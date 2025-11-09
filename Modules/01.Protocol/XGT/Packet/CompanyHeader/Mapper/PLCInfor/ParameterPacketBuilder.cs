using Modules.Attributes;
using Modules.Protocol.XGT.Params;
using Modules.Protocol.XGT.Params.CompanyHeader;
using Modules.Protocol.XGT.Params.Enums;

namespace Modules.Protocol.XGT.Packet.Mapper.PLCInfor
{
    public class ParameterPacketBuilder:IPacketSectionBuilder
    {
        private PLCInforLowMapper lowByte = new PLCInforLowMapper();
        private PLCInfoHighByteMapper highByte = new PLCInfoHighByteMapper();

        public byte[] Build(XGTParams param)
        {
            byte[] resultByte = new byte[] { 0x00, 0x00 };
            if (param.CompanyHeaderParam.PLCInfo.targetType == CommunicationType.Client) return resultByte;

            resultByte[0] = lowByte.GetByte(param.CompanyHeaderParam.PLCInfo);
            resultByte[1] = highByte.GetByte(param.CompanyHeaderParam.PLCInfo.SystemState);

            return resultByte;
        }

        public byte[] BuildPacket(PLCInfoParam param)
        {
            byte[] resultByte = new byte[] { 0x00, 0x00 };

            resultByte[0] = lowByte.GetByte(param);
            resultByte[1] = highByte.GetByte(param.SystemState);

            return resultByte;
        }
    }
}
