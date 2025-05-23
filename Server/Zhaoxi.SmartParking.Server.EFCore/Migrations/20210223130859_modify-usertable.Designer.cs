﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Zhaoxi.SmartParking.Server.EFCore;

namespace Zhaoxi.SmartParking.Server.EFCore.Migrations
{
    [DbContext(typeof(EFCoreContext))]
    [Migration("20210223130859_modify-usertable")]
    partial class modifyusertable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Zhaoxi.SmartParking.Server.Models.MenuInfo", b =>
                {
                    b.Property<int>("MenuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("menu_id")
                        .UseIdentityColumn();

                    b.Property<int>("Index")
                        .HasColumnType("int")
                        .HasColumnName("index");

                    b.Property<string>("MenuHeader")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("menu_header");

                    b.Property<string>("MenuIcon")
                        .HasColumnType("nvarchar(4)")
                        .HasColumnName("menu_icon");

                    b.Property<int>("MenuType")
                        .HasColumnType("int")
                        .HasColumnName("menu_type");

                    b.Property<int>("ParentId")
                        .HasColumnType("int")
                        .HasColumnName("parent_id");

                    b.Property<int>("State")
                        .HasColumnType("int")
                        .HasColumnName("state");

                    b.Property<string>("TargetView")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("target_view");

                    b.HasKey("MenuId");

                    b.ToTable("menus");
                });

            modelBuilder.Entity("Zhaoxi.SmartParking.Server.Models.RoleInfo", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("role_id")
                        .UseIdentityColumn();

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("role_name");

                    b.Property<int>("state")
                        .HasColumnType("int");

                    b.HasKey("RoleId");

                    b.ToTable("roles");
                });

            modelBuilder.Entity("Zhaoxi.SmartParking.Server.Models.RoleMenu", b =>
                {
                    b.Property<int>("MenuId")
                        .HasColumnType("int")
                        .HasColumnName("menu_id");

                    b.Property<int>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("role_id");

                    b.HasKey("MenuId", "RoleId");

                    b.ToTable("role_menu");
                });

            modelBuilder.Entity("Zhaoxi.SmartParking.Server.Models.SysUserInfo", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("user_id")
                        .UseIdentityColumn();

                    b.Property<int>("Age")
                        .HasColumnType("int")
                        .HasColumnName("age");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("password");

                    b.Property<string>("RealName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("real_name");

                    b.Property<string>("UserIcon")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("user_icon");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("user_name");

                    b.Property<int>("state")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.ToTable("sys_user_info");
                });

            modelBuilder.Entity("Zhaoxi.SmartParking.Server.Models.UpgradeFile", b =>
                {
                    b.Property<int>("FileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("file_id")
                        .UseIdentityColumn();

                    b.Property<string>("FileMd5")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("file_md5");

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("file_name");

                    b.Property<string>("FilePath")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("file_path");

                    b.Property<long?>("UploadTime")
                        .HasColumnType("bigint")
                        .HasColumnName("upload_time");

                    b.Property<int>("state")
                        .HasColumnType("int")
                        .HasColumnName("state");

                    b.HasKey("FileId");

                    b.ToTable("upgrade_file");
                });

            modelBuilder.Entity("Zhaoxi.SmartParking.Server.Models.UserRole", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.Property<int>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("role_id");

                    b.HasKey("UserId", "RoleId");

                    b.ToTable("user_role");
                });
#pragma warning restore 612, 618
        }
    }
}
