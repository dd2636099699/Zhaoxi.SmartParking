using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Zhaoxi.SmartParking.Server.Models
{
    /// <summary>
    /// 车辆信息登录
    /// </summary>
    /// 
    [Table("auto_register")]
    public class AutoRegister
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("auto_id")]
        public int AutoId { get; set; }
        /// <summary>
        /// 车牌号
        /// </summary>
        [Column("auto_license")]
        public string AutoLicense { get; set; }
        /// <summary>
        /// 车牌的颜色
        /// </summary>
        [Column("license_color_id")]
        public int LicenseColorId { get; set; }
        /// <summary>
        /// 车身颜色
        /// </summary>
        [Column("auto_color_id")]
        public int AutoColorId { get; set; }
        /// <summary>
        /// 计费模式（无限、年卡、月卡、次卡）
        /// </summary>
        [Column("fee_mode_id")]
        public int FeeModeId { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Column("description")]
        public string Description { get; set; }

        [Column("state")]
        public int State { get; set; }

        [Column("valid_start_time")]
        public string ValidStartTime { get; set; }
        [Column("valid_end_time")]
        public string ValidEndTime { get; set; }
        [Column("valid_count")]
        public int ValidCount { get; set; }
    }
}
