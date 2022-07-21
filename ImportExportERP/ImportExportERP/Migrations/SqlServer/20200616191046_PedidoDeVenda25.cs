using Microsoft.EntityFrameworkCore.Migrations;

namespace ImportExportERP.Migrations.SqlServer
{
    public partial class PedidoDeVenda25 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GrupoItem",
                table: "PedidosDeVenda",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeFantasia",
                table: "PedidosDeVenda",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TextoEspecifico",
                table: "PedidosDeVenda",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GrupoItem",
                table: "PedidosDeVenda");

            migrationBuilder.DropColumn(
                name: "NomeFantasia",
                table: "PedidosDeVenda");

            migrationBuilder.DropColumn(
                name: "TextoEspecifico",
                table: "PedidosDeVenda");
        }
    }
}
