using Microsoft.EntityFrameworkCore.Migrations;

namespace WahalafreeAPI.Migrations
{
    public partial class feb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "deliveryCosts",
                columns: table => new
                {
                    deliveryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    belowFreeDeliveryCost = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_deliveryCosts", x => x.deliveryId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "deliveryCosts");
        }
    }
}
