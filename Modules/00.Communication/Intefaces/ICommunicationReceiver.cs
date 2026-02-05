using Modules.Communication.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Communication.Intefaces
{
    public interface ICommunicationReceiver : ITypeBasedInjectable, IDisposable
    {
        event EventHandler<string> OnPacketStringReceived;
        event EventHandler<byte[]> OnPacketByteReceived;
        void ReceiveSet();                  // 초기 설정
        void ReceiveRemoveSet();            // 이벤트 해제 메서드
    }
}
