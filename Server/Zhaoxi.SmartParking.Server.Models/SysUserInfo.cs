using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Zhaoxi.SmartParking.Server.Models
{
    [Table("sys_user_info")]
    public class SysUserInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(name: "user_id")]
        public int UserId { get; set; }
        [Column(name: "user_name")]
        public string UserName { get; set; }
        [Column(name: "password")]
        public string Password { get; set; }
        [Column(name: "user_icon")]
        public string UserIcon { get; set; }
        [Column("real_name")]
        public string RealName { get; set; }
        [Column(name: "age")]
        public int Age { get; set; }

        [DefaultValue(1)]
        public int state { get; set; }

        [NotMapped]
        public List<MenuInfo> Menus { get; set; }
    }
}
