using Modules.Protocol.XGT.Params.CompanyHeader;
using Modules.Protocol.XGT.Params.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Protocol.XGT.Packet.Mapper
{
    public class PLCInforLowMapper
    {
        private readonly Dictionary<CpuType, byte> CpuTypeMap = new Dictionary<CpuType, byte>()
        {
            { CpuType.CPU_H, 0x01 },
            { CpuType.CPU_S, 0x02 },
            { CpuType.CPU_A, 0x03 },
            { CpuType.CPU_E, 0x04 },
            { CpuType.CPU_U, 0x05 },
            { CpuType.CPU_HN, 0x11 },
            { CpuType.CPU_SN, 0x12 },
            { CpuType.CPU_UN, 0x15 }
        };

        public byte GetByte(PLCInfoParam param)
        {
            if (!CpuTypeMap.TryGetValue(param.CPUType, out byte cpuBase))
                throw new Exception("지원하지 않는 CPU type 입니다.");

            byte result = cpuBase;

            if (param.RedundancyType == CpuRedundancyType.Master)
                result |= 0x40;

            if (param.CPUState == CpuState.Normal)
                result |= 0x80;

            return result;
        }

    }
}
