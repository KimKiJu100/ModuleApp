using App.CoreModules.Thread.interfaces;
using Modules.Communication.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyModule.Actions
{
    public class RetryConnection : IConditionAction
    {
        private ComunicationContext _comunication;
        public RetryConnection(ComunicationContext comunication)
        {
            _comunication = comunication;
        }

        public void OnAction()
        {
            _comunication.Connection();
        }
    }
}
