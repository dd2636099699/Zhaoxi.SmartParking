using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhaoxi.SmartParking.Client.IBLL
{
    public interface IPayBLL
    {
        Task<string> Pay(long orderId, double money);
        Task<int> GetState(long orderId);
    }
}
