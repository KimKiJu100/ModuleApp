using Modules.Communication.Connection.Strategies;
using Modules.Communication.Intefaces;
using Modules.Communication.Params;
using Modules.Communication.Receiver.Strategies;
using Modules.Communication.Sender.Strategies;
using Modules.Communication.Type;
using Modules.Communication.Type.Strategies;
using Modules.Helper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Modules.Communication.Factory
{
    public class CommunicationFactory
    {
        private readonly List<ICommunicationTypeStrategy> _typeStrategyCollection;
        private readonly List<ICommunicationSenderStrategy> _senderStrategyCollection;
        private readonly List<ICommunicationReceiverStrategy> _receiveStrategyCollection;
        private readonly List<ICommunicationConnectionStrategy> _connectionStrategyCollection;

        public CommunicationFactory()
        {
            _typeStrategyCollection = CollectionHelper.LoadStrategies<ICommunicationTypeStrategy>();
            _senderStrategyCollection = CollectionHelper.LoadStrategies<ICommunicationSenderStrategy>();
            _receiveStrategyCollection = CollectionHelper.LoadStrategies<ICommunicationReceiverStrategy>();
            _connectionStrategyCollection = CollectionHelper.LoadStrategies<ICommunicationConnectionStrategy>();
        }

        public TypeBase CreateCommunicationInstance(CommParamBase param)
        {
            var strategy = _typeStrategyCollection.FirstOrDefault(s => s.CanHandle(param));
            if (strategy != null)
                return strategy.Create();

            throw new ArgumentException("지원하지 않는 통신 파라미터입니다.");
        }
        public ICommunicationConnection CreateConnection(CommParamBase param)
        {
            var strategy = _connectionStrategyCollection.FirstOrDefault(s => s.CanHandle(param));
            if (strategy != null)
                return strategy.Create();

            throw new ArgumentException("지원하지 않는 통신 파라미터입니다.");
        }

        public ICommunicationSender CreateSender(CommParamBase param)
        {
            var strategy = _senderStrategyCollection.FirstOrDefault(s => s.CanHandle(param));
            if (strategy != null)
                return strategy.Create();

            throw new ArgumentException("지원하지 않는 통신 파라미터입니다.");
        }

        public ICommunicationReceiver CreateReceiver(CommParamBase param)
        {
            var strategy = _receiveStrategyCollection.FirstOrDefault(s => s.CanHandle(param));
            if (strategy != null)
                return strategy.Create();

            throw new ArgumentException("지원하지 않는 통신 파라미터입니다.");
        }
    }
}
