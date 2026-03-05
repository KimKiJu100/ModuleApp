using App.CoreModules.Extensions;
using App.CoreModules.Models;
using App.CoreModules.Thread.Base;
using App.CoreModules.Thread.Base.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.CoreModules.Thread
{
    public class WorkerManager : IDisposable
    {
        private readonly ConcurrentDictionary<string, WorkerBase> _workers = new ConcurrentDictionary<string, WorkerBase>();
        private readonly ConcurrentQueue<string> _removeQueue = new ConcurrentQueue<string>();
        private bool _disposed;

        public bool IsRunning { get; private set; }

        public event EventHandler<ConditionWorkerEventArgs> WorkerAdded;
        public event EventHandler<ConditionWorkerEventArgs> WorkerRemoved;

        private void OnCompleted(object sender, EventArgs e)
        {
            if (sender is WorkerBase senderWorker)
            {
                _removeQueue.Enqueue(senderWorker.InstanceKey);
            }
        }
        private async Task CleanupLoop()
        {
            while (IsRunning)
            {
                while (_removeQueue.TryDequeue(out var key))
                {
                    if (_workers.TryRemove(key, out var target))
                    {
                        target.Completed -= OnCompleted;
                        target.Dispose();
                        WorkerRemoved?.Invoke(this, new ConditionWorkerEventArgs(target));
                    }
                }
                await Task.Delay(10);
            }
        }

        public WorkerManager()
        {
            IsRunning = true;
            Task.Run(CleanupLoop);
        }

        public void SetWorker(string keyName, WorkerBase worker)
        {
            worker.InstanceKey = keyName;
            worker.Completed += OnCompleted;

            if (!_workers.TryAdd(keyName, worker))
            {
                // 중복 차단 - 이미 등록된 키
                worker.Completed -= OnCompleted;
                return;
            }

            WorkerAdded?.Invoke(this, new ConditionWorkerEventArgs(worker));
        }
        public WorkerBase GetWorker(string key)
        {
            _workers.TryGetValue(key, out var worker);
            return worker;
        }
        public List<WorkerInfo> GetInformationWorkers()
        {
            List<WorkerInfo> infors = new List<WorkerInfo>();
            foreach (var worker in _workers.Values)
            {
                infors.Add(new WorkerInfo { WorkerName = worker.InstanceKey, State = worker.IsRunning ? "IsRunning" : "IsStop", ActionMethod = worker.ActionName });
            }
            return infors;
        }
        public void TargetWorkerStart(string key)
        {
            if (_workers.TryGetValue(key, out var targetWorker))
                targetWorker.StartAsync();
        }
        public void TargetWorkerStop(string key)
        {
            if (_workers.TryGetValue(key, out var targetWorker))
                targetWorker.TaskStop();
        }

        public async Task<TResponse> TargetWorkerStartRequest<TPayLoad, TResponse>(string key, WorkerRequest<TPayLoad, TResponse> request)
            where TPayLoad : class
        {
            if (!_workers.TryGetValue(key, out var targetWorker))
                throw new InvalidOperationException("키에 해당되는 Task는 없습니다.");

            //Task LoopAgin
            await targetWorker.StartAsync();
            if (targetWorker is IWorkerRequest<TResponse> requestWorker)
            {
                //외부 실행자 Task or UI스레드
                return await requestWorker.RequestAsync(request.Command, request.RequestPayLoad);
            }
            else
            {
                throw new InvalidCastException("해당 Worker는 RequestResponse 구조가 아닙니다.");
            }
        }
        public void workerAllStart()
        {
            foreach (var worker in _workers.Values) worker.StartAsync();
        }
        public void workerAllStop()
        {
            foreach (var worker in _workers.Values) worker.TaskStop();
        }
        public void workerAllClear()
        {
            foreach (var key in _workers.Keys) _removeQueue.Enqueue(key);
        }

        public async Task WaitWorker(IEnumerable<WorkerBase> workers)
        {
            var tasks = workers.ToList().ToWorkerBaseTask();
            await Task.WhenAll(tasks);
        }

        public void Dispose()
        {
            if (_disposed) return;
            _disposed = true;
            IsRunning = false;
            workerAllClear();
        }
    }
}
