using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
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

namespace Zhaoxi.Simulation.Devices
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.InitSocketServers();
        }

        List<Socket> servers = new List<Socket>();
        Dictionary<string, Socket> clients = new Dictionary<string, Socket>();
        private void InitSocketServers()
        {
            List<IPEndPoint> ips = new List<IPEndPoint>();
            ips.Add(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9001));
            ips.Add(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9002));
            ips.Add(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9003));
            ips.Add(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9004));

            ips.Add(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9005));
            ips.Add(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9006));
            ips.Add(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9007));
            ips.Add(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9008));

            Task.Run(() =>
            {
                ips.ForEach(async  (ep) =>
                    {
                        // 实例化Socket对象
                        Socket socketServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        socketServer.Bind(ep);//设置对应的主机地址（IP、Port）
                        socketServer.Listen(10);// 监听    表示等待连接对象只能有10个  
                                                // 在UI线程中显示弹窗
                        while (true)
                        {
                            await Task.Delay(200);
                          
                            MessageBox.Show($"端口 {ep.Port} 开始监听");
                            Socket client = socketServer.Accept();
                            MessageBox.Show($"端口 {ep.Port} 连接");
                            clients.Add(ep.Port.ToString(), client);

                            servers.Add(socketServer);
                        }
                    });
            });
        }

        private void Button_Click(object sender, RoutedEventArgs e)

        {
            string port = (sender as Button).Tag.ToString();
            Socket client = clients[port];
            client.Send(Encoding.UTF8.GetBytes($"{port}:1"));
        }

        protected override void OnClosed(EventArgs e)
        {
            // 关闭服务端
            servers.ForEach((s) =>
            {
                s?.Shutdown(SocketShutdown.Both);
                s?.Dispose();
                s?.Close();
            });
        }
    }
}
