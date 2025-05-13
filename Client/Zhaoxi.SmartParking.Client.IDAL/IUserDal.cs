using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhaoxi.SmartParking.Client.IDAL
{
    public interface IUserDal
    {
        // 获取所有有效的用户信息
        Task<string> GetAll();
        //修改状态
        Task ChangeState(int userId, int state);
        // 修改用户信息
        Task SaveUser(string data);
        // 重置密码
        Task ResetPassword(int userId);
        // 更新用户角色
        Task UpdateRoles(int userId, string roles);
    }
}
