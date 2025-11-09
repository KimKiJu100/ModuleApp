using Modules.Protocol.XGT.Params.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Extensions
{
    public static class XgtPacketExtension
    {
        public static CpuType ToCpuType(this string cpuType)
        {
            if (Enum.TryParse(cpuType, true, out CpuType result))
                return result;

            throw new ArgumentException($"지원하지 않는 type: {cpuType}");
        }

        public static CpuInfor ToCpuInfor(this string cpuInfo)
        {
            if (Enum.TryParse(cpuInfo, true, out CpuInfor result))
                return result;

            throw new ArgumentException($"지원하지 않는 CPU type: {cpuInfo}");
        }
    }
}
