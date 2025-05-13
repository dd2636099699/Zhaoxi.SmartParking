using System;
using System.Collections.Generic;
using System.Text;

namespace Zhaoxi.SmartParking.Server.ICommon
{
    public interface IConfiguration
    {
        string Read(string key);
    }
}
