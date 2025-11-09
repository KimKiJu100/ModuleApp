using Modules._02.Parsers.Type;
using Modules.Parsers.Base;
using Modules.Parsers.FrameSchemas;
using Modules.Parsers.Params;

namespace Modules.Parsers.Factory
{
    public class FrameParserFacotry
    {

        public FrameParserFacotry()
        {

        }

        public IFrameParserBase CreateFrameParser(ParserParamBase baseParam)
        {
            if (baseParam is XGTParserParam)
                return new XGTFrameParser();
            else
                return new XGTFrameParser();
        }

        public XGTFrameSchema CreateFrameSchema(ParserParamBase baseParam)
        {
            //스키마 정보 전달
            return new XGTFrameSchema();
        }
    }
}
