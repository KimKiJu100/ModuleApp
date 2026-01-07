using Modules.Packet;
using Modules.Packet.Base;
using Modules.Parsers;
using Modules.Parsers.MetaField;
using System;

namespace Modules._02.Parsers.Type
{
    /// <summary>
    /// 미구현
    /// </summary>
    public class MelSecFrameParser : IFrameParser<MelSecPacket>
    {
        private FrameSchema _schema;
        private FrameSchemaParser schemaParser;
        public MelSecFrameParser()
        {

        }

        public MelSecPacket Parse(byte[] frame)
        {
            schemaParser = new FrameSchemaParser(_schema);
            var model = new MelSecPacket();

            model = schemaParser.Parse<MelSecPacket>(frame);
            return model;
        }

        public PacketBase BaseParser(byte[] frame)
        {
            return Parse(frame);
        }

        public void SetSchema(FrameSchema schema)
        {
            _schema = schema;
        }
    }
}
