using Modules.Communication.Intefaces;
using Modules.Communication.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Communication.Sender.Base
{
    public abstract class SenderBase : ICommunicationSender
    {
        public virtual void SetInstance(TypeBase Type)
        {
            throw new NotImplementedException("SenderBase클래스 SetInstance(TypeBase Type) - 구현 클래스에서 해당 메서드를 오버라이딩 되어있지 않습니다. 확인하세요.");
        }

        public virtual void Send(byte[] data)
        {
            throw new NotImplementedException("SenderBase클래스 Send(data) - 구현 클래스에서 해당 메서드를 오버라이딩 되어있지 않습니다. 확인하세요.");
        }
    }
}
