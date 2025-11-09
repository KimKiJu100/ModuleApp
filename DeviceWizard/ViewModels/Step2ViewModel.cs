using Editor.Core;
using Editor.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceWizard.ViewModels
{
    public class Step2ViewModel : ViewModelBase
    {
        private readonly IDeviceWizardService _deviceWizardService;

        public Step2ViewModel(IDeviceWizardService deviceWizardService)
        {
            _deviceWizardService = deviceWizardService;
        }
    }
}
