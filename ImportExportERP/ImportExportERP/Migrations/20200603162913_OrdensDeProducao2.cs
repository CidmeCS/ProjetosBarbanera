using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ImportExportERP.Migrations
{
    public partial class OrdensDeProducao2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DtLiberacao",
                table: "OrdensDeProducoes",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<string>(
                name: "DtEncerramento",
                table: "OrdensDeProducoes",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<string>(
                name: "DtCancelamento",
                table: "OrdensDeProducoes",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DtLiberacao",
                table: "OrdensDeProducoes",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DtEncerramento",
                table: "OrdensDeProducoes",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DtCancelamento",
                table: "OrdensDeProducoes",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
