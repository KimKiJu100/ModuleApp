using Modules.Communication.Intefaces;
using Modules.Communication.Params;
using System;

namespace Modules.Communication.Sender.Strategies
{
    public class SerialSenderStrategy : ICommunicationSenderStrategy
    {
        public bool CanHandle(CommParamBase param) => param is SerialParams;

        public ICommunicationSender Create() => new Serial232Sender();
    }
}
