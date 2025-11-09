using Modules.Communication.Intefaces;
using Modules.Communication.Params;
using System;

namespace Modules.Communication.Receiver.Strategies
{
    public class Serial232ReceiverStrategy : ICommunicationReceiverStrategy
    {
        public bool CanHandle(CommParamBase param) => param is SerialParams;

        public ICommunicationReceiver Create()
        {
            throw new NotImplementedException();
        }

        //public ICommunicationReceiver Create() => new Serial232Receiver();
    }
}
