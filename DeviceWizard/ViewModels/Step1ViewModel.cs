using Editor.Core;
using Editor.Service.Interfaces;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceWizard.ViewModels
{
    public class Step1ViewModel : ViewModelBase
    {
        private readonly IDeviceWizardService _deviceWizardService;

        public Step1ViewModel(IDeviceWizardService deviceWizardService)
        {
            _deviceWizardService = deviceWizardService;
        }
    }
}
