using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ImportExportERP.Classes
{
    internal class Exports
    {
        static Label lblDownloadCorrente;
        public Exports(Label lblDownloadCorrente)
        {
            Exports.lblDownloadCorrente = lblDownloadCorrente;
        }
        public static string k = "ERRO";

        internal string Start(string item, Button btn, DateTimePicker dtp)
        {
           

            do
            {
                switch (item)
                {
                    case "01 E.Saldo": k = ControllerERP_Pronto.Saldo(); break;
                    case "02 E.Itens Estoque": k = ControllerERP_Pronto.ItensDeEstoque(); break;
                    case "03 E.Movimentos": k = ControllerERP_Pronto.Movimento(); break;
                    case "04 E.Pedido de Vendas": k = ControllerERP_Pronto.PedidoVenda(); break;
                    case "05 E.Fora de Estoque": k = ControllerERP_Pronto.ForaDeEstoque(); break;
                    case "06 E.De Terceiro": k = ControllerERP_Pronto.DeTerceiros(); break;
                    case "07 E.Pedido de Compras": k = ControllerERP_Pronto.PedidoCompra(); break;
                    case "08 E.Estab De Terceiro": k = ControllerERP_Pronto.DepositoDeTerceiro(); break;
                    case "09 E.Saldo DeTerceiro": k = ControllerERP_Pronto.SaldoDeTerceiro(); break;
                    case "10 E.Movimentos Total": k = ControllerERP_Pronto.MovimentoTotal(); break;
                    case "11 E.OrdensDeProducao": k = ControllerERP_Pronto.OrdensDeProducao(); break;
                    case "12 E.NFs Dinamica Produto": k = ControllerERP_Pronto.NFsDinamicaProduto(dtp); break;

                    case "01 I.Saldo": k = Import.SaldoImport(btn); break;
                    case "02 I.Itens Estoque": k = Import.ItensDeEstoqueImport(btn); break;
                    case "03 I.Movimentos": k = Import.MovimentoImport(btn); break;
                    case "04 I.Pedido de Vendas": k = Import.PedidoVendaImport(btn); break;
                    case "05 I.Fora de Estoque": k = Import.ForaDeEstoqueImport(btn); break;
                    case "06 I.De Terceiro": k = Import.DeTerceirosImport(btn); break;
                    case "07 I.Pedido de Compras": k = Import.PedidoCompraImport(btn); break;
                    case "08 I.Estab De Terceiro": k = Import.DepositoDeTerceiroImport(btn); break;
                    case "09 I.Saldo DeTerceiro": k = Import.SaldoDeTerceiroImport(btn); break;
                    //case "10 I.Movimentos Total": k = Import.MovimentoImpport(btn, ); break;
                    case "11 I.OrdensDeProducao": k = Import.OrdensDeProducao(btn); break;
                    case "12 I.NFs Dinamica Produto": k = Import.NFsDinamicaProduto(btn, dtp); break;

                    //case "03 E.MovimentosFULL": k = ControllerERP_Pronto.MovimentoFULL(); break;
                    //case "05 E.Fora de EstoqueFULL": k = ControllerERP_Pronto.ForaDeEstoqueFULL(); break;
                    //case "06 E.De TerceiroFULL": k = ControllerERP_Pronto.DeTerceirosFULL(); break;
                    //case "07 E.Pedido de ComprasFULL": k = ControllerERP_Pronto.PedidoCompraFULL(); break;
                    //case "11 E.OrdensDeProducaoFULL": k = ControllerERP_Pronto.OrdensDeProducaoFULL(); break;
                    //case "12 E.NFs Dinamica ProdutoFULL": k = ControllerERP_Pronto.NFsDinamicaProdutoFULL(dtp); break;

                    case "03 I.MovimentosFULL": k = Import.MovimentoImportFULL(btn); break;
                    case "05 I.Fora de EstoqueFULL": k = Import.ForaDeEstoqueImportFULL(btn); break;
                    case "06 I.De TerceiroFULL": k = Import.DeTerceirosImportFULL(btn); break;
                    case "07 I.Pedido de ComprasFULL": k = Import.PedidoCompraImportFULL(btn); break;
                    case "11 I.OrdensDeProducaoFULL": k = Import.OrdensDeProducaoFULL(btn); break;
                    case "12 I.NFs Dinamica ProdutoFULL": k = Import.NFsDinamicaProdutoFULL(btn, dtp); break;
                }
            } while (k == "ERRO");

            return k;
        }
    }
}