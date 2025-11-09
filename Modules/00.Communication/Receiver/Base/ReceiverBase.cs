using Modules.Communication.Intefaces;
using Modules.Communication.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Communication.Receiver.Base
{
    public class ReceiverBase : ICommunicationReceiver
    {
        public event EventHandler<string> OnPacketStringReceived;
        public event EventHandler<byte[]> OnPacketByteReceived;

        protected void RaisePacketReceived(object targetObject,string message)
        {
            OnPacketStringReceived?.Invoke(targetObject, message);
        }

        protected void RaisePacketByteReceived(object targetObject, byte[] message)
        {
            OnPacketByteReceived?.Invoke(targetObject, message);
        }

        public virtual void SetInstance(TypeBase Type)
        {
            throw new NotImplementedException("ReceiverBase클래스 SetInstance(TypeBase Type) - 구현 클래스에서 해당 메서드를 오버라이딩 되어있지 않습니다. 확인하세요.");
        }
        public virtual void ReceiveSet()
        {
            throw new NotImplementedException("ReceiverBase클래스 ReceiveSet - 구현 클래스에서 해당 메서드를 오버라이딩 되어있지 않습니다. 확인하세요.");
        }
    }
}
