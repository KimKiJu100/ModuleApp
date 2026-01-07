using DevExpress.Xpf.Docking;
using DevExpress.Xpf.Ribbon;
using DeviceWizard;
using Editor.Core;
using Editor.Core.Adapters;
using Editor.PageGroup;
using Editor.ViewModels;
using Editor.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using System.Windows;

namespace Editor
{
    /// <summary>
    /// App.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<RibbonWindow>();
        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IApplicationCommands, ApplicationCommands>();
            containerRegistry.RegisterSingleton<DeviceTabViewModel>();

            containerRegistry.RegisterForNavigation<DeviceTab, DeviceTabViewModel>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<DeviceWizardModule>();
        }

        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();
            //ViewModelLocationProvider.Register<DeviceTab, DeviceTabViewModel>();

            ViewModelLocationProvider.SetDefaultViewModelFactory((view, vmType) =>
            {
                if (view is DeviceTab)
                    return Container.Resolve<DeviceTabViewModel>();

                return Container.Resolve(vmType);
            });
        }

        protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
        {
            base.ConfigureRegionAdapterMappings(regionAdapterMappings);
            regionAdapterMappings.RegisterMapping(typeof(RibbonControl), Container.Resolve<DevRibbonControlRegionAdapter>());
            regionAdapterMappings.RegisterMapping(typeof(DockLayoutManager), Container.Resolve<DevDockingManagerControlRegionAdapter>());
        }

        protected override void ConfigureDefaultRegionBehaviors(IRegionBehaviorFactory regionBehaviors)
        {
            base.ConfigureDefaultRegionBehaviors(regionBehaviors);

            regionBehaviors.AddIfMissing(DependentViewRegionBehavior.BehaviorKey, typeof(DependentViewRegionBehavior));
        }
    }
}
