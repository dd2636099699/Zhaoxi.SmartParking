using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zhaoxi.SmartParking.Client.Entity;
using Zhaoxi.SmartParking.Client.IBLL;
using Zhaoxi.SmartParking.Client.IDAL;

namespace Zhaoxi.SmartParking.Client.BLL
{
    public class MenuBLL : IMenuBLL
    {
        ILocalDataAccess _localDataAccess;
        IMenuDal _menuDal;
        public MenuBLL(ILocalDataAccess localDataAccess, IMenuDal menuDal)
        {
            _localDataAccess = localDataAccess;
            _menuDal = menuDal;
        }


        public List<string> GetIcons()
        {
            return _localDataAccess.GetIcons();
        }

        public async Task<List<MenuEntity>> GetMenus(int roleId)
        {
            var menus = await _menuDal.GetMenus(roleId);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<MenuEntity>>(menus);
        }

        public async Task<List<MenuEntity>> GetAllMenus()
        {
            var menus = await _menuDal.GetAllMenus();
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<MenuEntity>>(menus);
        }

        public Task SaveMenu(MenuEntity menuEntity)
        {
            return _menuDal.SaveMenu(Newtonsoft.Json.JsonConvert.SerializeObject(menuEntity));
        }

        public Task DeleteMenu(int id)
        {
            return _menuDal.DeleteMenu(id);
        }
    }
}
