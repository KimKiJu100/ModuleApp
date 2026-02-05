using Modules._00.Communication.State.Base;
using Modules.Communication.Intefaces;
using Modules.Communication.Params;
using Modules.Communication.Sender;
using Modules.Communication.Sender.Strategies;
using Modules.Communication.Type;
using Modules.Communication.Type.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules._00.Communication.State.Strategies
{
    public class SerialStateStrategy : ICommunicationStaterStrategy
    {
        public bool CanHandle(CommParamBase param) => param is SerialParams;

        public IComunicationState Create() => new Serial232State();
    }
}
