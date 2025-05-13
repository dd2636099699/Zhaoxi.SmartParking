using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zhaoxi.SmartParking.Client.IDAL;

namespace Zhaoxi.SmartParking.Client.DAL
{
    public class AutoRegisterDal : WebDataAccess, IAutoRegisterDal
    {
        public Task<string> GetAll(int index, int count)
        {
            return this.GetDatas($"{domain}auto/all/{index}/{count}");
        }

        public Task<string> GetAutoByLicense(string license)
        {
            return this.GetDatas($"{domain}auto/info/{license}");
        }
    }
}
