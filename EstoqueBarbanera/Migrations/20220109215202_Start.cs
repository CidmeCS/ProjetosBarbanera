using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Estoque.Migrations
{
    public partial class Start : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnotacaoRFIDs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Produto = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    SaldoAtual = table.Column<string>(nullable: true),
                    Prateleira = table.Column<string>(nullable: true),
                    Saida = table.Column<decimal>(nullable: false),
                    Entrada = table.Column<decimal>(nullable: false),
                    SaldoES = table.Column<decimal>(nullable: false),
                    ResultadoFinal = table.Column<decimal>(nullable: false),
                    Atualiza = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnotacaoRFIDs", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "DataBackUP",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataBackUP", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DepositoDeTerceiros",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Deposito = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepositoDeTerceiros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeTerceiros",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Op = table.Column<string>(nullable: true),
                    DocEn = table.Column<string>(nullable: true),
                    Serie = table.Column<string>(nullable: true),
                    Produto = table.Column<string>(nullable: true),
                    Traducao = table.Column<string>(nullable: true),
                    TM = table.Column<string>(nullable: true),
                    Data = table.Column<DateTime>(nullable: false),
                    Cliente = table.Column<string>(nullable: true),
                    DocFiscal = table.Column<string>(nullable: true),
                    Serie2 = table.Column<string>(nullable: true),
                    Cont = table.Column<string>(nullable: true),
                    Lt = table.Column<string>(nullable: true),
                    QtdeNf = table.Column<double>(nullable: false),
                    ValorNf = table.Column<double>(nullable: false),
                    ValorCusto = table.Column<double>(nullable: false),
                    SaldoQtde = table.Column<double>(nullable: false),
                    SaldoCusto = table.Column<double>(nullable: false),
                    Observacao = table.Column<string>(nullable: true),
                    NomeFantasia = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    ValorUnitario = table.Column<double>(nullable: false),
                    TextoEspecificoFatBalcao = table.Column<string>(nullable: true),
                    ObsNFBalcao = table.Column<string>(nullable: true),
                    TIPO_MOVTO_NF = table.Column<string>(nullable: true),
                    NRO_FORNEC = table.Column<string>(nullable: true),
                    SEQ_FORNEC = table.Column<string>(nullable: true),
                    QT_ENVIADA = table.Column<double>(nullable: false),
                    VR_ENV_NF = table.Column<double>(nullable: false),
                    VR_ENVIADO = table.Column<double>(nullable: false),
                    QT_DEVOLV = table.Column<double>(nullable: false),
                    VR_DEV_NF = table.Column<double>(nullable: false),
                    VR_DEVOLV = table.Column<double>(nullable: false),
                    ESTAB = table.Column<string>(nullable: true),
                    Cont2 = table.Column<string>(nullable: true),
                    DEPOSITO = table.Column<string>(nullable: true),
                    TIPO_FE = table.Column<string>(nullable: true),
                    SEQ = table.Column<string>(nullable: true),
                    EMP_FIL = table.Column<string>(nullable: true),
                    DT_VENCTO = table.Column<string>(nullable: true),
                    DT_DOC_F = table.Column<DateTime>(nullable: false),
                    QT_FECH = table.Column<double>(nullable: false),
                    QT_FECH_AN = table.Column<double>(nullable: false),
                    VR_FECH = table.Column<double>(nullable: false),
                    VR_FECH_AN = table.Column<double>(nullable: false),
                    VR_FECH_NF = table.Column<double>(nullable: false),
                    VR_FEAN_NF = table.Column<double>(nullable: false),
                    VRI_ENVIAD = table.Column<string>(nullable: true),
                    VRI_DEVOLV = table.Column<string>(nullable: true),
                    VRI_FECH = table.Column<string>(nullable: true),
                    VRI_FECH_AN = table.Column<string>(nullable: true),
                    VRU_ENVIAD = table.Column<string>(nullable: true),
                    VRU_DEVOLV = table.Column<string>(nullable: true),
                    VRU_FECH = table.Column<string>(nullable: true),
                    VRU_FECH_AN = table.Column<string>(nullable: true),
                    REF_UNID = table.Column<string>(nullable: true),
                    REF_LOCAL = table.Column<string>(nullable: true),
                    C_CUSTO = table.Column<string>(nullable: true),
                    DG_CCUSTO = table.Column<string>(nullable: true),
                    C_CUSTO2 = table.Column<string>(nullable: true),
                    DG_CCUSTO2 = table.Column<string>(nullable: true),
                    CONTA = table.Column<string>(nullable: true),
                    DG_CONTA = table.Column<string>(nullable: true),
                    CONTA2 = table.Column<string>(nullable: true),
                    DG_CONTA2 = table.Column<string>(nullable: true),
                    TIPO_CONTAB = table.Column<string>(nullable: true),
                    DATA_ALTER = table.Column<DateTime>(nullable: false),
                    TIME_STAMP = table.Column<string>(nullable: true),
                    HORA_ALTER = table.Column<string>(nullable: true),
                    ORIGEM_MOVTO = table.Column<string>(nullable: true),
                    ORDEM_ENVIO = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeTerceiros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EntregaDeTerceiros",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Produto = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    Quantidade = table.Column<double>(nullable: false),
                    Deposito = table.Column<string>(nullable: true),
                    EntreguePara = table.Column<string>(nullable: true),
                    Data = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntregaDeTerceiros", x => x.Id);
                });
            
            migrationBuilder.CreateTable(
                name: "EtiquetaMovimentos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Codigo = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    Operacao = table.Column<string>(nullable: true),
                    ValorMovimento = table.Column<decimal>(type: "decimal(18, 3)", nullable: false),
                    SaldoAtual = table.Column<decimal>(type: "decimal(18, 3)", nullable: false),
                    Prateleira = table.Column<string>(nullable: true),
                    Livre17 = table.Column<decimal>(type: "decimal(18, 5)", nullable: false),
                    Convertido = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    UND = table.Column<string>(nullable: true),
                    NewSaldoAtual = table.Column<decimal>(type: "decimal(18, 3)", nullable: false),
                    NewConvewtido = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Data = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EtiquetaMovimentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Etiquetas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Codigo = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    SaldoAtual = table.Column<decimal>(type: "decimal(18, 3)", nullable: false),
                    Prateleira = table.Column<string>(nullable: true),
                    Livre17 = table.Column<decimal>(type: "decimal(18, 5)", nullable: false),
                    Convertido = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Grupo = table.Column<string>(nullable: true),
                    UND = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etiquetas", x => x.Id);
                });
             
            migrationBuilder.CreateTable(
                name: "ForaDeEstoques",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Op = table.Column<string>(nullable: true),
                    DocEn = table.Column<string>(nullable: true),
                    Serie = table.Column<string>(nullable: true),
                    Produto = table.Column<string>(nullable: true),
                    Traducao = table.Column<string>(nullable: true),
                    TM = table.Column<string>(nullable: true),
                    Data = table.Column<DateTime>(nullable: false),
                    Fornecedor = table.Column<string>(nullable: true),
                    DocFiscal = table.Column<string>(nullable: true),
                    Serie2 = table.Column<string>(nullable: true),
                    Cont = table.Column<string>(nullable: true),
                    Lt = table.Column<string>(nullable: true),
                    QtdeNf = table.Column<double>(nullable: false),
                    ValorNf = table.Column<double>(nullable: false),
                    ValorCusto = table.Column<double>(nullable: false),
                    SaldoQtde = table.Column<double>(nullable: false),
                    SaldoCusto = table.Column<double>(nullable: false),
                    Observacao = table.Column<string>(nullable: true),
                    NomeFantasia = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    ValorUnitario = table.Column<double>(nullable: false),
                    TextoEspecificoFatBalcao = table.Column<string>(nullable: true),
                    ObsNFBalcao = table.Column<string>(nullable: true),
                    TIPO_MOVTO_NF = table.Column<string>(nullable: true),
                    NRO_FORNEC = table.Column<string>(nullable: true),
                    SEQ_FORNEC = table.Column<string>(nullable: true),
                    QT_ENVIADA = table.Column<double>(nullable: false),
                    VR_ENV_NF = table.Column<double>(nullable: false),
                    VR_ENVIADO = table.Column<double>(nullable: false),
                    QT_DEVOLV = table.Column<double>(nullable: false),
                    VR_DEV_NF = table.Column<double>(nullable: false),
                    VR_DEVOLV = table.Column<double>(nullable: false),
                    ESTAB = table.Column<string>(nullable: true),
                    Cont2 = table.Column<string>(nullable: true),
                    DEPOSITO = table.Column<string>(nullable: true),
                    TIPO_FE = table.Column<string>(nullable: true),
                    SEQ = table.Column<string>(nullable: true),
                    EMP_FIL = table.Column<string>(nullable: true),
                    DT_VENCTO = table.Column<string>(nullable: true),
                    DT_DOC_F = table.Column<DateTime>(nullable: false),
                    QT_FECH = table.Column<double>(nullable: false),
                    QT_FECH_AN = table.Column<double>(nullable: false),
                    VR_FECH = table.Column<double>(nullable: false),
                    VR_FECH_AN = table.Column<double>(nullable: false),
                    VR_FECH_NF = table.Column<double>(nullable: false),
                    VR_FEAN_NF = table.Column<double>(nullable: false),
                    VRI_ENVIAD = table.Column<string>(nullable: true),
                    VRI_DEVOLV = table.Column<string>(nullable: true),
                    VRI_FECH = table.Column<string>(nullable: true),
                    VRI_FECH_AN = table.Column<string>(nullable: true),
                    VRU_ENVIAD = table.Column<string>(nullable: true),
                    VRU_DEVOLV = table.Column<string>(nullable: true),
                    VRU_FECH = table.Column<string>(nullable: true),
                    VRU_FECH_AN = table.Column<string>(nullable: true),
                    REF_UNID = table.Column<string>(nullable: true),
                    REF_LOCAL = table.Column<string>(nullable: true),
                    C_CUSTO = table.Column<string>(nullable: true),
                    DG_CCUSTO = table.Column<string>(nullable: true),
                    C_CUSTO2 = table.Column<string>(nullable: true),
                    DG_CCUSTO2 = table.Column<string>(nullable: true),
                    CONTA = table.Column<string>(nullable: true),
                    DG_CONTA = table.Column<string>(nullable: true),
                    CONTA2 = table.Column<string>(nullable: true),
                    DG_CONTA2 = table.Column<string>(nullable: true),
                    TIPO_CONTAB = table.Column<string>(nullable: true),
                    DATA_ALTER = table.Column<DateTime>(nullable: false),
                    TIME_STAMP = table.Column<string>(nullable: true),
                    HORA_ALTER = table.Column<string>(nullable: true),
                    ORIGEM_MOVTO = table.Column<string>(nullable: true),
                    ORDEM_ENVIO = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForaDeEstoques", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItensDeEstoques",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Codigo = table.Column<string>(nullable: true),
                    PrecoCompra = table.Column<double>(nullable: false),
                    Traducao = table.Column<string>(nullable: true),
                    Unidade = table.Column<string>(nullable: true),
                    Grupo = table.Column<string>(nullable: true),
                    Lotes = table.Column<string>(nullable: true),
                    NS = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    QuantidadeDisponivel = table.Column<double>(nullable: false),
                    SaldoFisico = table.Column<double>(nullable: false),
                    QuantidadeporUnidade = table.Column<string>(nullable: true),
                    Cubagem = table.Column<string>(nullable: true),
                    PesoBruto = table.Column<string>(nullable: true),
                    PesoLiquido = table.Column<string>(nullable: true),
                    DatadaCompra = table.Column<string>(nullable: true),
                    Prateleira = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    ItemCadastradoEm = table.Column<DateTime>(nullable: false),
                    PosicaoFiscal = table.Column<string>(nullable: true),
                    ComplPosicaoFiscal = table.Column<string>(nullable: true),
                    UnidAlterDIPI = table.Column<string>(nullable: true),
                    FatorUnidDIPI = table.Column<string>(nullable: true),
                    Procedência = table.Column<string>(nullable: true),
                    UnAlterDIPI = table.Column<string>(nullable: true),
                    EXdaTIPI = table.Column<string>(nullable: true),
                    CoddoFabricantedoProduto = table.Column<string>(nullable: true),
                    ExpPalm = table.Column<string>(nullable: true),
                    PrecoVenda = table.Column<double>(nullable: false),
                    Codigo2 = table.Column<string>(nullable: true),
                    DESCR_1 = table.Column<string>(nullable: true),
                    DESCR_2 = table.Column<string>(nullable: true),
                    DescricaoCompleta = table.Column<string>(nullable: true),
                    CodigoExterno = table.Column<string>(nullable: true),
                    ESTAB = table.Column<string>(nullable: true),
                    DEPOSITO = table.Column<string>(nullable: true),
                    QtdUltFech = table.Column<double>(nullable: false),
                    ENTRADAS = table.Column<double>(nullable: false),
                    SAIDAS = table.Column<double>(nullable: false),
                    OS_PREVIST = table.Column<string>(nullable: true),
                    ForadeEstoque = table.Column<double>(nullable: false),
                    VendasConsig = table.Column<string>(nullable: true),
                    ComprasConsig = table.Column<double>(nullable: false),
                    ResVendas = table.Column<double>(nullable: false),
                    PedVenda = table.Column<double>(nullable: false),
                    Preco = table.Column<double>(nullable: false),
                    QT_ALT_OBR = table.Column<string>(nullable: true),
                    EmpReqCompra = table.Column<double>(nullable: false),
                    UnidadeAlternativa = table.Column<string>(nullable: true),
                    FatordeConversao = table.Column<double>(nullable: false),
                    CodFamilia = table.Column<string>(nullable: true),
                    DescricaodaFamilia = table.Column<string>(nullable: true),
                    CodEAN13 = table.Column<string>(nullable: true),
                    EstoqueMinimo = table.Column<double>(nullable: false),
                    EstoqueMáximo = table.Column<double>(nullable: false),
                    Tolerancia = table.Column<double>(nullable: false),
                    Leadtime = table.Column<double>(nullable: false),
                    CodigodoRecolhimento = table.Column<string>(nullable: true),
                    AliquotadeIPI = table.Column<string>(nullable: true),
                    Livre1 = table.Column<string>(nullable: true),
                    Livre2 = table.Column<string>(nullable: true),
                    Livre3 = table.Column<string>(nullable: true),
                    Livre4 = table.Column<string>(nullable: true),
                    Livre5 = table.Column<string>(nullable: true),
                    Livre6 = table.Column<string>(nullable: true),
                    Livre7 = table.Column<string>(nullable: true),
                    Livre8 = table.Column<string>(nullable: true),
                    Livre9 = table.Column<string>(nullable: true),
                    Livre10 = table.Column<string>(nullable: true),
                    Livre11 = table.Column<string>(nullable: true),
                    Livre12 = table.Column<string>(nullable: true),
                    Livre13 = table.Column<DateTime>(nullable: false),
                    Livre14 = table.Column<DateTime>(nullable: false),
                    Livre15 = table.Column<DateTime>(nullable: false),
                    Livre16 = table.Column<DateTime>(nullable: false),
                    Livre17 = table.Column<string>(nullable: true),
                    Livre18 = table.Column<string>(nullable: true),
                    Livre19 = table.Column<string>(nullable: true),
                    Livre20 = table.Column<string>(nullable: true),
                    CodigodeServico = table.Column<string>(nullable: true),
                    ContaContabil = table.Column<string>(nullable: true),
                    ContaConsumo = table.Column<string>(nullable: true),
                    CentrodeCusto = table.Column<string>(nullable: true),
                    GeneroCotepe = table.Column<string>(nullable: true),
                    TipoItemSped = table.Column<string>(nullable: true),
                    CodigoProdutoSimilar = table.Column<string>(nullable: true),
                    ValorUltFech = table.Column<double>(nullable: false),
                    CustoMedioSimulado = table.Column<double>(nullable: false),
                    CustoMedio = table.Column<double>(nullable: false),
                    RESERVADO_11 = table.Column<string>(nullable: true),
                    CodigodeTributacaoAM = table.Column<string>(nullable: true),
                    GrupodeFamilia = table.Column<string>(nullable: true),
                    DescricaoGrupoFamilia = table.Column<string>(nullable: true),
                    DescricaoCompleta2 = table.Column<string>(nullable: true),
                    Descricaos = table.Column<string>(nullable: true),
                    CEST = table.Column<string>(nullable: true),
                    Conta = table.Column<string>(nullable: true),
                    DgConta = table.Column<string>(nullable: true),
                    ContaCons = table.Column<string>(nullable: true),
                    DgContaCons = table.Column<string>(nullable: true),
                    CentroCusto = table.Column<string>(nullable: true),
                    DgCentroCusto = table.Column<string>(nullable: true),
                    PrecodeReposicao = table.Column<string>(nullable: true),
                    Reinf = table.Column<string>(nullable: true),
                    GoodsReceipt = table.Column<string>(nullable: true),
                    DescricaodoGrupo = table.Column<string>(nullable: true),
                    CodigodeTributacao = table.Column<string>(nullable: true),
                    CodigodeTributacaoAlternativo = table.Column<string>(nullable: true),
                    Familia = table.Column<string>(nullable: true),
                    Formadepedir = table.Column<string>(nullable: true),
                    FatorUnidadeNCM = table.Column<string>(nullable: true),
                    Fatordaunidade = table.Column<string>(nullable: true),
                    Unidadealternativaexportacao = table.Column<string>(nullable: true),
                    FatorunidadeDIPIexportacao = table.Column<string>(nullable: true),
                    Aplicacao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensDeEstoques", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movimentos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<DateTime>(nullable: false),
                    TM = table.Column<int>(nullable: false),
                    Codigo = table.Column<string>(nullable: true),
                    Lote = table.Column<string>(nullable: true),
                    Documento = table.Column<string>(nullable: true),
                    AC = table.Column<string>(nullable: true),
                    Quantidade = table.Column<double>(nullable: false),
                    ValorMovimento = table.Column<double>(nullable: false),
                    OS = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    Unidade = table.Column<string>(nullable: true),
                    TipodeContabilização = table.Column<string>(nullable: true),
                    ClienteFornecedor = table.Column<string>(nullable: true),
                    NomeFantasia = table.Column<string>(nullable: true),
                    Contabiliza = table.Column<string>(nullable: true),
                    ContaContabil = table.Column<string>(nullable: true),
                    Dig = table.Column<string>(nullable: true),
                    CentrodeCusto = table.Column<string>(nullable: true),
                    Dig2 = table.Column<string>(nullable: true),
                    Livre2 = table.Column<string>(nullable: true),
                    DescrTipoMovto = table.Column<string>(nullable: true),
                    CUSTO_INF = table.Column<double>(nullable: false),
                    SaldoAtual = table.Column<double>(nullable: false),
                    ConsMedio = table.Column<double>(nullable: false),
                    VALOR = table.Column<double>(nullable: false),
                    DESC_RATEA = table.Column<string>(nullable: true),
                    REF_LOTE = table.Column<string>(nullable: true),
                    QTDE_BRUTA = table.Column<double>(nullable: false),
                    FLAG = table.Column<string>(nullable: true),
                    EMP_FIL = table.Column<string>(nullable: true),
                    ESTAB = table.Column<string>(nullable: true),
                    DEPOSITO = table.Column<string>(nullable: true),
                    CustoMedioSimulado = table.Column<double>(nullable: false),
                    NR_TRANSF_CG = table.Column<string>(nullable: true),
                    OperadorInclusao = table.Column<string>(nullable: true),
                    DataInclusao = table.Column<DateTime>(nullable: false),
                    HoraInclusao = table.Column<string>(nullable: true),
                    CustoMedio = table.Column<double>(nullable: false),
                    Roteiro = table.Column<string>(nullable: true),
                    DataInicioRoteiro = table.Column<string>(nullable: true),
                    QuantidadeDigitada = table.Column<string>(nullable: true),
                    Fator = table.Column<string>(nullable: true),
                    OPERACAO = table.Column<string>(nullable: true),
                    DescrMovto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NotasFiscaisDinamicaProdutos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NotaFiscal = table.Column<int>(nullable: false),
                    Serie = table.Column<string>(nullable: true),
                    Fornecedor = table.Column<string>(nullable: true),
                    Linha = table.Column<string>(nullable: true),
                    DataMovimento = table.Column<DateTime>(nullable: false),
                    TipoMovto = table.Column<string>(nullable: true),
                    Estabelecimento = table.Column<string>(nullable: true),
                    Deposito = table.Column<string>(nullable: true),
                    Produto = table.Column<string>(nullable: true),
                    Quantidade = table.Column<double>(nullable: false),
                    PesoLiquido = table.Column<string>(nullable: true),
                    PesoBruto = table.Column<string>(nullable: true),
                    ValorUnitario = table.Column<string>(nullable: true),
                    ValordasMercadorias = table.Column<string>(nullable: true),
                    ValorAdicionalFinanceiro = table.Column<string>(nullable: true),
                    ValorDesconto = table.Column<string>(nullable: true),
                    ValorEmbalagem = table.Column<string>(nullable: true),
                    ValorFrete = table.Column<string>(nullable: true),
                    ValorICMS = table.Column<string>(nullable: true),
                    ValorICMSSubst = table.Column<string>(nullable: true),
                    PorcentagemISS = table.Column<string>(nullable: true),
                    ValorIPI = table.Column<string>(nullable: true),
                    ValorISS = table.Column<string>(nullable: true),
                    ValorPIS = table.Column<string>(nullable: true),
                    ValorCOFINS = table.Column<string>(nullable: true),
                    ValorSeguro = table.Column<string>(nullable: true),
                    PorcentagemIR = table.Column<string>(nullable: true),
                    ValorIRRetido = table.Column<string>(nullable: true),
                    TratamentoFiscal = table.Column<string>(nullable: true),
                    CFOP = table.Column<string>(nullable: true),
                    PosicaoFiscal = table.Column<string>(nullable: true),
                    PorcentagemICMS = table.Column<string>(nullable: true),
                    ValorIPISobreFrete = table.Column<string>(nullable: true),
                    VrDescZonaFranca = table.Column<string>(nullable: true),
                    DocEnvio = table.Column<string>(nullable: true),
                    Pedido = table.Column<int>(nullable: false),
                    IDCusto = table.Column<string>(nullable: true),
                    ValorINSS = table.Column<string>(nullable: true),
                    NotaFiscalOrigem = table.Column<string>(nullable: true),
                    SerieNFOrigem = table.Column<string>(nullable: true),
                    CentrodeCusto = table.Column<string>(nullable: true),
                    DigCCusto = table.Column<string>(nullable: true),
                    TipodeContabilizacao = table.Column<string>(nullable: true),
                    PIS = table.Column<string>(nullable: true),
                    COFINS = table.Column<string>(nullable: true),
                    NumerodaDI = table.Column<string>(nullable: true),
                    DatadeEmissao = table.Column<DateTime>(nullable: false),
                    Territorio = table.Column<string>(nullable: true),
                    Vendedor = table.Column<string>(nullable: true),
                    Supervisor = table.Column<string>(nullable: true),
                    Gerente = table.Column<string>(nullable: true),
                    DatadeSaida = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(nullable: true),
                    Emissao = table.Column<string>(nullable: true),
                    ObservacaonoLivro = table.Column<string>(nullable: true),
                    FretePago_APagar = table.Column<string>(nullable: true),
                    EspecieNF = table.Column<string>(nullable: true),
                    Placa = table.Column<string>(nullable: true),
                    Transportador = table.Column<string>(nullable: true),
                    IRVencimento = table.Column<string>(nullable: true),
                    PorcICMSSubst = table.Column<string>(nullable: true),
                    CNPJ_CGC = table.Column<string>(nullable: true),
                    NomeFantasia = table.Column<string>(nullable: true),
                    DescricaodoProduto = table.Column<string>(nullable: true),
                    ValorLiquido = table.Column<string>(nullable: true),
                    DescontoZonaFranca = table.Column<string>(nullable: true),
                    ImpostodeImportacao = table.Column<string>(nullable: true),
                    PercentPISSubstTrib = table.Column<string>(nullable: true),
                    ValorPISSubstTrib = table.Column<string>(nullable: true),
                    PercentCOFINSSubstTrib = table.Column<string>(nullable: true),
                    ValorCOFINSSubstTrib = table.Column<string>(nullable: true),
                    ValorderetencaodePIS = table.Column<string>(nullable: true),
                    ValorderetencaodeCOFINS = table.Column<string>(nullable: true),
                    ValorderetencaodeCSLL = table.Column<string>(nullable: true),
                    DescontoICMSConv100_97 = table.Column<string>(nullable: true),
                    ValorFUNRURAL = table.Column<string>(nullable: true),
                    DespesasAduaneiras = table.Column<string>(nullable: true),
                    ValorAFRMM = table.Column<string>(nullable: true),
                    Finalidade = table.Column<string>(nullable: true),
                    VrBaseICMSSubstTribSubstituidoPosterior = table.Column<string>(nullable: true),
                    VrICMSSubstTribSubstituidoPosterior = table.Column<string>(nullable: true),
                    VrFCP = table.Column<string>(nullable: true),
                    VrICMSDest = table.Column<string>(nullable: true),
                    VrICMSOrig = table.Column<string>(nullable: true),
                    BasedeCOFINS = table.Column<string>(nullable: true),
                    BasedePIS = table.Column<string>(nullable: true),
                    ValorINSSRetido = table.Column<string>(nullable: true),
                    ICMSSTOperacoesdeFrete = table.Column<string>(nullable: true),
                    DescricaoTipoMovimento = table.Column<string>(nullable: true),
                    NumeroNFEletronica = table.Column<string>(nullable: true),
                    DescricaoCFOP = table.Column<string>(nullable: true),
                    DescricaoPosFiscal = table.Column<string>(nullable: true),
                    CSTPIS = table.Column<string>(nullable: true),
                    CSTCOFINS = table.Column<string>(nullable: true),
                    RazaoSocial = table.Column<string>(nullable: true),
                    EMP_FIL = table.Column<string>(nullable: true),
                    TIPO_MOVTO = table.Column<string>(nullable: true),
                    COM_VEN = table.Column<string>(nullable: true),
                    ENTR_SAID = table.Column<string>(nullable: true),
                    ICM_SP = table.Column<string>(nullable: true),
                    INF_TRAD = table.Column<string>(nullable: true),
                    TEM_NFDA = table.Column<string>(nullable: true),
                    UNIDADE = table.Column<string>(nullable: true),
                    BASE_UNIT = table.Column<string>(nullable: true),
                    DT_VENCTO = table.Column<string>(nullable: true),
                    COND_PGTO = table.Column<string>(nullable: true),
                    QTDE_REC = table.Column<string>(nullable: true),
                    QTDE_ALTER = table.Column<string>(nullable: true),
                    QT_ALT_REC = table.Column<string>(nullable: true),
                    TAB_PRECO = table.Column<string>(nullable: true),
                    COD_EMBAL = table.Column<string>(nullable: true),
                    VLR_DIF_ALIQ_ICMS = table.Column<string>(nullable: true),
                    VLR_REPASSE = table.Column<string>(nullable: true),
                    ADIC_IR_PERCENT = table.Column<string>(nullable: true),
                    ADIC_IR = table.Column<string>(nullable: true),
                    COD_TRIB = table.Column<string>(nullable: true),
                    PORC_IPI = table.Column<string>(nullable: true),
                    PORC_ICM_S_FRETE = table.Column<string>(nullable: true),
                    PORC_IPI_S_FRETE = table.Column<string>(nullable: true),
                    BASE_ICM = table.Column<string>(nullable: true),
                    BASE_ICM_SUBST = table.Column<string>(nullable: true),
                    ICM_S_FRETE = table.Column<string>(nullable: true),
                    BASE_ICM_S_FRETE = table.Column<string>(nullable: true),
                    BASE_IPI_S_FRETE = table.Column<string>(nullable: true),
                    BASE_IPI = table.Column<string>(nullable: true),
                    BONIF = table.Column<string>(nullable: true),
                    NRO_OS = table.Column<string>(nullable: true),
                    OPERACAO = table.Column<string>(nullable: true),
                    ITEM_PED = table.Column<string>(nullable: true),
                    ALT_ESTQ = table.Column<string>(nullable: true),
                    ALT_ESTQ_TERC = table.Column<string>(nullable: true),
                    ALT_CUSTO = table.Column<string>(nullable: true),
                    JA_PROC = table.Column<string>(nullable: true),
                    PORC_COMIS = table.Column<string>(nullable: true),
                    PORC_COM_SUP = table.Column<string>(nullable: true),
                    PORC_COM_GER = table.Column<string>(nullable: true),
                    VR_COM_VEND = table.Column<string>(nullable: true),
                    VR_COM_SUP = table.Column<string>(nullable: true),
                    VR_COM_GER = table.Column<string>(nullable: true),
                    VR_COM_LQ_VEND = table.Column<string>(nullable: true),
                    VR_COM_LQ_SUP = table.Column<string>(nullable: true),
                    NF_ULT_COMPRA = table.Column<string>(nullable: true),
                    SR_ULT_COMPRA = table.Column<string>(nullable: true),
                    FORN_ULT_COMPRA = table.Column<string>(nullable: true),
                    PR_ULT_COMPRA = table.Column<string>(nullable: true),
                    TEXTO_ESP = table.Column<string>(nullable: true),
                    TEXTO_GEN = table.Column<string>(nullable: true),
                    EXPORTA_MV = table.Column<string>(nullable: true),
                    SERV_OFICINA = table.Column<string>(nullable: true),
                    REF_LOTE = table.Column<string>(nullable: true),
                    REF_UNID = table.Column<string>(nullable: true),
                    REF_LOCAL = table.Column<string>(nullable: true),
                    NOP = table.Column<string>(nullable: true),
                    COD_SERV = table.Column<string>(nullable: true),
                    LOCAL_CC = table.Column<string>(nullable: true),
                    LIVRE = table.Column<string>(nullable: true),
                    CONTA = table.Column<string>(nullable: true),
                    DG_CONTA = table.Column<string>(nullable: true),
                    CONTA2 = table.Column<string>(nullable: true),
                    DG_CONTA2 = table.Column<string>(nullable: true),
                    C_CUSTO2 = table.Column<string>(nullable: true),
                    DG_C_CUSTO2 = table.Column<string>(nullable: true),
                    NR_TRANSF_CG = table.Column<string>(nullable: true),
                    COD_ERRO1 = table.Column<string>(nullable: true),
                    COD_ERRO2 = table.Column<string>(nullable: true),
                    COD_ERRO3 = table.Column<string>(nullable: true),
                    VLR_MATERIAIS = table.Column<string>(nullable: true),
                    VLR_SUB_EMPR = table.Column<string>(nullable: true),
                    PORC_DESC_PV = table.Column<string>(nullable: true),
                    PORC_ADF_PV = table.Column<string>(nullable: true),
                    OPERADOR = table.Column<string>(nullable: true),
                    DATA_ALTER = table.Column<string>(nullable: true),
                    HORA_ALTER = table.Column<string>(nullable: true),
                    TIME_STAMP = table.Column<string>(nullable: true),
                    RESERVADO_01 = table.Column<string>(nullable: true),
                    RESERVADO_02 = table.Column<string>(nullable: true),
                    RESERVADO_03 = table.Column<string>(nullable: true),
                    RESERVADO_04 = table.Column<string>(nullable: true),
                    RESERVADO_05 = table.Column<string>(nullable: true),
                    RESERVADO_06 = table.Column<string>(nullable: true),
                    RESERVADO_07 = table.Column<string>(nullable: true),
                    RESERVADO_08 = table.Column<string>(nullable: true),
                    RESERVADO_09 = table.Column<string>(nullable: true),
                    RESERVADO_10 = table.Column<string>(nullable: true),
                    RESERVADO_11 = table.Column<string>(nullable: true),
                    RESERVADO_12 = table.Column<string>(nullable: true),
                    RESERVADO_13 = table.Column<string>(nullable: true),
                    DT_EMISSAO_1 = table.Column<string>(nullable: true),
                    CFO_1 = table.Column<string>(nullable: true),
                    VLR_ICM_BSTP = table.Column<string>(nullable: true),
                    VLR_ICM_STP = table.Column<string>(nullable: true),
                    NRO_PED = table.Column<int>(nullable: false),
                    DT_PED = table.Column<string>(nullable: true),
                    VLR_FCP_ST = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotasFiscaisDinamicaProdutos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrdensDeProducoes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NroOP = table.Column<int>(nullable: false),
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
                    DtEncerramento = table.Column<string>(nullable: true),
                    DtCancelamento = table.Column<string>(nullable: true),
                    DtLiberacao = table.Column<string>(nullable: true),
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
                    DescricaoGrupo = table.Column<string>(nullable: true),
                    PedidosDeVenda = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdensDeProducoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PedidosDeCompra",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Pedido = table.Column<string>(nullable: true),
                    Data = table.Column<DateTime>(nullable: false),
                    Entrega = table.Column<DateTime>(nullable: false),
                    Produto = table.Column<string>(nullable: true),
                    ValorUnitario = table.Column<double>(nullable: false),
                    PrecoTotal = table.Column<double>(nullable: false),
                    Unidade = table.Column<string>(nullable: true),
                    Requisicao = table.Column<string>(nullable: true),
                    LinhaReq = table.Column<string>(nullable: true),
                    CCusto = table.Column<string>(nullable: true),
                    DescricaoAlternativa = table.Column<string>(nullable: true),
                    Fornecedor = table.Column<string>(nullable: true),
                    Indice = table.Column<string>(nullable: true),
                    DescricaodaMoeda = table.Column<string>(nullable: true),
                    Quantidade = table.Column<double>(nullable: false),
                    QtdeEntregue = table.Column<double>(nullable: false),
                    LinhaPed = table.Column<string>(nullable: true),
                    Saldo = table.Column<double>(nullable: false),
                    Situacao = table.Column<string>(nullable: true),
                    STA_REG = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    Observacoes = table.Column<string>(nullable: true),
                    DigCCusto = table.Column<string>(nullable: true),
                    Título = table.Column<string>(nullable: true),
                    Traducao = table.Column<string>(nullable: true),
                    BaixaManual = table.Column<string>(nullable: true),
                    BaixaNF = table.Column<string>(nullable: true),
                    UnidadeEstq = table.Column<string>(nullable: true),
                    QtdeEstq = table.Column<string>(nullable: true),
                    EMP_FIL = table.Column<string>(nullable: true),
                    ESTAB = table.Column<string>(nullable: true),
                    DEPOSITO = table.Column<string>(nullable: true),
                    FORNEC = table.Column<string>(nullable: true),
                    NR_COTACAO = table.Column<string>(nullable: true),
                    OS = table.Column<string>(nullable: true),
                    PRIORIDADE = table.Column<string>(nullable: true),
                    DT_ENT_PREV = table.Column<string>(nullable: true),
                    DT_ENT_ORIG = table.Column<string>(nullable: true),
                    DT_ULT_ENT = table.Column<string>(nullable: true),
                    PORC_ICM = table.Column<string>(nullable: true),
                    VEZES_ENT = table.Column<string>(nullable: true),
                    LISTA = table.Column<string>(nullable: true),
                    BASE_UNIT = table.Column<string>(nullable: true),
                    PERC_DESC = table.Column<string>(nullable: true),
                    PERC_IPI = table.Column<string>(nullable: true),
                    VLR_DESC = table.Column<string>(nullable: true),
                    VLR_IPI = table.Column<string>(nullable: true),
                    VR_ENTR = table.Column<string>(nullable: true),
                    SEQ_ALT = table.Column<string>(nullable: true),
                    COD_TRIB = table.Column<string>(nullable: true),
                    TRAT_FISC = table.Column<string>(nullable: true),
                    COD_GEN = table.Column<string>(nullable: true),
                    CONTA = table.Column<string>(nullable: true),
                    DG_CONTA = table.Column<string>(nullable: true),
                    CONTA2 = table.Column<string>(nullable: true),
                    DG_CONTA2 = table.Column<string>(nullable: true),
                    C_CUSTO2 = table.Column<string>(nullable: true),
                    DG_CCUSTO2 = table.Column<string>(nullable: true),
                    GERA_FLUXO = table.Column<string>(nullable: true),
                    LIVRE = table.Column<string>(nullable: true),
                    BATCH_PROG = table.Column<string>(nullable: true),
                    BATCH_DATA = table.Column<string>(nullable: true),
                    BATCH_HORA = table.Column<string>(nullable: true),
                    ESTAGIO = table.Column<string>(nullable: true),
                    DT_INIC_EXEC = table.Column<string>(nullable: true),
                    PERIODO = table.Column<string>(nullable: true),
                    PROJETO_OBRA = table.Column<string>(nullable: true),
                    PROJETO_ETAPA = table.Column<string>(nullable: true),
                    APROVADOR_PROX = table.Column<string>(nullable: true),
                    APROV_AVISADO = table.Column<string>(nullable: true),
                    DT_APROVACAO = table.Column<string>(nullable: true),
                    DT_VALIDADE = table.Column<string>(nullable: true),
                    SOLICITANTE = table.Column<string>(nullable: true),
                    UNID_FORN = table.Column<string>(nullable: true),
                    FATOR_UN_FORN = table.Column<string>(nullable: true),
                    CUSTO_QT_SOLIC = table.Column<string>(nullable: true),
                    CUSTO_QT_APROV = table.Column<string>(nullable: true),
                    COND_PAGTO = table.Column<string>(nullable: true),
                    TIPO_DESPESA = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidosDeCompra", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PedidosDeVenda",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DataEntrega = table.Column<DateTime>(nullable: false),
                    Seq = table.Column<string>(nullable: true),
                    Quantidade = table.Column<double>(nullable: false),
                    StatusdoItem = table.Column<string>(nullable: true),
                    DataPedido = table.Column<DateTime>(nullable: false),
                    MotivosBloqueio = table.Column<string>(nullable: true),
                    Vendedor = table.Column<string>(nullable: true),
                    NPedido = table.Column<string>(nullable: true),
                    Bloq = table.Column<string>(nullable: true),
                    Item = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    Disponivel = table.Column<double>(nullable: false),
                    Deposito = table.Column<string>(nullable: true),
                    Estabelecimento = table.Column<string>(nullable: true),
                    OrdemCompra = table.Column<string>(nullable: true),
                    PrecoUnitário = table.Column<double>(nullable: false),
                    ValorTotal = table.Column<double>(nullable: false),
                    RazaoSocial = table.Column<string>(nullable: true),
                    NomeFantasia = table.Column<string>(nullable: true),
                    GrupoItem = table.Column<string>(nullable: true),
                    TextoEspecifico = table.Column<string>(nullable: true),
                    CodigoCliente = table.Column<string>(nullable: true),
                    DESCR_1 = table.Column<string>(nullable: true),
                    DESCR_2 = table.Column<string>(nullable: true),
                    VendaConfirmada = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidosDeVenda", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegistrosInventario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Produto = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    Prateleira = table.Column<string>(nullable: true),
                    Unid = table.Column<string>(nullable: true),
                    SaldoAtual = table.Column<double>(nullable: false),
                    ValorConvertido = table.Column<double>(nullable: false),
                    Inventario = table.Column<double>(nullable: false),
                    DiaInventario = table.Column<DateTime>(nullable: false),
                    DiasMov = table.Column<string>(nullable: true),
                    Acerto = table.Column<double>(nullable: false),
                    Livre17 = table.Column<double>(nullable: false),
                    _Indice = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrosInventario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegistrosInventarioSaldoDeTerceiro",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Produto = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    Prateleira = table.Column<string>(nullable: true),
                    Unid = table.Column<string>(nullable: true),
                    SaldoAtual = table.Column<double>(nullable: false),
                    DeTerceiro = table.Column<double>(nullable: false),
                    Inventario = table.Column<string>(nullable: true),
                    DiaInventario = table.Column<DateTime>(nullable: false),
                    ClienteDeposito = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrosInventarioSaldoDeTerceiro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SaldoDeTerceiros",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Produto = table.Column<string>(nullable: true),
                    Traducao = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    Unid = table.Column<string>(nullable: true),
                    Lote = table.Column<string>(nullable: true),
                    Grupo = table.Column<string>(nullable: true),
                    Disponivel = table.Column<double>(nullable: false),
                    SaldoAtual = table.Column<double>(nullable: false),
                    SaldoUltFech = table.Column<double>(nullable: false),
                    Entradas = table.Column<double>(nullable: false),
                    Saidas = table.Column<double>(nullable: false),
                    PedCompras = table.Column<double>(nullable: false),
                    PedVendas = table.Column<double>(nullable: false),
                    ConsuPrevOs = table.Column<double>(nullable: false),
                    JaRequisOS = table.Column<double>(nullable: false),
                    ProdPrevOS = table.Column<double>(nullable: false),
                    ProdEntrOS = table.Column<double>(nullable: false),
                    ForaEstoque = table.Column<double>(nullable: false),
                    Transito = table.Column<double>(nullable: false),
                    DeTerceiros = table.Column<double>(nullable: false),
                    VendaConsign = table.Column<double>(nullable: false),
                    CompraEntrFutura = table.Column<double>(nullable: false),
                    VendaEntrFutura = table.Column<double>(nullable: false),
                    CompraConsig = table.Column<double>(nullable: false),
                    AguardandoCQ = table.Column<double>(nullable: false),
                    EstqMinimo = table.Column<double>(nullable: false),
                    EstqMaximo = table.Column<double>(nullable: false),
                    ReservaDeVendas = table.Column<double>(nullable: false),
                    Prateleira = table.Column<string>(nullable: true),
                    SaldoPedidoDataEntregaExcedida = table.Column<double>(nullable: false),
                    PrevFabric = table.Column<double>(nullable: false),
                    DiassemMovimento = table.Column<double>(nullable: false),
                    EMP_FIL = table.Column<string>(nullable: true),
                    ESTAB = table.Column<string>(nullable: true),
                    DEPOSITO = table.Column<string>(nullable: true),
                    QT_CCON = table.Column<string>(nullable: true),
                    GR1 = table.Column<string>(nullable: true),
                    DESCR_2 = table.Column<string>(nullable: true),
                    FORNECED_2 = table.Column<string>(nullable: true),
                    RESERVADO_11 = table.Column<double>(nullable: false),
                    ValorUltFech = table.Column<double>(nullable: false),
                    CustoMedioSimulado = table.Column<double>(nullable: false),
                    CustoMedio = table.Column<double>(nullable: false),
                    PrecoListaPadrao = table.Column<double>(nullable: false),
                    Descricao2 = table.Column<string>(nullable: true),
                    Data = table.Column<DateTime>(nullable: false),
                    Livre17 = table.Column<decimal>(type: "decimal(18, 5)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaldoDeTerceiros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Saldos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Produto = table.Column<string>(nullable: true),
                    Traducao = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    Unid = table.Column<string>(nullable: true),
                    Lote = table.Column<string>(nullable: true),
                    Grupo = table.Column<string>(nullable: true),
                    Disponivel = table.Column<double>(nullable: false),
                    SaldoAtual = table.Column<double>(nullable: false),
                    SaldoUltFech = table.Column<double>(nullable: false),
                    Entradas = table.Column<double>(nullable: false),
                    Saidas = table.Column<double>(nullable: false),
                    PedCompras = table.Column<double>(nullable: false),
                    PedVendas = table.Column<double>(nullable: false),
                    ConsuPrevOs = table.Column<double>(nullable: false),
                    JaRequisOS = table.Column<double>(nullable: false),
                    ProdPrevOS = table.Column<double>(nullable: false),
                    ProdEntrOS = table.Column<double>(nullable: false),
                    ForaEstoque = table.Column<double>(nullable: false),
                    Transito = table.Column<double>(nullable: false),
                    DeTerceiros = table.Column<double>(nullable: false),
                    VendaConsign = table.Column<double>(nullable: false),
                    CompraEntrFutura = table.Column<double>(nullable: false),
                    VendaEntrFutura = table.Column<double>(nullable: false),
                    CompraConsig = table.Column<double>(nullable: false),
                    AguardandoCQ = table.Column<double>(nullable: false),
                    EstqMinimo = table.Column<double>(nullable: false),
                    EstqMaximo = table.Column<double>(nullable: false),
                    ReservaDeVendas = table.Column<double>(nullable: false),
                    Prateleira = table.Column<string>(nullable: true),
                    SaldoPedidoDataEntregaExcedida = table.Column<double>(nullable: false),
                    PrevFabric = table.Column<double>(nullable: false),
                    DiassemMovimento = table.Column<double>(nullable: false),
                    EMP_FIL = table.Column<string>(nullable: true),
                    ESTAB = table.Column<string>(nullable: true),
                    DEPOSITO = table.Column<string>(nullable: true),
                    QT_CCON = table.Column<string>(nullable: true),
                    GR1 = table.Column<string>(nullable: true),
                    DESCR_2 = table.Column<string>(nullable: true),
                    FORNECED_2 = table.Column<string>(nullable: true),
                    RESERVADO_11 = table.Column<double>(nullable: false),
                    ValorUltFech = table.Column<double>(nullable: false),
                    CustoMedioSimulado = table.Column<double>(nullable: false),
                    CustoMedio = table.Column<double>(nullable: false),
                    PrecoListaPadrao = table.Column<double>(nullable: false),
                    Descricao2 = table.Column<string>(nullable: true),
                    Livre17 = table.Column<decimal>(type: "decimal(18, 5)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saldos", x => x.Id);
                });
                     
            migrationBuilder.CreateIndex(
                name: "IX_Etiquetas_Codigo",
                table: "Etiquetas",
                column: "Codigo",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnotacaoRFIDs");

            migrationBuilder.DropTable(
                name: "Atualizacoes");

            migrationBuilder.DropTable(
                name: "DataBackUP");

            migrationBuilder.DropTable(
                name: "DepositoDeTerceiros");

            migrationBuilder.DropTable(
                name: "DeTerceiros");

            migrationBuilder.DropTable(
                name: "EntregaDeTerceiros");

            migrationBuilder.DropTable(
                name: "EtiquetaMovimentos");

            migrationBuilder.DropTable(
                name: "Etiquetas");

            migrationBuilder.DropTable(
                name: "ForaDeEstoques");

            migrationBuilder.DropTable(
                name: "ItensDeEstoques");

            migrationBuilder.DropTable(
                name: "Movimentos");

            migrationBuilder.DropTable(
                name: "NotasFiscaisDinamicaProdutos");

            migrationBuilder.DropTable(
                name: "OrdensDeProducoes");

            migrationBuilder.DropTable(
                name: "PedidosDeCompra");

            migrationBuilder.DropTable(
                name: "PedidosDeVenda");

            migrationBuilder.DropTable(
                name: "RegistrosInventario");

            migrationBuilder.DropTable(
                name: "RegistrosInventarioSaldoDeTerceiro");

            migrationBuilder.DropTable(
                name: "SaldoDeTerceiros");

            migrationBuilder.DropTable(
                name: "Saldos");
        }
    }
}
