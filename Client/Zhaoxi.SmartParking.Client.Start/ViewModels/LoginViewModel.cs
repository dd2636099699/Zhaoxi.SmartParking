using Prism.Commands;
using Prism.Events;
using Prism.Ioc;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Zhaoxi.SmartParking.Client.Common;
using Zhaoxi.SmartParking.Client.Common.MessageSentEvent;
using Zhaoxi.SmartParking.Client.IBLL;

namespace Zhaoxi.SmartParking.Client.Start.ViewModels
{
    public class LoginViewModel : BindableBase
    {
        #region 属性
        public DelegateCommand CancelLoadingCommand { get => new DelegateCommand(() => IsLoading = false); }
        private bool _isLoading;

        public bool IsLoading
        {
            get { return _isLoading; }
            set { SetProperty(ref _isLoading, value); }
        }

        private string _loadingMessage;

        public string LoadingMessage
        {
            get { return _loadingMessage; }
            set { SetProperty(ref _loadingMessage, value); }
        }

        private string _userName = "admin";

        public string UserName
        {
            get { return _userName; }
            set { SetProperty(ref _userName, value); }
        }

        private string _password = "123456";

        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        private string _errorMsg;

        public string ErrorMsg
        {
            get { return _errorMsg; }
            set { SetProperty(ref _errorMsg, value); }
        }
        #endregion


        private ICommand _loginCommand;

        public ICommand LoginCommand
        {
            get
            {
                if (_loginCommand == null)
                    _loginCommand = new DelegateCommand<object>(OnLogin);
                return _loginCommand;
            }
        }

        private async void OnLogin(object obj)
        {
            try
            {
                this.ErrorMsg = "";
                if (string.IsNullOrEmpty(this.UserName))
                {
                    this.ErrorMsg = "请输入用户名";
                    return;
                }
                if (string.IsNullOrEmpty(this.Password))
                {
                    this.ErrorMsg = "请输入密码";
                    return;
                }
                this.IsLoading = true;
                this.LoadingMessage = "正在登录";
                // 请求WebAPI
                await Task.Delay(1000);
                if (await _loginBLL.Login(this.UserName, this.Password))
                {
                    (obj as Window).DialogResult = true;
                }
                else
                {
                    // 提示错误
                    this.ErrorMsg = "用户名或密码错误，请重新输入";
                    this.IsLoading = false;
                }
            }
            catch (Exception ex)
            {
                //_logHelper.Error(this, ex.Message);
                //ex.StackTrace;
                //ex.Message;
                // 消息提示
                MessageBox.Show("登录失败！");
            }
        }


        //GlobalEntity _globalEntity = null;
        IUpgradeFileBLL _systemBLL = null;
        ILoginBLL _loginBLL = null;
        public LoginViewModel(
            IContainerProvider containerProvider,
            IEventAggregator ea,
            IUpgradeFileBLL systemBLL,
            ILoginBLL loginBLL)
        {
            //_globalEntity = containerProvider.Resolve<GlobalEntity>();
            _systemBLL = systemBLL;
            _loginBLL = loginBLL;

            // 应用启动时开始检查程序版本
            this.IsLoading = true;
            this.LoadingMessage = "正在检查软件版本";
            Task.Run(async () =>
            {
                await Task.Delay(2000);

                try
                {
                    var result = await _systemBLL.DiffFileListAsync();
                    if (result.Count > 0)
                    {
                        // 需要更新的时候，启动更新程序，关闭主程序

                        Process process = Process.Start(
                            "Zhaoxi.SmartParking.Client.Upgrade.exe",
                            string.Join(" ", result.ToArray())
                            );
                        process.WaitForInputIdle();

                        ea.GetEvent<CloseWindowEvent>().Publish();
                    }

                    // 否则的话开始执行登录 
                    this.IsLoading = false;
                }
                catch (Exception)
                {
                    MessageBox.Show("系统检查更新失败！");
                }
            });
        }
    }
}
