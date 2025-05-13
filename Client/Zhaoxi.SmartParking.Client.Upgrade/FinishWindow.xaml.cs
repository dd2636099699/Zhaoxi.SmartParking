using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Zhaoxi.SmartParking.Client.Upgrade.ViewModel;

namespace Zhaoxi.SmartParking.Client.Upgrade
{
    /// <summary>
    /// FinishWindow.xaml 的交互逻辑
    /// </summary>
    public partial class FinishWindow : Window
    {
        public FinishWindow()
        {
            InitializeComponent();

            this.DataContext = new FinishViewModel()
            {
                ConfirmAction = new Action<bool>((arg) =>
                {
                    if (arg)
                    {
                        Process process = Process.Start("Zhaoxi.SmartParking.Client.Start.exe");
                        process.WaitForInputIdle();
                    }

                    Application.Current.Shutdown();
                })
            };
        }
    }
}
