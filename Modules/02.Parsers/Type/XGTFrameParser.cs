using Modules._02.Parsers.Type;
using Modules.Packet;
using Modules.Packet.Base;
using Modules.Parsers.MetaField;

namespace Modules.Parsers
{
    public class XGTFrameParser : IFrameParser<XGTPacket>
    {
        private FrameSchema _schema;
        private FrameSchemaParser schemaParser;
        public XGTFrameParser()
        {

        }

        public void SetSchema(FrameSchema schema)
        {
            _schema = schema;
        }
        public XGTPacket Parse(byte[] frame)
        {
            schemaParser = new FrameSchemaParser(_schema);
            var model = new XGTPacket();
            
            model = schemaParser.Parse<XGTPacket>(frame);
            return model;
        }

        public PacketBase BaseParser(byte[] frame) {
            return Parse(frame);
        }
    }
}
