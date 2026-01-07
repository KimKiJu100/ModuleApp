using Modules.Protocol.XGT.Params;
using Modules.Protocol.XGT.Params.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Protocol.XGT.Packet.CommandFormat
{
    public class DataTypePacketMapper : IPacketSectionBuilder
    {
        private readonly Dictionary<DataType, byte[]> DataTypeMap = new Dictionary<DataType, byte[]>()
        {
            { DataType.Bit, new byte[] { 0x00 ,0x00 }},
            { DataType.Byte,new byte[] { 0x01 ,0x00 }},
            { DataType.Word, new byte[] { 0x02 ,0x00 } },
            { DataType.DWord, new byte[] { 0x03 ,0x00 } },
            { DataType.LWord, new byte[] { 0x04 ,0x00 } },
            { DataType.ByteBlock, new byte[] { 0x14 ,0x00 } },
        };

        public byte[] Build(XGTParams param)
        {
            if (!DataTypeMap.TryGetValue(param.CommandParam.DataType, out byte[] packets))
                throw new Exception($"지원하지 않는 {param.CommandParam.DataType.GetType().Name} 입니다.");

            return packets;
        }
    }
}
