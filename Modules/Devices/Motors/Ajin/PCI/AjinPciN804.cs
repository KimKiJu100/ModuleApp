using Modules.Devices.Motors.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Devices.Motors.Ajin.PCI
{
    /// <summary>
    /// 
    /// </summary>
    public class AjinPciN804 : IMotionControl
    {
        public string keyName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public AjinPciN804()
        {

        }

        public MotionState GetState()
        {
            throw new NotImplementedException();
        }
    }
}
