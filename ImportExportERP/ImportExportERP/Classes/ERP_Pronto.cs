using System;
using System.Diagnostics;
using System.Threading;
using WindowsInput;
using WindowsInput.Native;
using System.Windows.Forms;
using ImportExportERP.Views;
using ListarJanelasAbertas;
using System.IO;
using AutoIt;
using ImportExportERP.Properties;
using ImportExportERP.Classes;
using System.Drawing;
using System.Windows.Media.Imaging;
using System.Drawing.Imaging;
using System.Threading.Tasks;

namespace ImportExportERP
{
    public class ERP_Pronto
    {
        /*
         * Atalhos Consultas saldo de estoque
         * ALT + B = EXECUTA
         * ALT + C = CONSULTA
         * ALT + F = SAIR
         * ALT + T = EXPORTAR
         * F1 = AJUDA
         atalhos
             */

        static TextBox Dep;
        static TextBox User;
        static TextBox PW;
        static TextBox Filial;
        static RichTextBox RtbMensagens;
        static InputSimulator ins = new InputSimulator();
        static int X = 0, Y = 0;


        public ERP_Pronto(TextBox dep, TextBox user, TextBox pw, TextBox filial, RichTextBox rtbMensagens)
        {
            
            Dep = dep;
            User = user;
            PW = pw;
            RtbMensagens = rtbMensagens;
            Filial = filial;

        }

        internal static void Login()
        {
            AbreAPP();

            var v = AutoItX.WinWaitActive("Identificação", "", 60);
            if (v == 0)
            {
                File.AppendAllText(@"C:\Exports\ERRO_Export.txt", $"{DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")} A janela o identificação demorou mais de 20 segundos\n");
                throw new Exception();
            }

            ProcuraRecurso("btnOkLogin.PNG", 10, 256, 375, 74, 36, false, true);

            Thread.Sleep(100);
            ins.Keyboard.TextEntry("332");
            Thread.Sleep(100);
            ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            Thread.Sleep(100);
            ins.Keyboard.TextEntry(Filial.Text);
            Thread.Sleep(100);
            ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            Thread.Sleep(100);
            ins.Keyboard.TextEntry(Dep.Text);
            Thread.Sleep(100);
            ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            Thread.Sleep(100);
            ins.Keyboard.TextEntry(User.Text); // USUARIO

            Thread.Sleep(100);
            ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            Thread.Sleep(100);

            ins.Keyboard.TextEntry(PW.Text); // SENHA
            Thread.Sleep(100);

            ins.Keyboard.KeyPress(VirtualKeyCode.RETURN);

