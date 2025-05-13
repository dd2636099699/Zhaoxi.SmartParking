using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using Unity;
using Unity.Interception;
using Unity.Interception.Interceptors.InstanceInterceptors.InterfaceInterception;
using Zhaoxi.SmartParking.Client.AutoModule;
using Zhaoxi.SmartParking.Client.BaseModule;
using Zhaoxi.SmartParking.Client.BLL;
using Zhaoxi.SmartParking.Client.DAL;
using Zhaoxi.SmartParking.Client.IBLL;
using Zhaoxi.SmartParking.Client.IDAL;
using Zhaoxi.SmartParking.Client.ILog;
using Zhaoxi.SmartParking.Client.Log;
using Zhaoxi.SmartParking.Client.ReportModule;
using Zhaoxi.SmartParking.Client.Start.Views;
using Zhaoxi.SmartParking.Client.SysModule;

namespace Zhaoxi.SmartParking.Client.Start
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : PrismApplication
    {
        public App()
        {
            // 日志Log4Net初始化
            LogConfiguration log = new LogConfiguration();
            log.Initialize();

        }
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell(Window shell)
        {
            // 通信容器来获取对象  可以进行相关对象的注入
            if (Container.Resolve<LoginView>().ShowDialog() == false)
            {
                Application.Current?.Shutdown();
            }
            else
            {
                base.InitializeShell(shell);
            }
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Unity -》 配置一个AOP
            //var container = Container.Resolve<IUnityContainer>();
            //container = container.AddNewExtension<Interception>();

            /// 全局对象注册
            containerRegistry.Register<Dispatcher>(() => Application.Current.Dispatcher);


            // 注册所有DAL
            containerRegistry.Register<IWebDataAccess, WebDataAccess>();
            containerRegistry.Register<IUpgradeDal, UpgradeDal>();
            containerRegistry.Register<IMenuDal, MenuDal>();
            containerRegistry.Register<IUserDal, UserDal>();
            containerRegistry.Register<IRoleDal, RoleDal>();
            containerRegistry.Register<IAutoRegisterDal, AutoRegisterDal>();
            //20210315
            containerRegistry.Register<IRecordDal, RecordDal>();
            containerRegistry.Register<IBillingDal, BillingDal>();
            containerRegistry.Register<IPayDal, PayDal>();
            //
            containerRegistry.Register<IReportDal, ReportDal>();



            // 注册所有BLL
            containerRegistry.Register<IUpgradeFileBLL, UpgradeFileBLL>();
            containerRegistry.Register<ILocalDataAccess, LocalDataAccess>();
            containerRegistry.Register<ILoginBLL, LoginBLL>();
            containerRegistry.Register<IMenuBLL, MenuBLL>();
            containerRegistry.Register<IUserBLL, UserBLL>();
            containerRegistry.Register<IRoleBLL, RoleBLL>();
            containerRegistry.Register<IAutoRegisterBLL, AutoRegisterBLL>();
            containerRegistry.Register<IMonitorBLL, MonitorBLL>();
            containerRegistry.Register<ISettingsBLL, SettingsBLL>();
            //20210315
            containerRegistry.Register<IRecordBLL, RecordBLL>();
            containerRegistry.Register<IBillingBLL, BillingBLL>();
            containerRegistry.Register<IPayBLL, PayBLL>();
            //
            containerRegistry.Register<IReportBLL, ReportBLL>();


            //20210316    配合当前框架-》常规使用  
            // 
            containerRegistry.RegisterSingleton<ILogHelper, LogHelper>();
            //container.Configure<Interception>().SetInterceptorFor<IUpgradeFileBLL>(new InterfaceInterceptor());



            //  注册弹出窗父窗口
            containerRegistry.RegisterDialogWindow<DialogWindow>();
        }


        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);
            // 自动扫描目录

            // 手动添加
            moduleCatalog.AddModule<MainModule.MainModule>();
            moduleCatalog.AddModule<SystemModule>();
            moduleCatalog.AddModule<BaseInfoModule>();
            moduleCatalog.AddModule<AutoInfoModule>();
            moduleCatalog.AddModule<ReportInfoModule>();

        }
    }
}
