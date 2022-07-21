using System;
using System.Collections.Generic;
using System.Data;
using Estoque.Entidade;

namespace Estoque.Views
{
    internal class PopulandoDeTerceiro
    {
        private static List<DeTerceiro> d;

        internal static List<DeTerceiro> Start(DataSet DeTerc)
        {
            //d = new List<DeTerceiro>();
            //for (int linha = 0; linha < DeTerc.Tables[0].Rows.Count; linha++)
            //{

            //    d.Add(new DeTerceiro()
            //    {
            //        Id = (int)DeTerc.Tables[0].Rows[linha].ItemArray[0],

            //        Op = DeTerc.Tables[0].Rows[linha].ItemArray[1].ToString(),
            //        DocEn = DeTerc.Tables[0].Rows[linha].ItemArray[2].ToString(),
            //        Serie = DeTerc.Tables[0].Rows[linha].ItemArray[3].ToString(),
            //        Produto = DeTerc.Tables[0].Rows[linha].ItemArray[4].ToString(),
            //        Traducao = DeTerc.Tables[0].Rows[linha].ItemArray[5].ToString(),
            //        TM = DeTerc.Tables[0].Rows[linha].ItemArray[6].ToString(),
            //        Data = (DateTime)DeTerc.Tables[0].Rows[linha].ItemArray[7],
            //        Cliente = DeTerc.Tables[0].Rows[linha].ItemArray[8].ToString(),
            //        DocFiscal = DeTerc.Tables[0].Rows[linha].ItemArray[9].ToString(),
            //        Serie2 = DeTerc.Tables[0].Rows[linha].ItemArray[10].ToString(),

            //        Cont = DeTerc.Tables[0].Rows[linha].ItemArray[11].ToString(),
            //        Lt = DeTerc.Tables[0].Rows[linha].ItemArray[12].ToString(),
            //        QtdeNf = (double)DeTerc.Tables[0].Rows[linha].ItemArray[13],
            //        ValorNf = (double)DeTerc.Tables[0].Rows[linha].ItemArray[14],
            //        ValorCusto = (double)DeTerc.Tables[0].Rows[linha].ItemArray[15],
            //        SaldoQtde = (double)DeTerc.Tables[0].Rows[linha].ItemArray[16],
            //        SaldoCusto = (double)DeTerc.Tables[0].Rows[linha].ItemArray[17],
            //        Observacao = DeTerc.Tables[0].Rows[linha].ItemArray[18].ToString(),
            //        NomeFantasia = DeTerc.Tables[0].Rows[linha].ItemArray[19].ToString(),
            //        Descricao = DeTerc.Tables[0].Rows[linha].ItemArray[20].ToString(),

            //        ValorUnitario = (double)DeTerc.Tables[0].Rows[linha].ItemArray[21],
            //        TextoEspecificoFatBalcao = DeTerc.Tables[0].Rows[linha].ItemArray[22].ToString(),
            //        ObsNFBalcao = DeTerc.Tables[0].Rows[linha].ItemArray[23].ToString(),
            //        TIPO_MOVTO_NF = DeTerc.Tables[0].Rows[linha].ItemArray[24].ToString(),
            //        NRO_FORNEC = DeTerc.Tables[0].Rows[linha].ItemArray[25].ToString(),
            //        SEQ_FORNEC = DeTerc.Tables[0].Rows[linha].ItemArray[26].ToString(),
            //        QT_ENVIADA = (double)DeTerc.Tables[0].Rows[linha].ItemArray[27],
            //        VR_ENV_NF =  (double)DeTerc.Tables[0].Rows[linha].ItemArray[28],
            //        VR_ENVIADO = (double)DeTerc.Tables[0].Rows[linha].ItemArray[29],
            //        QT_DEVOLV =  (double)DeTerc.Tables[0].Rows[linha].ItemArray[30],
            //        VR_DEV_NF =  (double)DeTerc.Tables[0].Rows[linha].ItemArray[31],
            //        VR_DEVOLV =  (double)DeTerc.Tables[0].Rows[linha].ItemArray[32],
            //        ESTAB = DeTerc.Tables[0].Rows[linha].ItemArray[33].ToString(),
            //        Cont2 = DeTerc.Tables[0].Rows[linha].ItemArray[34].ToString(),
            //        DEPOSITO = DeTerc.Tables[0].Rows[linha].ItemArray[35].ToString(),
            //        TIPO_FE = DeTerc.Tables[0].Rows[linha].ItemArray[36].ToString(),
            //        SEQ = DeTerc.Tables[0].Rows[linha].ItemArray[37].ToString(),
            //        EMP_FIL = DeTerc.Tables[0].Rows[linha].ItemArray[38].ToString(),
            //        DT_VENCTO = DeTerc.Tables[0].Rows[linha].ItemArray[39].ToString(),
            //        DT_DOC_F =   (DateTime)DeTerc.Tables[0].Rows[linha].ItemArray[40],
            //        QT_FECH =    (double)DeTerc.Tables[0].Rows[linha].ItemArray[41],
            //        QT_FECH_AN = (double)DeTerc.Tables[0].Rows[linha].ItemArray[42],
            //        VR_FECH =    (double)DeTerc.Tables[0].Rows[linha].ItemArray[43],
            //        VR_FECH_AN = (double)DeTerc.Tables[0].Rows[linha].ItemArray[44],
            //        VR_FECH_NF = (double)DeTerc.Tables[0].Rows[linha].ItemArray[45],
            //        VR_FEAN_NF = (double)DeTerc.Tables[0].Rows[linha].ItemArray[46],
            //        VRI_ENVIAD = DeTerc.Tables[0].Rows[linha].ItemArray[47].ToString(),
            //        VRI_DEVOLV = DeTerc.Tables[0].Rows[linha].ItemArray[48].ToString(),
            //        VRI_FECH = DeTerc.Tables[0].Rows[linha].ItemArray[49].ToString(),
            //        VRI_FECH_AN = DeTerc.Tables[0].Rows[linha].ItemArray[50].ToString(),
            //        VRU_ENVIAD = DeTerc.Tables[0].Rows[linha].ItemArray[51].ToString(),
            //        VRU_DEVOLV = DeTerc.Tables[0].Rows[linha].ItemArray[52].ToString(),
            //        VRU_FECH = DeTerc.Tables[0].Rows[linha].ItemArray[53].ToString(),
            //        VRU_FECH_AN = DeTerc.Tables[0].Rows[linha].ItemArray[54].ToString(),
            //        REF_UNID = DeTerc.Tables[0].Rows[linha].ItemArray[55].ToString(),
            //        REF_LOCAL = DeTerc.Tables[0].Rows[linha].ItemArray[56].ToString(),
            //        C_CUSTO = DeTerc.Tables[0].Rows[linha].ItemArray[57].ToString(),
            //        DG_CCUSTO = DeTerc.Tables[0].Rows[linha].ItemArray[58].ToString(),
            //        C_CUSTO2 = DeTerc.Tables[0].Rows[linha].ItemArray[59].ToString(),
            //        DG_CCUSTO2 = DeTerc.Tables[0].Rows[linha].ItemArray[60].ToString(),

            //        CONTA = DeTerc.Tables[0].Rows[linha].ItemArray[61].ToString(),
            //        DG_CONTA = DeTerc.Tables[0].Rows[linha].ItemArray[62].ToString(),
            //        CONTA2 = DeTerc.Tables[0].Rows[linha].ItemArray[63].ToString(),
            //        DG_CONTA2 = DeTerc.Tables[0].Rows[linha].ItemArray[64].ToString(),
            //        TIPO_CONTAB = DeTerc.Tables[0].Rows[linha].ItemArray[65].ToString(),
            //        DATA_ALTER = (DateTime)DeTerc.Tables[0].Rows[linha].ItemArray[66],
            //        TIME_STAMP = DeTerc.Tables[0].Rows[linha].ItemArray[67].ToString(),
            //        HORA_ALTER = DeTerc.Tables[0].Rows[linha].ItemArray[68].ToString(),
            //        ORIGEM_MOVTO = DeTerc.Tables[0].Rows[linha].ItemArray[69].ToString(),
            //        ORDEM_ENVIO = DeTerc.Tables[0].Rows[linha].ItemArray[70].ToString()
            //    });
            //}
            return d;
        }

    }
}