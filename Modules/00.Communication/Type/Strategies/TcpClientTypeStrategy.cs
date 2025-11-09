using Modules.Communication.Params;

namespace Modules.Communication.Type.Strategies
{
    public class TcpClientTypeStrategy : ICommunicationTypeStrategy
    {
        public bool CanHandle(CommParamBase param) => param is SocketParams;
        public TypeBase Create() => new TCPClientSocketType();
    }
}
