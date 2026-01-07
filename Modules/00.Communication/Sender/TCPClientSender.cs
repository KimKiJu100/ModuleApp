using Modules.Communication.Sender.Base;
using Modules.Communication.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Communication.Sender
{
    public class TCPClientSender : SenderBase
    {
        private Socket _soc;

        public override void SetInstance(TypeBase Type)
        {
            if (Type is TCPClientSocketType type)
                _soc = type.Instance;
            else
                throw new Exception("Error - 타입 변환이 정상적이지 않습니다. 확인하세요.");
        }

        public override void Send(byte[] data)
        {
            _soc.Send(data);
        }
    }
}
