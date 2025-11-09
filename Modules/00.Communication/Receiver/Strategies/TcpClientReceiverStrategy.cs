using Modules.Communication.Intefaces;
using Modules.Communication.Params;

namespace Modules.Communication.Receiver.Strategies
{
    public class TcpClientReceiverStrategy : ICommunicationReceiverStrategy
    {
        public bool CanHandle(CommParamBase param) => param is SocketParams;
        public ICommunicationReceiver Create() => new TCPClientReceiver();
    }
}
