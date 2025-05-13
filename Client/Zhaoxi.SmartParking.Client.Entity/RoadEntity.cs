using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhaoxi.SmartParking.Client.Entity
{
    /// <summary>
    /// 对应的就是数据库的数据结构
    /// </summary>
    public class RoadEntity
    {
        public int RoadId { get; set; }
        public string RoadName { get; set; }
        public int RoadType { get; set; }

        public List<DeviceInfoEntity> DeviceList { get; set; }
    }
}
