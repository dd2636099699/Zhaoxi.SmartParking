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
    public class BillingBLL : IBillingBLL
    {
        IBillingDal _billingDal;
        public BillingBLL(IBillingDal billingDal)
        {
            _billingDal = billingDal;
        }

        public async Task<List<BillingEntity>> GetAll()
        {
            string resultStr = await _billingDal.GetAll();

            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<BillingEntity>>(resultStr);
        }
    }
}
