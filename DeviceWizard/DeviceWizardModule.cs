using DeviceWizard.ViewModels;
using DeviceWizard.Views;
using Editor.Service;
using Editor.Service.Interfaces;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace DeviceWizard
{
    public class DeviceWizardModule : IModule
    {
        private readonly IRegionManager _regionManager;
        public DeviceWizardModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }
        public void OnInitialized(IContainerProvider containerProvider)
        {
            //
            //this._regionManager.RegisterViewWithRegion(RegionNames.OutlookGroupRegion, typeof(MailGroup));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IDeviceWizardService,DeviceWizardService>();
            containerRegistry.RegisterDialog<MainWizardView, MainWizardViewModel>();
            containerRegistry.Register<Step1View>();
        }
    }
}
