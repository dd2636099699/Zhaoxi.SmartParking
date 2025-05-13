using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zhaoxi.SmartParking.Client.Entity;

namespace Zhaoxi.SmartParking.Client.IBLL
{
    public interface IRecordBLL
    {
        Task<List<RecordEntity>> GetRecord(string license);

        // 录入记录 ->  需要对服务器数据进行更新
        void InsertRecord(); // 默认情况直接写到服务器  -》 AOP的方式，在后面执行本地缓存的更新
        // 更新记录 ->  需要对服务器数据进行更新

    }
}
