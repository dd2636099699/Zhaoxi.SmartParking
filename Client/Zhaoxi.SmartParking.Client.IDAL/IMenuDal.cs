using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhaoxi.SmartParking.Client.IDAL
{
    public interface IMenuDal
    {
        Task<string> GetMenus(int roleId);
        Task<string> GetAllMenus();
        Task SaveMenu(string data);
        Task DeleteMenu(int menuId);
    }
}
