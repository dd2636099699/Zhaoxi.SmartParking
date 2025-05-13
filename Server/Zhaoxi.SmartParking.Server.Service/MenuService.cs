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
    public class MenuService : BaseService, IMenuService
    {
        public MenuService(IDbConnectionFactory contextFactor) : base(contextFactor) { }

        public List<MenuInfo> GetAllMenus()
        {
            return (from menu in Context.Set<MenuInfo>()
                    where menu.State == 1
                    select menu).ToList();
        }

        public List<MenuInfo> GetMenusByRoleId(int roleId)
        {
            // 获取所有权限
            var roles = (from role in Context.Set<RoleInfo>()
                         where role.RoleId == roleId && role.state == 1
                         select role.RoleId).ToList();

            var query = from menu in Context.Set<MenuInfo>()
                        join role_menu in Context.Set<RoleMenu>()
                        on menu.MenuId equals role_menu.MenuId
                        where roles.Contains(role_menu.RoleId) && menu.State == 1
                        select menu;

            return query.Distinct().ToList();
        }

        public List<MenuInfo> GetMenusByUserId(int userid)
        {
            // 获取所有权限
            var roles = (from ur in Context.Set<UserRole>()
                         join role in Context.Set<RoleInfo>() on ur.RoleId equals role.RoleId
                         where ur.UserId == userid && role.state == 1
                         select ur.RoleId).ToList();

            // 菜单的去重
            var query = from menu in Context.Set<MenuInfo>()
                        join role_menu in Context.Set<RoleMenu>()
                        on menu.MenuId equals role_menu.MenuId
                        where roles.Contains(role_menu.RoleId) && menu.State == 1
                        select menu;

            return query.Distinct().ToList();
        }

        public void SaveMenu(string data)
        {
            var value = Newtonsoft.Json.JsonConvert.DeserializeObject<MenuInfo>(data);

            if (value.MenuId == 0)
            {
                var index = Context.Set<MenuInfo>().Max(i => i.Index);
                value.Index = index + 1;
            }
            value.State = 1;

            Context.Entry(value).State = value.MenuId == 0 ?
                EntityState.Added :
                EntityState.Modified;
            Context.SaveChanges();
        }
    }
}
