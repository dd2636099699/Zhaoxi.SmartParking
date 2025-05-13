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
    public class MonitorBLL : IMonitorBLL
    {
        ILocalDataAccess _localDataAccess;
        public MonitorBLL(ILocalDataAccess localDataAccess)
        {
            _localDataAccess = localDataAccess;
        }

        //网络访问的   需要进行异步操作
        //本地访问
        public List<RoadEntity> GetRoads()
        {
            //获取车道信息
            var result = _localDataAccess.GetRoads();            
            List<RoadEntity> roads = Newtonsoft.Json.JsonConvert.DeserializeObject<List<RoadEntity>>(result);
            roads.ForEach(r =>
            {
                //根据当前国道信息获取对应的设备信息
                var dr = _localDataAccess.GetDevices(r.RoadId);
                r.DeviceList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<DeviceInfoEntity>>(dr);
            });
            return roads;
        }
    }
}
