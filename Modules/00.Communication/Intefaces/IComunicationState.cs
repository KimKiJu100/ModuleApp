using Modules.Communication.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules._00.Communication.State
{
    public interface IComunicationState : ITypeBasedInjectable , IDisposable
    {
        bool GetConnectionState();
        void SetConnectionState(bool connectionState);
    }
}
