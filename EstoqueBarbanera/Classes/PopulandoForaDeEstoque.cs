using Estoque.Entidade;
using System;
using System.Collections.Generic;
using System.Data;

namespace Estoque.Views
{
    internal class PopulandoForaDeEstoque
    {
        private static List<ForaDeEstoqueForm> f;

        internal static List<ForaDeEstoqueForm> Start(DataSet ForaEst)
        {
            //f = new List<ForaDeEstoque>();
            //for (int linha = 0; linha < ForaEst.Tables[0].Rows.Count; linha++)
            //{

            //    f.Add(new ForaDeEstoque()
            //    {
            //        Id = (int)ForaEst.Tables[0].Rows[linha].ItemArray[0],

            //        Op = ForaEst.Tables[0].Rows[linha].ItemArray[1].ToString(),
            //        DocEn = ForaEst.Tables[0].Rows[linha].ItemArray[2].ToString(),
            //        Serie = ForaEst.Tables[0].Rows[linha].ItemArray[3].ToString(),
            //        Produto = ForaEst.Tables[0].Rows[linha].ItemArray[4].ToString(),
            //        Traducao = ForaEst.Tables[0].Rows[linha].ItemArray[5].ToString(),
            //        TM = ForaEst.Tables[0].Rows[linha].ItemArray[6].ToString(),
            //        Data = (DateTime)ForaEst.Tables[0].Rows[linha].ItemArray[7],
            //        Fornecedor = ForaEst.Tables[0].Rows[linha].ItemArray[8].ToString(),
            //        DocFiscal = ForaEst.Tables[0].Rows[linha].ItemArray[9].ToString(),
            //        Serie2 = ForaEst.Tables[0].Rows[linha].ItemArray[10].ToString(),
            //        Cont = ForaEst.Tables[0].Rows[linha].ItemArray[11].ToString(),
            //        Lt = ForaEst.Tables[0].Rows[linha].ItemArray[12].ToString(),
            //        QtdeNf = Convert.ToDouble(ForaEst.Tables[0].Rows[linha].ItemArray[13]),
            //        ValorNf = Convert.ToDouble(ForaEst.Tables[0].Rows[linha].ItemArray[14]),
            //        ValorCusto = Convert.ToDouble(ForaEst.Tables[0].Rows[linha].ItemArray[15]),
            //        SaldoQtde = Convert.ToDouble(ForaEst.Tables[0].Rows[linha].ItemArray[16]),
            //        SaldoCusto = Convert.ToDouble(ForaEst.Tables[0].Rows[linha].ItemArray[17]),
            //        Observacao = ForaEst.Tables[0].Rows[linha].ItemArray[18].ToString(),
            //        NomeFantasia = ForaEst.Tables[0].Rows[linha].ItemArray[19].ToString(),
            //        Descricao = ForaEst.Tables[0].Rows[linha].ItemArray[20].ToString(),
            //        ValorUnitario = Convert.ToDouble(ForaEst.Tables[0].Rows[linha].ItemArray[21]),
            //        TextoEspecificoFatBalcao = ForaEst.Tables[0].Rows[linha].ItemArray[22].ToString(),
            //        ObsNFBalcao = ForaEst.Tables[0].Rows[linha].ItemArray[23].ToString(),
            //        TIPO_MOVTO_NF = ForaEst.Tables[0].Rows[linha].ItemArray[24].ToString(),
            //        NRO_FORNEC = ForaEst.Tables[0].Rows[linha].ItemArray[25].ToString(),
            //        SEQ_FORNEC = ForaEst.Tables[0].Rows[linha].ItemArray[26].ToString(),
            //        QT_ENVIADA = Convert.ToDouble(ForaEst.Tables[0].Rows[linha].ItemArray[27]),
            //        VR_ENV_NF = Convert.ToDouble(ForaEst.Tables[0].Rows[linha].ItemArray[28]),
            //        VR_ENVIADO = Convert.ToDouble(ForaEst.Tables[0].Rows[linha].ItemArray[29]),
            //        QT_DEVOLV = Convert.ToDouble(ForaEst.Tables[0].Rows[linha].ItemArray[30]),
            //        VR_DEV_NF = Convert.ToDouble(ForaEst.Tables[0].Rows[linha].ItemArray[31]),
            //        VR_DEVOLV = Convert.ToDouble(ForaEst.Tables[0].Rows[linha].ItemArray[32]),
            //        ESTAB = ForaEst.Tables[0].Rows[linha].ItemArray[33].ToString(),
            //        Cont2 = ForaEst.Tables[0].Rows[linha].ItemArray[34].ToString(),
            //        DEPOSITO = ForaEst.Tables[0].Rows[linha].ItemArray[35].ToString(),
            //        TIPO_FE = ForaEst.Tables[0].Rows[linha].ItemArray[36].ToString(),
            //        SEQ = ForaEst.Tables[0].Rows[linha].ItemArray[37].ToString(),
            //        EMP_FIL = ForaEst.Tables[0].Rows[linha].ItemArray[38].ToString(),
            //        DT_VENCTO = ForaEst.Tables[0].Rows[linha].ItemArray[39].ToString(),
            //        DT_DOC_F = (DateTime)ForaEst.Tables[0].Rows[linha].ItemArray[7],
            //        QT_FECH = Convert.ToDouble(ForaEst.Tables[0].Rows[linha].ItemArray[41]),
            //        QT_FECH_AN = Convert.ToDouble(ForaEst.Tables[0].Rows[linha].ItemArray[42]),
            //        VR_FECH = Convert.ToDouble(ForaEst.Tables[0].Rows[linha].ItemArray[43]),
            //        VR_FECH_AN = Convert.ToDouble(ForaEst.Tables[0].Rows[linha].ItemArray[44]),
            //        VR_FECH_NF = Convert.ToDouble(ForaEst.Tables[0].Rows[linha].ItemArray[45]),
            //        VR_FEAN_NF = Convert.ToDouble(ForaEst.Tables[0].Rows[linha].ItemArray[46]),
            //        VRI_ENVIAD = ForaEst.Tables[0].Rows[linha].ItemArray[47].ToString(),
            //        VRI_DEVOLV = ForaEst.Tables[0].Rows[linha].ItemArray[48].ToString(),
            //        VRI_FECH = ForaEst.Tables[0].Rows[linha].ItemArray[49].ToString(),
            //        VRI_FECH_AN = ForaEst.Tables[0].Rows[linha].ItemArray[50].ToString(),
            //        VRU_ENVIAD = ForaEst.Tables[0].Rows[linha].ItemArray[51].ToString(),
            //        VRU_DEVOLV = ForaEst.Tables[0].Rows[linha].ItemArray[52].ToString(),
            //        VRU_FECH = ForaEst.Tables[0].Rows[linha].ItemArray[53].ToString(),
            //        VRU_FECH_AN = ForaEst.Tables[0].Rows[linha].ItemArray[54].ToString(),
            //        REF_UNID = ForaEst.Tables[0].Rows[linha].ItemArray[55].ToString(),
            //        REF_LOCAL = ForaEst.Tables[0].Rows[linha].ItemArray[56].ToString(),
            //        C_CUSTO = ForaEst.Tables[0].Rows[linha].ItemArray[57].ToString(),
            //        DG_CCUSTO = ForaEst.Tables[0].Rows[linha].ItemArray[58].ToString(),
            //        C_CUSTO2 = ForaEst.Tables[0].Rows[linha].ItemArray[59].ToString(),
            //        DG_CCUSTO2 = ForaEst.Tables[0].Rows[linha].ItemArray[60].ToString(),
            //        CONTA = ForaEst.Tables[0].Rows[linha].ItemArray[61].ToString(),
            //        DG_CONTA = ForaEst.Tables[0].Rows[linha].ItemArray[62].ToString(),
            //        CONTA2 = ForaEst.Tables[0].Rows[linha].ItemArray[63].ToString(),
            //        DG_CONTA2 = ForaEst.Tables[0].Rows[linha].ItemArray[64].ToString(),
            //        TIPO_CONTAB = ForaEst.Tables[0].Rows[linha].ItemArray[65].ToString(),
            //        DATA_ALTER = (DateTime)ForaEst.Tables[0].Rows[linha].ItemArray[7],
            //        TIME_STAMP = ForaEst.Tables[0].Rows[linha].ItemArray[67].ToString(),
            //        HORA_ALTER = ForaEst.Tables[0].Rows[linha].ItemArray[68].ToString(),
            //        ORIGEM_MOVTO = ForaEst.Tables[0].Rows[linha].ItemArray[69].ToString(),
            //        ORDEM_ENVIO = ForaEst.Tables[0].Rows[linha].ItemArray[70].ToString()
            //    });
            //}
            return f;
        }

    }
}