using Modules.Attributes;
using Modules.Protocol.XGT.Params;
using Modules.Protocol.XGT.Params.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Protocol.XGT.Packet.Mapper.CPUInfors
{
    public class CpuInforPacketMapper : IPacketSectionBuilder
    {
        private readonly Dictionary<CpuInfor, byte[]> CpuInforMap = new Dictionary<CpuInfor, byte[]>()
        {
            { CpuInfor.XGK, new byte[]{ 0xA0 }},
            { CpuInfor.XGB_MK, new byte[]{ 0xB0 }},
            { CpuInfor.XGI, new byte[]{ 0xA4 }},
            { CpuInfor.XGB_IEC, new byte[]{ 0xB4 }},
            { CpuInfor.XGR, new byte[]{ 0xA8 }},
        };

        public byte[] Build(XGTParams param)
        {
            if (!CpuInforMap.TryGetValue(param.CompanyHeaderParam.CPUInfo, out byte[] packet))
                throw new Exception(string.Format("지원하지 않는 {0} 입니다.", param.GetType().Name));

            return packet;
        }
    }
}
