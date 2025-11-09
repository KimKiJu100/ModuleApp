using Modules.Protocol.XGT.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Protocol.XGT.Packet.CompanyHeader.Mapper
{
    public class NoneDataPacketBuilder : IPacketSectionBuilder
    {
        public byte[] Build(XGTParams param)
        {
            return new byte[] { 0x00, 0x00 };
        }
    }

    public class OneByteNoneDataPacketBuilder : IPacketSectionBuilder
    {
        public byte[] Build(XGTParams param)
        {
            return new byte[] { 0x00 };
        }
    }
}
