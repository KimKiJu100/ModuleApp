using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyModule.CommunicationUI
{
    public class ComboBoxItem<TTypeCode>
    {
        public string Name { get; set; } = string.Empty;
        public TTypeCode TypeCode { get; set; }
    }
}
