using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Zhaoxi.SmartParking.Server.Models
{
    [Table("billing_info")]
    public class BillingInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("billing_id")]
        public int BillingId { get; set; }

        [Column("start_time")]
        public string StartTime { get; set; }
        [Column("end_time")]
        public string EndTime { get; set; }

        [Column("billing_rate")]
        public double BillingRate { get; set; }//计费频率
        [Column("amount_money")]
        public double AmountMoney { get; set; }//每频率的费用
    }
}
