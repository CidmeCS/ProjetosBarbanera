using System;
using System.Collections.Generic;
using System.Data;
using Estoque.Entidade;
using Renci.SshNet.Common;

namespace Estoque.Views
{
    internal class PopulandoItensDeEstoque
    {
        /*
        private static List<ItensDeEstoque> ie;


        internal static List<ItensDeEstoque> Start(DataSet itens)
        {
            ie = new List<ItensDeEstoque>();
            for (int linha = 0; linha < itens.Tables[0].Rows.Count; linha++)
            {

                ie.Add(new ItensDeEstoque()
                {

                    Codigo = itens.Tables[0].Rows[linha].ItemArray[1].ToString(),
                    PrecoCompra = Convert.ToDouble(itens.Tables[0].Rows[linha].ItemArray[2]),
                    Traducao = itens.Tables[0].Rows[linha].ItemArray[3].ToString(),
                    Unidade = itens.Tables[0].Rows[linha].ItemArray[4].ToString(),
                    Grupo = itens.Tables[0].Rows[linha].ItemArray[5].ToString(),
                    Lotes = itens.Tables[0].Rows[linha].ItemArray[6].ToString(),

                    NS = itens.Tables[0].Rows[linha].ItemArray[7].ToString(),
                    Descricao = itens.Tables[0].Rows[linha].ItemArray[8].ToString(),
                    QuantidadeDisponivel = Convert.ToDouble(itens.Tables[0].Rows[linha].ItemArray[9]),
                    SaldoFisico = Convert.ToDouble(itens.Tables[0].Rows[linha].ItemArray[10]),
                    QuantidadeporUnidade = itens.Tables[0].Rows[linha].ItemArray[11].ToString(),

                    Cubagem = itens.Tables[0].Rows[linha].ItemArray[12].ToString(),
                    PesoBruto = itens.Tables[0].Rows[linha].ItemArray[13].ToString(),
                    PesoLiquido = itens.Tables[0].Rows[linha].ItemArray[14].ToString(),
                    DatadaCompra = itens.Tables[0].Rows[linha].ItemArray[15].ToString(),
                    Prateleira = itens.Tables[0].Rows[linha].ItemArray[16].ToString(),

                    Status = itens.Tables[0].Rows[linha].ItemArray[17].ToString(),
                    ItemCadastradoEm = DateTime.Parse(itens.Tables[0].Rows[linha].ItemArray[18].ToString()),
                    PosicaoFiscal = itens.Tables[0].Rows[linha].ItemArray[19].ToString(),
                    ComplPosicaoFiscal = itens.Tables[0].Rows[linha].ItemArray[20].ToString(),
                    UnidAlterDIPI = itens.Tables[0].Rows[linha].ItemArray[21].ToString(),

                    FatorUnidDIPI = itens.Tables[0].Rows[linha].ItemArray[22].ToString(),
                    Procedência = itens.Tables[0].Rows[linha].ItemArray[23].ToString(),
                    UnAlterDIPI = itens.Tables[0].Rows[linha].ItemArray[24].ToString(),
                    EXdaTIPI = itens.Tables[0].Rows[linha].ItemArray[25].ToString(),
                    CoddoFabricantedoProduto = itens.Tables[0].Rows[linha].ItemArray[26].ToString(),

                    ExpPalm = itens.Tables[0].Rows[linha].ItemArray[27].ToString(),
                    PrecoVenda = Convert.ToDouble(itens.Tables[0].Rows[linha].ItemArray[28]),
                    Codigo2 = itens.Tables[0].Rows[linha].ItemArray[29].ToString(),
                    DESCR_1 = itens.Tables[0].Rows[linha].ItemArray[30].ToString(),
                    DESCR_2 = itens.Tables[0].Rows[linha].ItemArray[31].ToString(),

                    DescricaoCompleta = itens.Tables[0].Rows[linha].ItemArray[32].ToString(),
                    CodigoExterno = itens.Tables[0].Rows[linha].ItemArray[33].ToString(),
                    ESTAB = itens.Tables[0].Rows[linha].ItemArray[34].ToString(),
                    DEPOSITO = itens.Tables[0].Rows[linha].ItemArray[35].ToString(),
                    QtdUltFech = Convert.ToDouble(itens.Tables[0].Rows[linha].ItemArray[36]),

                    ENTRADAS = Convert.ToDouble(itens.Tables[0].Rows[linha].ItemArray[37]),
                    SAIDAS = Convert.ToDouble(itens.Tables[0].Rows[linha].ItemArray[38]),
                    OS_PREVIST = itens.Tables[0].Rows[linha].ItemArray[39].ToString(),
                    ForadeEstoque = Convert.ToDouble(itens.Tables[0].Rows[linha].ItemArray[40]),
                    VendasConsig = itens.Tables[0].Rows[linha].ItemArray[41].ToString(),

                    ComprasConsig = Convert.ToDouble(itens.Tables[0].Rows[linha].ItemArray[42]),
                    ResVendas = Convert.ToDouble(itens.Tables[0].Rows[linha].ItemArray[43]),
                    PedVenda = Convert.ToDouble(itens.Tables[0].Rows[linha].ItemArray[44]),
                    Preco = Convert.ToDouble(itens.Tables[0].Rows[linha].ItemArray[45]),
                    QT_ALT_OBR = itens.Tables[0].Rows[linha].ItemArray[46].ToString(),

                    EmpReqCompra = Convert.ToDouble(itens.Tables[0].Rows[linha].ItemArray[47]),
                    UnidadeAlternativa = itens.Tables[0].Rows[linha].ItemArray[48].ToString(),
                    FatordeConversao = Convert.ToDouble(itens.Tables[0].Rows[linha].ItemArray[49]),
                    CodFamilia = itens.Tables[0].Rows[linha].ItemArray[50].ToString(),
                    DescricaodaFamilia = itens.Tables[0].Rows[linha].ItemArray[51].ToString(),

                    CodEAN13 = itens.Tables[0].Rows[linha].ItemArray[52].ToString(),
                    EstoqueMinimo = Convert.ToDouble(itens.Tables[0].Rows[linha].ItemArray[53]),
                    EstoqueMáximo = Convert.ToDouble(itens.Tables[0].Rows[linha].ItemArray[54]),
                    Tolerancia = Convert.ToDouble(itens.Tables[0].Rows[linha].ItemArray[55]),
                    Leadtime = Convert.ToDouble(itens.Tables[0].Rows[linha].ItemArray[56]),

                    CodigodoRecolhimento = itens.Tables[0].Rows[linha].ItemArray[57].ToString(),
                    AliquotadeIPI = itens.Tables[0].Rows[linha].ItemArray[58].ToString(),
                    Livre1 = itens.Tables[0].Rows[linha].ItemArray[59].ToString(),
                    Livre2 = itens.Tables[0].Rows[linha].ItemArray[60].ToString(),
                    Livre3 = itens.Tables[0].Rows[linha].ItemArray[61].ToString(),

                    Livre4 = itens.Tables[0].Rows[linha].ItemArray[62].ToString(),
                    Livre5 = itens.Tables[0].Rows[linha].ItemArray[63].ToString(),
                    Livre6 = itens.Tables[0].Rows[linha].ItemArray[64].ToString(),
                    Livre7 = itens.Tables[0].Rows[linha].ItemArray[65].ToString(),
                    Livre8 = itens.Tables[0].Rows[linha].ItemArray[66].ToString(),

                    Livre9 = itens.Tables[0].Rows[linha].ItemArray[67].ToString(),
                    Livre10 = itens.Tables[0].Rows[linha].ItemArray[68].ToString(),
                    Livre11 = itens.Tables[0].Rows[linha].ItemArray[69].ToString(),
                    Livre12 = itens.Tables[0].Rows[linha].ItemArray[70].ToString(),
                    Livre13 = DateTime.Parse(itens.Tables[0].Rows[linha].ItemArray[71].ToString()),

                    Livre14 = DateTime.Parse(itens.Tables[0].Rows[linha].ItemArray[72].ToString()),
                    Livre15 = DateTime.Parse(itens.Tables[0].Rows[linha].ItemArray[73].ToString()),
                    Livre16 = DateTime.Parse(itens.Tables[0].Rows[linha].ItemArray[74].ToString()),
                    Livre17 = itens.Tables[0].Rows[linha].ItemArray[75].ToString(),
                    Livre18 = itens.Tables[0].Rows[linha].ItemArray[76].ToString(),

                    Livre19 = itens.Tables[0].Rows[linha].ItemArray[77].ToString(),
                    Livre20 = itens.Tables[0].Rows[linha].ItemArray[78].ToString(),
                    CodigodeServico = itens.Tables[0].Rows[linha].ItemArray[79].ToString(),
                    ContaContabil = itens.Tables[0].Rows[linha].ItemArray[80].ToString(),
                    ContaConsumo = itens.Tables[0].Rows[linha].ItemArray[81].ToString(),

                    CentrodeCusto = itens.Tables[0].Rows[linha].ItemArray[82].ToString(),
                    GeneroCotepe = itens.Tables[0].Rows[linha].ItemArray[83].ToString(),
                    TipoItemSped = itens.Tables[0].Rows[linha].ItemArray[84].ToString(),
                    CodigoProdutoSimilar = itens.Tables[0].Rows[linha].ItemArray[85].ToString(),
                    ValorUltFech = Convert.ToDouble(itens.Tables[0].Rows[linha].ItemArray[86]),

                    CustoMedioSimulado = Convert.ToDouble(itens.Tables[0].Rows[linha].ItemArray[87]),
                    CustoMedio = Convert.ToDouble(itens.Tables[0].Rows[linha].ItemArray[88]),
                    RESERVADO_11 = itens.Tables[0].Rows[linha].ItemArray[89].ToString(),
                    CodigodeTributacaoAM = itens.Tables[0].Rows[linha].ItemArray[90].ToString(),
                    GrupodeFamilia = itens.Tables[0].Rows[linha].ItemArray[91].ToString(),

                    DescricaoGrupoFamilia = itens.Tables[0].Rows[linha].ItemArray[92].ToString(),
                    DescricaoCompleta2 = itens.Tables[0].Rows[linha].ItemArray[93].ToString(),
                    Descricaos = itens.Tables[0].Rows[linha].ItemArray[94].ToString(),
                    CEST = itens.Tables[0].Rows[linha].ItemArray[95].ToString(),
                    Conta = itens.Tables[0].Rows[linha].ItemArray[96].ToString(),

                    DgConta = itens.Tables[0].Rows[linha].ItemArray[97].ToString(),
                    ContaCons = itens.Tables[0].Rows[linha].ItemArray[98].ToString(),
                    DgContaCons = itens.Tables[0].Rows[linha].ItemArray[99].ToString(),
                    CentroCusto = itens.Tables[0].Rows[linha].ItemArray[10].ToString(),
                    DgCentroCusto = itens.Tables[0].Rows[linha].ItemArray[101].ToString(),

                    PrecodeReposicao = itens.Tables[0].Rows[linha].ItemArray[102].ToString(),
                    Reinf = itens.Tables[0].Rows[linha].ItemArray[103].ToString(),
                    GoodsReceipt = itens.Tables[0].Rows[linha].ItemArray[104].ToString(),
                    DescricaodoGrupo = itens.Tables[0].Rows[linha].ItemArray[105].ToString(),
                    CodigodeTributacao = itens.Tables[0].Rows[linha].ItemArray[106].ToString(),

                    CodigodeTributacaoAlternativo = itens.Tables[0].Rows[linha].ItemArray[107].ToString(),
                    Familia = itens.Tables[0].Rows[linha].ItemArray[108].ToString(),
                    Formadepedir = itens.Tables[0].Rows[linha].ItemArray[109].ToString(),
                    FatorUnidadeNCM = itens.Tables[0].Rows[linha].ItemArray[110].ToString(),
                    Fatordaunidade = itens.Tables[0].Rows[linha].ItemArray[111].ToString(),

                    Unidadealternativaexportacao = itens.Tables[0].Rows[linha].ItemArray[112].ToString(),
                    FatorunidadeDIPIexportacao = itens.Tables[0].Rows[linha].ItemArray[113].ToString(),
                    Aplicacao = itens.Tables[0].Rows[linha].ItemArray[114].ToString()


                });

            }
            return ie;
        }

        */
    }
}