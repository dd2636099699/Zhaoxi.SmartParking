using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhaoxi.SmartParking.Client.IDAL
{
    public interface ILocalDataAccess
    {
        List<string[]> GetLocalFileInfo();
        List<string> GetIcons();

        /// <summary>
        /// 获取客户端类型
        /// </summary>
        /// <returns></returns>
        int GetClientType();
        /// 获取车道信息
        string GetRoads();
        /// <summary>
        /// 根据车道ID获取对应的设备信息
        /// </summary>
        /// <param name="roadId"></param>
        /// <returns></returns>
        string GetDevices(int roadId);
    }
}
