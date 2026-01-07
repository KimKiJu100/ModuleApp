using Modules.Protocol.XGT.Params.CompanyHeader;
using Modules.Protocol.XGT.Params.Enums;

namespace Modules.Protocol.XGT.Params
{
    public class CompanyHeaderParam
    {
        public string CompanyID { get; set; } = string.Empty;

        //이것도 클래스 내부
        public PLCInfoParam PLCInfo { get; set; } = new PLCInfoParam();
        public CpuInfor CPUInfo { get; set; } = CpuInfor.XGK;
        public CommunicationType SourceOfFrame { get; set; } = CommunicationType.Client;
        public int invokeID { get; set; } = 0;
        public int CommandLength { get; set; } = 0;

        //이것도 클래스 내부
        public EthernetPosition EnetPosition { get; set; } = new EthernetPosition();

        public int Reverse2 { get; set; } = 0;
    }
}
