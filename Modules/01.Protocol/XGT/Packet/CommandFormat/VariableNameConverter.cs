using Modules.Protocol.XGT.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Protocol.XGT.Packet.CommandFormat
{
    public class VariableNameConverter : IPacketSectionBuilder
    {
        public byte[] Build(XGTParams param)
        {
            return Encoding.ASCII.GetBytes(param.CommandParam.Data.DataAddress); 
        }
    }
}
