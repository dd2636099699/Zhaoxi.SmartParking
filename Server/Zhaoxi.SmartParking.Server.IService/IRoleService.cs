using System;
using System.Collections.Generic;
using System.Text;
using Zhaoxi.SmartParking.Server.Models;

namespace Zhaoxi.SmartParking.Server.IService
{
    public interface IRoleService : IBaseService
    {
        List<RoleInfo> GetRolesByUserId(int userId);
        List<SysUserInfo> GetAllUsers(int roleId);
        void Save(string role, string users, string menus);
    }
}
