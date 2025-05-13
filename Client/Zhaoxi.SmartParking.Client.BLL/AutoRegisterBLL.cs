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
    public class AutoRegisterBLL : IAutoRegisterBLL
    {
        IAutoRegisterDal _autoRegisterDal;
        public AutoRegisterBLL(IAutoRegisterDal autoRegisterDal)
        {
            _autoRegisterDal = autoRegisterDal;
        }
        public async Task<PaginationResult> GetAll(int index, int count)
        {
            string resultStr = await _autoRegisterDal.GetAll(index, count);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<PaginationResult>(resultStr);
        }

        public async Task<AutoRegisterEntity> GetAutoByLicense(string license)
        {
            string resultStr = await _autoRegisterDal.GetAutoByLicense(license);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<AutoRegisterEntity>(resultStr);
        }
    }
}
