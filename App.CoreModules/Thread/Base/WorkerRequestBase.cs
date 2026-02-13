using App.CoreModules.Events;
using App.CoreModules.Thread.Base.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.CoreModules.Thread.Base
{
    //리턴 객체를 기다린다. 정해진 커맨드 명령에따른 처리 후 종료 한다.
    public abstract class WorkerRequestBase<TPayLoad, TResponse> : 
        WorkerBase , IWorkerRequest<TResponse>
    {
        private readonly ConcurrentQueue<WorkerRequest<TPayLoad, TResponse>> _requests = new ConcurrentQueue<WorkerRequest<TPayLoad, TResponse>>();
        private CancellationTokenSource _cts;

        public EventHandler<ExceptionEventArgs> exceptionErrorError;
        public WorkerRequestBase()
        {
                
        }

        public override Task StartAsync()
        {
            _cts = new CancellationTokenSource();
            task = Task.Run(() => ExecuteLoopAsync(_cts.Token));
            return Task.CompletedTask;
        }

        public override void TaskStop()
        {
            _cts.Cancel();
            OnCanceled(this);
        }

        public Task<TResponse> RequestAsync(string command, object RequestPayLoad)
        {
            var req = new WorkerRequest<TPayLoad, TResponse>
            {
                Command = command,
                RequestPayLoad = (TPayLoad)RequestPayLoad
            };

            _requests.Enqueue(req);
            return req.Response.Task; 
        }

        private async Task ExecuteLoopAsync(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                if (_requests.TryDequeue(out WorkerRequest<TPayLoad, TResponse> req))
                {
                    try
                    {
                        var result = await HandleRequest(req.Command);
                        req.Response.SetResult(result);
                    }
                    catch (Exception ex)
                    {
                        exceptionErrorError?.Invoke(this, new ExceptionEventArgs(ex));
                    }
                    finally
                    {
                        OnCompleted(this);
                    }
                }
                await Task.Delay(1);
            }
        }

        protected abstract Task<TResponse> HandleRequest(string command);

        protected override void Dispose(bool disposing)
        {
            _cts.Cancel();
            base.Dispose(disposing);
        }
    }
}
