using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zhaoxi.SmartParking.Client.IBLL;
using Zhaoxi.SmartParking.Client.MainModule.Views;

namespace Zhaoxi.SmartParking.Client.MainModule
{
    public class MainModule : IModule
    {
       
        ISettingsBLL _settingsBLL;
        IMonitorBLL _monitorBLL;
        public MainModule(ISettingsBLL settingsBLL, IMonitorBLL monitorBLL)
        {
            _settingsBLL = settingsBLL;
            _monitorBLL = monitorBLL;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("LeftMenuTreeRegion", typeof(TreeMenuView));
            regionManager.RegisterViewWithRegion("MainHeaderRegion", typeof(MainHeaderView));


            var clientType = _settingsBLL.GetClientType();
            if (clientType == 2)
            {
                // 如果客户端管理中心类型的话  打开以下界面
                regionManager.RegisterViewWithRegion("MainContentRegion", typeof(DashboardView));
            }
            else if (clientType == 1)
            {
                //否则打开监控页面

                //获取车道信息
                //List<string> road = new List<string>();
                //进行车道遍历
                //    NavigationParameters param = new NavigationParameters();
                ////添加对应的车道信息
                //param.Add("info", "");
                //regionManager.RequestNavigate("MainContentRegion", "MonitorView", param);// 两个车道：需要打开两个MonitorView
                //regionManager.RequestNavigate("MainContentRegion", "MonitorView", param);// 两个车道：需要打开两个MonitorView

                // 获取所有车道信息
                var result = _monitorBLL.GetRoads();
                // 监控所有车道
                result.ForEach(r =>
                {
                    NavigationParameters param = new NavigationParameters();
                    param.Add("info", r);
                    regionManager.RequestNavigate("MainContentRegion", "MonitorView", param);
                });
            }
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<TreeMenuView>();
            containerRegistry.Register<MainHeaderView>();
            containerRegistry.Register<DashboardView>();

            containerRegistry.RegisterForNavigation<MonitorView>();
        }
    }
}
