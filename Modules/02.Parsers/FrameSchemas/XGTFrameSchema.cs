using Modules.Parsers.MetaField;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Parsers.FrameSchemas
{
    //Word 기준 1개 의 기준으로 작성되었다.
    public class XGTFrameSchema
    {
        private readonly FrameSchema _schema;
        public FrameSchema Schema => _schema;
        public XGTFrameSchema()
        {
            _schema = new FrameSchema();
            _schema.ModelName = "XGTFrame";
            _schema.Fields.Add(new FrameFieldInfo { Name = "CompanyID", Offset = 0, Length = 10, Unit = "Direct" });
            _schema.Fields.Add(new FrameFieldInfo { Name = "PLCInfo", Offset = 10, Length = 2, Unit = "Direct" });
            _schema.Fields.Add(new FrameFieldInfo { Name = "CPUInfo", Offset = 12, Length = 1, Unit = "Direct" });
            _schema.Fields.Add(new FrameFieldInfo { Name = "SourceOfFrame", Offset = 13, Length = 1, Unit = "Direct" });
            _schema.Fields.Add(new FrameFieldInfo { Name = "InvokeID", Offset = 14, Length = 2, Unit = "Direct" });
            _schema.Fields.Add(new FrameFieldInfo { Name = "length", Offset = 16, Length = 2, Unit = "Direct" });
            _schema.Fields.Add(new FrameFieldInfo { Name = "EthernetPosition", Offset = 18, Length = 1, Unit = "Direct" });
            _schema.Fields.Add(new FrameFieldInfo { Name = "Reverse2", Offset = 19, Length = 1, Unit = "Direct" });

            _schema.Fields.Add(new FrameFieldInfo { Name = "CommandType", Offset = 20, Length = 2, Unit = "Direct" });
            _schema.Fields.Add(new FrameFieldInfo { Name = "DataType", Offset = 22, Length = 2, Unit = "Direct" });

            _schema.Fields.Add(new FrameFieldInfo { Name = "Reverse1", Offset = 24, Length = 2, Unit = "Direct" });
            _schema.Fields.Add(new FrameFieldInfo { Name = "ErrorState", Offset = 26, Length = 2, Unit = "Direct" });
            _schema.Fields.Add(new FrameFieldInfo { Name = "BlockCount", Offset = 28, Length = 2, Unit = "Direct" });

            _schema.Fields.Add(new FrameFieldInfo { Name = "DataSize", Offset = 30, Length = 2, Unit = "Direct" });
            _schema.Fields.Add(new FrameFieldInfo { Name = "Data", Offset = 32, Length = 2, Unit = "Direct" });
        }
    }
}
