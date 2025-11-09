using Modules.Protocol.XGT.Params.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Protocol.XGT.Params.CompanyHeader
{
    public class PLCInfoParam
    {
        public CommunicationType targetType { get; set; } = CommunicationType.Client;                        //0 : Client->Server 1: Server->Client
        public CpuType CPUType { get; set; } = CpuType.CPU_H;                                       //0:XGK/I/R-CPUH 1:XGK/I-CPUS 2:XGK-CPUA 3:XGK/I-CPUE 4:XGK/I-CPUU 5:XGK-CPUHN 6:XGK-CPUSN 7:XGK-CPUUN
        public CpuRedundancyType RedundancyType { get; set; } = CpuRedundancyType.Master;           //0:(이중화:Master / 단독) 1:(이중화Slave)
        public CpuState CPUState { get; set; } = CpuState.Normal;                                   //0:정상 1:에러
        public SystemState SystemState { get; set; } = SystemState.Run;                             //0:시작 //1:정지 //2:에러 //3:디버그
    }
}
