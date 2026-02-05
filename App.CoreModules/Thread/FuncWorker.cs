using App.CoreModules.Thread.Base;
using App.CoreModules.Thread.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.CoreModules.Thread
{
    public class FuncWorker<TPlayLoad,TResponse> : WorkerRequestBase<TPlayLoad, TResponse>, IGenaricWorkerAction
    {
        private readonly Func<TResponse> _func;
        private readonly TimeSpan _interval;

        private string _actionName = string.Empty;                  //메소드 이름 정보
        public string ActionName { get => _actionName; }

        public FuncWorker(Func<TResponse> func,
                             TimeSpan interval)
        {
            _func = func;
            _interval = interval;
            _actionName = func.Method.Name;
            InstanceKey = nameof(FuncWorker<TPlayLoad,TResponse>);
        }

        protected override Task<TResponse> HandleRequestAsync(string command)
        {
            if (command == "Invoke")
            {
                TResponse result = _func.Invoke();
                return Task.FromResult<TResponse>(result);
            }

            throw new InvalidOperationException($"Unknown command: {command}");
        }
    }
}
