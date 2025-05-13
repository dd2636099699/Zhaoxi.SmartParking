using Microsoft.EntityFrameworkCore.Migrations;

namespace Zhaoxi.SmartParking.Server.EFCore.Migrations
{
    public partial class modifyusertable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "real_name",
                table: "sys_user_info",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "state",
                table: "sys_user_info",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "real_name",
                table: "sys_user_info");

            migrationBuilder.DropColumn(
                name: "state",
                table: "sys_user_info");
        }
    }
}
