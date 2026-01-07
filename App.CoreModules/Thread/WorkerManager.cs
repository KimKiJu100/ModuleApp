using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.CoreModules.Thread
{
    public class WorkerManager
    {
        private List<WorkerBase> _workers;
        private readonly ConcurrentQueue<string> _removeQueue = new ConcurrentQueue<string>();

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
                    var target = _workers.FirstOrDefault(w => w.InstanceKey == key);
                    if (target != null)
                    {
                        target.TaskStop();
                        target.Completed -= OnCompleted;
                        _workers.Remove(target);
                        WorkerRemoved?.Invoke(this, new ConditionWorkerEventArgs(target));
                    }
                }
                await Task.Delay(10);
            }
        }

        public WorkerManager()
        {
            _workers = new List<WorkerBase>();
            IsRunning = true;
            Task.Run(CleanupLoop);
        }

        public void SetWorker(string keyName, WorkerBase worker)
        {
            //중복 차단
            if (_workers.Any(w => w.InstanceKey == keyName)) return; 

            worker.InstanceKey = keyName;
            worker.Completed += OnCompleted;

            _workers.Add(worker);

            WorkerAdded?.Invoke(this, new ConditionWorkerEventArgs(_workers));
        }
        public WorkerBase GetWorker(string key)
        {
            var targetWorker = _workers.FirstOrDefault(w => w.InstanceKey == key);
            return targetWorker; 
        }
        public void TargetWorkerStart(string key)
        {
            var targetWorker = _workers.FirstOrDefault(w => w.InstanceKey == key);
            if(targetWorker != null)
                targetWorker.StartAsync();
        }
        public void TargetWorkerStop(string key)
        {
            var targetWorker = _workers.FirstOrDefault(w => w.InstanceKey == key);
            if (targetWorker != null)
                targetWorker.TaskStop();
        }
        public void workerAllStart()
        {
            _workers.ForEach(worker => worker.StartAsync());
        }
        public void workerAllStop()
        {
            _workers.ForEach(worker => worker.TaskStop());
        }
        //이부분은 외부에서 언박싱후 처리하는게 맞아 
        //public void workerCurrentValueSet(string key, double value)
        //{
        //    var targetWorker = _workers.FirstOrDefault(w => w.InstanceKey == key);
        //    targetWorker.SetCurrentValue(value);
        //}

        public void workerAllClear()
        {
            _workers.ForEach(worker => _removeQueue.Enqueue(worker.InstanceKey));
        }
    }
}
