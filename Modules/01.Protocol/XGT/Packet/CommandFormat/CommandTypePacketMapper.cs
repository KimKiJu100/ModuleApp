using Modules.Protocol.XGT.Params;
using Modules.Protocol.XGT.Params.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Protocol.XGT.Packet.CommandFormat
{
    public class CommandTypePacketMapper : IPacketSectionBuilder
    {
        private readonly Dictionary<CommandType, byte[]> CommandTypeMap = new Dictionary<CommandType, byte[]>()
        {
            { CommandType.ReadRequest, new byte[] { 0x54 ,0x00 }},
            { CommandType.ReadResponse,new byte[] { 0x55 ,0x00 }},
            { CommandType.WriteRequest, new byte[] { 0x58 ,0x00 } },
            { CommandType.WriteResponse, new byte[] { 0x59 ,0x00 } },
        };

        public byte[] Build(XGTParams param)
        {
            if (!CommandTypeMap.TryGetValue(param.CommandParam.CommandType, out byte[] packets))
                throw new Exception($"지원하지 않는 {param.GetType().Name} 입니다.");

            return packets;
        }
    }
}
