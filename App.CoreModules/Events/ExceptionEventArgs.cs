using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.CoreModules.Events
{
    public class ExceptionEventArgs : EventArgs
    {
        private Exception Exception { get; set; }
        public ExceptionEventArgs(Exception ex)
        {
            Exception = ex;
        }
    }
}
