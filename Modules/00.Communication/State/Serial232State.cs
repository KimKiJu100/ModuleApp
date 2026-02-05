using Modules._00.Communication.State.Base;
using Modules.Communication.Type;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules._00.Communication.State
{
    public class Serial232State : CommunicationStateBase
    {
        private SerialPort _port = null;
        public override void SetInstance(TypeBase Type)
        {
            if (Type is Serial232Type type)
                _port = type.Instance;
            else
                throw new Exception("Error - 타입 변환이 정상적이지 않습니다. 확인하세요.");
        }

        public override bool GetConnectionState()
        {
            return _port.IsOpen;
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
