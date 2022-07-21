using ImportExportERP.Classes;
using ImportExportERP.Entidade;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ImportExportERP
{
    public class ControllerERP_Pronto
    {

        internal static string Saldo()
        {
            while (true)
            {
                try
                {
                    AreaTranferencia("ExportSaldo.txt");
                    ERP_Pronto.Login();
                    ERP_Pronto.BuscarJanela("EPSDPRB1", "Consultar Saldos de Estoque");
                    ERP_Pronto.ConsultarSaldosDeEstoque();
                    ERP_Pronto.ExportarDadosFull(@"C:\Exports", "ExportSaldo.txt", 1000);
                    ERP_Pronto.Subescrever();
                    ERP_Pronto.FecharABC71();
                    Mensagerias.Send($"Export Saldo Ok\n---------\n");
                    return "Export Saldo Ok";
                }
                catch (Exception)
                {
                }
            }
        }

        internal static string PedidoCompra()
        {
            while (true)
            {
                try
                {
                    AreaTranferencia("PedidosDeCompras.txt");
                    ERP_Pronto.Login();
                    ERP_Pronto.BuscarJanela("SUPDBR", "Consultar Pedidos de Compra");
                    ERP_Pronto.ConsultarPedidosDeCompra();
                    ERP_Pronto.ExportarDadosFull(@"C:\Exports", "PedidosDeCompras.txt", 1000);
                    ERP_Pronto.Subescrever();
                    ERP_Pronto.FecharABC71();

                    var texto = File.ReadAllText(@"C:\Exports\PedidosDeCompras.txt", Encoding.Default);
                    var x = texto.Replace("  ", "").Replace("\r2\"", "\"").Replace("\n2\"", "\"").Replace("\t2\"", "\"");
                    File.WriteAllText(@"C:\Exports\PedidosDeCompras.txt", x, Encoding.Default);

                    Mensagerias.Send($"Export PedidoCompra Ok\n---------\n");
                    return "Export PedidoCompra Ok";
                }
                catch (Exception)
                {
                }
            }
        }

        internal static string MovimentoTotal()
        {
            while (true)
            {
                try
                {
                    AreaTranferencia("MovimentosTotal.txt");
                    ERP_Pronto.Login();
                    ERP_Pronto.BuscarJanela("EPMCM1BR", "Consultar Movimentos de Estoque - Quantitativos");
                    ERP_Pronto.Movimentos("TOTAL");
                    ERP_Pronto.ExportarDadosFull(@"C:\Exports", "MovimentosTotal.txt", 1000);
                    ERP_Pronto.Subescrever();
                    ERP_Pronto.FecharABC71();
                    Mensagerias.Send($"Export MovimentoTotal Ok\n---------\n");
                    return "Export Movimento Total Ok";
                }
                catch (Exception)
                {
                }
            }
        }

        internal static string NFsDinamicaProduto(DateTimePicker dtp)
        {
            while (true)
            {
                try
                {
                    AreaTranferencia("NotasFiscaisDinamicaProduto.txt");
                    ERP_Pronto.Login();
                    ERP_Pronto.BuscarJanela("NFDEVGBR", "Consultar Notas Fiscais - Detalhes - Consulta Dinâmica");
                    ERP_Pronto.NFsDinamicaProduto(dtp);
                    ERP_Pronto.ExportarDadosFull(@"C:\Exports", "NotasFiscaisDinamicaProduto.txt", 1000);
                    ERP_Pronto.Subescrever();
                    ERP_Pronto.FecharABC71();
                    Mensagerias.Send($"Export NFsDinamicaProduto Ok\n---------\n");
                    return "Export NotasFiscaisDinamicaProduto Ok";
                }
                catch (Exception)
                {
                }
            }
        }

        internal static string OrdensDeProducao()
        {
            while (true)
            {
                try
                {
                    AreaTranferencia("ConsultaOrdensDeProducao.txt");
                    ERP_Pronto.Login();
                    ERP_Pronto.BuscarJanela("MOPPBR", "Consultar Consulta de Ordens de Produção");
                    ERP_Pronto.ConsultarOrdensDeProducao();
                    ERP_Pronto.ExportarDadosFull(@"C:\Exports", "ConsultaOrdensDeProducao.txt", 1000);
                    ERP_Pronto.Subescrever();
                    ERP_Pronto.FecharABC71();
                    Mensagerias.Send($"Export OrdensDeProducao Ok\n---------\n");
                    return "Export OrdensDeProducao Ok";
                }
                catch (Exception)
                {
                }
            }
        }

        internal static string PedidoVenda()
        {
            while (true)
            {
                try
                {
                    AreaTranferencia("PedidosDeVendas.txt");
                    ERP_Pronto.Login();
                    ERP_Pronto.BuscarJanela("PEDBR", "Consultar Pedidos não Faturados");
                    ERP_Pronto.CarregarPVs();
                    ERP_Pronto.ExportarDadosFull(@"C:\Exports", "PedidosDeVendas.txt", 1000);
                    ERP_Pronto.Subescrever();
                    ERP_Pronto.FecharABC71();
                    Mensagerias.Send($"Export PedidoVenda Ok\n---------\n");
                    return "Export PedidoVenda Ok";
                }
                catch (Exception)
                {
                }
            }
        }

        internal static string DepositoDeTerceiro()
        {
            while (true)
            {
                try
                {
                    AreaTranferencia("DepositoDeTerceiro.txt");
                    ERP_Pronto.Login();
                    ERP_Pronto.BuscarJanela("FILIBR", "Consultar Dados das Filiais");
                    ERP_Pronto.ConsultarDadosDasFiliais();
                    ERP_Pronto.ConsultarFilial();
                    ERP_Pronto.ConsultarEstabelecimento();
                    ERP_Pronto.ExportarDadosFull(@"C:\Exports", "DepositoDeTerceiro.txt", 1000);
                    ERP_Pronto.Subescrever();
                    ERP_Pronto.FecharABC71();
                    Mensagerias.Send($"Export DepositoDeTerceiro Ok\n---------\n");
                    return "Export DepositoDeTerceiro Ok";
                }
                catch (Exception)
                {
                }
            }
        }

        internal static string Movimento()
        {
            while (true)
            {
                try
                {
                    AreaTranferencia("Movimentos.txt");
                    ERP_Pronto.Login();
                    ERP_Pronto.BuscarJanela("EPMCM1BR", "Consultar Movimentos de Estoque - Quantitativos");
                    ERP_Pronto.Movimentos("PARCIAL");
                    ERP_Pronto.ExportarDadosFull(@"C:\Exports", "Movimentos.txt", 1000);
                    ERP_Pronto.Subescrever();
                    ERP_Pronto.FecharABC71();
                    Mensagerias.Send($"Export Movimento Ok\n---------\n");
                    return "Export Movimento Ok";
                }
                catch (Exception)
                {
                }
            }
        }

        internal static string ForaDeEstoque()
        {
            while (true)
            {
                try
                {
                    AreaTranferencia("ForaDeEstoque.txt");
                    ERP_Pronto.Login();
                    ERP_Pronto.BuscarJanela("EPFE4BR", "Consultar Fora de Estoque");
                    ERP_Pronto.CarregarForaEstoque_DeTerceiro("Consultar Fora de Estoque");
                    ERP_Pronto.ExportarDadosFull(@"C:\Exports", "ForaDeEstoque.txt", 1000);
                    ERP_Pronto.Subescrever();
                    ERP_Pronto.FecharABC71();
                    Mensagerias.Send($"Export ForaDeEstoque Ok\n---------\n");
                    return "Export ForaDeEstoque Ok";
                }
                catch (Exception)
                {
                }
            }
        }

        internal static string DeTerceiros()
        {
            while (true)
            {
                try
                {
                    AreaTranferencia("DeTerceiro.txt");
                    ERP_Pronto.Login();
                    ERP_Pronto.BuscarJanela("EPFE7BR", "Consultar Mercadorias de Terceiros em Nosso Poder");
                    ERP_Pronto.CarregarForaEstoque_DeTerceiro("Consultar Mercadorias de Terceiros em Nosso Poder");
                    ERP_Pronto.ExportarDadosFull(@"C:\Exports", "DeTerceiro.txt", 1000);
                    ERP_Pronto.Subescrever();
                    ERP_Pronto.FecharABC71();
                    Mensagerias.Send($"Export DeTerceiros Ok\n---------\n");
                    return "Export DeTerceiros Ok";
                }
                catch (Exception)
                {
                }
            }
        }

        internal static string ItensDeEstoque()
        {
            while (true)
            {
                try
                {
                    AreaTranferencia("ItensDeEstoque.txt");
                    ERP_Pronto.Login();
                    ERP_Pronto.BuscarJanela("ESTQBR", "Consultar Itens de Estoque");
                    ERP_Pronto.ItensDeEstoque();
                    ERP_Pronto.ExportarDadosFull(@"C:\Exports", "ItensDeEstoque.txt", 1000);
                    ERP_Pronto.Subescrever();
                    ERP_Pronto.FecharABC71();
                    Mensagerias.Send($"Export ItensDeEstoque Ok\n---------\n");
                    return "Export ItensDeEstoque Ok";
                }
                catch (Exception)
                {
                }
            }
        }

        internal static string SaldoDeTerceiro()
        {
            while (true)
            {
                try
                {
                    AreaTranferencia("SaldoDeTerceiro.txt");
                    ERP_Pronto.Login();
                    ERP_Pronto.BuscarJanela("EPSDPRB1", "Consultar Saldos de Estoque");

                    ERP_Pronto.SelecionaEstabelecimentoDeposito();
                    ERP_Pronto.ConsultarSaldosDeEstoque();

                    ERP_Pronto.ExportarDadosFull(@"C:\Exports", "SaldoDeTerceiro.txt", 1000);
                    ERP_Pronto.Subescrever();
                    ERP_Pronto.FecharABC71();
                    Mensagerias.Send($"Export SaldoDeTerceiro Ok\n---------\n");
                    return "Export SaldoDeTerceiro Ok";
                }
                catch (Exception)
                {
                }
            }
        }

        public static bool VerificarDownload(int it)
        {
            Stream st = File.Open($@"C:\Exports\SaldosDeTerceiros\ExportSaldo{it}.txt", FileMode.Open);
            StreamReader sr = new StreamReader(st, System.Text.Encoding.Default);
            sr.ReadLine();
            var line = sr.ReadLine();
            var lin = line.Split('\t');
            var li = Convert.ToInt32(lin[34]);
            if (li == it)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static void AreaTranferencia(string arquivo)
        {
            Thread.Sleep(1000);
            Clipboard.Clear();
            Thread.Sleep(1000);
            Clipboard.SetText(arquivo);
            Thread.Sleep(1000);
        }

        static bool SePastaEstaAcessivel()
        {


            DateTime StartTime = DateTime.Now;

            Process.Start("Y:\\");
            //Thread.Sleep(2000);
            try
            {
                using (Process myProcess = new Process())
                {
                    //myProcess.StartInfo.UseShellExecute = false;
                    // You can start any process, HelloWorld is a do-nothing example.
                    myProcess.StartInfo.FileName = @"Y:\Check\Check.txt";
                    myProcess.StartInfo.CreateNoWindow = true;
                    myProcess.Start();
                    // This code assumes the process you are starting will terminate itself.
                    // Given that is is started without a window so you cannot terminate it
                    // on the desktop, it must terminate itself or you can do it programmatically
                    // from this application using the Kill method.
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            bool b = false;

            for (int i = 0; i < 10; i++)
            {
                Process[] process0 = Process.GetProcessesByName("notepad");
                foreach (Process p in process0)
                {

                    if (p.MainWindowTitle == "Check.txt - Bloco de Notas")
                    {
                        b = true;
                        //Thread.Sleep(500);
                        p.Kill();
                        var s = Process.GetProcessesByName("explorer").ToList();
                        s.ForEach(pi => pi.Kill());
                        return true;

                    }
                }
                if (b)
                {
                    break;
                }
                Thread.Sleep(500);
            }

            if (b == false)
            {
                return false;
            }
            return false;
        }

        /// <summary>
        /// Sincroniza os ultimos exports
        /// </summary>
        public static void SincronizaFiles()
        {
            for (int i = 1; i <= 3; i++)
            {
                if (i == 3)
                {
                    Mensagerias.Send("Não foi possível Sincronizar os arquivos de Exports\n");
                    MessageBox.Show("Não foi possível Sincronizar os arquivos de Exports", "Sincroniza Files");
                    return;
                }
                bool open = SePastaEstaAcessivel();
                if (open)
                {
                    break;
                }
            }
            //
            bool z = false, y = false;
            while (true)
            {
                try
                {
                    z = Directory.Exists(@"Z:\");
                    y = Directory.Exists(@"Y:\");
                    if (z & y)
                    {
                        Console.WriteLine("Unidades OK");
                        break;
                    }
                    else
                    {
                        if (MessageBox.Show($@"ERRO ao abrir unidades para fazer BackUps:\nZ:\Cid\ ou Y:\Exports\ \n\n
                            Z:\\ {z} \n
                            Y:\\ {y}", "ATENÇÃO", MessageBoxButtons.RetryCancel) == DialogResult.Retry)
                        {
                            Mensagerias.Send($@"ERRO ao abrir unidades para fazer BackUps:\nZ:\Cid\ ou Y:\Exports\ \n\n
                            Z:\\ {z} \n
                            Y:\\ {y}");
                        }
                        else
                        {
                            Mensagerias.Send("Repare as unidades e use o botao 'Sincroniza Files'");
                            MessageBox.Show("Repare as unidades e use o botao 'Sincroniza Files'", "ATENÇÃO");
                            break;
                        }
                    }
                }
                catch (Exception)
                {
                }
            }
            //


            var local = @"C:\Exports\";
            var outro = @"Y:\Exports\";
            var publico = @"Z:\Cid\";
            List<ListFiles> lf;

            List<string> l = new List<string> { "ConsultaOrdensDeProducao.txt", "DepositoDeTerceiro.txt", "DeTerceiro.txt", "ExportSaldo.txt",
                "ForaDeEstoque.txt", "ItensDeEstoque.txt", "Movimentos.txt", "MovimentosTotal.txt", "NotasFiscaisDinamicaProduto.txt", "PedidosDeCompras.txt",
                "PedidosDeVendas.txt", "PedidosDeVendasEtiquetas.txt", "SaldoDeTerceiro.txt" };


            foreach (var item in l)
            {
                var L = File.GetLastWriteTime(local + item);
                var o = File.GetLastWriteTime(outro + item);
                var p = File.GetLastWriteTime(publico + item);
                lf = new List<ListFiles>();
                lf.Add(new ListFiles { date = L, file = local + item });
                lf.Add(new ListFiles { date = o, file = outro + item });
                lf.Add(new ListFiles { date = p, file = publico + item });
                var lf2 = lf.OrderByDescending(k => k.date).ToList();
                for (int i = 1; i <= 2; i++)
                {
                    if (lf2[0].date == lf2[i].date)
                    {
                        Mensagerias.Send("Sincrinizado! " + lf2[i].file + "\n");
                        Console.WriteLine("Sincrinizado! " + lf2[i].file);
                    }
                    else
                    {
                        Mensagerias.Send("Sicronizando... " + lf2[i].file + "\n");
                        Console.WriteLine("Sicronizando... " + lf2[i].file);
                        File.Copy(lf2[0].file, lf2[i].file, true);
                    }
                }
            }
        }

        //FULL
        internal static string NFsDinamicaProdutoFULL(DateTimePicker dtp)
        {
            throw new NotImplementedException();
        }

        internal static string OrdensDeProducaoFULL()
        {
            throw new NotImplementedException();
        }

        internal static string PedidoCompraFULL()
        {
            throw new NotImplementedException();
        }

        internal static string DeTerceirosFULL()
        {
            throw new NotImplementedException();
        }

        internal static string ForaDeEstoqueFULL()
        {
            throw new NotImplementedException();
        }

        internal static string MovimentoFULL()
        {
            throw new NotImplementedException();
        }

    }
}