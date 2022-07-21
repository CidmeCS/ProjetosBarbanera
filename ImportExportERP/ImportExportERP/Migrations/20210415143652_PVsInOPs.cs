using Microsoft.EntityFrameworkCore.Migrations;

namespace ImportExportERP.Migrations
{
    public partial class PVsInOPs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PedidosDeVenda",
                table: "OrdensDeProducoes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PedidosDeVenda",
                table: "OrdensDeProducoes");
        }
    }
}
