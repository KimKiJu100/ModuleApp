using Editor.Core;
using Prism.Commands;
using Prism.Regions;
using Prism.Services.Dialogs;

namespace Editor.ViewModels
{
    public  class DeviceTabViewModel : ViewModelBase
    {
        private readonly IRegionManager _regionManager;
        private readonly IDialogService _dialogService;
        private readonly IApplicationCommands _applicationCommands;

        public DelegateCommand SaveCommand { get; set; }
        public DelegateCommand EditorGridViewCommand { get; set; }

        public DeviceTabViewModel(IRegionManager regionManager, IApplicationCommands applicationCommands, IDialogService dialogService)
        {
            _regionManager = regionManager;
            _dialogService = dialogService;
            _applicationCommands = applicationCommands;

            SaveCommand = new DelegateCommand(Save);
            EditorGridViewCommand = new DelegateCommand(CreateCommandEditorView);
        }

        public DeviceTabViewModel()
        {
        }

        private void Save()
        {
            int i = 0;
        }

        private void CreateCommandEditorView()
        {
            int i = 0;
        }
    }
}
