
using System;
using Zhaoxi.SmartParking.Server.EFCore;
using Zhaoxi.SmartParking.Server.ICommon;

namespace Zhaoxi.SmartParking.Server.Common
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        IConfiguration _configuration;
        public DbConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public EFCoreContext CreateDbContext()
        {
            return new EFCoreContext(_configuration.Read("DbConnectStr"));// 只是针对SqlServer
        }
    }
}
