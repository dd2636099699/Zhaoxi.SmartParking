using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Zhaoxi.SmartParking.Server.Models
{
    [Table("role_menu")]
    public class RoleMenu
    {
        [Column("role_id")]
        public int RoleId { get; set; }
        [Column("menu_id")]
        public int MenuId { get; set; }
    }
}
