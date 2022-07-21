using Microsoft.EntityFrameworkCore.Migrations;

namespace ImportExportERP.Migrations
{
    public partial class PedidoDeVenda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Saldo",
                table: "PedidosDeVenda",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Saldo",
                table: "PedidosDeVenda");
        }
    }
}
