using System;
using Zhaoxi.SmartParking.Server.EFCore;

namespace Zhaoxi.SmartParking.Server.ICommon
{
    public interface IDbConnectionFactory
    {
        EFCoreContext CreateDbContext();
    }
}
