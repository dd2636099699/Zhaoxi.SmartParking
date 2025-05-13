using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Zhaoxi.SmartParking.Client.Common;
using Zhaoxi.SmartParking.Client.Entity;
using Zhaoxi.SmartParking.Client.IBLL;
using Zhaoxi.SmartParking.Client.Models;

namespace Zhaoxi.SmartParking.Client.SysModule.ViewModels
{
    public class AddMenuDialogViewModel : BindableBase, IDialogAware
    {
        string _title = "系统菜单";
        public string Title => _title;

        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {

        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            int _type = 0;
            if (parameters.ContainsKey("type"))
            {
                _type = parameters.GetValue<int>("type");

                _title = (_type == 0 ? "新增" : "修改") + _title;
            }
            if (parameters.ContainsKey("menu"))
            {
                var menu = parameters.GetValue<MenuItemModel>("menu");
                if (_type == 0)// 新增的时候
                    CurrentParentMenu = ParentNodes.First(m => m.MenuId == menu.MenuId);
                else// 修改的时候
                {
                    CurrentParentMenu = ParentNodes.First(m => m.MenuId == menu.ParentId);
                    MenuModel = menu;
                }

                MenuModel.ParentId = menu.ParentId;
            }
        }

        public MenuItemModel MenuModel { get; set; } = new MenuItemModel();
        public ObservableCollection<string> Icons { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<MenuItemModel> ParentNodes { get; set; } = new ObservableCollection<MenuItemModel>();

        private MenuItemModel _currentParentMenu;
        public MenuItemModel CurrentParentMenu
        {
            get => _currentParentMenu;
            set { SetProperty<MenuItemModel>(ref _currentParentMenu, value); }
        }


        public ICommand ConfirmCommand
        {
            get => new DelegateCommand(() =>
            {
                _menuBLL.SaveMenu(new MenuEntity
                {
                    MenuId = MenuModel.MenuId,
                    MenuHeader = MenuModel.MenuHeader,
                    TargetView = MenuModel.TargetView,
                    ParentId = CurrentParentMenu.MenuId,
                    MenuIcon = MenuModel.MenuIcon,// 字体图标
                    Index = MenuModel.Index,
                    MenuType = MenuModel.MenuType
                });

                RequestClose?.Invoke(new DialogResult(ButtonResult.OK));
            });
        }
        public ICommand CancelCommand
        {
            get => new DelegateCommand(() =>
            {
                RequestClose?.Invoke(new DialogResult(ButtonResult.Cancel));
            });
        }


        IMenuBLL _menuBLL;
        public AddMenuDialogViewModel(IContainerProvider containerProvider, IMenuBLL menuBLL)
        {
            _menuBLL = menuBLL;

            MenuModel.MenuType = 1;

            if (GlobalEntity.CurrentUserInfo == null) return;

            // 初始化父节点
            var origMenus = GlobalEntity.CurrentUserInfo.Menus;
            this.ParentNodes.Add(new MenuItemModel { MenuId = 0, MenuHeader = "根节点" });
            origMenus.ForEach(item =>
            {
                if (item.MenuType == 1)
                {
                    MenuItemModel mode = new MenuItemModel
                    {
                        MenuId = item.MenuId,
                        MenuHeader = item.MenuHeader
                    };
                    this.ParentNodes.Add(mode);
                }
            });

            // 初始化图标列表
            var icons = menuBLL.GetIcons();
            for (int i = 0; i < icons.Count; i++)
            {
                Icons.Add(((char)int.Parse(icons[i], System.Globalization.NumberStyles.HexNumber)).ToString());
            }
        }
    }
}
