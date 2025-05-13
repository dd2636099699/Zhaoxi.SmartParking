using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zhaoxi.SmartParking.Client.IBLL;
using Zhaoxi.SmartParking.Client.IDAL;

namespace Zhaoxi.SmartParking.Client.BLL
{
    public class SettingsBLL : ISettingsBLL
    {
        ILocalDataAccess _localDataAccess;
        public SettingsBLL(ILocalDataAccess localDataAccess)
        {
            _localDataAccess = localDataAccess;
        }
        public int GetClientType()
        {
            return _localDataAccess.GetClientType();
        }
    }
}
