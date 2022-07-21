using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ImportExportERP.Classes
{
    public class Import
    {
        static decimal b = 0M, f = 0M;
        public static BackgroundWorker bgw { get; set; }
        static DateTime hoje = DateTime.Today;
        static DateTime data = hoje.AddMonths(-2).AddDays(-hoje.Day + 1);
        static DateTime dataPC = hoje.AddYears(-2).AddDays(-hoje.Day + 1);

        public Import(BackgroundWorker bgw)
        {
            Import.bgw = bgw;
        }
        internal static string SaldoImport(Button btn)
        {
            var x = PadronizarColunasDados.Saldo();
            CRUD c = new CRUD();

            if (btn.Name == "btnExportarSqlServer")
            {
                NewMethod(x, out b, out f);
                c.TruncateSaldoSqlServer();
                int d = x.Count;
                for (int i = 0; i <= x.Count; i += 1000)
                {
                    if (d < 1000)
                    {
                        bgw.ReportProgress(100);
                        c.AdicionaSaldoSqlServer(x.GetRange(i, d));
                    }
                    else
                    {
                        f += b;
                        bgw.ReportProgress((int)Math.Floor(f));
                        c.AdicionaSaldoSqlServer(x.GetRange(i, 1000));
                    }
                    if (d >= 1000)
                    {
                        d -= 1000;
                    }
                }
                return "SaldoSqlServer Import Ok";
            }

            else if (btn.Name == "btnExportarMySql")
            {
                NewMethod(x, out b, out f);
                c.TruncateSaldoMySql();
                int d = x.Count;
                for (int i = 0; i <= x.Count; i += 1000)
                {
                    if (d < 1000)
                    {
                        bgw.ReportProgress(100);
                        c.AdicionaSaldoMySql(x.GetRange(i, d));
                    }
                    else
                    {
                        f += b;
                        bgw.ReportProgress((int)Math.Floor(f));
                        c.AdicionaSaldoMySql(x.GetRange(i, 1000));
                    }
                    if (d >= 1000)
                    {
                        d -= 1000;
                    }
                }
                Mensagerias.Send("SaldoMySql Import Ok");
                return "SaldoMySql Import Ok";
            }
            return null;
        }
        internal static string PedidoCompraImport(Button btn)
        {
            var x = PadronizarColunasDados.PedidoDeCompra(@"C:\Exports\PedidosDeCompras.txt");
            CRUD c = new CRUD();
            if (btn.Name == "btnExportarSqlServer")
            {
                NewMethod(x, out b, out f);
                c.TruncatePedidoDeCompraSqlServer();
                int d = x.Count;
                for (int i = 0; i <= x.Count; i += 1000)
                {
                    if (d < 1000)
                    {
                        bgw.ReportProgress(100);
                        c.AdicionaPedidoDeCompraSqlServer(x.GetRange(i, d));
                    }
                    else
                    {
                        f += b;
                        bgw.ReportProgress((int)Math.Floor(f));
                        c.AdicionaPedidoDeCompraSqlServer(x.GetRange(i, 1000));
                    }
                    if (d >= 1000)
                    {
                        d -= 1000;
                    }
                }
                return "PedidoDeCompraSqlServer Import Ok";
            }
            else if (btn.Name == "btnExportarMySql")
            {
                NewMethod(x, out b, out f);
                var pc = c.ListPedidoDeCompraMySql().Where(p => p.Entrega >= dataPC).ToList();
                c.DeletePedidoDeCompraMySql(pc);
                //c.TruncatePedidoDeCompraMySql();
                int d = x.Count;
                for (int i = 0; i <= x.Count; i += 1000)
                {
                    if (d < 1000)
                    {
                        bgw.ReportProgress(100);
                        c.AdicionaPedidoDeCompraMySql(x.GetRange(i, d));
                    }
                    else
                    {
                        f += b;
                        bgw.ReportProgress((int)Math.Floor(f));
                        c.AdicionaPedidoDeCompraMySql(x.GetRange(i, 1000));
                    }
                    if (d >= 1000)
                    {
                        d -= 1000;
                    }
                }
                Mensagerias.Send("PedidoDeCompraMySql Import Ok");
                return "PedidoDeCompraMySql Import Ok";
            }
            return null;
        }
        internal static string PedidoVendaImport(Button btn)
        {
            var x = PadronizarColunasDados.PedidoDeVenda();
            ParaEtiquetas.Start();
            CRUD c = new CRUD();
            if (btn.Name == "btnExportarSqlServer")
            {
                NewMethod(x, out b, out f);
                c.TruncatePedidoDeVendaSqlServer();
                int d = x.Count;
                for (int i = 0; i <= x.Count; i += 1000)
                {
                    if (d < 1000)
                    {
                        bgw.ReportProgress(100);
                        c.AdicionaPedidoDeVendaSqlServer(x.GetRange(i, d));
                    }
                    else
                    {
                        f += b;
                        bgw.ReportProgress((int)Math.Floor(f));
                        c.AdicionaPedidoDeVendaSqlServer(x.GetRange(i, 1000));
                    }
                    if (d >= 1000)
                    {
                        d -= 1000;
                    }
                }
                return "PedidoDeVendaSqlServer Import Ok";
            }
            else if (btn.Name == "btnExportarMySql")
            {
                NewMethod(x, out b, out f);
                c.TruncatePedidoDeVendaMySql();
                int d = x.Count;
                for (int i = 0; i <= x.Count; i += 1000)
                {
                    if (d < 1000)
                    {
                        bgw.ReportProgress(100);
                        c.AdicionaPedidoDeVendaMySql(x.GetRange(i, d));
                    }
                    else
                    {
                        f += b;
                        bgw.ReportProgress((int)Math.Floor(f));
                        c.AdicionaPedidoDeVendaMySql(x.GetRange(i, 1000));
                    }
                    if (d >= 1000)
                    {
                        d -= 1000;
                    }
                }
                Mensagerias.Send("PedidoDeVendaMySql Import Ok");
                return "PedidoDeVendaMySql Import Ok";
            }
            return null;
        }
        internal static string MovimentoImport(Button btn)
        {
            var x = PadronizarColunasDados.Movimento(@"C:\Exports\Movimentos.txt");
            CRUD c = new CRUD();
            if (btn.Name == "btnExportarSqlServer")
            {
                NewMethod(x, out b, out f);
                var l = (from m in c.ListMovimentoSqlServer() where m.Data >= data select m).ToList();
                c.DeleteMovimentoSqlServer(l);
                int d = x.Count;
                for (int i = 0; i <= x.Count; i += 1000)
                {
                    if (d < 1000)
                    {
                        bgw.ReportProgress(100);
                        c.AdicionaMovimentoSqlServer(x.GetRange(i, d));
                    }
                    else
                    {
                        f += b;
                        bgw.ReportProgress((int)Math.Floor(f));
                        c.AdicionaMovimentoSqlServer(x.GetRange(i, 1000));
                    }
                    if (d >= 1000)
                    {
                        d -= 1000;
                    }
                }
                return "MovimentoSqlServer Import Ok";
            }
            else if (btn.Name == "btnExportarMySql")
            {
                NewMethod(x, out b, out f);
                var l = (from m in c.ListMovimentoMySql() where m.Data >= data select m).ToList();
                c.DeleteMovimentoMySql(l);
                int d = x.Count;
                for (int i = 0; i <= x.Count; i += 1000)
                {
                    if (d < 1000)
                    {
                        bgw.ReportProgress(100);
                        c.AdicionaMovimentoMySql(x.GetRange(i, d));
                    }
                    else
                    {
                        f += b;
                        bgw.ReportProgress((int)Math.Floor(f));
                        c.AdicionaMovimentoMySql(x.GetRange(i, 1000));
                    }
                    if (d >= 1000)
                    {
                        d -= 1000;
                    }
                }
                Mensagerias.Send("MovimentoMySql Import Ok");
                return "MovimentoMySql Import Ok";
            }
            return null;
        }
        internal static string ForaDeEstoqueImport(Button btn)
        {
            var x = PadronizarColunasDados.ForaDeEstoque(@"C:\Exports\ForaDeEstoque.txt");
            CRUD c = new CRUD();
            if (btn.Name == "btnExportarSqlServer")
            {
                NewMethod(x, out b, out f);
                c.TruncateForaDeEstoqueSqlServer();
                int d = x.Count;
                for (int i = 0; i <= x.Count; i += 1000)
                {
                    if (d < 1000)
                    {
                        bgw.ReportProgress(100);
                        c.AdicionaForaDeEstoqueSqlServer(x.GetRange(i, d));
                    }
                    else
                    {
                        f += b;
                        bgw.ReportProgress((int)Math.Floor(f));
                        c.AdicionaForaDeEstoqueSqlServer(x.GetRange(i, 1000));
                    }
                    if (d >= 1000)
                    {
                        d -= 1000;
                    }
                }
                return "ForaDeEstoqueSqlServer Import Ok";
            }
            else if (btn.Name == "btnExportarMySql")
            {
                NewMethod(x, out b, out f);
                //c.TruncateForaDeEstoqueMySql();
                DateTime data = hoje.AddYears(-2).AddDays(-hoje.Day + 1);
                var l = (from m in c.ListForaDeEstoqueMySql() where m.Data >= data select m).ToList();
                c.DeleteForaDeEstoqueMySql(l);


                int d = x.Count;
                for (int i = 0; i <= x.Count; i += 1000)
                {
                    if (d < 1000)
                    {
                        bgw.ReportProgress(100);
                        c.AdicionaForaDeEstoqueMySql(x.GetRange(i, d));
                    }
                    else
                    {
                        f += b;
                        bgw.ReportProgress((int)Math.Floor(f));
                        c.AdicionaForaDeEstoqueMySql(x.GetRange(i, 1000));
                    }
                    if (d >= 1000)
                    {
                        d -= 1000;
                    }
                }
                Mensagerias.Send("ForaDeEstoqueMySql Import Ok");
                return "ForaDeEstoqueMySql Import Ok";
            }
            return null;

        }
        internal static string DeTerceirosImport(Button btn)
        {
            var x = PadronizarColunasDados.DeTerceiros(@"C:\Exports\DeTerceiro.txt");
            CRUD c = new CRUD();
            if (btn.Name == "btnExportarSqlServer")
            {
                NewMethod(x, out b, out f);
                c.TruncateDeTerceiroSqlServer();
                int d = x.Count;
                for (int i = 0; i <= x.Count; i += 1000)
                {
                    if (d < 1000)
                    {
                        bgw.ReportProgress(100);
                        c.AdicionaDeTerceiroSqlServer(x.GetRange(i, d));
                    }
                    else
                    {
                        f += b;
                        bgw.ReportProgress((int)Math.Floor(f));
                        c.AdicionaDeTerceiroSqlServer(x.GetRange(i, 1000));
                    }
                    if (d >= 1000)
                    {
                        d -= 1000;
                    }
                }
                return "DeTerceiroSqlServer Import Ok";
            }
            else if (btn.Name == "btnExportarMySql")
            {

                NewMethod(x, out b, out f);
                //c.TruncateDeTerceiroMySql();
                DateTime data = hoje.AddYears(-4).AddDays(-hoje.Day + 1);
                var l = (from m in c.ListDeTerceiroMySql() where m.Data >= data select m).ToList();
                c.DeleteDeTerceiroMySql(l);
                int d = x.Count;
                for (int i = 0; i <= x.Count; i += 1000)
                {
                    if (d < 1000)
                    {
                        bgw.ReportProgress(100);
                        c.AdicionaDeTerceiroMySql(x.GetRange(i, d));
                    }
                    else
                    {
                        f += b;
                        bgw.ReportProgress((int)Math.Floor(f));
                        c.AdicionaDeTerceiroMySql(x.GetRange(i, 1000));
                    }
                    if (d >= 1000)
                    {
                        d -= 1000;
                    }
                }
                Mensagerias.Send("DeTerceiroMySql Import Ok");
                return "DeTerceiroMySql Import Ok";
            }
            return null;
        }
        internal static string ItensDeEstoqueImport(Button btn)
        {
            var x = PadronizarColunasDados.ItensDeEstoque();
            CRUD c = new CRUD();
            if (btn.Name == "btnExportarSqlServer")
            {
                NewMethod(x, out b, out f);
                c.TruncateItemDeEstoqueSqlServer();
                int d = x.Count;
                for (int i = 0; i <= x.Count; i += 1000)
                {
                    if (d < 1000)
                    {
                        bgw.ReportProgress(100);
                        c.AdicionaItemDeEstoqueSqlServer(x.GetRange(i, d));
                    }
                    else
                    {
                        f += b;
                        bgw.ReportProgress((int)Math.Floor(f));
                        c.AdicionaItemDeEstoqueSqlServer(x.GetRange(i, 1000));
                    }
                    if (d >= 1000)
                    {
                        d -= 1000;
                    }
                }
                return "ItensDeEstoqueSqlServer Import Ok";
            }
            else if (btn.Name == "btnExportarMySql")
            {
                NewMethod(x, out b, out f);
                c.TruncateItemDeEstoqueMySql();
                int d = x.Count;
                for (int i = 0; i <= x.Count; i += 1000)
                {
                    if (d < 1000)
                    {
                        bgw.ReportProgress(100);
                        c.AdicionaItemDeEstoqueMySql(x.GetRange(i, d));
                    }
                    else
                    {
                        f += b;
                        bgw.ReportProgress((int)Math.Floor(f));
                        c.AdicionaItemDeEstoqueMySql(x.GetRange(i, 1000));
                    }
                    if (d >= 1000)
                    {
                        d -= 1000;
                    }
                }
                Mensagerias.Send("ItensDeEstoqueMySql Import Ok");
                return "ItensDeEstoqueMySql Import Ok";
            }
            return null;
        }
        internal static string DepositoDeTerceiroImport(Button btn)
        {
            var x = PadronizarColunasDados.DepositoDeTerceiro();
            CRUD c = new CRUD();
            if (btn.Name == "btnExportarSqlServer")
            {
                NewMethod(x, out b, out f);
                c.TruncateDepositoDeTerceiroSqlServer();
                int d = x.Count;
                for (int i = 0; i <= x.Count; i += 1000)
                {
                    if (d < 1000)
                    {
                        bgw.ReportProgress(100);
                        c.AdicionaDepositoDeTerceiroSqlServer(x.GetRange(i, d));
                    }
                    else
                    {
                        f += b;
                        bgw.ReportProgress((int)Math.Floor(f));
                        c.AdicionaDepositoDeTerceiroSqlServer(x.GetRange(i, 1000));
                    }
                    if (d >= 1000)
                    {
                        d -= 1000;
                    }
                }
                
                return "DepositoDeTerceiroSqlServer Import Ok";
            }
            else if (btn.Name == "btnExportarMySql")
            {
                NewMethod(x, out b, out f);
                c.TruncateDepositoDeTerceiroMySql();
                int d = x.Count;
                for (int i = 0; i <= x.Count; i += 1000)
                {
                    if (d < 1000)
                    {
                        bgw.ReportProgress(100);
                        c.AdicionaDepositoDeTerceiroMySql(x.GetRange(i, d));
                    }
                    else
                    {
                        f += b;
                        bgw.ReportProgress((int)Math.Floor(f));
                        c.AdicionaDepositoDeTerceiroMySql(x.GetRange(i, 1000));
                    }
                    if (d >= 1000)
                    {
                        d -= 1000;
                    }
                }
                Mensagerias.Send("DepositoDeTerceiroMySql Import Ok");
                return "DepositoDeTerceiroMySql Import Ok";
            }
            return null;
        }
        internal static string SaldoDeTerceiroImport(Button btn)
        {
            CRUD c = new CRUD();
            //var u = c.ListaDepositoDeTerceiroMySql();
            var x = PadronizarColunasDados.SaldoDeTerceiro2();
            if (btn.Name == "btnExportarSqlServer")
            {
                NewMethod(x, out b, out f);
                c.TruncateSaldoDeTerceiroSqlServer();
                int d = x.Count;
                for (int i = 0; i <= x.Count; i += 1000)
                {
                    if (d < 1000)
                    {
                        bgw.ReportProgress(100);
                        c.AdicionaSaldoDeTerceiroSqlServer(x.GetRange(i, d));
                    }
                    else
                    {
                        f += b;
                        bgw.ReportProgress((int)Math.Floor(f));
                        c.AdicionaSaldoDeTerceiroSqlServer(x.GetRange(i, 1000));
                    }
                    if (d >= 1000)
                    {
                        d -= 1000;
                    }
                }
                return "SaldoDeTerceiroSqlServer Import Ok";
            }
            else if (btn.Name == "btnExportarMySql")
            {
                NewMethod(x, out b, out f);
                c.TruncateSaldoDeTerceiroMySql();
                int d = x.Count;
                for (int i = 0; i <= x.Count; i += 1000)
                {
                    if (d < 1000)
                    {
                        bgw.ReportProgress(100);
                        c.AdicionaSaldoDeTerceiroMySql(x.GetRange(i, d));
                    }
                    else
                    {
                        f += b;
                        bgw.ReportProgress((int)Math.Floor(f));
                        c.AdicionaSaldoDeTerceiroMySql(x.GetRange(i, 1000));
                    }
                    if (d >= 1000)
                    {
                        d -= 1000;
                    }
                }
                Mensagerias.Send("SaldoDeTerceiroMySql Import Ok");
                return "SaldoDeTerceiroMySql Import Ok";
            }
            return null;
        }
        internal static string OrdensDeProducao(Button btn)
        {
            var x = PadronizarColunasDados.OrdensDeProducao(@"C:\Exports\ConsultaOrdensDeProducao.txt");
            CRUD c = new CRUD();
            if (btn.Name == "btnExportarSqlServer")
            {
                NewMethod(x, out b, out f);
                c.TruncateOredensDeProducaoSqlServer();
                int d = x.Count;
                for (int i = 0; i <= x.Count; i += 1000)
                {
                    if (d < 1000)
                    {
                        bgw.ReportProgress(100);
                        c.AdicionaOrdensDeProducaoSqlServer(x.GetRange(i, d));
                    }
                    else
                    {
                        f += b;
                        bgw.ReportProgress((int)Math.Floor(f));
                        c.AdicionaOrdensDeProducaoSqlServer(x.GetRange(i, 1000));
                    }
                    if (d >= 1000)
                    {
                        d -= 1000;
                    }
                }
                return "OrdensDeProducaoSqlServer Import Ok";
            }
            else if (btn.Name == "btnExportarMySql")
            {
                NewMethod(x, out b, out f);
                c.TruncateOredensDeProducaoMySql();
                int d = x.Count;
                for (int i = 0; i <= x.Count; i += 1000)
                {
                    if (d < 1000)
                    {
                        bgw.ReportProgress(100);
                        c.AdicionaOrdensDeProducaoMySql(x.GetRange(i, d));
                    }
                    else
                    {
                        f += b;
                        bgw.ReportProgress((int)Math.Floor(f));
                        c.AdicionaOrdensDeProducaoMySql(x.GetRange(i, 1000));
                    }
                    if (d >= 1000)
                    {
                        d -= 1000;
                    }
                }
                Mensagerias.Send("OrdensDeProducaoMySql Import Ok");
                return "OrdensDeProducaoMySql Import Ok";
            }
            return null;
        }
        internal static string NFsDinamicaProduto(Button btn, DateTimePicker data)
        {
            var x = PadronizarColunasDados.NFsDinamicaProduto(@"C:\Exports\NotasFiscaisDinamicaProduto.txt");
            CRUD c = new CRUD();
            if (btn.Name == "btnExportarSqlServer")
            {

                NewMethod(x, out b, out f);
                c.TruncateNotasFiscaisDinamicaProdutoMSqlServer();
                int d = x.Count;
                for (int i = 0; i <= x.Count; i += 1000)
                {
                    if (d < 1000)
                    {
                        bgw.ReportProgress(100);
                        c.AdicionaNotasFiscaisDinamicaProdutoSqlServer(x.GetRange(i, d));
                    }
                    else
                    {
                        f += b;
                        bgw.ReportProgress((int)Math.Floor(f));
                        c.AdicionaNotasFiscaisDinamicaProdutoSqlServer(x.GetRange(i, 1000));
                    }
                    if (d >= 1000)
                    {
                        d -= 1000;
                    }
                }
                return "NotasFiscaisDinamicaProdutoSqlServer Import Ok";
            }
            else if (btn.Name == "btnExportarMySql")
            {
                NewMethod(x, out b, out f);
                var l = (from m in c.ListNotasFiscaisDinamicaProdutoMySql() where m.DatadeEmissao >= data.Value select m).ToList();
                c.DeleteNotasFiscaisDinamicaProdutoMySql(l);
                //c.TruncateNotasFiscaisDinamicaProdutoMySql();
                int d = x.Count;
                for (int i = 0; i <= x.Count; i += 1000)
                {
                    if (d < 1000)
                    {
                        c.AdicionaNotasFiscaisDinamicaProdutoMySql(x.GetRange(i, d));
                        bgw.ReportProgress(100);
                    }
                    else
                    {
                        f += b;
                        c.AdicionaNotasFiscaisDinamicaProdutoMySql(x.GetRange(i, 1000));
                        bgw.ReportProgress((int)Math.Floor(f));
                    }
                    if (d >= 1000)
                    {
                        d -= 1000;
                    }
                }
                Mensagerias.Send("NotasFiscaisDinamicaProdutoMySql Import Ok");
                return "NotasFiscaisDinamicaProdutoMySql Import Ok";
            }
            return null;
        }
        private static void NewMethod<T>(List<T> x, out decimal b, out decimal f)
        {
            bgw.ReportProgress(0);
            if (x.Count > 1000)
            {
                decimal s = x.Count / 1000M;
                b = 100M / s;
            }
            else
            {
                b = 100M;
            }
            f = 0M;
        }
        public static void AtualizaTudo()
        {
            bgw.ReportProgress(0);
            CRUD cd = new CRUD();
            List<Entidade.Atualizacao> le = new List<Entidade.Atualizacao>();
            List<string> ls = new List<string>();

            ls.Add(@"C:\Exports\ExportSaldo.txt");
            ls.Add(@"C:\Exports\ItensDeEstoque.txt");
            ls.Add(@"C:\Exports\PedidosDeCompras.txt");
            ls.Add(@"C:\Exports\PedidosDeVendas.txt");
            ls.Add(@"C:\Exports\Movimentos.txt");
            ls.Add(@"C:\Exports\ForaDeEstoque.txt");
            ls.Add(@"C:\Exports\DeTerceiro.txt");
            ls.Add(@"C:\Exports\DepositoDeTerceiro.txt");
            ls.Add(@"C:\Exports\MovimentosTotal.txt");
            ls.Add(@"C:\Exports\ConsultaOrdensDeProducao.txt");
            ls.Add(@"C:\Exports\NotasFiscaisDinamicaProduto.txt");
            ls.Add(@"C:\Exports\SaldoDeTerceiro.txt");


            //var t = Directory.GetFiles(@"C:\Exports\SaldosDeTerceiros").ToList();
            //var o = t.Where(p => p.StartsWith(@"C:\Exports\SaldosDeTerceiros\ExportSaldo")).ToList();

            //foreach (var item in o)
            //{
            //    le.Add(new Entidade.Atualizacao { Entidade = item.Remove(0, 35), Data = File.GetLastWriteTime(item) });
            //}
            foreach (var item in ls)
            {
                le.Add(new Entidade.Atualizacao { Entidade = item.Remove(0, 11), Data = File.GetLastWriteTime(item) });
            }

            bgw.ReportProgress(25);
            cd.TruncateAtualizaAtualizacaoMySql();
            //cd.TruncateAtualizaAtualizacaoSqlServer();

            bgw.ReportProgress(50);
            cd.AtualizaAtualizacaoMySql(le);
            bgw.ReportProgress(100);
            //cd.AtualizaAtualizacaoSqlServer(le);
        }

        //FULL
        internal static string MovimentoImportFULL(Button btn)
        {
            var x = PadronizarColunasDados.Movimento(@"C:\Exports\MovimentosFULL.txt");
            CRUD c = new CRUD();
            NewMethod(x, out b, out f);
            c.TruncateMovimentoMySql();
            int d = x.Count;
            for (int i = 0; i <= x.Count; i += 1000)
            {
                if (d < 1000)
                {
                    bgw.ReportProgress(100);
                    c.AdicionaMovimentoMySql(x.GetRange(i, d));
                }
                else
                {
                    
                    f += b;
                    bgw.ReportProgress((int)Math.Floor(f));
                    c.AdicionaMovimentoMySql(x.GetRange(i, 1000));
                }
                if (d >= 1000)
                {
                    d -= 1000;
                }
            }
            return "Movimento -FULL- MySql Import Ok";
        }
        internal static string ForaDeEstoqueImportFULL(Button btn)
        {
            var x = PadronizarColunasDados.ForaDeEstoque(@"C:\Exports\ForaDeEstoqueFULL.txt");
            CRUD c = new CRUD();
            NewMethod(x, out b, out f);
            c.TruncateForaDeEstoqueMySql();
            int d = x.Count;
            for (int i = 0; i <= x.Count; i += 1000)
            {
                if (d < 1000)
                {
                    bgw.ReportProgress(100);
                    c.AdicionaForaDeEstoqueMySql(x.GetRange(i, d));
                }
                else
                {
                    f += b;
                    bgw.ReportProgress((int)Math.Floor(f));
                    c.AdicionaForaDeEstoqueMySql(x.GetRange(i, 1000));
                }
                if (d >= 1000)
                {
                    d -= 1000;
                }
            }
            return "ForaDeEstoque -FULL- MySql Import Ok";
        }
        internal static string NFsDinamicaProdutoFULL(Button btn, DateTimePicker dtp)
        {
            var x = PadronizarColunasDados.NFsDinamicaProduto(@"C:\Exports\NotasFiscaisDinamicaProdutoFULL.txt");
            CRUD c = new CRUD();
            NewMethod(x, out b, out f);
            c.TruncateNotasFiscaisDinamicaProdutoMySql();
            int d = x.Count;
            for (int i = 0; i <= x.Count; i += 1000)
            {
                if (d < 1000)
                {
                    bgw.ReportProgress(100);
                    c.AdicionaNotasFiscaisDinamicaProdutoMySql(x.GetRange(i, d));
                }
                else
                {
                    f += b;
                    bgw.ReportProgress((int)Math.Floor(f));
                    c.AdicionaNotasFiscaisDinamicaProdutoMySql(x.GetRange(i, 1000));
                }
                if (d >= 1000)
                {
                    d -= 1000;
                }
            }
            return "NotasFiscaisDinamicaProduto -FULL- MySql Import Ok";
        }
        internal static string OrdensDeProducaoFULL(Button btn)
        {
            var x = PadronizarColunasDados.OrdensDeProducao(@"C:\Exports\ConsultaOrdensDeProducaoFULL.txt");
            CRUD c = new CRUD();
            NewMethod(x, out b, out f);
            c.TruncateOredensDeProducaoMySql();
            int d = x.Count;
            for (int i = 0; i <= x.Count; i += 1000)
            {
                if (d < 1000)
                {
                    bgw.ReportProgress(100);
                    c.AdicionaOrdensDeProducaoMySql(x.GetRange(i, d));
                }
                else
                {
                    f += b;
                    bgw.ReportProgress((int)Math.Floor(f));
                    c.AdicionaOrdensDeProducaoMySql(x.GetRange(i, 1000));
                }
                if (d >= 1000)
                {
                    d -= 1000;
                }
            }
            return "OrdensDeProducao -FULL- MySql Import Ok";
        }
        internal static string PedidoCompraImportFULL(Button btn)
        {
            var x = PadronizarColunasDados.PedidoDeCompra(@"C:\Exports\PedidosDeComprasFULL.txt");
            CRUD c = new CRUD();
            NewMethod(x, out b, out f);
            c.TruncatePedidoDeCompraMySql();
            int d = x.Count;
            for (int i = 0; i <= x.Count; i += 1000)
            {
                if (d < 1000)
                {
                    bgw.ReportProgress(100);
                    c.AdicionaPedidoDeCompraMySql(x.GetRange(i, d));
                }
                else
                {
                    f += b;
                    bgw.ReportProgress((int)Math.Floor(f));
                    c.AdicionaPedidoDeCompraMySql(x.GetRange(i, 1000));
                }
                if (d >= 1000)
                {
                    d -= 1000;
                }
            }
            return "PedidoDeCompra -FULL- MySql Import Ok";
        }
        internal static string DeTerceirosImportFULL(Button btn)
        {
            var x = PadronizarColunasDados.DeTerceiros(@"C:\Exports\DeTerceiroFULL.txt");
            CRUD c = new CRUD();
            NewMethod(x, out b, out f);
            c.TruncateDeTerceiroMySql();
            int d = x.Count;
            for (int i = 0; i <= x.Count; i += 1000)
            {
                if (d < 1000)
                {
                    bgw.ReportProgress(100);
                    c.AdicionaDeTerceiroMySql(x.GetRange(i, d));
                }
                else
                {
                    f += b;
                    bgw.ReportProgress((int)Math.Floor(f));
                    c.AdicionaDeTerceiroMySql(x.GetRange(i, 1000));
                }
                if (d >= 1000)
                {
                    d -= 1000;
                }
            }
            return "DeTerceiro -FULL- MySql Import Ok";
        }

    }
}