using Modules.Communication.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyModule.CommunicationUI.Interface
{
    public interface IParamUserControl
    {
        CommParamBase GetParams();
        void SetParams(CommParamBase @param);
    }
}
