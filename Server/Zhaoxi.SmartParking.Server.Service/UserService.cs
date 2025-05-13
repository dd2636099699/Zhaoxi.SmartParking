using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zhaoxi.SmartParking.Server.ICommon;
using Zhaoxi.SmartParking.Server.IService;
using Zhaoxi.SmartParking.Server.Models;

namespace Zhaoxi.SmartParking.Server.Service
{
    public class UserService : BaseService, IUserService
    {
        IUtils _utils;
        public UserService(IDbConnectionFactory contextFactor, IUtils utils) : base(contextFactor)
        {
            _utils = utils;
        }

        public void ChangeState(int userId, int state)
        {
            var users = Context.Set<SysUserInfo>().Where(u => u.UserId == userId).ToList();
            users.ForEach(u => u.state = state);
            Context.SaveChanges();
        }

        public void SaveUser(string data)
        {
            var value = Newtonsoft.Json.JsonConvert.DeserializeObject<SysUserInfo>(data);

            value.state = 1;

            if (value.UserId == 0)
            {
                value.UserIcon = "image/show/temp.jpg";
                value.Password = _utils.GetMD5Str(_utils.GetMD5Str("123456") + "|" + value.UserName);
            }

            Context.Entry(value).State = value.UserId == 0 ?
                EntityState.Added :
                EntityState.Modified;
            Context.SaveChanges();
        }

        public void ResetPassword(int userId)
        {
            Context.Set<SysUserInfo>().Where(u => u.UserId == userId).ToList().ForEach(u => u.Password = _utils.GetMD5Str(_utils.GetMD5Str("123456") + "|" + u.UserName));

            Context.SaveChanges();
        }

        public void UpdateRoles(int userId, List<int> roles)
        {
            var r = Context.Set<UserRole>().Where(u => u.UserId == userId).ToList();
            r.ForEach(i => Context.Set<UserRole>().Remove(i));
            roles.ForEach(r => Context.Set<UserRole>().Add(new UserRole { UserId = userId, RoleId = r }));
            Context.SaveChanges();
        }
    }
}
