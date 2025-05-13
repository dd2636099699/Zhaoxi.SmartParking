using Microsoft.EntityFrameworkCore.Migrations;

namespace Zhaoxi.SmartParking.Server.EFCore.Migrations
{
    public partial class a03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "billing_info",
                columns: table => new
                {
                    billing_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    start_time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    end_time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    billing_rate = table.Column<double>(type: "float", nullable: false),
                    amount_money = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_billing_info", x => x.billing_id);
                });

            migrationBuilder.CreateTable(
                name: "record_info",
                columns: table => new
                {
                    record_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    auto_license = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    enter_time = table.Column<long>(type: "bigint", nullable: true),
                    leave_time = table.Column<long>(type: "bigint", nullable: true),
                    cost = table.Column<double>(type: "float", nullable: false),
                    order_id = table.Column<long>(type: "bigint", nullable: false),
                    fee_mode_id = table.Column<int>(type: "int", nullable: false),
                    state = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_record_info", x => x.record_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "billing_info");

            migrationBuilder.DropTable(
                name: "record_info");
        }
    }
}
