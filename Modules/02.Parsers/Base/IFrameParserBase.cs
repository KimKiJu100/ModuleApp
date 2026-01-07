using Modules.Packet.Base;
using Modules.Parsers.MetaField;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules._02.Parsers.Type
{
    public interface IFrameParserBase
    {
        PacketBase BaseParser(byte[] frame);
        void SetSchema(FrameSchema schema);
    }
}
