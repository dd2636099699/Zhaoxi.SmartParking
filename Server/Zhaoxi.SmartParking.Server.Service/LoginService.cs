using System;
using System.Collections.Generic;
using System.Text;
using Zhaoxi.SmartParking.Server.ICommon;
using Zhaoxi.SmartParking.Server.IService;

namespace Zhaoxi.SmartParking.Server.Service
{
    public class LoginService : BaseService, ILoginService
    {
        public LoginService(IDbConnectionFactory contextFactor) : base(contextFactor) { }
    }
}
