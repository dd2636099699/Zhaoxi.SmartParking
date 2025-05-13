using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhaoxi.SmartParking.Client.Entity
{
    public class RecordEntity
    {
        public int RecordId { get; set; }
        public string AutoLicense { get; set; }
        public string EnterTime { get; set; }
        public string LeaveTime { get; set; }
        public double Cost { get; set; }
        public long OrderId { get; set; }
        public int state { get; set; }
    }
}
