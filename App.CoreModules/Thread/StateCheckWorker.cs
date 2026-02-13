using App.CoreModules.Thread.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.CoreModules.Thread
{
    public class StateCheckWorker : WorkerBase
    {
        private readonly IConditionRule _conditionRule;
        private readonly IConditionAction _successAction;
        private readonly IConditionAction _scanningAction;

        private readonly TimeSpan _interval;
        private CancellationTokenSource _cts;

        public EventHandler<bool> OnStateChanged;
        private bool stateChanged = false;

        private string _conditionName = string.Empty;

        public override string InstanceKey { get; set; } = string.Empty;
        public override string ActionName => _conditionName;

        public StateCheckWorker(
            IConditionRule conditionRule = null,
            IConditionAction success = null,
            IConditionAction scanning = null,
            TimeSpan? interval = null)
        {
            _conditionRule = conditionRule;
            _successAction = success;
            _scanningAction = scanning;
            _interval = interval ?? TimeSpan.FromMilliseconds(200);

            _conditionName = _conditionRule.RuleName;
        }

        public override async Task StartAsync()
        {
            if (IsRunning) return;

            _cts = new CancellationTokenSource();
            IsRunning = true;
            try
            {
                task = Task.Run(async () =>
                {
                    while (!_cts.Token.IsCancellationRequested)
                    {
                        var result = _conditionRule.Check();

                        if (stateChanged != result)
                        {
                            stateChanged = result;
                            OnStateChanged?.Invoke(this, stateChanged);
                        }
                        if (result)
                        {
                            _successAction?.OnAction();
                        }
                        else
                        {
                            _scanningAction?.OnAction();
                        }
                        await Task.Delay(_interval, _cts.Token);
                    }
                });

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
