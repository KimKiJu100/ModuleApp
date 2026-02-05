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
        protected override void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 관리형 상태(관리형 개체)를 삭제합니다.
                    _soc = null;
                }

                // TODO: 비관리형 리소스(비관리형 개체)를 해제하고 종료자를 재정의합니다.
                // TODO: 큰 필드를 null로 설정합니다.
                disposedValue = true;
            }
        }
    }
}
