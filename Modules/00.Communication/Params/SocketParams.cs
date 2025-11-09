using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Communication.Params
{
    public class SocketParams : CommParamBase
    {
        public string IpAddress { get; set; } = string.Empty;
        public int Port { get; set; } = 502;
    }
}
