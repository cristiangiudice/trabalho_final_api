using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CBF_API_Core.Migrations
{
    public partial class Transferencias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transferencias",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TimeDeOrigemId = table.Column<Guid>(nullable: false),
                    TimeDeDestinoId = table.Column<Guid>(nullable: false),
                    ValorTransferencia = table.Column<decimal>(nullable: false),
                    JogadorTransferidoId = table.Column<Guid>(nullable: false),
                    DataTransferencia = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transferencias", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transferencias");
        }
    }
}
