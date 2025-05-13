using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zhaoxi.SmartParking.Client.Entity;
using Zhaoxi.SmartParking.Client.IBLL;
using Zhaoxi.SmartParking.Client.IDAL;

namespace Zhaoxi.SmartParking.Client.BLL
{
    public class PayBLL : IPayBLL
    {
        IPayDal _payDal;
        public PayBLL(IPayDal payDal)
        {
            _payDal = payDal;
        }
        public async Task<int> GetState(long orderId)
        {
            string resultStr = await _payDal.GetState(orderId);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<PayRecieveEntity>(resultStr).state;
        }

        public async Task<string> Pay(long orderId, double money)
        {
            PaySendEntity entity = new PaySendEntity
            {
                orderId = orderId,
                oneceId = Guid.NewGuid().ToString(),
                totalPay = money
            };

            var resultStr = await _payDal.Pay(Newtonsoft.Json.JsonConvert.SerializeObject(entity));

            return Newtonsoft.Json.JsonConvert.DeserializeObject<PayRecieveEntity>(resultStr).Url;
        }
    }
}
