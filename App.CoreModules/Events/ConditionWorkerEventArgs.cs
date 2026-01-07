using System;
using System.Collections.Generic;

namespace App.CoreModules.Thread
{ 
    public interface IConditionWorkerInfo
    {
        string InstanceKey { get; }
        bool IsRunning { get; }
    }

    public class ConditionWorkerEventArgs : EventArgs
    {
        public IEnumerable<IConditionWorkerInfo> Workers { get; }

        public ConditionWorkerEventArgs(IConditionWorkerInfo worker)
        {
            Workers = new List<IConditionWorkerInfo> { worker };
        }

        public ConditionWorkerEventArgs(IEnumerable<IConditionWorkerInfo> workers) 
        {
            Workers = workers;
        }
    }
}
