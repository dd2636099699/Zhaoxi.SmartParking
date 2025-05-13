using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Zhaoxi.SmartParking.Server.Models
{
    [Table("menus")]
    public class MenuInfo
    {
        [Key]
        [Column("menu_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MenuId { get; set; }
        [Column("menu_header")]
        public string MenuHeader { get; set; }
        [Column("target_view")]
        public string TargetView { get; set; }
        [Column("parent_id")]
        public int ParentId { get; set; }
        [Column("menu_icon", TypeName = "nvarchar(4)")]
        public string MenuIcon { get; set; }
        [Column("index")]
        public int Index { get; set; }
        [Column("menu_type")]
        public int MenuType { get; set; }
        [Column("state")]
        [DefaultValue(1)]
        public int State { get; set; }
    }
}
