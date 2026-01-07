using Modules.Communication.Intefaces;
using Modules.Communication.Params;
using System;

namespace Modules.Communication.Connection.Strategies
{
    public class Serial232ConnectionStrategy : ICommunicationConnectionStrategy
    {
        public bool CanHandle(CommParamBase param) => param is SerialParams;

        public ICommunicationConnection Create()
        {
            throw new NotImplementedException();
        }
    }
}
