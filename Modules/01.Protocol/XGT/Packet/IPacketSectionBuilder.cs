using Modules.Protocol.XGT.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Protocol.XGT.Packet
{
    public interface IPacketSectionBuilder
    {
        byte[] Build(XGTParams param);
    }
}
