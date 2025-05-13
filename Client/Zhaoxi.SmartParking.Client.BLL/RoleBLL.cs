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
    public class RoleBLL : IRoleBLL
    {
        IRoleDal _roleDal;
        public RoleBLL(IRoleDal roleDal)
        {
            _roleDal = roleDal;
        }
        public async Task<List<RoleEntity>> GetAll()
        {
            var rolesStr = await _roleDal.GetAll();
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<RoleEntity>>(rolesStr);
        }

        public async Task<List<RoleEntity>> GetAllByUserId(int userId)
        {
            var rolesStr = await _roleDal.GetAllByUserId(userId);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<RoleEntity>>(rolesStr);
        }

        public async Task<List<UserEntity>> GetAllUsers(int roleId)
        {
            var usersStr = await _roleDal.GetAllUsers(roleId);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<UserEntity>>(usersStr);
        }

        public Task Save(RoleEntity role, List<int> userIds, List<int> menuIds)
        {
            return _roleDal.Save(Newtonsoft.Json.JsonConvert.SerializeObject(role),
                Newtonsoft.Json.JsonConvert.SerializeObject(userIds),
                Newtonsoft.Json.JsonConvert.SerializeObject(menuIds)
                );
        }
    }
}
