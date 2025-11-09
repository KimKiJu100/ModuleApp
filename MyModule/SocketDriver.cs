using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace MyModule
{
    public class SocketDriver
    {
        private Socket _clientSocket;
        private SocketAsyncEventArgs _receiveEventArgs;
        private byte[] _buffer = new byte[1024];
        public bool IsConnected => throw new NotImplementedException();

        //public event ValueTriggerEventHandler ValueTrigger;
        //public event TerminatedEventHandler Terminated;

        public SocketDriver()
        {
            _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }
        public bool Connecntion()
        {
            _clientSocket.Connect(IPAddress.Parse("127.0.0.1"), 2004);
            if (_clientSocket.Connected)
            {
                init();
            }
            return _clientSocket.Connected;
        }

        public bool DisConnecntion()
        {
            throw new NotImplementedException();
        }

        public byte[] Receive()
        {
            throw new NotImplementedException();
        }

        public void Send(byte[] data)
        {
            _clientSocket.Send(data);
        }

        public void init()
        {
            _receiveEventArgs = new SocketAsyncEventArgs();
            _receiveEventArgs.SetBuffer(_buffer, 0, _buffer.Length);
            _receiveEventArgs.Completed += OnReceiveCompleted;
            _receiveEventArgs.UserToken = _clientSocket;

            if (!_clientSocket.ReceiveAsync(_receiveEventArgs))
            {
                OnReceiveCompleted(this, _receiveEventArgs);
            }
        }

        private void OnReceiveCompleted(object sender, SocketAsyncEventArgs e)
        {
            if (e.BytesTransferred > 0 && e.SocketError == SocketError.Success)
            {
                string message = Encoding.UTF8.GetString(e.Buffer, 0, e.BytesTransferred);

                if (!((Socket)e.UserToken).ReceiveAsync(e))
                {
                    OnReceiveCompleted(sender, e);
                }
            }
            else
            {
                Console.WriteLine("Disconnected from server.");
                _clientSocket.Close();
            }
        }
    }
}

