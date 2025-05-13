using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhaoxi.SmartParking.Client.Entity
{
    public class BillingEntity
    {
        public int BillingId { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public double BillingRate { get; set; }
        public double AmountMoney { get; set; }
    }
}
