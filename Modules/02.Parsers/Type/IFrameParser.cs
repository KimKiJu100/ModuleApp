using Modules.Packet.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules._02.Parsers.Type
{
    public interface IFrameParser<TPacket> : IFrameParserBase where TPacket : PacketBase
    {
        TPacket Parse(byte[] frame);
    }
}
