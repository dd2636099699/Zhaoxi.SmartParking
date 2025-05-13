using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;
using Unity;
using Zhaoxi.SmartParking.Client.Common;
using Zhaoxi.SmartParking.Client.Entity;
using Zhaoxi.SmartParking.Client.IBLL;
using Zhaoxi.SmartParking.Client.Models;

namespace Zhaoxi.SmartParking.Client.SysModule.ViewModels
{
    public class MenuManagementViewModel : PageViewModelBase
    {
        public ObservableCollection<MenuItemModel> MenuTree { get; set; } = new ObservableCollection<MenuItemModel>();
        private List<MenuEntity> origMenus = null;
        private MenuItemModel currentMenu;

        // ListView   SelectedItem

        public ICommand ItemSelectedCommand { get; set; }

        IUnityContainer _unityContainer;
        IDialogService _dialogService;
        IMenuBLL _menuBLL;
        public MenuManagementViewModel(
            IRegionManager regionManager,
            IUnityContainer unityContainer,
            IEventAggregator ea,
            IDialogService dialogService,
            IMenuBLL menuBLL)
            : base(regionManager, unityContainer, ea)
        {
            _unityContainer = unityContainer;
            _dialogService = dialogService;
            _menuBLL = menuBLL;

            this.PageTitle = "系统菜单管理";

            ItemSelectedCommand = new DelegateCommand<object>(o => { currentMenu = o as MenuItemModel; });

        }

        public override void Refresh()
        {
            // 初始化当前用户权限下的所有菜单数据
            //var global = _unityContainer.Resolve<GlobalEntity>();
            //if (global != null && global.CurrentUserInfo != null)
            this.ShowLoading();
            MenuTree.Clear();
            Task.Run(async () =>
            {
                origMenus = await _menuBLL.GetAllMenus();
                GlobalEntity.CurrentUserInfo.Menus = origMenus;

                MenuItemModel root = new MenuItemModel
                {
                    MenuId = 0,
                    MenuHeader = "根节点",
                    HasChild = true,
                    IsExpanded = true,
                    IsCurrent = true,
                    MenuType = 1
                };
                currentMenu = root;

                _unityContainer.Resolve<Dispatcher>().Invoke(() =>
                {
                    MenuTree.Add(root);
                    FillMenus(origMenus, root.Children, 0);
                });

                this.HideLoading();
            });
        }

        private void FillMenus(IList<MenuEntity> origMenus, IList<MenuItemModel> menus, int nodeId, int nodeType = 0)
        {
            var sub = origMenus.Where(m => m.ParentId == nodeId && m.MenuType >= nodeType).OrderBy(o => o.Index);

            if (sub.Count() > 0)
            {
                foreach (var item in sub)
                {
                    MenuItemModel mm = new MenuItemModel()
                    {
                        MenuId = item.MenuId,
                        MenuHeader = item.MenuHeader,
                        MenuIcon = item.MenuIcon,
                        TargetView = item.TargetView,
                        IsExpanded = true,
                        MenuType = item.MenuType,
                        ParentId = item.ParentId,
                        Index = item.Index
                    };
                    mm.EditCommand = new DelegateCommand<object>(EditMenuNode);
                    mm.DeleteCommand = new DelegateCommand<object>(DeleteMenuNode);

                    FillMenus(origMenus, mm.Children, item.MenuId, nodeType);
                    mm.HasChild = mm.Children.Count > 0;
                    menus.Add(mm);
                }
            }
        }

        public override void AddItem()
        {
            // 添加菜单项
            if (currentMenu.MenuType == 1)
            {
                DialogParameters param = new DialogParameters();
                param.Add("type", 0);
                param.Add("menu", currentMenu);

                ShowEditDialog(param);
            }
        }

        private void EditMenuNode(object obj)
        {
            DialogParameters param = new DialogParameters();
            param.Add("type", 1);
            param.Add("menu", obj as MenuItemModel);

            ShowEditDialog(param);
        }

        private void ShowEditDialog(DialogParameters param)
        {
            _dialogService.ShowDialog(
                "AddMenuDialog",
                param,
                new Action<IDialogResult>(result =>
                {
                    if (result != null && result.Result == ButtonResult.OK)
                    {
                        System.Windows.MessageBox.Show("数据已保存", "提示");
                        this.Refresh();
                    }
                }));
        }

        private async void DeleteMenuNode(object obj)
        {
            // 只要是做数据清理的时候   都做确认操作
            if (System.Windows.MessageBox.Show("是否确定删除此菜单项？", "提示", System.Windows.MessageBoxButton.YesNo, System.Windows.MessageBoxImage.Question) == System.Windows.MessageBoxResult.Yes)
            {
                await _menuBLL.DeleteMenu((obj as MenuItemModel).MenuId);

                this.Refresh();
            }
        }
    }
}
