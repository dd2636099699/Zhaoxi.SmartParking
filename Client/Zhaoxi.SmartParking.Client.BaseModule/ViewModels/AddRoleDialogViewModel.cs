using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Zhaoxi.SmartParking.Client.Entity;
using Zhaoxi.SmartParking.Client.IBLL;

namespace Zhaoxi.SmartParking.Client.BaseModule.ViewModels
{
    public class AddRoleDialogViewModel : BindableBase, IDialogAware
    {
        public string Title => "添加角色信息";

        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog() => true;

        public void OnDialogClosed() { }

        public void OnDialogOpened(IDialogParameters parameters) { }


        private string _roleName;
        public string RoleName
        {
            get => _roleName;
            set { SetProperty<string>(ref _roleName, value); }
        }

        public ICommand ConfirmCommand
        {
            get => new DelegateCommand(() =>
            {
                // 保存数据到数据库
                _roleBLL.Save(new RoleEntity { roleId = 0, roleName = this.RoleName, state = 1 }, new List<int>(), new List<int>());

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

        IRoleBLL _roleBLL;
        public AddRoleDialogViewModel(IRoleBLL roleBLL)
        {
            _roleBLL = roleBLL;
        }
    }
}
