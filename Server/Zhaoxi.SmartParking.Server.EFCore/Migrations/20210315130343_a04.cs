using Microsoft.EntityFrameworkCore.Migrations;

namespace Zhaoxi.SmartParking.Server.EFCore.Migrations
{
    public partial class a04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "valid_count",
                table: "auto_register",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "valid_end_time",
                table: "auto_register",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "valid_start_time",
                table: "auto_register",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "valid_count",
                table: "auto_register");

            migrationBuilder.DropColumn(
                name: "valid_end_time",
                table: "auto_register");

            migrationBuilder.DropColumn(
                name: "valid_start_time",
                table: "auto_register");
        }
    }
}
