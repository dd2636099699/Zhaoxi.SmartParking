using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Zhaoxi.SmartParking.Client.IDAL;

namespace Zhaoxi.SmartParking.Client.DAL
{
    public class UserDal : WebDataAccess, IUserDal
    {
        public Task ChangeState(int userId, int state)
        {
            //  什么时候用Post  什么时候用Get     WebApi的开发人员去思考
            Dictionary<string, HttpContent> param = new Dictionary<string, HttpContent>();
            param.Add("userId", new StringContent(userId.ToString()));
            param.Add("state", new StringContent(state.ToString()));

            return this.PostDatas($"{domain}user/state", this.GetFormData(param));
        }

        public Task<string> GetAll()
        {
            return this.GetDatas($"{domain}user/all");
        }

        public Task ResetPassword(int userId)
        {
            Dictionary<string, HttpContent> param = new Dictionary<string, HttpContent>();
            param.Add("userId", new StringContent(userId.ToString()));

            return this.PostDatas($"{domain}user/resetpwd", this.GetFormData(param));
        }

        public Task SaveUser(string data)
        {
            StringContent content = new StringContent(data);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            return this.PostDatas($"{domain}user/save", content);
        }

        public Task UpdateRoles(int userId, string roles)
        {
            Dictionary<string, HttpContent> param = new Dictionary<string, HttpContent>();
            param.Add("userId", new StringContent(userId.ToString()));
            param.Add("roles", new StringContent(roles));

            return this.PostDatas($"{domain}user/roles", this.GetFormData(param));
        }
    }
}
