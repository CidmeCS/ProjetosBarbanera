using AutoIt;
using Estoque.DAO;
using Estoque.Entidade;
using Estoque.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Estoque.Classes.ERP

{
    internal class ControllerERP_Pronto
    {
        internal static void Saldo()
        {
            ERP_Pronto.Login();
            ERP_Pronto.BuscarJanela("EPSDPRB1", "Consultar Saldos de Estoque");
            ERP_Pronto.ConsultarSaldosDeEstoque();
            ERP_Pronto.ExportarDadosFull(@"C:\Exports", "ExportSaldo.txt", 1000);
            ERP_Pronto.Subescrever(20000);
            ERP_Pronto.FecharABC71();
            var x = Directory.Exists(@"Z:\");
            if (x)
            {
                File.Copy(@"C:\Exports\ExportSaldo.txt", @"Z:\Cid\ExportSaldo.txt", true);
            }
        }

        internal static void PedidoCompra()
        {
            ERP_Pronto.Login();
            ERP_Pronto.BuscarJanela("SUPDBR", "Consultar Pedidos de Compra");
            ERP_Pronto.ConsultarPedidosDeCompra();
            ERP_Pronto.ExportarDadosFull(@"C:\Exports", "PedidosDeCompras.txt", 1000);
            ERP_Pronto.Subescrever(5000);
            ERP_Pronto.FecharABC71();
            var x = Directory.Exists(@"Z:\");
            if (x)
            {
                File.Copy(@"C:\Exports\PedidosDeCompras.txt", @"Z:\Cid\PedidosDeCompras.txt", true);
            }
        }

        internal static void DepositoDeTerceiro()
        {
            ERP_Pronto.Login();
            ERP_Pronto.BuscarJanela("FILIBR", "Consultar Dados das Filiais");
            ERP_Pronto.ConsultarDadosDasFiliais();
            ERP_Pronto.ConsultarFilial();
            ERP_Pronto.ConsultarEstabelecimento();
            ERP_Pronto.ExportarDadosFull(@"C:\Exports", "DepositoDeTerceiro.txt", 1000);
            ERP_Pronto.Subescrever(5000);
            ERP_Pronto.FecharABC71();
        }

        internal static void ExcluirItens(List<string> produtos, string filePath)
        {
            ERP_Pronto.Login();
            ERP_Pronto.BuscarJanela("ESTQBR", "Consultar Itens de Estoque");


            foreach (var item in produtos)
            {
                ERP_Pronto.AguardaJanelaAtivar("Consultar Itens de Estoque", 60);
                ERP_Pronto.ExcluirItens(item);
                ExcluiDadosDoExcel.ExcluiUmaCelula(item, filePath);
            }
            ERP_Pronto.FecharABC71();
        }

        internal static void AlteraDescricaoManual(List<string> l, Label lbl)
        {
            ERP_Pronto.Login();
            ERP_Pronto.BuscarJanela("ESTQBR", "Consultar Itens de Estoque");
            ERP_Pronto.PreparaJanelaItensDeEstoque();
            ERP_Pronto.AlteraDescricaoManual(l, lbl);
        }

        internal static void CorrigeTubo(List<SaldoT> listT)
        {
            ERP_Pronto.Login();
            ERP_Pronto.BuscarJanela("ESTQBR", "Consultar Itens de Estoque");
            ERP_Pronto.PreparaJanelaItensDeEstoque();
            ERP_Pronto.CorrigeTubo(listT);
            ERP_Pronto.FecharABC71();
        }

        internal static void SaldoDeTerceiro(List<int> li)
        {

            Directory.CreateDirectory(@"C:\Exports\SaldosDeTerceiros");

            ERP_Pronto.Login();
            ERP_Pronto.BuscarJanela("EPSDPRB1", "Consultar Saldos de Estoque");

            int ig = 1;
            int de = 0;
            int es = 0;
            foreach (var it in li)
            {
                de = it - ig;
                ig = it;
                ERP_Pronto.ConsultarSaldosDeEstoqueDeTerceiro(es, de);
                ERP_Pronto.ExportarDadosFull(@"C:\Exports\SaldosDeTerceiros", $"ExportSaldo{it}.txt", 1000);
                ERP_Pronto.Subescrever(5000);
                ERP_Pronto.FecharDownloads();
                var v = VerificarDownload(it);
                if (v == false)
                {
                    MessageBox.Show($"Refazer o export de saldo de terceiro: ExportSaldo{it}", "Refazer Export Saldo de Terceiro");
                    break;
                }
                es++;
            }
            ERP_Pronto.FecharABC71();
        }

       

        internal static void ValorizarCustoMedio(List<SaldoMensal.ListaSaldoMensal> lista)
        {
            ERP_Pronto.Login();
            ERP_Pronto.BuscarJanela("EPILBR", "Consultar Controle de Inventários");
            var database = ERP_Pronto.GerarNumeroDeInventario();
            ERP_Pronto.LançarItens(lista);
            ERP_Pronto.JanelaEmFoco("ERP Pronto - ABC71");
            ERP_Pronto.BuscarJanela("EP840PR", "Processo EP840 - Inventário de Estoque");
            ERP_Pronto.EfetivarInventario(database);
            ERP_Pronto.FecharABC71();
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

        internal static void AlterarLivre17(List<Livre17> ll)
        {
            ERP_Pronto.Login();
            ERP_Pronto.BuscarJanela("ESTQBR", "Consultar Itens de Estoque");
            ERP_Pronto.AguardaJanelaAtivar("Consultar Itens de Estoque", 60);
            ERP_Pronto.PreparaJanelaItensDeEstoque();


            Crud c = new Crud();
            foreach (var item in ll)
            {
                ERP_Pronto.AlterarLivre17(item.Produto, item.Livre17New);
                c.AlterarLivre17Saldo(item.Produto, item.Livre17New);
                c.AlterarLivre17Etiqueta(item.Produto, item.Livre17New);
            }
            ERP_Pronto.FecharABC71();
        }

        internal static void PedidoVenda()
        {
            ERP_Pronto.Login();
            ERP_Pronto.BuscarJanela("PEDBR", "Consultar Pedidos não Faturados");
            ERP_Pronto.CarregarPVs();
            ERP_Pronto.ExportarDadosFull(@"C:\Exports", "PedidosDeVendas.txt", 1000);
            ERP_Pronto.Subescrever(5000);
            ERP_Pronto.FecharABC71();
            var x = Directory.Exists(@"Z:\");
            if (x)
            {
                File.Copy(@"C:\Exports\PedidosDeVendas.txt", @"Z:\Cid\PedidosDeVendas.txt", true);
            }
        }

        internal static void Movimento()
        {
            ERP_Pronto.Login();
            ERP_Pronto.BuscarJanela("EPMCM1BR", "Consultar Movimentos de Estoque - Quantitativos");
            ERP_Pronto.Movimentos();
            ERP_Pronto.ExportarDadosFull(@"C:\Exports", "Movimentos.txt", 1000);
            ERP_Pronto.Subescrever(20000);
            ERP_Pronto.FecharABC71();
            var x = Directory.Exists(@"Z:\");
            if (x)
            {
                File.Copy(@"C:\Exports\Movimentos.txt", @"Z:\Cid\Movimentos.txt", true);
            }
        }

        internal static void ForaDeEstoque()
        {
            ERP_Pronto.Login();
            ERP_Pronto.BuscarJanela("EPFE4BR", "Consultar Fora de Estoque");
            ERP_Pronto.CarregarForaEstoque_DeTerceiro("Consultar Fora de Estoque");
            ERP_Pronto.ExportarDadosFull(@"C:\Exports", "ForaDeEstoque.txt", 1000);
            ERP_Pronto.Subescrever(10000);
            ERP_Pronto.FecharABC71();
            var x = Directory.Exists(@"Z:\");
            if (x)
            {
                File.Copy(@"C:\Exports\ForaDeEstoque.txt", @"Z:\Cid\ForaDeEstoque.txt", true);
            }
        }

        internal static void AplicaTipoItemSped(List<ItensDeEstoque> TipoItemSped)
        {
            while (true)
            {
                try
                {
                    ERP_Pronto.FecharABC71();
                    ERP_Pronto.Login();
                    ERP_Pronto.BuscarJanela("ESTQBR", "Consultar Itens de Estoque");

                    ERP_Pronto.AplicaTipoItemSped(TipoItemSped);
                    ERP_Pronto.FecharABC71();
                    break;

                }
                catch (Exception)
                {
                }

            }
        }

        internal static void ZerarSaldos(List<PedidoNFs> listaMatarSaldo)
        {
            while (true)
            {
                try
                {
                    ERP_Pronto.Login();
                    ERP_Pronto.BuscarJanela("SUBX1BR", "Baixa de Pedido de Compra");
                    ERP_Pronto.ZerarSaldos(listaMatarSaldo);
                    ERP_Pronto.FecharABC71();
                    MessageBox.Show("Lista de Saldos a Zerar Concluído", "Tarefa Concluída");
                    break;

                }
                catch (Exception)
                {
                }
            }
        }

        internal static void ItensDeEstoque()
        {

            ERP_Pronto.Login();
            ERP_Pronto.BuscarJanela("ESTQBR", "Consultar Itens de Estoque");
            ERP_Pronto.ItensDeEstoque();
            ERP_Pronto.ExportarDadosFull(@"C:\Exports", "ItensDeEstoque.txt", 1000);
            ERP_Pronto.Subescrever(0);
            MessageBox.Show("Aguarde O download se concluído");
            ERP_Pronto.FecharABC71();
            var x = Directory.Exists(@"Z:\");
            if (x)
            {
                File.Copy(@"C:\Exports\ItensDeEstoque.txt", @"Z:\Cid\ItensDeEstoque.txt", true);
            }
        }

        internal static void DeTerceiro()
        {
            ERP_Pronto.Login();
            ERP_Pronto.BuscarJanela("EPFE7BR", "Consultar Mercadorias de Terceiros em Nosso Poder");
            ERP_Pronto.CarregarForaEstoque_DeTerceiro("Consultar Mercadorias de Terceiros em Nosso Poder");
            ERP_Pronto.ExportarDadosFull(@"C:\Exports", "DeTerceiro.txt", 1000);
            ERP_Pronto.Subescrever(10000);
            ERP_Pronto.FecharABC71();
            var x = Directory.Exists(@"Z:\");
            if (x)
            {
                File.Copy(@"C:\Exports\DeTerceiro.txt", @"Z:\Cid\DeTerceiro.txt", true);
            }
        }

        internal static void LimparPrateleira(List<string> l)
        {
            ERP_Pronto.Login();
            ERP_Pronto.BuscarJanela("ESTQBR", "Consultar Itens de Estoque");


            foreach (var item in l)
            {
                ERP_Pronto.AguardaJanelaAtivar("Consultar Itens de Estoque", 60);
                ERP_Pronto.EliminarPrateleira(item);
            }
            ERP_Pronto.FecharABC71();
        }

        internal static void AlterarPrateleira(Dictionary<string, string> dic)
        {
            ERP_Pronto.Login();
            ERP_Pronto.BuscarJanela("ESTQBR", "Consultar Itens de Estoque");


            foreach (var item in dic)
            {
                ERP_Pronto.AguardaJanelaAtivar("Consultar Itens de Estoque", 60);
                ERP_Pronto.AlterarPrateleira(item.Key, item.Value);
            }
            ERP_Pronto.FecharABC71();
        }
        internal static void AlterarPrateleira(List<Prateleiras> lp)
        {
            ERP_Pronto.Login();
            ERP_Pronto.BuscarJanela("ESTQBR", "Consultar Itens de Estoque");
                ERP_Pronto.AguardaJanelaAtivar("Consultar Itens de Estoque", 60);
                ERP_Pronto.PreparaJanelaItensDeEstoque();


            Crud c = new Crud();
            foreach (var item in lp)
            {
                ERP_Pronto.AlterarPrateleira(item.Produto, item.PrateleiraNova);
                c.AlterarPrateleiraSaldo(item.Produto, item.PrateleiraNova);
                c.AlterarPrateleiraEtiqueta(item.Produto, item.PrateleiraNova);
            }
            ERP_Pronto.FecharABC71();
        }

        internal static void APlicarAcertos(List<Acerto> acertos)
        {
            ERP_Pronto.Login();
            ERP_Pronto.BuscarJanela("EPMVACBR", "Consultar Movimentos de Estoque - Acertos");
            ERP_Pronto.AguardaJanelaAtivar("Consultar Movimentos de Estoque - Acertos", 60);
            ERP_Pronto.btnIncluir();
            ERP_Pronto.AguardaJanelaAtivar("Incluir Acertos de Estoque", 60);
            acertos.OrderBy(p => p.TM);
            foreach (var a in acertos)
            {
                ERP_Pronto.AcertarQuantidade(a);
            }
            ERP_Pronto.FecharABC71();
        }

        internal static void RequisitarApontamentos(List<Apontamento> la)
        {
            try
            {
                ERP_Pronto.FecharABC71();
                //ERP_Pronto.LoginTeste();
                ERP_Pronto.Login();
                ERP_Pronto.BuscarJanela("MOAPOPED", "Apontamento de Ordem de Produção");
                ERP_Pronto.PreparaJanela();
                ERP_Pronto.RequisitarApontamentos(la);
                //ERP_Pronto.FecharABC71();
            }
            catch (Exception e)
            {
                if (MessageBox.Show(e.Message + "... Deseja Continuar?", "ERRO", MessageBoxButtons.YesNo) == DialogResult.No)
                {

                }
            }
        }

        internal static void AlteraGrupo(Dictionary<string, string> d)
        {
            try
            {
                ERP_Pronto.FecharABC71();
                //ERP_Pronto.LoginTeste();
                ERP_Pronto.Login();
                ERP_Pronto.BuscarJanela("ESTQBR", "Consultar Itens de Estoque");
                ERP_Pronto.PreparaJanelaItensDeEstoque();
                ERP_Pronto.AlteraGrupo(d);
                ERP_Pronto.FecharABC71();
            }
            catch (Exception e)
            {
                if (MessageBox.Show(e.Message + "... Deseja Continuar?", "ERRO", MessageBoxButtons.YesNo) == DialogResult.No)
                {

                }
            }
        }

        internal static void EstornarApontamentos(List<Apontamento> la, DateTime mesFechado)
        {
            while (true)
            {
                try
                {
                    ERP_Pronto.FecharABC71();
                    ERP_Pronto.Login();
                    //ERP_Pronto.LoginTeste();
                    ERP_Pronto.BuscarJanela("MOAPOPED", "Apontamento de Ordem de Produção");
                    ERP_Pronto.PreparaJanela();
                    break;
                }
                catch (Exception)
                {
                }
            }
            try
            {
                ERP_Pronto.EstornarApontamentos(la, mesFechado);
            }
            catch (Exception e)
            {
                if (MessageBox.Show(e.Message + "... Deseja Continuar?", "ERRO", MessageBoxButtons.YesNo) == DialogResult.No)
                {

                }
            }
        }

        public static void ObterMesFechado()
        {
            while (true)
            {
                try
                {
                    ERP_Pronto.FecharABC71();
                    ERP_Pronto.Login();
                    //ERP_Pronto.LoginTeste();
                    ERP_Pronto.BuscarJanela("EPMCM1BR", "Consultar Movimentos de Estoque - Quantitativos");
                    ERP_Pronto.ObterMesFechado();
                    ERP_Pronto.FecharABC71();
                    break;
                }
                catch (Exception)
                {
                }
            }
        }

        internal static void MovimentarAcertar(List<Apontamento> laA, List<Apontamento> laM)
        {
            ERP_Pronto.FecharABC71();
            ERP_Pronto.Login();
            if (laM.Count > 0)
            {
                ERP_Pronto.BuscarJanela("EPMCM1BR", "Consultar Movimentos de Estoque - Quantitativos");
                ERP_Pronto.MovimentarAcertar(laM, "Incluir Movimento de Quantidade");
            }
            if (laA.Count > 0)
            {
                ERP_Pronto.BuscarJanela("EPMVACBR", "Consultar Movimentos de Estoque - Acertos");
                ERP_Pronto.MovimentarAcertar(laA, "Incluir Acertos de Estoque");
            }
            //ERP_Pronto.FecharABC71();
        }

        internal static List<string> ConsultaSaldo(List<string> listaProduto)
        {

            ERP_Pronto.FecharABC71();
            ERP_Pronto.Login();
            ERP_Pronto.BuscarJanela("EPSDPRB1", "Consultar Saldos de Estoque");
            ERP_Pronto.PreparaJanelaSaldo();
            var l = ERP_Pronto.ConsultarSaldosDeEstoque(listaProduto);

            return l;
        }

        internal static void RequisitarSugestao(List<RequisitaSugestao> rs)
        {
            try
            {
                //ERP_Pronto.FecharABC71();

                string l1 = string.Empty, L2 = string.Empty;
                //ERP_Pronto.LoginTeste();
                ERP_Pronto.Login();
                ERP_Pronto.BuscarJanela("MOAPOPED", "Apontamento de Ordem de Produção");
                var rs2 = ERP_Pronto.VerificaSePodeSugerir(rs);

                foreach (var r in rs)
                {
                    l1 += r.OP + ", ";
                }
                var L1 = l1.Remove(l1.Length - 2, 2);

                if (rs2.Count > 0)
                {
                    ERP_Pronto.PreparaJanelaSugestao();
                    ERP_Pronto.RequisitarSugestao(rs2);

                    l1 = string.Empty;
                    foreach (var r in rs2)
                    {
                        l1 += r.OP + ", ";
                    }
                    L2 = l1.Remove(l1.Length - 2, 2);
                }
                MessageBox.Show(
                    $"Das OPs {L1}.\n" +
                    $"Apenas as OPs {L2} foram sugeridas", "Sugestões");
                AutoItX.WinSetOnTop("Apontamentos","",0);
                
                //ERP_Pronto.FecharABC71();
            }
            catch (Exception e)
            {
                if (MessageBox.Show(e.Message + "... Deseja Continuar?", "ERRO", MessageBoxButtons.YesNo) == DialogResult.No)
                {

                }
            }
        }
    }
}