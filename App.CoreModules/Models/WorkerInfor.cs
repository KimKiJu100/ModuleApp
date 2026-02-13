using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.CoreModules.Models
{
    public class WorkerInfor : IEquatable<WorkerInfor>
    {
        public string WorkerName { get; set; }
        public string ActionMethod { get; set; }
        public string State { get; set; }

        public bool Equals(WorkerInfor other)
        {
            if (other == null)
                return false;

            return WorkerName == other.WorkerName &&
                ActionMethod == other.ActionMethod &&
                State == other.State;
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as WorkerInfor);
        }
    }
}
