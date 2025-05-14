/*
 Navicat Premium Data Transfer

 Source Server         : sqlserver
 Source Server Type    : SQL Server
 Source Server Version : 16001000
 Source Host           : LAPTOP-7RAV79T8:1433
 Source Catalog        : gzz_sp
 Source Schema         : dbo

 Target Server Type    : SQL Server
 Target Server Version : 16001000
 File Encoding         : 65001

 Date: 13/05/2025 17:26:10
*/


-- ----------------------------
-- Table structure for __EFMigrationsHistory
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[__EFMigrationsHistory]') AND type IN ('U'))
	DROP TABLE [dbo].[__EFMigrationsHistory]
GO

CREATE TABLE [dbo].[__EFMigrationsHistory] (
  [MigrationId] nvarchar(150) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [ProductVersion] nvarchar(32) COLLATE Chinese_PRC_CI_AS  NOT NULL
)
GO

ALTER TABLE [dbo].[__EFMigrationsHistory] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of __EFMigrationsHistory
-- ----------------------------
INSERT INTO [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210220123424_add-1', N'5.0.2')
GO

INSERT INTO [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210223130859_modify-usertable', N'5.0.2')
GO

INSERT INTO [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210302130104_a01', N'5.0.2')
GO

INSERT INTO [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210302132444_a02', N'5.0.2')
GO

INSERT INTO [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210315125138_a03', N'5.0.2')
GO

INSERT INTO [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210315130343_a04', N'5.0.2')
GO

INSERT INTO [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250328121507_add-1', N'5.0.2')
GO

INSERT INTO [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250507035859_test', N'5.0.2')
GO


-- ----------------------------
-- Table structure for auto_register
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[auto_register]') AND type IN ('U'))
	DROP TABLE [dbo].[auto_register]
GO

CREATE TABLE [dbo].[auto_register] (
  [auto_id] int  IDENTITY(1,1) NOT NULL,
  [auto_license] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [license_color_id] int  NOT NULL,
  [auto_color_id] int  NOT NULL,
  [fee_mode_id] int  NOT NULL,
  [description] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [state] int  NOT NULL,
  [valid_count] int DEFAULT 0 NOT NULL,
  [valid_end_time] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [valid_start_time] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[auto_register] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of auto_register
-- ----------------------------
SET IDENTITY_INSERT [dbo].[auto_register] ON
GO

INSERT INTO [dbo].[auto_register] ([auto_id], [auto_license], [license_color_id], [auto_color_id], [fee_mode_id], [description], [state], [valid_count], [valid_end_time], [valid_start_time]) VALUES (N'1', N'苏E05EV8', N'1', N'1', N'1', N'test', N'1', N'1', NULL, NULL)
GO

INSERT INTO [dbo].[auto_register] ([auto_id], [auto_license], [license_color_id], [auto_color_id], [fee_mode_id], [description], [state], [valid_count], [valid_end_time], [valid_start_time]) VALUES (N'2', N'2', N'2', N'3', N'1', N'描述信息1', N'1', N'10', N'2025-06-11 16:27:12', N'2025-05-12 16:27:12')
GO

INSERT INTO [dbo].[auto_register] ([auto_id], [auto_license], [license_color_id], [auto_color_id], [fee_mode_id], [description], [state], [valid_count], [valid_end_time], [valid_start_time]) VALUES (N'3', N'3', N'2', N'2', N'1', N'描述信息2', N'1', N'10', N'2025-06-11 16:27:12', N'2025-05-12 16:27:12')
GO

INSERT INTO [dbo].[auto_register] ([auto_id], [auto_license], [license_color_id], [auto_color_id], [fee_mode_id], [description], [state], [valid_count], [valid_end_time], [valid_start_time]) VALUES (N'4', N'4', N'2', N'5', N'1', N'描述信息3', N'1', N'10', N'2025-06-11 16:27:12', N'2025-05-12 16:27:12')
GO

INSERT INTO [dbo].[auto_register] ([auto_id], [auto_license], [license_color_id], [auto_color_id], [fee_mode_id], [description], [state], [valid_count], [valid_end_time], [valid_start_time]) VALUES (N'5', N'5', N'1', N'3', N'1', N'描述信息4', N'1', N'10', N'2025-06-11 16:27:12', N'2025-05-12 16:27:12')
GO

INSERT INTO [dbo].[auto_register] ([auto_id], [auto_license], [license_color_id], [auto_color_id], [fee_mode_id], [description], [state], [valid_count], [valid_end_time], [valid_start_time]) VALUES (N'6', N'6', N'2', N'3', N'1', N'描述信息5', N'1', N'10', N'2025-06-11 16:27:12', N'2025-05-12 16:27:12')
GO

INSERT INTO [dbo].[auto_register] ([auto_id], [auto_license], [license_color_id], [auto_color_id], [fee_mode_id], [description], [state], [valid_count], [valid_end_time], [valid_start_time]) VALUES (N'7', N'7', N'1', N'5', N'1', N'描述信息6', N'1', N'10', N'2025-06-11 16:27:12', N'2025-05-12 16:27:12')
GO

INSERT INTO [dbo].[auto_register] ([auto_id], [auto_license], [license_color_id], [auto_color_id], [fee_mode_id], [description], [state], [valid_count], [valid_end_time], [valid_start_time]) VALUES (N'8', N'8', N'2', N'4', N'1', N'描述信息7', N'1', N'10', N'2025-06-11 16:27:12', N'2025-05-12 16:27:12')
GO

INSERT INTO [dbo].[auto_register] ([auto_id], [auto_license], [license_color_id], [auto_color_id], [fee_mode_id], [description], [state], [valid_count], [valid_end_time], [valid_start_time]) VALUES (N'9', N'9', N'1', N'3', N'1', N'描述信息8', N'1', N'10', N'2025-06-11 16:27:12', N'2025-05-12 16:27:12')
GO

INSERT INTO [dbo].[auto_register] ([auto_id], [auto_license], [license_color_id], [auto_color_id], [fee_mode_id], [description], [state], [valid_count], [valid_end_time], [valid_start_time]) VALUES (N'10', N'10', N'2', N'5', N'1', N'描述信息9', N'1', N'10', N'2025-06-11 16:27:12', N'2025-05-12 16:27:12')
GO

INSERT INTO [dbo].[auto_register] ([auto_id], [auto_license], [license_color_id], [auto_color_id], [fee_mode_id], [description], [state], [valid_count], [valid_end_time], [valid_start_time]) VALUES (N'11', N'11', N'1', N'3', N'1', N'描述信息10', N'1', N'10', N'2025-06-11 16:27:12', N'2025-05-12 16:27:12')
GO

SET IDENTITY_INSERT [dbo].[auto_register] OFF
GO


-- ----------------------------
-- Table structure for base_auto_color
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[base_auto_color]') AND type IN ('U'))
	DROP TABLE [dbo].[base_auto_color]
GO

CREATE TABLE [dbo].[base_auto_color] (
  [color_id] int  IDENTITY(1,1) NOT NULL,
  [color_name] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[base_auto_color] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of base_auto_color
-- ----------------------------
SET IDENTITY_INSERT [dbo].[base_auto_color] ON
GO

INSERT INTO [dbo].[base_auto_color] ([color_id], [color_name]) VALUES (N'1', N'红')
GO

INSERT INTO [dbo].[base_auto_color] ([color_id], [color_name]) VALUES (N'2', N'橙')
GO

INSERT INTO [dbo].[base_auto_color] ([color_id], [color_name]) VALUES (N'3', N'黄')
GO

INSERT INTO [dbo].[base_auto_color] ([color_id], [color_name]) VALUES (N'4', N'绿')
GO

INSERT INTO [dbo].[base_auto_color] ([color_id], [color_name]) VALUES (N'5', N'蓝')
GO

SET IDENTITY_INSERT [dbo].[base_auto_color] OFF
GO


-- ----------------------------
-- Table structure for base_fee_model
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[base_fee_model]') AND type IN ('U'))
	DROP TABLE [dbo].[base_fee_model]
GO

CREATE TABLE [dbo].[base_fee_model] (
  [fee_model_id] int  IDENTITY(1,1) NOT NULL,
  [fee_model_name] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[base_fee_model] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of base_fee_model
-- ----------------------------
SET IDENTITY_INSERT [dbo].[base_fee_model] ON
GO

INSERT INTO [dbo].[base_fee_model] ([fee_model_id], [fee_model_name]) VALUES (N'1', N'年')
GO

INSERT INTO [dbo].[base_fee_model] ([fee_model_id], [fee_model_name]) VALUES (N'2', N'月')
GO

INSERT INTO [dbo].[base_fee_model] ([fee_model_id], [fee_model_name]) VALUES (N'3', N'日')
GO

INSERT INTO [dbo].[base_fee_model] ([fee_model_id], [fee_model_name]) VALUES (N'4', N'次')
GO

SET IDENTITY_INSERT [dbo].[base_fee_model] OFF
GO


-- ----------------------------
-- Table structure for base_license_color
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[base_license_color]') AND type IN ('U'))
	DROP TABLE [dbo].[base_license_color]
GO

CREATE TABLE [dbo].[base_license_color] (
  [color_id] int  IDENTITY(1,1) NOT NULL,
  [color_name] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[base_license_color] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of base_license_color
-- ----------------------------
SET IDENTITY_INSERT [dbo].[base_license_color] ON
GO

INSERT INTO [dbo].[base_license_color] ([color_id], [color_name]) VALUES (N'1', N'绿')
GO

INSERT INTO [dbo].[base_license_color] ([color_id], [color_name]) VALUES (N'2', N'蓝')
GO

SET IDENTITY_INSERT [dbo].[base_license_color] OFF
GO


-- ----------------------------
-- Table structure for billing_info
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[billing_info]') AND type IN ('U'))
	DROP TABLE [dbo].[billing_info]
GO

CREATE TABLE [dbo].[billing_info] (
  [billing_id] int  IDENTITY(1,1) NOT NULL,
  [start_time] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [end_time] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [billing_rate] float(53)  NOT NULL,
  [amount_money] float(53)  NOT NULL
)
GO

ALTER TABLE [dbo].[billing_info] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of billing_info
-- ----------------------------
SET IDENTITY_INSERT [dbo].[billing_info] ON
GO

SET IDENTITY_INSERT [dbo].[billing_info] OFF
GO


-- ----------------------------
-- Table structure for menus
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[menus]') AND type IN ('U'))
	DROP TABLE [dbo].[menus]
GO

CREATE TABLE [dbo].[menus] (
  [menu_id] int  IDENTITY(1,1) NOT NULL,
  [menu_header] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [target_view] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [parent_id] int  NOT NULL,
  [menu_icon] nvarchar(4) COLLATE Chinese_PRC_CI_AS  NULL,
  [index] int  NOT NULL,
  [menu_type] int  NOT NULL,
  [state] int  NOT NULL
)
GO

ALTER TABLE [dbo].[menus] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of menus
-- ----------------------------
SET IDENTITY_INSERT [dbo].[menus] ON
GO

INSERT INTO [dbo].[menus] ([menu_id], [menu_header], [target_view], [parent_id], [menu_icon], [index], [menu_type], [state]) VALUES (N'14', N'系统维护', NULL, N'0', N'e618', N'1', N'1', N'1')
GO

INSERT INTO [dbo].[menus] ([menu_id], [menu_header], [target_view], [parent_id], [menu_icon], [index], [menu_type], [state]) VALUES (N'15', N'菜单管理', N'MenuManagementView', N'14', NULL, N'0', N'0', N'1')
GO

INSERT INTO [dbo].[menus] ([menu_id], [menu_header], [target_view], [parent_id], [menu_icon], [index], [menu_type], [state]) VALUES (N'16', N'升级文件上传', N'FileUploadView', N'14', NULL, N'2', N'0', N'1')
GO

INSERT INTO [dbo].[menus] ([menu_id], [menu_header], [target_view], [parent_id], [menu_icon], [index], [menu_type], [state]) VALUES (N'17', N'基础信息管理', NULL, N'0', N'e6b8', N'2', N'1', N'1')
GO

INSERT INTO [dbo].[menus] ([menu_id], [menu_header], [target_view], [parent_id], [menu_icon], [index], [menu_type], [state]) VALUES (N'18', N'系统用户', N'UserManagementView', N'17', NULL, N'1', N'0', N'1')
GO

INSERT INTO [dbo].[menus] ([menu_id], [menu_header], [target_view], [parent_id], [menu_icon], [index], [menu_type], [state]) VALUES (N'19', N'用户角色', N'RoleManagementView', N'17', NULL, N'2', N'0', N'1')
GO

INSERT INTO [dbo].[menus] ([menu_id], [menu_header], [target_view], [parent_id], [menu_icon], [index], [menu_type], [state]) VALUES (N'20', N'一级菜单', NULL, N'0', N'e600', N'3', N'1', N'1')
GO

INSERT INTO [dbo].[menus] ([menu_id], [menu_header], [target_view], [parent_id], [menu_icon], [index], [menu_type], [state]) VALUES (N'21', N'二级菜单', NULL, N'20', NULL, N'1', N'1', N'1')
GO

INSERT INTO [dbo].[menus] ([menu_id], [menu_header], [target_view], [parent_id], [menu_icon], [index], [menu_type], [state]) VALUES (N'22', N'三级菜单', NULL, N'21', NULL, N'1', N'1', N'1')
GO

INSERT INTO [dbo].[menus] ([menu_id], [menu_header], [target_view], [parent_id], [menu_icon], [index], [menu_type], [state]) VALUES (N'23', N'四级菜单', NULL, N'22', NULL, N'1', N'0', N'1')
GO

INSERT INTO [dbo].[menus] ([menu_id], [menu_header], [target_view], [parent_id], [menu_icon], [index], [menu_type], [state]) VALUES (N'1015', N'车辆管理', N'AutoRegisterView', N'17', NULL, N'4', N'0', N'1')
GO

INSERT INTO [dbo].[menus] ([menu_id], [menu_header], [target_view], [parent_id], [menu_icon], [index], [menu_type], [state]) VALUES (N'1016', N'数据报表', N'ReportView', N'17', NULL, N'5', N'0', N'1')
GO

SET IDENTITY_INSERT [dbo].[menus] OFF
GO


-- ----------------------------
-- Table structure for record_info
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[record_info]') AND type IN ('U'))
	DROP TABLE [dbo].[record_info]
GO

CREATE TABLE [dbo].[record_info] (
  [record_id] int  IDENTITY(1,1) NOT NULL,
  [auto_license] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [enter_time] bigint  NULL,
  [leave_time] bigint  NULL,
  [cost] float(53)  NOT NULL,
  [order_id] bigint  NOT NULL,
  [fee_mode_id] int  NOT NULL,
  [state] int  NOT NULL
)
GO

ALTER TABLE [dbo].[record_info] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of record_info
-- ----------------------------
SET IDENTITY_INSERT [dbo].[record_info] ON
GO

INSERT INTO [dbo].[record_info] ([record_id], [auto_license], [enter_time], [leave_time], [cost], [order_id], [fee_mode_id], [state]) VALUES (N'1', N'浙A00001', N'1747070814776', N'1747070814776', N'10.5', N'100', N'1', N'1')
GO

INSERT INTO [dbo].[record_info] ([record_id], [auto_license], [enter_time], [leave_time], [cost], [order_id], [fee_mode_id], [state]) VALUES (N'2', N'浙A00002', N'1747070814800', N'1747070814800', N'21', N'200', N'2', N'1')
GO

INSERT INTO [dbo].[record_info] ([record_id], [auto_license], [enter_time], [leave_time], [cost], [order_id], [fee_mode_id], [state]) VALUES (N'3', N'浙A00003', N'1747070814800', N'1747070814800', N'31.5', N'300', N'3', N'1')
GO

INSERT INTO [dbo].[record_info] ([record_id], [auto_license], [enter_time], [leave_time], [cost], [order_id], [fee_mode_id], [state]) VALUES (N'4', N'浙A00004', N'1747070814803', N'1747070814803', N'42', N'400', N'4', N'1')
GO

INSERT INTO [dbo].[record_info] ([record_id], [auto_license], [enter_time], [leave_time], [cost], [order_id], [fee_mode_id], [state]) VALUES (N'5', N'浙A00005', N'1747070814803', N'1747070814803', N'52.5', N'500', N'2', N'1')
GO

INSERT INTO [dbo].[record_info] ([record_id], [auto_license], [enter_time], [leave_time], [cost], [order_id], [fee_mode_id], [state]) VALUES (N'6', N'浙A00006', N'1747070814803', N'1747070814803', N'63', N'600', N'3', N'1')
GO

INSERT INTO [dbo].[record_info] ([record_id], [auto_license], [enter_time], [leave_time], [cost], [order_id], [fee_mode_id], [state]) VALUES (N'7', N'浙A00007', N'1747070814806', N'1747070814806', N'73.5', N'700', N'4', N'1')
GO

INSERT INTO [dbo].[record_info] ([record_id], [auto_license], [enter_time], [leave_time], [cost], [order_id], [fee_mode_id], [state]) VALUES (N'8', N'浙A00008', N'1747070814806', N'1747070814806', N'84', N'800', N'2', N'1')
GO

INSERT INTO [dbo].[record_info] ([record_id], [auto_license], [enter_time], [leave_time], [cost], [order_id], [fee_mode_id], [state]) VALUES (N'9', N'浙A00009', N'1747070814806', N'1747070814806', N'94.5', N'900', N'1', N'1')
GO

INSERT INTO [dbo].[record_info] ([record_id], [auto_license], [enter_time], [leave_time], [cost], [order_id], [fee_mode_id], [state]) VALUES (N'10', N'浙A00010', N'1747070814810', N'1747070814810', N'105', N'1000', N'2', N'1')
GO

SET IDENTITY_INSERT [dbo].[record_info] OFF
GO


-- ----------------------------
-- Table structure for role_menu
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[role_menu]') AND type IN ('U'))
	DROP TABLE [dbo].[role_menu]
GO

CREATE TABLE [dbo].[role_menu] (
  [role_id] int  NOT NULL,
  [menu_id] int  NOT NULL
)
GO

ALTER TABLE [dbo].[role_menu] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of role_menu
-- ----------------------------
INSERT INTO [dbo].[role_menu] ([role_id], [menu_id]) VALUES (N'1', N'14')
GO

INSERT INTO [dbo].[role_menu] ([role_id], [menu_id]) VALUES (N'1', N'15')
GO

INSERT INTO [dbo].[role_menu] ([role_id], [menu_id]) VALUES (N'1', N'16')
GO

INSERT INTO [dbo].[role_menu] ([role_id], [menu_id]) VALUES (N'1', N'17')
GO

INSERT INTO [dbo].[role_menu] ([role_id], [menu_id]) VALUES (N'1', N'18')
GO

INSERT INTO [dbo].[role_menu] ([role_id], [menu_id]) VALUES (N'1', N'19')
GO

INSERT INTO [dbo].[role_menu] ([role_id], [menu_id]) VALUES (N'1', N'20')
GO

INSERT INTO [dbo].[role_menu] ([role_id], [menu_id]) VALUES (N'1', N'21')
GO

INSERT INTO [dbo].[role_menu] ([role_id], [menu_id]) VALUES (N'1', N'22')
GO

INSERT INTO [dbo].[role_menu] ([role_id], [menu_id]) VALUES (N'1', N'23')
GO

INSERT INTO [dbo].[role_menu] ([role_id], [menu_id]) VALUES (N'1', N'1015')
GO

INSERT INTO [dbo].[role_menu] ([role_id], [menu_id]) VALUES (N'1', N'1016')
GO


-- ----------------------------
-- Table structure for roles
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[roles]') AND type IN ('U'))
	DROP TABLE [dbo].[roles]
GO

CREATE TABLE [dbo].[roles] (
  [role_id] int  IDENTITY(1,1) NOT NULL,
  [role_name] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [state] int  NOT NULL
)
GO

ALTER TABLE [dbo].[roles] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of roles
-- ----------------------------
SET IDENTITY_INSERT [dbo].[roles] ON
GO

INSERT INTO [dbo].[roles] ([role_id], [role_name], [state]) VALUES (N'1', N'超级管理员', N'1')
GO

SET IDENTITY_INSERT [dbo].[roles] OFF
GO


-- ----------------------------
-- Table structure for sys_user_info
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[sys_user_info]') AND type IN ('U'))
	DROP TABLE [dbo].[sys_user_info]
GO

CREATE TABLE [dbo].[sys_user_info] (
  [user_id] int  IDENTITY(1,1) NOT NULL,
  [user_name] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [password] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [user_icon] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [age] int  NOT NULL,
  [real_name] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [state] int DEFAULT 0 NOT NULL
)
GO

ALTER TABLE [dbo].[sys_user_info] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of sys_user_info
-- ----------------------------
SET IDENTITY_INSERT [dbo].[sys_user_info] ON
GO

INSERT INTO [dbo].[sys_user_info] ([user_id], [user_name], [password], [user_icon], [age], [real_name], [state]) VALUES (N'1', N'admin', N'ABFB5D41B5DCCF7B34A90F32EC475E77', N'1', N'1', NULL, N'0')
GO

INSERT INTO [dbo].[sys_user_info] ([user_id], [user_name], [password], [user_icon], [age], [real_name], [state]) VALUES (N'1001', N'2', N'BBD80DA2D0B25FA0F809086D0AB5B7EB', N'image/show/temp.jpg', N'2', N'2', N'1')
GO

INSERT INTO [dbo].[sys_user_info] ([user_id], [user_name], [password], [user_icon], [age], [real_name], [state]) VALUES (N'1002', N'3', N'A67E6054583F1827DC6F4BF261C758AC', N'image/show/temp.jpg', N'3', N'3', N'1')
GO

SET IDENTITY_INSERT [dbo].[sys_user_info] OFF
GO


-- ----------------------------
-- Table structure for upgrade_file
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[upgrade_file]') AND type IN ('U'))
	DROP TABLE [dbo].[upgrade_file]
GO

CREATE TABLE [dbo].[upgrade_file] (
  [file_id] int  IDENTITY(1,1) NOT NULL,
  [file_name] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [file_md5] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [file_path] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL,
  [upload_time] bigint  NULL,
  [state] int  NOT NULL
)
GO

ALTER TABLE [dbo].[upgrade_file] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of upgrade_file
-- ----------------------------
SET IDENTITY_INSERT [dbo].[upgrade_file] ON
GO

SET IDENTITY_INSERT [dbo].[upgrade_file] OFF
GO


-- ----------------------------
-- Table structure for user_role
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[user_role]') AND type IN ('U'))
	DROP TABLE [dbo].[user_role]
GO

CREATE TABLE [dbo].[user_role] (
  [user_id] int  NOT NULL,
  [role_id] int  NOT NULL
)
GO

ALTER TABLE [dbo].[user_role] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of user_role
-- ----------------------------
INSERT INTO [dbo].[user_role] ([user_id], [role_id]) VALUES (N'1', N'1')
GO

INSERT INTO [dbo].[user_role] ([user_id], [role_id]) VALUES (N'6', N'4')
GO


-- ----------------------------
-- Primary Key structure for table __EFMigrationsHistory
-- ----------------------------
ALTER TABLE [dbo].[__EFMigrationsHistory] ADD CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED ([MigrationId])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for auto_register
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[auto_register]', RESEED, 1001)
GO


-- ----------------------------
-- Primary Key structure for table auto_register
-- ----------------------------
ALTER TABLE [dbo].[auto_register] ADD CONSTRAINT [PK_auto_register] PRIMARY KEY CLUSTERED ([auto_id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for base_auto_color
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[base_auto_color]', RESEED, 1001)
GO


-- ----------------------------
-- Primary Key structure for table base_auto_color
-- ----------------------------
ALTER TABLE [dbo].[base_auto_color] ADD CONSTRAINT [PK_base_auto_color] PRIMARY KEY CLUSTERED ([color_id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for base_fee_model
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[base_fee_model]', RESEED, 1001)
GO


-- ----------------------------
-- Primary Key structure for table base_fee_model
-- ----------------------------
ALTER TABLE [dbo].[base_fee_model] ADD CONSTRAINT [PK_base_fee_model] PRIMARY KEY CLUSTERED ([fee_model_id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for base_license_color
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[base_license_color]', RESEED, 1001)
GO


-- ----------------------------
-- Primary Key structure for table base_license_color
-- ----------------------------
ALTER TABLE [dbo].[base_license_color] ADD CONSTRAINT [PK_base_license_color] PRIMARY KEY CLUSTERED ([color_id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for billing_info
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[billing_info]', RESEED, 1)
GO


-- ----------------------------
-- Primary Key structure for table billing_info
-- ----------------------------
ALTER TABLE [dbo].[billing_info] ADD CONSTRAINT [PK_billing_info] PRIMARY KEY CLUSTERED ([billing_id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for menus
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[menus]', RESEED, 2014)
GO


-- ----------------------------
-- Primary Key structure for table menus
-- ----------------------------
ALTER TABLE [dbo].[menus] ADD CONSTRAINT [PK_menus] PRIMARY KEY CLUSTERED ([menu_id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for record_info
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[record_info]', RESEED, 1000)
GO


-- ----------------------------
-- Primary Key structure for table record_info
-- ----------------------------
ALTER TABLE [dbo].[record_info] ADD CONSTRAINT [PK_record_info] PRIMARY KEY CLUSTERED ([record_id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table role_menu
-- ----------------------------
ALTER TABLE [dbo].[role_menu] ADD CONSTRAINT [PK_role_menu] PRIMARY KEY CLUSTERED ([menu_id], [role_id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for roles
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[roles]', RESEED, 1000)
GO


-- ----------------------------
-- Primary Key structure for table roles
-- ----------------------------
ALTER TABLE [dbo].[roles] ADD CONSTRAINT [PK_roles] PRIMARY KEY CLUSTERED ([role_id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for sys_user_info
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[sys_user_info]', RESEED, 1002)
GO


-- ----------------------------
-- Primary Key structure for table sys_user_info
-- ----------------------------
ALTER TABLE [dbo].[sys_user_info] ADD CONSTRAINT [PK_sys_user_info] PRIMARY KEY CLUSTERED ([user_id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for upgrade_file
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[upgrade_file]', RESEED, 1)
GO


-- ----------------------------
-- Primary Key structure for table upgrade_file
-- ----------------------------
ALTER TABLE [dbo].[upgrade_file] ADD CONSTRAINT [PK_upgrade_file] PRIMARY KEY CLUSTERED ([file_id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table user_role
-- ----------------------------
ALTER TABLE [dbo].[user_role] ADD CONSTRAINT [PK_user_role] PRIMARY KEY CLUSTERED ([user_id], [role_id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO

