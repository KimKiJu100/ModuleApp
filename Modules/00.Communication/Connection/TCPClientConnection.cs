using Modules.Communication.Connection.Base;
using Modules.Communication.Intefaces;
using Modules.Communication.Params;
using Modules.Communication.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Modules.Communication.Connection
{
    public class TCPClientConnection : ConnectionBase
    {
        private Socket _soc;
        private readonly object _lock = new object();

        public TCPClientConnection()
        {
        }

        public override void SetInstance(TypeBase Type)
        {
            if (Type is TCPClientSocketType type)
                _soc = type.Instance;
            else
                throw new NotImplementedException("Error - 타입 변환이 정상적이지 않습니다. 확인하세요.");
        }

        public override bool Connection(CommParamBase paramBase)
        {
            lock (_lock)
            {
                if (paramBase is SocketParams parma)
                {
                    try
                    {
                        if (_soc.Connected) return false;
                        _soc.Connect(IPAddress.Parse(parma.IpAddress), parma.Port);
                        IsConnected = _soc.Connected;
                        return IsConnected;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"연결시 문제가 있습니다.{ex.Message}");
                    }
                }
                else
                    throw new NotImplementedException("Error Type - 타입 변환이 정상적이지 않습니다. 확인하세요.");
            }
        }

        public override bool DisConnection()
        {
            lock(_lock)
            {
                if (!_soc.Connected) return true;
                _soc.Disconnect(true);
                return true;
            }
        }
    }
}
