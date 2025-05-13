using System;
using System.Collections.Generic;
using System.Text;
using Zhaoxi.SmartParking.Server.Models;

namespace Zhaoxi.SmartParking.Server.IService
{
    public interface IMenuService : IBaseService
    {
        List<MenuInfo> GetMenusByUserId(int roleId);
        // 角色编辑的时候用到
        List<MenuInfo> GetMenusByRoleId(int roleId);
        List<MenuInfo> GetAllMenus();

        // 包含新增和修改
        void SaveMenu(string data);
    }
}