            v = AutoItX.WinWaitActive("ERP Pronto - ABC71", "", 20);
            if (v == 0)
            {
                File.AppendAllText(@"C:\Exports\ERRO_Export.txt", $"{DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")} A janela o ERP PRONTO - ABC71 demorou mais de 20SEGUNDOS\n");
                throw new Exception();
            }

        } //OK

        private static void AbreAPP()
        {
            FecharABC71();
            Process prc = new Process();
            prc.StartInfo.FileName = @"C:\Exports\erpPronto.jnlp";
            prc.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Maximized;
            prc.Start();

        }

        private static void AguardarJanelaAtivar(string janela)
        {
            bool x = false;
            do
            {
                Thread.Sleep(1000);
                x = (ListaDeJanelasAbertas.ObterJanelaAtiva() == janela);
            } while (!x);
        }

        private static void AguardaJanelaAbrir(string janela)
        {
            do
            {
                Thread.Sleep(1000);
            } while (!ListaDeJanelasAbertas.Lista().Exists(p => p == janela));
        }

        private static void AguardaJanelaFechar(string janela)
        {
            do
            {
                Thread.Sleep(1000);
            } while (ListaDeJanelasAbertas.Lista().Exists(p => p == janela));
        }

        internal static void NFsDinamicaProduto(DateTimePicker dtp)
        {
            var s = AutoItX.WinWaitActive("Consultar Notas Fiscais - Detalhes - Consulta Dinâmica", "", 60);
            if (s == 0)
            {
                File.AppendAllText(@"C:\Exports\ERRO_Export.txt", $"{DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")} A janela 'CONSULTAR NOTAS FISCAIS - DETALHE - CONSULTA DINAMICA' demorou mais de 1MIN\n");
                throw new Exception();
            }

            ProcuraRecurso("btnExecutar.PNG", 20, 993, 111, 37, 29, false, true);

            ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            Thread.Sleep(500);
            ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            Thread.Sleep(500);

            ins.Keyboard.TextEntry(dtp.Text);

            // botao EXECUTAR

            ProcuraRecurso("btnExecutar.PNG", 20, 993, 111, 37, 29, true, true);

            //exportar registros
            Thread.Sleep(1000);

            //detalhar por
            ins.Keyboard.KeyDown(VirtualKeyCode.LMENU);
            Thread.Sleep(500);
            ins.Keyboard.KeyPress(VirtualKeyCode.VK_D);
            Thread.Sleep(500);
            ins.Keyboard.KeyUp(VirtualKeyCode.LMENU);
            Thread.Sleep(500);

            s = AutoItX.WinWaitActive("Alterar Níveis para Detalhamento", "", 60);
            if (s == 0)
            {
                File.AppendAllText(@"C:\Exports\ERRO_Export.txt", $"{DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")} A janela 'aLTERAR NIVEIS PARA DETALHAMENTO' demorou mais de 1MIN\n");
                throw new Exception();
            }
            ProcuraRecurso("btnOK.PNG", 20, 511, 427, 36, 29, false, false);


            Thread.Sleep(1000);

            //Seleciona Linha da nota fiscal
            ins.Keyboard.KeyPress(VirtualKeyCode.VK_L);
            Thread.Sleep(500);

            ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            Thread.Sleep(500);
            ins.Keyboard.KeyPress(VirtualKeyCode.RETURN);
            Thread.Sleep(1000);

            btnOK();

            s = AutoItX.WinWaitActive("Consultar Notas Fiscais - Detalhes - Consulta Dinâmica", "", 60);
            if (s == 0)
            {
                File.AppendAllText(@"C:\Exports\ERRO_Export.txt", $"{DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")} A janela 'Consultar Notas Fiscais - Detalhes - Consulta Dinâmica' demorou mais de 1MIN\n");
                throw new Exception();
            }

            ProcuraRecurso("btnExecutar.PNG", 100, 993, 111, 37, 29, false, true);

            btnExportar();

        }

        private static void AguardarJanelaSair(string v)
        {
            AutoItX.WinClose(v);
            AutoItX.WinWaitClose(v);
            Thread.Sleep(1000);
        }

        private static void AguardarJanelaAbrir(string v)
        {
            AutoItX.WinActivate(v);
            AutoItX.WinWait(v);
            Thread.Sleep(1000);
        }

        internal static void ConsultarOrdensDeProducao()
        {
            var s = AutoItX.WinWaitActive("Consultar Consulta de Ordens de Produção", "", 60);
            if (s == 0)
            {
                File.AppendAllText(@"C:\Exports\ERRO_Export.txt", $"{DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")} A janela 'Consultar Consulta de Ordens de Produção' demorou mais de 1 MIN\n");
                throw new Exception();
            }            //
            ProcuraRecurso("btnExecutar.PNG", 20, 343, 185, 38, 31, true, true);
            //exportar registros
            ProcuraRecurso("ExportarRegistros.PNG", 20, 520, 391, 32, 27, true, true);
        }

        internal static void BuscarJanela(string codJanela, string nomeJanela)
        {
            var p = AutoItX.WinWaitActive("ERP Pronto - ABC71", "", 60);
            if (p == 0)
            {
                File.AppendAllText(@"C:\Exports\ERRO_Export.txt", $"{DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")} A janela 'ERP Pronto - ABC71' demorou mais de 1 MIN\n");
                throw new Exception();
            }
            Thread.Sleep(2000);
            ProcuraRecurso("btnJanelas.PNG", 10, 170, 20, 70, 30, false, true);

            ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            Thread.Sleep(1000);
            ins.Keyboard.KeyDown(VirtualKeyCode.LMENU);
            Thread.Sleep(100);
            ins.Keyboard.KeyPress(VirtualKeyCode.VK_J);
            Thread.Sleep(100);
            ins.Keyboard.KeyUp(VirtualKeyCode.LMENU);
            Thread.Sleep(1000);
            ins.Keyboard.KeyPress(VirtualKeyCode.RETURN);

            Thread.Sleep(1000);

            ProcuraRecurso("LocalizarJanela.PNG", 10, 250, 90, 90, 60, false, true);

            //INSERIR CODIGO DA JANELA
            ins.Keyboard.TextEntry(codJanela);
            Thread.Sleep(500);

            //LIMPAR TEXTO DO LMENU
            ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            Thread.Sleep(100);
            ins.Keyboard.KeyPress(VirtualKeyCode.DELETE);
            Thread.Sleep(100);

            //SELECIONAR TIPO DE PESQUISA PARA "EXATA"
            ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            Thread.Sleep(100);
            ins.Keyboard.KeyPress(VirtualKeyCode.VK_E);
            Thread.Sleep(500);

            // BOTAO PESQUISAR
            ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            Thread.Sleep(100);
            ins.Keyboard.KeyPress(VirtualKeyCode.RETURN);
            Thread.Sleep(2000);

            for (int i = 1; i <= 3; i++)
            {
                Thread.Sleep(100);
                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            }
            Thread.Sleep(100);
            ins.Keyboard.KeyPress(VirtualKeyCode.RETURN);// abre janela escolhida


            var s = AutoItX.WinWaitActive(nomeJanela, "", 60);
            if (s == 0)
            {
                File.AppendAllText(@"C:\Exports\ERRO_Export.txt", $"{DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")} A janela '{nomeJanela}' demorou mais de 1min\n");
                throw new Exception();
            }
        }//ok

        internal static void ConsultarSaldosDeEstoque()
        {
            var s = AutoItX.WinWaitActive("Consultar Saldos de Estoque", "", 60);
            if (s == 0)
            {
                File.AppendAllText(@"C:\Exports\ERRO_Export.txt", $"{DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")} A janela 'Consultar Saldos de Estoque' demorou mais de 1MIN\n");
                throw new Exception();
            }
            ProcuraRecurso("btnExecutar.PNG", 100, 450, 151, 37, 29, false, false);

            Thread.Sleep(1000);

            //zerar Max
            ProcuraRecurso("Max.PNG", 10, 642, 139, 81, 32, true, true);

            for (int i = 1; i <= 10; i++)
            {
                Thread.Sleep(100);
                ins.Keyboard.KeyPress(VirtualKeyCode.BACK);
                Thread.Sleep(100);
                ins.Keyboard.KeyPress(VirtualKeyCode.DELETE);
            }

            //clicar verde executar
            btnExecutar();

            Thread.Sleep(1000);

            ProcuraRecurso("btnExecuta2.PNG", 100, 450, 151, 37, 29, false, false);

            //clicar exportar registros/

            btnExportar();


            s = AutoItX.WinWaitActive("Exportar Dados", "", 60);
            if (s == 0)
            {
                File.AppendAllText(@"C:\Exports\ERRO_Export.txt", $"{DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")} A janela 'Exportar Dados' demorou mais de 1MIN\n");
                throw new Exception();
            }
            Thread.Sleep(1000);
        } //ok

        internal static void ConsultarPedidosDeCompra()
        {

            var s = AutoItX.WinWaitActive("Consultar Pedidos de Compra", "", 60);
            if (s == 0)
            {
                File.AppendAllText(@"C:\Exports\ERRO_Export.txt", $"{DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")} A janela 'Consultar Pedidos de Compra' demorou mais de 1MIN\n");
                throw new Exception();
            }

            // seleciona aba fornecedor E seleciona aba data de entrega
            ProcuraRecurso("DataDeEntrega.PNG", 20, 118, 29, 108, 24, true, true);

            ProcuraRecurso("btnExecutar.PNG", 20, 590, 158, 37, 31, false, true);
            //zera campo max
            Thread.Sleep(2000);
            for (int i = 1; i <= 5; i++)
            {
                Thread.Sleep(500);
                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            }
            Thread.Sleep(500);
            DateTime hoje = DateTime.Today;
            string dataPC = hoje.AddYears(-2).AddDays(-hoje.Day + 1).ToString("ddMMyy");
            ins.Keyboard.TextEntry(dataPC);

            for (int i = 1; i <= 5; i++)
            {
                Thread.Sleep(500);
                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            }
            Thread.Sleep(500);
            ins.Keyboard.KeyPress(VirtualKeyCode.VK_0);

            //seleviona pedidos = com saldo
            //Thread.Sleep(500);
            //ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            //Thread.Sleep(500);
            //ins.Keyboard.KeyPress(VirtualKeyCode.VK_C);
            //Thread.Sleep(500);

            //aciona executar
            btnExecutar();
            ProcuraRecurso("btnExecuta2.PNG", 20, 590, 158, 37, 31, false, true);
            Thread.Sleep(1000);

            //btnExportar();

            //aciona exportar registros
            for (int i = 1; i <= 7; i++)
            {
                Thread.Sleep(500);
                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            }
            Thread.Sleep(500);
            ins.Keyboard.KeyPress(VirtualKeyCode.RETURN);
            Thread.Sleep(1000);
        }//ok

        internal static void SelecionaEstabelecimentoDeposito()
        {
            var s = AutoItX.WinWaitActive("Consultar Saldos de Estoque", "", 60);
            if (s == 0)
            {
                File.AppendAllText(@"C:\Exports\ERRO_Export.txt", $"{DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")} A janela 'Consultar Saldos de Estoque' demorou mais de 1MIN\n");
                throw new Exception();
            }
            ProcuraRecurso("btnExecutar.PNG", 100, 450, 151, 37, 29, false, false);

            Thread.Sleep(1000);
            ins.Keyboard.KeyPress(VirtualKeyCode.VK_2);
            Thread.Sleep(500);
            ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            Thread.Sleep(500);
            ins.Keyboard.KeyDown(VirtualKeyCode.UP);
            Thread.Sleep(2000);

            ins.Keyboard.KeyDown(VirtualKeyCode.LSHIFT);
            Thread.Sleep(500);
            ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            Thread.Sleep(500);
            ins.Keyboard.KeyUp(VirtualKeyCode.LSHIFT);

            ProcuraRecurso("Confirmar.PNG", 20, 136, 68, 125, 62, false, true);
        }

        internal static void CarregarPVs()
        {

            var s = AutoItX.WinWaitActive("Consultar Pedidos não Faturados", "", 60);
            if (s == 0)
            {
                File.AppendAllText(@"C:\Exports\ERRO_Export.txt", $"{DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")} A janela 'Consultar Pedidos não Faturados' demorou mais de 1MIN\n");
                throw new Exception();
            }
            ProcuraRecurso("btnExecutar.PNG", 20, 235, 64, 32, 27, true, true);
            ProcuraRecurso("btnExecuta2.PNG", 20, 235, 64, 32, 27, false, true);

            Thread.Sleep(1000);
            //executar
            //btnExecutar(); // botao EXECUTAR

            //exportar registros
            btnExportar(); // botao Exportar Registros
            Thread.Sleep(1000);

        } //ok

        public static void Movimentos(string st)
        {
            Thread.Sleep(1000);

            var s = AutoItX.WinWaitActive("Consultar Movimentos de Estoque - Quantitativos", "", 60);
            if (s == 0)
            {
                File.AppendAllText(@"C:\Exports\ERRO_Export.txt", $"{DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")} A janela 'Consultar Movimentos de Estoque - Quantitativos' demorou mais de 1MIN\n");
                throw new Exception();
            }

            ProcuraRecurso("btnExecutar.PNG", 100, 484, 230, 34, 27, false, true);

            Thread.Sleep(500);


            for (int i = 1; i <= 4; i++)
            {
                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                Thread.Sleep(200);
            }

            ins.Keyboard.KeyPress(VirtualKeyCode.SPACE);
            Thread.Sleep(200);


            //ProcuraRecurso("Todos.PNG", 10, 507, 78, 74, 28, true, false);
            //Thread.Sleep(500);
            ProcuraRecurso("Todos2.PNG", 100, 507, 78, 74, 28, true, true);
            Thread.Sleep(500);

            //posicao data de
            Thread.Sleep(500);
            for (int i = 1; i <= 12; i++)
            {
                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                Thread.Sleep(200);
            }

            ObterMesFechado();

            if (st == "TOTAL")
            {
                ins.Keyboard.KeyPress(VirtualKeyCode.DELETE);
            }
            if (st == "PARCIAL")
            {
                //incluindo data de
                var data = DateTime.Today;
                var n = data.AddMonths(-2);
                var d = n.AddDays(-data.Day + 1);
                ins.Keyboard.TextEntry(d.ToString("dd/MM/yyyy"));
            }

            //acionando executar
            btnExecutar();

            ProcuraRecurso("btnExecuta2.PNG", 100, 484, 230, 34, 27, false, true);
            Thread.Sleep(1000);


            //executando botao exportar registros
            btnExportar();
            Thread.Sleep(1000);
            //ok
        }

        private static void ObterMesFechado()
        {
            while (true)
            {
                try
                {
                    Clipboard.Clear();

                    ins.Keyboard.KeyPress(VirtualKeyCode.HOME);
                    Thread.Sleep(200);

                    ins.Keyboard.KeyDown(VirtualKeyCode.LSHIFT);
                    Thread.Sleep(200);
                    ins.Keyboard.KeyPress(VirtualKeyCode.END);
                    Thread.Sleep(200);
                    ins.Keyboard.KeyUp(VirtualKeyCode.LSHIFT);
                    Thread.Sleep(100);

                    ins.Keyboard.KeyDown(VirtualKeyCode.LCONTROL);
                    Thread.Sleep(200);
                    ins.Keyboard.KeyPress(VirtualKeyCode.VK_C);
                    Thread.Sleep(500);
                    ins.Keyboard.KeyUp(VirtualKeyCode.LCONTROL);
                    Thread.Sleep(100);

                    string t = Clipboard.GetText(TextDataFormat.Text);
                    Console.WriteLine("Capturado: " + t);
                    DateTime dt = Convert.ToDateTime(t);
                    var mesfechado = dt.AddDays(-1);
                    string path = @"C:\Exports\MesFechado.txt";
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                        File.AppendAllText(path, mesfechado.ToString("dd-MM-yyyy"));
                    }
                    else
                    {
                        File.AppendAllText(path, mesfechado.ToString("dd-MM-yyyy"));
                    }
                    Clipboard.Clear();
                    break;
                }
                catch (Exception)
                {
                }
            }
        }

        internal static void CarregarForaEstoque_DeTerceiro(string janela)
        {
            Thread.Sleep(1000);

            var s = AutoItX.WinWaitActive(janela, "", 60);
            if (s == 0)
            { File.AppendAllText(@"C:\Exports\ERRO_Export.txt", $"{DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")} A janela '{janela}' demorou mais de 1MIN\n"); throw new Exception(); }

            ProcuraRecurso("btnExecutar.PNG", 20, 489, 136, 33, 26, false, true);

            if (janela == "Consultar Mercadorias de Terceiros em Nosso Poder")
            {
                ins.Keyboard.KeyPress(VirtualKeyCode.UP);
                Thread.Sleep(500);
            }

            Thread.Sleep(1000);
            //ZERANDO MAX.
            for (int i = 1; i <= 3; i++)
            {
                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                Thread.Sleep(200);
            }
            ins.Keyboard.KeyPress(VirtualKeyCode.VK_0);
            Thread.Sleep(500);

            //data
            string data = "";
            DateTime hoje = DateTime.Today;
            if (janela == "Consultar Mercadorias de Terceiros em Nosso Poder")
            {
                data = hoje.AddYears(-4).AddDays(-hoje.Day + 1).ToString("ddMMyy");
            }
            else
            {
                data = hoje.AddYears(-2).AddDays(-hoje.Day + 1).ToString("ddMMyy");
            }

            for (int i = 1; i <= 1; i++)
            {
                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                Thread.Sleep(200);
            }
            ins.Keyboard.TextEntry(data);
            Thread.Sleep(500);

            //POSIÇÃO EXECUTAR OK
            btnExecutar();
            ProcuraRecurso("btnExecuta2.PNG", 20, 489, 136, 33, 26, false, true);
            Thread.Sleep(1000);

            //acionando exportar registros
            btnExportar();
            Thread.Sleep(1000);
        } //ok

        internal static void ItensDeEstoque()
        {
            var s = AutoItX.WinWaitActive("Consultar Itens de Estoque", "", 60);
            if (s == 0)
            { File.AppendAllText(@"C:\Exports\ERRO_Export.txt", $"{DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")} A janela 'Consultar Itens de Estoque' demorou mais de 1MIN\n"); throw new Exception(); }

            ERP_Pronto.ProcuraRecurso("btnExecutar.PNG", 20, 284, 164, 28, 24, false, true);

            ////DELETA VALOR 100
            //zerar Max
            ProcuraRecurso("Max2.PNG", 10, 393, 124, 104, 36, true, true);


            for (int i = 1; i <= 10; i++)
            {
                Thread.Sleep(100);
                ins.Keyboard.KeyPress(VirtualKeyCode.BACK);
                Thread.Sleep(100);
                ins.Keyboard.KeyPress(VirtualKeyCode.DELETE);
            }

            //BOTAO EXECUTAR
            btnExecutar();//BOTAO EXECUTAR
            Thread.Sleep(1000);
            ERP_Pronto.ProcuraRecurso("btnExecuta2.PNG", 20, 284, 164, 28, 24, false, true);
            Thread.Sleep(1000);

            //BOTAO EXPORTAR REGISTROS
            btnExportar();//BOTAO EXPORTAR REGISTROS
            Thread.Sleep(1000);
        } //ok

        internal static void ConsultarDadosDasFiliais()
        {
            var s = AutoItX.WinWaitActive("Consultar Dados das Filiais", "", 60);
            if (s == 0)
            { File.AppendAllText(@"C:\Exports\ERRO_Export.txt", $"{DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")} A janela 'Consultar Dados das Filiais' demorou mais de 1MIN\n"); throw new Exception(); }
            ProcuraRecurso("btnExecutar.PNG", 20, 386, 66, 30, 26, false, false);
            //botao executar
            btnExecutar();
            ProcuraRecurso("btnExecuta2.PNG", 20, 386, 66, 30, 26, false, false);
            Thread.Sleep(1000);

            //ConsultarDadosDasFiliais registro
            btnConsultar();
        } //ok

        internal static void ConsultarFilial()
        {
            var s = AutoItX.WinWaitActive("Consultar Filial", "", 60);
            if (s == 0)
            { File.AppendAllText(@"C:\Exports\ERRO_Export.txt", $"{DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")} A janela 'Consultar Filial' demorou mais de 1MIN\n"); throw new Exception(); }
            ProcuraRecurso("Estabelecimentos.PNG", 20, 292, 21, 114, 30, true, true);

            ProcuraRecurso("MaterialDeTerceiro.PNG", 20, 93, 92, 154, 24, true, true);

            btnConsultar();
        } //ok

        internal static void ConsultarEstabelecimento()
        {
            var s = AutoItX.WinWaitActive("Consultar Estabelecimento", "", 60);
            if (s == 0)
            { File.AppendAllText(@"C:\Exports\ERRO_Export.txt", $"{DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")} A janela 'Consultar Estabelecimento' demorou mais de 1MIN\n"); throw new Exception(); }

            ProcuraRecurso("Depositos.PNG", 20, 103, 24, 71, 30, true, true);

            ProcuraRecurso("ExportarRegistros.PNG", 20, 249, 217, 40, 31, true, true);

        } //ok

        internal static void ConsultarSaldosDeEstoqueDeTerceiro(int e, int d)
        {
            AutoItX.WinWaitActive("Consultar Saldos de Estoque");
            Thread.Sleep(1000);

            //seleciona estabelecimento
            if (e > 0)
            {
                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                Thread.Sleep(4000);
            }
            ins.Keyboard.KeyPress(VirtualKeyCode.VK_2);

            //SELECIONA DEPOSITO
            ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            Thread.Sleep(4000);
            for (int i = 0; i < d; i++)
            {
                ins.Keyboard.KeyPress(VirtualKeyCode.UP);
                Thread.Sleep(4000);
            }

            //inclui zero itens para puxar todos os itens
            for (int i = 1; i <= 9; i++)
            {
                Thread.Sleep(500);
                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            }
            Thread.Sleep(500);
            ins.Keyboard.KeyPress(VirtualKeyCode.VK_0);
            Thread.Sleep(500);

            //clicar verde executar
            btnExecutar();

            //clicar exportar registros/
            Thread.Sleep(5000);

            btnExportar();
        } //ok

        internal static void Subescrever()
        {
            var p = AutoItX.WinWaitActive("Sobrescrever", "", 60);
            if (p == 0)
            { File.AppendAllText(@"C:\Exports\ERRO_Export.txt", $"{DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")} A janela 'Sobrescrever' demorou mais de 1MIN\n"); throw new Exception(); }

            Thread.Sleep(500);

            ProcuraRecurso("btnOK_.PNG", 10, 70, 99, 98, 20, true, false);


            AutoItX.WinWaitClose("Sobrescrever", "", 60);
            //

            ProcuraRecurso("DownloadConcluido.PNG", 0, 196, 246, 134, 34, false, true);

            FecharABC71();

            RtbMensagens.BeginInvoke(new Action(async () =>
            {
                RtbMensagens.AppendText($"DownLoad OK \n para: {Clipboard.GetText()}\n---------\n");
                Thread.Sleep(2000);
            }));

            return;

        }

        internal static void ExportarDadosFull(string path, string file, int tempo)
        {
            ExportarDados(file);

            Aguarde(file);

            DownloaddeArquivos(path, tempo);
        } //ok

        internal static void ExportarDados(string file)
        {
            Thread.Sleep(1000);
            if (AutoItX.WinExists("ERP Pronto - ABC71") == 0)
            {
                { File.AppendAllText(@"C:\Exports\ERRO_Export.txt", $"{DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")} A janela 'ERP Pronto - ABC71' demorou mais de 1MIN\n"); throw new Exception(); }
            }
            var T = AutoItX.WinWaitActive("Exportar Dados", "", 10);
            if (T == 0)
            {
                { File.AppendAllText(@"C:\Exports\ERRO_Export.txt", $"{DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")} A janela 'Exportar Dados' demorou mais de 1MIN\n"); throw new Exception(); }
            }

            ProcuraRecurso("btnOK.PNG", 3, 400, 430, 50, 50, false, true);

            Thread.Sleep(1000);

            //posicionando disponivel
            for (int i = 1; i <= 3; i++)
            {
                Thread.Sleep(500);
                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            }

            // seleciona tudo disponivel
            Thread.Sleep(500);
            ins.Keyboard.KeyDown(VirtualKeyCode.CONTROL);
            Thread.Sleep(500);
            ins.Keyboard.KeyPress(VirtualKeyCode.VK_A);// seleciona tudo disponivel
            Thread.Sleep(500);
            ins.Keyboard.KeyUp(VirtualKeyCode.CONTROL);

            //movendo tudo do disponivel
            Thread.Sleep(500);
            ins.Keyboard.KeyDown(VirtualKeyCode.LSHIFT);
            Thread.Sleep(500);
            ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            Thread.Sleep(500);
            ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            Thread.Sleep(500);
            ins.Keyboard.KeyUp(VirtualKeyCode.LSHIFT);
            Thread.Sleep(500);
            ins.Keyboard.KeyPress(VirtualKeyCode.RETURN);
            Thread.Sleep(5000); //aguardando mover tudo

            //escrever nome do arquivo.txt
            for (int i = 1; i <= 6; i++)
            {
                Thread.Sleep(500);
                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            }
            Thread.Sleep(500);
            ins.Keyboard.TextEntry(file);//

            //boatao verde ok
            Thread.Sleep(1000);
            btnOK();
        } //ok

        /// <summary>
        /// Especifica o recurso/imagem, vezes procurada, X,Y,W,H da regiao da janela a ser procurada, se deve ser clicado, se aponta o mouse durante a procura.
        /// Se especificar X,Y,W,H igual a 0, sera procurado na janela inteira
        /// </summary>
        /// <param name="recurso">Imagem</param>
        /// <param name="vezes">Vezes a ser procurada</param>
        /// <param name="cutX">ponto X de uma regiao da janela</param>
        /// <param name="cutY">ponto Y de uma regiao da janela</param>
        /// <param name="cutW">Comprimento da regiao</param>
        /// <param name="cutH">Altura da regiao</param>
        /// <param name="click">Se deva se clicado</param>
        /// <param name="mouse">Se o mouse deve acompanhar a busca. Demora mais tempo</param>
        public static void ProcuraRecurso(string recurso, int vezes, int cutX, int cutY, int cutW, int cutH, bool click, bool mouse)
        {

            FileStream fs = File.OpenRead($@"..\..\Resources\{recurso}");
            Bitmap bmp = new Bitmap(fs);
            bool b = DetectaImagem.Start(bmp, click, vezes, cutX, cutY, cutW, cutH, mouse, recurso);
            if (!b)
            {
                { File.AppendAllText(@"C:\Exports\ERRO_Export.txt", $"{DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")} A janela '' demorou mais de 1MIN\n"); throw new Exception(); }
            }
        }
        private static void REgistrosExportados(int tempo, int cutX, int cutY, int cutW, int cutH, bool mouse)
        {
            // 635 x 320 o tamanho da janela 'Aguarde'.
            throw new NotImplementedException();
        }

        private static void Aguarde(string file)
        {
            var T = AutoItX.WinWaitActive("Aguarde", "", 60);
            if (T == 0)
            {

                File.AppendAllText(@"C:\Exports\ERRO_Export.txt", $"{DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")} o metodo aguarde() ultrapassou 1 minuto\n");
                throw new Exception();
            }

            Thread.Sleep(1000);

            if (AutoItX.WinActive("Erro") == 1)
            {
                File.AppendAllText(@"C:\Exports\ERRO_Export.txt", $"{DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")} A janela ERRO apareceu\n");

                throw new Exception();
            }

            while (false)// mude para true se estiver bom
            {
                //verifica se os registros exportados muda
                REgistrosExportados(10, 17, 64, 208, 25, false);
            }

        } //ok

        private static void DownloaddeArquivos(string path, int tempo)
        {

            var i = AutoItX.WinWaitActive("Download de Arquivos", "", 900); //espera por ate 15min 
            if (i == 0)
            {
                File.AppendAllText(@"C:\Exports\ERRO_Export.txt", $"{DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")} A janela download demorou mais de 15min\n");
                throw new Exception();
            }

            Thread.Sleep(1000);
            ProcuraRecurso("btnSalvarTodos.PNG", 10, 404, 115, 122, 30, true, true);
            Thread.Sleep(1000);

            //janela salvar todos
            SalvarTodos(path);


            if (tempo != 0)
            {
                Thread.Sleep(tempo);
            }
            else
            {
                MessageBox.Show("Aguardando o Download ser comcluido \n\n Click 'OK' ao concluir!!", "Aguardando o Download", MessageBoxButtons.YesNo);
            }
        } //ok

        private static void SalvarTodos(string path)
        {
            var ix = AutoItX.WinWaitActive("Salvar Todos", "", 60); //espera por ate 5min 
            if (ix == 0)
            {
                File.AppendAllText(@"C:\Exports\ERRO_Export.txt", $"{DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")} A janela o Salvar Todos demorou mais de 1min\n");
                throw new Exception();
            }

            Thread.Sleep(2000);

            // ProcuraRecurso("btnSalvar.PNG", 20, 351, 250, 300, 100, false, false);

            Thread.Sleep(100);

            //seleciona campo 
            ins.Keyboard.KeyDown(VirtualKeyCode.LMENU);
            Thread.Sleep(500);
            ins.Keyboard.KeyPress(VirtualKeyCode.VK_N);
            Thread.Sleep(500);
            ins.Keyboard.KeyUp(VirtualKeyCode.LMENU);

            //deleta textos antigos
            Thread.Sleep(500);
            for (int i = 1; i <= 200; i++)
            {
                Thread.Sleep(10);
                ins.Keyboard.KeyPress(VirtualKeyCode.BACK);
            }

            //insere novo caminho
            Thread.Sleep(500);
            ins.Keyboard.TextEntry(path);
            Thread.Sleep(500);

            //botao salvar
            ins.Keyboard.KeyPress(VirtualKeyCode.RETURN);
            Thread.Sleep(500);
        } //ok

        internal static void FecharDownloads()
        {
            var processos = Process.GetProcesses();
            foreach (var processo in processos)
            {
                if (processo.MainWindowTitle == "Aguarde")
                {
                    processo.CloseMainWindow();
                    Thread.Sleep(1000);
                }
            }
        } //ok

        internal static void FecharABC71()
        {
            var processos = Process.GetProcesses();
            foreach (var processo in processos)
            {
                if (processo.ProcessName == "jp2launcher")
                {
                    try
                    {
                        processo.Kill();
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        } //ok

        #region Atalhos
        internal static void btnExecutar()
        {
            //clicar verde executar
            ins.Keyboard.KeyDown(VirtualKeyCode.LMENU);
            Thread.Sleep(100);
            ins.Keyboard.KeyPress(VirtualKeyCode.VK_B);
            Thread.Sleep(100);
            ins.Keyboard.KeyUp(VirtualKeyCode.LMENU);
        }
        internal static void btnConsultar()
        {
            ins.Keyboard.KeyDown(VirtualKeyCode.LMENU);
            Thread.Sleep(100);
            ins.Keyboard.KeyPress(VirtualKeyCode.VK_C);
            Thread.Sleep(100);
            ins.Keyboard.KeyUp(VirtualKeyCode.LMENU);
        }
        internal static void btnSair()
        {
            ins.Keyboard.KeyDown(VirtualKeyCode.LMENU);
            Thread.Sleep(100);
            ins.Keyboard.KeyPress(VirtualKeyCode.VK_S);
            Thread.Sleep(100);
            ins.Keyboard.KeyUp(VirtualKeyCode.LMENU);
        }
        internal static void btnExportar()
        {
            ins.Keyboard.KeyDown(VirtualKeyCode.LMENU);
            Thread.Sleep(100);
            ins.Keyboard.KeyPress(VirtualKeyCode.VK_T);
            Thread.Sleep(100);
            ins.Keyboard.KeyUp(VirtualKeyCode.LMENU);
        }
        internal static void btnOK()
        {
            ins.Keyboard.KeyDown(VirtualKeyCode.LMENU);
            Thread.Sleep(100);
            ins.Keyboard.KeyPress(VirtualKeyCode.VK_O);
            Thread.Sleep(100);
            ins.Keyboard.KeyUp(VirtualKeyCode.LMENU);
        }
        internal static void Ajuda()
        {
            ins.Keyboard.KeyPress(VirtualKeyCode.F1);
        }
        internal static void Localizar(string p)
        {
            ins.Keyboard.KeyDown(VirtualKeyCode.CONTROL);
            Thread.Sleep(100);
            ins.Keyboard.KeyPress(VirtualKeyCode.VK_F);
            Thread.Sleep(100);
            ins.Keyboard.KeyUp(VirtualKeyCode.CONTROL);
            Thread.Sleep(2000);
            ins.Keyboard.TextEntry(p);
            Thread.Sleep(100);
            ins.Keyboard.KeyPress(VirtualKeyCode.RETURN);
            Thread.Sleep(1000);
            ins.Keyboard.KeyPress(VirtualKeyCode.RETURN);
            Thread.Sleep(1000);
        }
        internal static void Localizar_Down(string p)
        {
            ins.Keyboard.KeyDown(VirtualKeyCode.CONTROL);
            Thread.Sleep(100);
            ins.Keyboard.KeyPress(VirtualKeyCode.VK_F);
            Thread.Sleep(100);
            ins.Keyboard.KeyUp(VirtualKeyCode.CONTROL);
            Thread.Sleep(2000);
            ins.Keyboard.TextEntry(p);
            Thread.Sleep(500);
            ins.Keyboard.KeyPress(VirtualKeyCode.RETURN);
            Thread.Sleep(1000);
            ins.Keyboard.KeyPress(VirtualKeyCode.DOWN);
            Thread.Sleep(500);
            ins.Keyboard.KeyPress(VirtualKeyCode.RETURN);
            Thread.Sleep(1000);
        }
        #endregion
    }
}

