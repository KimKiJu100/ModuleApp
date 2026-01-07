using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Parsers.MetaField
{
    public class FrameFieldInfo
    {
        public string Name { get; set; }
        public int Offset { get; set; }
        public int Length { get; set; }
        public string Unit { get; set; }
        public string Desc { get; set; }
    }
}
