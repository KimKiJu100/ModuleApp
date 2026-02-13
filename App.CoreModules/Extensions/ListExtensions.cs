using App.CoreModules.Thread;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.CoreModules.Extensions
{
    public static class ListExtension
    {
        public static IEnumerable<Task> ToWorkerBaseTask<T>(this List<T> sourceCollection) where T : WorkerBase
        {
            return sourceCollection.Select(worker => worker.task);
        }
    }
}
