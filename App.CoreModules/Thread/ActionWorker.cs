using App.CoreModules.Thread.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.CoreModules.Thread
{
    public class ActionWorker<TActionParamType> : WorkerBase 
    {
        private readonly Action<TActionParamType> _action;
        private readonly TimeSpan _interval;

        private CancellationTokenSource _cts;
        private TActionParamType _paramType;
        private Task task;

        private string _actionName = string.Empty;                  //메소드 이름 정보
        public override string ActionName { get => _actionName; }

        public ActionWorker(Action<TActionParamType> action,
                             TimeSpan interval)
        {
            _action = action;
            _interval = interval;
            _actionName = _action.Method.Name;
        }

        public void SetActionParams(TActionParamType paramType)
        {
            _paramType = paramType;
        }

        public override async Task StartAsync()
        {
            if (IsRunning) return;
            if (_paramType == null) throw new ArgumentException("_paramType를 설정 하지 않고 worker를 실행하려고 했습니다.");

            _cts = new CancellationTokenSource();
            IsRunning = true;
            try
            {
                task = Task.Run(() =>
                {
                    _action(_paramType);
                }, _cts.Token);
                
                await task;
            }
            finally
            {
                IsRunning = false;
                OnCompleted(this);
            }
        }
        public override void TaskStop()
        {
            _cts.Cancel();
            OnCanceled(this);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _cts.Cancel();
            }
            base.Dispose(disposing);
        }
    }
}
