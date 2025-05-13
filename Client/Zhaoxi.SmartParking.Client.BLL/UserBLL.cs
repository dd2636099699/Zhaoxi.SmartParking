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
    public class UserBLL : IUserBLL
    {
        IUserDal _userDal;
        public UserBLL(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public Task ChangeState(int userId, int state)
        {
            return _userDal.ChangeState(userId, state);
        }

        public async Task<List<UserEntity>> GetAll()
        {
            var usersStr = await _userDal.GetAll();
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<UserEntity>>(usersStr);
        }


        public Task SaveUser(UserEntity userEntity)
        {
            return _userDal.SaveUser(Newtonsoft.Json.JsonConvert.SerializeObject(userEntity));
        }

        public Task ResetPassword(int userId)
        {
            return _userDal.ResetPassword(userId);
        }

        public Task UpdateRoles(int userId, List<int> roles)
        {
            return _userDal.UpdateRoles(userId, Newtonsoft.Json.JsonConvert.SerializeObject(roles));
        }
    }
}
