using Modules.Attributes;
using Modules.Protocol.XGT.Params;
using Modules.Protocol.XGT.Params.Enums;
using System;
using System.Collections.Generic;

namespace Modules.Protocol.XGT.Packet.Mapper.SourceOfFrame
{
    public class SourceOfFramePacketMapper : IPacketSectionBuilder
    {
        private readonly Dictionary<CommunicationType, byte> SourceOfFrameMap = new Dictionary<CommunicationType, byte>()
        {
            { CommunicationType.Client, 0x33 },
            { CommunicationType.Server, 0x02 },
        };

        public byte[] Build(XGTParams param)
        {
            return new byte[] { GetPacket(param.CompanyHeaderParam.SourceOfFrame) }; 
        }

        private  byte GetPacket(CommunicationType param)
        {
            if (!SourceOfFrameMap.TryGetValue(param, out byte packet))
                throw new Exception("지원하지 않는 SourceOfFrame 입니다.");

            return packet;
        }
    }
}
