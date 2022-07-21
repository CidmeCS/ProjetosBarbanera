using ImportExportERP.Classes;
using ImportExportERP.Entidade;
using ImportExportERP.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImportExportERP
{
    public class PadronizarColunasDados
    {
        public static List<PedidoDeVenda> listaPV;

        public static FileStream st { get; private set; }
        public static StreamReader sr { get; private set; }
        public static string linha { get; private set; }
        public static Dictionary<string, int> dic { get; private set; }
        public static string fullpath { get; private set; }

        public static void ErroColunaPadrao(string linha, string arquivo)
        {
            //teste
            switch (arquivo)
            {
                case "SaldoDeTerceiro.txt": arquivo = "ExportSaldo.txt"; break;
                case "MovimentosTotal.txt": arquivo = "Movimentos.txt"; break;
            }

            List<string> ColunasFixas = null;
            switch (arquivo)
            {
                case "ExportSaldo.txt":
                    ColunasFixas = new List<string>() { "Produto", "Tradução" ,"Descrição" ,"Unid", "Lote", "Grupo", "Disponível", "Saldo Atual",
                    "Saldo Últ.Fech.", "Entradas", "Saídas", "Ped.Compras", "Ped.Vendas", "Consu.Prev.Os", "Já Requis.OS", "Prod.Prev.OS", "Prod.Entr.OS",
                    "Fora Estoque", "Trânsito", "De Terceiros", "Venda Consign.", "Compra Entr.Futura", "Venda Entr.Futura", "Compra  Consig", "Aguardando CQ",
                    "Estq. Mínimo", "Estq. Máximo", "Reserva De Vendas", "Prateleira", "Saldo (Pedido Data Entrega Excedida)", "Prev. Fabric.",
                    "Dias sem Movimento", "EMP_FIL", "ESTAB", "DEPOSITO", "QT_CCON", "GR1", "DESCR_2", "FORNECED_2", "RESERVADO_11",
                    "Valor Últ.Fech.", "Custo Médio", "Custo Médio Simulado", "Preço Lista Padrão", "Campo Livre 17" }; break;

                case "PedidosDeCompras.txt":
                    ColunasFixas = new List<string>() { "Pedido", "Data", "Entrega", "Produto", "Valor Unitário", "Preço Total", "Unidade", "Requisição", "Linha Req.",
                    "C.Custo", "Descrição Alternativa", "Fornecedor", "Indice", "Descrição da Moeda", "Quantidade", "Qtde. Entregue", "Linha Ped.", "Saldo", "Situação", "STA_REG", "Descrição",
                    "Observações", "Dig C.Custo", "Título", "Tradução", "Baixa Manual", "Baixa NF", "Unidade Estq.", "Qtde Estq", "EMP_FIL", "ESTAB", "DEPOSITO", "FORNEC", "NR_COTACAO", "OS",
                    "PRIORIDADE", "DT_ENT_PREV", "DT_ENT_ORIG", "DT_ULT_ENT", "PORC_ICM", "VEZES_ENT", "LISTA", "BASE_UNIT", "PERC_DESC", "PERC_IPI", "VLR_DESC", "VLR_IPI", "VR_ENTR", "SEQ_ALT",
                    "COD_TRIB", "TRAT_FISC", "COD_GEN", "CONTA", "DG_CONTA", "CONTA2", "DG_CONTA2", "C_CUSTO2", "DG_CCUSTO2", "GERA_FLUXO", "LIVRE", "BATCH_PROG", "BATCH_DATA", "BATCH_HORA",
                    "ESTAGIO", "DT_INIC_EXEC", "PERIODO", "PROJETO_OBRA", "PROJETO_ETAPA", "APROVADOR_PROX", "APROV_AVISADO", "DT_APROVACAO", "DT_VALIDADE", "SOLICITANTE", "UNID_FORN",
                    "FATOR_UN_FORN", "CUSTO_QT_SOLIC", "CUSTO_QT_APROV", "COND_PAGTO", "TIPO_DESPESA" }; break;
                case "PedidosDeComprasFULL.txt":
                    ColunasFixas = new List<string>() { "Pedido", "Data", "Entrega", "Produto", "Valor Unitário", "Preço Total", "Unidade", "Requisição", "Linha Req.",
                    "C.Custo", "Descrição Alternativa", "Fornecedor", "Indice", "Descrição da Moeda", "Quantidade", "Qtde. Entregue", "Linha Ped.", "Saldo", "Situação", "STA_REG", "Descrição",
                    "Observações", "Dig C.Custo", "Título", "Tradução", "Baixa Manual", "Baixa NF", "Unidade Estq.", "Qtde Estq", "EMP_FIL", "ESTAB", "DEPOSITO", "FORNEC", "NR_COTACAO", "OS",
                    "PRIORIDADE", "DT_ENT_PREV", "DT_ENT_ORIG", "DT_ULT_ENT", "PORC_ICM", "VEZES_ENT", "LISTA", "BASE_UNIT", "PERC_DESC", "PERC_IPI", "VLR_DESC", "VLR_IPI", "VR_ENTR", "SEQ_ALT",
                    "COD_TRIB", "TRAT_FISC", "COD_GEN", "CONTA", "DG_CONTA", "CONTA2", "DG_CONTA2", "C_CUSTO2", "DG_CCUSTO2", "GERA_FLUXO", "LIVRE", "BATCH_PROG", "BATCH_DATA", "BATCH_HORA",
                    "ESTAGIO", "DT_INIC_EXEC", "PERIODO", "PROJETO_OBRA", "PROJETO_ETAPA", "APROVADOR_PROX", "APROV_AVISADO", "DT_APROVACAO", "DT_VALIDADE", "SOLICITANTE", "UNID_FORN",
                    "FATOR_UN_FORN", "CUSTO_QT_SOLIC", "CUSTO_QT_APROV", "COND_PAGTO", "TIPO_DESPESA" }; break;

                case "PedidosDeVendas.txt":
                    ColunasFixas = new List<string>() { "Data Entrega", "Seq", "Saldo", "Quantidade", "Status do Item", "Data Pedido", "Vendedor", "Bloq",
                        "Motivos Bloqueio", "Disponível", "Descrição", "Estabelecimento", "Nº Pedido", "Depósito", "Item", "Ordem Compra", "Preço Unitário",
                        "Valor Total", "Razão Social", "Nome Fantasia", "Grupo Item", "Texto Específico", "Código Cliente", "DESCR_1", "DESCR_2",
                        "Venda Confirmada" }; break;

                case "Movimentos.txt":
                    ColunasFixas = new List<string>() {"Data", "TM", "Código", "Lote", "Documento", "AC", "Quantidade", "Valor Movimento", "OS", "Descrição",
                        "Unidade", "Tipo de Contabilização", "Cliente/Fornecedor", "Nome Fantasia", "Contabiliza", "Conta Contábil", "Díg.",
                        "Centro de Custo", "Díg.", "Livre 2", "Descr. Tipo Movto.", "CUSTO_INF", "Saldo Atual", "Cons. Médio", "VALOR", "DESC_RATEA",
                        "REF_LOTE", "QTDE_BRUTA", "FLAG", "EMP_FIL", "ESTAB", "DEPOSITO", "Custo Médio Simulado", "NR_TRANSF_CG", "Operador Inclusão",
                        "Data Inclusão", "Hora Inclusão", "Custo médio", "Roteiro", "Data Início Roteiro", "Quantidade Digitada", "Fator", "OPERACAO",
                        "Descr. Movto", "ID Etiqueta" }; break;
                case "MovimentosFULL.txt":
                    ColunasFixas = new List<string>() {"Data", "TM", "Código", "Lote", "Documento", "AC", "Quantidade", "Valor Movimento", "OS", "Descrição",
                        "Unidade", "Tipo de Contabilização", "Cliente/Fornecedor", "Nome Fantasia", "Contabiliza", "Conta Contábil", "Díg.",
                        "Centro de Custo", "Díg.", "Livre 2", "Descr. Tipo Movto.", "CUSTO_INF", "Saldo Atual", "Cons. Médio", "VALOR", "DESC_RATEA",
                        "REF_LOTE", "QTDE_BRUTA", "FLAG", "EMP_FIL", "ESTAB", "DEPOSITO", "Custo Médio Simulado", "NR_TRANSF_CG", "Operador Inclusão",
                        "Data Inclusão", "Hora Inclusão", "Custo médio", "Roteiro", "Data Início Roteiro", "Quantidade Digitada", "Fator", "OPERACAO",
                        "Descr. Movto", "ID Etiqueta" }; break;

                case "ForaDeEstoque.txt":
                    ColunasFixas = new List<string>() { "Op", "Doc.En", "Serie", "Produto", "Tradução", "TM", "Data", "Fornecedor", "Nome Fantasia", "UF",
                        "Doc. Fiscal", "Serie", "Contabiliza", "Lt", "Qtde Nf", "Valor Nf", "Valor Custo", "Saldo Qtde", "Saldo Custo", "Observação",
                        "Descrição", "Valor Unitário", "Texto Específico Fat. Balcão", "Obs NF Balcão", "TIPO_MOVTO_NF", "Estab", "Deposito",
                        "Tipo Contabilização", "NRO_FORNEC", "SEQ_FORNEC", "QT_ENVIADA", "VR_ENV_NF", "VR_ENVIADO", "QT_DEVOLV", "VR_DEV_NF", "VR_DEVOLV",
                        "Cont", "TIPO_FE", "SEQ", "EMP_FIL", "DT_VENCTO", "DT_DOC_F", "QT_FECH", "QT_FECH_AN", "VR_FECH", "VR_FECH_AN", "VR_FECH_NF",
                        "VR_FEAN_NF", "VRI_ENVIAD", "VRI_DEVOLV", "VRI_FECH", "VRI_FECH_AN", "VRU_ENVIAD", "VRU_DEVOLV", "VRU_FECH", "VRU_FECH_AN",
                        "REF_UNID", "REF_LOCAL", "C_CUSTO", "DG_CCUSTO", "C_CUSTO2", "DG_CCUSTO2", "CONTA", "DG_CONTA", "CONTA2", "DG_CONTA2",
                        "TIPO_CONTAB", "DATA_ALTER", "TIME_STAMP", "HORA_ALTER", "ORIGEM_MOVTO", "ORDEM_ENVIO" }; break;
                case "ForaDeEstoqueFULL.txt":
                    ColunasFixas = new List<string>() { "Op", "Doc.En", "Serie", "Produto", "Tradução", "TM", "Data", "Fornecedor", "Nome Fantasia", "UF",
                        "Doc. Fiscal", "Serie", "Contabiliza", "Lt", "Qtde Nf", "Valor Nf", "Valor Custo", "Saldo Qtde", "Saldo Custo", "Observação",
                        "Descrição", "Valor Unitário", "Texto Específico Fat. Balcão", "Obs NF Balcão", "TIPO_MOVTO_NF", "Estab", "Deposito",
                        "Tipo Contabilização", "NRO_FORNEC", "SEQ_FORNEC", "QT_ENVIADA", "VR_ENV_NF", "VR_ENVIADO", "QT_DEVOLV", "VR_DEV_NF", "VR_DEVOLV",
                        "Cont", "TIPO_FE", "SEQ", "EMP_FIL", "DT_VENCTO", "DT_DOC_F", "QT_FECH", "QT_FECH_AN", "VR_FECH", "VR_FECH_AN", "VR_FECH_NF",
                        "VR_FEAN_NF", "VRI_ENVIAD", "VRI_DEVOLV", "VRI_FECH", "VRI_FECH_AN", "VRU_ENVIAD", "VRU_DEVOLV", "VRU_FECH", "VRU_FECH_AN",
                        "REF_UNID", "REF_LOCAL", "C_CUSTO", "DG_CCUSTO", "C_CUSTO2", "DG_CCUSTO2", "CONTA", "DG_CONTA", "CONTA2", "DG_CONTA2",
                        "TIPO_CONTAB", "DATA_ALTER", "TIME_STAMP", "HORA_ALTER", "ORIGEM_MOVTO", "ORDEM_ENVIO" }; break;

                case "DeTerceiro.txt":
                    ColunasFixas = new List<string>() { "Op", "Doc.En", "Serie", "Produto", "Tradução", "TM", "Data", "Cliente", "Nome Fantasia", "UF",
                        "Doc. Fiscal", "Serie", "Contabiliza", "Lt", "Qtde Nf", "Valor Nf", "Valor Custo", "Saldo Qtde", "Saldo Custo", "Observação",
                        "Descrição", "Valor Unitário", "Texto Específico Fat. Balcão", "Obs NF Balcão", "TIPO_MOVTO_NF", "Estab", "Deposito",
                        "Tipo Contabilização", "NRO_FORNEC", "SEQ_FORNEC", "QT_ENVIADA", "VR_ENV_NF", "VR_ENVIADO", "QT_DEVOLV", "VR_DEV_NF", "VR_DEVOLV",
                        "Cont", "TIPO_FE", "SEQ", "EMP_FIL", "DT_VENCTO", "DT_DOC_F", "QT_FECH", "QT_FECH_AN", "VR_FECH", "VR_FECH_AN", "VR_FECH_NF",
                        "VR_FEAN_NF", "VRI_ENVIAD", "VRI_DEVOLV", "VRI_FECH", "VRI_FECH_AN", "VRU_ENVIAD", "VRU_DEVOLV", "VRU_FECH", "VRU_FECH_AN",
                        "REF_UNID", "REF_LOCAL", "C_CUSTO", "DG_CCUSTO", "C_CUSTO2", "DG_CCUSTO2", "CONTA", "DG_CONTA", "CONTA2", "DG_CONTA2",
                        "TIPO_CONTAB", "DATA_ALTER", "TIME_STAMP", "HORA_ALTER", "ORIGEM_MOVTO", "ORDEM_ENVIO" }; break;
                case "DeTerceiroFULL.txt":
                    ColunasFixas = new List<string>() { "Op", "Doc.En", "Serie", "Produto", "Tradução", "TM", "Data", "Cliente", "Nome Fantasia", "UF",
                        "Doc. Fiscal", "Serie", "Contabiliza", "Lt", "Qtde Nf", "Valor Nf", "Valor Custo", "Saldo Qtde", "Saldo Custo", "Observação",
                        "Descrição", "Valor Unitário", "Texto Específico Fat. Balcão", "Obs NF Balcão", "TIPO_MOVTO_NF", "Estab", "Deposito",
                        "Tipo Contabilização", "NRO_FORNEC", "SEQ_FORNEC", "QT_ENVIADA", "VR_ENV_NF", "VR_ENVIADO", "QT_DEVOLV", "VR_DEV_NF", "VR_DEVOLV",
                        "Cont", "TIPO_FE", "SEQ", "EMP_FIL", "DT_VENCTO", "DT_DOC_F", "QT_FECH", "QT_FECH_AN", "VR_FECH", "VR_FECH_AN", "VR_FECH_NF",
                        "VR_FEAN_NF", "VRI_ENVIAD", "VRI_DEVOLV", "VRI_FECH", "VRI_FECH_AN", "VRU_ENVIAD", "VRU_DEVOLV", "VRU_FECH", "VRU_FECH_AN",
                        "REF_UNID", "REF_LOCAL", "C_CUSTO", "DG_CCUSTO", "C_CUSTO2", "DG_CCUSTO2", "CONTA", "DG_CONTA", "CONTA2", "DG_CONTA2",
                        "TIPO_CONTAB", "DATA_ALTER", "TIME_STAMP", "HORA_ALTER", "ORIGEM_MOVTO", "ORDEM_ENVIO" }; break;

                case "ItensDeEstoque.txt":
                    ColunasFixas = new List<string>() { "Código", "Preco Compra", "Tradução", "Unidade", "Grupo", "Lotes", "NS", "Descrição",
                        "Quantidade Disponível", "Saldo Físico", "Quantidade por Unidade", "Cubagem(m³)", "Peso Bruto", "Peso Líquido", "Data da Compra",
                        "Prateleira", "Status", "Item Cadastrado Em", "Posição Fiscal", "Compl Posição Fiscal", "Unid. Alter. DIPI", "Fator Unid. DIPI",
                        "Procedência", "Un. Alter. DIPI", "EX da TIPI", "Cód. do Fabricante do Produto", "Exp Palm", "Preço Venda", "Contrato de Royalties",
                        "Linha/Licença", "Tipo do Prod.", "Código", "DESCR_1", "DESCR_2", "Descrição Completa", "Código Externo", "ESTAB", "DEPOSITO",
                        "Qtd Últ. Fech.", "ENTRADAS", "SAIDAS", "OS_PREVIST", "Fora de Estoque", "Vendas Consig", "Compras Consig", "Res. Vendas",
                        "Ped Venda", "Preço", "QT_ALT_OBR", "Emp. Req. Compra", "Unidade Alternativa", "Fator de Conversão", "Cód. Família",
                        "Descrição da Família", "Cod. EAN 13", "Estoque Mínimo", "Estoque Máximo", "% de Tolerância", "Leadtime", "Código do Recolhimento",
                        "Alíquota de IPI", "Livre 1", "Livre 2", "Livre 3", "Livre 4", "Livre 5", "Livre 6", "Livre 7", "Livre 8", "Livre 9", "Livre 10",
                        "Livre 11", "Livre 12", "Livre 13", "Livre 14", "Livre 15", "Livre 16", "Livre 17", "Livre 18", "Livre 19", "Livre 20",
                        "Código de Serviço", "Conta Contabil", "Conta Consumo", "Centro de Custo", "Gênero Cotepe", "Tipo Item Sped",
                        "Código Produto Similar", "Valor Últ. Fech.", "Custo Médio Simulado", "Custo Médio", "RESERVADO_11", "Código de Tributação AM",
                        "Grupo de Família", "Descrição Grupo Família", "Descrição Completa (   )", "Descrição (s/    )", "CEST", "Conta", "Dg Conta",
                        "Conta Cons", "Dg Conta Cons", "Centro Custo", "Dg Centro Custo", "Preço de Reposição", "Reinf", "Goods Receipt",
                        "Descrição do Grupo", "Código de Tributação", "Código de Tributação Alternativo", "Família", "Forma de pedir", "Fator Unidade NCM",
                        "Fator da unidade", "Unidade alternativa exportação", "Fator unidade DIPI exportação", "Aplicação", "Fabricação Terceiros",
                        "ID_FABRICACAO"}; break;
                case "DepositoDeTerceiro.txt":
                    ColunasFixas = new List<string>() { "Deposito", "Nome" }; break;

                case "ConsultaOrdensDeProducao.txt":
                    ColunasFixas = new List<string>() { "Nro. O.P.", "Status O.P.", "Estabelecimento", "Depósito", "Produto", "Tradução", "Quantidade Prev.",
                        "Quantidade Digitada", "Fator", "Saldo", "Roteiro", "Dt. Inic. Roteiro", "Dt. Abertura", "Hr. Abertura", "Programação", "Plano",
                        "Dt. Inic. Prod.", "Dt. Fim Prod.", "Ref. Lote", "Tipo de OP      ", "Descrição ", "Tipo de Custo", "Peso para Rateio 1",
                        "Peso para Rateio 2", "Peso para Rateio 3", "Peso para Rateio 4", "EMPRESA", "FILIAL", "STATUS", "Quantidade Apont.",
                        "NR_OP_ORIGEM", "Dt. Encerramento", "Dt. Cancelamento", "Dt. Liberação", "Hr. Encerramento", "Hr. Cancelamento", "Hr. Liberação",
                        "Hr. Inicio Prod.", "Hr. Fim Prod.", "COD_OBS_GEN", "Descrição 1", "Descrição 2", "Observação", "Doc. Origem", "Operador",
                        "Data Alter", "Hora Alter", "RESERVADO_02", "% Máx. Produção", "Grupo", "Descrição Grupo" }; break;
                case "ConsultaOrdensDeProducaoFULL.txt":
                    ColunasFixas = new List<string>() { "Nro. O.P.", "Status O.P.", "Estabelecimento", "Depósito", "Produto", "Tradução", "Quantidade Prev.",
                        "Quantidade Digitada", "Fator", "Saldo", "Roteiro", "Dt. Inic. Roteiro", "Dt. Abertura", "Hr. Abertura", "Programação", "Plano",
                        "Dt. Inic. Prod.", "Dt. Fim Prod.", "Ref. Lote", "Tipo de OP      ", "Descrição ", "Tipo de Custo", "Peso para Rateio 1",
                        "Peso para Rateio 2", "Peso para Rateio 3", "Peso para Rateio 4", "EMPRESA", "FILIAL", "STATUS", "Quantidade Apont.",
                        "NR_OP_ORIGEM", "Dt. Encerramento", "Dt. Cancelamento", "Dt. Liberação", "Hr. Encerramento", "Hr. Cancelamento", "Hr. Liberação",
                        "Hr. Inicio Prod.", "Hr. Fim Prod.", "COD_OBS_GEN", "Descrição 1", "Descrição 2", "Observação", "Doc. Origem", "Operador",
                        "Data Alter", "Hora Alter", "RESERVADO_02", "% Máx. Produção", "Grupo", "Descrição Grupo" }; break;

                case "NotasFiscaisDinamicaProduto.txt":
                    ColunasFixas = new List<string>() { "Nota Fiscal", "Série", "Fornecedor", "Linha", "Data Movimento", "Tipo Movto", "Estabelecimento",
                        "Depósito", "Produto", "Quantidade", "Peso Líquido", "Peso Bruto", "Valor Unitário", "Valor das Mercadorias",
                        "Valor Adicional Financeiro", "Valor Desconto", "Valor Embalagem", "Valor Frete", "Valor ICMS", "Valor ICMS Subst",
                        "Porcentagem ISS", "Valor IPI", "Valor ISS", "Valor PIS", "Valor COFINS", "Valor Seguro", "Porcentagem IR", "Valor IR Retido",
                        "Tratamento Fiscal", "CFOP", "Posição Fiscal", "Porcentagem ICMS", "Valor IPI Sobre Frete", "Vr. Desc. Zona Franca", "Doc Envio",
                        "Pedido", "ID Custo", "Valor INSS", "Nota Fiscal Origem", "Série NF Origem", "Centro de Custo", "Dig. C. Custo",
                        "Tipo de Contabilização", "% PIS", "% COFINS", "Número da DI", "Data de Emissão", "Território", "Vendedor", "Supervisor",
                        "Gerente", "Data de Saída", "Estado", "Emissão", "Observação no Livro", "Frete Pago/A Pagar", "Espécie NF", "Placa",
                        "Transportador", "IR Vencimento", "Porc. ICMS Subst", "CNPJ/CGC", "Nome Fantasia", "Descrição do Produto", "Valor Líquido",
                        "Desconto Zona Franca (%)", "Imposto de Importação", "Percent. PIS - Subst. Trib", "Valor PIS - Subst. Trib",
                        "Percent. COFINS Subst. Trib.", "Valor COFINS Subst. Trib.", "Valor de retenção de PIS", "Valor de retenção de COFINS",
                        "Valor de retenção de CSLL", "Desconto ICMS Conv. 100/97", "Valor FUNRURAL", "Despesas Aduaneiras", "Valor AFRMM", "Finalidade",
                        "Vr Base ICMS Subst. Trib. - Substituído Posterior", "Vr ICMS Subst. Trib. - Substituído Posterior", "Vr. FCP", "Vr. ICMS Dest.",
                        "Vr. ICMS Orig.", "Base de COFINS", "Base de PIS", "Valor INSS Retido", "ICMS ST - Operações de Frete", "Descrição Tipo Movimento",
                        "Número NF Eletrônica", "Descrição CFOP", "Descrição Pos. Fiscal", "CST PIS", "CST COFINS", "Razão Social", "EMP_FIL", "TIPO_MOVTO",
                        "COM_VEN", "ENTR_SAID", "ICM_SP", "INF_TRAD", "TEM_NFDA", "UNIDADE", "BASE_UNIT", "DT_VENCTO", "COND_PGTO", "QTDE_REC",
                        "QTDE_ALTER", "QT_ALT_REC", "TAB_PRECO", "COD_EMBAL", "VLR_DIF_ALIQ_ICMS", "VLR_REPASSE", "ADIC_IR_PERCENT", "ADIC_IR", "COD_TRIB",
                        "PORC_IPI", "PORC_ICM_S_FRETE", "PORC_IPI_S_FRETE", "BASE_ICM", "BASE_ICM_SUBST", "ICM_S_FRETE", "BASE_ICM_S_FRETE",
                        "BASE_IPI_S_FRETE", "BASE_IPI", "BONIF", "NRO_OS", "OPERACAO", "ITEM_PED", "ALT_ESTQ", "ALT_ESTQ_TERC", "ALT_CUSTO", "JA_PROC",
                        "PORC_COMIS", "PORC_COM_SUP", "PORC_COM_GER", "VR_COM_VEND", "VR_COM_SUP", "VR_COM_GER", "VR_COM_LQ_VEND", "VR_COM_LQ_SUP",
                        "NF_ULT_COMPRA", "SR_ULT_COMPRA", "FORN_ULT_COMPRA", "PR_ULT_COMPRA", "TEXTO_ESP", "TEXTO_GEN", "EXPORTA_MV", "SERV_OFICINA",
                        "REF_LOTE", "REF_UNID", "REF_LOCAL", "NOP", "COD_SERV", "LOCAL_CC", "LIVRE", "CONTA", "DG_CONTA", "CONTA2", "DG_CONTA2", "C_CUSTO2",
                        "DG_C_CUSTO2", "NR_TRANSF_CG", "COD_ERRO1", "COD_ERRO2", "COD_ERRO3", "VLR_MATERIAIS", "VLR_SUB_EMPR", "PORC_DESC_PV",
                        "PORC_ADF_PV", "OPERADOR", "DATA_ALTER", "HORA_ALTER", "TIME_STAMP", "RESERVADO_01", "RESERVADO_02", "RESERVADO_03",
                        "RESERVADO_04", "RESERVADO_05", "RESERVADO_06", "RESERVADO_07", "RESERVADO_08", "RESERVADO_09", "RESERVADO_10", "RESERVADO_11",
                        "RESERVADO_12", "RESERVADO_13", "DT_EMISSAO_1", "CFO_1", "VLR_ICM_BSTP", "VLR_ICM_STP", "NRO_PED", "DT_PED", "VLR_FCP_ST" }; break;
                case "NotasFiscaisDinamicaProdutoFULL.txt":
                    ColunasFixas = new List<string>() { "Nota Fiscal", "Série", "Fornecedor", "Linha", "Data Movimento", "Tipo Movto", "Estabelecimento",
                        "Depósito", "Produto", "Quantidade", "Peso Líquido", "Peso Bruto", "Valor Unitário", "Valor das Mercadorias",
                        "Valor Adicional Financeiro", "Valor Desconto", "Valor Embalagem", "Valor Frete", "Valor ICMS", "Valor ICMS Subst",
                        "Porcentagem ISS", "Valor IPI", "Valor ISS", "Valor PIS", "Valor COFINS", "Valor Seguro", "Porcentagem IR", "Valor IR Retido",
                        "Tratamento Fiscal", "CFOP", "Posição Fiscal", "Porcentagem ICMS", "Valor IPI Sobre Frete", "Vr. Desc. Zona Franca", "Doc Envio",
                        "Pedido", "ID Custo", "Valor INSS", "Nota Fiscal Origem", "Série NF Origem", "Centro de Custo", "Dig. C. Custo",
                        "Tipo de Contabilização", "% PIS", "% COFINS", "Número da DI", "Data de Emissão", "Território", "Vendedor", "Supervisor",
                        "Gerente", "Data de Saída", "Estado", "Emissão", "Observação no Livro", "Frete Pago/A Pagar", "Espécie NF", "Placa",
                        "Transportador", "IR Vencimento", "Porc. ICMS Subst", "CNPJ/CGC", "Nome Fantasia", "Descrição do Produto", "Valor Líquido",
                        "Desconto Zona Franca (%)", "Imposto de Importação", "Percent. PIS - Subst. Trib", "Valor PIS - Subst. Trib",
                        "Percent. COFINS Subst. Trib.", "Valor COFINS Subst. Trib.", "Valor de retenção de PIS", "Valor de retenção de COFINS",
                        "Valor de retenção de CSLL", "Desconto ICMS Conv. 100/97", "Valor FUNRURAL", "Despesas Aduaneiras", "Valor AFRMM", "Finalidade",
                        "Vr Base ICMS Subst. Trib. - Substituído Posterior", "Vr ICMS Subst. Trib. - Substituído Posterior", "Vr. FCP", "Vr. ICMS Dest.",
                        "Vr. ICMS Orig.", "Base de COFINS", "Base de PIS", "Valor INSS Retido", "ICMS ST - Operações de Frete", "Descrição Tipo Movimento",
                        "Número NF Eletrônica", "Descrição CFOP", "Descrição Pos. Fiscal", "CST PIS", "CST COFINS", "Razão Social", "EMP_FIL", "TIPO_MOVTO",
                        "COM_VEN", "ENTR_SAID", "ICM_SP", "INF_TRAD", "TEM_NFDA", "UNIDADE", "BASE_UNIT", "DT_VENCTO", "COND_PGTO", "QTDE_REC",
                        "QTDE_ALTER", "QT_ALT_REC", "TAB_PRECO", "COD_EMBAL", "VLR_DIF_ALIQ_ICMS", "VLR_REPASSE", "ADIC_IR_PERCENT", "ADIC_IR", "COD_TRIB",
                        "PORC_IPI", "PORC_ICM_S_FRETE", "PORC_IPI_S_FRETE", "BASE_ICM", "BASE_ICM_SUBST", "ICM_S_FRETE", "BASE_ICM_S_FRETE",
                        "BASE_IPI_S_FRETE", "BASE_IPI", "BONIF", "NRO_OS", "OPERACAO", "ITEM_PED", "ALT_ESTQ", "ALT_ESTQ_TERC", "ALT_CUSTO", "JA_PROC",
                        "PORC_COMIS", "PORC_COM_SUP", "PORC_COM_GER", "VR_COM_VEND", "VR_COM_SUP", "VR_COM_GER", "VR_COM_LQ_VEND", "VR_COM_LQ_SUP",
                        "NF_ULT_COMPRA", "SR_ULT_COMPRA", "FORN_ULT_COMPRA", "PR_ULT_COMPRA", "TEXTO_ESP", "TEXTO_GEN", "EXPORTA_MV", "SERV_OFICINA",
                        "REF_LOTE", "REF_UNID", "REF_LOCAL", "NOP", "COD_SERV", "LOCAL_CC", "LIVRE", "CONTA", "DG_CONTA", "CONTA2", "DG_CONTA2", "C_CUSTO2",
                        "DG_C_CUSTO2", "NR_TRANSF_CG", "COD_ERRO1", "COD_ERRO2", "COD_ERRO3", "VLR_MATERIAIS", "VLR_SUB_EMPR", "PORC_DESC_PV",
                        "PORC_ADF_PV", "OPERADOR", "DATA_ALTER", "HORA_ALTER", "TIME_STAMP", "RESERVADO_01", "RESERVADO_02", "RESERVADO_03",
                        "RESERVADO_04", "RESERVADO_05", "RESERVADO_06", "RESERVADO_07", "RESERVADO_08", "RESERVADO_09", "RESERVADO_10", "RESERVADO_11",
                        "RESERVADO_12", "RESERVADO_13", "DT_EMISSAO_1", "CFO_1", "VLR_ICM_BSTP", "VLR_ICM_STP", "NRO_PED", "DT_PED", "VLR_FCP_ST" }; break;
            }

            var ColunasExport = linha.Replace("\"", "").Replace("'", "").Split('\t').ToList();
            var BasicaFaltando = ColunasFixas.Except(ColunasExport).ToList();
            var ExportSobrando = ColunasExport.Except(ColunasFixas).ToList();
            if (BasicaFaltando.Count != 0)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var item in BasicaFaltando)
                {
                    sb.AppendLine(item);
                }

                Mensagerias.Send($"As colunas abaixo nao existem no ultimo export feito. {arquivo}\n" +
                    "Elas precisam constar via export (ERP Pronto)\nou mudar a estrutura basica da aplicação na classe, nos métodos e no banco de dados (CUIDADO).\n\n" +
                    sb.ToString() + "\nERRO XP45\n---------------------------------\n");

                var x = Process.GetProcesses();
                foreach (Process p in x)
                {
                    if (p.MainWindowTitle == "frmExport")
                    {
                        if (p.ProcessName == "ImportExportERP")
                        {
                            p.CloseMainWindow();
                        }
                    }

                }
            }
        }

        private static Dictionary<string, int> ColunarPadrao(string linha)
        {

            var xp = linha.Replace("\"", "").Replace("'", "").Split('\t');
            Dictionary<string, int> valor = new Dictionary<string, int>();

            int i = 0;

            foreach (var x in xp)
            {
                try
                {
                    valor.Add(x, i);
                }
                catch (Exception e)
                {
                    valor.Add(x + 2, i);
                }
                i++;
            }

            return valor;
        }

        private static void ObterLinha()
        {
            try
            {
                st = File.OpenRead(fullpath);
            }
            catch (Exception e)
            {
                Mensagerias.Send(e.Message + "\n---------\n");
            }
            sr = new StreamReader(st, Encoding.Default);
            linha = sr.ReadLine();
            ErroColunaPadrao(linha, Path.GetFileName(fullpath));
            dic = ColunarPadrao(linha);
        }


        //Saldo
        internal static List<Saldo> Saldo()
        {
            fullpath = @"C:\Exports\ExportSaldo.txt";
            ObterLinha();
            List<Saldo> lista = new List<Saldo>();


            while ((linha = sr.ReadLine()) != null)
            {



                string[] b = new string[dic.Count];

                b = linha.Replace("\"", "").Replace("'", "").Split('\t');
                string produto = "", traducao = "", descricao = "", unid = "", lote = "", grupo = "", disponivel = "", saldoatual = "",
                        saldoultfech = "", entradas = "", saidas = "", pedcompras = "", pedvendas = "", consuprevos = "", jarequisos = "", prodprevos = "",
                        prodentros = "", foraestoque = "", transito = "", deterceiros = "", vendaconsign = "", compraentrfutura = "", vendaentrfutura = "",
                        compraconsig = "", aguardandocq = "", estqminimo = "", estqmaximo = "", reservadevendas = "", prateleira = "",
                        saldopedidodataentregaexcedida = "", prevfabric = "", diassemmovimento = "", emp_fil = "", estab = "", deposito = "", qt_ccon = "",
                        gr1 = "", descr_2 = "", forneced_2 = "", reservado_11 = "", valorultfech = "", customediosimulado = "",
                        customedio = "", precolistapadrao = "", descricao2 = "", livre17 = "";

                foreach (var dc in dic)
                {
                    switch (dc.Key)
                    {

                        case "Produto": produto = b[dc.Value].Trim(); break;
                        case "Tradução": traducao = b[dc.Value].Trim(); break;
                        case "Descrição": descricao = b[dc.Value].Trim(); break;
                        case "Unid": unid = b[dc.Value].Trim(); break;
                        case "Lote": lote = b[dc.Value].Trim(); break;
                        case "Grupo": grupo = b[dc.Value].Trim(); break;
                        case "Disponível": disponivel = Math.Round(Convert.ToDouble(b[dc.Value].Trim()), 3).ToString(); break;
                        case "Saldo Atual": saldoatual = Math.Round(Convert.ToDouble(b[dc.Value].Trim()), 3).ToString(); break;
                        case "Saldo Últ.Fech.": saldoultfech = b[dc.Value].Trim(); break;
                        case "Entradas": entradas = b[dc.Value].Trim(); break;
                        case "Saídas": saidas = b[dc.Value].Trim(); break;
                        case "Ped.Compras": pedcompras = b[dc.Value].Trim(); break;
                        case "Ped.Vendas": pedvendas = b[dc.Value].Trim(); break;
                        case "Consu.Prev.Os": consuprevos = b[dc.Value].Trim(); break;
                        case "Já Requis.OS": jarequisos = b[dc.Value].Trim(); break;
                        case "Prod.Prev.OS": prodprevos = b[dc.Value].Trim(); break;
                        case "Prod.Entr.OS": prodentros = b[dc.Value].Trim(); break;
                        case "Fora Estoque": foraestoque = b[dc.Value].Trim(); break;
                        case "Trânsito": transito = b[dc.Value].Trim(); break;
                        case "De Terceiros": deterceiros = b[dc.Value].Trim(); break;
                        case "Venda Consign.": vendaconsign = b[dc.Value].Trim(); break;
                        case "Compra Entr.Futura": compraentrfutura = b[dc.Value].Trim(); break;
                        case "Venda Entr.Futura": vendaentrfutura = b[dc.Value].Trim(); break;
                        case "Compra  Consig": compraconsig = b[dc.Value].Trim(); break;
                        case "Aguardando CQ": aguardandocq = b[dc.Value].Trim(); break;
                        case "Estq. Mínimo": estqminimo = b[dc.Value].Trim(); break;
                        case "Estq. Máximo": estqmaximo = b[dc.Value].Trim(); break;
                        case "Reserva De Vendas": reservadevendas = b[dc.Value].Trim(); break;
                        case "Prateleira": prateleira = b[dc.Value].Trim(); break;
                        case "Saldo (Pedido Data Entrega Excedida)": saldopedidodataentregaexcedida = b[dc.Value].Trim(); break;
                        case "Prev. Fabric.": prevfabric = b[dc.Value].Trim(); break;
                        case "Dias sem Movimento": diassemmovimento = b[dc.Value].Trim(); break;
                        case "ESTAB": estab = b[dc.Value].Trim(); break;
                        case "DEPOSITO": deposito = b[dc.Value].Trim(); break;
                        case "EMP_FIL": emp_fil = b[dc.Value].Trim(); break;
                        case "QT_CCON": qt_ccon = b[dc.Value].Trim(); break;
                        case "GR1": gr1 = b[dc.Value].Trim(); break;
                        case "DESCR_2": descr_2 = b[dc.Value].Trim(); break;
                        case "FORNECED_2": forneced_2 = b[dc.Value].Trim(); break;
                        case "RESERVADO_11": reservado_11 = b[dc.Value].Trim(); break;
                        case "Valor Últ.Fech.": valorultfech = b[dc.Value].Trim(); break;
                        case "Custo Médio Simulado": customediosimulado = b[dc.Value].Trim(); break;
                        case "Custo Médio": customedio = b[dc.Value].Trim(); break;
                        case "Preço Lista Padrão": precolistapadrao = b[dc.Value].Trim(); break;
                        case "Descrição2": descricao2 = b[dc.Value].Trim(); break;
                        case "Campo Livre 17": livre17 = b[dc.Value].Trim(); break;
                    }
                }
                lista.Add(new Saldo
                {
                    Produto = produto,
                    Traducao = traducao,
                    Descricao = descricao,
                    Unid = unid,
                    Lote = lote,
                    Grupo = grupo,
                    Disponivel = Convert.ToDouble(disponivel),
                    SaldoAtual = Convert.ToDouble(saldoatual),
                    SaldoUltFech = Convert.ToDouble(saldoultfech),
                    Entradas = Convert.ToDouble(entradas),
                    Saidas = Convert.ToDouble(saidas),
                    PedCompras = Convert.ToDouble(pedcompras),
                    PedVendas = Convert.ToDouble(pedvendas),
                    ConsuPrevOs = Convert.ToDouble(consuprevos),
                    JaRequisOS = Convert.ToDouble(jarequisos),
                    ProdPrevOS = Convert.ToDouble(prodprevos),
                    ProdEntrOS = Convert.ToDouble(prodentros),
                    ForaEstoque = Convert.ToDouble(foraestoque),
                    Transito = Convert.ToDouble(transito),
                    DeTerceiros = Convert.ToDouble(deterceiros),
                    VendaConsign = Convert.ToDouble(vendaconsign),
                    CompraEntrFutura = Convert.ToDouble(compraentrfutura),
                    VendaEntrFutura = Convert.ToDouble(vendaentrfutura),
                    CompraConsig = Convert.ToDouble(compraconsig),
                    AguardandoCQ = Convert.ToDouble(aguardandocq),
                    EstqMinimo = Convert.ToDouble(estqminimo),
                    EstqMaximo = Convert.ToDouble(estqmaximo),
                    ReservaDeVendas = Convert.ToDouble(reservadevendas),
                    Prateleira = prateleira,
                    SaldoPedidoDataEntregaExcedida = Convert.ToDouble(saldopedidodataentregaexcedida),
                    PrevFabric = Convert.ToDouble(prevfabric),
                    DiassemMovimento = Convert.ToDouble(diassemmovimento),
                    EMP_FIL = emp_fil,
                    ESTAB = estab,
                    DEPOSITO = deposito,
                    QT_CCON = qt_ccon,
                    GR1 = gr1,
                    DESCR_2 = descr_2,
                    FORNECED_2 = forneced_2,
                    RESERVADO_11 = Convert.ToDouble(reservado_11),
                    ValorUltFech = Convert.ToDouble(valorultfech),
                    CustoMedioSimulado = Convert.ToDouble(customediosimulado),
                    CustoMedio = Convert.ToDouble(customedio),
                    PrecoListaPadrao = Convert.ToDouble(precolistapadrao),
                    Descricao2 = descricao2,
                    Livre17 = livre17 == "" ? 0 : Convert.ToDecimal(livre17),
                });
            }
            sr.Close();
            st.Close();
            return lista;
        }

        //PedidoDeCompra
        internal static List<PedidoDeCompra> PedidoDeCompra(string path)
        {
            fullpath = path;
            ObterLinha();
            List<PedidoDeCompra> lista = new List<PedidoDeCompra>();

            while ((linha = sr.ReadLine()) != null)
            {



                string[] b = new string[dic.Count];

                b = linha.Replace("\"", "").Replace("'", "").Split('\t');

                string pedido = "", data = "", entrega = "", produto = "", valorunitario = "", precototal = "", unidade = "", requisicao = "", linhareq = "", ccusto = "",
                    descricaoalternativa = "", fornecedor = "", indice = "", descricaodamoeda = "", quantidade = "", qtdeentregue = "", linhaped = "", saldo = "",
                    situacao = "", sta_reg = "", descricao = "", observacoes = "", digccusto = "", titulo = "", traducao = "", baixamanual = "", baixanf = "",
                    unidadeestq = "", qtdeestq = "", emp_fil = "", estab = "", deposito = "", fornec = "", nr_cotacao = "", os = "", prioridade = "", dt_ent_prev = "",
                    dt_ent_orig = "", dt_ult_ent = "", porc_icm = "", vezes_ent = "", listaa = "", base_unit = "", perc_desc = "", perc_ipi = "", vlr_desc = "", vlr_ipi = "",
                    vr_entr = "", seq_alt = "", cod_trib = "", trat_fisc = "", cod_gen = "", conta = "", dg_conta = "", conta2 = "", dg_conta2 = "", c_custo2 = "",
                    dg_ccusto2 = "", gera_fluxo = "", livre = "", batch_prog = "", batch_data = "", batch_hora = "", estagio = "", dt_inic_exec = "", periodo = "",
                    projeto_obra = "", projeto_etapa = "", aprovador_prox = "", aprov_avisado = "", dt_aprovacao = "", dt_validade = "", solicitante = "", unid_forn = "",
                    fator_un_forn = "", custo_qt_solic = "", custo_qt_aprov = "", cond_pagto = "", tipo_despesa = "";
                ;

                foreach (var dc in dic)
                {
                    switch (dc.Key)
                    {
                        case "Pedido": pedido = b[dc.Value].Trim(); break;
                        case "Data": data = b[dc.Value].Trim(); break;
                        case "Entrega": entrega = b[dc.Value].Trim(); break;
                        case "Produto": produto = b[dc.Value].Trim(); break;
                        case "Valor Unitário": valorunitario = b[dc.Value].Trim(); break;
                        case "Preço Total": precototal = b[dc.Value].Trim(); break;
                        case "Unidade": unidade = b[dc.Value].Trim(); break;
                        case "Requisição": requisicao = b[dc.Value].Trim(); break;
                        case "Linha Req.": linhareq = b[dc.Value].Trim(); break;
                        case "C.Custo": ccusto = b[dc.Value].Trim(); break;
                        case "Descrição Alternativa": descricaoalternativa = b[dc.Value].Trim(); break;
                        case "Fornecedor": fornecedor = b[dc.Value].Trim(); break;
                        case "Indice": indice = b[dc.Value].Trim(); break;
                        case "Descrição da Moeda": descricaodamoeda = b[dc.Value].Trim(); break;
                        case "Quantidade": quantidade = b[dc.Value].Trim(); break;
                        case "Qtde. Entregue": qtdeentregue = b[dc.Value].Trim(); break;
                        case "Linha Ped.": linhaped = b[dc.Value].Trim(); break;
                        case "Saldo": saldo = b[dc.Value].Trim(); break;
                        case "Situação": situacao = b[dc.Value].Trim(); break;
                        case "STA_REG": sta_reg = b[dc.Value].Trim(); break;
                        case "Descrição": descricao = b[dc.Value].Trim(); break;
                        case "Observações": observacoes = b[dc.Value].Trim(); break;
                        case "Dig C.Custo": digccusto = b[dc.Value].Trim(); break;
                        case "Título": titulo = b[dc.Value].Trim(); break;
                        case "Tradução": traducao = b[dc.Value].Trim(); break;
                        case "Baixa Manual": baixamanual = b[dc.Value].Trim(); break;
                        case "Baixa NF": baixanf = b[dc.Value].Trim(); break;
                        case "Unidade Estq.": unidadeestq = b[dc.Value].Trim(); break;
                        case "Qtde Estq": qtdeestq = b[dc.Value].Trim(); break;
                        case "EMP_FIL": emp_fil = b[dc.Value].Trim(); break;
                        case "ESTAB": estab = b[dc.Value].Trim(); break;
                        case "DEPOSITO": deposito = b[dc.Value].Trim(); break;
                        case "FORNEC": fornec = b[dc.Value].Trim(); break;
                        case "NR_COTACAO": nr_cotacao = b[dc.Value].Trim(); break;
                        case "OS": os = b[dc.Value].Trim(); break;
                        case "PRIORIDADE": prioridade = b[dc.Value].Trim(); break;
                        case "DT_ENT_PREV": dt_ent_prev = b[dc.Value].Trim(); break;
                        case "DT_ENT_ORIG": dt_ent_orig = b[dc.Value].Trim(); break;
                        case "DT_ULT_ENT": dt_ult_ent = b[dc.Value].Trim(); break;
                        case "PORC_ICM": porc_icm = b[dc.Value].Trim(); break;
                        case "VEZES_ENT": vezes_ent = b[dc.Value].Trim(); break;
                        case "LISTA": listaa = b[dc.Value].Trim(); break;
                        case "BASE_UNIT": base_unit = b[dc.Value].Trim(); break;
                        case "PERC_DESC": perc_desc = b[dc.Value].Trim(); break;
                        case "PERC_IPI": perc_ipi = b[dc.Value].Trim(); break;
                        case "VLR_DESC": vlr_desc = b[dc.Value].Trim(); break;
                        case "VLR_IPI": vlr_ipi = b[dc.Value].Trim(); break;
                        case "VR_ENTR": vr_entr = b[dc.Value].Trim(); break;
                        case "SEQ_ALT": seq_alt = b[dc.Value].Trim(); break;
                        case "COD_TRIB": cod_trib = b[dc.Value].Trim(); break;
                        case "TRAT_FISC": trat_fisc = b[dc.Value].Trim(); break;
                        case "COD_GEN": cod_gen = b[dc.Value].Trim(); break;
                        case "CONTA": conta = b[dc.Value].Trim(); break;
                        case "DG_CONTA": dg_conta = b[dc.Value].Trim(); break;
                        case "CONTA2": conta2 = b[dc.Value].Trim(); break;
                        case "DG_CONTA2": dg_conta2 = b[dc.Value].Trim(); break;
                        case "C_CUSTO2": c_custo2 = b[dc.Value].Trim(); break;
                        case "DG_CCUSTO2": dg_ccusto2 = b[dc.Value].Trim(); break;
                        case "GERA_FLUXO": gera_fluxo = b[dc.Value].Trim(); break;
                        case "LIVRE": livre = b[dc.Value].Trim(); break;
                        case "BATCH_PROG": batch_prog = b[dc.Value].Trim(); break;
                        case "BATCH_DATA": batch_data = b[dc.Value].Trim(); break;
                        case "BATCH_HORA": batch_hora = b[dc.Value].Trim(); break;
                        case "ESTAGIO": estagio = b[dc.Value].Trim(); break;
                        case "DT_INIC_EXEC": dt_inic_exec = b[dc.Value].Trim(); break;
                        case "PERIODO": periodo = b[dc.Value].Trim(); break;
                        case "PROJETO_OBRA": projeto_obra = b[dc.Value].Trim(); break;
                        case "PROJETO_ETAPA": projeto_etapa = b[dc.Value].Trim(); break;
                        case "APROVADOR_PROX": aprovador_prox = b[dc.Value].Trim(); break;
                        case "APROV_AVISADO": aprov_avisado = b[dc.Value].Trim(); break;
                        case "DT_APROVACAO": dt_aprovacao = b[dc.Value].Trim(); break;
                        case "DT_VALIDADE": dt_validade = b[dc.Value].Trim(); break;
                        case "SOLICITANTE": solicitante = b[dc.Value].Trim(); break;
                        case "UNID_FORN": unid_forn = b[dc.Value].Trim(); break;
                        case "FATOR_UN_FORN": fator_un_forn = b[dc.Value].Trim(); break;
                        case "CUSTO_QT_SOLIC": custo_qt_solic = b[dc.Value].Trim(); break;
                        case "CUSTO_QT_APROV": custo_qt_aprov = b[dc.Value].Trim(); break;
                        case "COND_PAGTO": cond_pagto = b[dc.Value].Trim(); break;
                        case "TIPO_DESPESA": tipo_despesa = b[dc.Value].Trim(); break;

                    }

                }
                lista.Add(new PedidoDeCompra
                {
                    Pedido = pedido,
                    Data = Convert.ToDateTime(data),
                    Entrega = Convert.ToDateTime(entrega),
                    Produto = produto,
                    ValorUnitario = Convert.ToDouble(valorunitario),
                    PrecoTotal = Convert.ToDouble(precototal),
                    Unidade = unidade,
                    Requisicao = requisicao,
                    LinhaReq = linhareq,
                    CCusto = ccusto,
                    DescricaoAlternativa = descricaoalternativa,
                    Fornecedor = fornecedor,
                    Indice = indice,
                    DescricaodaMoeda = descricaodamoeda,
                    Quantidade = Convert.ToDouble(quantidade),
                    QtdeEntregue = Convert.ToDouble(qtdeentregue),
                    LinhaPed = linhaped,
                    Saldo = Convert.ToDouble(saldo),
                    Situacao = situacao,
                    STA_REG = sta_reg,
                    Descricao = descricao,
                    Observacoes = observacoes,
                    DigCCusto = digccusto,
                    Título = titulo,
                    Traducao = traducao,
                    BaixaManual = baixamanual,
                    BaixaNF = baixanf,
                    UnidadeEstq = unidadeestq,
                    QtdeEstq = qtdeestq,
                    EMP_FIL = emp_fil,
                    ESTAB = estab,
                    DEPOSITO = deposito,
                    FORNEC = fornec,
                    NR_COTACAO = nr_cotacao,
                    OS = os,
                    PRIORIDADE = prioridade,
                    DT_ENT_PREV = dt_ent_prev,
                    DT_ENT_ORIG = dt_ent_orig,
                    DT_ULT_ENT = dt_ult_ent,
                    PORC_ICM = porc_icm,
                    VEZES_ENT = vezes_ent,
                    LISTA = listaa,
                    BASE_UNIT = base_unit,
                    PERC_DESC = perc_desc,
                    PERC_IPI = perc_ipi,
                    VLR_DESC = vlr_desc,
                    VLR_IPI = vlr_ipi,
                    VR_ENTR = vr_entr,
                    SEQ_ALT = seq_alt,
                    COD_TRIB = cod_trib,
                    TRAT_FISC = trat_fisc,
                    COD_GEN = cod_gen,
                    CONTA = conta,
                    DG_CONTA = dg_conta,
                    CONTA2 = conta2,
                    DG_CONTA2 = dg_conta2,
                    C_CUSTO2 = c_custo2,
                    DG_CCUSTO2 = dg_ccusto2,
                    GERA_FLUXO = gera_fluxo,
                    LIVRE = livre,
                    BATCH_PROG = batch_prog,
                    BATCH_DATA = batch_data,
                    BATCH_HORA = batch_hora,
                    ESTAGIO = estagio,
                    DT_INIC_EXEC = dt_inic_exec,
                    PERIODO = periodo,
                    PROJETO_OBRA = projeto_obra,
                    PROJETO_ETAPA = projeto_etapa,
                    APROVADOR_PROX = aprovador_prox,
                    APROV_AVISADO = aprov_avisado,
                    DT_APROVACAO = dt_aprovacao,
                    DT_VALIDADE = dt_validade,
                    SOLICITANTE = solicitante,
                    UNID_FORN = unid_forn,
                    FATOR_UN_FORN = fator_un_forn,
                    CUSTO_QT_SOLIC = custo_qt_solic,
                    CUSTO_QT_APROV = custo_qt_aprov,
                    COND_PAGTO = cond_pagto,
                    TIPO_DESPESA = tipo_despesa,


                });
                Console.WriteLine("Pedido: " + pedido);
            }
            sr.Close();
            st.Close();
            return lista;
        }

        //PedidoDeVenda
        internal static List<PedidoDeVenda> PedidoDeVenda()
        {
            fullpath = @"C:\Exports\PedidosDeVendas.txt";
            ObterLinha();
            listaPV = new List<PedidoDeVenda>();

            while ((linha = sr.ReadLine()) != null)
            {


                string[] b = new string[dic.Count];
                b = linha.Replace("\"", "").Replace("'", "").Split('\t');
                string dataentrega = "", seq = "", quantidade = "", statusdoitem = "", datapedido = "", vendedor = "", item = "", bloq = "", estabelecimento = "",
                    motivosbloqueio = "", disponivel = "", npedido = "", descricao = "", deposito = "", ordemcompra = "", precounitário = "", valortotal = "",
                    razaosocial = "", codigocliente = "", descr_1 = "", descr_2 = "", vendaconfirmada = "", nomefantasia = "", grupoitem = "", textoespecifico = "";

                foreach (var dc in dic)
                {
                    switch (dc.Key)
                    {
                        case "Data Entrega": dataentrega = b[dc.Value].Trim(); break;
                        case "Seq": seq = b[dc.Value].Trim(); break;
                        case "Quantidade": quantidade = b[dc.Value].Trim(); break;
                        case "Status do Item": statusdoitem = b[dc.Value].Trim(); break;
                        case "Data Pedido": datapedido = b[dc.Value].Trim(); break;
                        case "Motivos Bloqueio": motivosbloqueio = b[dc.Value].Trim(); break;
                        case "Vendedor": vendedor = b[dc.Value].Trim(); break;
                        case "Nº Pedido": npedido = b[dc.Value].Trim(); break;
                        case "Bloq": bloq = b[dc.Value].Trim(); break;
                        case "Item": item = b[dc.Value].Trim(); break;
                        case "Descrição": descricao = b[dc.Value].Trim(); break;
                        case "Disponível": disponivel = b[dc.Value].Trim(); break;
                        case "Depósito": deposito = b[dc.Value].Trim(); break;
                        case "Estabelecimento": estabelecimento = b[dc.Value].Trim(); break;
                        case "Ordem Compra": ordemcompra = b[dc.Value].Trim(); break;
                        case "Preço Unitário": precounitário = b[dc.Value].Trim(); break;
                        case "Valor Total": valortotal = b[dc.Value].Trim(); break;
                        case "Razão Social": razaosocial = b[dc.Value].Trim(); break;
                        case "Nome Fantasia": nomefantasia = b[dc.Value].Trim(); break;
                        case "Grupo Item": grupoitem = b[dc.Value].Trim(); break;
                        case "Texto Específico": textoespecifico = b[dc.Value].Trim(); break;
                        case "Código Cliente": codigocliente = b[dc.Value].Trim(); break;
                        case "DESCR_1": descr_1 = b[dc.Value].Trim(); break;
                        case "DESCR_2": descr_2 = b[dc.Value].Trim(); break;
                        case "Venda Confirmada": vendaconfirmada = b[dc.Value].Trim(); break;
                    }
                }

                listaPV.Add(new PedidoDeVenda
                {
                    DataEntrega = Convert.ToDateTime(dataentrega),
                    Seq = seq,
                    Quantidade = Convert.ToDouble(quantidade),
                    StatusdoItem = statusdoitem,
                    DataPedido = Convert.ToDateTime(datapedido),
                    MotivosBloqueio = motivosbloqueio,
                    Vendedor = vendedor,
                    NPedido = npedido,
                    Bloq = bloq,
                    Item = item,
                    Descricao = descricao,
                    Disponivel = Convert.ToDouble(disponivel),
                    Deposito = deposito,
                    Estabelecimento = estabelecimento,
                    OrdemCompra = ordemcompra,
                    PrecoUnitário = Convert.ToDouble(precounitário),
                    ValorTotal = Convert.ToDouble(valortotal),
                    RazaoSocial = razaosocial,
                    NomeFantasia = nomefantasia,
                    GrupoItem = grupoitem,
                    TextoEspecifico = textoespecifico,
                    CodigoCliente = codigocliente,
                    DESCR_1 = descr_1,
                    DESCR_2 = descr_2,
                    VendaConfirmada = vendaconfirmada
                });
            }
            sr.Close();
            st.Close();
            return listaPV;
        }

        //Movimento
        internal static List<Movimento> Movimento(string path)
        {
            fullpath = Path.GetFullPath(path);
            ObterLinha();
            List<Movimento> lista = new List<Movimento>();

            while ((linha = sr.ReadLine()) != null)
            {
                string[] b = new string[dic.Count];
                b = linha.Replace("\"", "").Replace("'", "").Split('\t');

                string data = "", tm = "", codigo = "", lote = "", documento = "", ac = "", quantidade = "", valormovimento = "", os = "", descricao = "", unidade = "",
                    tipodecontabilização = "", clientefornecedor = "", nomefantasia = "", contabiliza = "", contacontabil = "", dig = "", centrodecusto = "", dig2 = "",
                    livre2 = "", descrtipomovto = "", custo_inf = "", saldoatual = "", consmedio = "", valor = "", desc_ratea = "", ref_lote = "", qtde_bruta = "", flag = "",
                    emp_fil = "", estab = "", deposito = "", customediosimulado = "", nr_transf_cg = "", operadorinclusao = "", datainclusao = "", horainclusao = "",
                    customedio = "", roteiro = "", datainicioroteiro = "", quantidadedigitada = "", fator = "", operacao = "", descrmovto = "";
                foreach (var dc in dic)
                {
                    switch (dc.Key)
                    {
                        case "Data": data = b[dc.Value].Trim(); break;
                        case "TM": tm = b[dc.Value].Trim(); break;
                        case "Código": codigo = b[dc.Value].Trim(); break;
                        case "Lote": lote = b[dc.Value].Trim(); break;
                        case "Documento": documento = b[dc.Value].Trim(); break;
                        case "AC": ac = b[dc.Value].Trim(); break;
                        case "Quantidade": quantidade = b[dc.Value].Trim(); break;
                        case "Valor Movimento": valormovimento = b[dc.Value].Trim(); break;
                        case "OS": os = b[dc.Value].Trim(); break;
                        case "Descrição": descricao = b[dc.Value].Trim(); break;
                        case "Unidade": unidade = b[dc.Value].Trim(); break;
                        case "Tipo de Contabilização": tipodecontabilização = b[dc.Value].Trim(); break;
                        case "Cliente/Fornecedor": clientefornecedor = b[dc.Value].Trim(); break;
                        case "Nome Fantasia": nomefantasia = b[dc.Value].Trim(); break;
                        case "Contabiliza": contabiliza = b[dc.Value].Trim(); break;
                        case "Conta Contábil": contacontabil = b[dc.Value].Trim(); break;
                        case "Díg.": dig = b[dc.Value].Trim(); break;
                        case "Centro de Custo": centrodecusto = b[dc.Value].Trim(); break;
                        case "Díg.2": dig2 = b[dc.Value].Trim(); break;
                        case "Livre 2": livre2 = b[dc.Value].Trim(); break;
                        case "Descr. Tipo Movto.": descrtipomovto = b[dc.Value].Trim(); break;
                        case "CUSTO_INF": custo_inf = b[dc.Value].Trim(); break;
                        case "Saldo Atual": saldoatual = b[dc.Value].Trim(); break;
                        case "Cons. Médio": consmedio = b[dc.Value].Trim(); break;
                        case "VALOR": valor = b[dc.Value].Trim(); break;
                        case "DESC_RATEA": desc_ratea = b[dc.Value].Trim(); break;
                        case "REF_LOTE": ref_lote = b[dc.Value].Trim(); break;
                        case "QTDE_BRUTA": qtde_bruta = b[dc.Value].Trim(); break;
                        case "FLAG": flag = b[dc.Value].Trim(); break;
                        case "EMP_FIL": emp_fil = b[dc.Value].Trim(); break;
                        case "ESTAB": estab = b[dc.Value].Trim(); break;
                        case "DEPOSITO": deposito = b[dc.Value].Trim(); break;
                        case "Custo Médio Simulado": customediosimulado = b[dc.Value].Trim(); break;
                        case "NR_TRANSF_CG": nr_transf_cg = b[dc.Value].Trim(); break;
                        case "Operador Inclusão": operadorinclusao = b[dc.Value].Trim(); break;
                        case "Data Inclusão": datainclusao = b[dc.Value].Trim(); break;
                        case "Hora Inclusão": horainclusao = b[dc.Value].Trim(); break;
                        case "Custo médio": customedio = b[dc.Value].Trim(); break;
                        case "Roteiro": roteiro = b[dc.Value].Trim(); break;
                        case "Data Início Roteiro": datainicioroteiro = b[dc.Value].Trim(); break;
                        case "Quantidade Digitada": quantidadedigitada = b[dc.Value].Trim(); break;
                        case "Fator": fator = b[dc.Value].Trim(); break;
                        case "OPERACAO": operacao = b[dc.Value].Trim(); break;
                        case "Descr. Movto": descrmovto = b[dc.Value].Trim(); break;
                    }
                }

                lista.Add(new Movimento
                {
                    Data = Convert.ToDateTime(data),
                    TM = tm,
                    Codigo = codigo,
                    Lote = lote,
                    Documento = documento,
                    AC = ac,
                    Quantidade = Convert.ToDouble(quantidade),
                    ValorMovimento = Convert.ToDouble(valormovimento),
                    OS = os,
                    Descricao = descricao,
                    Unidade = unidade,
                    TipodeContabilização = tipodecontabilização,
                    ClienteFornecedor = clientefornecedor,
                    NomeFantasia = nomefantasia,
                    Contabiliza = contabiliza,
                    ContaContabil = contacontabil,
                    Dig = dig,
                    CentrodeCusto = centrodecusto,
                    Dig2 = dig2,
                    Livre2 = livre2,
                    DescrTipoMovto = descrtipomovto,
                    CUSTO_INF = Convert.ToDouble(custo_inf),
                    SaldoAtual = Convert.ToDouble(saldoatual),
                    ConsMedio = Convert.ToDouble(consmedio),
                    VALOR = Convert.ToDouble(valor),
                    DESC_RATEA = desc_ratea,
                    REF_LOTE = ref_lote,
                    QTDE_BRUTA = Convert.ToDouble(qtde_bruta),
                    FLAG = flag,
                    EMP_FIL = emp_fil,
                    ESTAB = estab,
                    DEPOSITO = deposito,
                    CustoMedioSimulado = Convert.ToDouble(customediosimulado),
                    NR_TRANSF_CG = nr_transf_cg,
                    OperadorInclusao = operadorinclusao,
                    DataInclusao = Convert.ToDateTime(datainclusao),
                    HoraInclusao = horainclusao,
                    CustoMedio = Convert.ToDouble(customedio),
                    Roteiro = roteiro,
                    DataInicioRoteiro = datainicioroteiro,
                    QuantidadeDigitada = quantidadedigitada,
                    Fator = fator,
                    OPERACAO = operacao,
                    DescrMovto = descrmovto,
                });
            }
            sr.Close();
            st.Close();
            return lista;
        }

        //ForaDeEstoque
        internal static List<ForaDeEstoque> ForaDeEstoque(string path)
        {
            fullpath = path;
            ObterLinha();
            List<ForaDeEstoque> lista = new List<ForaDeEstoque>();

            while ((linha = sr.ReadLine()) != null)
            {

                string[] a, b = new string[dic.Count];
                b = linha.Replace("\"", "").Replace("'", "").Split('\t');
                string op = "", docen = "", serie = "", produto = "", traducao = "", tm = "", data = "", fornecedor = "", docfiscal = "", serie2 = "", cont = "", lt = "", qtdenf = "",
                    valornf = "", valorcusto = "", saldoqtde = "", saldocusto = "", observacao = "", nomefantasia = "", descricao = "", valorunitario = "", textoespecificofatbalcao = "",
                    obsnfbalcao = "", tipo_movto_nf = "", nro_fornec = "", seq_fornec = "", qt_enviada = "", vr_env_nf = "", vr_enviado = "", qt_devolv = "", vr_dev_nf = "", vr_devolv = "",
                    estab = "", cont2 = "", deposito = "", tipo_fe = "", seq = "", emp_fil = "", dt_vencto = "", dt_doc_f = "", qt_fech = "", qt_fech_an = "", vr_fech = "", vr_fech_an = "",
                    vr_fech_nf = "", vr_fean_nf = "", vri_enviad = "", vri_devolv = "", vri_fech = "", vri_fech_an = "", vru_enviad = "", vru_devolv = "", vru_fech = "", vru_fech_an = "",
                    ref_unid = "", ref_local = "", c_custo = "", dg_ccusto = "", c_custo2 = "", dg_ccusto2 = "", conta = "", dg_conta = "", conta2 = "", dg_conta2 = "", tipo_contab = "",
                    data_alter = "", time_stamp = "", hora_alter = "", origem_movto = "", ordem_envio = "";
                try
                {

                    foreach (var dc in dic)
                    {
                        switch (dc.Key)
                        {
                            case "Op": op = b[dc.Value].Trim(); break;
                            case "Doc.En": docen = b[dc.Value].Trim(); break;
                            case "Serie": serie = b[dc.Value].Trim(); break;
                            case "Produto": produto = b[dc.Value].Trim(); break;
                            case "Tradução": traducao = b[dc.Value].Trim(); break;
                            case "TM": tm = b[dc.Value].Trim(); break;
                            case "Data": data = b[dc.Value].Trim(); break;
                            case "Fornecedor": fornecedor = b[dc.Value].Trim(); break;
                            case "Doc. Fiscal": docfiscal = b[dc.Value].Trim(); break;
                            case "Serie2": serie2 = b[dc.Value].Trim(); break;

                            case "Cont": cont = b[dc.Value].Trim(); break;
                            case "Qtde Nf": qtdenf = b[dc.Value].Trim(); break;
                            case "Valor Nf": valornf = b[dc.Value].Trim(); break;
                            case "Valor Custo": valorcusto = b[dc.Value].Trim(); break;
                            case "Saldo Qtde": saldoqtde = b[dc.Value].Trim(); break;
                            case "Saldo Custo": saldocusto = b[dc.Value].Trim(); break;
                            case "Observação": observacao = b[dc.Value].Trim(); break;
                            case "Nome Fantasia": nomefantasia = b[dc.Value].Trim(); break;
                            case "Descrição": descricao = b[dc.Value].Trim(); break;
                            case "Valor Unitário": valorunitario = b[dc.Value].Trim(); break;

                            case "Texto Específico Fat. Balcão": textoespecificofatbalcao = b[dc.Value].Trim(); break;
                            case "Obs NF Balcão": obsnfbalcao = b[dc.Value].Trim(); break;
                            case "TIPO_MOVTO_NF": tipo_movto_nf = b[dc.Value].Trim(); break;
                            case "NRO_FORNEC": nro_fornec = b[dc.Value].Trim(); break;
                            case "SEQ_FORNEC": seq_fornec = b[dc.Value].Trim(); break;
                            case "QT_ENVIADA": qt_enviada = b[dc.Value].Trim(); break;
                            case "VR_ENV_NF": vr_env_nf = b[dc.Value].Trim(); break;
                            case "VR_ENVIADO": vr_enviado = b[dc.Value].Trim(); break;
                            case "QT_DEVOLV": qt_devolv = b[dc.Value].Trim(); break;
                            case "VR_DEV_NF": vr_dev_nf = b[dc.Value].Trim(); break;

                            case "VR_DEVOLV": vr_devolv = b[dc.Value].Trim(); break;
                            case "Estab": estab = b[dc.Value].Trim(); break;
                            case "Cont2": cont2 = b[dc.Value].Trim(); break;
                            case "Deposito": deposito = b[dc.Value].Trim(); break;
                            case "TIPO_FE": tipo_fe = b[dc.Value].Trim(); break;
                            case "SEQ": seq = b[dc.Value].Trim(); break;
                            case "EMP_FIL": emp_fil = b[dc.Value].Trim(); break;
                            case "DT_VENCTO": dt_vencto = b[dc.Value].Trim(); break;
                            case "DT_DOC_F": dt_doc_f = b[dc.Value].Trim(); break;
                            case "QT_FECH": qt_fech = b[dc.Value].Trim(); break;

                            case "QT_FECH_AN": qt_fech_an = b[dc.Value].Trim(); break;
                            case "VR_FECH": vr_fech = b[dc.Value].Trim(); break;
                            case "VR_FECH_AN": vr_fech_an = b[dc.Value].Trim(); break;
                            case "VR_FECH_NF": vr_fech_nf = b[dc.Value].Trim(); break;
                            case "VR_FEAN_NF": vr_fean_nf = b[dc.Value].Trim(); break;
                            case "VRI_ENVIAD": vri_enviad = b[dc.Value].Trim(); break;
                            case "VRI_DEVOLV": vri_devolv = b[dc.Value].Trim(); break;
                            case "VRI_FECH": vri_fech = b[dc.Value].Trim(); break;
                            case "VRI_FECH_AN": vri_fech_an = b[dc.Value].Trim(); break;
                            case "VRU_ENVIAD": vru_enviad = b[dc.Value].Trim(); break;

                            case "VRU_DEVOLV": vru_devolv = b[dc.Value].Trim(); break;
                            case "VRU_FECH": vru_fech = b[dc.Value].Trim(); break;
                            case "VRU_FECH_AN": vru_fech_an = b[dc.Value].Trim(); break;
                            case "REF_UNID": ref_unid = b[dc.Value].Trim(); break;
                            case "REF_LOCAL": ref_local = b[dc.Value].Trim(); break;
                            case "C_CUSTO": c_custo = b[dc.Value].Trim(); break;
                            case "DG_CCUSTO": dg_ccusto = b[dc.Value].Trim(); break;
                            case "C_CUSTO2": c_custo2 = b[dc.Value].Trim(); break;
                            case "DG_CCUSTO2": dg_ccusto2 = b[dc.Value].Trim(); break;
                            case "CONTA": conta = b[dc.Value].Trim(); break;

                            case "DG_CONTA": dg_conta = b[dc.Value].Trim(); break;
                            case "CONTA2": conta2 = b[dc.Value].Trim(); break;
                            case "DG_CONTA2": dg_conta2 = b[dc.Value].Trim(); break;
                            case "TIPO_CONTAB": tipo_contab = b[dc.Value].Trim(); break;
                            case "DATA_ALTER": data_alter = b[dc.Value].Trim(); break;
                            case "TIME_STAMP": time_stamp = b[dc.Value].Trim(); break;
                            case "HORA_ALTER": hora_alter = b[dc.Value].Trim(); break;
                            case "ORIGEM_MOVTO": origem_movto = b[dc.Value].Trim(); break;
                            case "ORDEM_ENVIO": ordem_envio = b[dc.Value].Trim(); break;
                        }
                    }
                }

                catch (Exception)
                {
                    Mensagerias.Send("ERRO JJK6\n---------\n");
                }

                try
                {
                    lista.Add(new ForaDeEstoque
                    {
                        Op = op,
                        DocEn = docen,
                        Serie = serie,
                        Produto = produto,
                        Traducao = traducao,
                        TM = tm,
                        Data = Convert.ToDateTime(data),
                        Fornecedor = fornecedor,
                        DocFiscal = docfiscal,
                        Serie2 = serie2,
                        Cont = cont,
                        Lt = lt,
                        QtdeNf = Convert.ToDouble(qtdenf),
                        ValorNf = Convert.ToDouble(valornf),
                        ValorCusto = Convert.ToDouble(valorcusto),
                        SaldoQtde = Convert.ToDouble(saldoqtde),
                        SaldoCusto = Convert.ToDouble(saldocusto),
                        Observacao = observacao,
                        NomeFantasia = nomefantasia,
                        Descricao = descricao,
                        ValorUnitario = Convert.ToDouble(valorunitario),
                        TextoEspecificoFatBalcao = textoespecificofatbalcao,
                        ObsNFBalcao = obsnfbalcao,
                        TIPO_MOVTO_NF = tipo_movto_nf,
                        NRO_FORNEC = nro_fornec,
                        SEQ_FORNEC = seq_fornec,
                        QT_ENVIADA = Convert.ToDouble(qt_enviada),
                        VR_ENV_NF = Convert.ToDouble(vr_env_nf),
                        VR_ENVIADO = Convert.ToDouble(vr_enviado),
                        QT_DEVOLV = Convert.ToDouble(qt_devolv),
                        VR_DEV_NF = Convert.ToDouble(vr_dev_nf),
                        VR_DEVOLV = Convert.ToDouble(vr_devolv),
                        ESTAB = estab,
                        Cont2 = cont2,
                        DEPOSITO = deposito,
                        TIPO_FE = tipo_fe,
                        SEQ = seq,
                        EMP_FIL = emp_fil,
                        DT_VENCTO = dt_vencto,
                        DT_DOC_F = Convert.ToDateTime(dt_doc_f),
                        QT_FECH = Convert.ToDouble(qt_fech),
                        QT_FECH_AN = Convert.ToDouble(qt_fech_an),
                        VR_FECH = Convert.ToDouble(vr_fech),
                        VR_FECH_AN = Convert.ToDouble(vr_fech_an),
                        VR_FECH_NF = Convert.ToDouble(vr_fech_nf),
                        VR_FEAN_NF = Convert.ToDouble(vr_fean_nf),
                        VRI_ENVIAD = vri_enviad,
                        VRI_DEVOLV = vri_devolv,
                        VRI_FECH = vri_fech,
                        VRI_FECH_AN = vri_fech_an,
                        VRU_ENVIAD = vru_enviad,
                        VRU_DEVOLV = vru_devolv,
                        VRU_FECH = vru_fech,
                        VRU_FECH_AN = vru_fech_an,
                        REF_UNID = ref_unid,
                        REF_LOCAL = ref_local,
                        C_CUSTO = c_custo,
                        DG_CCUSTO = dg_ccusto,
                        C_CUSTO2 = c_custo2,
                        DG_CCUSTO2 = dg_ccusto2,
                        CONTA = conta,
                        DG_CONTA = dg_conta,
                        CONTA2 = conta2,
                        DG_CONTA2 = dg_conta2,
                        TIPO_CONTAB = tipo_contab,
                        DATA_ALTER = Convert.ToDateTime(data_alter),
                        TIME_STAMP = time_stamp,
                        HORA_ALTER = hora_alter,
                        ORIGEM_MOVTO = origem_movto,
                        ORDEM_ENVIO = ordem_envio,

                    }
                    );
                }
                catch (Exception e)
                {
                    Mensagerias.Send("ERRO HHU\n" + e.Message + "\n---------\n");
                }
            }
            sr.Close();
            st.Close();
            return lista;
        }

        //DeTerceiro aguard
        internal static List<DeTerceiros> DeTerceiros(String path)
        {
            fullpath = path;
            ObterLinha();
            List<DeTerceiros> lista = new List<DeTerceiros>();

            while ((linha = sr.ReadLine()) != null)
            {

                string[] a, b = new string[dic.Count];
                b = linha.Replace("\"", "").Replace("'", "").Split('\t');

                string op = "", docen = "", serie = "", produto = "", traducao = "", tm = "", data = "", cliente = "", docfiscal = "", serie2 = "", cont = "", lt = "", qtdenf = "",
                    valornf = "", valorcusto = "", saldoqtde = "", saldocusto = "", observacao = "", nomefantasia = "", descricao = "", valorunitario = "", textoespecificofatbalcao = "",
                    obsnfbalcao = "", tipo_movto_nf = "", nro_fornec = "", seq_fornec = "", qt_enviada = "", vr_env_nf = "", vr_enviado = "", qt_devolv = "", vr_dev_nf = "", vr_devolv = "",
                    estab = "", cont2 = "", deposito = "", tipo_fe = "", seq = "", emp_fil = "", dt_vencto = "", dt_doc_f = "", qt_fech = "", qt_fech_an = "", vr_fech = "", vr_fech_an = "",
                    vr_fech_nf = "", vr_fean_nf = "", vri_enviad = "", vri_devolv = "", vri_fech = "", vri_fech_an = "", vru_enviad = "", vru_devolv = "", vru_fech = "", vru_fech_an = "",
                    ref_unid = "", ref_local = "", c_custo = "", dg_ccusto = "", c_custo2 = "", dg_ccusto2 = "", conta = "", dg_conta = "", conta2 = "", dg_conta2 = "", tipo_contab = "",
                    data_alter = "", time_stamp = "", hora_alter = "", origem_movto = "", ordem_envio = "";

                try
                {
                    foreach (var dc in dic)
                    {
                        switch (dc.Key)
                        {
                            case "Op": op = b[dc.Value].Trim(); break;
                            case "Doc.En": docen = b[dc.Value].Trim(); break;
                            case "Serie": serie = b[dc.Value].Trim(); break;
                            case "Produto": produto = b[dc.Value].Trim(); break;
                            case "Tradução": traducao = b[dc.Value].Trim(); break;
                            case "TM": tm = b[dc.Value].Trim(); break;
                            case "Data": data = b[dc.Value].Trim(); break;
                            case "Cliente": cliente = b[dc.Value].Trim(); break;
                            case "Doc. Fiscal": docfiscal = b[dc.Value].Trim(); break;
                            case "Serie2": serie2 = b[dc.Value].Trim(); break;

                            case "Cont": cont = b[dc.Value].Trim(); break;
                            case "Qtde Nf": qtdenf = b[dc.Value].Trim(); break;
                            case "Valor Nf": valornf = b[dc.Value].Trim(); break;
                            case "Valor Custo": valorcusto = b[dc.Value].Trim(); break;
                            case "Saldo Qtde": saldoqtde = b[dc.Value].Trim(); break;
                            case "Saldo Custo": saldocusto = b[dc.Value].Trim(); break;
                            case "Observação": observacao = b[dc.Value].Trim(); break;
                            case "Nome Fantasia": nomefantasia = b[dc.Value].Trim(); break;
                            case "Descrição": descricao = b[dc.Value].Trim(); break;
                            case "Valor Unitário": valorunitario = b[dc.Value].Trim(); break;

                            case "Texto Específico Fat. Balcão": textoespecificofatbalcao = b[dc.Value].Trim(); break;
                            case "Obs NF Balcão": obsnfbalcao = b[dc.Value].Trim(); break;
                            case "TIPO_MOVTO_NF": tipo_movto_nf = b[dc.Value].Trim(); break;
                            case "NRO_FORNEC": nro_fornec = b[dc.Value].Trim(); break;
                            case "SEQ_FORNEC": seq_fornec = b[dc.Value].Trim(); break;
                            case "QT_ENVIADA": qt_enviada = b[dc.Value].Trim(); break;
                            case "VR_ENV_NF": vr_env_nf = b[dc.Value].Trim(); break;
                            case "VR_ENVIADO": vr_enviado = b[dc.Value].Trim(); break;
                            case "QT_DEVOLV": qt_devolv = b[dc.Value].Trim(); break;
                            case "VR_DEV_NF": vr_dev_nf = b[dc.Value].Trim(); break;

                            case "VR_DEVOLV": vr_devolv = b[dc.Value].Trim(); break;
                            case "Estab": estab = b[dc.Value].Trim(); break;
                            case "Cont2": cont2 = b[dc.Value].Trim(); break;
                            case "Deposito": deposito = b[dc.Value].Trim(); break;
                            case "TIPO_FE": tipo_fe = b[dc.Value].Trim(); break;
                            case "SEQ": seq = b[dc.Value].Trim(); break;
                            case "EMP_FIL": emp_fil = b[dc.Value].Trim(); break;
                            case "DT_VENCTO": dt_vencto = b[dc.Value].Trim(); break;
                            case "DT_DOC_F": dt_doc_f = b[dc.Value].Trim(); break;
                            case "QT_FECH": qt_fech = b[dc.Value].Trim(); break;

                            case "QT_FECH_AN": qt_fech_an = b[dc.Value].Trim(); break;
                            case "VR_FECH": vr_fech = b[dc.Value].Trim(); break;
                            case "VR_FECH_AN": vr_fech_an = b[dc.Value].Trim(); break;
                            case "VR_FECH_NF": vr_fech_nf = b[dc.Value].Trim(); break;
                            case "VR_FEAN_NF": vr_fean_nf = b[dc.Value].Trim(); break;
                            case "VRI_ENVIAD": vri_enviad = b[dc.Value].Trim(); break;
                            case "VRI_DEVOLV": vri_devolv = b[dc.Value].Trim(); break;
                            case "VRI_FECH": vri_fech = b[dc.Value].Trim(); break;
                            case "VRI_FECH_AN": vri_fech_an = b[dc.Value].Trim(); break;
                            case "VRU_ENVIAD": vru_enviad = b[dc.Value].Trim(); break;

                            case "VRU_DEVOLV": vru_devolv = b[dc.Value].Trim(); break;
                            case "VRU_FECH": vru_fech = b[dc.Value].Trim(); break;
                            case "VRU_FECH_AN": vru_fech_an = b[dc.Value].Trim(); break;
                            case "REF_UNID": ref_unid = b[dc.Value].Trim(); break;
                            case "REF_LOCAL": ref_local = b[dc.Value].Trim(); break;
                            case "C_CUSTO": c_custo = b[dc.Value].Trim(); break;
                            case "DG_CCUSTO": dg_ccusto = b[dc.Value].Trim(); break;
                            case "C_CUSTO2": c_custo2 = b[dc.Value].Trim(); break;
                            case "DG_CCUSTO2": dg_ccusto2 = b[dc.Value].Trim(); break;
                            case "CONTA": conta = b[dc.Value].Trim(); break;

                            case "DG_CONTA": dg_conta = b[dc.Value].Trim(); break;
                            case "CONTA2": conta2 = b[dc.Value].Trim(); break;
                            case "DG_CONTA2": dg_conta2 = b[dc.Value].Trim(); break;
                            case "TIPO_CONTAB": tipo_contab = b[dc.Value].Trim(); break;
                            case "DATA_ALTER": data_alter = b[dc.Value].Trim(); break;
                            case "TIME_STAMP": time_stamp = b[dc.Value].Trim(); break;
                            case "HORA_ALTER": hora_alter = b[dc.Value].Trim(); break;
                            case "ORIGEM_MOVTO": origem_movto = b[dc.Value].Trim(); break;
                            case "ORDEM_ENVIO": ordem_envio = b[dc.Value].Trim(); break;
                        }
                    }
                }
                catch (Exception e)
                {
                    Mensagerias.Send("ERRO CCC555 " + e.Message + "\n---------\n");
                }

                try
                {
                    lista.Add(new DeTerceiros
                    {
                        Op = op,
                        DocEn = docen,
                        Serie = serie,
                        Produto = produto,
                        Traducao = traducao,
                        TM = tm,
                        Data = Convert.ToDateTime(data),
                        Cliente = cliente,
                        DocFiscal = docfiscal,
                        Serie2 = serie2,
                        Cont = cont,
                        Lt = lt,
                        QtdeNf = Convert.ToDouble(qtdenf),
                        ValorNf = Convert.ToDouble(valornf),
                        ValorCusto = Convert.ToDouble(valorcusto),
                        SaldoQtde = Convert.ToDouble(saldoqtde),
                        SaldoCusto = Convert.ToDouble(saldocusto),
                        Observacao = observacao,
                        NomeFantasia = nomefantasia,
                        Descricao = descricao,
                        ValorUnitario = Convert.ToDouble(valorunitario),
                        TextoEspecificoFatBalcao = textoespecificofatbalcao,
                        ObsNFBalcao = obsnfbalcao,
                        TIPO_MOVTO_NF = tipo_movto_nf,
                        NRO_FORNEC = nro_fornec,
                        SEQ_FORNEC = seq_fornec,
                        QT_ENVIADA = Convert.ToDouble(qt_enviada),
                        VR_ENV_NF = Convert.ToDouble(vr_env_nf),
                        VR_ENVIADO = Convert.ToDouble(vr_enviado),
                        QT_DEVOLV = Convert.ToDouble(qt_devolv),
                        VR_DEV_NF = Convert.ToDouble(vr_dev_nf),
                        VR_DEVOLV = Convert.ToDouble(vr_devolv),
                        ESTAB = estab,
                        Cont2 = cont2,
                        DEPOSITO = deposito,
                        TIPO_FE = tipo_fe,
                        SEQ = seq,
                        EMP_FIL = emp_fil,
                        DT_VENCTO = dt_vencto,
                        DT_DOC_F = Convert.ToDateTime(dt_doc_f),
                        QT_FECH = Convert.ToDouble(qt_fech),
                        QT_FECH_AN = Convert.ToDouble(qt_fech_an),
                        VR_FECH = Convert.ToDouble(vr_fech),
                        VR_FECH_AN = Convert.ToDouble(vr_fech_an),
                        VR_FECH_NF = Convert.ToDouble(vr_fech_nf),
                        VR_FEAN_NF = Convert.ToDouble(vr_fean_nf),
                        VRI_ENVIAD = vri_enviad,
                        VRI_DEVOLV = vri_devolv,
                        VRI_FECH = vri_fech,
                        VRI_FECH_AN = vri_fech_an,
                        VRU_ENVIAD = vru_enviad,
                        VRU_DEVOLV = vru_devolv,
                        VRU_FECH = vru_fech,
                        VRU_FECH_AN = vru_fech_an,
                        REF_UNID = ref_unid,
                        REF_LOCAL = ref_local,
                        C_CUSTO = c_custo,
                        DG_CCUSTO = dg_ccusto,
                        C_CUSTO2 = c_custo2,
                        DG_CCUSTO2 = dg_ccusto2,
                        CONTA = conta,
                        DG_CONTA = dg_conta,
                        CONTA2 = conta2,
                        DG_CONTA2 = dg_conta2,
                        TIPO_CONTAB = tipo_contab,
                        DATA_ALTER = Convert.ToDateTime(data_alter),
                        TIME_STAMP = time_stamp,
                        HORA_ALTER = hora_alter,
                        ORIGEM_MOVTO = origem_movto,
                        ORDEM_ENVIO = ordem_envio,

                    });
                }
                catch (Exception e)
                {
                    Mensagerias.Send("ERRO GGRT " + e.Message + "\n---------\n");
                }

            }
            sr.Close();
            st.Close();
            return lista;
        }

        //ItensDeEstoque
        internal static List<ItensDeEstoque> ItensDeEstoque()
        {

            fullpath = @"C:\Exports\ItensDeEstoque.txt";
            ObterLinha();
            List<ItensDeEstoque> lista = new List<ItensDeEstoque>();

            while ((linha = sr.ReadLine()) != null)
            {

                string[] a, b = new string[dic.Count];
                b = linha.Replace("\"", "").Replace("'", "").Split('\t');

                string codigo = "", precocompra = "", traducao = "", unidade = "", grupo = "", lotes = "", ns = "", descricao = "", quantidadedisponivel = "", saldofisico = "",
                    quantidadeporunidade = "", cubagem = "", pesobruto = "", pesoliquido = "", datadacompra = "", prateleira = "", status = "", itemcadastradoem = "", posicaofiscal = "",
                    complposicaofiscal = "", unidalterdipi = "", fatoruniddipi = "", procedencia = "", unalterdipi = "", exdatipi = "", coddofabricantedoproduto = "", exppalm = "",
                    precovenda = "", codigo2 = "", descr_1 = "", descr_2 = "", descricaocompleta = "", codigoexterno = "", estab = "", deposito = "", qtdultfech = "", entradas = "",
                    saidas = "", os_previst = "", foradeestoque = "", vendasconsig = "", comprasconsig = "", resvendas = "", pedvenda = "", preco = "", qt_alt_obr = "", empreqcompra = "",
                    unidadealternativa = "", fatordeconversao = "", codfamilia = "", descricaodafamilia = "", codean13 = "", estoqueminimo = "", estoquemaximo = "", tolerancia = "",
                    leadtime = "", codigodorecolhimento = "", aliquotadeipi = "", livre1 = "", livre2 = "", livre3 = "", livre4 = "", livre5 = "", livre6 = "", livre7 = "", livre8 = "",
                    livre9 = "", livre10 = "", livre11 = "", livre12 = "", livre13 = "", livre14 = "", livre15 = "", livre16 = "", livre17 = "", livre18 = "", livre19 = "", livre20 = "",
                    codigodeservico = "", contacontabil = "", contaconsumo = "", centrodecusto = "", generocotepe = "", tipoitemsped = "", codigoprodutosimilar = "", valorultfech = "",
                    customediosimulado = "", customedio = "", reservado_11 = "", codigodetributacaoam = "", grupodefamilia = "", descricaogrupofamilia = "", descricaocompleta2 = "",
                    descricaos = "", cest = "", conta = "", dgconta = "", contacons = "", dgcontacons = "", centrocusto = "", dgcentrocusto = "", precodereposicao = "", reinf = "",
                    goodsreceipt = "", descricaodogrupo = "", codigodetributacao = "", codigodetributacaoalternativo = "", familia = "", formadepedir = "", fatorunidadencm = "",
                    fatordaunidade = "", unidadealternativaexportacao = "", fatorunidadedipiexportacao = "", aplicacao = "";

                String t = "";
                try
                {
                    foreach (var dc in dic)
                    {
                        t = dc.Key + " " + dc.Value;
                        switch (dc.Key)
                        {
                            case "Código": codigo = b[dc.Value].Trim(); break;
                            case "Preco Compra": precocompra = b[dc.Value].Trim(); break;
                            case "Tradução": traducao = b[dc.Value].Trim(); break;
                            case "Unidade": unidade = b[dc.Value].Trim(); break;
                            case "Grupo": grupo = b[dc.Value].Trim(); break;
                            case "Lotes": lotes = b[dc.Value].Trim(); break;
                            case "NS": ns = b[dc.Value].Trim(); break;
                            case "Descrição": descricao = b[dc.Value].Trim(); break;
                            case "Quantidade Disponível": quantidadedisponivel = Math.Round(Convert.ToDouble(b[dc.Value].Trim()), 3).ToString(); break;
                            case "Saldo Físico": saldofisico = Math.Round(Convert.ToDouble(b[dc.Value].Trim()), 3).ToString(); break;
                            case "Quantidade por Unidade": quantidadeporunidade = b[dc.Value].Trim(); break;
                            case "Cubagem(m³)": cubagem = b[dc.Value].Trim(); break;
                            case "Peso Bruto": pesobruto = b[dc.Value].Trim(); break;
                            case "Peso Líquido": pesoliquido = b[dc.Value].Trim(); break;
                            case "Data da Compra": datadacompra = b[dc.Value].Trim(); break;
                            case "Prateleira": prateleira = b[dc.Value].Trim(); break;
                            case "Status": status = b[dc.Value].Trim(); break;
                            case "Item Cadastrado Em": itemcadastradoem = b[dc.Value].Trim(); break;
                            case "Posição Fiscal": posicaofiscal = b[dc.Value].Trim(); break;
                            case "Compl Posição Fiscal": complposicaofiscal = b[dc.Value].Trim(); break;
                            case "Unid. Alter. DIPI": unidalterdipi = b[dc.Value].Trim(); break;
                            case "Fator Unid. DIPI": fatoruniddipi = b[dc.Value].Trim(); break;
                            case "Procedência": procedencia = b[dc.Value].Trim(); break;
                            case "Un. Alter. DIPI": unalterdipi = b[dc.Value].Trim(); break;
                            case "EX da TIPI": exdatipi = b[dc.Value].Trim(); break;
                            case "Cód. do Fabricante do Produto": coddofabricantedoproduto = b[dc.Value].Trim(); break;
                            case "Exp Palm": exppalm = b[dc.Value].Trim(); break;
                            case "Preço Venda": precovenda = b[dc.Value].Trim(); break;
                            case "Código2": codigo2 = b[dc.Value].Trim(); break;
                            case "DESCR_1": descr_1 = b[dc.Value].Trim(); break;
                            case "DESCR_2": descr_2 = b[dc.Value].Trim(); break;
                            case "Descrição Completa": descricaocompleta = b[dc.Value].Trim(); break;
                            case "Código Externo": codigoexterno = b[dc.Value].Trim(); break;
                            case "ESTAB": estab = b[dc.Value].Trim(); break;
                            case "DEPOSITO": deposito = b[dc.Value].Trim(); break;
                            case "Qtd Últ. Fech.": qtdultfech = b[dc.Value].Trim(); break;
                            case "ENTRADAS": entradas = b[dc.Value].Trim(); break;
                            case "SAIDAS": saidas = b[dc.Value].Trim(); break;
                            case "OS_PREVIST": os_previst = b[dc.Value].Trim(); break;
                            case "Fora de Estoque": foradeestoque = b[dc.Value].Trim(); break;
                            case "Vendas Consig": vendasconsig = b[dc.Value].Trim(); break;
                            case "Compras Consig": comprasconsig = b[dc.Value].Trim(); break;
                            case "Res. Vendas": resvendas = b[dc.Value].Trim(); break;
                            case "Ped Venda": pedvenda = b[dc.Value].Trim(); break;
                            case "Preço": preco = b[dc.Value].Trim(); break;
                            case "QT_ALT_OBR": qt_alt_obr = b[dc.Value].Trim(); break;
                            case "Emp. Req. Compra": empreqcompra = b[dc.Value].Trim(); break;
                            case "Unidade Alternativa": unidadealternativa = b[dc.Value].Trim(); break;
                            case "Fator de Conversão": fatordeconversao = b[dc.Value].Trim(); break;
                            case "Cód. Família": codfamilia = b[dc.Value].Trim(); break;
                            case "Descrição da Família": descricaodafamilia = b[dc.Value].Trim(); break;
                            case "Cod. EAN 13": codean13 = b[dc.Value].Trim(); break;
                            case "Estoque Mínimo": estoqueminimo = b[dc.Value].Trim(); break;
                            case "Estoque Máximo": estoquemaximo = b[dc.Value].Trim(); break;
                            case "% de Tolerância": tolerancia = b[dc.Value].Trim(); break;
                            case "Leadtime": leadtime = b[dc.Value].Trim(); break;
                            case "Código do Recolhimento": codigodorecolhimento = b[dc.Value].Trim(); break;
                            case "Alíquota de IPI": aliquotadeipi = b[dc.Value].Trim(); break;
                            case "Livre 1": livre1 = b[dc.Value].Trim(); break;
                            case "Livre 2": livre2 = b[dc.Value].Trim(); break;
                            case "Livre 3": livre3 = b[dc.Value].Trim(); break;
                            case "Livre 4": livre4 = b[dc.Value].Trim(); break;
                            case "Livre 5": livre5 = b[dc.Value].Trim(); break;
                            case "Livre 6": livre6 = b[dc.Value].Trim(); break;
                            case "Livre 7": livre7 = b[dc.Value].Trim(); break;
                            case "Livre 8": livre8 = b[dc.Value].Trim(); break;
                            case "Livre 9": livre9 = b[dc.Value].Trim(); break;
                            case "Livre 10": livre10 = b[dc.Value].Trim(); break;
                            case "Livre 11": livre11 = b[dc.Value].Trim(); break;
                            case "Livre 12": livre12 = b[dc.Value].Trim(); break;
                            case "Livre 13": livre13 = b[dc.Value].Trim(); break;
                            case "Livre 14": livre14 = b[dc.Value].Trim(); break;
                            case "Livre 15": livre15 = b[dc.Value].Trim(); break;
                            case "Livre 16": livre16 = b[dc.Value].Trim(); break;
                            case "Livre 17": livre17 = b[dc.Value].Trim(); break;
                            case "Livre 18": livre18 = b[dc.Value].Trim(); break;
                            case "Livre 19": livre19 = b[dc.Value].Trim(); break;
                            case "Livre 20": livre20 = b[dc.Value].Trim(); break;
                            case "Código de Serviço": codigodeservico = b[dc.Value].Trim(); break;
                            case "Conta Contabil": contacontabil = b[dc.Value].Trim(); break;
                            case "Conta Consumo": contaconsumo = b[dc.Value].Trim(); break;
                            case "Centro de Custo": centrodecusto = b[dc.Value].Trim(); break;
                            case "Gênero Cotepe": generocotepe = b[dc.Value].Trim(); break;
                            case "Tipo Item Sped": tipoitemsped = b[dc.Value].Trim(); break;
                            case "Código Produto Similar": codigoprodutosimilar = b[dc.Value].Trim(); break;
                            case "Valor Últ. Fech.": valorultfech = b[dc.Value].Trim(); break;
                            case "Custo Médio Simulado": customediosimulado = b[dc.Value].Trim(); break;
                            case "Custo Médio": customedio = b[dc.Value].Trim(); break;
                            case "RESERVADO_11": reservado_11 = b[dc.Value].Trim(); break;
                            case "Código de Tributação AM": codigodetributacaoam = b[dc.Value].Trim(); break;
                            case "Grupo de Família": grupodefamilia = b[dc.Value].Trim(); break;
                            case "Descrição Grupo Família": descricaogrupofamilia = b[dc.Value].Trim(); break;
                            case "Descrição Completa (   )": descricaocompleta = b[dc.Value].Trim(); break;
                            case "Descrição (s/    )": descricaos = b[dc.Value].Trim(); break;
                            case "CEST": cest = b[dc.Value].Trim(); break;
                            case "Conta": conta = b[dc.Value].Trim(); break;
                            case "Dg Conta": dgconta = b[dc.Value].Trim(); break;
                            case "Conta Cons": contacons = b[dc.Value].Trim(); break;
                            case "Dg Conta Cons": dgcontacons = b[dc.Value].Trim(); break;
                            case "Centro Custo": centrocusto = b[dc.Value].Trim(); break;
                            case "Dg Centro Custo": dgcentrocusto = b[dc.Value].Trim(); break;
                            case "Preço de Reposição": precodereposicao = b[dc.Value].Trim(); break;
                            case "Reinf": reinf = b[dc.Value].Trim(); break;
                            case "Goods Receipt": goodsreceipt = b[dc.Value].Trim(); break;
                            case "Descrição do Grupo": descricaodogrupo = b[dc.Value].Trim(); break;
                            case "Código de Tributação": codigodetributacao = b[dc.Value].Trim(); break;
                            case "Código de Tributação Alternativo": codigodetributacaoalternativo = b[dc.Value].Trim(); break;
                            case "Família": familia = b[dc.Value].Trim(); break;
                            case "Forma de pedir": formadepedir = b[dc.Value].Trim(); break;
                            case "Fator Unidade NCM": fatorunidadencm = b[dc.Value].Trim(); break;
                            case "Fator da unidade": fatordaunidade = b[dc.Value].Trim(); break;
                            case "Unidade alternativa exportação": unidadealternativaexportacao = b[dc.Value].Trim(); break;
                            case "Fator unidade DIPI exportação": fatorunidadedipiexportacao = b[dc.Value].Trim(); break;
                            case "Aplicação": aplicacao = b[dc.Value].Trim(); break;


                        }
                    }
                }
                catch (Exception e)
                {
                    Mensagerias.Send("ERRO XPT889 1 - " + e.Message + "\n---------\n");
                }
                try
                {
                    lista.Add(new ItensDeEstoque
                    {
                        Codigo = codigo,
                        PrecoCompra = Convert.ToDouble(precocompra),
                        Traducao = traducao,
                        Unidade = unidade,
                        Grupo = grupo,
                        Lotes = lotes,
                        NS = ns,
                        Descricao = descricao,
                        QuantidadeDisponivel = Convert.ToDouble(quantidadedisponivel),
                        SaldoFisico = Convert.ToDouble(saldofisico),
                        QuantidadeporUnidade = quantidadeporunidade,
                        Cubagem = cubagem,
                        PesoBruto = pesobruto,
                        PesoLiquido = pesoliquido,
                        DatadaCompra = datadacompra,
                        Prateleira = prateleira,
                        Status = status,
                        ItemCadastradoEm = Convert.ToDateTime(itemcadastradoem),
                        PosicaoFiscal = posicaofiscal,
                        ComplPosicaoFiscal = complposicaofiscal,
                        UnidAlterDIPI = unidalterdipi,
                        FatorUnidDIPI = fatoruniddipi,
                        Procedência = procedencia,
                        UnAlterDIPI = unalterdipi,
                        EXdaTIPI = exdatipi,
                        CoddoFabricantedoProduto = coddofabricantedoproduto,
                        ExpPalm = exppalm,
                        PrecoVenda = Convert.ToDouble(precovenda),
                        Codigo2 = codigo2,
                        DESCR_1 = descr_1,
                        DESCR_2 = descr_2,
                        DescricaoCompleta = descricaocompleta,
                        CodigoExterno = codigoexterno,
                        ESTAB = estab,
                        DEPOSITO = deposito,
                        QtdUltFech = Convert.ToDouble(qtdultfech),
                        ENTRADAS = Convert.ToDouble(entradas),
                        SAIDAS = Convert.ToDouble(saidas),
                        OS_PREVIST = os_previst,
                        ForadeEstoque = Convert.ToDouble(foradeestoque),
                        VendasConsig = vendasconsig,
                        ComprasConsig = Convert.ToDouble(comprasconsig),
                        ResVendas = Convert.ToDouble(resvendas),
                        PedVenda = Convert.ToDouble(pedvenda),
                        Preco = Convert.ToDouble(preco),
                        QT_ALT_OBR = qt_alt_obr,
                        EmpReqCompra = Convert.ToDouble(empreqcompra),
                        UnidadeAlternativa = unidadealternativa,
                        FatordeConversao = Convert.ToDouble(fatordeconversao),
                        CodFamilia = codfamilia,
                        DescricaodaFamilia = descricaodafamilia,
                        CodEAN13 = codean13,
                        EstoqueMinimo = Convert.ToDouble(estoqueminimo),
                        EstoqueMáximo = Convert.ToDouble(estoquemaximo),
                        Tolerancia = Convert.ToDouble(tolerancia),
                        Leadtime = Convert.ToDouble(leadtime),
                        CodigodoRecolhimento = codigodorecolhimento,
                        AliquotadeIPI = aliquotadeipi,
                        Livre1 = livre1,
                        Livre2 = livre2,
                        Livre3 = livre3,
                        Livre4 = livre4,
                        Livre5 = livre5,
                        Livre6 = livre6,
                        Livre7 = livre7,
                        Livre8 = livre8,
                        Livre9 = livre9,
                        Livre10 = livre10,
                        Livre11 = livre11,
                        Livre12 = livre12,
                        Livre13 = Convert.ToDateTime(livre13),
                        Livre14 = Convert.ToDateTime(livre14),
                        Livre15 = Convert.ToDateTime(livre15),
                        Livre16 = Convert.ToDateTime(livre16),
                        Livre17 = livre17,
                        Livre18 = livre18,
                        Livre19 = livre19,
                        Livre20 = livre20,
                        CodigodeServico = codigodeservico,
                        ContaContabil = contacontabil,
                        ContaConsumo = contaconsumo,
                        CentrodeCusto = centrodecusto,
                        GeneroCotepe = generocotepe,
                        TipoItemSped = tipoitemsped,
                        CodigoProdutoSimilar = codigoprodutosimilar,
                        ValorUltFech = Convert.ToDouble(valorultfech),
                        CustoMedioSimulado = Convert.ToDouble(customediosimulado),
                        CustoMedio = Convert.ToDouble(customedio),
                        RESERVADO_11 = reservado_11,
                        CodigodeTributacaoAM = codigodetributacaoam,
                        GrupodeFamilia = grupodefamilia,
                        DescricaoGrupoFamilia = descricaogrupofamilia,
                        DescricaoCompleta2 = descricaocompleta2,
                        Descricaos = descricaos,
                        CEST = cest,
                        Conta = conta,
                        DgConta = dgconta,
                        ContaCons = contacons,
                        DgContaCons = dgcontacons,
                        CentroCusto = centrocusto,
                        DgCentroCusto = dgcentrocusto,
                        PrecodeReposicao = precodereposicao,
                        Reinf = reinf,
                        GoodsReceipt = goodsreceipt,
                        DescricaodoGrupo = descricaodogrupo,
                        CodigodeTributacao = codigodetributacao,
                        CodigodeTributacaoAlternativo = codigodetributacaoalternativo,
                        Familia = familia,
                        Formadepedir = formadepedir,
                        FatorUnidadeNCM = fatorunidadencm,
                        Fatordaunidade = fatordaunidade,
                        Unidadealternativaexportacao = unidadealternativaexportacao,
                        FatorunidadeDIPIexportacao = fatorunidadedipiexportacao,
                        Aplicacao = aplicacao
                    });
                }
                catch (Exception e)
                {
                    Mensagerias.Send("ERRO XPT889 2 - " + e.Message + "\n---------\n");
                }

            }
            sr.Close();
            st.Close();
            return lista;
        }

        //DepositoDeTerceiro
        internal static List<DepositoDeTerceiro> DepositoDeTerceiro()
        {
            fullpath = @"C:\Exports\DepositoDeTerceiro.txt";
            ObterLinha();
            List<DepositoDeTerceiro> lista = new List<DepositoDeTerceiro>();


            while ((linha = sr.ReadLine()) != null)
            {

                string[] b = new string[dic.Count];
                b = linha.Replace("\"", "").Replace("'", "").Split('\t');

                string deposito = "", nome = "";

                foreach (var dc in dic)
                {
                    string valor = "";
                    switch (b[0].ToString().Length)
                    {
                        case 1: valor = "00" + b[dc.Value].Trim(); break;

                        case 2: valor = "0" + b[dc.Value].Trim(); break;

                        case 3: valor = b[dc.Value].Trim(); break;

                        case 4:

                            Mensagerias.Send($"ERRO 222 aumentar zeros na sequencia de deposito de terceiro {b[dc.Value]}" + "\n---------\n");
                            break;

                    }
                    switch (dc.Key)
                    {
                        case "Deposito": deposito = valor; break;
                        case "Nome": nome = b[dc.Value].Trim(); break;
                    }
                }
                lista.Add(new DepositoDeTerceiro
                {
                    Deposito = deposito,
                    Nome = nome
                });
            }
            sr.Close();
            st.Close();
            return lista;
        }

        //SaldoDeTerceiro
        internal static List<SaldoDeTerceiro> SaldoDeTerceiro2()
        {
            fullpath = @"C:\Exports\SaldoDeTerceiro.txt";
            ObterLinha();
            List<SaldoDeTerceiro> lista = new List<SaldoDeTerceiro>();

            while ((linha = sr.ReadLine()) != null)
            {

                string[] b = new string[dic.Count];
                b = linha.Replace("\"", "").Replace("'", "").Split('\t');

                string produto = "", traducao = "", descricao = "", unid = "", lote = "", grupo = "", disponivel = "", saldoatual = "",
                        saldoultfech = "", entradas = "", saidas = "", pedcompras = "", pedvendas = "", consuprevos = "", jarequisos = "", prodprevos = "",
                        prodentros = "", foraestoque = "", transito = "", deterceiros = "", vendaconsign = "", compraentrfutura = "", vendaentrfutura = "",
                        compraconsig = "", aguardandocq = "", estqminimo = "", estqmaximo = "", reservadevendas = "", prateleira = "",
                        saldopedidodataentregaexcedida = "", prevfabric = "", diassemmovimento = "", emp_fil = "", estab = "", deposito = "", qt_ccon = "",
                        gr1 = "", descr_2 = "", forneced_2 = "", reservado_11 = "", valorultfech = "", customediosimulado = "",
                        customedio = "", precolistapadrao = "", descricao2 = "";


                foreach (var dc in dic)
                {
                    string valor = "";
                    switch (b[34].ToString().Length)
                    {
                        case 1: valor = "00" + b[dc.Value].Trim(); break;
                        case 2: valor = "0" + b[dc.Value].Trim(); break;
                        case 3: valor = b[dc.Value].Trim(); break;
                        case 4:
                            Mensagerias.Send($"ERRO 222 aumentar zeros na sequencia de deposito de terceiro {b[dc.Value]}" + "\n---------\n"); break;
                    }
                    switch (dc.Key)
                    {
                        case "Produto": produto = b[dc.Value].Trim(); break;
                        case "Tradução": traducao = b[dc.Value].Trim(); break;
                        case "Descrição": descricao = b[dc.Value].Trim(); break;
                        case "Unid": unid = b[dc.Value].Trim(); break;
                        case "Lote": lote = b[dc.Value].Trim(); break;
                        case "Grupo": grupo = b[dc.Value].Trim(); break;
                        case "Disponível": disponivel = b[dc.Value].Trim(); break;
                        case "Saldo Atual": saldoatual = b[dc.Value].Trim(); break;
                        case "Saldo Últ.Fech.": saldoultfech = b[dc.Value].Trim(); break;
                        case "Entradas": entradas = b[dc.Value].Trim(); break;
                        case "Saídas": saidas = b[dc.Value].Trim(); break;
                        case "Ped.Compras": pedcompras = b[dc.Value].Trim(); break;
                        case "Ped.Vendas": pedvendas = b[dc.Value].Trim(); break;
                        case "Consu.Prev.Os": consuprevos = b[dc.Value].Trim(); break;
                        case "Já Requis.OS": jarequisos = b[dc.Value].Trim(); break;
                        case "Prod.Prev.OS": prodprevos = b[dc.Value].Trim(); break;
                        case "Prod.Entr.OS": prodentros = b[dc.Value].Trim(); break;
                        case "Fora Estoque": foraestoque = b[dc.Value].Trim(); break;
                        case "Trânsito": transito = b[dc.Value].Trim(); break;
                        case "De Terceiros": deterceiros = b[dc.Value].Trim(); break;
                        case "Venda Consign.": vendaconsign = b[dc.Value].Trim(); break;
                        case "Compra Entr.Futura": compraentrfutura = b[dc.Value].Trim(); break;
                        case "Venda Entr.Futura": vendaentrfutura = b[dc.Value].Trim(); break;
                        case "Compra  Consig": compraconsig = b[dc.Value].Trim(); break;
                        case "Aguardando CQ": aguardandocq = b[dc.Value].Trim(); break;
                        case "Estq. Mínimo": estqminimo = b[dc.Value].Trim(); break;
                        case "Estq. Máximo": estqmaximo = b[dc.Value].Trim(); break;
                        case "Reserva De Vendas": reservadevendas = b[dc.Value].Trim(); break;
                        case "Prateleira": prateleira = b[dc.Value].Trim(); break;
                        case "Saldo (Pedido Data Entrega Excedida)": saldopedidodataentregaexcedida = b[dc.Value].Trim(); break;
                        case "Prev. Fabric.": prevfabric = b[dc.Value].Trim(); break;
                        case "Dias sem Movimento": diassemmovimento = b[dc.Value].Trim(); break;
                        case "ESTAB": estab = b[dc.Value].Trim(); break;
                        case "DEPOSITO": deposito = valor; break;
                        case "EMP_FIL": emp_fil = b[dc.Value].Trim(); break;
                        case "QT_CCON": qt_ccon = b[dc.Value].Trim(); break;
                        case "GR1": gr1 = b[dc.Value].Trim(); break;
                        case "DESCR_2": descr_2 = b[dc.Value].Trim(); break;
                        case "FORNECED_2": forneced_2 = b[dc.Value].Trim(); break;
                        case "RESERVADO_11": reservado_11 = b[dc.Value].Trim(); break;
                        case "Valor Últ.Fech.": valorultfech = b[dc.Value].Trim(); break;
                        case "Custo Médio Simulado": customediosimulado = b[dc.Value].Trim(); break;
                        case "Custo Médio": customedio = b[dc.Value].Trim(); break;
                        case "Preço Lista Padrão": precolistapadrao = b[dc.Value].Trim(); break;
                        case "Descrição2": descricao2 = b[dc.Value].Trim(); break;
                    }
                }
                lista.Add(new SaldoDeTerceiro
                {
                    Produto = produto,
                    Traducao = traducao,
                    Descricao = descricao,
                    Unid = unid,
                    Lote = lote,
                    Grupo = grupo,
                    Disponivel = Convert.ToDouble(disponivel),
                    SaldoAtual = Convert.ToDouble(saldoatual),
                    SaldoUltFech = Convert.ToDouble(saldoultfech),
                    Entradas = Convert.ToDouble(entradas),
                    Saidas = Convert.ToDouble(saidas),
                    PedCompras = Convert.ToDouble(pedcompras),
                    PedVendas = Convert.ToDouble(pedvendas),
                    ConsuPrevOs = Convert.ToDouble(consuprevos),
                    JaRequisOS = Convert.ToDouble(jarequisos),
                    ProdPrevOS = Convert.ToDouble(prodprevos),
                    ProdEntrOS = Convert.ToDouble(prodentros),
                    ForaEstoque = Convert.ToDouble(foraestoque),
                    Transito = Convert.ToDouble(transito),
                    DeTerceiros = Convert.ToDouble(deterceiros),
                    VendaConsign = Convert.ToDouble(vendaconsign),
                    CompraEntrFutura = Convert.ToDouble(compraentrfutura),
                    VendaEntrFutura = Convert.ToDouble(vendaentrfutura),
                    CompraConsig = Convert.ToDouble(compraconsig),
                    AguardandoCQ = Convert.ToDouble(aguardandocq),
                    EstqMinimo = Convert.ToDouble(estqminimo),
                    EstqMaximo = Convert.ToDouble(estqmaximo),
                    ReservaDeVendas = Convert.ToDouble(reservadevendas),
                    Prateleira = prateleira,
                    SaldoPedidoDataEntregaExcedida = Convert.ToDouble(saldopedidodataentregaexcedida),
                    PrevFabric = Convert.ToDouble(prevfabric),
                    DiassemMovimento = Convert.ToDouble(diassemmovimento),
                    EMP_FIL = emp_fil,
                    ESTAB = estab,
                    DEPOSITO = deposito,
                    QT_CCON = qt_ccon,
                    GR1 = gr1,
                    DESCR_2 = descr_2,
                    FORNECED_2 = forneced_2,
                    RESERVADO_11 = Convert.ToDouble(reservado_11),
                    ValorUltFech = Convert.ToDouble(valorultfech),
                    CustoMedioSimulado = Convert.ToDouble(customediosimulado),
                    CustoMedio = Convert.ToDouble(customedio),
                    PrecoListaPadrao = Convert.ToDouble(precolistapadrao),
                    Descricao2 = descricao2,
                });
            }
            sr.Close();
            st.Close();
            return lista;
        }

        //OrdensDeProducao
        internal static List<OrdensDeProducao> OrdensDeProducao(string path)
        {

            fullpath = path;
            ObterLinha();
            List<OrdensDeProducao> lista = new List<OrdensDeProducao>();

            while ((linha = sr.ReadLine()) != null)
            {

                string[] b = new string[dic.Count];
                b = linha.Replace("\"", "").Replace("'", "").Split('\t');

                string nroop = "", statusop = "", estabelecimento = "", deposito = "", produto = "", traducao = "", quantidadeprev = "", quantidadedigitada = "", fator = "", saldo = "",
                    roteiro = "", dtinicroteiro = "", dtabertura = "", hrabertura = "", programacao = "", plano = "", dtinicprod = "", dtfimprod = "", reflote = "", tipodeop = "",
                    descricao = "", tipodecusto = "", pesopararateio1 = "", pesopararateio2 = "", pesopararateio3 = "", pesopararateio4 = "", empresa = "", filial = "", status = "",
                    quantidadeapont = "", nr_op_origem = "", dtencerramento = "", dtcancelamento = "", dtliberacao = "", hrencerramento = "", hrcancelamento = "", hrliberacao = "",
                    hrinicioprod = "", hrfimprod = "", cod_obs_gen = "", descricao1 = "", descricao2 = "", observacao = "", docorigem = "", operador = "", dataalter = "", horaalter = "",
                    reservado_02 = "", maxproducao = "", grupo = "", descricaogrupo = "", pedidosdevenda = "";

                try
                {

                    foreach (var dc in dic)
                    {
                        switch (dc.Key)
                        {
                            case "Nro. O.P.": nroop = b[dc.Value].Trim(); break;
                            case "Status O.P.": statusop = b[dc.Value].Trim(); break;
                            case "Estabelecimento": estabelecimento = b[dc.Value].Trim(); break;
                            case "Depósito": deposito = b[dc.Value].Trim(); break;
                            case "Produto": produto = b[dc.Value].Trim(); break;
                            case "Tradução": traducao = b[dc.Value].Trim(); break;
                            case "Quantidade Prev.": quantidadeprev = b[dc.Value].Trim(); break;
                            case "Quantidade Digitada": quantidadedigitada = b[dc.Value].Trim(); break;
                            case "Fator": fator = b[dc.Value].Trim(); break;
                            case "Saldo": saldo = b[dc.Value].Trim(); break;
                            case "Roteiro": roteiro = b[dc.Value].Trim(); break;
                            case "Dt. Inic. Roteiro": dtinicroteiro = b[dc.Value].Trim(); break;
                            case "Dt. Abertura": dtabertura = b[dc.Value].Trim(); break;
                            case "Hr. Abertura": hrabertura = b[dc.Value].Trim(); break;
                            case "Programação": programacao = b[dc.Value].Trim(); break;
                            case "Plano": plano = b[dc.Value].Trim(); break;
                            case "Dt. Inic. Prod.": dtinicprod = b[dc.Value].Trim(); break;
                            case "Dt. Fim Prod.": dtfimprod = b[dc.Value].Trim(); break;
                            case "Ref. Lote": reflote = b[dc.Value].Trim(); break;
                            case "Tipo de OP      ": tipodeop = b[dc.Value].Trim(); break;
                            case "Descrição ": descricao = b[dc.Value].Trim(); break;
                            case "Tipo de Custo": tipodecusto = b[dc.Value].Trim(); break;
                            case "Peso para Rateio 1": pesopararateio1 = b[dc.Value].Trim(); break;
                            case "Peso para Rateio 2": pesopararateio2 = b[dc.Value].Trim(); break;
                            case "Peso para Rateio 3": pesopararateio3 = b[dc.Value].Trim(); break;
                            case "Peso para Rateio 4": pesopararateio4 = b[dc.Value].Trim(); break;
                            case "EMPRESA": empresa = b[dc.Value].Trim(); break;
                            case "FILIAL": filial = b[dc.Value].Trim(); break;
                            case "STATUS": status = b[dc.Value].Trim(); break;
                            case "Quantidade Apont.": quantidadeapont = b[dc.Value].Trim(); break;
                            case "NR_OP_ORIGEM": nr_op_origem = b[dc.Value].Trim(); break;
                            case "Dt. Encerramento": dtencerramento = b[dc.Value].Trim(); break;
                            case "Dt. Cancelamento": dtcancelamento = b[dc.Value].Trim(); break;
                            case "Dt. Liberação": dtliberacao = b[dc.Value].Trim(); break;
                            case "Hr. Encerramento": hrencerramento = b[dc.Value].Trim(); break;
                            case "Hr. Cancelamento": hrcancelamento = b[dc.Value].Trim(); break;
                            case "Hr. Liberação": hrliberacao = b[dc.Value].Trim(); break;
                            case "Hr. Inicio Prod.": hrinicioprod = b[dc.Value].Trim(); break;
                            case "Hr. Fim Prod.": hrfimprod = b[dc.Value].Trim(); break;
                            case "COD_OBS_GEN": cod_obs_gen = b[dc.Value].Trim(); break;
                            case "Descrição 1": descricao1 = b[dc.Value].Trim(); break;
                            case "Descrição 2": descricao2 = b[dc.Value].Trim(); break;
                            case "Observação": observacao = b[dc.Value].Trim(); break;
                            case "Doc. Origem": docorigem = b[dc.Value].Trim(); break;
                            case "Operador": operador = b[dc.Value].Trim(); break;
                            case "Data Alter": dataalter = b[dc.Value].Trim(); break;
                            case "Hora Alter": horaalter = b[dc.Value].Trim(); break;
                            case "RESERVADO_02": reservado_02 = b[dc.Value].Trim(); break;
                            case "% Máx. Produção": maxproducao = b[dc.Value].Trim(); break;
                            case "Grupo": grupo = b[dc.Value].Trim(); break;
                            case "Descrição Grupo": descricaogrupo = b[dc.Value].Trim(); break;
                            case "Pedidos de Venda": pedidosdevenda = b[dc.Value].Trim(); break;

                        }
                    }
                }
                catch (Exception e)
                {
                    Mensagerias.Send("ERRO DD9989 - " + e.Message + "\n---------\n");
                }
                try
                {

                    lista.Add(new OrdensDeProducao
                    {
                        NroOP = Convert.ToInt32(nroop),
                        StatusOP = statusop,
                        Estabelecimento = estabelecimento,
                        Deposito = deposito,
                        Produto = produto,
                        Traducao = traducao,
                        QuantidadePrev = quantidadeprev,
                        QuantidadeDigitada = quantidadedigitada,
                        Fator = fator,
                        Saldo = saldo,
                        Roteiro = roteiro,
                        DtInicRoteiro = dtinicroteiro,
                        DtAbertura = dtabertura,
                        HrAbertura = hrabertura,
                        Programacao = programacao,
                        Plano = plano,
                        DtInicProd = dtinicprod,
                        DtFimProd = dtfimprod,
                        RefLote = reflote,
                        TipodeOP = tipodeop,
                        Descricao = descricao,
                        TipodeCusto = tipodecusto,
                        PesoparaRateio1 = pesopararateio1,
                        PesoparaRateio2 = pesopararateio2,
                        PesoparaRateio3 = pesopararateio3,
                        PesoparaRateio4 = pesopararateio4,
                        EMPRESA = empresa,
                        FILIAL = filial,
                        STATUS = status,
                        QuantidadeApont = quantidadeapont,
                        NR_OP_ORIGEM = nr_op_origem,
                        DtEncerramento = dtencerramento,
                        DtCancelamento = dtcancelamento,
                        DtLiberacao = dtliberacao,
                        HrEncerramento = hrencerramento,
                        HrCancelamento = hrcancelamento,
                        HrLiberacao = hrliberacao,
                        HrInicioProd = hrinicioprod,
                        HrFimProd = hrfimprod,
                        COD_OBS_GEN = cod_obs_gen,
                        Descricao1 = descricao1,
                        Descricao2 = descricao2,
                        Observacao = observacao,
                        DocOrigem = docorigem,
                        Operador = operador,
                        DataAlter = dataalter,
                        HoraAlter = horaalter,
                        RESERVADO_02 = reservado_02,
                        MaxProducao = maxproducao,
                        Grupo = grupo,
                        DescricaoGrupo = descricaogrupo,
                        PedidosDeVenda = pedidosdevenda
                    });
                }
                catch (Exception e)
                {
                    Mensagerias.Send("ERRO HG996 - " + e.Message + "\n---------\n");
                }
            }
            sr.Close();
            st.Close();
            return lista;
        }

        //NFsDinamicaProduto
        internal static List<NotasFiscaisDinamicaProduto> NFsDinamicaProduto(string path)
        {

            fullpath = path;
            ObterLinha();
            List<NotasFiscaisDinamicaProduto> lista = new List<NotasFiscaisDinamicaProduto>();



            while ((linha = sr.ReadLine()) != null)
            {

                string[] b = new string[dic.Count];
                b = linha.Replace("\"", "").Replace("'", "").Split('\t');

                string notafiscal = "", serie = "", fornecedor = "", linhaa = "", datamovimento = "", tipomovto = "", estabelecimento = "", deposito = "", produto = "", quantidade = "",
                    pesoliquido = "", pesobruto = "", valorunitario = "", valordasmercadorias = "", valoradicionalfinanceiro = "", valordesconto = "", valorembalagem = "", valorfrete = "",
                    valoricms = "", valoricmssubst = "", porcentagemiss = "", valoripi = "", valoriss = "", valorpis = "", valorcofins = "", valorseguro = "", porcentagemir = "",
                    valorirretido = "", tratamentofiscal = "", cfop = "", posicaofiscal = "", porcentagemicms = "", valoripisobrefrete = "", vrdesczonafranca = "", docenvio = "", pedido = "",
                    idcusto = "", valorinss = "", notafiscalorigem = "", serienforigem = "", centrodecusto = "", digccusto = "", tipodecontabilizacao = "", pis = "", cofins = "", numerodadi = "",
                    datadeemissao = "", territorio = "", vendedor = "", supervisor = "", gerente = "", datadesaida = "", estado = "", emissao = "", observacaonolivro = "", fretepago_apagar = "",
                    especienf = "", placa = "", transportador = "", irvencimento = "", porcicmssubst = "", cnpj_cgc = "", nomefantasia = "", descricaodoproduto = "", valorliquido = "",
                    descontozonafranca = "", impostodeimportacao = "", percentpissubsttrib = "", valorpissubsttrib = "", percentcofinssubsttrib = "", valorcofinssubsttrib = "",
                    valorderetencaodepis = "", valorderetencaodecofins = "", valorderetencaodecsll = "", descontoicmsconv100_97 = "", valorfunrural = "", despesasaduaneiras = "",
                    valorafrmm = "", finalidade = "", vrbaseicmssubsttribsubstituidoposterior = "", vricmssubsttribsubstituidoposterior = "", vrfcp = "", vricmsdest = "", vricmsorig = "",
                    basedecofins = "", basedepis = "", valorinssretido = "", icmsstoperacoesdefrete = "", descricaotipomovimento = "", numeronfeletronica = "", descricaocfop = "",
                    descricaoposfiscal = "", cstpis = "", cstcofins = "", razaosocial = "", emp_fil = "", tipo_movto = "", com_ven = "", entr_said = "", icm_sp = "", inf_trad = "", tem_nfda = "",
                    unidade = "", base_unit = "", dt_vencto = "", cond_pgto = "", qtde_rec = "", qtde_alter = "", qt_alt_rec = "", tab_preco = "", cod_embal = "", vlr_dif_aliq_icms = "",
                    vlr_repasse = "", adic_ir_percent = "", adic_ir = "", cod_trib = "", porc_ipi = "", porc_icm_s_frete = "", porc_ipi_s_frete = "", base_icm = "", base_icm_subst = "",
                    icm_s_frete = "", base_icm_s_frete = "", base_ipi_s_frete = "", base_ipi = "", bonif = "", nro_os = "", operacao = "", item_ped = "", alt_estq = "", alt_estq_terc = "",
                    alt_custo = "", ja_proc = "", porc_comis = "", porc_com_sup = "", porc_com_ger = "", vr_com_vend = "", vr_com_sup = "", vr_com_ger = "", vr_com_lq_vend = "",
                    vr_com_lq_sup = "", nf_ult_compra = "", sr_ult_compra = "", forn_ult_compra = "", pr_ult_compra = "", texto_esp = "", texto_gen = "", exporta_mv = "", serv_oficina = "",
                    ref_lote = "", ref_unid = "", ref_local = "", nop = "", cod_serv = "", local_cc = "", livre = "", conta = "", dg_conta = "", conta2 = "", dg_conta2 = "", c_custo2 = "",
                    dg_c_custo2 = "", nr_transf_cg = "", cod_erro1 = "", cod_erro2 = "", cod_erro3 = "", vlr_materiais = "", vlr_sub_empr = "", porc_desc_pv = "", porc_adf_pv = "", operador = "",
                    data_alter = "", hora_alter = "", time_stamp = "", reservado_01 = "", reservado_02 = "", reservado_03 = "", reservado_04 = "", reservado_05 = "", reservado_06 = "",
                    reservado_07 = "", reservado_08 = "", reservado_09 = "", reservado_10 = "", reservado_11 = "", reservado_12 = "", reservado_13 = "", dt_emissao_1 = "", cfo_1 = "",
                    vlr_icm_bstp = "", vlr_icm_stp = "", nro_ped = "", dt_ped = "", vlr_fcp_st = "";

                try
                {

                    foreach (var dc in dic)
                    {
                        switch (dc.Key)
                        {
                            case "Nota Fiscal": notafiscal = b[dc.Value].Trim(); break;
                            case "Série": serie = b[dc.Value].Trim(); break;
                            case "Fornecedor": fornecedor = b[dc.Value].Trim(); break;
                            case "Linha": linhaa = b[dc.Value].Trim(); break;
                            case "Data Movimento": datamovimento = b[dc.Value].Trim(); break;
                            case "Tipo Movto": tipomovto = b[dc.Value].Trim(); break;
                            case "Estabelecimento": estabelecimento = b[dc.Value].Trim(); break;
                            case "Depósito": deposito = b[dc.Value].Trim(); break;
                            case "Produto": produto = b[dc.Value].Trim(); break;
                            case "Quantidade": quantidade = b[dc.Value].Trim(); break;
                            case "Peso Líquido": pesoliquido = b[dc.Value].Trim(); break;
                            case "Peso Bruto": pesobruto = b[dc.Value].Trim(); break;
                            case "Valor Unitário": valorunitario = b[dc.Value].Trim(); break;
                            case "Valor das Mercadorias": valordasmercadorias = b[dc.Value].Trim(); break;
                            case "Valor Adicional Financeiro": valoradicionalfinanceiro = b[dc.Value].Trim(); break;
                            case "Valor Desconto": valordesconto = b[dc.Value].Trim(); break;
                            case "Valor Embalagem": valorembalagem = b[dc.Value].Trim(); break;
                            case "Valor Frete": valorfrete = b[dc.Value].Trim(); break;
                            case "Valor ICMS": valoricms = b[dc.Value].Trim(); break;
                            case "Valor ICMS Subst": valoricmssubst = b[dc.Value].Trim(); break;
                            case "Porcentagem ISS": porcentagemiss = b[dc.Value].Trim(); break;
                            case "Valor IPI": valoripi = b[dc.Value].Trim(); break;
                            case "Valor ISS": valoriss = b[dc.Value].Trim(); break;
                            case "Valor PIS": valorpis = b[dc.Value].Trim(); break;
                            case "Valor COFINS": valorcofins = b[dc.Value].Trim(); break;
                            case "Valor Seguro": valorseguro = b[dc.Value].Trim(); break;
                            case "Porcentagem IR": porcentagemir = b[dc.Value].Trim(); break;
                            case "Valor IR Retido": valorirretido = b[dc.Value].Trim(); break;
                            case "Tratamento Fiscal": tratamentofiscal = b[dc.Value].Trim(); break;
                            case "CFOP": cfop = b[dc.Value].Trim(); break;
                            case "Posição Fiscal": posicaofiscal = b[dc.Value].Trim(); break;
                            case "Porcentagem ICMS": porcentagemicms = b[dc.Value].Trim(); break;
                            case "Valor IPI Sobre Frete": valoripisobrefrete = b[dc.Value].Trim(); break;
                            case "Vr. Desc. Zona Franca": vrdesczonafranca = b[dc.Value].Trim(); break;
                            case "Doc Envio": docenvio = b[dc.Value].Trim(); break;
                            case "Pedido": pedido = b[dc.Value].Trim(); break;
                            case "ID Custo": idcusto = b[dc.Value].Trim(); break;
                            case "Valor INSS": valorinss = b[dc.Value].Trim(); break;
                            case "Nota Fiscal Origem": notafiscalorigem = b[dc.Value].Trim(); break;
                            case "Série NF Origem": serienforigem = b[dc.Value].Trim(); break;
                            case "Centro de Custo": centrodecusto = b[dc.Value].Trim(); break;
                            case "Dig. C. Custo": digccusto = b[dc.Value].Trim(); break;
                            case "Tipo de Contabilização": tipodecontabilizacao = b[dc.Value].Trim(); break;
                            case "% PIS": pis = b[dc.Value].Trim(); break;
                            case "% COFINS": cofins = b[dc.Value].Trim(); break;
                            case "Número da DI": numerodadi = b[dc.Value].Trim(); break;
                            case "Data de Emissão": datadeemissao = b[dc.Value].Trim(); break;
                            case "Território": territorio = b[dc.Value].Trim(); break;
                            case "Vendedor": vendedor = b[dc.Value].Trim(); break;
                            case "Supervisor": supervisor = b[dc.Value].Trim(); break;
                            case "Gerente": gerente = b[dc.Value].Trim(); break;
                            case "Data de Saída": datadesaida = b[dc.Value].Trim(); break;
                            case "Estado": estado = b[dc.Value].Trim(); break;
                            case "Emissão": emissao = b[dc.Value].Trim(); break;
                            case "Observação no Livro": observacaonolivro = b[dc.Value].Trim(); break;
                            case "Frete Pago/A Pagar": fretepago_apagar = b[dc.Value].Trim(); break;
                            case "Espécie NF": especienf = b[dc.Value].Trim(); break;
                            case "Placa": placa = b[dc.Value].Trim(); break;
                            case "Transportador": transportador = b[dc.Value].Trim(); break;
                            case "IR Vencimento": irvencimento = b[dc.Value].Trim(); break;
                            case "Porc. ICMS Subst": porcicmssubst = b[dc.Value].Trim(); break;
                            case "CNPJ/CGC": cnpj_cgc = b[dc.Value].Trim(); break;
                            case "Nome Fantasia": nomefantasia = b[dc.Value].Trim(); break;
                            case "Descrição do Produto": descricaodoproduto = b[dc.Value].Trim(); break;
                            case "Valor Líquido": valorliquido = b[dc.Value].Trim(); break;
                            case "Desconto Zona Franca (%)": descontozonafranca = b[dc.Value].Trim(); break;
                            case "Imposto de Importação": impostodeimportacao = b[dc.Value].Trim(); break;
                            case "Percent. PIS - Subst. Trib": percentpissubsttrib = b[dc.Value].Trim(); break;
                            case "Valor PIS - Subst. Trib": valorpissubsttrib = b[dc.Value].Trim(); break;
                            case "Percent. COFINS Subst. Trib.": percentcofinssubsttrib = b[dc.Value].Trim(); break;
                            case "Valor COFINS Subst. Trib.": valorcofinssubsttrib = b[dc.Value].Trim(); break;
                            case "Valor de retenção de PIS": valorderetencaodepis = b[dc.Value].Trim(); break;
                            case "Valor de retenção de COFINS": valorderetencaodecofins = b[dc.Value].Trim(); break;
                            case "Valor de retenção de CSLL": valorderetencaodecsll = b[dc.Value].Trim(); break;
                            case "Desconto ICMS Conv. 100/97": descontoicmsconv100_97 = b[dc.Value].Trim(); break;
                            case "Valor FUNRURAL": valorfunrural = b[dc.Value].Trim(); break;
                            case "Despesas Aduaneiras": despesasaduaneiras = b[dc.Value].Trim(); break;
                            case "Valor AFRMM": valorafrmm = b[dc.Value].Trim(); break;
                            case "Finalidade": finalidade = b[dc.Value].Trim(); break;
                            case "Vr Base ICMS Subst. Trib. - Substituído Posterior": vrbaseicmssubsttribsubstituidoposterior = b[dc.Value].Trim(); break;
                            case "Vr ICMS Subst. Trib. - Substituído Posterior": vricmssubsttribsubstituidoposterior = b[dc.Value].Trim(); break;
                            case "Vr. FCP": vrfcp = b[dc.Value].Trim(); break;
                            case "Vr. ICMS Dest.": vricmsdest = b[dc.Value].Trim(); break;
                            case "Vr. ICMS Orig.": vricmsorig = b[dc.Value].Trim(); break;
                            case "Base de COFINS": basedecofins = b[dc.Value].Trim(); break;
                            case "Base de PIS": basedepis = b[dc.Value].Trim(); break;
                            case "Valor INSS Retido": valorinssretido = b[dc.Value].Trim(); break;
                            case "ICMS ST - Operações de Frete": icmsstoperacoesdefrete = b[dc.Value].Trim(); break;
                            case "Descrição Tipo Movimento": descricaotipomovimento = b[dc.Value].Trim(); break;
                            case "Número NF Eletrônica": numeronfeletronica = b[dc.Value].Trim(); break;
                            case "Descrição CFOP": descricaocfop = b[dc.Value].Trim(); break;
                            case "Descrição Pos. Fiscal": descricaoposfiscal = b[dc.Value].Trim(); break;
                            case "CST PIS": cstpis = b[dc.Value].Trim(); break;
                            case "CST COFINS": cstcofins = b[dc.Value].Trim(); break;
                            case "Razão Social": razaosocial = b[dc.Value].Trim(); break;
                            case "EMP_FIL": emp_fil = b[dc.Value].Trim(); break;
                            case "TIPO_MOVTO": tipo_movto = b[dc.Value].Trim(); break;
                            case "COM_VEN": com_ven = b[dc.Value].Trim(); break;
                            case "ENTR_SAID": entr_said = b[dc.Value].Trim(); break;
                            case "ICM_SP": icm_sp = b[dc.Value].Trim(); break;
                            case "INF_TRAD": inf_trad = b[dc.Value].Trim(); break;
                            case "TEM_NFDA": tem_nfda = b[dc.Value].Trim(); break;
                            case "UNIDADE": unidade = b[dc.Value].Trim(); break;
                            case "BASE_UNIT": base_unit = b[dc.Value].Trim(); break;
                            case "DT_VENCTO": dt_vencto = b[dc.Value].Trim(); break;
                            case "COND_PGTO": cond_pgto = b[dc.Value].Trim(); break;
                            case "QTDE_REC": qtde_rec = b[dc.Value].Trim(); break;
                            case "QTDE_ALTER": qtde_alter = b[dc.Value].Trim(); break;
                            case "QT_ALT_REC": qt_alt_rec = b[dc.Value].Trim(); break;
                            case "TAB_PRECO": tab_preco = b[dc.Value].Trim(); break;
                            case "COD_EMBAL": cod_embal = b[dc.Value].Trim(); break;
                            case "VLR_DIF_ALIQ_ICMS": vlr_dif_aliq_icms = b[dc.Value].Trim(); break;
                            case "VLR_REPASSE": vlr_repasse = b[dc.Value].Trim(); break;
                            case "ADIC_IR_PERCENT": adic_ir_percent = b[dc.Value].Trim(); break;
                            case "ADIC_IR": adic_ir = b[dc.Value].Trim(); break;
                            case "COD_TRIB": cod_trib = b[dc.Value].Trim(); break;
                            case "PORC_IPI": porc_ipi = b[dc.Value].Trim(); break;
                            case "PORC_ICM_S_FRETE": porc_icm_s_frete = b[dc.Value].Trim(); break;
                            case "PORC_IPI_S_FRETE": porc_ipi_s_frete = b[dc.Value].Trim(); break;
                            case "BASE_ICM": base_icm = b[dc.Value].Trim(); break;
                            case "BASE_ICM_SUBST": base_icm_subst = b[dc.Value].Trim(); break;
                            case "ICM_S_FRETE": icm_s_frete = b[dc.Value].Trim(); break;
                            case "BASE_ICM_S_FRETE": base_icm_s_frete = b[dc.Value].Trim(); break;
                            case "BASE_IPI_S_FRETE": base_ipi_s_frete = b[dc.Value].Trim(); break;
                            case "BASE_IPI": base_ipi = b[dc.Value].Trim(); break;
                            case "BONIF": bonif = b[dc.Value].Trim(); break;
                            case "NRO_OS": nro_os = b[dc.Value].Trim(); break;
                            case "OPERACAO": operacao = b[dc.Value].Trim(); break;
                            case "ITEM_PED": item_ped = b[dc.Value].Trim(); break;
                            case "ALT_ESTQ": alt_estq = b[dc.Value].Trim(); break;
                            case "ALT_ESTQ_TERC": alt_estq_terc = b[dc.Value].Trim(); break;
                            case "ALT_CUSTO": alt_custo = b[dc.Value].Trim(); break;
                            case "JA_PROC": ja_proc = b[dc.Value].Trim(); break;
                            case "PORC_COMIS": porc_comis = b[dc.Value].Trim(); break;
                            case "PORC_COM_SUP": porc_com_sup = b[dc.Value].Trim(); break;
                            case "PORC_COM_GER": porc_com_ger = b[dc.Value].Trim(); break;
                            case "VR_COM_VEND": vr_com_vend = b[dc.Value].Trim(); break;
                            case "VR_COM_SUP": vr_com_sup = b[dc.Value].Trim(); break;
                            case "VR_COM_GER": vr_com_ger = b[dc.Value].Trim(); break;
                            case "VR_COM_LQ_VEND": vr_com_lq_vend = b[dc.Value].Trim(); break;
                            case "VR_COM_LQ_SUP": vr_com_lq_sup = b[dc.Value].Trim(); break;
                            case "NF_ULT_COMPRA": nf_ult_compra = b[dc.Value].Trim(); break;
                            case "SR_ULT_COMPRA": sr_ult_compra = b[dc.Value].Trim(); break;
                            case "FORN_ULT_COMPRA": forn_ult_compra = b[dc.Value].Trim(); break;
                            case "PR_ULT_COMPRA": pr_ult_compra = b[dc.Value].Trim(); break;
                            case "TEXTO_ESP": texto_esp = b[dc.Value].Trim(); break;
                            case "TEXTO_GEN": texto_gen = b[dc.Value].Trim(); break;
                            case "EXPORTA_MV": exporta_mv = b[dc.Value].Trim(); break;
                            case "SERV_OFICINA": serv_oficina = b[dc.Value].Trim(); break;
                            case "REF_LOTE": ref_lote = b[dc.Value].Trim(); break;
                            case "REF_UNID": ref_unid = b[dc.Value].Trim(); break;
                            case "REF_LOCAL": ref_local = b[dc.Value].Trim(); break;
                            case "NOP": nop = b[dc.Value].Trim(); break;
                            case "COD_SERV": cod_serv = b[dc.Value].Trim(); break;
                            case "LOCAL_CC": local_cc = b[dc.Value].Trim(); break;
                            case "LIVRE": livre = b[dc.Value].Trim(); break;
                            case "CONTA": conta = b[dc.Value].Trim(); break;
                            case "DG_CONTA": dg_conta = b[dc.Value].Trim(); break;
                            case "CONTA2": conta2 = b[dc.Value].Trim(); break;
                            case "DG_CONTA2": dg_conta2 = b[dc.Value].Trim(); break;
                            case "C_CUSTO2": c_custo2 = b[dc.Value].Trim(); break;
                            case "DG_C_CUSTO2": dg_c_custo2 = b[dc.Value].Trim(); break;
                            case "NR_TRANSF_CG": nr_transf_cg = b[dc.Value].Trim(); break;
                            case "COD_ERRO1": cod_erro1 = b[dc.Value].Trim(); break;
                            case "COD_ERRO2": cod_erro2 = b[dc.Value].Trim(); break;
                            case "COD_ERRO3": cod_erro3 = b[dc.Value].Trim(); break;
                            case "VLR_MATERIAIS": vlr_materiais = b[dc.Value].Trim(); break;
                            case "VLR_SUB_EMPR": vlr_sub_empr = b[dc.Value].Trim(); break;
                            case "PORC_DESC_PV": porc_desc_pv = b[dc.Value].Trim(); break;
                            case "PORC_ADF_PV": porc_adf_pv = b[dc.Value].Trim(); break;
                            case "OPERADOR": operador = b[dc.Value].Trim(); break;
                            case "DATA_ALTER": data_alter = b[dc.Value].Trim(); break;
                            case "HORA_ALTER": hora_alter = b[dc.Value].Trim(); break;
                            case "TIME_STAMP": time_stamp = b[dc.Value].Trim(); break;
                            case "RESERVADO_01": reservado_01 = b[dc.Value].Trim(); break;
                            case "RESERVADO_02": reservado_02 = b[dc.Value].Trim(); break;
                            case "RESERVADO_03": reservado_03 = b[dc.Value].Trim(); break;
                            case "RESERVADO_04": reservado_04 = b[dc.Value].Trim(); break;
                            case "RESERVADO_05": reservado_05 = b[dc.Value].Trim(); break;
                            case "RESERVADO_06": reservado_06 = b[dc.Value].Trim(); break;
                            case "RESERVADO_07": reservado_07 = b[dc.Value].Trim(); break;
                            case "RESERVADO_08": reservado_08 = b[dc.Value].Trim(); break;
                            case "RESERVADO_09": reservado_09 = b[dc.Value].Trim(); break;
                            case "RESERVADO_10": reservado_10 = b[dc.Value].Trim(); break;
                            case "RESERVADO_11": reservado_11 = b[dc.Value].Trim(); break;
                            case "RESERVADO_12": reservado_12 = b[dc.Value].Trim(); break;
                            case "RESERVADO_13": reservado_13 = b[dc.Value].Trim(); break;
                            case "DT_EMISSAO_1": dt_emissao_1 = b[dc.Value].Trim(); break;
                            case "CFO_1": cfo_1 = b[dc.Value].Trim(); break;
                            case "VLR_ICM_BSTP": vlr_icm_bstp = b[dc.Value].Trim(); break;
                            case "VLR_ICM_STP": vlr_icm_stp = b[dc.Value].Trim(); break;
                            case "NRO_PED": nro_ped = b[dc.Value].Trim(); break;

                        }
                    }
                }
                catch (Exception e)
                {
                    Mensagerias.Send("ERRO SDF566 - " + e.Message + "\n---------\n");
                }

                try
                {

                    lista.Add(new NotasFiscaisDinamicaProduto
                    {
                        NotaFiscal = Convert.ToInt32(notafiscal),
                        Serie = serie,
                        Fornecedor = fornecedor,
                        Linha = linhaa,
                        DataMovimento = Convert.ToDateTime(datamovimento),
                        TipoMovto = tipomovto,
                        Estabelecimento = estabelecimento,
                        Deposito = deposito,
                        Produto = produto,
                        Quantidade = Convert.ToDouble(quantidade),
                        PesoLiquido = pesoliquido,
                        PesoBruto = pesobruto,
                        ValorUnitario = valorunitario,
                        ValordasMercadorias = valordasmercadorias,
                        ValorAdicionalFinanceiro = valoradicionalfinanceiro,
                        ValorDesconto = valordesconto,
                        ValorEmbalagem = valorembalagem,
                        ValorFrete = valorfrete,
                        ValorICMS = valoricms,
                        ValorICMSSubst = valoricmssubst,
                        PorcentagemISS = porcentagemiss,
                        ValorIPI = valoripi,
                        ValorISS = valoriss,
                        ValorPIS = valorpis,
                        ValorCOFINS = valorcofins,
                        ValorSeguro = valorseguro,
                        PorcentagemIR = porcentagemir,
                        ValorIRRetido = valorirretido,
                        TratamentoFiscal = tratamentofiscal,
                        CFOP = cfop,
                        PosicaoFiscal = posicaofiscal,
                        PorcentagemICMS = porcentagemicms,
                        ValorIPISobreFrete = valoripisobrefrete,
                        VrDescZonaFranca = vrdesczonafranca,
                        DocEnvio = docenvio,
                        Pedido = Convert.ToInt32(pedido),
                        IDCusto = idcusto,
                        ValorINSS = valorinss,
                        NotaFiscalOrigem = notafiscalorigem,
                        SerieNFOrigem = serienforigem,
                        CentrodeCusto = centrodecusto,
                        DigCCusto = digccusto,
                        TipodeContabilizacao = tipodecontabilizacao,
                        PIS = pis,
                        COFINS = cofins,
                        NumerodaDI = numerodadi,
                        DatadeEmissao = Convert.ToDateTime(datadeemissao),
                        Territorio = territorio,
                        Vendedor = vendedor,
                        Supervisor = supervisor,
                        Gerente = gerente,
                        DatadeSaida = datadesaida,
                        Estado = estado,
                        Emissao = emissao,
                        ObservacaonoLivro = observacaonolivro,
                        FretePago_APagar = fretepago_apagar,
                        EspecieNF = especienf,
                        Placa = placa,
                        Transportador = transportador,
                        IRVencimento = irvencimento,
                        PorcICMSSubst = porcicmssubst,
                        CNPJ_CGC = cnpj_cgc,
                        NomeFantasia = nomefantasia,
                        DescricaodoProduto = descricaodoproduto,
                        ValorLiquido = valorliquido,
                        DescontoZonaFranca = descontozonafranca,
                        ImpostodeImportacao = impostodeimportacao,
                        PercentPISSubstTrib = percentpissubsttrib,
                        ValorPISSubstTrib = valorpissubsttrib,
                        PercentCOFINSSubstTrib = percentcofinssubsttrib,
                        ValorCOFINSSubstTrib = valorcofinssubsttrib,
                        ValorderetencaodePIS = valorderetencaodepis,
                        ValorderetencaodeCOFINS = valorderetencaodecofins,
                        ValorderetencaodeCSLL = valorderetencaodecsll,
                        DescontoICMSConv100_97 = descontoicmsconv100_97,
                        ValorFUNRURAL = valorfunrural,
                        DespesasAduaneiras = despesasaduaneiras,
                        ValorAFRMM = valorafrmm,
                        Finalidade = finalidade,
                        VrBaseICMSSubstTribSubstituidoPosterior = vrbaseicmssubsttribsubstituidoposterior,
                        VrICMSSubstTribSubstituidoPosterior = vricmssubsttribsubstituidoposterior,
                        VrFCP = vrfcp,
                        VrICMSDest = vricmsdest,
                        VrICMSOrig = vricmsorig,
                        BasedeCOFINS = basedecofins,
                        BasedePIS = basedepis,
                        ValorINSSRetido = valorinssretido,
                        ICMSSTOperacoesdeFrete = icmsstoperacoesdefrete,
                        DescricaoTipoMovimento = descricaotipomovimento,
                        NumeroNFEletronica = numeronfeletronica,
                        DescricaoCFOP = descricaocfop,
                        DescricaoPosFiscal = descricaoposfiscal,
                        CSTPIS = cstpis,
                        CSTCOFINS = cstcofins,
                        RazaoSocial = razaosocial,
                        EMP_FIL = emp_fil,
                        TIPO_MOVTO = tipo_movto,
                        COM_VEN = com_ven,
                        ENTR_SAID = entr_said,
                        ICM_SP = icm_sp,
                        INF_TRAD = inf_trad,
                        TEM_NFDA = tem_nfda,
                        UNIDADE = unidade,
                        BASE_UNIT = base_unit,
                        DT_VENCTO = dt_vencto,
                        COND_PGTO = cond_pgto,
                        QTDE_REC = qtde_rec,
                        QTDE_ALTER = qtde_alter,
                        QT_ALT_REC = qt_alt_rec,
                        TAB_PRECO = tab_preco,
                        COD_EMBAL = cod_embal,
                        VLR_DIF_ALIQ_ICMS = vlr_dif_aliq_icms,
                        VLR_REPASSE = vlr_repasse,
                        ADIC_IR_PERCENT = adic_ir_percent,
                        ADIC_IR = adic_ir,
                        COD_TRIB = cod_trib,
                        PORC_IPI = porc_ipi,
                        PORC_ICM_S_FRETE = porc_icm_s_frete,
                        PORC_IPI_S_FRETE = porc_ipi_s_frete,
                        BASE_ICM = base_icm,
                        BASE_ICM_SUBST = base_icm_subst,
                        ICM_S_FRETE = icm_s_frete,
                        BASE_ICM_S_FRETE = base_icm_s_frete,
                        BASE_IPI_S_FRETE = base_ipi_s_frete,
                        BASE_IPI = base_ipi,
                        BONIF = bonif,
                        NRO_OS = nro_os,
                        OPERACAO = operacao,
                        ITEM_PED = item_ped,
                        ALT_ESTQ = alt_estq,
                        ALT_ESTQ_TERC = alt_estq_terc,
                        ALT_CUSTO = alt_custo,
                        JA_PROC = ja_proc,
                        PORC_COMIS = porc_comis,
                        PORC_COM_SUP = porc_com_sup,
                        PORC_COM_GER = porc_com_ger,
                        VR_COM_VEND = vr_com_vend,
                        VR_COM_SUP = vr_com_sup,
                        VR_COM_GER = vr_com_ger,
                        VR_COM_LQ_VEND = vr_com_lq_vend,
                        VR_COM_LQ_SUP = vr_com_lq_sup,
                        NF_ULT_COMPRA = nf_ult_compra,
                        SR_ULT_COMPRA = sr_ult_compra,
                        FORN_ULT_COMPRA = forn_ult_compra,
                        PR_ULT_COMPRA = pr_ult_compra,
                        TEXTO_ESP = texto_esp,
                        TEXTO_GEN = texto_gen,
                        EXPORTA_MV = exporta_mv,
                        SERV_OFICINA = serv_oficina,
                        REF_LOTE = ref_lote,
                        REF_UNID = ref_unid,
                        REF_LOCAL = ref_local,
                        NOP = nop,
                        COD_SERV = cod_serv,
                        LOCAL_CC = local_cc,
                        LIVRE = livre,
                        CONTA = conta,
                        DG_CONTA = dg_conta,
                        CONTA2 = conta2,
                        DG_CONTA2 = dg_conta2,
                        C_CUSTO2 = c_custo2,
                        DG_C_CUSTO2 = dg_c_custo2,
                        NR_TRANSF_CG = nr_transf_cg,
                        COD_ERRO1 = cod_erro1,
                        COD_ERRO2 = cod_erro2,
                        COD_ERRO3 = cod_erro3,
                        VLR_MATERIAIS = vlr_materiais,
                        VLR_SUB_EMPR = vlr_sub_empr,
                        PORC_DESC_PV = porc_desc_pv,
                        PORC_ADF_PV = porc_adf_pv,
                        OPERADOR = operador,
                        DATA_ALTER = data_alter,
                        HORA_ALTER = hora_alter,
                        TIME_STAMP = time_stamp,
                        RESERVADO_01 = reservado_01,
                        RESERVADO_02 = reservado_02,
                        RESERVADO_03 = reservado_03,
                        RESERVADO_04 = reservado_04,
                        RESERVADO_05 = reservado_05,
                        RESERVADO_06 = reservado_06,
                        RESERVADO_07 = reservado_07,
                        RESERVADO_08 = reservado_08,
                        RESERVADO_09 = reservado_09,
                        RESERVADO_10 = reservado_10,
                        RESERVADO_11 = reservado_11,
                        RESERVADO_12 = reservado_12,
                        RESERVADO_13 = reservado_13,
                        DT_EMISSAO_1 = dt_emissao_1,
                        CFO_1 = cfo_1,
                        VLR_ICM_BSTP = vlr_icm_bstp,
                        VLR_ICM_STP = vlr_icm_stp,
                        NRO_PED = Convert.ToInt32(nro_ped),
                        DT_PED = dt_ped,
                        VLR_FCP_ST = vlr_fcp_st,

                    });
                }
                catch (Exception e)
                {
                    Mensagerias.Send("ERRO 9988 - " + e.Message + "\n---------\n");
                }
            }
            sr.Close();
            st.Close();
            return lista;
        }
    }
}