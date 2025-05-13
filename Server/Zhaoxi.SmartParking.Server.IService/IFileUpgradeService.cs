using System;
using Zhaoxi.SmartParking.Server.Models;

namespace Zhaoxi.SmartParking.Server.IService
{
    public interface IFileUpgradeService : IBaseService
    {
        int AddOrUpdate(UpgradeFile upgradeFile);
    }
}
