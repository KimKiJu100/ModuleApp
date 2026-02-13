using Modules._00.Communication.State.Base;
using Modules.Communication.Params;
using Modules.Communication.Type.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules._00.Communication.State.Strategies
{
    public class TCPClientStateStrategy : ICommunicationStaterStrategy
    {
        public bool CanHandle(CommParamBase param) => param is SocketParams;

        public IComunicationState Create() => new TCPClientSocketState();
    }
}
