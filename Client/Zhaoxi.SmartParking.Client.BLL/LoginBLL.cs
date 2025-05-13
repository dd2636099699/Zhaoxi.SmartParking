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
    public class LoginBLL : ILoginBLL
    {
        IWebDataAccess _webDataAccess;
        public LoginBLL(IWebDataAccess webDataAccess)
        {
            _webDataAccess = webDataAccess;
        }
        public async Task<bool> Login(string uName, string pwd)
        {
            // 通过DAL进行数据获取
            /// 登录窗口进行用户名 密码的校验
            ///     校验成功：跳转到主窗口
            ///     校验失败：保持当前状态
            ///     有个问题：如果跳转到主窗口，需要用户信息的显示：再取一次
            var userStr = await _webDataAccess.Login(uName, pwd);
            UserEntity userEntity = Newtonsoft.Json.JsonConvert.DeserializeObject<UserEntity>(userStr);
            // 转换成全局用户信息

            if (userEntity != null)
            {
                GlobalEntity.CurrentUserInfo = userEntity;
                return true;
            }
            return false;
        }
    }
}
