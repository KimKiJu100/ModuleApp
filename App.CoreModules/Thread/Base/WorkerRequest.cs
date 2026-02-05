using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.CoreModules.Thread.Base
{
    public class WorkerRequest<TPayLoad, TResponse>
    {
        public string Command { get; set; } = string.Empty;
        public TPayLoad RequestPayLoad { get; set; }
        public TaskCompletionSource<TResponse> Response = new TaskCompletionSource<TResponse>();
    };
}
