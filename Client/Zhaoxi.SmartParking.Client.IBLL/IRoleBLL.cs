using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zhaoxi.SmartParking.Client.Entity;

namespace Zhaoxi.SmartParking.Client.IBLL
{
    public interface IRoleBLL
    {
        Task<List<RoleEntity>> GetAll();
        Task<List<RoleEntity>> GetAllByUserId(int userId);
        Task<List<UserEntity>> GetAllUsers(int roleId);

        Task Save(RoleEntity role, List<int> userIds, List<int> menuIds);
    }
}
