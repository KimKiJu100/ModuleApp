using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.CoreModules.Models
{
    public class WorkerInfo : IEquatable<WorkerInfo>
    {
        public string WorkerName { get; set; }
        public string ActionMethod { get; set; }
        public string State { get; set; }

        public bool Equals(WorkerInfo other)
        {
            if (other == null)
                return false;

            return WorkerName == other.WorkerName &&
                ActionMethod == other.ActionMethod &&
                State == other.State;
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as WorkerInfo);
        }
        public override int GetHashCode()
        {
            int hash = WorkerName?.GetHashCode() ?? 0;
            hash = (hash * 397) ^ (ActionMethod?.GetHashCode() ?? 0);
            hash = (hash * 397) ^ (State?.GetHashCode() ?? 0);
            return hash;
        }
    }
}
