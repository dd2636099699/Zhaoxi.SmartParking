using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhaoxi.SmartParking.Client.ILog
{
    public interface ILogHelper
    {
        void Debug(object source, string msg);  // 这个并不是最终的解决方案，Log4Net

        void Error(object source, string msg);
    }
}
