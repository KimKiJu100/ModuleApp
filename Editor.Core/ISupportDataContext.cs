using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor.Core
{
    public interface ISupportDataContext
    {
        object DataContext { get; set; }
    }
}
