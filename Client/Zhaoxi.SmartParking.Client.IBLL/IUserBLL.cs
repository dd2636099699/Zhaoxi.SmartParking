using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zhaoxi.SmartParking.Client.Entity;

namespace Zhaoxi.SmartParking.Client.IBLL
{
    public interface IUserBLL
    {
        Task<List<UserEntity>> GetAll();

        Task ChangeState(int userId, int state);
        Task SaveUser(UserEntity userEntity);
        Task ResetPassword(int userId);
        Task UpdateRoles(int userId, List<int> roles);
    }
}
