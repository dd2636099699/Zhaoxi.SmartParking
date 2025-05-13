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
    public class RecordBLL : IRecordBLL
    {
        IRecordDal _recordDal;
        public RecordBLL(IRecordDal recordDal)
        {
            _recordDal = recordDal;
        }

        public async Task<List<RecordEntity>> GetRecord(string license)
        {
            var entityStr = await _recordDal.GetRecordByLicense(license);
            var entityList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<RecordEntity>>(entityStr);
            return entityList;
        }

        public void InsertRecord()
        {
            throw new NotImplementedException();
        }
    }
}
