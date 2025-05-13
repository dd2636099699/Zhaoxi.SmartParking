using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Zhaoxi.SmartParking.Client.IDAL;

namespace Zhaoxi.SmartParking.Client.DAL
{
    public class RoleDal : WebDataAccess, IRoleDal
    {
        public Task<string> GetAll()
        {
            return this.GetDatas($"{domain}role/all");
        }

        public Task<string> GetAllByUserId(int userId)
        {
            return this.GetDatas($"{domain}role/all/{userId}");
        }

        public Task<string> GetAllUsers(int roleId)
        {
            return this.GetDatas($"{domain}role/all_users/{roleId}");
        }

        public Task Save(string role, string users, string menus)
        {
            Dictionary<string, HttpContent> param = new Dictionary<string, HttpContent>();
            param.Add("role", new StringContent(role));
            param.Add("users", new StringContent(users));
            param.Add("menus", new StringContent(menus));

            return this.PostDatas($"{domain}role/save", this.GetFormData(param));
        }
    }
}
