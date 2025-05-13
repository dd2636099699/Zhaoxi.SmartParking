using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zhaoxi.SmartParking.Client.IDAL;

namespace Zhaoxi.SmartParking.Client.DAL
{
    public class RecordDal : WebDataAccess, IRecordDal
    {
        public Task<string> GetRecordByLicense(string license)
        {
            return this.GetDatas($"{domain}record/license/{license}");
        }
    }
}
