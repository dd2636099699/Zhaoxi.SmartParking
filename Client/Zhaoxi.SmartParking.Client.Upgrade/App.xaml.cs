using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Zhaoxi.SmartParking.Client.Upgrade
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            if (e.Args == null || e.Args.Length == 0)
                Application.Current.Shutdown();

            new MainWindow(e.Args).Show();
        }
    }
}
