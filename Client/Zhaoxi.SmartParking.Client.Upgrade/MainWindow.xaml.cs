using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Zhaoxi.SmartParking.Client.Upgrade.ViewModel;

namespace Zhaoxi.SmartParking.Client.Upgrade
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(string[] args)
        {
            InitializeComponent();

            this.DataContext = new MainWindowViewModel(args)
            {
                ConfirmAction = new Action(OnFinished)
            };
        }

        private void OnFinished()
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                // 打开升级完成确认窗口
                new FinishWindow() { Owner = this }.ShowDialog();
            });
        }
    }
}
