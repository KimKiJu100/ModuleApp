using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Parsers.MetaField
{
    public class FrameSchema
    {
        public string ModelName { get; set; }
        public List<FrameFieldInfo> Fields { get; set; } = new List<FrameFieldInfo>();
    }
}
