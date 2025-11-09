using Modules.Helper;
using Modules.Protocol.XGT.Params;
using Modules.Protocol.XGT.Params.CompanyHeader;
using System;

namespace Modules.Protocol.XGT.Packet.Mapper.EthernetPositions
{
    public class EthernetPositionPacketBuilder : IPacketSectionBuilder
    {
        public byte[] Build(XGTParams param)
        {
            var packetByte = new byte[] { GetPacket(param.CompanyHeaderParam.EnetPosition) };
            return packetByte;
        }

        private byte GetPacket(EthernetPosition param)
        {
            //상위 비트
            byte reulst = Convert.ToByte(param.EthernetBaseNumber);
            BitHelper.ShiftByteLeft(reulst, 5);
            //하위 비트
            reulst |= Convert.ToByte(param.EthernetSlotPosition);
            return reulst;
        }
    }
}
