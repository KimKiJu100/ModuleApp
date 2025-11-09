using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace Modules.Communication.Params
{
    public class SerialParams : CommParamBase
    {
        public string PortName { get; set; } = "COM1";
        public int baudRate { get; set; } = 9600;
        public Parity Parity { get; set; } = Parity.None;
        public int DataBits { get; set; } = 8;
        public StopBits StopBits { get; set; } = StopBits.None;
    }
}
