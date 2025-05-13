using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhaoxi.SmartParking.Client.Entity
{
    public class PaySendEntity
    {
        public long orderId { get; set; }
        public string apiKey { get; set; } = "b043d31eff7df2233635654d7==";
        public string oneceId { get; set; }
        public double totalPay { get; set; }
    }

    public class PayRecieveEntity
    {
        public bool Result { get; set; }
        public string Message { get; set; }
        public string Url { get; set; }
        public int state { get; set; }
    }
}
