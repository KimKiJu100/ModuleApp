using Modules.Communication.Intefaces;
using Modules.Communication.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Communication.Sender.Strategies
{
    public interface ICommunicationSenderStrategy
    {
        bool CanHandle(CommParamBase param);
        ICommunicationSender Create();
    }
}
