using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhaoxi.SmartParking.Client.Entity
{
    public class DeviceInfoEntity
    {
        public int DeviceId { get; set; }
        public string DeviceName { get; set; }
        public string IP { get; set; }
        public int Port { get; set; }
        public string VisitorId { get; set; }
        public string Password { get; set; }
        public int ConnectId { get; set; }
        public string ConnectType { get; set; }
        public int RoadID { get; set; }
        public string RoadName { get; set; }
        public int State { get; set; }
    }
}
