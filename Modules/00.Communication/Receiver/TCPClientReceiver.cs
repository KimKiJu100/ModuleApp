using Modules.Communication.Receiver.Base;
using Modules.Communication.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Communication.Receiver
{
    public class TCPClientReceiver : ReceiverBase
    {
        private Socket _soc;
        private SocketAsyncEventArgs _receiveEventArgs;
        private byte[] _buffer = new byte[1024];

        public TCPClientReceiver()
        {
        }

        public override void SetInstance(TypeBase Type)
        {
            if (Type is TCPClientSocketType type)
                _soc = type.Instance;
            else
                throw new Exception("Error - 타입 변환이 정상적이지 않습니다. 확인하세요.");
        }

        public override void ReceiveSet()
        {
            if (_soc == null)
                throw new Exception("소켓 인스턴스가 설정되지 않았습니다. SetInstance 먼저 호출하세요.");

            _receiveEventArgs = new SocketAsyncEventArgs();
            _receiveEventArgs.SetBuffer(_buffer, 0, _buffer.Length);
            _receiveEventArgs.Completed += OnReceiveCompleted;
            _receiveEventArgs.UserToken = _soc;

            if (!_soc.ReceiveAsync(_receiveEventArgs)) {
                OnReceiveCompleted(this, _receiveEventArgs);
            }
        }

        private void OnReceiveCompleted(object sender, SocketAsyncEventArgs e)
        {
            if (e.BytesTransferred > 0 && e.SocketError == SocketError.Success)
            {
                string message = Encoding.UTF8.GetString(e.Buffer, 0, e.BytesTransferred);
                byte[] bytedata = new byte[e.BytesTransferred]; 
                Array.Copy(e.Buffer, 0, bytedata, 0, e.BytesTransferred);

                //해당 패캣을 만들어 외부에 알려준다. 이벤트 선언이 필요 함.
                RaisePacketReceived(this,message);
                RaisePacketByteReceived(this, bytedata);

                if (!((Socket)e.UserToken).ReceiveAsync(e))
                {
                    OnReceiveCompleted(sender, e);
                }
            }
            else
                throw new Exception("Error - Disconnected from server.");
        }
    }
}
