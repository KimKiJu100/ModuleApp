using Modules.Helper;
using Modules.Protocol.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Protocol.Facotrys
{
    public class ProtocolFactory
    {
        List<PacketBase> _packetCollection;
        public ProtocolFactory()
        {
            _packetCollection = CollectionHelper.LoadCollectionBaseClass<PacketBase>();
        }

        public PacketBase CreateProtocolPacket(ProtocolParamBase param)
        {
            return _packetCollection.FirstOrDefault(s => s.CanParams(param));
            throw new ArgumentException("지원하지 않는 통신 프로토콜입니다.");
        }
    }
}
