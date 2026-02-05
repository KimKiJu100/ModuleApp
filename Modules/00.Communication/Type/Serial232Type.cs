using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Communication.Type
{
    public class Serial232Type : TypeBase
    {
        private SerialPort _instance;
        public SerialPort Instance { get => _instance; }
        public override bool IsConnection { get => _instance.IsOpen; }
        public Serial232Type()
        {
            _instance = new SerialPort();
        }

        protected override void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 관리형 상태(관리형 개체)를 삭제합니다.
                    _instance.Close();
                    _instance.Dispose();
                    _instance = null;
                }

                // TODO: 비관리형 리소스(비관리형 개체)를 해제하고 종료자를 재정의합니다.
                // TODO: 큰 필드를 null로 설정합니다.
                disposedValue = true;
            }
        }
    }
}
