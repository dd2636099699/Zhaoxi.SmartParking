using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Zhaoxi.SmartParking.Server.Models
{
    [Table("record_info")]
    public class RecordInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("record_id")]
        public int RecordId { get; set; }
        [Column("auto_license")]
        public string AutoLicense { get; set; }
        [Column("enter_time", TypeName = "bigint")]
        public string EnterTime { get; set; }

        [Column("leave_time", TypeName = "bigint")]
        public string LeaveTime { get; set; }
        [Column("cost")]
        public double Cost { get; set; }
        [Column("order_id")]
        public long OrderId { get; set; }
        [Column("fee_mode_id")]
        public int FeeModelId { get; set; } = 0;
        [Column("state")]
        public int State { get; set; } = 0;

        // 生成另一条记录
        // 这种情况允许出现：
    }
}
