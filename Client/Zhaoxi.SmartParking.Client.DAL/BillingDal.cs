using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zhaoxi.SmartParking.Client.IDAL;

namespace Zhaoxi.SmartParking.Client.DAL
{
    public class BillingDal : WebDataAccess, IBillingDal
    {
        public Task<string> GetAll()
        {
            return this.GetDatas($"{domain}billing/all");
        }
    }
}
