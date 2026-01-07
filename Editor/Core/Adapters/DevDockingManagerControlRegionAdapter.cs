using DevExpress.Xpf.Docking;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor.Core.Adapters
{
    public class DevDockingManagerControlRegionAdapter : RegionAdapterBase<DockLayoutManager>
    {
        public DevDockingManagerControlRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory) :
            base(regionBehaviorFactory)
        {
        }

        protected override void Adapt(IRegion region, DockLayoutManager regionTarget)
        {
            region.Views.CollectionChanged += (s, e) => {
                switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        //foreach (var view in e.NewItems)
                        //{
                        //    AddViewToRegion(view, regionTarget);
                        //}
                        break;
                    case NotifyCollectionChangedAction.Remove:
                        //foreach (var view in e.NewItems)
                        //{
                        //    RemoveViewFromRegion(view, regionTarget);
                        //}
                        break;
                }
            };
        }

        protected override IRegion CreateRegion()
        {
            return new SingleActiveRegion();
        }
    }
}
