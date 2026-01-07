using Editor.Helper;
using Modules.Attributes;
using Prism.Ioc;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor.Core
{
    public class DependentViewRegionBehavior : RegionBehavior
    {
        public const string BehaviorKey = "DependentViewRegionehavior";
        private readonly IContainerExtension _container;

        Dictionary<object, List<DependentViewInfo>> _dependentViewCache = new Dictionary<object, List<DependentViewInfo>>();

        public DependentViewRegionBehavior(IContainerExtension container)
        {
            _container = container;
        }

        protected override void OnAttach()
        {
            Region.ActiveViews.CollectionChanged += ActiveViews_CollectionChanged;
        }

        private void ActiveViews_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (var newView in e.NewItems)
                {
                    var dependentViews = new List<DependentViewInfo>();

                    if (_dependentViewCache.ContainsKey(newView))
                    {
                        dependentViews = _dependentViewCache[newView];
                    }
                    else
                    {
                        var atts = AttributesHelper.GetCustomAttributes<DependentViewAttribute>(newView.GetType());
                        foreach (var att in atts)
                        {
                            var info = CreateDependentViewInfo(att);
                            if (info.View is ISupportDataContext infoDC && newView is ISupportDataContext viewDC)
                            {
                                infoDC.DataContext = viewDC.DataContext;
                            }

                            dependentViews.Add(info);
                        }
                        _dependentViewCache.Add(newView, dependentViews);
                    }
                    dependentViews.ForEach(item => Region.RegionManager.Regions[item.Region].Add(item.View));
                }
            }
        }

        private DependentViewInfo CreateDependentViewInfo(DependentViewAttribute attribute)
        {
            var info = new DependentViewInfo();
            info.Region = attribute.Region;
            info.View = _container.Resolve(attribute.Type);
            return info;
        }
    }
}
