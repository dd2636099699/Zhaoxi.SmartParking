using Microsoft.EntityFrameworkCore.Migrations;

namespace Zhaoxi.SmartParking.Server.EFCore.Migrations
{
    public partial class a01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "auto_register",
                columns: table => new
                {
                    auto_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    auto_license = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    license_color_id = table.Column<int>(type: "int", nullable: false),
                    auto_color_id = table.Column<int>(type: "int", nullable: false),
                    fee_mode_id = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    state = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_auto_register", x => x.auto_id);
                });

            migrationBuilder.CreateTable(
                name: "base_auto_color",
                columns: table => new
                {
                    color_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    color_name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_base_auto_color", x => x.color_id);
                });

            migrationBuilder.CreateTable(
                name: "base_license_color",
                columns: table => new
                {
                    color_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    color_name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_base_license_color", x => x.color_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "auto_register");

            migrationBuilder.DropTable(
                name: "base_auto_color");

            migrationBuilder.DropTable(
                name: "base_license_color");
        }
    }
}
