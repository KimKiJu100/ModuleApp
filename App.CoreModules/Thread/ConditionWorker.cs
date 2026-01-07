using System;
using System.Threading;
using System.Threading.Tasks;

namespace App.CoreModules.Thread
{
    public class ConditionWorker : WorkerBase
    {
        private readonly Func<double, double, double, bool> _condition;
        private readonly Action _successAction;
        private readonly Action _scanningAction;
        private readonly TimeSpan _interval;
        private CancellationTokenSource _cts;

        public override string InstanceKey { get; set; } = string.Empty;
        public override bool IsRunning { get; protected set; }

        private double _minValue, _maxValue = 0;
        private double _currentValue = 0;
        private bool _oneFlag = false;

        public ConditionWorker(
            Func<double, double, double, bool> condition,
            Action successAction,
            Action ScanningAction,
            TimeSpan? interval = null)
        {
            _condition = condition ?? throw new ArgumentNullException(nameof(condition));
            _successAction = successAction ?? throw new ArgumentNullException(nameof(successAction));
            _scanningAction = ScanningAction ?? throw new ArgumentNullException(nameof(ScanningAction));
            _interval = interval ?? TimeSpan.FromMilliseconds(200);
        }
        public void SetCondition(double minValue, double maxValue)
        {
            _minValue = minValue;
            _maxValue = maxValue;
        }
        public void SetCurrentValue(double value)
        {
            _currentValue = value;
        }
        public override async Task StartAsync()
        {
            if (IsRunning) return;

            _cts = new CancellationTokenSource();
            IsRunning = true;
            try
            {
                await Task.Run(async () =>
                {
                    while (!_cts.Token.IsCancellationRequested)
                    {
                        if (_condition(_minValue, _maxValue, _currentValue))
                        {
                            if (!_oneFlag)
                            {
                                _oneFlag = true;
                                _successAction?.Invoke();
                            }
                        }
                        else
                        {
                            if (_oneFlag)
                            {
                                _oneFlag = false;
                                _scanningAction?.Invoke();
                            }
                        }

                        await Task.Delay(_interval, _cts.Token);
                    }
                });
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
        }
    }
}
