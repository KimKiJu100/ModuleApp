using Modules.Communication.Receiver.Base;
using Modules.Communication.Type;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Communication.Receiver
{
    public class Serial232Receiver : ReceiverBase
    {
        private SerialPort _port;
        private SocketAsyncEventArgs _receiveEventArgs;
        private byte[] _buffer = new byte[1024];
        private string FrameBuffer = string.Empty;
        public override void SetInstance(TypeBase Type)
        {
            if (Type is Serial232Type type)
                _port = type.Instance;
            else
                throw new Exception("Error - 타입 변환이 정상적이지 않습니다. 확인하세요.");
        }

        public override void ReceiveSet()
        {
            if (_port == null)
                throw new Exception("SerialPort 인스턴스가 설정되지 않았습니다. SetInstance 먼저 호출하세요.");

            //이벤트 구독 
            _port.DataReceived += _port_DataReceived;
        }

        public override void ReceiveRemoveSet()
        {
            if (_port == null)
                throw new Exception("SerialPort 인스턴스가 설정되지 않았습니다. SetInstance 먼저 호출하세요.");

            //이벤트 구독 
            _port.DataReceived -= _port_DataReceived;
        }

        private void _port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //var readLine = _port.ReadLine();

            var readLine = _port.ReadExisting();
            if (readLine.Contains('\r')) {
                FrameBuffer += readLine;
                RaisePacketReceived(this, FrameBuffer);
                FrameBuffer = string.Empty;
            }
            else {
                FrameBuffer += readLine;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 관리형 상태(관리형 개체)를 삭제합니다.
                    //이벤트 구독 
                    _port.DataReceived -= _port_DataReceived;
                    _port = null;
                }

                // TODO: 비관리형 리소스(비관리형 개체)를 해제하고 종료자를 재정의합니다.
                // TODO: 큰 필드를 null로 설정합니다.
                disposedValue = true;
            }
        }
    }
}
