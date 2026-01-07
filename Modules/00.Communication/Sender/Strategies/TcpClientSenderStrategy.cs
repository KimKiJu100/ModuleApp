using Modules.Communication.Intefaces;
using Modules.Communication.Params;

namespace Modules.Communication.Sender.Strategies
{
    public class TcpClientSenderStrategy : ICommunicationSenderStrategy
    {
        public bool CanHandle(CommParamBase param) => param is SocketParams;

        public ICommunicationSender Create() => new TCPClientSender();
    }
}
