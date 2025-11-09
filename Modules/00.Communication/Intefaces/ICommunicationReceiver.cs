using Modules.Communication.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Communication.Intefaces
{
    public interface ICommunicationReceiver : ITypeBasedInjectable
    {
        event EventHandler<string> OnPacketStringReceived;
        event EventHandler<byte[]> OnPacketByteReceived;
        void ReceiveSet();                  // 초기 설정
    }
}
