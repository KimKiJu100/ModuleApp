using Modules._00.Communication.State;
using Modules.Communication.Factory;
using Modules.Communication.Intefaces;
using Modules.Communication.Params;
using Modules.Communication.Type;
using System;

namespace Modules.Communication.Context
{
    public class ComunicationContext:IDisposable
    {
        private TypeBase _instance;
        private ICommunicationConnection _connection;
        private ICommunicationSender _sender;
        private ICommunicationReceiver _receiver;
        private IComunicationState _state;

        private CommunicationFactory _factory;
        private bool disposedValue;

        /// <summary>
        /// 현재 세팅 정보를 보기위해...
        /// </summary>
        public CommParamBase CommParam { get; set; }
        public bool IsConnection { get => _instance.IsConnection; }

        public ComunicationContext(){
            _factory = new CommunicationFactory();
        }
        private void SetInjectionInstance()
        {
            _connection.SetInstance(_instance);
            _sender.SetInstance(_instance);
            _receiver.SetInstance(_instance);
            _state.SetInstance(_instance);
        }
        private void _receiver_OnPacketReceived(object sender, string e)
        {
            //해당 데이터를 받아오는곳
            //throw new NotImplementedException();
        }

        public void Configure(CommParamBase param)
        {
            CommParam = param;
            _instance = _factory.CreateCommunicationInstance(param);
            _connection = _factory.CreateConnection(param);
            _sender = _factory.CreateSender(param);
            _receiver = _factory.CreateReceiver(param);
            _state = _factory.CreateState(param);

            SetInjectionInstance();
        }
        public bool Connection()
        {
            bool bState = _connection.Connection(CommParam);
            
            if (bState)
            {
                _receiver.ReceiveSet();
                _receiver.OnPacketStringReceived += _receiver_OnPacketReceived;
            }

            return bState;
        }
        public bool DisConnection()
        {
            bool bState = _connection.DisConnection();
            if (bState)
            {
                _receiver.ReceiveRemoveSet();
                _receiver.OnPacketStringReceived -= _receiver_OnPacketReceived;
            }
            return bState;
        }
        public void Sender(byte[] data)
        {
            _sender.Send(data);
        }
        public void Sender(string data)
        {
            _sender.Send(data);
        }

        public bool GetConnection()
        {
            return _state.GetConnectionState();
        }

        public void AddReceivedEvent(EventHandler<string> handler)
        {
            _receiver.OnPacketStringReceived += handler;
        }
        public void RemoveReceivedEvent(EventHandler<string> handler)
        {
            _receiver.OnPacketStringReceived -= handler;
        }

        public void AddReceivedEvent(EventHandler<byte[]> handler)
        {
            _receiver.OnPacketByteReceived += handler;
        }
        public void RemoveReceivedEvent(EventHandler<byte[]> handler)
        {
            _receiver.OnPacketByteReceived -= handler;
        }

        protected void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 관리형 상태(관리형 개체)를 삭제합니다.
                    _instance?.Dispose();
                    _connection?.Dispose();
                    _sender?.Dispose();
                    _receiver?.Dispose();
                    _state?.Dispose();
                }

                // TODO: 비관리형 리소스(비관리형 개체)를 해제하고 종료자를 재정의합니다.
                // TODO: 큰 필드를 null로 설정합니다.
                disposedValue = true;
            }
        }

        // // TODO: 비관리형 리소스를 해제하는 코드가 'Dispose(bool disposing)'에 포함된 경우에만 종료자를 재정의합니다.
        // ~ComunicationContext()
        // {
        //     // 이 코드를 변경하지 마세요. 'Dispose(bool disposing)' 메서드에 정리 코드를 입력합니다.
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // 이 코드를 변경하지 마세요. 'Dispose(bool disposing)' 메서드에 정리 코드를 입력합니다.
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
