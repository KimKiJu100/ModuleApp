using System;
using System.Threading;
using System.Threading.Tasks;

namespace App.CoreModules.Thread
{
    public class WorkerBase : IConditionWorkerInfo
    {
        public virtual string InstanceKey { get; set; }
        public virtual bool IsRunning { get; protected set; }
        public virtual async Task StartAsync() { }
        public virtual void TaskStop() { }

        public event EventHandler Completed;
        protected virtual void OnCompleted(object InvokeInstance)
        {
            Completed?.Invoke(InvokeInstance, EventArgs.Empty);
        }
    }
}
