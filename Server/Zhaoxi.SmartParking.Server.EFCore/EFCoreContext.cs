using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Globalization;
using System.Linq;
using Zhaoxi.SmartParking.Server.Models;

namespace Zhaoxi.SmartParking.Server.EFCore
{
    public class EFCoreContext : DbContext
    {
        private string strConn = string.Empty;

        public EFCoreContext()
        {
            /// 对于数据库结构的更新有用
            /// 正式生产环境需要更新
            strConn = "Server=LAPTOP-7RAV79T8;Database=gzz_sp;Trusted_Connection=True";
            strConn = "Server=LAPTOP-7RAV79T8;Database=gzz_sp;Trusted_Connection=True";
            // sql更新
        }
        public EFCoreContext(string connectionStr)
        {
            strConn = connectionStr;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(strConn);
        }

        /// <summary>
        /// 配置数据库结构，
        /// 关系映射
        /// 索引配置 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 联合主键设置
            modelBuilder.Entity<RoleMenu>().HasKey(pk => new { pk.MenuId, pk.RoleId });
            modelBuilder.Entity<UserRole>().HasKey(pk => new { pk.UserId, pk.RoleId });

            // 文件库中时间转换  string<->timespan
            ValueConverter timeValueConverter = new ValueConverter<string, long>(
                v => (DateTime.ParseExact(v, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture).Ticks - 621355968000000000) / 10000000,
                v => new DateTime(v * 10000000 + 621355968000000000).ToString("yyyy-MM-dd HH:mm:ss"));
            modelBuilder.Entity<UpgradeFile>().Property(p => p.UploadTime).HasConversion(timeValueConverter);

            // 菜单表中字体图标值转换   编号string<->字符string
            ValueConverter iconValueConverter = new ValueConverter<string, string>(
                v => string.IsNullOrEmpty(v) ? null : ((int)v.ToArray()[0]).ToString("x"),
                v => v == null ? "" : ((char)int.Parse(v, NumberStyles.HexNumber)).ToString());
            modelBuilder.Entity<MenuInfo>().Property(p => p.MenuIcon).HasConversion(iconValueConverter);

 //           var simpleTimeValueConverter = new ValueConverter<string, long>(
 //    v => DateTime.Parse(v).ToUniversalTime().Ticks,
 //    v => new DateTime(v).ToString("yyyy-MM-dd HH:mm:ss")
 //);

            // 应用到实体属性
            modelBuilder.Entity<RecordInfo>().Property(p => p.EnterTime).HasConversion(timeValueConverter);
            modelBuilder.Entity<RecordInfo>().Property(p => p.LeaveTime).HasConversion(timeValueConverter);

            //// 出入记录的时间转换
            //modelBuilder.Entity<RecordInfo>().Property(p => p.EnterTime).HasConversion(simpleTimeValueConverter);
            //modelBuilder.Entity<RecordInfo>().Property(p => p.LeaveTime).HasConversion(simpleTimeValueConverter);
            // 定义值转换器（处理字符串 <-> 毫秒时间戳）
            var timeValueConverter1 = new ValueConverter<string, long>(
                v => string.IsNullOrEmpty(v) ? 0 :
                     DateTimeOffset.Parse(v).ToUnixTimeMilliseconds(),
                v => v == 0 ? string.Empty :
                     DateTimeOffset.FromUnixTimeMilliseconds(v).ToString("yyyy-MM-dd HH:mm:ss")
            );

            // 应用到实体属性
            modelBuilder.Entity<RecordInfo>()
                .Property(p => p.EnterTime)
                .HasConversion(timeValueConverter1);

            modelBuilder.Entity<RecordInfo>()
                .Property(p => p.LeaveTime)
                .HasConversion(timeValueConverter1);
        }


        public DbSet<UpgradeFile> UpgradeFile { get; set; }
        public DbSet<SysUserInfo> SysUserInfo { get; set; }
        public DbSet<RoleInfo> RoleInfo { get; set; }
        public DbSet<MenuInfo> MenuInfo { get; set; }
        public DbSet<RoleMenu> RoleMenu { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<AutoColor> AutoColor { get; set; }
        public DbSet<LicenseColor> LicenseColor { get; set; }
        public DbSet<FeeModel> FeeModel { get; set; }
        public DbSet<AutoRegister> AutoRegister { get; set; }
        // 20210315
        public DbSet<RecordInfo> RecordInfo { get; set; }
        public DbSet<BillingInfo> BillingInfo { get; set; }
    }
}
