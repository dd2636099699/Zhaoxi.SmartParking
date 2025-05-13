using System;
using System.Collections.Generic;
using System.Text;
using Zhaoxi.SmartParking.Server.Models;

namespace Zhaoxi.SmartParking.Server.IService
{
    public interface IRecordService : IBaseService
    {
        List<RecordInfo> GetRecordInfo(string license);
    }
}
