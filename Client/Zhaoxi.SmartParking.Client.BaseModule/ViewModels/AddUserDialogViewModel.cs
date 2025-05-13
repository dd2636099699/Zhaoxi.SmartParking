using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Zhaoxi.SmartParking.Client.IBLL;
using Zhaoxi.SmartParking.Client.Models;

namespace Zhaoxi.SmartParking.Client.BaseModule.ViewModels
{
    public class AddUserDialogViewModel : BindableBase, IDialogAware
    {
        private string _title = "用户信息";
        public string Title => _title;

        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed() { }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            _title = "编辑" + _title;
            var _type = parameters.GetValue<int>("type");
            _title = (_type == 0 ? "新增" : "修改") + _title;
            this.RaisePropertyChanged("Title");

            // 编辑状态
            // 当编辑状态，用户Name不可以修改；在新增的时候是可以输入的
            if (_type == 1)
            {
                IsReadOnlyUserName = true;
                MainModel = parameters.GetValue<UserInfoModel>("model");
            }
        }


        private UserInfoModel _mainModel = new UserInfoModel();
        public UserInfoModel MainModel
        {
            get => _mainModel;
            set { SetProperty<UserInfoModel>(ref _mainModel, value); }
        }
        private bool _isReadOnlyUserName = false;
        public bool IsReadOnlyUserName
        {
            get => _isReadOnlyUserName;
            set { SetProperty<bool>(ref _isReadOnlyUserName, value); }
        }


        public ICommand ConfirmCommand
        {
            get => new DelegateCommand(() =>
            {
                // 确认操作
                // 数据校验（关键字段不能为空、年龄做数字区间的校验、做UserName的唯一检查（自定义特性检查））


                // 校验通过
                // 保存数据到数据库  新增和修改
                _userBLL.SaveUser(new Entity.UserEntity
                {
                    UserId = MainModel.UserId,
                    UserName = MainModel.UserName,
                    RealName = MainModel.RealName,
                    UserIcon = MainModel.UserIcon?.Replace(System.Configuration.ConfigurationManager.AppSettings["api_domain"].ToString(), ""),
                    Password = MainModel.Password,
                    Age = MainModel.Age
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

        IUserBLL _userBLL;
        public AddUserDialogViewModel(IUserBLL userBLL)
        {
            _userBLL = userBLL;
        }
    }
}
