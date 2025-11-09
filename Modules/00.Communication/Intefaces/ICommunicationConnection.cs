using Modules.Communication.Params;
using Modules.Communication.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Communication.Intefaces
{
    public interface ICommunicationConnection : ITypeBasedInjectable
    {
        bool Connection();                  //초기 설정
        bool Connection(CommParamBase param);                  //파라미터로 초기 설정 

        bool DisConnection();
    }
}
