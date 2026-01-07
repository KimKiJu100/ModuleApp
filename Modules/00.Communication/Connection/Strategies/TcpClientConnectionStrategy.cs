using Modules.Communication.Intefaces;
using Modules.Communication.Params;

namespace Modules.Communication.Connection.Strategies
{
    public class TcpClientConnectionStrategy : ICommunicationConnectionStrategy
    {
        public bool CanHandle(CommParamBase param) => param is SocketParams;

        public ICommunicationConnection Create() => new TCPClientConnection();
    }
}
