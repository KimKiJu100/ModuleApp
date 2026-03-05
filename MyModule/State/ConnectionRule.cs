using App.CoreModules.Thread.interfaces;
using Modules.Communication.Context;
using Modules.Communication.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyModule.State
{
    public class ConnectionRule : IConditionRule
    {
        private readonly ComunicationContext _targetContext;

        public string RuleName => nameof(ConnectionRule);

        public ConnectionRule(ComunicationContext targetContext)
        {
            this._targetContext = targetContext;
        }

        public bool Check()
        {
            return this._targetContext.GetConnection();
        }
    }
}
