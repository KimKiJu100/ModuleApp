using Modules.Attributes;
using Modules.Protocol.XGT.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Protocol.XGT.Packet.CompanyHeader.Mapper
{
    public class CompanyIDPacketBuilder : IPacketSectionBuilder
    {
        public byte[] Build(XGTParams param)
        {
            var companyId = Encoding.ASCII.GetBytes(param.CompanyHeaderParam.CompanyID);
            var fixedCompanyId = new byte[10];
            Array.Copy(companyId, fixedCompanyId, companyId.Length);
            return fixedCompanyId; 
        }
    }
}
