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

namespace Zhaoxi.SmartParking.Client.BaseModule.ViewModels
{
    public class RoleManagementViewModel : PageViewModelBase
    {
        public ObservableCollection<RoleModel> Roles { get; set; } = new ObservableCollection<RoleModel>();
        public ObservableCollection<UserInfoModel> Users { get; set; } = new ObservableCollection<UserInfoModel>();
        public ObservableCollection<MenuItemModel> Menus { get; set; } = new ObservableCollection<MenuItemModel>();

        private RoleModel _currentRole;
        public RoleModel CurrentRole
        {
            get => _currentRole;
            set { SetProperty<RoleModel>(ref _currentRole, value); }
        }

        public ICommand SaveCommand
        {
            get => new DelegateCommand(async () =>
            {
                this.ShowLoading("正在保存....");
                _menusids.Clear();
                GetSelectedMenuIds(Menus);
                await _roleBLL.Save(new RoleEntity { roleId = CurrentRole.RoleId, roleName = CurrentRole.RoleName, state = 1 },
                     Users.Select(u => u.UserId).ToList(),
                     _menusids);

                this.HideLoading();
                System.Windows.MessageBox.Show("数据保存完成", "提示");
                this.Refresh();
            });
        }

        public ICommand AddUserCommand
        {
            get => new DelegateCommand(() =>
            {
                DialogParameters param = new DialogParameters();
                param.Add("ids", Users.Select(u => u.UserId).ToList());

                _dialogService.ShowDialog(
               "SelectUserDialog",
               param,
               new Action<IDialogResult>(result =>
               {
                   if (result != null && result.Result == ButtonResult.OK)
                   {
                       var users = result.Parameters.GetValue<List<UserInfoModel>>("users");
                       users.ForEach(u => Users.Add(new UserInfoModel
                       {
                           UserId = u.UserId,
                           UserName = u.UserName,
                           RealName = u.RealName,
                           DeleteCommand = new DelegateCommand<object>((obj) =>
                           {
                               Users.Remove(obj as UserInfoModel);
                           })
                       }));
                   }
               }));
            });
        }

        Dispatcher _dispatcher;
        IRoleBLL _roleBLL;
        IMenuBLL _menuBLL;
        IDialogService _dialogService;
        public RoleManagementViewModel(
            IRegionManager regionManager,
            IUnityContainer unityContainer,
            IEventAggregator ea,
            IRoleBLL roleBLL,
            IMenuBLL menuBLL,
            IDialogService dialogService
            )
            : base(regionManager, unityContainer, ea)
        {
            this.PageTitle = "用户角色管理";

            _dispatcher = unityContainer.Resolve<Dispatcher>();
            _dialogService = dialogService;
            _roleBLL = roleBLL;
            _menuBLL = menuBLL;
        }

        public override void Refresh()
        {
            this.ShowLoading();
            Roles.Clear();
            Task.Run(async () =>
            {
                var roles = await _roleBLL.GetAll();
                if (roles != null)
                {
                    _dispatcher.Invoke(() =>
                    {
                        roles.ForEach(r => Roles.Add(new RoleModel
                        {
                            RoleId = r.roleId,
                            RoleName = r.roleName,
                            ItemSelectedCommand = new DelegateCommand<object>(async (obj) =>
                            {
                                this.CurrentRole = obj as RoleModel;
                                await LoadUsersAndMenus();
                            }),
                            DeleteCommand = new DelegateCommand<object>(DeleteItem)
                        }));
                    });
                    if (Roles.Count > 0)
                    {
                        Roles[0].IsSelected = true;
                        CurrentRole = Roles[0];
                    }
                }

                await LoadUsersAndMenus();

                this.HideLoading();
            });
        }

        private async Task LoadUsersAndMenus()
        {
            _dispatcher.Invoke(() =>
            {
                Users.Clear(); Menus.Clear();
            });
            if (CurrentRole != null)
            {
                // 获取当前角色下所有用户
                var users = await _roleBLL.GetAllUsers(CurrentRole.RoleId);
                _dispatcher.Invoke(() =>
                {
                    users.ForEach(u => Users.Add(new UserInfoModel
                    {
                        UserId = u.UserId,
                        UserName = u.UserName,
                        DeleteCommand = new DelegateCommand<object>((obj) =>
                        {
                            Users.Remove(obj as UserInfoModel);
                        })
                    }));
                });
                // 获取当前角色下所有菜单
                var alls = await _menuBLL.GetAllMenus();
                var current = await _menuBLL.GetMenus(CurrentRole.RoleId);
                // 递归菜单数据

                _dispatcher.Invoke(() =>
                {
                    FillMenus(alls, Menus, new MenuItemModel { MenuId = 0 }, current.Select(c => c.MenuId).ToList());
                });
            }
        }

        private void FillMenus(IList<MenuEntity> origMenus, IList<MenuItemModel> menus, MenuItemModel parent, IList<int> role_menus)
        {
            var sub = origMenus.Where(m => m.ParentId == parent.MenuId).OrderBy(o => o.Index);

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
                        Index = item.Index,
                        IsSelected = role_menus.Contains(item.MenuId),
                        Parent = parent
                    };

                    FillMenus(origMenus, mm.Children, mm, role_menus);
                    mm.HasChild = mm.Children.Count > 0;
                    menus.Add(mm);
                }
            }
        }
        List<int> _menusids = new List<int>();
        private void GetSelectedMenuIds(IList<MenuItemModel> menus)
        {
            if (menus != null && menus.Count > 0)
            {
                menus.ToList().ForEach(m =>
                {
                    if (m.IsSelected)
                        _menusids.Add(m.MenuId);

                    GetSelectedMenuIds(m.Children);
                });
            }
        }

        public override void AddItem()
        {
            _dialogService.ShowDialog(
                "AddRoleDialog",
                null,
                new Action<IDialogResult>(result =>
                {
                    if (result != null && result.Result == ButtonResult.OK)
                    {
                        System.Windows.MessageBox.Show("数据已保存", "提示");
                        this.Refresh();
                    }
                }));
        }

        private async void DeleteItem(object obj)
        {
            if (System.Windows.MessageBox.Show("是否确定删除此角色信息？", "提示", System.Windows.MessageBoxButton.YesNo, System.Windows.MessageBoxImage.Question) == System.Windows.MessageBoxResult.Yes)
            {
                this.ShowLoading("正在删除....");
                var value = obj as RoleModel;
                await _roleBLL.Save(new RoleEntity { roleId = value.RoleId, roleName = value.RoleName, state = 0 },
                    new List<int>(), new List<int>());

                this.Refresh();
            }
        }
    }
}
