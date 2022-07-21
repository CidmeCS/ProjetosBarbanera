using System;
using System.Collections.Generic;
using System.Data;
using Estoque.Entidade;

namespace Estoque.Views
{
    internal class PopulandoMovimentos
    {
        private static List<Movimento> m;

        internal static List<Movimento> Start(DataSet movmt)
        {
            //m = new List<Movimento>();

            //for (int linha = 0; linha < movmt.Tables[0].Rows.Count; linha++)
            //{

            //    m.Add(new Movimento()
            //    {
            //        Id = (int)movmt.Tables[0].Rows[linha].ItemArray[0],

            //        Data = (DateTime)movmt.Tables[0].Rows[linha].ItemArray[1],
            //        TM = Convert.ToInt16(movmt.Tables[0].Rows[linha].ItemArray[2].ToString()),
            //        Codigo = movmt.Tables[0].Rows[linha].ItemArray[3].ToString(),
            //        Lote = movmt.Tables[0].Rows[linha].ItemArray[4].ToString(),
            //        Documento = movmt.Tables[0].Rows[linha].ItemArray[5].ToString(),
            //        AC = movmt.Tables[0].Rows[linha].ItemArray[6].ToString(),
            //        Quantidade = (double)movmt.Tables[0].Rows[linha].ItemArray[7],
            //        ValorMovimento = (double)movmt.Tables[0].Rows[linha].ItemArray[8],
            //        OS = movmt.Tables[0].Rows[linha].ItemArray[9].ToString(),
            //        Descricao = movmt.Tables[0].Rows[linha].ItemArray[10].ToString(),

            //        Unidade = movmt.Tables[0].Rows[linha].ItemArray[11].ToString(),
            //        TipodeContabilização = movmt.Tables[0].Rows[linha].ItemArray[12].ToString(),
            //        ClienteFornecedor = movmt.Tables[0].Rows[linha].ItemArray[13].ToString(),
            //        NomeFantasia = movmt.Tables[0].Rows[linha].ItemArray[14].ToString(),
            //        Contabiliza = movmt.Tables[0].Rows[linha].ItemArray[15].ToString(),
            //        ContaContabil = movmt.Tables[0].Rows[linha].ItemArray[16].ToString(),
            //        Dig = movmt.Tables[0].Rows[linha].ItemArray[17].ToString(),
            //        CentrodeCusto = movmt.Tables[0].Rows[linha].ItemArray[18].ToString(),
            //        Dig2 = movmt.Tables[0].Rows[linha].ItemArray[19].ToString(),
            //        Livre2 = movmt.Tables[0].Rows[linha].ItemArray[20].ToString(),

            //        DescrTipoMovto = movmt.Tables[0].Rows[linha].ItemArray[21].ToString(),
            //        CUSTO_INF = (double)movmt.Tables[0].Rows[linha].ItemArray[22],
            //        SaldoAtual = (double)movmt.Tables[0].Rows[linha].ItemArray[23],
            //        ConsMedio = (double)movmt.Tables[0].Rows[linha].ItemArray[24],
            //        VALOR = (double)movmt.Tables[0].Rows[linha].ItemArray[25],
            //        DESC_RATEA = movmt.Tables[0].Rows[linha].ItemArray[26].ToString(),
            //        REF_LOTE = movmt.Tables[0].Rows[linha].ItemArray[27].ToString(),
            //        QTDE_BRUTA = (double)movmt.Tables[0].Rows[linha].ItemArray[28],
            //        FLAG = movmt.Tables[0].Rows[linha].ItemArray[29].ToString(),
            //        EMP_FIL = movmt.Tables[0].Rows[linha].ItemArray[30].ToString(),

            //        ESTAB = movmt.Tables[0].Rows[linha].ItemArray[31].ToString(),
            //        DEPOSITO = movmt.Tables[0].Rows[linha].ItemArray[32].ToString(),
            //        CustoMedioSimulado = (double)movmt.Tables[0].Rows[linha].ItemArray[33],
            //        NR_TRANSF_CG = movmt.Tables[0].Rows[linha].ItemArray[34].ToString(),
            //        OperadorInclusao = movmt.Tables[0].Rows[linha].ItemArray[35].ToString(),
            //        DataInclusao = (DateTime)movmt.Tables[0].Rows[linha].ItemArray[36],
            //        HoraInclusao = movmt.Tables[0].Rows[linha].ItemArray[37].ToString(),
            //        CustoMedio = (double)movmt.Tables[0].Rows[linha].ItemArray[38],
            //        Roteiro = movmt.Tables[0].Rows[linha].ItemArray[39].ToString(),
            //        DataInicioRoteiro = movmt.Tables[0].Rows[linha].ItemArray[40].ToString(),

            //        QuantidadeDigitada = movmt.Tables[0].Rows[linha].ItemArray[41].ToString(),
            //        Fator = movmt.Tables[0].Rows[linha].ItemArray[42].ToString(),
            //        OPERACAO = movmt.Tables[0].Rows[linha].ItemArray[43].ToString(),
            //        DescrMovto = movmt.Tables[0].Rows[linha].ItemArray[44].ToString()
            //    });
            //}
            return m;
        }

    }
}