using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhaoxi.SmartParking.Client.Models
{
    public class ReportModel
    {
        //[Export("≥µ¡æ∫≈≈∆")]
        public string AutoLicense { get; set; }
        public string EnterTime { get; set; }
        public string LeaveTime { get; set; }
        public double Cost { get; set; }

    }
}
