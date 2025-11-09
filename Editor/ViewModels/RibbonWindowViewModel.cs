using Editor.Core;
using Prism.Commands;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor.ViewModels
{
    public class RibbonWindowViewModel : ViewModelBase
    {
        private readonly IRegionManager _regionManager;
        private readonly IDialogService _dialogService;
        private readonly IApplicationCommands _applicationCommands;

        //private DelegateCommand _openWizardCommand;
        public DelegateCommand OpenWizardCommand { get; set; }
        public RibbonWindowViewModel(IRegionManager regionManager, IApplicationCommands applicationCommands, IDialogService dialogService)
        {
            _regionManager = regionManager;
            _dialogService = dialogService;
            _applicationCommands = applicationCommands;
            OpenWizardCommand = new DelegateCommand(DialogWizardOpen);
        }

        private void DialogWizardOpen()
        {
            var param = new DialogParameters { { "SomeParam", 123 } };
            _dialogService.ShowDialog("MainWizardView", null, DialogResultCallback);
        }

        private void DialogResultCallback(IDialogResult result)
        {
            if (result.Result == ButtonResult.OK)
            {
                // OK 눌렀을 때 처리
            }
        }
    }
}
