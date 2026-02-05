using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.CoreModules
{
    public interface IConditionRule
    {
        string RuleName { get; }
        bool Check();   
    }
}
