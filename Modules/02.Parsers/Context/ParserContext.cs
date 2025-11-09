using Modules._02.Parsers.Type;
using Modules.Packet.Base;
using Modules.Parsers.Base;
using Modules.Parsers.Factory;
using Modules.Parsers.FrameSchemas;

namespace Modules.Parsers.Context
{
    public class ParserContext
    {
        private readonly FrameParserFacotry _fac;
        private IFrameParserBase _paser;
        private XGTFrameSchema _schema;

        private ParserParamBase _param;
        public ParserContext()
        {
            _fac = new FrameParserFacotry();    
        }

        public void Configure(ParserParamBase param)
        {
            _param = param;
            _paser = _fac.CreateFrameParser(_param);
            _schema = _fac.CreateFrameSchema(_param);
            _paser.SetSchema(_schema.Schema);
        }

        public PacketBase CreatePack(byte[] fullFrame)
        {
            return _paser.BaseParser(fullFrame);
        }
    }
}
