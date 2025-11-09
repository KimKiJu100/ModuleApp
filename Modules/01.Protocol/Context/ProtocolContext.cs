using Modules.Protocol.Base;
using Modules.Protocol.Facotrys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Protocol.Context
{
    public class ProtocolContext
    {
        private ProtocolParamBase _param;
        private PacketBase _packet;

        private readonly ProtocolFactory _fac;
        public ProtocolContext()
        {
            _fac = new ProtocolFactory();
        }

        public void Configure(ProtocolParamBase param)
        {
            _param = param;
            _packet = _fac.CreateProtocolPacket(param);
        }

        public byte[] GetByteFullFrame()
        {
            return _packet.BuildPacket(_param);
        }
    }
}
