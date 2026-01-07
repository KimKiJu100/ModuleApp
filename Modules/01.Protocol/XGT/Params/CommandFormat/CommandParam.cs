using Modules.Protocol.XGT.Params.CommandFormat.Data;
using Modules.Protocol.XGT.Params.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Protocol.XGT.Params.CommandFormat
{
    public class CommandParam
    {
        public CommandType CommandType { get; set; } = 0;           
        public DataType DataType { get; set; } = 0;              
        public XgtDataParam Data { get; set; } = new XgtDataParam();
    }
}
