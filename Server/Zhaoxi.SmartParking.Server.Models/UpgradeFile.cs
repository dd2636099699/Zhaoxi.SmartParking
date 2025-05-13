using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zhaoxi.SmartParking.Server.Models
{
    [Table("upgrade_file")]
    public class UpgradeFile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("file_id")]
        public int FileId { get; set; }
        [Column("file_name")]
        public string FileName { get; set; }
        [Column("file_md5")]
        public string FileMd5 { get; set; }
        [Column("file_path")]
        public string FilePath { get; set; }
        [Column("upload_time", TypeName = "bigint")]
        public string UploadTime { get; set; }
        [Column("state")]
        public int state { get; set; }
    }
}
