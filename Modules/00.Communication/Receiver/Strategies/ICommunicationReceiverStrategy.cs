using Modules.Communication.Intefaces;
using Modules.Communication.Params;

namespace Modules.Communication.Receiver.Strategies
{
    public interface ICommunicationReceiverStrategy
    {
        bool CanHandle(CommParamBase param);
        ICommunicationReceiver Create();
    }
}
