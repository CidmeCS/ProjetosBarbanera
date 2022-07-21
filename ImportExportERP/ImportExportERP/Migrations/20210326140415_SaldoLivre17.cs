using Microsoft.EntityFrameworkCore.Migrations;

namespace ImportExportERP.Migrations
{
    public partial class SaldoLivre17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Livre17",
                table: "Saldos",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Livre17",
                table: "SaldoDeTerceiros",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Livre17",
                table: "Saldos");

            migrationBuilder.DropColumn(
                name: "Livre17",
                table: "SaldoDeTerceiros");
        }
    }
}
