using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ImportExportERP.Migrations.SqlServer
{
    public partial class OrdensDeProducao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrdensDeProducoes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NroOP = table.Column<string>(nullable: true),
                    StatusOP = table.Column<string>(nullable: true),
                    Estabelecimento = table.Column<string>(nullable: true),
                    Deposito = table.Column<string>(nullable: true),
                    Produto = table.Column<string>(nullable: true),
                    Traducao = table.Column<string>(nullable: true),
                    QuantidadePrev = table.Column<string>(nullable: true),
                    QuantidadeDigitada = table.Column<string>(nullable: true),
                    Fator = table.Column<string>(nullable: true),
                    Saldo = table.Column<string>(nullable: true),
                    Roteiro = table.Column<string>(nullable: true),
                    DtInicRoteiro = table.Column<string>(nullable: true),
                    DtAbertura = table.Column<string>(nullable: true),
                    HrAbertura = table.Column<string>(nullable: true),
                    Programacao = table.Column<string>(nullable: true),
                    Plano = table.Column<string>(nullable: true),
                    DtInicProd = table.Column<string>(nullable: true),
                    DtFimProd = table.Column<string>(nullable: true),
                    RefLote = table.Column<string>(nullable: true),
                    TipodeOP = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    TipodeCusto = table.Column<string>(nullable: true),
                    PesoparaRateio1 = table.Column<string>(nullable: true),
                    PesoparaRateio2 = table.Column<string>(nullable: true),
                    PesoparaRateio3 = table.Column<string>(nullable: true),
                    PesoparaRateio4 = table.Column<string>(nullable: true),
                    EMPRESA = table.Column<string>(nullable: true),
                    FILIAL = table.Column<string>(nullable: true),
                    STATUS = table.Column<string>(nullable: true),
                    QuantidadeApont = table.Column<string>(nullable: true),
                    NR_OP_ORIGEM = table.Column<string>(nullable: true),
                    DtEncerramento = table.Column<DateTime>(nullable: false),
                    DtCancelamento = table.Column<DateTime>(nullable: false),
                    DtLiberacao = table.Column<DateTime>(nullable: false),
                    HrEncerramento = table.Column<string>(nullable: true),
                    HrCancelamento = table.Column<string>(nullable: true),
                    HrLiberacao = table.Column<string>(nullable: true),
                    HrInicioProd = table.Column<string>(nullable: true),
                    HrFimProd = table.Column<string>(nullable: true),
                    COD_OBS_GEN = table.Column<string>(nullable: true),
                    Descricao1 = table.Column<string>(nullable: true),
                    Descricao2 = table.Column<string>(nullable: true),
                    Observacao = table.Column<string>(nullable: true),
                    DocOrigem = table.Column<string>(nullable: true),
                    Operador = table.Column<string>(nullable: true),
                    DataAlter = table.Column<string>(nullable: true),
                    HoraAlter = table.Column<string>(nullable: true),
                    RESERVADO_02 = table.Column<string>(nullable: true),
                    MaxProducao = table.Column<string>(nullable: true),
                    Grupo = table.Column<string>(nullable: true),
                    DescricaoGrupo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdensDeProducoes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdensDeProducoes");
        }
    }
}
