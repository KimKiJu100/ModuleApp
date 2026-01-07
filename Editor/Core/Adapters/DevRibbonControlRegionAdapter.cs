using DevExpress.Xpf.Ribbon;
using DevExpress.Xpf.Ribbon.Internal;
using Editor.PageGroup;
using Editor.ViewModels;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using System.Collections.Specialized;
using System.Threading.Tasks;
using System.Windows;

namespace Editor.Core
{
    /// <summary>
    /// DevExrpess 컨트롤을 prism의 레전에 인식시키기 위해 Adapter 클래스로 커스텀 마이징을 진행 해야된다.
    /// </summary>
    public class DevRibbonControlRegionAdapter : RegionAdapterBase<RibbonControl>
    {
        public DevRibbonControlRegionAdapter(IRegionBehaviorFactory regionBehaviorfactory) :
            base(regionBehaviorfactory)
        {
        }
        /// <summary>
        /// region 등록 행위
        /// </summary>
        /// <param name="region"></param>
        /// <param name="regionTarget"></param>
        protected override void Adapt(IRegion region, RibbonControl regionTarget)
        {
            region.Views.CollectionChanged += (s,e) =>{
                switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        foreach (var view in e.NewItems)
                        {
                            AddViewToRegion(view, regionTarget);
                        }
                    break;
                    case NotifyCollectionChangedAction.Remove:
                        foreach (var view in e.NewItems)
                        {
                            RemoveViewFromRegion(view, regionTarget);
                        }
                        break;
                }
            };
        }

        protected override IRegion CreateRegion()
        {
            return new SingleActiveRegion();
        }

        private void AddViewToRegion(object view, RibbonControl devRibbon)
        {
            var ribbonTabItem = view as IRibbonItem;
            if (ribbonTabItem != null)
            {
                devRibbon.Items.Add(ribbonTabItem);
            }
        }

        private void RemoveViewFromRegion(object view, RibbonControl devRibbon)
        {
            var ribbonTabItem = view as IRibbonItem;
            if (ribbonTabItem != null)
                devRibbon.Items.Remove(ribbonTabItem);
        }
    }
}
