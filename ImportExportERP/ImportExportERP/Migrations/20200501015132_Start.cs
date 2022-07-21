using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace ImportExportERP.Migrations
{
    public partial class Start : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DepositoDeTerceiros",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Deposito = table.Column<int>(nullable: false),
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
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
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
                name: "ForaDeEstoques",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
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
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
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
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<DateTime>(nullable: false),
                    TM = table.Column<string>(nullable: true),
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
                name: "PedidosDeCompra",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
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
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    DataEntrega = table.Column<DateTime>(nullable: false),
                    Seq = table.Column<string>(nullable: true),
                    Quantidade = table.Column<double>(nullable: false),
                    StatusdoItem = table.Column<string>(nullable: true),
                    DataPedido = table.Column<DateTime>(nullable: false),
                    Vendedor = table.Column<string>(nullable: true),
                    Item = table.Column<string>(nullable: true),
                    Bloq = table.Column<string>(nullable: true),
                    Estabelecimento = table.Column<string>(nullable: true),
                    MotivosBloqueio = table.Column<string>(nullable: true),
                    Disponivel = table.Column<double>(nullable: false),
                    NPedido = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    Deposito = table.Column<string>(nullable: true),
                    OrdemCompra = table.Column<string>(nullable: true),
                    PrecoUnitário = table.Column<double>(nullable: false),
                    ValorTotal = table.Column<double>(nullable: false),
                    RazaoSocial = table.Column<string>(nullable: true),
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
                name: "SaldoDeTerceiros",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
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
                    DESCR_3 = table.Column<string>(nullable: true),
                    RESERVADO_11 = table.Column<double>(nullable: false),
                    ValorUltFech = table.Column<double>(nullable: false),
                    CustoMedioSimulado = table.Column<double>(nullable: false),
                    CustoMedio = table.Column<double>(nullable: false),
                    PrecoListaPadrao = table.Column<double>(nullable: false),
                    Descricao2 = table.Column<string>(nullable: true)
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
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
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
                    DESCR_3 = table.Column<string>(nullable: true),
                    RESERVADO_11 = table.Column<double>(nullable: false),
                    ValorUltFech = table.Column<double>(nullable: false),
                    CustoMedioSimulado = table.Column<double>(nullable: false),
                    CustoMedio = table.Column<double>(nullable: false),
                    PrecoListaPadrao = table.Column<double>(nullable: false),
                    Descricao2 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saldos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepositoDeTerceiros");

            migrationBuilder.DropTable(
                name: "DeTerceiros");

            migrationBuilder.DropTable(
                name: "ForaDeEstoques");

            migrationBuilder.DropTable(
                name: "ItensDeEstoques");

            migrationBuilder.DropTable(
                name: "Movimentos");

            migrationBuilder.DropTable(
                name: "PedidosDeCompra");

            migrationBuilder.DropTable(
                name: "PedidosDeVenda");

            migrationBuilder.DropTable(
                name: "SaldoDeTerceiros");

            migrationBuilder.DropTable(
                name: "Saldos");
        }
    }
}
