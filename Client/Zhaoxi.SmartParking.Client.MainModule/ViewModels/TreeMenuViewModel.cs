using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zhaoxi.SmartParking.Client.Entity;
using Zhaoxi.SmartParking.Client.MainModule.Models;

namespace Zhaoxi.SmartParking.Client.MainModule.ViewModels
{
    public class TreeMenuViewModel : BindableBase
    {
        public List<MenuItemModel> Menus { get; set; } = new List<MenuItemModel>();

        private List<MenuEntity> origMenus = null;

        private IRegionManager _regionManager = null;

        public TreeMenuViewModel(IContainerProvider containerProvider, IRegionManager regionManager)
        {
            _regionManager = regionManager;
            //var global = containerProvider.Resolve<GlobalEntity>();// 注册一个单例
            if (GlobalEntity.CurrentUserInfo != null)
            {
                origMenus = GlobalEntity.CurrentUserInfo.Menus;
                this.FillMenus(Menus, 0);
            }
        }

        ///递归
        ///
        private void FillMenus(List<MenuItemModel> menus, int parentId)
        {
            var sub = origMenus.Where(m => m.ParentId == parentId).OrderBy(o => o.Index);

            if (sub.Count() > 0)
            {
                foreach (var item in sub)
                {
                    MenuItemModel mm = new MenuItemModel(_regionManager)
                    {
                        MenuHeader = item.MenuHeader,
                        MenuIcon = item.MenuIcon,
                        TargetView = item.TargetView
                    };
                    menus.Add(mm);

                    FillMenus(mm.Children = new List<MenuItemModel>(), item.MenuId);
                }
            }
        }
    }
}
