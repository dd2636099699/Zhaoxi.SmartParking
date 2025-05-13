using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Zhaoxi.SmartParking.Client.IDAL;

namespace Zhaoxi.SmartParking.Client.DAL
{
    public class MenuDal : WebDataAccess, IMenuDal
    {
        public Task<string> GetMenus(int roleId)
        {
            return this.GetDatas($"{domain}menu/list?roleid={roleId}");
        }

        public Task<string> GetAllMenus()
        {
            return this.GetDatas($"{domain}menu/all");
        }

        public Task SaveMenu(string data)
        {
            StringContent content = new StringContent(data);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            return this.PostDatas($"{domain}menu/save", content);
        }

        public Task DeleteMenu(int menuId)
        {
            Dictionary<string, HttpContent> values = new Dictionary<string, HttpContent>();
            values.Add("menuId", new StringContent(menuId.ToString()));
            return this.PostDatas($"{domain}menu/del", this.GetFormData(values));
        }
    }
}
