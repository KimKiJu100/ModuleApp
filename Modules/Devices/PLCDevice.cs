using Modules.Communication.Context;
using Modules.Parsers.Context;
using Modules.Protocol.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Devices
{
    public class PLCDevice : DeviceBase
    {
        /// <summary>
        /// 일반 생성자 형식
        /// </summary>
        public PLCDevice() : base()
        {
        }
        /// <summary>
        /// DI 주입 형식
        /// </summary>
        /// <param name="comContext"></param>
        /// <param name="parserContext"></param>
        /// <param name="protocolContext"></param>
        public PLCDevice(ComunicationContext comContext, ParserContext parserContext, ProtocolContext protocolContext) : base(comContext, parserContext, protocolContext)
        {
        }
    }
}
