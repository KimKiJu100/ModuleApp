using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Protocol.Base
{
    public abstract class PacketBase
    {
        public virtual bool CanParams(ProtocolParamBase paramBase)
        {
            throw new NotImplementedException("PacketBase클래스 CanParams(ProtocolParamBase) - 구현 클래스에서 해당 메서드를 오버라이딩 되어있지 않습니다. 확인하세요.");
        }

        public virtual byte[] BuildPacket(ProtocolParamBase paramBase)
        {
            throw new NotImplementedException("PacketBase클래스 BuildPacket(ProtocolParamBase) - 구현 클래스에서 해당 메서드를 오버라이딩 되어있지 않습니다. 확인하세요.");
        }
    }
}
