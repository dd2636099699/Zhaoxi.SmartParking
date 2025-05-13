using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Zhaoxi.SmartParking.Client.Common;
using Zhaoxi.SmartParking.Client.Common.MessageSentEvent;

namespace Zhaoxi.SmartParking.Client.Start.Views
{
    /// <summary>
    /// LoginView.xaml 的交互逻辑
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView(IEventAggregator ea)
        {
            InitializeComponent();

            //var culture = Thread.CurrentThread.CurrentUICulture;
            // locBaml
            this.Resources.MergedDictionaries[2].Source=new Uri("pack://application:,,,/Zhaoxi.SmartParking.Client.Assets;component/Local/en-US.xaml");

            ea.GetEvent<CloseWindowEvent>().Subscribe(MessageReceived, ThreadOption.UIThread);
        }

        private void MessageReceived()
        {
            this.DialogResult = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
