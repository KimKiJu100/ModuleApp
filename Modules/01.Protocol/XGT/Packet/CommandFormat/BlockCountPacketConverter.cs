using Modules.Protocol.XGT.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Protocol.XGT.Packet.CommandFormat
{
    public class BlockCountPacketConverter : IPacketSectionBuilder
    {
        public byte[] Build(XGTParams param)
        {
            return new byte[] { Convert.ToByte(param.CommandParam.Data.BlockCount), 0x00 };
        }
    }
}
