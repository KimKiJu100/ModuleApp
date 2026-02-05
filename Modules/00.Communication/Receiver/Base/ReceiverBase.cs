using Modules.Communication.Intefaces;
using Modules.Communication.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Communication.Receiver.Base
{
    public class ReceiverBase : ICommunicationReceiver,IDisposable
    {
        protected bool disposedValue;

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
        public virtual void ReceiveRemoveSet()
        {
            throw new NotImplementedException("ReceiverBase클래스 ReceiveRemoveSet - 구현 클래스에서 해당 메서드를 오버라이딩 되어있지 않습니다. 확인하세요.");
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 관리형 상태(관리형 개체)를 삭제합니다.
                    OnPacketStringReceived = null;
                    OnPacketByteReceived = null;
                }

                // TODO: 비관리형 리소스(비관리형 개체)를 해제하고 종료자를 재정의합니다.
                // TODO: 큰 필드를 null로 설정합니다.
                disposedValue = true;
            }
        }

        // // TODO: 비관리형 리소스를 해제하는 코드가 'Dispose(bool disposing)'에 포함된 경우에만 종료자를 재정의합니다.
        // ~ReceiverBase()
        // {
        //     // 이 코드를 변경하지 마세요. 'Dispose(bool disposing)' 메서드에 정리 코드를 입력합니다.
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // 이 코드를 변경하지 마세요. 'Dispose(bool disposing)' 메서드에 정리 코드를 입력합니다.
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
