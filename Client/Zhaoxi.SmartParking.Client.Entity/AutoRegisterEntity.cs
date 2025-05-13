using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhaoxi.SmartParking.Client.Entity
{
    public class AutoRegisterEntity
    {
        public int AutoId { get; set; }
        public string AutoLicense { get; set; }
        public int LColorId { get; set; }
        public string LColorName { get; set; }
        public int AColorId { get; set; }
        public string AColorName { get; set; }
        public int FeeModelId { get; set; }
        public string FeeModelName { get; set; }
        public string Description { get; set; }
        public int State { get; set; }
        public string ValidStartTime { get; set; }
        public string ValidEndTime { get; set; }
        public int ValidCount { get; set; }
    }
}
