using Modules.Communication.Intefaces;
using Modules.Communication.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules._00.Communication.State.Strategies
{
    public interface ICommunicationStaterStrategy
    {
        bool CanHandle(CommParamBase param);
        IComunicationState Create();
    }
}
