using Modules.Communication.Sender.Base;
using Modules.Communication.Type;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Communication.Sender
{
    public class Serial232Sender : SenderBase
    {
        private SerialPort _port;

        public override void SetInstance(TypeBase Type)
        {
            if (Type is Serial232Type type)
                _port = type.Instance;
            else
                throw new Exception("Error - 타입 변환이 정상적이지 않습니다. 확인하세요.");
        }

        public override void Send(byte[] data)
        {
            throw new Exception("해당 구현 인스턴스는 byte Sender형식을 지원하지 않습니다.[필요 시 해당 메서드에 정의 필요.]");
        }

        public override void Send(string data)
        {
            _port.Write(data);
        }

        protected override void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 관리형 상태(관리형 개체)를 삭제합니다.
                    _port = null;
                }

                // TODO: 비관리형 리소스(비관리형 개체)를 해제하고 종료자를 재정의합니다.
                // TODO: 큰 필드를 null로 설정합니다.
                disposedValue = true;
            }
        }
    }
}
