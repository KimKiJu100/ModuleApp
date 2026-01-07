using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Communication.Type
{
    public class Serial232Type : TypeBase
    {
        private SerialPort _instance;

        public override bool IsConnection { get => _instance.IsOpen; }
        public Serial232Type()
        {
            _instance = new SerialPort();
        }
    }
}
