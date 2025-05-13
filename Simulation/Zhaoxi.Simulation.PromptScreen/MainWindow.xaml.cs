using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Speech.Synthesis;
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

namespace Zhaoxi.Simulation.PromptScreen
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Socket> clients = new List<Socket>();
        public MainWindow()
        {
            InitializeComponent();

            SpeechSynthesizer speech = new SpeechSynthesizer { Rate = 0, Volume = 100 };
            //speech.SelectVoice("Microsoft Anna");
            //speech.SpeakAsync("鄂 A 0 0 0 0 1，欢迎光临");

            //PromptBuilder promptBuilder = new PromptBuilder();
            //PromptStyle style = new PromptStyle();
            //style.Rate = PromptRate.Slow;
            //promptBuilder.StartStyle(style);
            //promptBuilder.AppendText("鄂A00001 欢迎光临");
            //promptBuilder.EndStyle();

            //speech.SpeakAsync(promptBuilder);

            this.InitSocketServer();
        }

        private void InitSocketServer()
        {
            /*
             * 车辆信息的提示
             * 二维码的提示（图像、字符串（微信的支付链接、小程序链接））
             * 
             * AddressFamily.InterNetWork：使用 IP4地址。
             * SocketType.Stream：支持可靠、双向、基于连接的字节流，而不重复数据。此类型的 Socket 与单个对方主机进行通信，并在通信开始之前需要远程主机连接。Stream 使用传输控制协议 (Tcp) ProtocolType 和 InterNetworkAddressFamily。
             * ProtocolType.Tcp：使用传输控制协议。
             */

            //TcpListener tcpListener = TcpListener.Create(9001);
            //tcpListener.Start();
            //tcpListener.AcceptTcpClient();

            //TcpClient tcpClient = new TcpClient("127.0.0.1", 9002);
            //tcpClient.Connect("127.0.0.1", 9001);
            Socket socketServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socketServer.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9009));
            socketServer.Listen(1);

            Task.Run(async () =>
            {
                while (true)
                {
                    await Task.Delay(200);
                    var client = socketServer.Accept();
                    // 接收消息 监听
                    Task.Run(async () =>
                    {
                        while (true)
                        {
                            await Task.Delay(200);
                            //if (!socketServer.Connected) continue;
                            byte[] buffer = new byte[1024];
                            int length = client.Receive(buffer);
                            if (length > 0)
                            {
                                string msg = Encoding.UTF8.GetString(buffer);
                                this.Dispatcher.Invoke(() =>
                                {
                                    this.tbAutoLisence.Text = msg.Replace("\0", "").Trim();
                                });

                                //从客户端发送车牌信息过来后，
                                // 进行语音播报
                                SpeechSynthesizer speech = new SpeechSynthesizer { Rate = 0, Volume = 100 };
                                speech.SpeakAsync(msg);
                            }
                        }
                    });
                }
            });
        }
    }
}
