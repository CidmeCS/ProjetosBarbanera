using Microsoft.EntityFrameworkCore.Migrations;

namespace ImportExportERP.Migrations
{
    public partial class desc3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DESCR_3",
                table: "Saldos");

            migrationBuilder.DropColumn(
                name: "DESCR_3",
                table: "SaldoDeTerceiros");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DESCR_3",
                table: "Saldos",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DESCR_3",
                table: "SaldoDeTerceiros",
                type: "text",
                nullable: true);
        }
    }
}
