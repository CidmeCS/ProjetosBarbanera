using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ImportExportERP.Migrations
{
    public partial class Atualizacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Atualizacoes",
                columns: table => new
                {
                    Entidade = table.Column<string>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atualizacoes", x => x.Entidade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atualizacoes");
        }
    }
}
