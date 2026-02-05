using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.CoreModules.Thread.Base.Interfaces
{
    public interface IWorkerRequest<TResponse>
    {
        Task<TResponse> RequestAsync(string cmd, object payload);
    }
}
