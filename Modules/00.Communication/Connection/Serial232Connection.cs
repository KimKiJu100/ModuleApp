using Modules.Communication.Connection.Base;
using Modules.Communication.Params;
using Modules.Communication.Type;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Communication.Connection
{
    public class Serial232Connection : ConnectionBase
    {
        private SerialPort _port;
        public override void SetInstance(TypeBase Type)
        {
            if (Type is Serial232Type type)
                _port = type.Instance;
            else
                throw new NotImplementedException("Error - 타입 변환이 정상적이지 않습니다. 확인하세요.");
        }

        public override bool Connection(CommParamBase paramBase)
        {
            lock (_lock)
            {
                if (paramBase is SerialParams @params)
                {
                    try
                    {
                        if (_port.IsOpen) return false;

                        _port.PortName = @params.PortName;
                        _port.BaudRate = @params.baudRate;
                        _port.Parity = @params.Parity;
                        _port.DataBits = @params.DataBits;
                        _port.StopBits = @params.StopBits;

                        _port.Open();
                        IsConnected = _port.IsOpen;
                        return IsConnected;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"연결시 문제가 있습니다.{ex.Message}\r\n");
                    }
                }
                else
                    throw new NotImplementedException("Error Type - 타입 변환이 정상적이지 않습니다. 확인하세요.");
            }
        }

        public override bool DisConnection()
        {
            lock (_lock)
            {
                if (!_port.IsOpen) return true;
                _port.Close();
                return true;
            }
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
