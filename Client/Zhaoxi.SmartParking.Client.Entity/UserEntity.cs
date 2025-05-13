using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhaoxi.SmartParking.Client.Entity
{
    public class UserEntity
    {
        public int UserId { get; set; }// 自增字段
        public string UserName { get; set; } // 自定义一个用户名、唯一性
        public string Password { get; set; }
        public string RealName { get; set; }
        public string UserIcon { get; set; }
        public int Age { get; set; }

        public List<MenuEntity> Menus { get; set; }
    }
}
