using Estoque.Classes.ERP;
using Estoque.DAO;
using Estoque.Entidade;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Estoque.Classes
{
    internal class PadronizarColunasDados
    {
        /*
        internal static StringBuilder Saldo()
        {
            int colunas = 46;

            try
            {
                Stream st = File.Open(@"C:\Exports\ExportSaldo.txt", FileMode.Open);
                StreamReader sr = new StreamReader(st, Encoding.Default);
                string linha;

                StringBuilder s = new StringBuilder();
                int f = 0;
                int c = 0;
                int[] sb = new int[33];
                while ((linha = sr.ReadLine()) != null)
                {

                    string l = linha.Replace("\"", "");
                    string[] a = new string[colunas];
                volta:
                    a = linha.Replace("\"", "").Replace("'", "").Split('\t');
                    //se erro na linha
                    if (a.Count() != colunas)
                    {
                        linha = linha + sr.ReadLine();
                        goto volta;
                    }

                    if (c <= 32)
                    {


                        for (int i = 0; i < a.Length; i++)
                        {
                            switch (a[i].ToString())
                            {
                                case "Produto":
                                    sb[0] = i; break;
                                case "Descrição":
                                    {
                                        if (sb[1] == 0)
                                        {
                                            sb[1] = i;
                                        }
                                        break;
                                    }
                                case "Unid":
                                    sb[2] = i; break;
                                case "Grupo":
                                    sb[3] = i; break;
                                case "Disponível":
                                    sb[4] = i; break;
                                case "Saldo Atual":
                                    sb[5] = i; break;
                                case "Saldo Últ.Fech.":
                                    sb[6] = i; break;
                                case "Entradas":
                                    sb[7] = i; break;
                                case "Saídas":
                                    sb[8] = i; break;
                                case "Ped.Compras":
                                    sb[9] = i; break;
                                case "Ped.Vendas":
                                    sb[10] = i; break;
                                case "Consu.Prev.Os":
                                    sb[11] = i; break;
                                case "Já Requis.OS":
                                    sb[12] = i; break;
                                case "Prod.Prev.OS":
                                    sb[13] = i; break;
                                case "Fora Estoque":
                                    sb[14] = i; break;
                                case "Trânsito":
                                    sb[15] = i; break;
                                case "De Terceiros":
                                    sb[16] = i; break;
                                case "Venda Consign.":
                                    sb[17] = i; break;
                                case "Compra Entr.Futura":
                                    sb[18] = i; break;
                                case "Venda Entr.Futura":
                                    sb[19] = i; break;
                                case "Compra  Consig":
                                    sb[20] = i; break;
                                case "Aguardando CQ":
                                    sb[21] = i; break;
                                case "Estq. Mínimo":
                                    sb[22] = i; break;
                                case "Estq. Máximo":
                                    sb[23] = i; break;
                                case "Reserva De Vendas":
                                    sb[24] = i; break;
                                case "Prateleira":
                                    sb[25] = i; break;
                                case "Saldo (Pedido Data Entrega Excedida)":
                                    sb[26] = i; break;
                                case "Prev. Fabric.":
                                    sb[27] = i; break;
                                case "Dias sem Movimento":
                                    sb[28] = i; break;
                            }
                            c++;
                        }
                    }

                    if (f != 0)
                    {
                        s.Append("('" + a[sb[0]] + "', '" + a[sb[1]].Trim() + "', '" + a[sb[2]] + "', '" + a[sb[3]] + "', '" + a[sb[4]].Replace(",", ".") + "', '" + a[sb[5]].Replace(",", ".") + "', '" + a[sb[6]].Replace(",", ".") + "', '" + a[sb[7]].Replace(",", ".") + "', '" + a[sb[8]].Replace(",", ".") + "', '" + a[sb[9]].Replace(",", ".") + "', '" + a[sb[10]].Replace(",", ".") + "', '" + a[sb[11]].Replace(",", ".") + "', '" + a[sb[12]].Replace(",", ".") + "', '" + a[sb[13]].Replace(",", ".") + "', '" + a[sb[14]].Replace(",", ".") + "', '" + a[sb[15]].Replace(",", ".") + "', '" + a[sb[16]].Replace(",", ".") + "', '" + a[sb[17]].Replace(",", ".") + "', '" + a[sb[18]].Replace(",", ".") + "', '" + a[sb[19]].Replace(",", ".") + "', '" + a[sb[20]].Replace(",", ".") + "', '" + a[sb[21]].Replace(",", ".") + "', '" + a[sb[22]].Replace(",", ".") + "', '" + a[sb[23]].Replace(",", ".") + "', '" + a[sb[24]].Replace(",", ".") + "', '" + a[sb[25]] + "', '" + a[sb[26]].Replace(",", ".") + "', '" + a[sb[27]].Replace(",", ".") + "', '" + a[sb[28]].Replace(",", ".") + "'), ");
                    }
                    f++;
                }
                sr.Close();
                st.Close();
                s.Remove(s.Length - 2, 2);
                return s;
            }
            catch (Exception)
            {
                ControllerERP_Pronto.Saldo();
                Import.SaldoImport();
                return null;

            }

        }

        internal static List<DeTerceiro> DeTerceiros2()
        {
            int colunas = 70;
            Stream st = File.OpenRead(@"C:\Exports\DeTerceiro.txt");
            StreamReader sr = new StreamReader(st, Encoding.Default);
            string linha = sr.ReadLine();
            Dictionary<string, int> dicionario = ColunarPadraoDeTerceiro(linha);
            var d = dicionario.OrderBy(p => p.Value);
            var dic = new Dictionary<string, int>();
            List<DeTerceiro> lista = new List<DeTerceiro>();

            foreach (var i in d)
            {
                dic.Add(i.Key, i.Value);
            }

            while ((linha = sr.ReadLine()) != null)
            {


                string l = linha.Replace("\"", "");
                string[] a, b = new string[colunas];
            volta:
                b = linha.Replace("\"", "").Replace("'", "").Split('\t');
                //se erro na linha
                if (b.Count() != colunas)
                {
                    linha = linha + sr.ReadLine();
                    goto volta;
                }
                a = b;
                string op = "", docen = "", serie = "", produto = "", traducao = "", tm = "", data = "", cliente = "", docfiscal = "", seriee = "", cont = "", lt = "", qtdenf = "",
                    valornf = "", valorcusto = "", saldoqtde = "", saldocusto = "", observacao = "", nomefantasia = "", descricao = "", valorunitario = "", textoespecificofatbalcao = "",
                    obsnfbalcao = "", tipo_movto_nf = "", nro_fornec = "", seq_fornec = "", qt_enviada = "", vr_env_nf = "", vr_enviado = "", qt_devolv = "", vr_dev_nf = "", vr_devolv = "",
                    estab = "", contt = "", deposito = "", tipo_fe = "", seq = "", emp_fil = "", dt_vencto = "", dt_doc_f = "", qt_fech = "", qt_fech_an = "", vr_fech = "", vr_fech_an = "",
                    vr_fech_nf = "", vr_fean_nf = "", vri_enviad = "", vri_devolv = "", vri_fech = "", vri_fech_an = "", vru_enviad = "", vru_devolv = "", vru_fech = "", vru_fech_an = "",
                    ref_unid = "", ref_local = "", c_custo = "", dg_ccusto = "", c_custo2 = "", dg_ccusto2 = "", conta = "", dg_conta = "", conta2 = "", dg_conta2 = "", tipo_contab = "",
                    data_alter = "", time_stamp = "", hora_alter = "", origem_movto = "", ordem_envio = "";
                ;

                for (int i = 0; i < colunas; i++)
                {
                    switch (i)
                    {
                        case 0: op = a[dicionario["Op"]].Trim(); break;
                        case 1: docen = a[dicionario["Doc.En"]].Trim(); break;
                        case 2: serie = a[dicionario["Serie1"]].Trim(); break;
                        case 3: produto = a[dicionario["Produto"]].Trim(); break;
                        case 4: traducao = a[dicionario["Tradução"]].Trim(); break;
                        case 5: tm = a[dicionario["TM"]].Trim(); break;
                        case 6: data = a[dicionario["Data"]].Trim(); break;
                        case 7: cliente = a[dicionario["Cliente"]].Trim(); break;
                        case 8: docfiscal = a[dicionario["Doc. Fiscal"]].Trim(); break;
                        case 9: seriee = a[dicionario["Serie2"]].Trim(); break;
                        case 10: cont = a[dicionario["Cont1"]].Trim(); break;
                        case 11: lt = a[dicionario["Lt"]].Trim(); break;
                        case 12: qtdenf = a[dicionario["Qtde Nf"]].Trim(); break;
                        case 13: valornf = a[dicionario["Valor Nf"]].Trim(); break;
                        case 14: valorcusto = a[dicionario["Valor Custo"]].Trim(); break;
                        case 15: saldoqtde = a[dicionario["Saldo Qtde"]].Trim(); break;
                        case 16: saldocusto = a[dicionario["Saldo Custo"]].Trim(); break;
                        case 17: observacao = a[dicionario["Observação"]].Trim(); break;
                        case 18: nomefantasia = a[dicionario["Nome Fantasia"]].Trim(); break;
                        case 19: descricao = a[dicionario["Descrição"]].Trim(); break;
                        case 20: valorunitario = a[dicionario["Valor Unitário"]].Trim(); break;
                        case 21: textoespecificofatbalcao = a[dicionario["Texto Específico Fat. Balcão"]].Trim(); break;
                        case 22: obsnfbalcao = a[dicionario["Obs NF Balcão"]].Trim(); break;
                        case 23: tipo_movto_nf = a[dicionario["TIPO_MOVTO_NF"]].Trim(); break;
                        case 24: nro_fornec = a[dicionario["NRO_FORNEC"]].Trim(); break;
                        case 25: seq_fornec = a[dicionario["SEQ_FORNEC"]].Trim(); break;
                        case 26: qt_enviada = a[dicionario["QT_ENVIADA"]].Trim(); break;
                        case 27: vr_env_nf = a[dicionario["VR_ENV_NF"]].Trim(); break;
                        case 28: vr_enviado = a[dicionario["VR_ENVIADO"]].Trim(); break;
                        case 29: qt_devolv = a[dicionario["QT_DEVOLV"]].Trim(); break;
                        case 30: vr_dev_nf = a[dicionario["VR_DEV_NF"]].Trim(); break;
                        case 31: vr_devolv = a[dicionario["VR_DEVOLV"]].Trim(); break;
                        case 32: estab = a[dicionario["ESTAB"]].Trim(); break;
                        case 33: contt = a[dicionario["Cont2"]].Trim(); break;
                        case 34: deposito = a[dicionario["DEPOSITO"]].Trim(); break;
                        case 35: tipo_fe = a[dicionario["TIPO_FE"]].Trim(); break;
                        case 36: seq = a[dicionario["SEQ"]].Trim(); break;
                        case 37: emp_fil = a[dicionario["EMP_FIL"]].Trim(); break;
                        case 38: dt_vencto = a[dicionario["DT_VENCTO"]].Trim(); break;
                        case 39: dt_doc_f = a[dicionario["DT_DOC_F"]].Trim(); break;
                        case 40: qt_fech = a[dicionario["QT_FECH"]].Trim(); break;
                        case 41: qt_fech_an = a[dicionario["QT_FECH_AN"]].Trim(); break;
                        case 42: vr_fech = a[dicionario["VR_FECH"]].Trim(); break;
                        case 43: vr_fech_an = a[dicionario["VR_FECH_AN"]].Trim(); break;
                        case 44: vr_fech_nf = a[dicionario["VR_FECH_NF"]].Trim(); break;
                        case 45: vr_fean_nf = a[dicionario["VR_FEAN_NF"]].Trim(); break;
                        case 46: vri_enviad = a[dicionario["VRI_ENVIAD"]].Trim(); break;
                        case 47: vri_devolv = a[dicionario["VRI_DEVOLV"]].Trim(); break;
                        case 48: vri_fech = a[dicionario["VRI_FECH"]].Trim(); break;
                        case 49: vri_fech_an = a[dicionario["VRI_FECH_AN"]].Trim(); break;
                        case 50: vru_enviad = a[dicionario["VRU_ENVIAD"]].Trim(); break;
                        case 51: vru_devolv = a[dicionario["VRU_DEVOLV"]].Trim(); break;
                        case 52: vru_fech = a[dicionario["VRU_FECH"]].Trim(); break;
                        case 53: vru_fech_an = a[dicionario["VRU_FECH_AN"]].Trim(); break;
                        case 54: ref_unid = a[dicionario["REF_UNID"]].Trim(); break;
                        case 55: ref_local = a[dicionario["REF_LOCAL"]].Trim(); break;
                        case 56: c_custo = a[dicionario["C_CUSTO"]].Trim(); break;
                        case 57: dg_ccusto = a[dicionario["DG_CCUSTO"]].Trim(); break;
                        case 58: c_custo2 = a[dicionario["C_CUSTO2"]].Trim(); break;
                        case 59: dg_ccusto2 = a[dicionario["DG_CCUSTO2"]].Trim(); break;
                        case 60: conta = a[dicionario["CONTA"]].Trim(); break;
                        case 61: dg_conta = a[dicionario["DG_CONTA"]].Trim(); break;
                        case 62: conta2 = a[dicionario["CONTA2"]].Trim(); break;
                        case 63: dg_conta2 = a[dicionario["DG_CONTA2"]].Trim(); break;
                        case 64: tipo_contab = a[dicionario["TIPO_CONTAB"]].Trim(); break;
                        case 65: data_alter = a[dicionario["DATA_ALTER"]].Trim(); break;
                        case 66: time_stamp = a[dicionario["TIME_STAMP"]].Trim(); break;
                        case 67: hora_alter = a[dicionario["HORA_ALTER"]].Trim(); break;
                        case 68: origem_movto = a[dicionario["ORIGEM_MOVTO"]].Trim(); break;
                        case 69: ordem_envio = a[dicionario["ORDEM_ENVIO"]].Trim(); break;


                    }
                }
                lista.Add(new DeTerceiro
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
                    Serie2 = seriee,
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
                    Cont2 = contt,
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
            sr.Close();
            st.Close();
            return lista;
        }

        internal static List<ForaDeEstoque> ForaDeEstoque2()
        {
            int colunas = 70;
            Stream st = File.OpenRead(@"C:\Exports\ForaDeEstoque.txt");
            StreamReader sr = new StreamReader(st, Encoding.Default);
            string linha = sr.ReadLine();
            Dictionary<string, int> dicionario = ColunarPadraoForaDeEstoque(linha);
            var d = dicionario.OrderBy(p => p.Value);
            var dic = new Dictionary<string, int>();
            List<ForaDeEstoque> lista = new List<ForaDeEstoque>();

            foreach (var i in d)
            {
                dic.Add(i.Key, i.Value);
            }

            while ((linha = sr.ReadLine()) != null)
            {


                string l = linha.Replace("\"", "");
                string[] a, b = new string[colunas];
            volta:
                b = linha.Replace("\"", "").Replace("'", "").Split('\t');
                //se erro na linha
                if (b.Count() != colunas)
                {
                    linha = linha + sr.ReadLine();
                    goto volta;
                }
                a = b;
                string op = "", docen = "", serie = "", produto = "", traducao = "", tm = "", data = "", fornecedor = "", docfiscal = "", seriee = "", cont = "", lt = "", qtdenf = "",
                    valornf = "", valorcusto = "", saldoqtde = "", saldocusto = "", observacao = "", nomefantasia = "", descricao = "", valorunitario = "", textoespecificofatbalcao = "",
                    obsnfbalcao = "", tipo_movto_nf = "", nro_fornec = "", seq_fornec = "", qt_enviada = "", vr_env_nf = "", vr_enviado = "", qt_devolv = "", vr_dev_nf = "", vr_devolv = "",
                    estab = "", contt = "", deposito = "", tipo_fe = "", seq = "", emp_fil = "", dt_vencto = "", dt_doc_f = "", qt_fech = "", qt_fech_an = "", vr_fech = "", vr_fech_an = "",
                    vr_fech_nf = "", vr_fean_nf = "", vri_enviad = "", vri_devolv = "", vri_fech = "", vri_fech_an = "", vru_enviad = "", vru_devolv = "", vru_fech = "", vru_fech_an = "",
                    ref_unid = "", ref_local = "", c_custo = "", dg_ccusto = "", c_custo2 = "", dg_ccusto2 = "", conta = "", dg_conta = "", conta2 = "", dg_conta2 = "", tipo_contab = "",
                    data_alter = "", time_stamp = "", hora_alter = "", origem_movto = "", ordem_envio = "";
                ;

                for (int i = 0; i < colunas; i++)
                {
                    switch (i)
                    {
                        case 0: op = a[dicionario["Op"]].Trim(); break;
                        case 1: docen = a[dicionario["Doc.En"]].Trim(); break;
                        case 2: serie = a[dicionario["Serie1"]].Trim(); break;
                        case 3: produto = a[dicionario["Produto"]].Trim(); break;
                        case 4: traducao = a[dicionario["Tradução"]].Trim(); break;
                        case 5: tm = a[dicionario["TM"]].Trim(); break;
                        case 6: data = a[dicionario["Data"]].Trim(); break;
                        case 7: fornecedor = a[dicionario["Fornecedor"]].Trim(); break;
                        case 8: docfiscal = a[dicionario["Doc. Fiscal"]].Trim(); break;
                        case 9: seriee = a[dicionario["Serie2"]].Trim(); break;
                        case 10: cont = a[dicionario["Cont1"]].Trim(); break;
                        case 11: lt = a[dicionario["Lt"]].Trim(); break;
                        case 12: qtdenf = a[dicionario["Qtde Nf"]].Trim(); break;
                        case 13: valornf = a[dicionario["Valor Nf"]].Trim(); break;
                        case 14: valorcusto = a[dicionario["Valor Custo"]].Trim(); break;
                        case 15: saldoqtde = a[dicionario["Saldo Qtde"]].Trim(); break;
                        case 16: saldocusto = a[dicionario["Saldo Custo"]].Trim(); break;
                        case 17: observacao = a[dicionario["Observação"]].Trim(); break;
                        case 18: nomefantasia = a[dicionario["Nome Fantasia"]].Trim(); break;
                        case 19: descricao = a[dicionario["Descrição"]].Trim(); break;
                        case 20: valorunitario = a[dicionario["Valor Unitário"]].Trim(); break;
                        case 21: textoespecificofatbalcao = a[dicionario["Texto Específico Fat. Balcão"]].Trim(); break;
                        case 22: obsnfbalcao = a[dicionario["Obs NF Balcão"]].Trim(); break;
                        case 23: tipo_movto_nf = a[dicionario["TIPO_MOVTO_NF"]].Trim(); break;
                        case 24: nro_fornec = a[dicionario["NRO_FORNEC"]].Trim(); break;
                        case 25: seq_fornec = a[dicionario["SEQ_FORNEC"]].Trim(); break;
                        case 26: qt_enviada = a[dicionario["QT_ENVIADA"]].Trim(); break;
                        case 27: vr_env_nf = a[dicionario["VR_ENV_NF"]].Trim(); break;
                        case 28: vr_enviado = a[dicionario["VR_ENVIADO"]].Trim(); break;
                        case 29: qt_devolv = a[dicionario["QT_DEVOLV"]].Trim(); break;
                        case 30: vr_dev_nf = a[dicionario["VR_DEV_NF"]].Trim(); break;
                        case 31: vr_devolv = a[dicionario["VR_DEVOLV"]].Trim(); break;
                        case 32: estab = a[dicionario["ESTAB"]].Trim(); break;
                        case 33: contt = a[dicionario["Cont2"]].Trim(); break;
                        case 34: deposito = a[dicionario["DEPOSITO"]].Trim(); break;
                        case 35: tipo_fe = a[dicionario["TIPO_FE"]].Trim(); break;
                        case 36: seq = a[dicionario["SEQ"]].Trim(); break;
                        case 37: emp_fil = a[dicionario["EMP_FIL"]].Trim(); break;
                        case 38: dt_vencto = a[dicionario["DT_VENCTO"]].Trim(); break;
                        case 39: dt_doc_f = a[dicionario["DT_DOC_F"]].Trim(); break;
                        case 40: qt_fech = a[dicionario["QT_FECH"]].Trim(); break;
                        case 41: qt_fech_an = a[dicionario["QT_FECH_AN"]].Trim(); break;
                        case 42: vr_fech = a[dicionario["VR_FECH"]].Trim(); break;
                        case 43: vr_fech_an = a[dicionario["VR_FECH_AN"]].Trim(); break;
                        case 44: vr_fech_nf = a[dicionario["VR_FECH_NF"]].Trim(); break;
                        case 45: vr_fean_nf = a[dicionario["VR_FEAN_NF"]].Trim(); break;
                        case 46: vri_enviad = a[dicionario["VRI_ENVIAD"]].Trim(); break;
                        case 47: vri_devolv = a[dicionario["VRI_DEVOLV"]].Trim(); break;
                        case 48: vri_fech = a[dicionario["VRI_FECH"]].Trim(); break;
                        case 49: vri_fech_an = a[dicionario["VRI_FECH_AN"]].Trim(); break;
                        case 50: vru_enviad = a[dicionario["VRU_ENVIAD"]].Trim(); break;
                        case 51: vru_devolv = a[dicionario["VRU_DEVOLV"]].Trim(); break;
                        case 52: vru_fech = a[dicionario["VRU_FECH"]].Trim(); break;
                        case 53: vru_fech_an = a[dicionario["VRU_FECH_AN"]].Trim(); break;
                        case 54: ref_unid = a[dicionario["REF_UNID"]].Trim(); break;
                        case 55: ref_local = a[dicionario["REF_LOCAL"]].Trim(); break;
                        case 56: c_custo = a[dicionario["C_CUSTO"]].Trim(); break;
                        case 57: dg_ccusto = a[dicionario["DG_CCUSTO"]].Trim(); break;
                        case 58: c_custo2 = a[dicionario["C_CUSTO2"]].Trim(); break;
                        case 59: dg_ccusto2 = a[dicionario["DG_CCUSTO2"]].Trim(); break;
                        case 60: conta = a[dicionario["CONTA"]].Trim(); break;
                        case 61: dg_conta = a[dicionario["DG_CONTA"]].Trim(); break;
                        case 62: conta2 = a[dicionario["CONTA2"]].Trim(); break;
                        case 63: dg_conta2 = a[dicionario["DG_CONTA2"]].Trim(); break;
                        case 64: tipo_contab = a[dicionario["TIPO_CONTAB"]].Trim(); break;
                        case 65: data_alter = a[dicionario["DATA_ALTER"]].Trim(); break;
                        case 66: time_stamp = a[dicionario["TIME_STAMP"]].Trim(); break;
                        case 67: hora_alter = a[dicionario["HORA_ALTER"]].Trim(); break;
                        case 68: origem_movto = a[dicionario["ORIGEM_MOVTO"]].Trim(); break;
                        case 69: ordem_envio = a[dicionario["ORDEM_ENVIO"]].Trim(); break;


                    }
                }
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
                    Serie2 = seriee,
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
                    Cont2 = contt,
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
            sr.Close();
            st.Close();
            return lista;
        }

        internal static List<ItensDeEstoque> ItensDeEstoque2()
        {
            int colunas = 114;
            Stream st = File.OpenRead(@"C:\Exports\ItensDeEstoque.txt");
            StreamReader sr = new StreamReader(st, Encoding.Default);
            string linha = sr.ReadLine();
            Dictionary<string, int> dicionario = ColunarPadraoItensDeEstoque(linha);
            var d = dicionario.OrderBy(p => p.Value);
            var dic = new Dictionary<string, int>();
            List<ItensDeEstoque> lista = new List<ItensDeEstoque>();

            foreach (var i in d)
            {
                dic.Add(i.Key, i.Value);
            }

            while ((linha = sr.ReadLine()) != null)
            {
                string l = linha.Replace("\"", "");
                string[] a, b = new string[colunas];
            volta:
                b = linha.Replace("\"", "").Replace("'", "").Split('\t');
                //se erro na linha
                if (b.Count() != colunas)
                {
                    linha = linha + sr.ReadLine();
                    goto volta;
                }
                a = b;
                string codigo = "", precocompra = "", traducao = "", unidade = "", grupo = "", lotes = "", ns = "", descricao = "", quantidadedisponivel = "", saldofisico = "",
                    quantidadeporunidade = "", cubagem = "", pesobruto = "", pesoliquido = "", datadacompra = "", prateleira = "", status = "", itemcadastradoem = "", posicaofiscal = "",
                    complposicaofiscal = "", unidalterdipi = "", fatoruniddipi = "", procedência = "", unalterdipi = "", exdatipi = "", coddofabricantedoproduto = "", exppalm = "",
                    precovenda = "", codigo2 = "", descr_1 = "", descr_2 = "", descricaocompleta = "", codigoexterno = "", estab = "", deposito = "", qtdultfech = "", entradas = "",
                    saidas = "", os_previst = "", foradeestoque = "", vendasconsig = "", comprasconsig = "", resvendas = "", pedvenda = "", preco = "", qt_alt_obr = "", empreqcompra = "",
                    unidadealternativa = "", fatordeconversao = "", codfamilia = "", descricaodafamilia = "", codean13 = "", estoqueminimo = "", estoquemáximo = "", tolerancia = "",
                    leadtime = "", codigodorecolhimento = "", aliquotadeipi = "", livre1 = "", livre2 = "", livre3 = "", livre4 = "", livre5 = "", livre6 = "", livre7 = "", livre8 = "",
                    livre9 = "", livre10 = "", livre11 = "", livre12 = "", livre13 = "", livre14 = "", livre15 = "", livre16 = "", livre17 = "", livre18 = "", livre19 = "", livre20 = "",
                    codigodeservico = "", contacontabil = "", contaconsumo = "", centrodecusto = "", generocotepe = "", tipoitemsped = "", codigoprodutosimilar = "", valorultfech = "",
                    customediosimulado = "", customedio = "", reservado_11 = "", codigodetributacaoam = "", grupodefamilia = "", descricaogrupofamilia = "", descricaocompleta2 = "",
                    descricaos = "", cest = "", conta = "", dgconta = "", contacons = "", dgcontacons = "", centrocusto = "", dgcentrocusto = "", precodereposicao = "", reinf = "",
                    goodsreceipt = "", descricaodogrupo = "", codigodetributacao = "", codigodetributacaoalternativo = "", familia = "", formadepedir = "", fatorunidadencm = "",
                    fatordaunidade = "", unidadealternativaexportacao = "", fatorunidadedipiexportacao = "", aplicacao = "";
                ;
                ;

                for (int i = 0; i < colunas; i++)
                {
                    switch (i)
                    {
                        case 0: codigo = a[dicionario["Código"]].Trim(); break;
                        case 1: precocompra = a[dicionario["Preco Compra"]].Trim(); break;
                        case 2: traducao = a[dicionario["Tradução"]].Trim(); break;
                        case 3: unidade = a[dicionario["Unidade"]].Trim(); break;
                        case 4: grupo = a[dicionario["Grupo"]].Trim(); break;
                        case 5: lotes = a[dicionario["Lotes"]].Trim(); break;
                        case 6: ns = a[dicionario["NS"]].Trim(); break;
                        case 7: descricao = a[dicionario["Descrição"]].Trim(); break;
                        case 8: quantidadedisponivel = a[dicionario["Quantidade Disponível"]].Trim(); break;
                        case 9: saldofisico = a[dicionario["Saldo Físico"]].Trim(); break;
                        case 10: quantidadeporunidade = a[dicionario["Quantidade por Unidade"]].Trim(); break;
                        case 11: cubagem = a[dicionario["Cubagem(m³)"]].Trim(); break;
                        case 12: pesobruto = a[dicionario["Peso Bruto"]].Trim(); break;
                        case 13: pesoliquido = a[dicionario["Peso Líquido"]].Trim(); break;
                        case 14: datadacompra = a[dicionario["Data da Compra"]].Trim(); break;
                        case 15: prateleira = a[dicionario["Prateleira"]].Trim(); break;
                        case 16: status = a[dicionario["Status"]].Trim(); break;
                        case 17: itemcadastradoem = a[dicionario["Item Cadastrado Em"]].Trim(); break;
                        case 18: posicaofiscal = a[dicionario["Posição Fiscal"]].Trim(); break;
                        case 19: complposicaofiscal = a[dicionario["Compl Posição Fiscal"]].Trim(); break;
                        case 20: unidalterdipi = a[dicionario["Unid. Alter. DIPI"]].Trim(); break;
                        case 21: fatoruniddipi = a[dicionario["Fator Unid. DIPI"]].Trim(); break;
                        case 22: procedência = a[dicionario["Procedência"]].Trim(); break;
                        case 23: unalterdipi = a[dicionario["Un. Alter. DIPI"]].Trim(); break;
                        case 24: exdatipi = a[dicionario["EX da TIPI"]].Trim(); break;
                        case 25: coddofabricantedoproduto = a[dicionario["Cód. do Fabricante do Produto"]].Trim(); break;
                        case 26: exppalm = a[dicionario["Exp Palm"]].Trim(); break;
                        case 27: precovenda = a[dicionario["Preço Venda"]].Trim(); break;
                        case 28: codigo2 = a[dicionario["Código"]].Trim(); break;
                        case 29: descr_1 = a[dicionario["DESCR_1"]].Trim(); break;
                        case 30: descr_2 = a[dicionario["DESCR_2"]].Trim(); break;
                        case 31: descricaocompleta = a[dicionario["Descrição Completa"]].Trim(); break;
                        case 32: codigoexterno = a[dicionario["Código Externo"]].Trim(); break;
                        case 33: estab = a[dicionario["ESTAB"]].Trim(); break;
                        case 34: deposito = a[dicionario["DEPOSITO"]].Trim(); break;
                        case 35: qtdultfech = a[dicionario["Qtd Últ. Fech."]].Trim(); break;
                        case 36: entradas = a[dicionario["ENTRADAS"]].Trim(); break;
                        case 37: saidas = a[dicionario["SAIDAS"]].Trim(); break;
                        case 38: os_previst = a[dicionario["OS_PREVIST"]].Trim(); break;
                        case 39: foradeestoque = a[dicionario["Fora de Estoque"]].Trim(); break;
                        case 40: vendasconsig = a[dicionario["Vendas Consig"]].Trim(); break;
                        case 41: comprasconsig = a[dicionario["Compras Consig"]].Trim(); break;
                        case 42: resvendas = a[dicionario["Res. Vendas"]].Trim(); break;
                        case 43: pedvenda = a[dicionario["Ped Venda"]].Trim(); break;
                        case 44: preco = a[dicionario["Preço"]].Trim(); break;
                        case 45: qt_alt_obr = a[dicionario["QT_ALT_OBR"]].Trim(); break;
                        case 46: empreqcompra = a[dicionario["Emp. Req. Compra"]].Trim(); break;
                        case 47: unidadealternativa = a[dicionario["Unidade Alternativa"]].Trim(); break;
                        case 48: fatordeconversao = a[dicionario["Fator de Conversão"]].Trim(); break;
                        case 49: codfamilia = a[dicionario["Cód. Família"]].Trim(); break;
                        case 50: descricaodafamilia = a[dicionario["Descrição da Família"]].Trim(); break;
                        case 51: codean13 = a[dicionario["Cod. EAN 13"]].Trim(); break;
                        case 52: estoqueminimo = a[dicionario["Estoque Mínimo"]].Trim(); break;
                        case 53: estoquemáximo = a[dicionario["Estoque Máximo"]].Trim(); break;
                        case 54: tolerancia = a[dicionario["% de Tolerância"]].Trim(); break;
                        case 55: leadtime = a[dicionario["Leadtime"]].Trim(); break;
                        case 56: codigodorecolhimento = a[dicionario["Código do Recolhimento"]].Trim(); break;
                        case 57: aliquotadeipi = a[dicionario["Alíquota de IPI"]].Trim(); break;
                        case 58: livre1 = a[dicionario["Livre 1"]].Trim(); break;
                        case 59: livre2 = a[dicionario["Livre 2"]].Trim(); break;
                        case 60: livre3 = a[dicionario["Livre 3"]].Trim(); break;
                        case 61: livre4 = a[dicionario["Livre 4"]].Trim(); break;
                        case 62: livre5 = a[dicionario["Livre 5"]].Trim(); break;
                        case 63: livre6 = a[dicionario["Livre 6"]].Trim(); break;
                        case 64: livre7 = a[dicionario["Livre 7"]].Trim(); break;
                        case 65: livre8 = a[dicionario["Livre 8"]].Trim(); break;
                        case 66: livre9 = a[dicionario["Livre 9"]].Trim(); break;
                        case 67: livre10 = a[dicionario["Livre 10"]].Trim(); break;
                        case 68: livre11 = a[dicionario["Livre 11"]].Trim(); break;
                        case 69: livre12 = a[dicionario["Livre 12"]].Trim(); break;
                        case 70: livre13 = a[dicionario["Livre 13"]].Trim(); break;
                        case 71: livre14 = a[dicionario["Livre 14"]].Trim(); break;
                        case 72: livre15 = a[dicionario["Livre 15"]].Trim(); break;
                        case 73: livre16 = a[dicionario["Livre 16"]].Trim(); break;
                        case 74: livre17 = a[dicionario["Livre 17"]].Trim(); break;
                        case 75: livre18 = a[dicionario["Livre 18"]].Trim(); break;
                        case 76: livre19 = a[dicionario["Livre 19"]].Trim(); break;
                        case 77: livre20 = a[dicionario["Livre 20"]].Trim(); break;
                        case 78: codigodeservico = a[dicionario["Código de Serviço"]].Trim(); break;
                        case 79: contacontabil = a[dicionario["Conta Contabil"]].Trim(); break;
                        case 80: contaconsumo = a[dicionario["Conta Consumo"]].Trim(); break;
                        case 81: centrodecusto = a[dicionario["Centro de Custo"]].Trim(); break;
                        case 82: generocotepe = a[dicionario["Gênero Cotepe"]].Trim(); break;
                        case 83: tipoitemsped = a[dicionario["Tipo Item Sped"]].Trim(); break;
                        case 84: codigoprodutosimilar = a[dicionario["Código Produto Similar"]].Trim(); break;
                        case 85: valorultfech = a[dicionario["Valor Últ. Fech."]].Trim(); break;
                        case 86: customediosimulado = a[dicionario["Custo Médio Simulado"]].Trim(); break;
                        case 87: customedio = a[dicionario["Custo Médio"]].Trim(); break;
                        case 88: reservado_11 = a[dicionario["RESERVADO_11"]].Trim(); break;
                        case 89: codigodetributacaoam = a[dicionario["Código de Tributação AM"]].Trim(); break;
                        case 90: grupodefamilia = a[dicionario["Grupo de Família"]].Trim(); break;
                        case 91: descricaogrupofamilia = a[dicionario["Descrição Grupo Família"]].Trim(); break;
                        case 92: descricaocompleta2 = a[dicionario["Descrição Completa (   )"]].Trim(); break;
                        case 93: descricaos = a[dicionario["Descrição (s/    )"]].Trim(); break;
                        case 94: cest = a[dicionario["CEST"]].Trim(); break;
                        case 95: conta = a[dicionario["Conta"]].Trim(); break;
                        case 96: dgconta = a[dicionario["Dg Conta"]].Trim(); break;
                        case 97: contacons = a[dicionario["Conta Cons"]].Trim(); break;
                        case 98: dgcontacons = a[dicionario["Dg Conta Cons"]].Trim(); break;
                        case 99: centrocusto = a[dicionario["Centro Custo"]].Trim(); break;
                        case 100: dgcentrocusto = a[dicionario["Dg Centro Custo"]].Trim(); break;
                        case 101: precodereposicao = a[dicionario["Preço de Reposição"]].Trim(); break;
                        case 102: reinf = a[dicionario["Reinf"]].Trim(); break;
                        case 103: goodsreceipt = a[dicionario["Goods Receipt"]].Trim(); break;
                        case 104: descricaodogrupo = a[dicionario["Descrição do Grupo"]].Trim(); break;
                        case 105: codigodetributacao = a[dicionario["Código de Tributação"]].Trim(); break;
                        case 106: codigodetributacaoalternativo = a[dicionario["Código de Tributação Alternativo"]].Trim(); break;
                        case 107: familia = a[dicionario["Família"]].Trim(); break;
                        case 108: formadepedir = a[dicionario["Forma de pedir"]].Trim(); break;
                        case 109: fatorunidadencm = a[dicionario["Fator Unidade NCM"]].Trim(); break;
                        case 110: fatordaunidade = a[dicionario["Fator da unidade"]].Trim(); break;
                        case 111: unidadealternativaexportacao = a[dicionario["Unidade alternativa exportação"]].Trim(); break;
                        case 112: fatorunidadedipiexportacao = a[dicionario["Fator unidade DIPI exportação"]].Trim(); break;
                        case 113: aplicacao = a[dicionario["Aplicação"]].Trim(); break;

                    }
                }
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
                    QuantidadeDisponivel = Convert.ToDouble(quantidadedisponivel.Replace("E-", "")),
                    SaldoFisico = Convert.ToDouble(saldofisico.Replace("E-", "")),
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
                    Procedência = procedência,
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
                    EstoqueMáximo = Convert.ToDouble(estoquemáximo),
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
            sr.Close();
            st.Close();
            return lista;
        }

        internal static void DepositoDeTerceiro()
        {
            int colunas = 2;
            Stream st = File.OpenRead(@"C:\Exports\DepositoDeTerceiro.txt");
            StreamReader sr = new StreamReader(st, Encoding.Default);
            string line = "";
            sr.ReadLine();
            List<DepositoDeTerceiro> s2 = new List<DepositoDeTerceiro>();
            while ((line = sr.ReadLine()) != null)
            {
                var dd = line.Split('\t');
                if (dd.Count() != colunas)
                {
                    MessageBox.Show($@"Refazer o Export de: C:\Exports\DepositoDeTerceiro.txt");
                    s2.Clear();
                    break;
                }
                s2.Add(new DepositoDeTerceiro
                {
                    Deposito = dd[0].Trim(),
                    Nome = dd[1].Replace("\"", "").Trim()
                });
            }
            sr.Close();
            st.Close();
            Crud c = new Crud();
            c.TruncateDepositoDeTerceiro();
            c.AdicionaDepositoDeTerceiro(s2);
        }

        internal static void SaldoDeTerceiro()
        {
            int colunas = 46;
            var files = Directory.GetFiles(@"C:\Exports\SaldosDeTerceiros");
            int i = 0;
            File.Delete(@"C:\Exports\SaldosDeTerceiros\Saldo.txt");
            List<SaldoDeTerceiro> ls = new List<SaldoDeTerceiro>();
            foreach (var file in files)
            {
                if (file.Contains("ExportSaldo"))
                {
                    List<string> text = new List<string>(File.ReadAllLines(file, Encoding.Default));
                    if (i == 0)
                    {

                        File.AppendAllLines(@"C:\Exports\SaldosDeTerceiros\Saldo.txt", text, Encoding.Default);
                    }
                    else
                    {
                        text.RemoveAt(0);
                        File.AppendAllLines(@"C:\Exports\SaldosDeTerceiros\Saldo.txt", text, Encoding.Default);
                    }
                    i++;

                    Stream st = File.OpenRead(file);
                    StreamReader sr = new StreamReader(st, Encoding.Default);
                    string line = "";
                    sr.ReadLine();
                    List<SaldoDeTerceiro> s2 = new List<SaldoDeTerceiro>();
                    while ((line = sr.ReadLine()) != null)
                    {
                        var dd = line.Split('\t');
                        if (dd.Count() != colunas)
                        {
                            MessageBox.Show($"Refazer o Export de: {file}");
                            s2.Clear();
                            break;
                        }
                        s2.Add(new SaldoDeTerceiro
                        {
                            Produto = dd[0].Replace("\"","").Trim(),
                            Descricao = dd[2].Replace("\"", "").Trim(),
                            Unid = dd[3].Replace("\"", "").Trim(),
                            Grupo = dd[5].Replace("\"", "").Trim(),
                            Disponivel = Convert.ToDouble(dd[6]),
                            SaldoAtual = Convert.ToDouble(dd[7]),
                            SaldoUltFech = Convert.ToDouble(dd[8]),
                            Entradas = Convert.ToDouble(dd[9]),
                            Saidas = Convert.ToDouble(dd[10]),
                            PedCompras = Convert.ToDouble(dd[11]),
                            PedVendas = Convert.ToDouble(dd[12]),
                            ConsuPrevOs = Convert.ToDouble(dd[13]),
                            ProdPrevOS = Convert.ToDouble(dd[15]),
                            ForaEstoque = Convert.ToDouble(dd[17]),
                            DeTerceiros = Convert.ToDouble(dd[19]),
                            EstqMinimo = Convert.ToDouble(dd[25]),
                            EstqMaximo = Convert.ToDouble(dd[26]),
                            Prateleira = dd[28].Replace("\"", "").Trim(),
                            PrevFabric = Convert.ToDouble(dd[30]),
                            DiassemMovimento = Convert.ToDouble(dd[31]),
                            ESTAB = dd[33].Replace("\"", "").Trim(),
                            DEPOSITO = dd[34].Replace("\"", "").Trim()
                        });
                    }
                    ls.AddRange(s2);
                    sr.Close();
                    st.Close();
                }
            }
            Crud c = new Crud();
            c.TruncateSaldoDeTerceiro();
            c.AdicionaSaldoDeTerceiro(ls);
            //parei aqui. falta criar depositos(export, import, e o relacionamento para ter os nomes dos depsitosna tabela saldodeterceiro), 
            //entity framework
        }

        internal static List<StringBuilder> ItensDeEstoque()
        {

            //try
            //{
            int colunas = 114;
            StringBuilder sb = new StringBuilder();
            List<StringBuilder> lsb = new List<StringBuilder>();


            Stream st = File.Open(@"C:\Exports\ItensDeEstoque.txt", FileMode.Open);
            StreamReader sr = new StreamReader(st, Encoding.Default);
            string linha;

            linha = sr.ReadLine();

            Dictionary<string, int> dicionario = ColunarPadraoItensDeEstoque(linha);
            var d = dicionario.OrderBy(p => p.Value);
            var dic = new Dictionary<string, int>();

            foreach (var i in d)
            {
                dic.Add(i.Key, i.Value);
            }

            int id = 1;

            while ((linha = sr.ReadLine()) != null)
            {

                string l = linha.Replace("\"", "");
                string[] a, b = new string[colunas];
            volta:
                b = linha.Replace("\"", "").Replace("'", "").Split('\t');
                //se erro na linha
                if (b.Count() != colunas)
                {
                    linha = linha + sr.ReadLine();
                    goto volta;
                }
                a = b;
                for (int i = 0; i < a.Length; i++)
                {
                    switch (i)
                    {
                        case 0: sb.Append("('" + a[dicionario["Código"]].Trim() + "', "); break;
                        case 1:
                            Decimal q = Math.Round(Convert.ToDecimal(a[dicionario["Preco Compra"]].Trim().Replace("E-", "")), 3);
                            if (q > 0)
                            {
                                sb.Append("'" + q.ToString().Replace(",", ".") + "', "); break;
                            }
                            else
                                sb.Append("'0', "); break;
                        case 2: sb.Append("'" + a[dicionario["Tradução"]].Trim() + "', "); break;
                        case 3: sb.Append("'" + a[dicionario["Unidade"]].Trim() + "', "); break;
                        case 4: sb.Append("'" + a[dicionario["Grupo"]].Trim() + "', "); break;
                        case 5: sb.Append("'" + a[dicionario["Lotes"]].Trim() + "', "); break;
                        case 6: sb.Append("'" + a[dicionario["NS"]].Trim() + "', "); break;
                        case 7: sb.Append("'" + a[dicionario["Descrição"]].Trim() + "', "); break;
                        case 8: sb.Append("'" + a[dicionario["Quantidade Disponível"]].Trim() + "', "); break;
                        case 9:
                            Decimal m = Math.Round(Convert.ToDecimal(a[dicionario["Saldo Físico"]].Trim().Replace("E-", "")), 3);
                            if (m > 0)
                            {
                                sb.Append("'" + m.ToString().Replace(",", ".") + "', "); break;
                            }
                            else
                                sb.Append("'0', "); break;
                        case 10: sb.Append("'" + a[dicionario["Quantidade por Unidade"]].Trim() + "', "); break;
                        case 11: sb.Append("'" + a[dicionario["Cubagem(m³)"]].Trim() + "', "); break;
                        case 12: sb.Append("'" + a[dicionario["Peso Bruto"]].Trim() + "', "); break;
                        case 13: sb.Append("'" + a[dicionario["Peso Líquido"]].Trim() + "', "); break;
                        case 14: sb.Append("'" + a[dicionario["Data da Compra"]].Trim() + "', "); break;
                        case 15: sb.Append("'" + a[dicionario["Prateleira"]].Trim() + "', "); break;
                        case 16: sb.Append("'" + a[dicionario["Status"]].Trim() + "', "); break;
                        case 17: sb.Append("'" + a[dicionario["Item Cadastrado Em"]].Trim() + "', "); break;
                        case 18: sb.Append("'" + a[dicionario["Posição Fiscal"]].Trim() + "', "); break;
                        case 19: sb.Append("'" + a[dicionario["Compl Posição Fiscal"]].Trim() + "', "); break;
                        case 20: sb.Append("'" + a[dicionario["Unid. Alter. DIPI"]].Trim() + "', "); break;
                        case 21: sb.Append("'" + a[dicionario["Fator Unid. DIPI"]].Trim() + "', "); break;
                        case 22: sb.Append("'" + a[dicionario["Procedência"]].Trim() + "', "); break;
                        case 23: sb.Append("'" + a[dicionario["Un. Alter. DIPI"]].Trim() + "', "); break;
                        case 24: sb.Append("'" + a[dicionario["EX da TIPI"]].Trim() + "', "); break;
                        case 25: sb.Append("'" + a[dicionario["Cód. do Fabricante do Produto"]].Trim() + "', "); break;
                        case 26: sb.Append("'" + a[dicionario["Exp Palm"]].Trim() + "', "); break;
                        case 27:
                            Decimal y = Math.Round(Convert.ToDecimal(a[dicionario["Preço Venda"]].Trim().Replace("E-", "")), 3);
                            if (y > 0)
                            {
                                sb.Append("'" + y.ToString().Replace(",", ".") + "', "); break;
                            }
                            else
                                sb.Append("'0', "); break;
                        case 28: sb.Append("'" + a[dicionario["Código1"]].Trim() + "', "); break;
                        case 29: sb.Append("'" + a[dicionario["DESCR_1"]].Trim() + "', "); break;
                        case 30: sb.Append("'" + a[dicionario["DESCR_2"]].Trim() + "', "); break;
                        case 31: sb.Append("'" + a[dicionario["Descrição Completa"]].Trim() + "', "); break;
                        case 32: sb.Append("'" + a[dicionario["Código Externo"]].Trim() + "', "); break;
                        case 33: sb.Append("'" + a[dicionario["ESTAB"]].Trim() + "', "); break;
                        case 34: sb.Append("'" + a[dicionario["DEPOSITO"]].Trim() + "', "); break;
                        case 35: sb.Append("'" + a[dicionario["Qtd Últ. Fech."]].Trim() + "', "); break;
                        case 36: sb.Append("'" + a[dicionario["ENTRADAS"]].Trim() + "', "); break;
                        case 37: sb.Append("'" + a[dicionario["SAIDAS"]].Trim() + "', "); break;
                        case 38: sb.Append("'" + a[dicionario["OS_PREVIST"]].Trim() + "', "); break;
                        case 39: sb.Append("'" + a[dicionario["Fora de Estoque"]].Trim() + "', "); break;
                        case 40: sb.Append("'" + a[dicionario["Vendas Consig"]].Trim() + "', "); break;
                        case 41: sb.Append("'" + a[dicionario["Compras Consig"]].Trim() + "', "); break;
                        case 42: sb.Append("'" + a[dicionario["Res. Vendas"]].Trim() + "', "); break;
                        case 43: sb.Append("'" + a[dicionario["Ped Venda"]].Trim() + "', "); break;
                        case 44: sb.Append("'" + a[dicionario["Preço"]].Trim() + "', "); break;
                        case 45: sb.Append("'" + a[dicionario["QT_ALT_OBR"]].Trim() + "', "); break;
                        case 46: sb.Append("'" + a[dicionario["Emp. Req. Compra"]].Trim() + "', "); break;
                        case 47: sb.Append("'" + a[dicionario["Unidade Alternativa"]].Trim() + "', "); break;
                        case 48: sb.Append("'" + a[dicionario["Fator de Conversão"]].Trim() + "', "); break;
                        case 49: sb.Append("'" + a[dicionario["Cód. Família"]].Trim() + "', "); break;
                        case 50: sb.Append("'" + a[dicionario["Descrição da Família"]].Trim() + "', "); break;
                        case 51: sb.Append("'" + a[dicionario["Cod. EAN 13"]].Trim() + "', "); break;
                        case 52: sb.Append("'" + a[dicionario["Estoque Mínimo"]].Trim() + "', "); break;
                        case 53: sb.Append("'" + a[dicionario["Estoque Máximo"]].Trim() + "', "); break;
                        case 54: sb.Append("'" + a[dicionario["% de Tolerância"]].Trim() + "', "); break;
                        case 55: sb.Append("'" + a[dicionario["Leadtime"]].Trim() + "', "); break;
                        case 56: sb.Append("'" + a[dicionario["Código do Recolhimento"]].Trim() + "', "); break;
                        case 57: sb.Append("'" + a[dicionario["Alíquota de IPI"]].Trim() + "', "); break;
                        case 58: sb.Append("'" + a[dicionario["Livre 1"]].Trim() + "', "); break;
                        case 59: sb.Append("'" + a[dicionario["Livre 2"]].Trim() + "', "); break;
                        case 60: sb.Append("'" + a[dicionario["Livre 3"]].Trim() + "', "); break;
                        case 61: sb.Append("'" + a[dicionario["Livre 4"]].Trim() + "', "); break;
                        case 62: sb.Append("'" + a[dicionario["Livre 5"]].Trim() + "', "); break;
                        case 63: sb.Append("'" + a[dicionario["Livre 6"]].Trim() + "', "); break;
                        case 64: sb.Append("'" + a[dicionario["Livre 7"]].Trim() + "', "); break;
                        case 65: sb.Append("'" + a[dicionario["Livre 8"]].Trim() + "', "); break;
                        case 66: sb.Append("'" + a[dicionario["Livre 9"]].Trim() + "', "); break;
                        case 67: sb.Append("'" + a[dicionario["Livre 10"]].Trim() + "', "); break;
                        case 68: sb.Append("'" + a[dicionario["Livre 11"]].Trim() + "', "); break;
                        case 69: sb.Append("'" + a[dicionario["Livre 12"]].Trim() + "', "); break;
                        case 70: sb.Append("'" + a[dicionario["Livre 13"]].Trim() + "', "); break;
                        case 71: sb.Append("'" + a[dicionario["Livre 14"]].Trim() + "', "); break;
                        case 72: sb.Append("'" + a[dicionario["Livre 15"]].Trim() + "', "); break;
                        case 73: sb.Append("'" + a[dicionario["Livre 16"]].Trim() + "', "); break;
                        //case 74: sb.Append("'" + a[dicionario["Livre 17"]].Trim() + "', "); break;

                        case 74:
                            Decimal h;
                            if (a[dicionario["Livre 17"]].Trim() == "")
                            {
                                h = 0;
                            }
                            else if (a[dicionario["Livre 17"]].Trim().Contains("E"))
                            {
                                h = Decimal.Parse(a[dicionario["Livre 17"]].ToString().Trim(), System.Globalization.NumberStyles.AllowExponent);
                            }
                            else
                            {
                                h = Convert.ToDecimal(a[dicionario["Livre 17"]].ToString().Trim());
                            }
                            sb.Append($"'{h.ToString().Replace(",", ".")}', "); break;
                        case 75: sb.Append("'" + a[dicionario["Livre 18"]].Trim() + "', "); break;
                        case 76: sb.Append("'" + a[dicionario["Livre 19"]].Trim() + "', "); break;
                        case 77: sb.Append("'" + a[dicionario["Livre 20"]].Trim() + "', "); break;
                        case 78: sb.Append("'" + a[dicionario["Código de Serviço"]].Trim() + "', "); break;
                        case 79: sb.Append("'" + a[dicionario["Conta Contabil"]].Trim() + "', "); break;
                        case 80: sb.Append("'" + a[dicionario["Conta Consumo"]].Trim() + "', "); break;
                        case 81: sb.Append("'" + a[dicionario["Centro de Custo"]].Trim() + "', "); break;
                        case 82: sb.Append("'" + a[dicionario["Gênero Cotepe"]].Trim() + "', "); break;
                        case 83: sb.Append("'" + a[dicionario["Tipo Item Sped"]].Trim() + "', "); break;
                        case 84: sb.Append("'" + a[dicionario["Código Produto Similar"]].Trim() + "', "); break;
                        case 85: sb.Append("'" + a[dicionario["Valor Últ. Fech."]].Trim() + "', "); break;
                        case 86: sb.Append("'" + a[dicionario["Custo Médio Simulado"]].Trim() + "', "); break;
                        case 87:
                            Decimal W = Math.Round(Convert.ToDecimal(a[dicionario["Custo Médio"]].Trim().Replace("E-", "")), 3);
                            if (W > 0)
                            {
                                sb.Append("'" + W.ToString().Replace(",", ".") + "', "); break;
                            }
                            else
                                sb.Append("'0', "); break;

                        case 88: sb.Append("'" + a[dicionario["RESERVADO_11"]].Trim() + "', "); break;
                        case 89: sb.Append("'" + a[dicionario["Código de Tributação AM"]].Trim() + "', "); break;
                        case 90: sb.Append("'" + a[dicionario["Grupo de Família"]].Trim() + "', "); break;
                        case 91: sb.Append("'" + a[dicionario["Descrição Grupo Família"]].Trim() + "', "); break;
                        case 92: sb.Append("'" + a[dicionario["Descrição Completa (   )"]].Trim() + "', "); break;
                        case 93: sb.Append("'" + a[dicionario["Descrição (s/    )"]].Trim() + "', "); break;
                        case 94: sb.Append("'" + a[dicionario["CEST"]].Trim() + "', "); break;
                        case 95: sb.Append("'" + a[dicionario["Conta"]].Trim() + "', "); break;
                        case 96: sb.Append("'" + a[dicionario["Dg Conta"]].Trim() + "', "); break;
                        case 97: sb.Append("'" + a[dicionario["Conta Cons"]].Trim() + "', "); break;
                        case 98: sb.Append("'" + a[dicionario["Dg Conta Cons"]].Trim() + "', "); break;
                        case 99: sb.Append("'" + a[dicionario["Centro Custo"]].Trim() + "', "); break;
                        case 100: sb.Append("'" + a[dicionario["Dg Centro Custo"]].Trim() + "', "); break;
                        case 101: sb.Append("'" + a[dicionario["Preço de Reposição"]].Trim() + "', "); break;
                        case 102: sb.Append("'" + a[dicionario["Reinf"]].Trim() + "', "); break;
                        case 103: sb.Append("'" + a[dicionario["Goods Receipt"]].Trim() + "', "); break;
                        case 104: sb.Append("'" + a[dicionario["Descrição do Grupo"]].Trim() + "', "); break;
                        case 105: sb.Append("'" + a[dicionario["Código de Tributação"]].Trim() + "', "); break;
                        case 106: sb.Append("'" + a[dicionario["Código de Tributação Alternativo"]].Trim() + "', "); break;
                        case 107: sb.Append("'" + a[dicionario["Família"]].Trim() + "', "); break;
                        case 108: sb.Append("'" + a[dicionario["Forma de pedir"]].Trim() + "', "); break;
                        case 109: sb.Append("'" + a[dicionario["Fator Unidade NCM"]].Trim() + "', "); break;
                        case 110: sb.Append("'" + a[dicionario["Fator da unidade"]].Trim() + "', "); break;
                        case 111: sb.Append("'" + a[dicionario["Unidade alternativa exportação"]].Trim() + "', "); break;
                        case 112: sb.Append("'" + a[dicionario["Fator unidade DIPI exportação"]].Trim() + "', "); break;
                        case 113: sb.Append("'" + a[dicionario["Aplicação"]].Trim() + "'), "); break;
                    }

                }

                if (id == 2000 | sr.EndOfStream == true)
                {
                    id = 1;
                    sb.Remove(sb.Length - 2, 2);
                    lsb.Add(sb);
                    sb = new StringBuilder();
                }

                id++;
            }

            sr.Close();
            st.Close();
            return lsb;
            //}
            //catch (Exception e)
            //{
            //    MessageBox.Show(e.Message);
            //    //ControllerERP_Pronto.ItensDeEstoque();
            //    //Import.ItensDeEstoqueImport();
            //    return null;
            //}


        }

        private static Dictionary<string, int> ColunarPadraoItensDeEstoque(string linha)
        {
            var x = linha.Replace("\"", "").Replace("'", "").Split('\t');
            Dictionary<string, int> valor = new Dictionary<string, int>();

            for (int i = 0; i < x.Length; i++)
            {
                switch (x[i])
                {
                    case "Código":
                        if (valor.Keys.Count == 0)
                        {
                            valor.Add("Código", i); break;
                        }
                        else if (valor.Keys.Count == 28)
                            valor.Add("Código1", i); break;

                    case "Preco Compra": valor.Add("Preco Compra", i); break;
                    case "Tradução": valor.Add("Tradução", i); break;
                    case "Unidade": valor.Add("Unidade", i); break;
                    case "Grupo": valor.Add("Grupo", i); break;
                    case "Lotes": valor.Add("Lotes", i); break;
                    case "NS": valor.Add("NS", i); break;
                    case "Descrição": valor.Add("Descrição", i); break;
                    case "Quantidade Disponível": valor.Add("Quantidade Disponível", i); break;
                    case "Saldo Físico": valor.Add("Saldo Físico", i); break;
                    case "Quantidade por Unidade": valor.Add("Quantidade por Unidade", i); break;
                    case "Cubagem(m³)": valor.Add("Cubagem(m³)", i); break;
                    case "Peso Bruto": valor.Add("Peso Bruto", i); break;
                    case "Peso Líquido": valor.Add("Peso Líquido", i); break;
                    case "Data da Compra": valor.Add("Data da Compra", i); break;
                    case "Prateleira": valor.Add("Prateleira", i); break;
                    case "Status": valor.Add("Status", i); break;
                    case "Item Cadastrado Em": valor.Add("Item Cadastrado Em", i); break;
                    case "Posição Fiscal": valor.Add("Posição Fiscal", i); break;
                    case "Compl Posição Fiscal": valor.Add("Compl Posição Fiscal", i); break;
                    case "Unid. Alter. DIPI": valor.Add("Unid. Alter. DIPI", i); break;
                    case "Fator Unid. DIPI": valor.Add("Fator Unid. DIPI", i); break;
                    case "Procedência": valor.Add("Procedência", i); break;
                    case "Un. Alter. DIPI": valor.Add("Un. Alter. DIPI", i); break;
                    case "EX da TIPI": valor.Add("EX da TIPI", i); break;
                    case "Cód. do Fabricante do Produto": valor.Add("Cód. do Fabricante do Produto", i); break;
                    case "Exp Palm": valor.Add("Exp Palm", i); break;
                    case "Preço Venda": valor.Add("Preço Venda", i); break;
                    case "DESCR_1": valor.Add("DESCR_1", i); break;
                    case "DESCR_2": valor.Add("DESCR_2", i); break;
                    case "Descrição Completa": valor.Add("Descrição Completa", i); break;
                    case "Código Externo": valor.Add("Código Externo", i); break;
                    case "ESTAB": valor.Add("ESTAB", i); break;
                    case "DEPOSITO": valor.Add("DEPOSITO", i); break;
                    case "Qtd Últ. Fech.": valor.Add("Qtd Últ. Fech.", i); break;
                    case "ENTRADAS": valor.Add("ENTRADAS", i); break;
                    case "SAIDAS": valor.Add("SAIDAS", i); break;
                    case "OS_PREVIST": valor.Add("OS_PREVIST", i); break;
                    case "Fora de Estoque": valor.Add("Fora de Estoque", i); break;
                    case "Vendas Consig": valor.Add("Vendas Consig", i); break;
                    case "Compras Consig": valor.Add("Compras Consig", i); break;
                    case "Res. Vendas": valor.Add("Res. Vendas", i); break;
                    case "Ped Venda": valor.Add("Ped Venda", i); break;
                    case "Preço": valor.Add("Preço", i); break;
                    case "QT_ALT_OBR": valor.Add("QT_ALT_OBR", i); break;
                    case "Emp. Req. Compra": valor.Add("Emp. Req. Compra", i); break;
                    case "Unidade Alternativa": valor.Add("Unidade Alternativa", i); break;
                    case "Fator de Conversão": valor.Add("Fator de Conversão", i); break;
                    case "Cód. Família": valor.Add("Cód. Família", i); break;
                    case "Descrição da Família": valor.Add("Descrição da Família", i); break;
                    case "Cod. EAN 13": valor.Add("Cod. EAN 13", i); break;
                    case "Estoque Mínimo": valor.Add("Estoque Mínimo", i); break;
                    case "Estoque Máximo": valor.Add("Estoque Máximo", i); break;
                    case "% de Tolerância": valor.Add("% de Tolerância", i); break;
                    case "Leadtime": valor.Add("Leadtime", i); break;
                    case "Código do Recolhimento": valor.Add("Código do Recolhimento", i); break;
                    case "Alíquota de IPI": valor.Add("Alíquota de IPI", i); break;
                    case "Livre 1": valor.Add("Livre 1", i); break;
                    case "Livre 2": valor.Add("Livre 2", i); break;
                    case "Livre 3": valor.Add("Livre 3", i); break;
                    case "Livre 4": valor.Add("Livre 4", i); break;
                    case "Livre 5": valor.Add("Livre 5", i); break;
                    case "Livre 6": valor.Add("Livre 6", i); break;
                    case "Livre 7": valor.Add("Livre 7", i); break;
                    case "Livre 8": valor.Add("Livre 8", i); break;
                    case "Livre 9": valor.Add("Livre 9", i); break;
                    case "Livre 10": valor.Add("Livre 10", i); break;
                    case "Livre 11": valor.Add("Livre 11", i); break;
                    case "Livre 12": valor.Add("Livre 12", i); break;
                    case "Livre 13": valor.Add("Livre 13", i); break;
                    case "Livre 14": valor.Add("Livre 14", i); break;
                    case "Livre 15": valor.Add("Livre 15", i); break;
                    case "Livre 16": valor.Add("Livre 16", i); break;
                    case "Livre 17": valor.Add("Livre 17", i); break;
                    case "Livre 18": valor.Add("Livre 18", i); break;
                    case "Livre 19": valor.Add("Livre 19", i); break;
                    case "Livre 20": valor.Add("Livre 20", i); break;
                    case "Código de Serviço": valor.Add("Código de Serviço", i); break;
                    case "Conta Contabil": valor.Add("Conta Contabil", i); break;
                    case "Conta Consumo": valor.Add("Conta Consumo", i); break;
                    case "Centro de Custo": valor.Add("Centro de Custo", i); break;
                    case "Gênero Cotepe": valor.Add("Gênero Cotepe", i); break;
                    case "Tipo Item Sped": valor.Add("Tipo Item Sped", i); break;
                    case "Código Produto Similar": valor.Add("Código Produto Similar", i); break;
                    case "Valor Últ. Fech.": valor.Add("Valor Últ. Fech.", i); break;
                    case "Custo Médio Simulado": valor.Add("Custo Médio Simulado", i); break;
                    case "Custo Médio": valor.Add("Custo Médio", i); break;
                    case "RESERVADO_11": valor.Add("RESERVADO_11", i); break;
                    case "Código de Tributação AM": valor.Add("Código de Tributação AM", i); break;
                    case "Grupo de Família": valor.Add("Grupo de Família", i); break;
                    case "Descrição Grupo Família": valor.Add("Descrição Grupo Família", i); break;
                    case "Descrição Completa (   )": valor.Add("Descrição Completa (   )", i); break;
                    case "Descrição (s/    )": valor.Add("Descrição (s/    )", i); break;
                    case "CEST": valor.Add("CEST", i); break;
                    case "Conta": valor.Add("Conta", i); break;
                    case "Dg Conta": valor.Add("Dg Conta", i); break;
                    case "Conta Cons": valor.Add("Conta Cons", i); break;
                    case "Dg Conta Cons": valor.Add("Dg Conta Cons", i); break;
                    case "Centro Custo": valor.Add("Centro Custo", i); break;
                    case "Dg Centro Custo": valor.Add("Dg Centro Custo", i); break;
                    case "Preço de Reposição": valor.Add("Preço de Reposição", i); break;
                    case "Reinf": valor.Add("Reinf", i); break;
                    case "Goods Receipt": valor.Add("Goods Receipt", i); break;
                    case "Descrição do Grupo": valor.Add("Descrição do Grupo", i); break;
                    case "Código de Tributação": valor.Add("Código de Tributação", i); break;
                    case "Código de Tributação Alternativo": valor.Add("Código de Tributação Alternativo", i); break;
                    case "Família": valor.Add("Família", i); break;
                    case "Forma de pedir": valor.Add("Forma de pedir", i); break;
                    case "Fator Unidade NCM": valor.Add("Fator Unidade NCM", i); break;
                    case "Fator da unidade": valor.Add("Fator da unidade", i); break;
                    case "Unidade alternativa exportação": valor.Add("Unidade alternativa exportação", i); break;
                    case "Fator unidade DIPI exportação": valor.Add("Fator unidade DIPI exportação", i); break;
                    case "Aplicação": valor.Add("Aplicação", i); break;
                }
            }
            return valor;
        }

        internal static object DeTerceiro()
        {
            int colunas = 70;
            StringBuilder sb = new StringBuilder();


            Stream st = File.Open(@"C:\Exports\DeTerceiro.txt", FileMode.Open);
            StreamReader sr = new StreamReader(st, Encoding.Default);
            string linha;

            linha = sr.ReadLine();

            var dicionario = ColunarPadraoDeTerceiro(linha);
            var d = dicionario.OrderBy(p => p.Value);
            var dic = new Dictionary<string, int>();

            foreach (var i in d)
            {
                dic.Add(i.Key, i.Value);
            }
            var g = Crud.Select("SELECT * FROM foradeestoques order by id desc limit 1");
            var k = 0;
            if (g.Tables[0].Rows.Count != 0)
            {
                k = Convert.ToInt32(g.Tables[0].Rows[0].ItemArray[0]);
            }

            while ((linha = sr.ReadLine()) != null)
            {

                string[] a, b = new string[colunas];
            volta:
                b = linha.Replace("\"", "").Replace("'", "").Split('\t');
                //se erro na linha
                if (b.Count() != colunas)
                {
                    linha = linha + sr.ReadLine();
                    goto volta;
                }
                a = b;
                for (int i = 0; i < a.Length; i++)
                {
                    switch (i)
                    {
                        case 0: sb.Append($"({++k}, '" + a[dic["Op"]].Trim() + "', "); break;
                        case 1: sb.Append("'" + a[dic["Doc.En"]].Trim() + "', "); break;
                        case 2: sb.Append("'" + a[dic["Serie1"]].Trim() + "', "); break;
                        case 3: sb.Append("'" + a[dic["Produto"]].Trim() + "', "); break;
                        case 4: sb.Append("'" + a[dic["Tradução"]].Trim() + "', "); break;
                        case 5: sb.Append("'" + a[dic["TM"]].Trim() + "', "); break;
                        case 6: sb.Append("'" + Convert.ToDateTime(a[dic["Data"]].Trim()).ToString("yyyy-MM-dd") + "', "); break;
                        case 7: sb.Append("'" + a[dic["Cliente"]].Trim() + "', "); break;
                        case 8: sb.Append("'" + a[dic["Doc. Fiscal"]].Trim() + "', "); break;
                        case 9: sb.Append("'" + a[dic["Serie2"]].Trim() + "', "); break;
                        case 10: sb.Append("'" + a[dic["Cont1"]].Trim() + "', "); break;
                        case 11: sb.Append("'" + a[dic["Lt"]].Trim() + "', "); break;
                        case 12: sb.Append("'" + a[dic["Qtde Nf"]].Trim() + "', "); break;
                        case 13: sb.Append("'" + a[dic["Valor Nf"]].Trim() + "', "); break;
                        case 14: sb.Append("'" + a[dic["Valor Custo"]].Trim() + "', "); break;
                        case 15: sb.Append("'" + a[dic["Saldo Qtde"]].Trim() + "', "); break;
                        case 16: sb.Append("'" + a[dic["Saldo Custo"]].Trim() + "', "); break;
                        case 17: sb.Append("'" + a[dic["Observação"]].Trim() + "', "); break;
                        case 18: sb.Append("'" + a[dic["Nome Fantasia"]].Trim() + "', "); break;
                        case 19: sb.Append("'" + a[dic["Descrição"]].Trim() + "', "); break;
                        case 20: sb.Append("'" + a[dic["Valor Unitário"]].Trim() + "', "); break;
                        case 21: sb.Append("'" + a[dic["Texto Específico Fat. Balcão"]].Trim() + "', "); break;
                        case 22: sb.Append("'" + a[dic["Obs NF Balcão"]].Trim() + "', "); break;
                        case 23: sb.Append("'" + a[dic["TIPO_MOVTO_NF"]].Trim() + "', "); break;
                        case 24: sb.Append("'" + a[dic["NRO_FORNEC"]].Trim() + "', "); break;
                        case 25: sb.Append("'" + a[dic["SEQ_FORNEC"]].Trim() + "', "); break;
                        case 26: sb.Append("'" + a[dic["QT_ENVIADA"]].Trim() + "', "); break;
                        case 27: sb.Append("'" + a[dic["VR_ENV_NF"]].Trim() + "', "); break;
                        case 28: sb.Append("'" + a[dic["VR_ENVIADO"]].Trim() + "', "); break;
                        case 29: sb.Append("'" + a[dic["QT_DEVOLV"]].Trim() + "', "); break;
                        case 30: sb.Append("'" + a[dic["VR_DEV_NF"]].Trim() + "', "); break;
                        case 31: sb.Append("'" + a[dic["VR_DEVOLV"]].Trim() + "', "); break;
                        case 32: sb.Append("'" + a[dic["ESTAB"]].Trim() + "', "); break;
                        case 33: sb.Append("'" + a[dic["Cont2"]].Trim() + "', "); break;
                        case 34: sb.Append("'" + a[dic["DEPOSITO"]].Trim() + "', "); break;
                        case 35: sb.Append("'" + a[dic["TIPO_FE"]].Trim() + "', "); break;
                        case 36: sb.Append("'" + a[dic["SEQ"]].Trim() + "', "); break;
                        case 37: sb.Append("'" + a[dic["EMP_FIL"]].Trim() + "', "); break;
                        case 38: sb.Append("'" + a[dic["DT_VENCTO"]].Trim() + "', "); break;
                        case 39: sb.Append("'" + a[dic["DT_DOC_F"]].Trim() + "', "); break;
                        case 40: sb.Append("'" + a[dic["QT_FECH"]].Trim() + "', "); break;
                        case 41: sb.Append("'" + a[dic["QT_FECH_AN"]].Trim() + "', "); break;
                        case 42: sb.Append("'" + a[dic["VR_FECH"]].Trim() + "', "); break;
                        case 43: sb.Append("'" + a[dic["VR_FECH_AN"]].Trim() + "', "); break;
                        case 44: sb.Append("'" + a[dic["VR_FECH_NF"]].Trim() + "', "); break;
                        case 45: sb.Append("'" + a[dic["VR_FEAN_NF"]].Trim() + "', "); break;
                        case 46: sb.Append("'" + a[dic["VRI_ENVIAD"]].Trim() + "', "); break;
                        case 47: sb.Append("'" + a[dic["VRI_DEVOLV"]].Trim() + "', "); break;
                        case 48: sb.Append("'" + a[dic["VRI_FECH"]].Trim() + "', "); break;
                        case 49: sb.Append("'" + a[dic["VRI_FECH_AN"]].Trim() + "', "); break;
                        case 50: sb.Append("'" + a[dic["VRU_ENVIAD"]].Trim() + "', "); break;
                        case 51: sb.Append("'" + a[dic["VRU_DEVOLV"]].Trim() + "', "); break;
                        case 52: sb.Append("'" + a[dic["VRU_FECH"]].Trim() + "', "); break;
                        case 53: sb.Append("'" + a[dic["VRU_FECH_AN"]].Trim() + "', "); break;
                        case 54: sb.Append("'" + a[dic["REF_UNID"]].Trim() + "', "); break;
                        case 55: sb.Append("'" + a[dic["REF_LOCAL"]].Trim() + "', "); break;
                        case 56: sb.Append("'" + a[dic["C_CUSTO"]].Trim() + "', "); break;
                        case 57: sb.Append("'" + a[dic["DG_CCUSTO"]].Trim() + "', "); break;
                        case 58: sb.Append("'" + a[dic["C_CUSTO2"]].Trim() + "', "); break;
                        case 59: sb.Append("'" + a[dic["DG_CCUSTO2"]].Trim() + "', "); break;
                        case 60: sb.Append("'" + a[dic["CONTA"]].Trim() + "', "); break;
                        case 61: sb.Append("'" + a[dic["DG_CONTA"]].Trim() + "', "); break;
                        case 62: sb.Append("'" + a[dic["CONTA2"]].Trim() + "', "); break;
                        case 63: sb.Append("'" + a[dic["DG_CONTA2"]].Trim() + "', "); break;
                        case 64: sb.Append("'" + a[dic["TIPO_CONTAB"]].Trim() + "', "); break;
                        case 65: sb.Append("'" + a[dic["DATA_ALTER"]].Trim() + "', "); break;
                        case 66: sb.Append("'" + a[dic["TIME_STAMP"]].Trim() + "', "); break;
                        case 67: sb.Append("'" + a[dic["HORA_ALTER"]].Trim() + "', "); break;
                        case 68: sb.Append("'" + a[dic["ORIGEM_MOVTO"]].Trim() + "', "); break;
                        case 69: sb.Append("'" + a[dic["ORDEM_ENVIO"]].Trim() + "'), "); break;
                    }
                }
            }
            sb.Remove(sb.Length - 2, 2);



            sr.Close();
            st.Close();

            return sb;
        }

        private static Dictionary<string, int> ColunarPadraoDeTerceiro(string linha)
        {
            var x = linha.Replace("\"", "").Replace("'", "").Split('\t');
            Dictionary<string, int> valor = new Dictionary<string, int>();

            for (int i = 0; i < x.Length; i++)
            {


                switch (x[i])
                {
                    case "Op": valor.Add("Op", i); break;
                    case "Doc.En": valor.Add("Doc.En", i); break;
                    case "Serie":
                        if (valor.Keys.Count == 2)
                        {
                            valor.Add("Serie1", i); break;
                        }
                        else if (valor.Keys.Count == 9)
                            valor.Add("Serie2", i); break;

                    case "Produto": valor.Add("Produto", i); break;
                    case "Tradução": valor.Add("Tradução", i); break;
                    case "TM": valor.Add("TM", i); break;
                    case "Data": valor.Add("Data", i); break;
                    case "Cliente": valor.Add("Cliente", i); break;
                    case "Doc. Fiscal": valor.Add("Doc. Fiscal", i); break;
                    case "Cont":
                        if (valor.Keys.Count == 10)
                        {
                            valor.Add("Cont1", i); break;
                        }
                        else if (valor.Keys.Count == 33)
                            valor.Add("Cont2", i); break;
                    case "Lt": valor.Add("Lt", i); break;
                    case "Qtde Nf": valor.Add("Qtde Nf", i); break;
                    case "Valor Nf": valor.Add("Valor Nf", i); break;
                    case "Valor Custo": valor.Add("Valor Custo", i); break;
                    case "Saldo Qtde": valor.Add("Saldo Qtde", i); break;
                    case "Saldo Custo": valor.Add("Saldo Custo", i); break;
                    case "Observação": valor.Add("Observação", i); break;
                    case "Nome Fantasia": valor.Add("Nome Fantasia", i); break;
                    case "Descrição": valor.Add("Descrição", i); break;
                    case "Valor Unitário": valor.Add("Valor Unitário", i); break;
                    case "Texto Específico Fat. Balcão": valor.Add("Texto Específico Fat. Balcão", i); break;
                    case "Obs NF Balcão": valor.Add("Obs NF Balcão", i); break;
                    case "TIPO_MOVTO_NF": valor.Add("TIPO_MOVTO_NF", i); break;
                    case "NRO_FORNEC": valor.Add("NRO_FORNEC", i); break;
                    case "SEQ_FORNEC": valor.Add("SEQ_FORNEC", i); break;
                    case "QT_ENVIADA": valor.Add("QT_ENVIADA", i); break;
                    case "VR_ENV_NF": valor.Add("VR_ENV_NF", i); break;
                    case "VR_ENVIADO": valor.Add("VR_ENVIADO", i); break;
                    case "QT_DEVOLV": valor.Add("QT_DEVOLV", i); break;
                    case "VR_DEV_NF": valor.Add("VR_DEV_NF", i); break;
                    case "VR_DEVOLV": valor.Add("VR_DEVOLV", i); break;
                    case "ESTAB": valor.Add("ESTAB", i); break;
                    case "DEPOSITO": valor.Add("DEPOSITO", i); break;
                    case "TIPO_FE": valor.Add("TIPO_FE", i); break;
                    case "SEQ": valor.Add("SEQ", i); break;
                    case "EMP_FIL": valor.Add("EMP_FIL", i); break;
                    case "DT_VENCTO": valor.Add("DT_VENCTO", i); break;
                    case "DT_DOC_F": valor.Add("DT_DOC_F", i); break;
                    case "QT_FECH": valor.Add("QT_FECH", i); break;
                    case "QT_FECH_AN": valor.Add("QT_FECH_AN", i); break;
                    case "VR_FECH": valor.Add("VR_FECH", i); break;
                    case "VR_FECH_AN": valor.Add("VR_FECH_AN", i); break;
                    case "VR_FECH_NF": valor.Add("VR_FECH_NF", i); break;
                    case "VR_FEAN_NF": valor.Add("VR_FEAN_NF", i); break;
                    case "VRI_ENVIAD": valor.Add("VRI_ENVIAD", i); break;
                    case "VRI_DEVOLV": valor.Add("VRI_DEVOLV", i); break;
                    case "VRI_FECH": valor.Add("VRI_FECH", i); break;
                    case "VRI_FECH_AN": valor.Add("VRI_FECH_AN", i); break;
                    case "VRU_ENVIAD": valor.Add("VRU_ENVIAD", i); break;
                    case "VRU_DEVOLV": valor.Add("VRU_DEVOLV", i); break;
                    case "VRU_FECH": valor.Add("VRU_FECH", i); break;
                    case "VRU_FECH_AN": valor.Add("VRU_FECH_AN", i); break;
                    case "REF_UNID": valor.Add("REF_UNID", i); break;
                    case "REF_LOCAL": valor.Add("REF_LOCAL", i); break;
                    case "C_CUSTO": valor.Add("C_CUSTO", i); break;
                    case "DG_CCUSTO": valor.Add("DG_CCUSTO", i); break;
                    case "C_CUSTO2": valor.Add("C_CUSTO2", i); break;
                    case "DG_CCUSTO2": valor.Add("DG_CCUSTO2", i); break;
                    case "CONTA": valor.Add("CONTA", i); break;
                    case "DG_CONTA": valor.Add("DG_CONTA", i); break;
                    case "CONTA2": valor.Add("CONTA2", i); break;
                    case "DG_CONTA2": valor.Add("DG_CONTA2", i); break;
                    case "TIPO_CONTAB": valor.Add("TIPO_CONTAB", i); break;
                    case "DATA_ALTER": valor.Add("DATA_ALTER", i); break;
                    case "TIME_STAMP": valor.Add("TIME_STAMP", i); break;
                    case "HORA_ALTER": valor.Add("HORA_ALTER", i); break;
                    case "ORIGEM_MOVTO": valor.Add("ORIGEM_MOVTO", i); break;
                    case "ORDEM_ENVIO": valor.Add("ORDEM_ENVIO", i); break;

                }
            }
            return valor;
        }

        internal static StringBuilder ForaDeEstoque()
        {
            int colunas = 70;
            StringBuilder sb = new StringBuilder();


            Stream st = File.Open(@"C:\Exports\ForaDeEstoque.txt", FileMode.Open);
            StreamReader sr = new StreamReader(st, Encoding.Default);
            string linha;

            linha = sr.ReadLine();

            var dicionario = ColunarPadraoForaDeEstoque(linha);
            var d = dicionario.OrderBy(p => p.Value);
            var dic = new Dictionary<string, int>();

            foreach (var i in d)
            {
                dic.Add(i.Key, i.Value);
            }
            var g = Crud.Select("SELECT * FROM foradeestoques order by id desc limit 1");
            var k = 0;
            if (g.Tables[0].Rows.Count != 0)
            {
                k = Convert.ToInt32(g.Tables[0].Rows[0].ItemArray[0]);
            }

            while ((linha = sr.ReadLine()) != null)
            {

                string[] a, b = new string[colunas];
            volta:
                b = linha.Replace("\"", "").Replace("'", "").Split('\t');
                //se erro na linha
                if (b.Count() != colunas)
                {
                    linha = linha + sr.ReadLine();
                    goto volta;
                }
                a = b;
                for (int i = 0; i < a.Length; i++)
                {
                    switch (i)
                    {
                        case 0: sb.Append($"({++k}, '" + a[dic["Op"]].Trim() + "', "); break;
                        case 1: sb.Append("'" + a[dic["Doc.En"]].Trim() + "', "); break;
                        case 2: sb.Append("'" + a[dic["Serie1"]].Trim() + "', "); break;
                        case 3: sb.Append("'" + a[dic["Produto"]].Trim() + "', "); break;
                        case 4: sb.Append("'" + a[dic["Tradução"]].Trim() + "', "); break;
                        case 5: sb.Append("'" + a[dic["TM"]].Trim() + "', "); break;
                        case 6: sb.Append("'" + Convert.ToDateTime(a[dic["Data"]].Trim()).ToString("yyyy-MM-dd") + "', "); break;
                        case 7: sb.Append("'" + a[dic["Fornecedor"]].Trim() + "', "); break;
                        case 8: sb.Append("'" + a[dic["Doc. Fiscal"]].Trim() + "', "); break;
                        case 9: sb.Append("'" + a[dic["Serie2"]].Trim() + "', "); break;
                        case 10: sb.Append("'" + a[dic["Cont1"]].Trim() + "', "); break;
                        case 11: sb.Append("'" + a[dic["Lt"]].Trim() + "', "); break;
                        case 12: sb.Append("'" + a[dic["Qtde Nf"]].Trim() + "', "); break;
                        case 13: sb.Append("'" + a[dic["Valor Nf"]].Trim() + "', "); break;
                        case 14: sb.Append("'" + a[dic["Valor Custo"]].Trim() + "', "); break;
                        case 15: sb.Append("'" + a[dic["Saldo Qtde"]].Trim() + "', "); break;
                        case 16: sb.Append("'" + a[dic["Saldo Custo"]].Trim() + "', "); break;
                        case 17: sb.Append("'" + a[dic["Observação"]].Trim() + "', "); break;
                        case 18: sb.Append("'" + a[dic["Nome Fantasia"]].Trim() + "', "); break;
                        case 19: sb.Append("'" + a[dic["Descrição"]].Trim() + "', "); break;
                        case 20: sb.Append("'" + a[dic["Valor Unitário"]].Trim() + "', "); break;
                        case 21: sb.Append("'" + a[dic["Texto Específico Fat. Balcão"]].Trim() + "', "); break;
                        case 22: sb.Append("'" + a[dic["Obs NF Balcão"]].Trim() + "', "); break;
                        case 23: sb.Append("'" + a[dic["TIPO_MOVTO_NF"]].Trim() + "', "); break;
                        case 24: sb.Append("'" + a[dic["NRO_FORNEC"]].Trim() + "', "); break;
                        case 25: sb.Append("'" + a[dic["SEQ_FORNEC"]].Trim() + "', "); break;
                        case 26: sb.Append("'" + a[dic["QT_ENVIADA"]].Trim() + "', "); break;
                        case 27: sb.Append("'" + a[dic["VR_ENV_NF"]].Trim() + "', "); break;
                        case 28: sb.Append("'" + a[dic["VR_ENVIADO"]].Trim() + "', "); break;
                        case 29: sb.Append("'" + a[dic["QT_DEVOLV"]].Trim() + "', "); break;
                        case 30: sb.Append("'" + a[dic["VR_DEV_NF"]].Trim() + "', "); break;
                        case 31: sb.Append("'" + a[dic["VR_DEVOLV"]].Trim() + "', "); break;
                        case 32: sb.Append("'" + a[dic["ESTAB"]].Trim() + "', "); break;
                        case 33: sb.Append("'" + a[dic["Cont2"]].Trim() + "', "); break;
                        case 34: sb.Append("'" + a[dic["DEPOSITO"]].Trim() + "', "); break;
                        case 35: sb.Append("'" + a[dic["TIPO_FE"]].Trim() + "', "); break;
                        case 36: sb.Append("'" + a[dic["SEQ"]].Trim() + "', "); break;
                        case 37: sb.Append("'" + a[dic["EMP_FIL"]].Trim() + "', "); break;
                        case 38: sb.Append("'" + a[dic["DT_VENCTO"]].Trim() + "', "); break;
                        case 39: sb.Append("'" + a[dic["DT_DOC_F"]].Trim() + "', "); break;
                        case 40: sb.Append("'" + a[dic["QT_FECH"]].Trim() + "', "); break;
                        case 41: sb.Append("'" + a[dic["QT_FECH_AN"]].Trim() + "', "); break;
                        case 42: sb.Append("'" + a[dic["VR_FECH"]].Trim() + "', "); break;
                        case 43: sb.Append("'" + a[dic["VR_FECH_AN"]].Trim() + "', "); break;
                        case 44: sb.Append("'" + a[dic["VR_FECH_NF"]].Trim() + "', "); break;
                        case 45: sb.Append("'" + a[dic["VR_FEAN_NF"]].Trim() + "', "); break;
                        case 46: sb.Append("'" + a[dic["VRI_ENVIAD"]].Trim() + "', "); break;
                        case 47: sb.Append("'" + a[dic["VRI_DEVOLV"]].Trim() + "', "); break;
                        case 48: sb.Append("'" + a[dic["VRI_FECH"]].Trim() + "', "); break;
                        case 49: sb.Append("'" + a[dic["VRI_FECH_AN"]].Trim() + "', "); break;
                        case 50: sb.Append("'" + a[dic["VRU_ENVIAD"]].Trim() + "', "); break;
                        case 51: sb.Append("'" + a[dic["VRU_DEVOLV"]].Trim() + "', "); break;
                        case 52: sb.Append("'" + a[dic["VRU_FECH"]].Trim() + "', "); break;
                        case 53: sb.Append("'" + a[dic["VRU_FECH_AN"]].Trim() + "', "); break;
                        case 54: sb.Append("'" + a[dic["REF_UNID"]].Trim() + "', "); break;
                        case 55: sb.Append("'" + a[dic["REF_LOCAL"]].Trim() + "', "); break;
                        case 56: sb.Append("'" + a[dic["C_CUSTO"]].Trim() + "', "); break;
                        case 57: sb.Append("'" + a[dic["DG_CCUSTO"]].Trim() + "', "); break;
                        case 58: sb.Append("'" + a[dic["C_CUSTO2"]].Trim() + "', "); break;
                        case 59: sb.Append("'" + a[dic["DG_CCUSTO2"]].Trim() + "', "); break;
                        case 60: sb.Append("'" + a[dic["CONTA"]].Trim() + "', "); break;
                        case 61: sb.Append("'" + a[dic["DG_CONTA"]].Trim() + "', "); break;
                        case 62: sb.Append("'" + a[dic["CONTA2"]].Trim() + "', "); break;
                        case 63: sb.Append("'" + a[dic["DG_CONTA2"]].Trim() + "', "); break;
                        case 64: sb.Append("'" + a[dic["TIPO_CONTAB"]].Trim() + "', "); break;
                        case 65: sb.Append("'" + a[dic["DATA_ALTER"]].Trim() + "', "); break;
                        case 66: sb.Append("'" + a[dic["TIME_STAMP"]].Trim() + "', "); break;
                        case 67: sb.Append("'" + a[dic["HORA_ALTER"]].Trim() + "', "); break;
                        case 68: sb.Append("'" + a[dic["ORIGEM_MOVTO"]].Trim() + "', "); break;
                        case 69: sb.Append("'" + a[dic["ORDEM_ENVIO"]].Trim() + "'), "); break;
                    }
                }
            }
            sb.Remove(sb.Length - 2, 2);



            sr.Close();
            st.Close();

            return sb;
        }

        private static Dictionary<string, int> ColunarPadraoForaDeEstoque(string linha)
        {
            var x = linha.Replace("\"", "").Replace("'", "").Split('\t');
            Dictionary<string, int> valor = new Dictionary<string, int>();

            for (int i = 0; i < x.Length; i++)
            {


                switch (x[i])
                {
                    case "Op": valor.Add("Op", i); break;
                    case "Doc.En": valor.Add("Doc.En", i); break;
                    case "Serie":
                        if (valor.Keys.Count == 2)
                        {
                            valor.Add("Serie1", i); break;
                        }
                        else if (valor.Keys.Count == 9)
                            valor.Add("Serie2", i); break;

                    case "Produto": valor.Add("Produto", i); break;
                    case "Tradução": valor.Add("Tradução", i); break;
                    case "TM": valor.Add("TM", i); break;
                    case "Data": valor.Add("Data", i); break;
                    case "Fornecedor": valor.Add("Fornecedor", i); break;
                    case "Doc. Fiscal": valor.Add("Doc. Fiscal", i); break;
                    case "Cont":
                        if (valor.Keys.Count == 10)
                        {
                            valor.Add("Cont1", i); break;
                        }
                        else if (valor.Keys.Count == 33)
                            valor.Add("Cont2", i); break;
                    case "Lt": valor.Add("Lt", i); break;
                    case "Qtde Nf": valor.Add("Qtde Nf", i); break;
                    case "Valor Nf": valor.Add("Valor Nf", i); break;
                    case "Valor Custo": valor.Add("Valor Custo", i); break;
                    case "Saldo Qtde": valor.Add("Saldo Qtde", i); break;
                    case "Saldo Custo": valor.Add("Saldo Custo", i); break;
                    case "Observação": valor.Add("Observação", i); break;
                    case "Nome Fantasia": valor.Add("Nome Fantasia", i); break;
                    case "Descrição": valor.Add("Descrição", i); break;
                    case "Valor Unitário": valor.Add("Valor Unitário", i); break;
                    case "Texto Específico Fat. Balcão": valor.Add("Texto Específico Fat. Balcão", i); break;
                    case "Obs NF Balcão": valor.Add("Obs NF Balcão", i); break;
                    case "TIPO_MOVTO_NF": valor.Add("TIPO_MOVTO_NF", i); break;
                    case "NRO_FORNEC": valor.Add("NRO_FORNEC", i); break;
                    case "SEQ_FORNEC": valor.Add("SEQ_FORNEC", i); break;
                    case "QT_ENVIADA": valor.Add("QT_ENVIADA", i); break;
                    case "VR_ENV_NF": valor.Add("VR_ENV_NF", i); break;
                    case "VR_ENVIADO": valor.Add("VR_ENVIADO", i); break;
                    case "QT_DEVOLV": valor.Add("QT_DEVOLV", i); break;
                    case "VR_DEV_NF": valor.Add("VR_DEV_NF", i); break;
                    case "VR_DEVOLV": valor.Add("VR_DEVOLV", i); break;
                    case "ESTAB": valor.Add("ESTAB", i); break;
                    case "DEPOSITO": valor.Add("DEPOSITO", i); break;
                    case "TIPO_FE": valor.Add("TIPO_FE", i); break;
                    case "SEQ": valor.Add("SEQ", i); break;
                    case "EMP_FIL": valor.Add("EMP_FIL", i); break;
                    case "DT_VENCTO": valor.Add("DT_VENCTO", i); break;
                    case "DT_DOC_F": valor.Add("DT_DOC_F", i); break;
                    case "QT_FECH": valor.Add("QT_FECH", i); break;
                    case "QT_FECH_AN": valor.Add("QT_FECH_AN", i); break;
                    case "VR_FECH": valor.Add("VR_FECH", i); break;
                    case "VR_FECH_AN": valor.Add("VR_FECH_AN", i); break;
                    case "VR_FECH_NF": valor.Add("VR_FECH_NF", i); break;
                    case "VR_FEAN_NF": valor.Add("VR_FEAN_NF", i); break;
                    case "VRI_ENVIAD": valor.Add("VRI_ENVIAD", i); break;
                    case "VRI_DEVOLV": valor.Add("VRI_DEVOLV", i); break;
                    case "VRI_FECH": valor.Add("VRI_FECH", i); break;
                    case "VRI_FECH_AN": valor.Add("VRI_FECH_AN", i); break;
                    case "VRU_ENVIAD": valor.Add("VRU_ENVIAD", i); break;
                    case "VRU_DEVOLV": valor.Add("VRU_DEVOLV", i); break;
                    case "VRU_FECH": valor.Add("VRU_FECH", i); break;
                    case "VRU_FECH_AN": valor.Add("VRU_FECH_AN", i); break;
                    case "REF_UNID": valor.Add("REF_UNID", i); break;
                    case "REF_LOCAL": valor.Add("REF_LOCAL", i); break;
                    case "C_CUSTO": valor.Add("C_CUSTO", i); break;
                    case "DG_CCUSTO": valor.Add("DG_CCUSTO", i); break;
                    case "C_CUSTO2": valor.Add("C_CUSTO2", i); break;
                    case "DG_CCUSTO2": valor.Add("DG_CCUSTO2", i); break;
                    case "CONTA": valor.Add("CONTA", i); break;
                    case "DG_CONTA": valor.Add("DG_CONTA", i); break;
                    case "CONTA2": valor.Add("CONTA2", i); break;
                    case "DG_CONTA2": valor.Add("DG_CONTA2", i); break;
                    case "TIPO_CONTAB": valor.Add("TIPO_CONTAB", i); break;
                    case "DATA_ALTER": valor.Add("DATA_ALTER", i); break;
                    case "TIME_STAMP": valor.Add("TIME_STAMP", i); break;
                    case "HORA_ALTER": valor.Add("HORA_ALTER", i); break;
                    case "ORIGEM_MOVTO": valor.Add("ORIGEM_MOVTO", i); break;
                    case "ORDEM_ENVIO": valor.Add("ORDEM_ENVIO", i); break;

                }
            }
            return valor;
        }

        public static void CustomSaldo()
        {
            int colunas = 46;
            Stream st = File.Open(@"C:\Exports\ExportSaldo.txt", FileMode.Open);
            StreamReader sr = new StreamReader(st, Encoding.Default);
            string linha;

            Stream st2 = File.Open(@"C:\Exports\ExportSaldoCustom.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(st2, Encoding.Default);
            int c = 0;
            int[] sb = new int[14];
            while ((linha = sr.ReadLine()) != null)
            {

                string l = linha.Replace("\"", "");
                string[] a = new string[60];
            volta:
                a = linha.Replace("\"", "").Replace("'", "").Split('\t');
                //se erro na linha
                if (a.Count() != colunas)
                {
                    linha = linha + sr.ReadLine();
                    goto volta;
                }

                //

                if (c <= 13)
                {


                    for (int i = 0; i < a.Length; i++)
                    {
                        switch (a[i].ToString())
                        {
                            case "Produto":
                                sb[0] = i; break;
                            case "Descrição":
                                if (sb[1] == 0)
                                {
                                    sb[1] = i;
                                }
                                break;
                            case "Unid":
                                sb[2] = i; break;
                            case "Saldo Atual":
                                sb[3] = i; break;
                            case "Estq. Mínimo":
                                sb[4] = i; break;
                            case "Estq. Máximo":
                                sb[5] = i; break;
                            case "Prateleira":
                                sb[6] = i; break;
                            case "Ped.Compras":
                                sb[7] = i; break;
                            case "Grupo":
                                sb[8] = i; break;
                            case "Dias sem Movimento":
                                sb[9] = i; break;
                            case "Fora Estoque":
                                sb[10] = i; break;
                            case "De Terceiros":
                                sb[11] = i; break;

                            case "Disponível":
                                sb[12] = i; break;
                            case "Ped.Vendas":
                                sb[13] = i; break;

                        }
                        c++;
                    }
                }
                //

                sw.WriteLine(
                    a[sb[0]] + '\t' + a[sb[1]].Trim() + '\t' + a[sb[2]] + '\t' + a[sb[3]] + '\t' + a[sb[4]] + '\t' +
                    a[sb[5]] + '\t' + a[sb[6]] + '\t' + a[sb[7]] + '\t' + a[sb[8]] + '\t' + a[sb[9]] + '\t' +
                    a[sb[10]] + '\t' + a[sb[11]] + '\t' + a[sb[12]] + '\t' + a[sb[13]]);

            }


            sw.Close();
            st2.Close();
            sr.Close();
            st.Close();
            //atende a qualidade na folha solicitacao nf terceiro
            File.Copy(@"C:\Exports\ExportSaldoCustom.txt", @"Z:\Cid\ExportCustom.txt", true);
        }


        internal static StringBuilder Movimentos()
        {
            int colunas = 44;
            StringBuilder sb = new StringBuilder();


            Stream st = File.Open(@"C:\Exports\Movimentos.txt", FileMode.Open);
            StreamReader sr = new StreamReader(st, Encoding.Default);
            string linha;

            linha = sr.ReadLine();

            var dicionario = ColunarPadraoMovimentos(linha);
            var d = dicionario.OrderBy(p => p.Value);
            var dic = new Dictionary<string, int>();

            foreach (var i in d)
            {
                dic.Add(i.Key, i.Value);
            }
            var x = Crud.Select("SELECT ID FROM movimentos order by id desc limit 1");
            int id = Convert.ToInt32(x.Tables[0].Rows[0].ItemArray[0].ToString());
            while ((linha = sr.ReadLine()) != null)
            {

                string l = linha.Replace("\"", "");
                string[] a, b = new string[colunas];
            volta:
                b = linha.Replace("\"", "").Replace("'", "").Split('\t');
                //se erro na linha
                if (b.Count() != colunas)
                {
                    linha = linha + sr.ReadLine();
                    goto volta;
                }
                a = b;
                for (int i = 0; i < a.Length; i++)
                {
                    switch (i)
                    {
                        case 0: sb.Append("(" + ++id + ", '" + Convert.ToDateTime(a[dic["Data"]].Trim()).ToString("yyyy-MM-dd") + "', "); break;
                        case 1: sb.Append("'" + a[dic["TM"]].Trim() + "', "); break;
                        case 2: sb.Append("'" + a[dic["Código"]].Trim() + "', "); break;
                        case 3: sb.Append("'" + a[dic["Lote"]].Trim() + "', "); break;
                        case 4: sb.Append("'" + a[dic["Documento"]].Trim() + "', "); break;
                        case 5: sb.Append("'" + a[dic["AC"]].Trim() + "', "); break;
                        case 6: sb.Append("'" + a[dic["Quantidade"]].Trim().Replace(",", ".") + "', "); break;
                        case 7: sb.Append("'" + a[dic["Valor Movimento"]].Trim().Replace(",", ".") + "', "); break;
                        case 8: sb.Append("'" + a[dic["OS"]].Trim() + "', "); break;
                        case 9: sb.Append("'" + a[dic["Descrição"]].Trim() + "', "); break;
                        case 10: sb.Append("'" + a[dic["Unidade"]].Trim() + "', "); break;
                        case 11: sb.Append("'" + a[dic["Tipo de Contabilização"]].Trim() + "', "); break;
                        case 12: sb.Append("'" + a[dic["Cliente/Fornecedor"]].Trim() + "', "); break;
                        case 13: sb.Append("'" + a[dic["Nome Fantasia"]].Trim() + "', "); break;
                        case 14: sb.Append("'" + a[dic["Contabiliza"]].Trim() + "', "); break;
                        case 15: sb.Append("'" + a[dic["Conta Contábil"]].Trim() + "', "); break;
                        case 16: sb.Append("'" + a[dic["Díg."]].Trim() + "', "); break;
                        case 17: sb.Append("'" + a[dic["Centro de Custo"]].Trim() + "', "); break;
                        case 18: sb.Append("'" + a[dic["Díg"]].Trim() + "', "); break;
                        case 19: sb.Append("'" + a[dic["Livre 2"]].Trim() + "', "); break;
                        case 20: sb.Append("'" + a[dic["Descr. Tipo Movto."]].Trim() + "', "); break;
                        case 21: sb.Append("'" + a[dic["CUSTO_INF"]].Trim() + "', "); break;
                        case 22:
                            Decimal m = Math.Round(Convert.ToDecimal(a[dic["Saldo Atual"]].Trim().Replace("E-", "")), 3);


                            //if (k == 867)
                            //{
                            //    var h = a[dic["Saldo Atual"]].Trim();
                            //    var p = h.Replace("E-","");
                            //    var o = p.Replace(",",".");
                            //    var s = Convert.ToDecimal(p);
                            //    var r = Math.Round(s, 3);
                            //}
                            //k++;


                            if (m > 0)
                            {
                                sb.Append("'" + m.ToString().Replace(",", ".") + "', "); break;
                            }
                            else
                                sb.Append("'0', "); break;

                        case 23: sb.Append("'" + a[dic["Cons. Médio"]].Trim().Replace(",", ".") + "', "); break;
                        case 24: sb.Append("'" + (a[dic["VALOR"]].Trim().Replace(",", ".")) + "', "); break;
                        case 25: sb.Append("'" + a[dic["DESC_RATEA"]].Trim() + "', "); break;
                        case 26: sb.Append("'" + a[dic["REF_LOTE"]].Trim() + "', "); break;
                        case 27: sb.Append("'" + a[dic["QTDE_BRUTA"]].Trim() + "', "); break;
                        case 28: sb.Append("'" + a[dic["FLAG"]].Trim() + "', "); break;
                        case 29: sb.Append("'" + a[dic["EMP_FIL"]].Trim() + "', "); break;
                        case 30: sb.Append("'" + a[dic["ESTAB"]].Trim() + "', "); break;
                        case 31: sb.Append("'" + a[dic["DEPOSITO"]].Trim() + "', "); break;
                        case 32: sb.Append("'" + (a[dic["Custo Médio Simulado"]].Trim().Replace(",", ".")) + "', "); break;
                        case 33: sb.Append("'" + a[dic["NR_TRANSF_CG"]].Trim() + "', "); break;
                        case 34: sb.Append("'" + a[dic["Operador Inclusão"]].Trim() + "', "); break;
                        case 35: sb.Append("'" + Convert.ToDateTime(a[dic["Data Inclusão"]].Trim()).ToString("yyyy-MM-dd") + "', "); break;
                        case 36: sb.Append("'" + a[dic["Hora Inclusão"]].Trim() + "', "); break;
                        case 37: sb.Append("'" + (a[dic["Custo médio"]].Trim().Replace(",", ".")) + "', "); break;
                        case 38: sb.Append("'" + a[dic["Roteiro"]].Trim() + "', "); break;
                        case 39: sb.Append("'" + a[dic["Data Início Roteiro"]].Trim() + "', "); break;
                        case 40: sb.Append("'" + (a[dic["Quantidade Digitada"]].Trim().Replace(",", ".")) + "', "); break;
                        case 41: sb.Append("'" + a[dic["Fator"]].Trim() + "', "); break;
                        case 42: sb.Append("'" + a[dic["OPERACAO"]].Trim() + "', "); break;
                        case 43: sb.Append("'" + a[dic["Descr. Movto"]].Trim() + "'), "); break;
                    }
                }
            }
            sb.Remove(sb.Length - 2, 2);



            sr.Close();
            st.Close();

            return sb;
        }

        private static Dictionary<string, int> ColunarPadraoMovimentos(string linha)
        {
            var x = linha.Replace("\"", "").Replace("'", "").Split('\t');
            Dictionary<string, int> valor = new Dictionary<string, int>();

            for (int i = 0; i < x.Length; i++)
            {


                switch (x[i])
                {
                    case "Data": valor.Add("Data", i); break;
                    case "TM": valor.Add("TM", i); break;
                    case "Código": valor.Add("Código", i); break;
                    case "Lote": valor.Add("Lote", i); break;
                    case "Documento": valor.Add("Documento", i); break;
                    case "AC": valor.Add("AC", i); break;
                    case "Quantidade": valor.Add("Quantidade", i); break;
                    case "Valor Movimento": valor.Add("Valor Movimento", i); break;
                    case "OS": valor.Add("OS", i); break;
                    case "Descrição": valor.Add("Descrição", i); break;
                    case "Unidade": valor.Add("Unidade", i); break;
                    case "Tipo de Contabilização": valor.Add("Tipo de Contabilização", i); break;
                    case "Cliente/Fornecedor": valor.Add("Cliente/Fornecedor", i); break;
                    case "Nome Fantasia": valor.Add("Nome Fantasia", i); break;
                    case "Contabiliza": valor.Add("Contabiliza", i); break;
                    case "Conta Contábil": valor.Add("Conta Contábil", i); break;
                    case "Díg.":
                        if (valor.Keys.Count == 16)
                        {
                            valor.Add("Díg.", i); break;
                        }
                        else if (valor.Keys.Count == 18)
                            valor.Add("Díg", i); break;
                    case "Centro de Custo": valor.Add("Centro de Custo", i); break;
                    //case "Díg.": valor.Add("Díg.", i); break;
                    case "Livre 2": valor.Add("Livre 2", i); break;
                    case "Descr. Tipo Movto.": valor.Add("Descr. Tipo Movto.", i); break;
                    case "CUSTO_INF": valor.Add("CUSTO_INF", i); break;
                    case "Saldo Atual": valor.Add("Saldo Atual", i); break;
                    case "Cons. Médio": valor.Add("Cons. Médio", i); break;
                    case "VALOR": valor.Add("VALOR", i); break;
                    case "DESC_RATEA": valor.Add("DESC_RATEA", i); break;
                    case "REF_LOTE": valor.Add("REF_LOTE", i); break;
                    case "QTDE_BRUTA": valor.Add("QTDE_BRUTA", i); break;
                    case "FLAG": valor.Add("FLAG", i); break;
                    case "EMP_FIL": valor.Add("EMP_FIL", i); break;
                    case "ESTAB": valor.Add("ESTAB", i); break;
                    case "DEPOSITO": valor.Add("DEPOSITO", i); break;
                    case "Custo Médio Simulado": valor.Add("Custo Médio Simulado", i); break;
                    case "NR_TRANSF_CG": valor.Add("NR_TRANSF_CG", i); break;
                    case "Operador Inclusão": valor.Add("Operador Inclusão", i); break;
                    case "Data Inclusão": valor.Add("Data Inclusão", i); break;
                    case "Hora Inclusão": valor.Add("Hora Inclusão", i); break;
                    case "Custo médio": valor.Add("Custo médio", i); break;
                    case "Roteiro": valor.Add("Roteiro", i); break;
                    case "Data Início Roteiro": valor.Add("Data Início Roteiro", i); break;
                    case "Quantidade Digitada": valor.Add("Quantidade Digitada", i); break;
                    case "Fator": valor.Add("Fator", i); break;
                    case "OPERACAO": valor.Add("OPERACAO", i); break;
                    case "Descr. Movto": valor.Add("Descr. Movto", i); break;
                }
            }
            return valor;
        }

        internal static object PedidoDeVenda()
        {

            try
            {
                int colunas = 22;
                StringBuilder sb = new StringBuilder();


                Stream st = File.Open(@"C:\Exports\PedidosDeVendas.txt", FileMode.Open);
                StreamReader sr = new StreamReader(st, Encoding.Default);
                string linha;

                linha = sr.ReadLine();

                var dicionario = ColunarPadraoPedVenda(linha);
                var d = dicionario.OrderBy(p => p.Value);
                var dic = new Dictionary<string, int>();

                foreach (var i in d)
                {
                    dic.Add(i.Key, i.Value);
                }

                int id = 1;
                while ((linha = sr.ReadLine()) != null)
                {
                    string l = linha.Replace("\"", "");
                    string[] a, b = new string[colunas];
                volta:
                    b = linha.Replace("\"", "").Replace("'", "").Split('\t');
                    //se erro na linha
                    if (b.Count() != colunas)
                    {
                        linha = linha + sr.ReadLine();
                        goto volta;
                    }
                    a = b;
                    for (int i = 0; i < a.Length; i++)
                    {

                        var x = dicionario["Nº Pedido"];
                        switch (i)
                        {
                            case 0: sb.Append("(" + id++ + ", '" + a[dic["Nº Pedido"]].Trim() + "', "); break;
                            case 1: sb.Append("'" + Convert.ToDateTime(a[dicionario["Data Entrega"]].Trim()).ToString("yyyy-MM-dd") + "', "); break;
                            case 2: sb.Append("'" + a[dicionario["Vendedor"]].Trim() + "', "); break;
                            case 3: sb.Append("'" + a[dicionario["Seq"]].Trim() + "', "); break;
                            case 4: sb.Append("'" + (a[dicionario["Quantidade"]].Trim().Replace(",", ".")) + "', "); break;
                            case 5: sb.Append("'" + a[dicionario["Status do Item"]].Trim() + "', "); break;
                            case 6: sb.Append("'" + Convert.ToDateTime(a[dicionario["Data Pedido"]].Trim()).ToString("yyyy-MM-dd") + "', "); break;
                            case 7: sb.Append("'" + a[dicionario["Bloq"]].Trim() + "', "); break;
                            case 8: sb.Append("'" + a[dicionario["Motivos Bloqueio"]].Trim() + "', "); break;
                            case 9: sb.Append("'" + a[dicionario["Item"]].Trim() + "', "); break;
                            case 10: sb.Append("'" + a[dicionario["Estabelecimento"]].Trim() + "', "); break;
                            case 11: sb.Append("'" + a[dicionario["Déposito"]].Trim() + "', "); break;
                            case 12: sb.Append("'" + a[dicionario["Disponível"]].Trim() + "', "); break;
                            case 13: sb.Append("'" + a[dicionario["Descrição"]].Trim() + "', "); break;
                            case 14: sb.Append("'" + a[dicionario["Ordem Compra"]].Trim() + "', "); break;
                            case 15: sb.Append("'" + a[dicionario["Preço Unitário"]].Trim() + "', "); break;
                            case 16: sb.Append("'" + a[dicionario["Valor Total"]].Trim() + "', "); break;
                            case 17: sb.Append("'" + a[dicionario["Razão Social"]].Trim() + "', "); break;
                            case 18: sb.Append("'" + a[dicionario["Código Cliente"]].Trim() + "', "); break;
                            case 19: sb.Append("'" + a[dicionario["DESCR_1"]].Trim() + "', "); break;
                            case 20: sb.Append("'" + a[dicionario["DESCR_2"]].Trim() + "', "); break;
                            case 21: sb.Append("'" + a[dicionario["Venda Confirmada"]].Trim() + "'), "); break;

                        }
                    }
                }
                sb.Remove(sb.Length - 2, 2);



                sr.Close();
                st.Close();

                return sb;
            }
            catch (Exception)
            {
                ControllerERP_Pronto.PedidoVenda();
                Import.PedidoVendaImport();
                return null;
            }


        }

        private static Dictionary<string, int> ColunarPadraoPedVenda(string linha)
        {
            var x = linha.Replace("\"", "").Replace("'", "").Split('\t');
            Dictionary<string, int> valor = new Dictionary<string, int>();

            for (int i = 0; i < x.Length; i++)
            {



                switch (x[i])
                {

                    case "Nº Pedido": valor.Add("Nº Pedido", i); break;
                    case "Data Entrega": valor.Add("Data Entrega", i); break;
                    case "Vendedor": valor.Add("Vendedor", i); break;
                    case "Seq": valor.Add("Seq", i); break;
                    case "Quantidade": valor.Add("Quantidade", i); break;
                    case "Status do Item": valor.Add("Status do Item", i); break;
                    case "Data Pedido": valor.Add("Data Pedido", i); break;
                    case "Bloq": valor.Add("Bloq", i); break;
                    case "Motivos Bloqueio": valor.Add("Motivos Bloqueio", i); break;
                    case "Item": valor.Add("Item", i); break;
                    case "Estabelecimento": valor.Add("Estabelecimento", i); break;
                    case "Depósito": valor.Add("Déposito", i); break;
                    case "Disponível": valor.Add("Disponível", i); break;
                    case "Descrição": valor.Add("Descrição", i); break;
                    case "Ordem Compra": valor.Add("Ordem Compra", i); break;
                    case "Preço Unitário": valor.Add("Preço Unitário", i); break;
                    case "Valor Total": valor.Add("Valor Total", i); break;
                    case "Código Cliente": valor.Add("Código Cliente", i); break;
                    case "Razão Social": valor.Add("Razão Social", i); break;
                    case "DESCR_1": valor.Add("DESCR_1", i); break;
                    case "DESCR_2": valor.Add("DESCR_2", i); break;
                    case "Venda Confirmada": valor.Add("Venda Confirmada", i); break;

                }
            }
            return valor;
        }

        public static StringBuilder PedidoDeCompra()
        {
            Stream st = File.Open(@"C:\Exports\PedidosDeCompras.txt", FileMode.Open);
            StreamReader sr = new StreamReader(st, Encoding.Default);

            //try
            //{
            int colunas = 79;
            StringBuilder sb = new StringBuilder();

            string linha;

            linha = sr.ReadLine();


            var dicionario = ColunarPadraoPedCompra(linha);
            var d = dicionario.OrderBy(p => p.Value);
            var dic = new Dictionary<string, int>();

            foreach (var i in d)
            {
                dic.Add(i.Key, i.Value);
            }

            int id = 1;
            while ((linha = sr.ReadLine()) != null)
            {
                string[] a, b = new string[colunas];
            volta:
                b = linha.Replace("\"", "").Replace("'", "").Split('\t');

                //se erro na linha
                if (b.Count() != colunas)
                {

                    MessageBox.Show("Reparar linha do pedido de compra: " + linha);
                    sr.Close();
                    st.Close();
                    //linha += sr.ReadLine();
                    //goto volta;
                }


                //
                a = b;
                for (int i = 0; i < a.Length; i++)
                {

                    switch (i)
                    {
                        case 0: sb.Append("(" + id++ + ", '" + Convert.ToInt32(a[dic["Pedido"]].Trim()) + "', "); break;
                        case 1: sb.Append("'" + Convert.ToDateTime(a[dicionario["Data"]].Trim()).ToString("yyyy-MM-dd") + "', "); break;
                        case 2: sb.Append("'" + Convert.ToDateTime(a[dicionario["Entrega"]].Trim()).ToString("yyyy-MM-dd") + "', "); break;
                        case 3: sb.Append("'" + a[dicionario["Produto"]].Trim() + "', "); break;
                        case 4: sb.Append("'" + (a[dicionario["Valor Unitário"]].Trim().Replace(",", ".")) + "', "); break;
                        case 5: sb.Append("'" + a[dicionario["Preço Total"]].Trim().Replace(",", ".") + "', "); break;
                        case 6: sb.Append("'" + a[dicionario["Unidade"]].Trim().Replace(",", ".") + "', "); break;
                        //case 7: sb.Append("'" + a[dicionario["Requisição"]].Trim().Replace(",", ".") + "', "); break;
                        //case 8: sb.Append("'" + a[dicionario["Linha Req."]].Trim().Replace(",", ".") + "', "); break;
                        //case 9: sb.Append("'" + a[dicionario["C.Custo"]].Trim().Replace(",", ".") + "', "); break;
                        case 10: sb.Append("'" + a[dicionario["Descrição Alternativa"]].Trim().Replace(",", ".") + "', "); break;
                        case 11: sb.Append("'" + a[dicionario["Fornecedor"]].Trim().Replace(",", ".") + "', "); break;
                        //case 12: sb.Append("'" + a[dicionario["Indice"]].Trim().Replace(",", ".") + "', "); break;
                        //case 13: sb.Append("'" + a[dicionario["Descrição da Moeda"]].Trim().Replace(",", ".") + "', "); break;
                        case 12: sb.Append("'" + a[dicionario["Quantidade"]].Trim().Replace(",", ".") + "', "); break;
                        case 13: sb.Append("'" + a[dicionario["Qtde. Entregue"]].Trim().Replace(",", ".") + "', "); break;
                        case 14: sb.Append("'" + a[dicionario["Linha Ped."]].Trim().Replace(",", ".") + "', "); break;
                        case 15: sb.Append("'" + a[dicionario["Saldo"]].Trim().Replace(",", ".") + "'), "); break;
                            //case 18: sb.Append("'" + a[dicionario["Situação"]].Trim().Replace(",", ".") + "', "); break;
                            //case 19: sb.Append("'" + a[dicionario["STA_REG"]].Trim().Replace(",", ".") + "', "); break;
                            //case 20: sb.Append("'" + a[dicionario["Descrição"]].Trim().Replace(",", ".") + "', "); break;
                            //case 21: sb.Append("'" + a[dicionario["Observações"]].Trim().Replace(",", ".") + "', "); break;
                            //case 22: sb.Append("'" + a[dicionario["Dig C.Custo"]].Trim().Replace(",", ".") + "', "); break;
                            //case 23: sb.Append("'" + a[dicionario["Título"]].Trim().Replace(",", ".") + "', "); break;
                            //case 24: sb.Append("'" + a[dicionario["Tradução"]].Trim().Replace(",", ".") + "', "); break;
                            //case 25: sb.Append("'" + a[dicionario["Baixa Manual"]].Trim().Replace(",", ".") + "', "); break;
                            //case 26: sb.Append("'" + a[dicionario["Baixa NF"]].Trim().Replace(",", ".") + "', "); break;
                            //case 27: sb.Append("'" + a[dicionario["Unidade Estq."]].Trim().Replace(",", ".") + "', "); break;
                            //case 28: sb.Append("'" + a[dicionario["Qtde Estq"]].Trim().Replace(",", ".") + "', "); break;
                            //case 29: sb.Append("'" + a[dicionario["EMP_FIL"]].Trim().Replace(",", ".") + "', "); break;
                            //case 30: sb.Append("'" + a[dicionario["ESTAB"]].Trim().Replace(",", ".") + "', "); break;
                            //case 31: sb.Append("'" + a[dicionario["DEPOSITO"]].Trim().Replace(",", ".") + "', "); break;
                            //case 32: sb.Append("'" + a[dicionario["FORNEC"]].Trim().Replace(",", ".") + "', "); break;
                            //case 33: sb.Append("'" + a[dicionario["NR_COTACAO"]].Trim().Replace(",", ".") + "', "); break;
                            //case 34: sb.Append("'" + a[dicionario["OS"]].Trim().Replace(",", ".") + "', "); break;
                            //case 35: sb.Append("'" + a[dicionario["PRIORIDADE"]].Trim().Replace(",", ".") + "', "); break;
                            //case 36: sb.Append("'" + a[dicionario["DT_ENT_PREV"]].Trim().Replace(",", ".") + "', "); break;
                            //case 37: sb.Append("'" + a[dicionario["DT_ENT_ORIG"]].Trim().Replace(",", ".") + "', "); break;
                            //case 38: sb.Append("'" + a[dicionario["DT_ULT_ENT"]].Trim().Replace(",", ".") + "', "); break;
                            //case 39: sb.Append("'" + a[dicionario["PORC_ICM"]].Trim().Replace(",", ".") + "', "); break;
                            //case 40: sb.Append("'" + a[dicionario["VEZES_ENT"]].Trim().Replace(",", ".") + "', "); break;
                            //case 41: sb.Append("'" + a[dicionario["LISTA"]].Trim().Replace(",", ".") + "', "); break;
                            //case 42: sb.Append("'" + a[dicionario["BASE_UNIT"]].Trim().Replace(",", ".") + "', "); break;
                            //case 43: sb.Append("'" + a[dicionario["PERC_DESC"]].Trim().Replace(",", ".") + "', "); break;
                            //case 44: sb.Append("'" + a[dicionario["PERC_IPI"]].Trim().Replace(",", ".") + "', "); break;
                            //case 45: sb.Append("'" + a[dicionario["VLR_DESC"]].Trim().Replace(",", ".") + "', "); break;
                            //case 46: sb.Append("'" + a[dicionario["VLR_IPI"]].Trim().Replace(",", ".") + "', "); break;
                            //case 47: sb.Append("'" + a[dicionario["VR_ENTR"]].Trim().Replace(",", ".") + "', "); break;
                            //case 48: sb.Append("'" + a[dicionario["SEQ_ALT"]].Trim().Replace(",", ".") + "', "); break;
                            //case 49: sb.Append("'" + a[dicionario["COD_TRIB"]].Trim().Replace(",", ".") + "', "); break;
                            //case 50: sb.Append("'" + a[dicionario["TRAT_FISC"]].Trim().Replace(",", ".") + "', "); break;
                            //case 51: sb.Append("'" + a[dicionario["COD_GEN"]].Trim().Replace(",", ".") + "', "); break;
                            //case 52: sb.Append("'" + a[dicionario["CONTA"]].Trim().Replace(",", ".") + "', "); break;
                            //case 53: sb.Append("'" + a[dicionario["DG_CONTA"]].Trim().Replace(",", ".") + "', "); break;
                            //case 54: sb.Append("'" + a[dicionario["CONTA2"]].Trim().Replace(",", ".") + "', "); break;
                            //case 55: sb.Append("'" + a[dicionario["DG_CONTA2"]].Trim().Replace(",", ".") + "', "); break;
                            //case 56: sb.Append("'" + a[dicionario["C_CUSTO2"]].Trim().Replace(",", ".") + "', "); break;
                            //case 57: sb.Append("'" + a[dicionario["DG_CCUSTO2"]].Trim().Replace(",", ".") + "', "); break;
                            //case 58: sb.Append("'" + a[dicionario["GERA_FLUXO"]].Trim().Replace(",", ".") + "', "); break;
                            //case 59: sb.Append("'" + a[dicionario["LIVRE"]].Trim().Replace(",", ".") + "', "); break;
                            //case 60: sb.Append("'" + a[dicionario["BATCH_PROG"]].Trim().Replace(",", ".") + "', "); break;
                            //case 61: sb.Append("'" + a[dicionario["BATCH_DATA"]].Trim().Replace(",", ".") + "', "); break;
                            //case 62: sb.Append("'" + a[dicionario["BATCH_HORA"]].Trim().Replace(",", ".") + "', "); break;
                            //case 63: sb.Append("'" + a[dicionario["ESTAGIO"]].Trim().Replace(",", ".") + "', "); break;
                            //case 64: sb.Append("'" + a[dicionario["DT_INIC_EXEC"]].Trim().Replace(",", ".") + "', "); break;
                            //case 65: sb.Append("'" + a[dicionario["PERIODO"]].Trim().Replace(",", ".") + "', "); break;
                            //case 66: sb.Append("'" + a[dicionario["PROJETO_OBRA"]].Trim().Replace(",", ".") + "', "); break;
                            //case 67: sb.Append("'" + a[dicionario["PROJETO_ETAPA"]].Trim().Replace(",", ".") + "', "); break;
                            //case 68: sb.Append("'" + a[dicionario["APROVADOR_PROX"]].Trim().Replace(",", ".") + "', "); break;
                            //case 69: sb.Append("'" + a[dicionario["APROV_AVISADO"]].Trim().Replace(",", ".") + "', "); break;
                            //case 70: sb.Append("'" + a[dicionario["DT_APROVACAO"]].Trim().Replace(",", ".") + "', "); break;
                            //case 71: sb.Append("'" + a[dicionario["DT_VALIDADE"]].Trim().Replace(",", ".") + "', "); break;
                            //case 72: sb.Append("'" + a[dicionario["SOLICITANTE"]].Trim().Replace(",", ".") + "', "); break;
                            //case 73: sb.Append("'" + a[dicionario["UNID_FORN"]].Trim().Replace(",", ".") + "', "); break;
                            //case 74: sb.Append("'" + a[dicionario["FATOR_UN_FORN"]].Trim().Replace(",", ".") + "', "); break;
                            //case 75: sb.Append("'" + a[dicionario["CUSTO_QT_SOLIC"]].Trim().Replace(",", ".") + "', "); break;
                            //case 76: sb.Append("'" + a[dicionario["CUSTO_QT_APROV"]].Trim().Replace(",", ".") + "', "); break;
                            //case 77: sb.Append("'" + a[dicionario["COND_PAGTO"]].Trim().Replace(",", ".") + "', "); break;

                            //case 78: sb.Append("'" + a[dicionario["TIPO_DESPESA"]].Trim().Replace(",", ".") + "'), "); break;

                    }
                }
            }
            sb.Remove(sb.Length - 2, 2);



            sr.Close();
            st.Close();

            return sb;
            //}
            //catch (Exception e)
            //{
            //    sr.Close();
            //    st.Close();

            //    Console.WriteLine(e.Message);
            //    ControllerERP_Pronto.PedidoCompra();
            //    Import.PedidoCompraImport();
            //    return null;
            //}

        }
        private static Dictionary<string, int> ColunarPadraoPedCompra(string linha)
        {
            var x = linha.Replace("\"", "").Replace("'", "").Split('\t');
            Dictionary<string, int> valor = new Dictionary<string, int>();

            for (int i = 0; i < x.Length; i++)
            {
                switch (x[i])
                {
                    case "Pedido": valor.Add("Pedido", i); break;
                    case "Data": valor.Add("Data", i); break;
                    case "Entrega": valor.Add("Entrega", i); break;
                    case "Produto": valor.Add("Produto", i); break;
                    case "Valor Unitário": valor.Add("Valor Unitário", i); break;
                    case "Preço Total": valor.Add("Preço Total", i); break;
                    case "Unidade": valor.Add("Unidade", i); break;
                    //case "Requisição": valor.Add("Requisição", i); break;
                    //case "Linha Req.": valor.Add("Linha Req.", i); break;
                    //case "C.Custo": valor.Add("C.Custo", i); break;
                    case "Descrição Alternativa": valor.Add("Descrição Alternativa", i); break;
                    case "Fornecedor": valor.Add("Fornecedor", i); break;
                    //case "Indice": valor.Add("Indice", i); break;
                    //case "Descrição da Moeda": valor.Add("Descrição da Moeda", i); break;
                    case "Quantidade": valor.Add("Quantidade", i); break;
                    case "Qtde. Entregue": valor.Add("Qtde. Entregue", i); break;
                    case "Linha Ped.": valor.Add("Linha Ped.", i); break;
                    case "Saldo": valor.Add("Saldo", i); break;
                        //case "Situação": valor.Add("Situação", i); break;
                        //case "STA_REG": valor.Add("STA_REG", i); break;
                        //case "Descrição": valor.Add("Descrição", i); break;
                        //case "Observações": valor.Add("Observações", i); break;
                        //case "Dig C.Custo": valor.Add("Dig C.Custo", i); break;
                        //case "Título": valor.Add("Título", i); break;
                        //case "Tradução": valor.Add("Tradução", i); break;
                        //case "Baixa Manual": valor.Add("Baixa Manual", i); break;
                        //case "Baixa NF": valor.Add("Baixa NF", i); break;
                        //case "Unidade Estq.": valor.Add("Unidade Estq.", i); break;
                        //case "Qtde Estq": valor.Add("Qtde Estq", i); break;
                        //case "EMP_FIL": valor.Add("EMP_FIL", i); break;
                        //case "ESTAB": valor.Add("ESTAB", i); break;
                        //case "DEPOSITO": valor.Add("DEPOSITO", i); break;
                        //case "FORNEC": valor.Add("FORNEC", i); break;
                        //case "NR_COTACAO": valor.Add("NR_COTACAO", i); break;
                        //case "OS": valor.Add("OS", i); break;
                        //case "PRIORIDADE": valor.Add("PRIORIDADE", i); break;
                        //case "DT_ENT_PREV": valor.Add("DT_ENT_PREV", i); break;
                        //case "DT_ENT_ORIG": valor.Add("DT_ENT_ORIG", i); break;
                        //case "DT_ULT_ENT": valor.Add("DT_ULT_ENT", i); break;
                        //case "PORC_ICM": valor.Add("PORC_ICM", i); break;
                        //case "VEZES_ENT": valor.Add("VEZES_ENT", i); break;
                        //case "LISTA": valor.Add("LISTA", i); break;
                        //case "BASE_UNIT": valor.Add("BASE_UNIT", i); break;
                        //case "PERC_DESC": valor.Add("PERC_DESC", i); break;
                        //case "PERC_IPI": valor.Add("PERC_IPI", i); break;
                        //case "VLR_DESC": valor.Add("VLR_DESC", i); break;
                        //case "VLR_IPI": valor.Add("VLR_IPI", i); break;
                        //case "VR_ENTR": valor.Add("VR_ENTR", i); break;
                        //case "SEQ_ALT": valor.Add("SEQ_ALT", i); break;
                        //case "COD_TRIB": valor.Add("COD_TRIB", i); break;
                        //case "TRAT_FISC": valor.Add("TRAT_FISC", i); break;
                        //case "COD_GEN": valor.Add("COD_GEN", i); break;
                        //case "CONTA": valor.Add("CONTA", i); break;
                        //case "DG_CONTA": valor.Add("DG_CONTA", i); break;
                        //case "CONTA2": valor.Add("CONTA2", i); break;
                        //case "DG_CONTA2": valor.Add("DG_CONTA2", i); break;
                        //case "C_CUSTO2": valor.Add("C_CUSTO2", i); break;
                        //case "DG_CCUSTO2": valor.Add("DG_CCUSTO2", i); break;
                        //case "GERA_FLUXO": valor.Add("GERA_FLUXO", i); break;
                        //case "LIVRE": valor.Add("LIVRE", i); break;
                        //case "BATCH_PROG": valor.Add("BATCH_PROG", i); break;
                        //case "BATCH_DATA": valor.Add("BATCH_DATA", i); break;
                        //case "BATCH_HORA": valor.Add("BATCH_HORA", i); break;
                        //case "ESTAGIO": valor.Add("ESTAGIO", i); break;
                        //case "DT_INIC_EXEC": valor.Add("DT_INIC_EXEC", i); break;
                        //case "PERIODO": valor.Add("PERIODO", i); break;
                        //case "PROJETO_OBRA": valor.Add("PROJETO_OBRA", i); break;
                        //case "PROJETO_ETAPA": valor.Add("PROJETO_ETAPA", i); break;
                        //case "APROVADOR_PROX": valor.Add("APROVADOR_PROX", i); break;
                        //case "APROV_AVISADO": valor.Add("APROV_AVISADO", i); break;
                        //case "DT_APROVACAO": valor.Add("DT_APROVACAO", i); break;
                        //case "DT_VALIDADE": valor.Add("DT_VALIDADE", i); break;
                        //case "SOLICITANTE": valor.Add("SOLICITANTE", i); break;
                        //case "UNID_FORN": valor.Add("UNID_FORN", i); break;
                        //case "FATOR_UN_FORN": valor.Add("FATOR_UN_FORN", i); break;
                        //case "CUSTO_QT_SOLIC": valor.Add("CUSTO_QT_SOLIC", i); break;
                        //case "CUSTO_QT_APROV": valor.Add("CUSTO_QT_APROV", i); break;
                        //case "COND_PAGTO": valor.Add("COND_PAGTO", i); break;
                        //case "TIPO_DESPESA": valor.Add("TIPO_DESPESA", i); break;


                }
            }
            return valor;
        }
        */
    }
}