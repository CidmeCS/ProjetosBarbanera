using Microsoft.EntityFrameworkCore.Migrations;

namespace ImportExportERP.Migrations.SqlServer
{
    public partial class OrdensDeProducao3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "NroOP",
                table: "OrdensDeProducoes",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NroOP",
                table: "OrdensDeProducoes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
