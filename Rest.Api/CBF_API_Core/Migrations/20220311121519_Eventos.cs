using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CBF_API_Core.Migrations
{
    public partial class Eventos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PartidaId = table.Column<Guid>(nullable: false),
                    TipoEvento = table.Column<int>(nullable: false),
                    DetalheEvento = table.Column<string>(maxLength: 300, nullable: true),
                    DataEvento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Eventos");
        }
    }
}
