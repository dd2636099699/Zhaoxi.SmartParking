using System;
using System.Collections.Generic;
using System.Text;
using Zhaoxi.SmartParking.Server.ICommon;
using Zhaoxi.SmartParking.Server.IService;

namespace Zhaoxi.SmartParking.Server.Service
{
    public class ReportService : BaseService, IReportService
    {
        public ReportService(IDbConnectionFactory contextFactor) : base(contextFactor)
        {
        }
    }
}
