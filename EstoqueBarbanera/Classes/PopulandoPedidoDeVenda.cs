using System;
using System.Collections.Generic;
using System.Data;
using Estoque.Entidade;

namespace Estoque.Views
{
    internal class PopulandoPedidoDeVenda
    {
        private static List<PedidoDeVenda> pv;

        internal static List<PedidoDeVenda> Start(DataSet PedVenda)
        {
            //pv = new List<PedidoDeVenda>();
            //for (int linha = 0; linha < PedVenda.Tables[0].Rows.Count; linha++)
            //{

            //    pv.Add(new PedidoDeVenda()
            //    {
            //        Id = (int)PedVenda.Tables[0].Rows[linha].ItemArray[0],
            //        DataEntrega = (DateTime)PedVenda.Tables[0].Rows[linha].ItemArray[1],
            //        Seq = PedVenda.Tables[0].Rows[linha].ItemArray[2].ToString(),
            //        Quantidade = (double)PedVenda.Tables[0].Rows[linha].ItemArray[3],
            //        StatusdoItem = PedVenda.Tables[0].Rows[linha].ItemArray[4].ToString(),
            //        DataPedido = (DateTime)PedVenda.Tables[0].Rows[linha].ItemArray[5],

            //        Vendedor = PedVenda.Tables[0].Rows[linha].ItemArray[6].ToString(),
            //        Item = PedVenda.Tables[0].Rows[linha].ItemArray[7].ToString(),
            //        Bloq = PedVenda.Tables[0].Rows[linha].ItemArray[8].ToString(),
            //        Estabelecimento = PedVenda.Tables[0].Rows[linha].ItemArray[9].ToString(),
            //        MotivosBloqueio = PedVenda.Tables[0].Rows[linha].ItemArray[10].ToString(),

            //        Disponivel = (double)PedVenda.Tables[0].Rows[linha].ItemArray[11],
            //        NPedido = PedVenda.Tables[0].Rows[linha].ItemArray[12].ToString(),
            //        Descricao = PedVenda.Tables[0].Rows[linha].ItemArray[13].ToString(),
            //        Deposito = PedVenda.Tables[0].Rows[linha].ItemArray[14].ToString(),
            //        OrdemCompra = PedVenda.Tables[0].Rows[linha].ItemArray[15].ToString(),

            //        PrecoUnitário = (double)PedVenda.Tables[0].Rows[linha].ItemArray[16],
            //        ValorTotal = (double)PedVenda.Tables[0].Rows[linha].ItemArray[17],
            //        RazaoSocial = PedVenda.Tables[0].Rows[linha].ItemArray[18].ToString(),
            //        CodigoCliente = PedVenda.Tables[0].Rows[linha].ItemArray[19].ToString(),
            //        DESCR_1 = PedVenda.Tables[0].Rows[linha].ItemArray[20].ToString(),

            //        DESCR_2 = PedVenda.Tables[0].Rows[linha].ItemArray[21].ToString(),
            //        VendaConfirmada = PedVenda.Tables[0].Rows[linha].ItemArray[22].ToString(),
            //        GrupoItem = PedVenda.Tables[0].Rows[linha].ItemArray[23].ToString(),
            //        NomeFantasia = PedVenda.Tables[0].Rows[linha].ItemArray[24].ToString(),
            //        TextoEspecifico = PedVenda.Tables[0].Rows[linha].ItemArray[25].ToString(),




            //    });

            //}
            return pv;
        }
    }
}