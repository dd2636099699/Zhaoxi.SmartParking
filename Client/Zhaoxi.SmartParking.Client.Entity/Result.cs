using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhaoxi.SmartParking.Client.Entity
{
    public class PaginationResult
    {
        public int State { get; set; }
        public string Message { get; set; }
        public PageInfo PageInfo { get; set; }
        public string Data { get; set; }
    }
    public class PageInfo
    {
        public int PageIndex { get; set; }
        public int RecordCount { get; set; }
    }
}
