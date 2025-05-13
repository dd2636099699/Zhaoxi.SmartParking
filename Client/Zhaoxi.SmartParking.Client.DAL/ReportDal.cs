using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zhaoxi.SmartParking.Client.IDAL;

namespace Zhaoxi.SmartParking.Client.DAL
{
    public class ReportDal : WebDataAccess, IReportDal
    {
        public Task<string> GetReportAll()
        {
            return this.GetDatas($"{domain}report/all");
        }
    }
}
