using Prism.Events;
using Prism.Regions;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Unity;
using Zhaoxi.SmartParking.Client.Common;
using Zhaoxi.SmartParking.Client.Entity;
using Zhaoxi.SmartParking.Client.IBLL;

namespace Zhaoxi.SmartParking.Client.MainModule.ViewModels
{
    public class MonitorViewModel : PageViewModelBase
    {
        private string _roadName;
        public string RoadName
        {
            get => _roadName;
            set { SetProperty<string>(ref _roadName, value); }
        }

        RoadEntity roadEntity = null;
        IAutoRegisterBLL _autoRegisterBLL;
        IRecordBLL _recordBLL;
        IBillingBLL _billingBLL;
        IPayBLL _payBLL;

        public MonitorViewModel(
            IRegionManager regionManager,
            IUnityContainer unityContainer,
            IEventAggregator ea,
            IAutoRegisterBLL autoRegisterBLL,
            IRecordBLL recordBLL,
            IBillingBLL billingBLL,
            IPayBLL payBLL
            )
            : base(regionManager, unityContainer, ea)
        {
            this.PageTitle = "车道监控";
            this.IsCanClose = false;
            this.CanNavigationTargetFunc = new Func<bool>(() => false);

            _autoRegisterBLL = autoRegisterBLL;
            _recordBLL = recordBLL;
            _billingBLL = billingBLL;
            _payBLL = payBLL;

            this.NavigatedToAction = new Action<NavigationContext>((nav) =>
            {
                roadEntity = nav.Parameters["info"] as RoadEntity;
                this.PageTitle += "-" + roadEntity.RoadName;
                this.RoadName = roadEntity.RoadName;

                this.Refresh();
            });
        }


        // 通信连接 
        Dictionary<string, Socket> clients = new Dictionary<string, Socket>();
        public override void Refresh()
        {
            this.ShowLoading();

            Task.Run(() =>
            {
                //拿到当前车道的所有设备信息（IP   Port）
                // 模拟的硬件程序

                roadEntity?.DeviceList.ForEach(d =>
                {
                    // 连接入口设备
                    IPAddress iPAddress = IPAddress.Parse(d.IP);
                    Socket socketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    socketClient.Connect(new IPEndPoint(iPAddress, d.Port));//每个客户端都连接上

                    // 每个设备都有可能进行消息的发送
                    clients.Add(d.Port.ToString(), socketClient);

                    Task.Run(async () =>
                    {
                        while (true)
                        {
                            if (!socketClient.Connected) continue;
                            byte[] buffer = new byte[10];

                            //接收其他端发送过来的信息
                            // msg=Hello      [00000005]HelloHelloHello
                            // 解决了：粘包和丢包
                            var length = socketClient.Receive(buffer);

                            // 执行业务逻辑
                            var code = Encoding.UTF8.GetString(buffer).Replace("\0", "");
                            System.Diagnostics.Debug.WriteLine(code);

                            string[] values = code.Split(':');
                            if (values[0] == "9002" || values[0] == "9006")//代码相机返回信息
                            {

                                // 获取返回图像
                                // 图像识别
                                // 获取车牌号

                                // 做出口逻辑
                                string license = "苏E05EV8";
                                string autoLicense = license + (roadEntity.RoadType == 1 ? "，欢迎光临" : "，一路顺风");
                                if (values[1] == "1")
                                {
                                    // 向提示屏发送消息 
                                    clients["9009"].Send(Encoding.UTF8.GetBytes(autoLicense));
                                }

                                // 获取车牌登记信息
                                var autoInfo = await _autoRegisterBLL.GetAutoByLicense(license);
                                if (autoInfo.FeeModelId == 4 && autoInfo.ValidCount > 0)
                                {
                                    // 更新次数
                                }
                                else if (new int[] { 2, 3 }.Contains(autoInfo.FeeModelId) &&
                                DateTime.Compare(DateTime.Parse(autoInfo.ValidEndTime), DateTime.Now) <= 0)
                                {
                                    // 时间区间有效
                                }
                                else
                                {
                                    double money = 0.0;
                                    // 查找入口记录
                                    List<RecordEntity> record = await _recordBLL.GetRecord(license);
                                    if (record.Exists(r => r.state == 1))
                                    {
                                        // 提前支付，判断时间是否在半小时之内
                                    }
                                    else if (record.Exists(r => r.state == 0))
                                    {
                                        // 通过入口时间，计算费用
                                        // 获取费用标准
                                        List<BillingEntity> billing = await _billingBLL.GetAll();
                                        // 根据不同时段进行费用计算  [一些基本的算法]

                                        money = 0.01;

                                        // 向支付接口请求
                                        DateTime time = DateTime.Now;
                                        long orderId = long.Parse(time.ToString("yyyMMdd") + ((time.ToUniversalTime().Ticks - 621355968000000000) / 10000000).ToString()) + new Random().Next(100, 10000);
                                        var payUrl = await _payBLL.Pay(orderId, money);

                                        // 针对URL生成二维码
                                        // 可以把URL发送给提示屏  做二维码的处理
                                        // 还可以传图片
                                        // 模拟，图片保存本地
                                        QRCodeGenerator qrGenerator = new QRCoder.QRCodeGenerator();
                                        QRCodeData qrCodeData = qrGenerator.CreateQrCode(payUrl, QRCodeGenerator.ECCLevel.Q);
                                        QRCode qrcode = new QRCode(qrCodeData);

                                        Bitmap qrCodeImage = qrcode.GetGraphic(5, System.Drawing.Color.Black, System.Drawing.Color.White, null, 15, 6, false);
                                        qrCodeImage.Save("d:\\pay.png", ImageFormat.Png);
                                        //二维码保存在本地


                                        // 做轮询
                                        int state = 0;
                                        while (state == 0)
                                        {
                                            await Task.Delay(500);
                                            state = await _payBLL.GetState(orderId);
                                        }

                                        // 支付成功

                                    }
                                }


                               
                            }
                        }
                    });
                });

                this.HideLoading();
            });
        }
    }
}
