using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhaoxi.SmartParking.Client.Common.MessageSentEvent
{
    public class LoadingPayload
    {
        public bool IsShow { get; set; }
        public string Message { get; set; }
    }
    public class LoadingEvent : PubSubEvent<LoadingPayload> { }
}
