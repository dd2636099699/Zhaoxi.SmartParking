using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhaoxi.SmartParking.Client.IDAL
{
    public interface IPayDal
    {
        // 支付请求 返回一个支付链接
        Task<string> Pay(string payInfo);

        // 检查支付状态
        Task<string> GetState(long orderId);
    }
}
