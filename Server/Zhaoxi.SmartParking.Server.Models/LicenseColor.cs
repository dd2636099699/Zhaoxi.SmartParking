using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Zhaoxi.SmartParking.Server.Models
{
    /// <summary>
    /// 车牌颜色
    /// </summary>
    [Table("base_license_color")]
    public class LicenseColor
    {
        [Key]
        [Column("color_id")]
        public int ColorId { get; set; }
        [Column("color_name")]
        public string ColorName { get; set; }
    }
}
