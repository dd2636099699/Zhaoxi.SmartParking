using Prism.Commands;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Zhaoxi.SmartParking.Client.IBLL;
using Zhaoxi.SmartParking.Client.Models;

namespace Zhaoxi.SmartParking.Client.BaseModule.ViewModels
{
    public class SelectUserDialogViewModel : IDialogAware
    {
        public string Title => "选择用户";

        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog() => true;

        public void OnDialogClosed() { }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            _userIds = parameters.GetValue<List<int>>("ids");
        }

        List<int> _userIds;

        public ObservableCollection<UserInfoModel> Users { get; set; } = new ObservableCollection<UserInfoModel>();

        IUserBLL _userBLL;
        public SelectUserDialogViewModel(IUserBLL userBLL)
        {
            _userBLL = userBLL;

            this.InitUsers();
        }

        private async void InitUsers()
        {
            var users = await _userBLL.GetAll();
            users.Where(u => !_userIds.Contains(u.UserId)).ToList().
                ForEach(u => Users.Add(new UserInfoModel
                {
                    UserId = u.UserId,
                    UserName = u.UserName,
                    RealName = u.RealName
                }));
        }

        public ICommand ConfirmCommand
        {
            get => new DelegateCommand(() =>
            {
                // 返回选中用户
                DialogParameters param = new DialogParameters();
                param.Add("users", Users.Where(u => u.IsSelected).ToList());

                RequestClose?.Invoke(new DialogResult(ButtonResult.OK, param));
            });
        }
        public ICommand CancelCommand
        {
            get => new DelegateCommand(() =>
            {
                RequestClose?.Invoke(new DialogResult(ButtonResult.Cancel));
            });
        }
    }
}
