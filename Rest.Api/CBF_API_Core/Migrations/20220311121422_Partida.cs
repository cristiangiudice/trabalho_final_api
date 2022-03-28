using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CBF_API_Core.Migrations
{
    public partial class Partida : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Partidas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TorneioId = table.Column<Guid>(nullable: false),
                    Time_MandanteId = table.Column<Guid>(nullable: false),
                    Time_VisitanteId = table.Column<Guid>(nullable: false),
                    DataPartida = table.Column<DateTime>(nullable: false),
                    GolsTimeMandante = table.Column<int>(nullable: false),
                    GolsTimeVisitante = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partidas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Partidas");
        }
    }
}
