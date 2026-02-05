using Modules.Communication.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyModule.Event
{
    public class ComunicationParamOKEventArgs : EventArgs
    {
        public CommParamBase Params { get; set; }

        public ComunicationParamOKEventArgs(CommParamBase @params)
        {
            Params = @params;
        }
    }
}
