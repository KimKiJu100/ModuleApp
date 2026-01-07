using DeviceWizard.Models;
using DeviceWizard.Views;
using Editor.Core;
using Editor.Service.Interfaces;
using Prism.Commands;
using Prism.Ioc;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceWizard.ViewModels
{
   public class MainWizardViewModel : ViewModelBase, IDialogAware
    {
        private readonly IDeviceWizardService _deviceWizardService;

        public event Action<IDialogResult> RequestClose;

        public DelegateCommand NextCommand { get; }
        public DelegateCommand PrevCommand { get; }

        public string Title => "Device Wizard";

        public ObservableCollection<WizardStep> Steps { get; } = new();

        private WizardStep _currentStep;
        public WizardStep CurrentStep
        {
            get => _currentStep;
            set => SetProperty(ref _currentStep, value);
        }

        public MainWizardViewModel(IDeviceWizardService deviceWizardService/*, IContainerProvider containerProvider*/)
        {
            _deviceWizardService = deviceWizardService;

            NextCommand = new DelegateCommand(() => _deviceWizardService.NextStep());
            PrevCommand = new DelegateCommand(() => _deviceWizardService.PreviousStep());

            //var step1 = containerProvider.Resolve<Step1View>();
            //var step2 = containerProvider.Resolve<Step2View>();

            //Steps.Add(new WizardStep { Name = "Step 1", Content = step1 });
            //Steps.Add(new WizardStep { Name = "Step 2", Content = step2 });

            CurrentStep = Steps.First();
        }

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            RequestClose?.Invoke(new DialogResult(ButtonResult.OK));
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
           
        }
    }
}
