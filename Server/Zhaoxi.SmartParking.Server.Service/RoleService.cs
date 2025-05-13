using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Zhaoxi.SmartParking.Server.ICommon;
using Zhaoxi.SmartParking.Server.IService;
using Zhaoxi.SmartParking.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Zhaoxi.SmartParking.Server.Service
{
    public class RoleService : BaseService, IRoleService
    {
        public RoleService(IDbConnectionFactory contextFactor) : base(contextFactor)
        {

        }

        public List<SysUserInfo> GetAllUsers(int roleId)
        {
            var ids = (from ur in Context.Set<UserRole>()
                       where ur.RoleId == roleId
                       select ur.UserId).ToList();
            return (from user in Context.Set<SysUserInfo>()
                    where ids.Contains(user.UserId)
                    select user).ToList();
        }

        public List<RoleInfo> GetRolesByUserId(int userId)
        {
            var roles = (from ur in Context.Set<UserRole>()
                         where ur.UserId == userId
                         select ur.RoleId).ToList();
            return (from role in Context.Set<RoleInfo>()
                    where roles.Contains(role.RoleId)
                    select role).ToList();
        }

        public void Save(string role, string users, string menus)
        {
            var value = Newtonsoft.Json.JsonConvert.DeserializeObject<RoleInfo>(role);
            var userids = Newtonsoft.Json.JsonConvert.DeserializeObject<List<int>>(users);
            var menuids = Newtonsoft.Json.JsonConvert.DeserializeObject<List<int>>(menus);

            Context.Entry<RoleInfo>(value).State = value.RoleId == 0 ? EntityState.Added : EntityState.Modified;
            if (value.RoleId > 0)
            {
                Context.Entry<RoleInfo>(value).State = EntityState.Modified;

                // 更新UserRole
                if (userids != null)
                {
                    var urs = Context.Set<UserRole>().Where(u => u.RoleId == value.RoleId).ToList();
                    urs.ForEach(u => Context.Set<UserRole>().Remove(u));
                    userids.ForEach(u => Context.Set<UserRole>().Add(new UserRole { UserId = u, RoleId = value.RoleId }));
                }
                // 更新RoleMenu
                if (menuids != null)
                {
                    var ms = Context.Set<RoleMenu>().Where(u => u.RoleId == value.RoleId).ToList();
                    ms.ForEach(m => Context.Set<RoleMenu>().Remove(m));
                    menuids.ForEach(m => Context.Set<RoleMenu>().Add(new RoleMenu { MenuId = m, RoleId = value.RoleId }));
                }
            }

            Context.SaveChanges();
        }
    }
}
