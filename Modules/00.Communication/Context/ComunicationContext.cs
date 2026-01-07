using Modules.Communication.Factory;
using Modules.Communication.Intefaces;
using Modules.Communication.Params;
using Modules.Communication.Type;
using System;

namespace Modules.Communication.Context
{
    public class ComunicationContext
    {
        private TypeBase _instance;
        private ICommunicationConnection _connection;
        private ICommunicationSender _sender;
        private ICommunicationReceiver _receiver;

        private CommunicationFactory _factory;

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
            return _connection.DisConnection();
        }
        public void Sender(byte[] data)
        {
            _sender.Send(data);
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
    }
}
