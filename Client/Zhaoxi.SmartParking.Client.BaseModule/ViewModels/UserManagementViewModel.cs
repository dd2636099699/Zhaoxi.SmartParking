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
using System.Windows.Threading;
using Unity;
using Zhaoxi.SmartParking.Client.Common;
using Zhaoxi.SmartParking.Client.IBLL;
using Zhaoxi.SmartParking.Client.Models;

namespace Zhaoxi.SmartParking.Client.BaseModule.ViewModels
{
    public class UserManagementViewModel : PageViewModelBase
    {
        public ObservableCollection<UserInfoModel> Users { get; set; } = new ObservableCollection<UserInfoModel>();

        IUnityContainer _unityContainer;
        IDialogService _dialogService;
        IUserBLL _userBLL;
        IRoleBLL _roleBLL;
        public UserManagementViewModel(
            IRegionManager regionManager,
            IUnityContainer unityContainer,
            IEventAggregator ea,
            IDialogService dialogService,
            IUserBLL userBLL,
            IRoleBLL roleBLL)
            : base(regionManager, unityContainer, ea)
        {
            this.PageTitle = "系统用户管理";
            _userBLL = userBLL;
            _roleBLL = roleBLL;
            _unityContainer = unityContainer;
            _dialogService = dialogService;

        }

        public override void Refresh()
        {
            this.ShowLoading();
            Users.Clear();
            Task.Run(async () =>
            {
                var users = await _userBLL.GetAll();
                foreach (var item in users)
                {
                    UserInfoModel model = new UserInfoModel
                    {
                        Index = users.IndexOf(item) + 1,
                        UserId = item.UserId,
                        UserName = item.UserName,
                        UserIcon = System.Configuration.ConfigurationManager.AppSettings["api_domain"].ToString() + item.UserIcon,
                        Age = item.Age,
                        Password = item.Password,
                        RealName = item.RealName
                    };
                    // 获取用户对应的所有角色
                    var roles = await _roleBLL.GetAllByUserId(item.UserId);
                    roles?.ForEach(r => model.Roles.Add(new RoleModel { RoleId = r.roleId, RoleName = r.roleName, State = r.state }));

                    model.EditCommand = new DelegateCommand<object>(EditItem);
                    model.DeleteCommand = new DelegateCommand<object>(DeleteItem);
                    model.RoleCommand = new DelegateCommand<object>(SetRoles);
                    model.PwdCommand = new DelegateCommand<object>(SetPassword);

                    _unityContainer.Resolve<Dispatcher>().Invoke(() =>
                    {
                        Users.Add(model);
                    });
                }

                this.HideLoading();
            });
        }

        public override void AddItem()
        {
            DialogParameters param = new DialogParameters();
            param.Add("type", 0);// 新增

            ShowEditDialog(param);
        }

        private void EditItem(object obj)
        {
            DialogParameters param = new DialogParameters();
            param.Add("type", 1);// 编辑
            param.Add("model", obj as UserInfoModel);

            ShowEditDialog(param);
        }

        private void ShowEditDialog(DialogParameters param)
        {
            _dialogService.ShowDialog(
                "AddUserDialog",
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

        private async void DeleteItem(object obj)
        {
            if (System.Windows.MessageBox.Show("是否确定删除此用户信息？", "提示", System.Windows.MessageBoxButton.YesNo, System.Windows.MessageBoxImage.Question) == System.Windows.MessageBoxResult.Yes)
            {
                var model = obj as UserInfoModel;
                if (model != null)
                    await _userBLL.ChangeState(model.UserId, 0);

                this.Refresh();
            }
        }

        private void SetRoles(object obj)
        {
            DialogParameters param = new DialogParameters();
            param.Add("userId", (obj as UserInfoModel).UserId);// Dialog进行数据保存，知道对哪个用户进行操作
            param.Add("roles", (obj as UserInfoModel).Roles.Select(r => r.RoleId).ToList());

            _dialogService.ShowDialog(
                "ModifyRolesDialog",
                param,
                new Action<IDialogResult>(result =>
                {
                    if (result != null && result.Result == ButtonResult.OK)
                    {
                        System.Windows.MessageBox.Show("角色分配完成", "提示");
                        this.Refresh();
                    }
                }));
        }

        private void SetPassword(object obj)
        {
            this.ShowLoading("正在重置....");
            Task.Run(async () =>
            {
                await _userBLL.ResetPassword((obj as UserInfoModel).UserId);
                System.Windows.MessageBox.Show("密码已重置", "提示");
                this.HideLoading();
            });
        }
    }
}
