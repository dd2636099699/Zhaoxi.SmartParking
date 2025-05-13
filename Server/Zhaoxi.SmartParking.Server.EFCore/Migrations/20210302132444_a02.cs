using Microsoft.EntityFrameworkCore.Migrations;

namespace Zhaoxi.SmartParking.Server.EFCore.Migrations
{
    public partial class a02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "base_fee_model",
                columns: table => new
                {
                    fee_model_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fee_model_name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_base_fee_model", x => x.fee_model_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "base_fee_model");
        }
    }
}
