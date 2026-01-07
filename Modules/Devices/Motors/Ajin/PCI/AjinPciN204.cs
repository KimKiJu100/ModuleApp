using Modules.Devices.Motors.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Devices.Motors.Ajin.PCI
{
    public class AjinPciN204 : IMotionControl
    {
        public string keyName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public AjinPciN204()
        {
            
        }

        public MotionState GetState()
        {
            throw new NotImplementedException();
        }
    }
}
