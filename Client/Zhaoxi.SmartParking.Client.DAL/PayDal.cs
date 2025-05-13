using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Zhaoxi.SmartParking.Client.IDAL;

namespace Zhaoxi.SmartParking.Client.DAL
{
    public class PayDal : WebDataAccess, IPayDal
    {
        public Task<string> GetState(long orderId)
        {
            return this.GetDatas("http://47.95.2.2/api/Pay/state/" + orderId);
        }

        public Task<string> Pay(string payInfo)
        {
            return this.PostDatas("http://47.95.2.2/api/zhaoxi/pay", new StringContent(payInfo));
        }
    }
}
