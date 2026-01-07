using Modules.Communication.Intefaces;
using Modules.Communication.Params;
using Modules.Communication.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Communication.Connection.Base
{
    //TODO 커넥션 풀링 개념 도입이 필요함.
    public abstract class ConnectionBase : ICommunicationConnection
    {
        protected bool IsConnected { get; set; }

        public virtual bool Connection()
        {
            throw new NotImplementedException("ConnectionBase클래스 Connection - 구현 클래스에서 해당 메서드를 오버라이딩 되어있지 않습니다. 확인하세요.");
        }

        public virtual bool Connection(CommParamBase param)
        {
            throw new NotImplementedException("ConnectionBase클래스 Connection(Param) - 구현 클래스에서 해당 메서드를 오버라이딩 되어있지 않습니다. 확인하세요.");
        }

        public virtual void SetInstance(TypeBase Type)
        {
            throw new NotImplementedException("ConnectionBase클래스 SetInstance(TypeBase Type) - 구현 클래스에서 해당 메서드를 오버라이딩 되어있지 않습니다. 확인하세요.");
        }

        public virtual bool DisConnection()
        {
            throw new NotImplementedException("ConnectionBase클래스 DisConnection - 구현 클래스에서 해당 메서드를 오버라이딩 되어있지 않습니다. 확인하세요.");
        }
    }
}
