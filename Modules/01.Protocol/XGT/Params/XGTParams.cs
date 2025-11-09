using Modules.Protocol.Base;
using Modules.Protocol.XGT.Params.CommandFormat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Protocol.XGT.Params
{
    public class XGTParams : ProtocolParamBase
    {
        public CompanyHeaderParam CompanyHeaderParam { get; set; } = new CompanyHeaderParam();
        public CommandParam CommandParam { get; set; } = new CommandParam();
    }
}
