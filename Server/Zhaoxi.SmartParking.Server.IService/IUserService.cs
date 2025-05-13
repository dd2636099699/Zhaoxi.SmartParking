using System;
using System.Collections.Generic;
using System.Text;

namespace Zhaoxi.SmartParking.Server.IService
{
    public interface IUserService : IBaseService
    {
        void ChangeState(int userId, int state);
        void SaveUser(string data);
        void ResetPassword(int userId);
        void UpdateRoles(int userId, List<int> roles);
    }
}
