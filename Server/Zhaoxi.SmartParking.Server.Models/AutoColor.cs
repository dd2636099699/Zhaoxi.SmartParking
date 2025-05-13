using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Zhaoxi.SmartParking.Server.Models
{
    /// <summary>
    /// 车辆颜色
    /// </summary>
    [Table("base_auto_color")]
    public class AutoColor
    {
        [Key]
        [Column("color_id")]
        public int ColorId { get; set; }
        [Column("color_name")]
        public string ColorName { get; set; }
    }
}
