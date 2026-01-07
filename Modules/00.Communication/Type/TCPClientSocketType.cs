using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Communication.Type
{
    public class TCPClientSocketType : TypeBase
    {
        private Socket _instance;

        public Socket Instance { get => _instance; }

        public override bool IsConnection { get => Instance.Connected; }

        public TCPClientSocketType()
        {
            _instance = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }
    }
}
