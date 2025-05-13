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
    public class ReportBLL : IReportBLL
    {
        IReportDal _reprotDal;
        public ReportBLL(IReportDal reprotDal)
        {
            _reprotDal = reprotDal;
        }

        public async Task<List<RecordEntity>> GetRecord()
        {
            string resultStr = await _reprotDal.GetReportAll();
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<RecordEntity>>(resultStr);
        }
    }
}
