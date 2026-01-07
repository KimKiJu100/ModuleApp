using Modules.Communication.Context;
using Modules.Parsers.Context;
using Modules.Protocol.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules
{
    public abstract class DeviceBase
    {
        protected ComunicationContext _comContext;
        protected ParserContext _parserContext;
        protected ProtocolContext _protocolContext;

        public DeviceBase()
        {
            _comContext = new ComunicationContext();
            _parserContext = new ParserContext();
            _protocolContext = new ProtocolContext();
        }
        public DeviceBase(ComunicationContext comContext, ParserContext parserContext, ProtocolContext protocolContext)
        {
            _comContext = comContext;
            _parserContext = parserContext;
            _protocolContext = protocolContext;
        }
    }
}
