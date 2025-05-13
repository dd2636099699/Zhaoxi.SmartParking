using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Zhaoxi.SmartParking.Server.ICommon;
using Zhaoxi.SmartParking.Server.IService;
using Zhaoxi.SmartParking.Server.Models;

namespace Zhaoxi.SmartParking.Server.Service
{
    public class RecordService : BaseService, IRecordService 
    {
        public RecordService(IDbConnectionFactory contextFactor) : base(contextFactor)
        {

        }

        public List<RecordInfo> GetRecordInfo(string license)
        {
            // 先取已支付的最大时间，如果没有，就是0
            var maxTime = this.Query<RecordInfo>(p => p.AutoLicense == license && p.State == 1)?.ToList()
                .Max(pm => GetTimespan(pm.LeaveTime));

            maxTime = maxTime == null ? 0 : maxTime;
            ; return this.Query<RecordInfo>(p => p.AutoLicense == license && (p.State == 0 ||
             (p.State == 1 && maxTime > 0 && GetTimespan(p.LeaveTime) == maxTime))).ToList();
        }

        private long GetTimespan(string timeStr)
        {
            long timeLong = 0;
            if (!string.IsNullOrEmpty(timeStr))
                timeLong = (DateTime.ParseExact(timeStr, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture).Ticks - 621355968000000000) / 10000000;

            return timeLong;
        }
    }
}
