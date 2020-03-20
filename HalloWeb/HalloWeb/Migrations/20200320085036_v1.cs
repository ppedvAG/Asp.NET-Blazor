using Microsoft.EntityFrameworkCore.Migrations;

namespace HalloWeb.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Klopapier",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnzahlBlatt = table.Column<int>(nullable: false),
                    Hersteller = table.Column<string>(nullable: true),
                    Produkt = table.Column<string>(nullable: true),
                    Langen = table.Column<int>(nullable: false),
                    Duft = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klopapier", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Klopapier");
        }
    }
}
