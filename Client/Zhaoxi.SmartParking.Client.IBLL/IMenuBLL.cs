using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zhaoxi.SmartParking.Client.Entity;

namespace Zhaoxi.SmartParking.Client.IBLL
{
    public interface IMenuBLL
    {
        List<string> GetIcons();
        Task<List<MenuEntity>> GetMenus(int roleId);
        Task<List<MenuEntity>> GetAllMenus();
        Task SaveMenu(MenuEntity menuEntity);
        Task DeleteMenu(int id);
    }
}
