using AutoIt;
using Estoque.DAO;
using Estoque.Entidade;
using Estoque.Views;
using Json.Net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using WindowsInput;
using WindowsInput.Native;

namespace Estoque.Classes.ERP
{
    internal class ERP_Pronto
    {

        static InputSimulator ins = new InputSimulator();
        private static bool t = true;
        private static int vez = 1;

        public static int DepositoAtual = 0;

        #region Atalhos


        /// <summary>
        /// CTRL + C
        /// </summary>
        public static string CopiarParaAreaDeTransferencia()
        {
            Thread.Sleep(500);

            ins.Keyboard.KeyDown(VirtualKeyCode.LCONTROL);
            Thread.Sleep(500);
            ins.Keyboard.KeyPress(VirtualKeyCode.VK_C);
            Thread.Sleep(500);
            ins.Keyboard.KeyUp(VirtualKeyCode.LCONTROL);
            Thread.Sleep(500);

            return Clipboard.GetText();

        }
        /// <summary>
        /// CTRL + C
        /// </summary>
        public static string CtrlC()
        {
            Clipboard.Clear();

            ins.Keyboard.KeyDown(VirtualKeyCode.LCONTROL);
            ins.Keyboard.Sleep(50);
            ins.Keyboard.KeyPress(VirtualKeyCode.VK_C);
            ins.Keyboard.Sleep(50);
            ins.Keyboard.KeyUp(VirtualKeyCode.LCONTROL);
            ins.Keyboard.Sleep(50);

            IDataObject idat = null;
            Exception threadEx = null;
            Thread staThread = new Thread(
                delegate ()
                {
                    try
                    {
                        idat = Clipboard.GetDataObject();
                    }

                    catch (Exception ex)
                    {
                        threadEx = ex;
                    }
                });
            staThread.SetApartmentState(ApartmentState.STA);
            staThread.Start();
            staThread.Join();

            return Clipboard.GetText();

        }

        internal static void AlteraDescricaoManual(List<string> colecao, Label lbl)
        {
            foreach (var l in colecao)
            {
                var t = l.Split(';');
                var codig = t[0];
                var desc1 = t[1];
                var desc2 = t[2];

                if (File.Exists(@"C:\Exports\Recusado.txt") == false)
                {
                    var x = File.Create(@"C:\Exports\Recusado.txt");
                    x.Close();
                }

                var linhas = File.ReadAllLines(@"C:\Exports\Recusado.txt");
                HashSet<string> hs = new HashSet<string>(linhas);
                var cont = hs.Contains(codig);
                if (cont)
                {
                    continue;
                }

                ins.Keyboard.TextEntry(codig);
                btnExecutar();
                Thread.Sleep(1000);

                ProcuraRecurso("btnEditarRegistro.PNG", 20, 456, 639, 47, 29, true, false);
                Thread.Sleep(1000);

                AguardaJanelaAtivar("Alterar Item de Estoque", 60);
                Thread.Sleep(1000);

                ProcuraRecurso("btnOK.PNG", 0, 639, 585, 36, 29, false, false);

                ins.Keyboard.TextEntry(desc1);
                Thread.Sleep(100);
                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                Thread.Sleep(100);
                try
                {
                    ins.Keyboard.TextEntry(desc2);
                }
                catch (Exception)
                {
                }
                ProcuraRecurso("btnOK.PNG", 0, 639, 585, 36, 29, true, false);


                var close = AutoItX.WinWaitClose("Alterar Item de Estoque", "", 20);
                if (close == 0)
                {
                    var x = File.AppendText(@"C:\Exports\Recusado.txt");
                    x.WriteLine(codig);
                    x.Close();
                    do
                    {
                        //Thread.Sleep(1000);
                        btnOK();
                        Thread.Sleep(1000);
                        //ProcuraRecurso("btnOK.PNG", 20, 639, 585, 36, 29, false, false);
                        btnSair2();
                    } while (0 == AutoItX.WinWaitClose("Alterar Item de Estoque", "", 60));
                }
                Thread.Sleep(1000);

                ProcuraRecurso("btnEditarRegistro.PNG", 0, 456, 639, 47, 29, false, false);

                Thread.Sleep(1000);

                ins.Keyboard.KeyDown(VirtualKeyCode.LSHIFT);
                Thread.Sleep(100);
                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                Thread.Sleep(100);
                ins.Keyboard.KeyUp(VirtualKeyCode.LSHIFT);

                for (int i = 1; i <= 6; i++)
                {
                    Thread.Sleep(100);
                    ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                }

                Thread.Sleep(100);
                ins.Keyboard.KeyPress(VirtualKeyCode.DELETE);

                var ss = File.AppendText(@"C:\Exports\Recusado.txt");
                ss.WriteLine(codig);
                ss.Close();
            }
            MessageBox.Show("Alterações OK. Atualizar o Export dos Itens");

            File.Delete(@"C:\Exports\Recusado.txt");
        }

        internal static void JanelaEmFoco(string v)
        {
            var s = AutoItX.WinActivate(v);
        }

        internal static void CorrigeTubo(List<SaldoT> listT)
        {
            ProcuraRecurso("btnEditarRegistro.PNG", 20, 456, 639, 47, 29, false, false);

            int i2 = 0;

            foreach (var i in listT)
            {
                ins.Keyboard.TextEntry(i.Produto);
                btnExecutar();
                Thread.Sleep(1000);

                ProcuraRecurso("btnEditarRegistro.PNG", 20, 456, 639, 47, 29, true, false);
                Thread.Sleep(1000);

                AguardaJanelaAtivar("Alterar Item de Estoque", 60);
                Thread.Sleep(1000);

                ProcuraRecurso("btnOK.PNG", 0, 639, 585, 36, 29, false, false);

                ins.Keyboard.TextEntry(i.Descricao2); //descricao 1
                Thread.Sleep(100);
                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                Thread.Sleep(100);
                try
                {
                    if (i.DESCR_2.Length == 0)
                    {
                        ins.Keyboard.KeyPress(VirtualKeyCode.DELETE);
                        Thread.Sleep(100);
                    }
                    else
                    {
                        ins.Keyboard.KeyPress(VirtualKeyCode.DELETE);
                        Thread.Sleep(100);
                        ins.Keyboard.TextEntry(i.DESCR_2); // descricao 2
                    }
                }
                catch (Exception)
                {
                }
                ProcuraRecurso("btnOK.PNG", 0, 639, 585, 36, 29, true, false);  // TRUE, FALSE

                Thread.Sleep(1000);

                //ATUALIZANDO SALDO
                Crud c = new Crud();
                var itemSaldo = c.ListaSaldo().Where(p => p.Produto == i.Produto).FirstOrDefault();
                itemSaldo.Descricao = i.Descricao;
                itemSaldo.Descricao2 = i.Descricao2;
                itemSaldo.DESCR_2 = i.DESCR_2;
                c.AlteraSaldo(itemSaldo);

                Debug.WriteLine($"FEITO {++i2} DE {listT.Count} >> {i.Produto} {i.Descricao}");

                

                var s = AutoItX.WinWaitActive("Consultar Itens de Estoque", "", 60);
                if (s == 0)
                    throw new Exception();

                ProcuraRecurso("btnEditarRegistro.PNG", 20, 456, 639, 47, 29, false, false); 

                // re-posicionando
                for (int ii = 1; ii <= 18; ii++)
                {
                    ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                    Thread.Sleep(100);
                }
                ins.Keyboard.KeyPress(VirtualKeyCode.DELETE);
                Thread.Sleep(200);


               
            }
        }

        internal static void AlterarLivre17(string cod, string livre17New)
        {
            Thread.Sleep(500);
            ins.Keyboard.TextEntry(cod);
            Thread.Sleep(500);

            btnExecutar();
            Thread.Sleep(1000);
            ProcuraRecurso("btnEditarRegistro.PNG", 20, 456, 639, 47, 29, false, false);
            Thread.Sleep(500);

            btnAlterar();

            //
            AguardaJanelaAtivar("Alterar Item de Estoque", 60);
            Thread.Sleep(1000);

            ProcuraRecurso("btnOK.PNG", 0, 639, 585, 36, 29, false, false);
            //



            Thread.Sleep(1000);

            ERP_Pronto.ProcuraRecurso("Livres1.PNG", 20, 116, 23, 73, 29, true, false);


            Thread.Sleep(1000);

            ERP_Pronto.ProcuraRecurso("Livres2.PNG", 20, 124, 47, 60, 28, false, false);


            livre17New = livre17New == string.Empty ? " " : livre17New;
            ins.Keyboard.TextEntry(livre17New);
            Thread.Sleep(100);


            btnOK();

            AutoItX.WinWaitClose("Alterar Item de Estoque");


            ProcuraRecurso("btnEditarRegistro.PNG", 20, 456, 639, 47, 29, false, false);
            Thread.Sleep(1000);

            //reposiciona o cursor
            for (int i = 1; i <= 18; i++)
            {
                Thread.Sleep(100);
                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            }
        }

        internal static void ExcluirItens(string item)
        {
            ////DELETA VALOR 100
            if (t)
            {
                for (int i = 1; i <= 15; i++)
                {
                    Thread.Sleep(100);
                    ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                }
                Thread.Sleep(500);
                ins.Keyboard.KeyPress(VirtualKeyCode.DELETE);
                //ESCREVE 1
                ins.Keyboard.KeyPress(VirtualKeyCode.VK_1);

                for (int i = 1; i <= 8; i++)
                {
                    Thread.Sleep(100);
                    ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                }
                t = false;
            }
            else
            {
                for (int i = 1; i <= 18; i++)
                {
                    Thread.Sleep(100);
                    ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                }
            }


            Thread.Sleep(500);
            ins.Keyboard.TextEntry(item);
            Thread.Sleep(500);

            btnExecutar();
            Thread.Sleep(1000);
            ERP_Pronto.ProcuraRecurso("btnExecuta2.PNG", 20, 284, 164, 28, 24, false, true);

            btnExcluir();

            Thread.Sleep(2000);

            AguardaJanelaAtivar("Excluir Item de Estoque", 60);
            Thread.Sleep(2000);

            btnOK();

            AguardaJanelaAtivar("Confirma", 60);
            Thread.Sleep(2000);

            //btnOK();

            AutoItX.WinWaitClose("Excluir Item de Estoque");

            Thread.Sleep(2000);
        }

        internal static void PreparaJanelaItensDeEstoque()
        {
            var s = AutoItX.WinWaitActive("Consultar Itens de Estoque", "", 60);
            if (s == 0)
                throw new Exception();
            ProcuraRecurso("btnExecutar.PNG", 20, 283, 162, 31, 26, false, false);
            ////DELETA VALOR 100
            //zerar Max
            //ProcuraRecurso("Max2.PNG", 10, 393, 124, 104, 36, false, true);
            Thread.Sleep(100);

           
            
            // double click
            AutoItX.MouseClick("LEFT", 980, 310, 2, -1); //  campo MAX
            //Thread.Sleep(50);
            //AutoItX.MouseClick("LEFT", p.X, p.Y, -1);

            //for (int i = 1; i <= 10; i++)
            //{
            //    Thread.Sleep(100);
            //    ins.Keyboard.KeyPress(VirtualKeyCode.BACK);
            //    Thread.Sleep(100);
            //    ins.Keyboard.KeyPress(VirtualKeyCode.DELETE);
            //}

            Thread.Sleep(100);
            ins.Keyboard.KeyPress(VirtualKeyCode.VK_1);

            //BOTAO EXECUTAR
            btnExecutar();//BOTAO EXECUTAR
            Thread.Sleep(1000);
            ProcuraRecurso("btnExecuta2.PNG", 20, 283, 162, 31, 26, false, true);
            Thread.Sleep(1000);

            AutoItX.MouseClick("LEFT", 710, 290, 1, -1); // Campo Codigo
            Thread.Sleep(100);
        }

        /// <summary>
        /// ALT + I
        /// </summary>
        internal static void btnIncluir()
        {
            //clicar verde executar
            ins.Keyboard.KeyDown(VirtualKeyCode.LMENU);
            Thread.Sleep(100);
            ins.Keyboard.KeyPress(VirtualKeyCode.VK_I);
            Thread.Sleep(100);
            ins.Keyboard.KeyUp(VirtualKeyCode.LMENU);
        }
        /// <summary>
        /// ALT + E
        /// </summary>
        internal static void btnExcluir()
        {
            //clicar verme excluir
            ins.Keyboard.KeyDown(VirtualKeyCode.LMENU);
            Thread.Sleep(100);
            ins.Keyboard.KeyPress(VirtualKeyCode.VK_E);
            Thread.Sleep(100);
            ins.Keyboard.KeyUp(VirtualKeyCode.LMENU);
        }
        /// <summary>
        /// ALT + B
        /// </summary>
        internal static void btnExecutar()
        {
            //clicar verde executar
            ins.Keyboard.KeyDown(VirtualKeyCode.LMENU);
            Thread.Sleep(100);
            ins.Keyboard.KeyPress(VirtualKeyCode.VK_B);
            Thread.Sleep(100);
            ins.Keyboard.KeyUp(VirtualKeyCode.LMENU);
        }
        /// <summary>
        /// ALT + A
        /// </summary>
        internal static void btnAlterar()
        {
            //clicar verde executar
            ins.Keyboard.KeyDown(VirtualKeyCode.LMENU);
            Thread.Sleep(100);
            ins.Keyboard.KeyPress(VirtualKeyCode.VK_A);
            Thread.Sleep(100);
            ins.Keyboard.KeyUp(VirtualKeyCode.LMENU);
        }
        /// <summary>
        /// ALT + C
        /// </summary>
        internal static void btnConsultar()
        {
            ins.Keyboard.KeyDown(VirtualKeyCode.LMENU);
            Thread.Sleep(100);
            ins.Keyboard.KeyPress(VirtualKeyCode.VK_C);
            Thread.Sleep(100);
            ins.Keyboard.KeyUp(VirtualKeyCode.LMENU);
        }
        /// <summary>
        /// ALT + S
        /// </summary>
        internal static void btnSair()
        {
            ins.Keyboard.KeyDown(VirtualKeyCode.LMENU);
            Thread.Sleep(100);
            ins.Keyboard.KeyPress(VirtualKeyCode.VK_S);
            Thread.Sleep(100);
            ins.Keyboard.KeyUp(VirtualKeyCode.LMENU);
        }
        /// <summary>
        /// ALT + L
        /// </summary>
        internal static void btnSair2()
        {
            ins.Keyboard.KeyDown(VirtualKeyCode.LMENU);
            Thread.Sleep(100);
            ins.Keyboard.KeyPress(VirtualKeyCode.VK_L);
            Thread.Sleep(100);
            ins.Keyboard.KeyUp(VirtualKeyCode.LMENU);
        }
        /// <summary>
        /// ALT + T
        /// </summary>
        internal static void btnExportar()
        {
            ins.Keyboard.KeyDown(VirtualKeyCode.LMENU);
            Thread.Sleep(100);
            ins.Keyboard.KeyPress(VirtualKeyCode.VK_T);
            Thread.Sleep(100);
            ins.Keyboard.KeyUp(VirtualKeyCode.LMENU);
        }

        internal static void AplicaSemelhanca()
        {
            Thread.Sleep(500);
            for (int i = 1; i <= 7; i++)
            {
                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                Thread.Sleep(500);
            }
            ins.Keyboard.KeyPress(VirtualKeyCode.SPACE);
            Thread.Sleep(500);
        }

        internal static bool VerificaPrateleiraEliminada()
        {
            Thread.Sleep(500);
            for (int i = 1; i < 16; i++)
            {
                ins.Keyboard.KeyPress(VirtualKeyCode.RIGHT);
                Thread.Sleep(500);
            }

            ins.Keyboard.KeyDown(VirtualKeyCode.LCONTROL);
            Thread.Sleep(500);
            ins.Keyboard.KeyPress(VirtualKeyCode.VK_C);
            Thread.Sleep(500);
            ins.Keyboard.KeyUp(VirtualKeyCode.LCONTROL);

            var x = Clipboard.GetText();
            //falta compara se o texto é vazio 
            // se sim resultado OK/Satisfatorio
            return true;

        }

        internal static void AplicaTipoItemSped(List<ItensDeEstoque> TipoItemSped)
        {


            foreach (var item in TipoItemSped)
            {

                Crud c = new Crud();
                var k = AutoItX.WinWaitActive("Consultar Itens de Estoque", "", 20);
                if (k == 0)
                {
                    throw new Exception();
                }

                ProcuraRecurso("Estabelecimento.PNG", 10, 140, 70, 90, 20, true, true);

                Thread.Sleep(500);

                AutoItX.MouseClick("LEFT", 770, 305, 2, 1); //DUPLO CLICK NO CAMPO CODIGO

                Thread.Sleep(500);

                ins.Keyboard.TextEntry(item.Codigo);

                Thread.Sleep(500);

                btnExecutar();

                Thread.Sleep(500);

                ProcuraRecurso("btnEditarRegistro.PNG", 10, 469, 641, 50, 50, false, true);
                Thread.Sleep(1000);
                btnAlterar();

                Thread.Sleep(1000);
                k = AutoItX.WinWaitActive("Alterar Item de Estoque", "", 20);
                if (k == 0)
                {
                    throw new Exception();
                }
                Thread.Sleep(1000);
                ProcuraRecurso("abaDadosSped.PNG", 20, 155, 31, 76, 16, true, true);
                Thread.Sleep(1000);
                ProcuraRecurso("lblTipoItemSped.PNG", 10, 29, 104, 117, 26, true, true);
                Thread.Sleep(1000);
                for (int i = 1; i <= 2; i++)
                {
                    ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                    Thread.Sleep(100);
                }
                Thread.Sleep(1000);

                switch (item.Grupo)
                {
                    case "12000000":
                        ins.Keyboard.KeyPress(VirtualKeyCode.HOME);
                        Thread.Sleep(500);
                        ins.Keyboard.KeyPress(VirtualKeyCode.VK_M);
                        Thread.Sleep(500);
                        ins.Keyboard.KeyPress(VirtualKeyCode.VK_M);
                        Thread.Sleep(500);
                        btnOK();
                        ProcuraRecurso("btnEditarRegistro.PNG", 10, 469, 641, 50, 50, false, true);
                        Thread.Sleep(1000);
                        item.TipoItemSped = "Matéria-Prima";
                        c.AlterarItensDeEstoque(item);
                        break;

                    case "15000000":
                        ins.Keyboard.KeyPress(VirtualKeyCode.HOME);
                        Thread.Sleep(500);
                        ins.Keyboard.KeyPress(VirtualKeyCode.VK_P);
                        Thread.Sleep(500);
                        ins.Keyboard.KeyPress(VirtualKeyCode.VK_P);
                        Thread.Sleep(500);
                        ins.Keyboard.KeyPress(VirtualKeyCode.VK_P);
                        Thread.Sleep(500);
                        btnOK();
                        ProcuraRecurso("btnEditarRegistro.PNG", 10, 469, 641, 50, 50, false, true);
                        Thread.Sleep(1000);
                        item.TipoItemSped = "Produto Intermediário";
                        c.AlterarItensDeEstoque(item);
                        break;

                    case "16000000":
                        ins.Keyboard.KeyPress(VirtualKeyCode.HOME);
                        Thread.Sleep(500);
                        ins.Keyboard.KeyPress(VirtualKeyCode.VK_M);
                        Thread.Sleep(500);
                        ins.Keyboard.KeyPress(VirtualKeyCode.VK_M);
                        Thread.Sleep(500);
                        ins.Keyboard.KeyPress(VirtualKeyCode.VK_M);
                        Thread.Sleep(500);
                        btnOK();
                        ProcuraRecurso("btnEditarRegistro.PNG", 10, 469, 641, 50, 50, false, true);
                        Thread.Sleep(1000);
                        item.TipoItemSped = "Material de Uso e Consumo";
                        c.AlterarItensDeEstoque(item);
                        break;

                    case "17000000":
                        ins.Keyboard.KeyPress(VirtualKeyCode.HOME);
                        Thread.Sleep(500);
                        ins.Keyboard.KeyPress(VirtualKeyCode.VK_S);
                        Thread.Sleep(500);
                        btnOK();
                        ProcuraRecurso("btnEditarRegistro.PNG", 10, 469, 641, 50, 50, false, true);
                        Thread.Sleep(1000);
                        item.TipoItemSped = "Subproduto";
                        c.AlterarItensDeEstoque(item);
                        break;

                    case "20000000":
                        ins.Keyboard.KeyPress(VirtualKeyCode.HOME);
                        Thread.Sleep(500);
                        ins.Keyboard.KeyPress(VirtualKeyCode.VK_O);
                        Thread.Sleep(500);
                        btnOK();
                        ProcuraRecurso("btnEditarRegistro.PNG", 10, 469, 641, 50, 50, false, true);
                        Thread.Sleep(1000);
                        item.TipoItemSped = "Outros insumos";
                        c.AlterarItensDeEstoque(item);
                        break;
                }
            }
        }

        internal static void AlteraGrupo(Dictionary<string, string> d)
        {
            foreach (var item in d)
            {

                var k = AutoItX.WinWaitActive("Consultar Itens de Estoque", "", 20);
                if (k == 0)
                {
                    throw new Exception();
                }

                ProcuraRecurso("btnEditarRegistro.PNG", 10, 469, 641, 50, 50, false, false);

                Thread.Sleep(500);

                AutoItX.MouseClick("LEFT", 770, 305, 2, 1); //DUPLO CLICK NO CAMPO CODIGO

                Thread.Sleep(500);

                ins.Keyboard.TextEntry(item.Key);

                Thread.Sleep(500);

                btnExecutar();

                Thread.Sleep(500);

                ProcuraRecurso("btnEditarRegistro.PNG", 10, 469, 641, 50, 50, false, true);
                Thread.Sleep(1000);
                btnAlterar();

                Thread.Sleep(1000);
                k = AutoItX.WinWaitActive("Alterar Item de Estoque", "", 20);
                if (k == 0)
                {
                    throw new Exception();
                }
                Thread.Sleep(1000);
                ProcuraRecurso("Grupo.PNG", 60, 220, 50, 138, 17, true, false);
                Thread.Sleep(1000);
                ProcuraRecurso("Grupo2.PNG", 60, 101, 86, 44, 24, false, false);
                Thread.Sleep(1000);

                var g1 = item.Value.Substring(0, 2);
                var g2 = item.Value.Substring(2, 2);
                var g3 = item.Value.Substring(4, 2);
                var g4 = item.Value.Substring(6, 2);

                ins.Keyboard.TextEntry(g1);
                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                Thread.Sleep(100);
                ins.Keyboard.TextEntry(g2);
                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                Thread.Sleep(100);
                ins.Keyboard.TextEntry(g3);
                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                Thread.Sleep(100);
                ins.Keyboard.TextEntry(g4);

                btnOK();
                ProcuraRecurso("btnEditarRegistro.PNG", 10, 469, 641, 50, 50, false, false);
                Thread.Sleep(1000);

                Crud c = new Crud();
                var l = c.ListaItensDeEstoque().Where(p => p.Codigo == item.Key).First(); ;
                l.Grupo = item.Value;
                c.AlterarItensDeEstoque(l);

            }
        }

        internal static void ObterMesFechado()
        {
            Thread.Sleep(500);

            var s = AutoItX.WinWaitActive("Consultar Movimentos de Estoque - Quantitativos", "", 60);
            if (s == 0)
                throw new Exception();

            ProcuraRecurso("btnExecutar.PNG", 100, 484, 230, 34, 27, false, true);

            Thread.Sleep(100);


            for (int i = 1; i <= 16; i++)
            {
                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                Thread.Sleep(100);
            }

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

        internal static List<RequisitaSugestao> VerificaSePodeSugerir(List<RequisitaSugestao> rs)
        {
            //prepara
            PreparaJanela();

            //verifica

            List<RequisitaSugestao> rst = new List<RequisitaSugestao>();

            foreach (var r in rs)
            {
                ins.Keyboard.TextEntry(r.OP);
                btnExecutar();
                ProcuraRecurso("btnExecutar.PNG", 20, 901, 382, 41, 34, false, true);
                var x = ProcuraRecurso("VerificaSugestao.PNG", 1, 0, 432, 128, 72, false, true);
                if (x)
                {
                    rst.Add(r);
                }

                //prepara para a proxima
                ProcuraRecurso("OP.PNG", 20, 129, 65, 31, 24, true, true);
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(100);
                    ins.Keyboard.KeyPress(VirtualKeyCode.DELETE);
                    Thread.Sleep(100);
                    ins.Keyboard.KeyPress(VirtualKeyCode.BACK);
                }
            }
            return rst;
        }

        internal static void PreparaJanelaSugestao()
        {
            var s = AutoItX.WinWaitActive("Apontamento de Ordem de Produção", "", 60);
            if (s == 0)
                throw new Exception();

            Thread.Sleep(1000);
            ProcuraRecurso("SugerirApenasConsumo.PNG", 20, 561, 56, 300, 50, true, true);
            //ProcuraRecurso("Componentes.PNG", 20, 79, 418, 89, 25, true, false);
            ProcuraRecurso("Componentes2.PNG", 20, 79, 418, 89, 25, false, false);
            ProcuraRecurso("OP.PNG", 20, 129, 65, 31, 24, true, true);
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(100);
                ins.Keyboard.KeyPress(VirtualKeyCode.DELETE);
                Thread.Sleep(100);
                ins.Keyboard.KeyPress(VirtualKeyCode.BACK);
            }
        }

        internal static void RequisitarSugestao(List<RequisitaSugestao> rs)
        {

            foreach (var l in rs)
            {
                ins.Keyboard.TextEntry(l.OP);

                ProcuraRecurso("PecasBoas.PNG", 20, 0, 364, 74, 63, true, true);
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(50);
                    ins.Keyboard.KeyPress(VirtualKeyCode.DELETE);
                    Thread.Sleep(50);
                    ins.Keyboard.KeyPress(VirtualKeyCode.BACK);
                }
                Thread.Sleep(100);
                ins.Keyboard.TextEntry(l.QTD);
                btnExecutar();

                ProcuraRecurso("EfetivarApontamentos.PNG", 20, 781, 638, 159, 44, true, true);

                //** outras janelas de efetivação

                AguardaJanelaAtivar("Confirma", 60);

                ProcuraRecurso("btnOK_.PNG", 20, 160, 90, 112, 34, true, true);

                AguardaJanelaAtivar("Aviso", 60);

                ProcuraRecurso("btnOK_.PNG", 20, 220, 88, 113, 42, true, true);

                AguardaJanelaAtivar("Aguarde", 60);

                btnFechar();

                AguardaJanelaAtivar("Apontamento de Ordem de Produção", 60);

                Thread.Sleep(1000);

                //prepara para o proximo
                ProcuraRecurso("OP.PNG", 20, 129, 65, 31, 24, true, true);
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(50);
                    ins.Keyboard.KeyPress(VirtualKeyCode.DELETE);
                    Thread.Sleep(50);
                    ins.Keyboard.KeyPress(VirtualKeyCode.BACK);
                }
            }
        }

        internal static void EfetivarInventario(string database)
        {
            AguardaJanelaAtivar("Processo EP840 - Inventário de Estoque", 60);
            Thread.Sleep(1000);
            var capalote = DateTime.Today.ToString("yyMMdd");

            Thread.Sleep(500);
            ins.Keyboard.TextEntry(database);

            Thread.Sleep(500);
            for (int i = 1; i <= 2; i++)
            {
                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                Thread.Sleep(500);
            }

            ins.Keyboard.KeyPress(VirtualKeyCode.DOWN);
            Thread.Sleep(500);

            for (int i = 1; i <= 1; i++)
            {
                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                Thread.Sleep(500);
            }

            ins.Keyboard.TextEntry(capalote);
            Thread.Sleep(500);

            //efetiva o inventario
            //ins.Keyboard.KeyDown(VirtualKeyCode.LMENU);
            //Thread.Sleep(500);
            //ins.Keyboard.KeyPress(VirtualKeyCode.VK_X);
            //Thread.Sleep(500);
            //ins.Keyboard.KeyUp(VirtualKeyCode.LMENU);

            //Thread.Sleep(1000);

            AguardaJanelaAtivar("Confirma", 60);
            Thread.Sleep(1000);

            ins.Keyboard.KeyPress(VirtualKeyCode.RETURN);
            Thread.Sleep(500);

            AguardaJanelaAtivar("Aguarde", 60);
            Thread.Sleep(1000);

            AguardaJanelaAtivar("Aviso", 60);
            Thread.Sleep(1000);

        }

        internal static void ZerarSaldos(List<PedidoNFs> listaMatarSaldo)
        {
            AguardaJanelaAtivar("Baixa de Pedido de Compra", 60);
            Thread.Sleep(2000);

            //prepara
            ins.Keyboard.TextEntry(listaMatarSaldo[0].PedidoDeCompra.ToString());
            Thread.Sleep(100);
            btnExecutar();
            Thread.Sleep(3000);
            btnIncluir();
            Thread.Sleep(2000);
            AguardaJanelaAtivar("Incluir Baixa de Pedido de Compra - Histórico", 60);
            Thread.Sleep(1000);
            btnSair2();
            Thread.Sleep(1000);
            AguardaJanelaAtivar("Baixa de Pedido de Compra", 60);
            Thread.Sleep(2000);

            string path = "SaldoZera.txt";
            if (!File.Exists(path))
            {
                using (File.Create("SaldoZera.txt"))
                { }
            }

            foreach (var l in listaMatarSaldo)
            {
                List<string> pcs = new List<string>();

                pcs.AddRange(File.ReadAllLines(path));

                var ss = pcs.Contains(l.PedidoDeCompra.ToString() + ";" + l.LinhaPed); //Evita duplicidades caso houver erros no ERP
                if (ss)
                {
                    continue;
                }

                for (int i = 1; i <= 12; i++)
                {
                    ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                    Thread.Sleep(100);
                }

                ins.Keyboard.TextEntry(l.PedidoDeCompra.ToString());
                Thread.Sleep(100);
                btnExecutar();
                Thread.Sleep(3000);

                //indo até o grid de linhas
                for (int i = 1; i <= 8; i++)
                {
                    ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                    Thread.Sleep(100);
                }

                // posicionando a primeira linha do grid
                ins.Keyboard.KeyPress(VirtualKeyCode.PRIOR);
                Thread.Sleep(300);

                //navega entre linhas
                for (int i = 1; i < l.LinhaPed; i++)
                {
                    ins.Keyboard.KeyPress(VirtualKeyCode.DOWN);
                    Thread.Sleep(300);
                }

                Thread.Sleep(3000);
                btnIncluir();
                Thread.Sleep(2000);
                AguardaJanelaAtivar("Incluir Baixa de Pedido de Compra - Histórico", 60);
                Thread.Sleep(1000);

                ///
                ins.Keyboard.TextEntry(l.PedidoDeCompra.ToString());
                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                Thread.Sleep(300);
                ins.Keyboard.TextEntry(l.LinhaPed.ToString());
                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                Thread.Sleep(300);
                ins.Keyboard.TextEntry(l.Saldo.ToString());
                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                Thread.Sleep(300);
                ins.Keyboard.TextEntry(DateTime.Today.ToString("dd/MM/yyyy"));
                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                Thread.Sleep(300);

                ///

                btnOK();
                //btnCancelar();
                Thread.Sleep(1000);
                AguardaJanelaAtivar("Baixa de Pedido de Compra", 60);
                Thread.Sleep(2000);
                string[] pc = { l.PedidoDeCompra.ToString() + ";" + l.LinhaPed };
                File.AppendAllLines(path, pc);
                Crud c = new Crud();
                var pca = c.ListPedidoDeCompra().Where(p => p.Pedido == l.PedidoDeCompra.ToString() & p.LinhaPed == l.LinhaPed.ToString()).ToList();
                c.DeletaPedidoDeCompra(pca);
            }
            File.Delete(path);
        }

        /// <summary>
        /// Cancelar ALT + L
        /// </summary>
        private static void btnCancelar()
        {
            ins.Keyboard.KeyDown(VirtualKeyCode.LMENU);
            Thread.Sleep(100);
            ins.Keyboard.KeyPress(VirtualKeyCode.VK_L);
            Thread.Sleep(100);
            ins.Keyboard.KeyUp(VirtualKeyCode.LMENU);
        }

        internal static void RequisitarApontamentos(List<Apontamento> AllOPs)
        {
            HashSet<string> OpsDistintas = new HashSet<string>();
            foreach (Apontamento A in AllOPs)
            {
                OpsDistintas.Add(A.OP);
            }

            

            foreach (string op_ in OpsDistintas)
            {
                var GrupoOPs = AllOPs.Where(p => p.OP == op_).ToList();

                // da op ate incluir
                ins.Keyboard.TextEntry(op_);
                Thread.Sleep(100);
                btnExecutar();
                ProcuraRecurso("btnExecutar.PNG", 20, 901, 382, 41, 34, false, true);
                Thread.Sleep(500);
                btnIncluir();
                Thread.Sleep(1000);
                AguardaJanelaAtivar("Incluir Detalhe do Apontamento por Operação", 60);

                Thread.Sleep(1000);

                ProcuraRecurso("btnOK2.PNG", 20, 667, 708, 35, 30, false, true);


                Thread.Sleep(1000);

                int ii = 1;

                foreach (var op in GrupoOPs) //todas as ops iguais
                {
                    for (int i = 1; i <= 2; i++)
                    {
                        ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                        Thread.Sleep(300);
                    }

                    ins.Keyboard.TextEntry(op.Produto);
                    ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                    Thread.Sleep(2000);

                    for (int i = 1; i <= 9; i++) // normal
                    {
                        ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                        Thread.Sleep(300);
                    }

                    ins.Keyboard.TextEntry(op.KG);
                    Thread.Sleep(300);

                    for (int i = 1; i <= 4; i++)
                    {
                        ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                        Thread.Sleep(300);
                    }

                    //limpando o anotação
                    ins.Keyboard.KeyDown(VirtualKeyCode.LCONTROL);
                    Thread.Sleep(200);
                    ins.Keyboard.KeyPress(VirtualKeyCode.VK_A);
                    Thread.Sleep(200);
                    ins.Keyboard.KeyUp(VirtualKeyCode.LCONTROL);
                    Thread.Sleep(200);
                    ins.Keyboard.TextEntry("Anotação : AUTOMATICO");
                    Thread.Sleep(300);

                    btnOK();

                    AguardaJanelaAtivar("Copiar Detalhe do Apontamento por Operação", 60);


                    ProcuraRecurso("btnOK2.PNG", 20, 667, 708, 35, 30, false, true);

                    if (GrupoOPs.Count == ii)
                    {
                        break;
                    }

                    AutoItX.MouseClick("LEFT", 938, 441, 1, -1); // Campo Estabellecimento (1 BARBANERA)
                    Thread.Sleep(200);
                    ins.Keyboard.KeyPress(VirtualKeyCode.ESCAPE);

                    ii++;

                }

                btnSair2();
                Thread.Sleep(1000);

                AguardaJanelaAtivar("Apontamento de Ordem de Produção", 60);

                Thread.Sleep(1000);
                //COM O MES FECHADO NAO DA PARA FAZER ESTORNO OP 5411 (B-186), B-2672 , B-441
                //efetivar
                ProcuraRecurso("EfetivarApontamentos.PNG", 20, 781, 638, 159, 44, true, true);

                //** outras janelas de efetivação

                AguardaJanelaAtivar("Confirma", 60);

                ProcuraRecurso("btnOK_.PNG", 20, 160, 90, 112, 34, true, true);

                AguardaJanelaAtivar("Aviso", 60);

                ProcuraRecurso("btnOK_.PNG", 20, 220, 88, 113, 42, true, true);

                AguardaJanelaAtivar("Aguarde", 60);

                btnFechar();

                AguardaJanelaAtivar("Apontamento de Ordem de Produção", 60);

                Thread.Sleep(1000);

                //prepara um update
                //List<ItensDeEstoque> lip = new List<ItensDeEstoque>();
                //foreach (var item in sub)
                //{
                //    var s = li.Where(p => p.Produto == item.Produto).First();
                //    s.SaldoAtual -= Convert.ToDouble(item.Quantidade);

                //    lip.Add(s);
                //}
                //Crud c = new Crud();
                //c.AlterarItensDeEstoque(lip);

                /// tem que alterar do sldo de estoque tbm: saldo e disponivel

                //fim update


                //** fim


                //preparando a janela novamente
                ProcuraRecurso("OP.PNG", 20, 129, 65, 31, 24, true, true);
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(100);
                    ins.Keyboard.KeyPress(VirtualKeyCode.DELETE);
                    Thread.Sleep(100);
                    ins.Keyboard.KeyPress(VirtualKeyCode.BACK);
                }
            }


        }

        internal static void EstornarApontamentos(List<Apontamento> Itens, DateTime mesFechado)
        {

            HashSet<string> OpsDistintas = new HashSet<string>();
            foreach (var Apontamento in Itens)
            {
                OpsDistintas.Add(Apontamento.OP);
            }

            foreach (var op in OpsDistintas)                 //op
            {
                ins.Keyboard.TextEntry(op);
                Thread.Sleep(100);
                btnExecutar();
                ProcuraRecurso("btnExecutar.PNG", 40, 901, 382, 41, 34, false, true);
                Thread.Sleep(500);
                ObterGridDeApontamentos();
                Thread.Sleep(500);
                ProcuraRecurso("btnIncluir2.PNG", 20, 319, 656, 33, 21, false, false);
                btnIncluir();
                Thread.Sleep(500);
                AguardaJanelaAtivar("Incluir Detalhe do Apontamento por Operação", 60);
                Thread.Sleep(500);
                ProcuraRecurso("btnOK2.PNG", 20, 667, 708, 35, 30, false, true);


                var itens = Itens.Where(p => p.OP == op);
                foreach (var item in itens)       //ITENS
                {
                    var dic = AnalisaComGridDeApontamentos(item, mesFechado); // valor e posicao  E DATA

                    foreach (var d in dic) // um apontamento no APP pode desmembrar em varios outros apontamentos no ERP
                    {
                        for (int i = 1; i <= 2; i++)   // pula estabelecimento e deposito
                        {
                            ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                            Thread.Sleep(300);
                        }

                        //Produto
                        ins.Keyboard.TextEntry(item.Produto);
                        ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                        Thread.Sleep(2000);

                        //Tipo Movumento  == Estorno
                        for (int i = 1; i <= 4; i++)      //pula da lupa até tipo de movimento  
                        {
                            ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                            Thread.Sleep(300);
                        }
                        ins.Keyboard.KeyPress(VirtualKeyCode.VK_E); // estorno
                        Thread.Sleep(1000);
                        ins.Keyboard.KeyPress(VirtualKeyCode.TAB);       // pula pa seq de estorno
                        Thread.Sleep(100);
                        ins.Keyboard.KeyPress(VirtualKeyCode.UP);      // seleciona o primeiro
                        Thread.Sleep(100);
                        for (int i = 0; i < d.SeqApontamento; i++)  // indica qual sequencia
                        {
                            ins.Keyboard.KeyPress(VirtualKeyCode.DOWN);
                            Thread.Sleep(100);
                        }

                        // Data
                        ins.Keyboard.KeyPress(VirtualKeyCode.TAB);      // data
                        Thread.Sleep(300);
                        ins.Keyboard.TextEntry(d.DataMovto);       // selec data

                        //Valor
                        for (int i = 1; i <= 4; i++)   // pula para valor
                        {
                            ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                            Thread.Sleep(300);
                        }
                        ins.Keyboard.TextEntry(d.QtdeReal);  //  valor
                        Thread.Sleep(300);

                        //OBSs
                        for (int i = 1; i <= 3; i++)    // pula para OBSs
                        {
                            ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                            Thread.Sleep(300);
                        }
                        //limpando o anotação
                        ins.Keyboard.KeyDown(VirtualKeyCode.LCONTROL);
                        Thread.Sleep(100);
                        ins.Keyboard.KeyPress(VirtualKeyCode.VK_A);
                        Thread.Sleep(100);
                        ins.Keyboard.KeyUp(VirtualKeyCode.LCONTROL);
                        Thread.Sleep(100);
                        ins.Keyboard.TextEntry("Anotação : AUTOMATICO");
                        Thread.Sleep(100);

                        btnOK();
                        AguardaJanelaAtivar("Copiar Detalhe do Apontamento por Operação", 60);
                        Thread.Sleep(1000);

                        //Volta para o Inicio
                        ProcuraRecurso("Componente3.PNG", 20, 5, 210, 90, 29, true, false);
                        Thread.Sleep(1000);

                        ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                        Thread.Sleep(300);
                    }
                }

                btnSair2();
                Thread.Sleep(1000);

                AguardaJanelaAtivar("Apontamento de Ordem de Produção", 60);

                Thread.Sleep(1000);

                //efetivar
                ProcuraRecurso("EfetivarApontamentos.PNG", 20, 781, 638, 159, 44, true, true);

                //** outras janelas de efetivação

                AguardaJanelaAtivar("Confirma", 60);

                ProcuraRecurso("btnOK_.PNG", 20, 160, 90, 112, 34, true, true);

                AguardaJanelaAtivar("Aviso", 60);

                ProcuraRecurso("btnOK_.PNG", 20, 220, 88, 113, 42, true, true);

                AguardaJanelaAtivar("Aguarde", 60);

                btnFechar();

                AguardaJanelaAtivar("Apontamento de Ordem de Produção", 60);

                Thread.Sleep(1000);


                //preparando a janela novamente
                ProcuraRecurso("OP.PNG", 40, 129, 65, 31, 24, true, true);
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(100);
                    ins.Keyboard.KeyPress(VirtualKeyCode.DELETE);
                    Thread.Sleep(100);
                    ins.Keyboard.KeyPress(VirtualKeyCode.BACK);
                }
            }
        }

        public static List<GridApontamento> AnalisaComGridDeApontamentos(Apontamento a, DateTime mesFechado)
        {
            var textoJson = File.ReadAllText(@"C:\Exports\GridApontamentos.json", Encoding.Default);
            List<GridApontamento> json = JsonNet.Deserialize<List<GridApontamento>>(textoJson);
            //var json = json2.Where(p => Convert.ToDateTime(p.DataMovto) > mesFechado).ToList();
            List<GridApontamento> dic = new List<GridApontamento>();

            // subtraindo estornos anteriores, atualizando QuantidadeReal
            var j1 = json.Where(p => p.Componente == a.Produto & p.SeqEstorno != "0" & Convert.ToDateTime(p.DataMovto) > mesFechado).ToList();
            foreach (var item in j1)
            {
                json.Where(p => p.SeqApontamento.ToString() == item.SeqEstorno).ToList().ForEach(p => p.QtdeReal = (Convert.ToDecimal(p.QtdeReal) - Convert.ToDecimal(item.QtdeReal)).ToString());
            }

            //   criando dicionario {data, sequenciaApontamento e quantidade}
            var j2 = json.Where(p => p.Componente == a.Produto & p.TipoMovto == "330").OrderBy(p => p.SeqApontamento).ToList();
            int seq = 0;
            decimal qtd = Convert.ToDecimal(a.KG);
            foreach (var item in j2)
            {
                //ignora se for de mes fechado
                if (Convert.ToDateTime(item.DataMovto) <= mesFechado)
                {
                    seq++;
                    continue;
                }

                if (qtd <= Convert.ToDecimal(item.QtdeReal))
                {
                    dic.Add(new GridApontamento { QtdeReal = qtd.ToString(), SeqApontamento = seq, DataMovto = item.DataMovto });
                    break;
                }

                qtd -= Convert.ToDecimal(item.QtdeReal);
                dic.Add(new GridApontamento { QtdeReal = item.QtdeReal, SeqApontamento = seq, DataMovto = item.DataMovto });
                seq++;
            }
            return dic;
        }

        public static List<GridApontamento> ObterGridDeApontamentos()
        {
            string Novalinha = string.Empty;
            string Velhlinha = string.Empty;
            string linha = string.Empty;
            do
            {
                Velhlinha = Novalinha;
                linha += Novalinha;
                Novalinha = string.Empty;

                for (int i = 0; i < 19; i++)
                {
                    string tm = string.Empty;
                    var copia = CtrlC().Trim();
                    if (i == 7 & copia == "90")
                    {
                        tm = "90";
                    }
                    if (i == 9 & tm == "90")
                    {
                        copia = "-" + copia;
                    }
                    Novalinha += copia + "\t";
                    Clipboard.Clear();
                    SetaDireita();
                    if (i == 18)
                    {
                        var x = Novalinha.Remove(Novalinha.Length - 1, 1);
                        Novalinha = string.Empty;
                        Novalinha = x + "\n";
                    }
                }

                ins.Keyboard.KeyPress(VirtualKeyCode.HOME);
                Thread.Sleep(100);
                ins.Keyboard.KeyPress(VirtualKeyCode.DOWN);
                Thread.Sleep(1000);
                ProcuraRecurso("btnExecutar.PNG", 20, 901, 382, 41, 34, false, false);

            } while (Novalinha != Velhlinha);

            var linhas = linha.Split('\n');

            List<GridApontamento> lga = new List<GridApontamento>();
            foreach (var l in linhas)
            {
                if (l == "")
                {
                    break;
                }
                var Cell = l.Split('\t');
                GridApontamento ga = new GridApontamento();

                ga.Status = Cell[0];
                ga.SeqOper = Cell[1];
                ga.Estab = Cell[2];
                ga.Depos = Cell[3];
                ga.Componente = Cell[4];
                ga.Traducao = Cell[5];
                ga.Unid = Cell[6];
                ga.TipoMovto = Cell[7];
                ga.QtdePrev = Cell[8];
                ga.QtdeReal = Cell[9];
                ga.QtdePrevSemPerda = Cell[10];
                ga.PerdaPrev = Cell[11];
                ga.QtdeRealSemPerda = Cell[12];
                ga.PerdaReal = Cell[13];
                ga.DataMovto = Cell[14];
                ga.HoraMovto = Cell[15];
                ga.DescricaComponente = Cell[16];
                ga.SeqApontamento = Convert.ToInt16(Cell[17]);
                ga.SeqEstorno = Cell[18];

                lga.Add(ga);
            }
            if (File.Exists(@"C:\Exports\GridApontamentos.json"))
            {
                File.Delete(@"C:\Exports\GridApontamentos.json");
            }
            using (File.Create(@"C:\Exports\GridApontamentos.json"))
            {
            }
            string json = JsonNet.Serialize(lga);
            File.AppendAllText(@"C:\Exports\GridApontamentos.json", json, Encoding.Default);

            return lga;
        }

        private static void SetaDireita()
        {
            Thread.Sleep(50);
            ins.Keyboard.KeyPress(VirtualKeyCode.RIGHT);
            Thread.Sleep(50);
        }

        /// <summary>
        /// ALT + F
        /// </summary>
        private static void btnFechar()
        {
            //clicar verde executar
            ins.Keyboard.KeyDown(VirtualKeyCode.LMENU);
            Thread.Sleep(100);
            ins.Keyboard.KeyPress(VirtualKeyCode.VK_F);
            Thread.Sleep(100);
            ins.Keyboard.KeyUp(VirtualKeyCode.LMENU);
        }

        internal static void PreparaJanela()
        {
            var s = AutoItX.WinWaitActive("Apontamento de Ordem de Produção", "", 60);
            if (s == 0)
                throw new Exception();

            Thread.Sleep(1000);
            ProcuraRecurso("NaoSugerir.PNG", 20, 615, 115, 95, 30, true, true);
            ProcuraRecurso("Componentes.PNG", 20, 79, 418, 89, 25, true, false);
            ProcuraRecurso("Componentes2.PNG", 20, 79, 418, 89, 25, false, false);
            ProcuraRecurso("OP.PNG", 20, 129, 65, 31, 24, true, true);
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(100);
                ins.Keyboard.KeyPress(VirtualKeyCode.DELETE);
                Thread.Sleep(100);
                ins.Keyboard.KeyPress(VirtualKeyCode.BACK);
            }
        }

        internal static void LançarItens(System.Collections.Generic.List<SaldoMensal.ListaSaldoMensal> lista)
        {
            Thread.Sleep(1000);
            btnIncluir();
            Thread.Sleep(1000);
            AguardaJanelaAtivar("Incluir Movimento de Inventário - Mês Fechado", 60);
            Thread.Sleep(1000);
            ins.Keyboard.KeyPress(VirtualKeyCode.VK_1);
            Thread.Sleep(500);

            //loop
            foreach (var l in lista)
            {
                Localizar("Número da Ficha");
                Thread.Sleep(500);
                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                Thread.Sleep(500);
                ins.Keyboard.TextEntry(l.Codigo);
                Thread.Sleep(2000);

                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                Thread.Sleep(500);
                for (int i = 1; i <= 2; i++)
                {
                    ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                    Thread.Sleep(500);
                }
                Thread.Sleep(1000);
                ins.Keyboard.KeyPress(VirtualKeyCode.HOME);
                Thread.Sleep(1000);
                ins.Keyboard.KeyPress(VirtualKeyCode.VK_U);
                Thread.Sleep(1000);

                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                Thread.Sleep(1000);

                ins.Keyboard.TextEntry("10");
                Thread.Sleep(500);

                btnOK();
                Thread.Sleep(2000);

                AguardaJanelaAtivar("Copiar Movimento de Inventário - Mês Fechado", 60);
                Thread.Sleep(1000);
            }
            ins.Keyboard.KeyDown(VirtualKeyCode.LMENU);
            Thread.Sleep(500);
            ins.Keyboard.KeyPress(VirtualKeyCode.VK_L);
            Thread.Sleep(500);
            AguardaJanelaAtivar("Consultar Controle de Inventários", 60);
            Thread.Sleep(500);
            ins.Keyboard.KeyPress(VirtualKeyCode.VK_F);
            Thread.Sleep(500);
            ins.Keyboard.KeyUp(VirtualKeyCode.LMENU);
            Thread.Sleep(1000);
        }

        internal static string GerarNumeroDeInventario()
        {
            var capalote = DateTime.Today.AddDays(-1).ToString("yyMMdd");

            /// posicionar lote
            Thread.Sleep(1000);
            ins.Keyboard.TextEntry(capalote);
            Thread.Sleep(500);
            ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            Thread.Sleep(500);
            ins.Keyboard.KeyPress(VirtualKeyCode.VK_C);
            Thread.Sleep(500);
            ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            Thread.Sleep(500);
            ins.Keyboard.KeyPress(VirtualKeyCode.VK_1);
            Thread.Sleep(500);
            ///

            btnIncluir();
            Thread.Sleep(2000);
            btnIncluir();
            Thread.Sleep(1000);
            AguardaJanelaAtivar("Incluir Controle de Inventário", 60);
            Thread.Sleep(1000);
            ins.Keyboard.TextEntry(capalote);
            Thread.Sleep(1000);
            for (int i = 1; i <= 1; i++)
            {
                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                Thread.Sleep(500);
            }
            ins.Keyboard.KeyPress(VirtualKeyCode.SPACE);
            Thread.Sleep(1000);
            btnOK();
            Thread.Sleep(1000);
            AguardaJanelaAtivar("Consultar Controle de Inventários", 60);
            Thread.Sleep(1000);

            btnExecutar();

            Thread.Sleep(2000);

            ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            Thread.Sleep(500);
            ins.Keyboard.KeyPress(VirtualKeyCode.RIGHT);
            Thread.Sleep(500);
            ins.Keyboard.KeyPress(VirtualKeyCode.RIGHT);
            Thread.Sleep(500);

            CopiarParaAreaDeTransferencia();
            var database = Clipboard.GetText();
            return database;

        }

        internal static void PosicionaDeposito()
        {
            Thread.Sleep(500);
            for (int i = 1; i <= 10; i++)
            {
                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                Thread.Sleep(500);
            }
        }

        internal static void NovoRegistro()
        {
            Thread.Sleep(1000);

            ins.Keyboard.KeyDown(VirtualKeyCode.LMENU);
            Thread.Sleep(500);
            ins.Keyboard.KeyPress(VirtualKeyCode.VK_I);
            Thread.Sleep(500);
            ins.Keyboard.KeyUp(VirtualKeyCode.LMENU);

            Thread.Sleep(1000);

        }

        internal static void LancarAcerto(string produto, double acerto)
        {
            Thread.Sleep(500);
            ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            Thread.Sleep(500);
            ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            Thread.Sleep(500);
            ins.Keyboard.TextEntry(produto);
            Thread.Sleep(500);
            ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            Thread.Sleep(2000);
            for (int i = 1; i <= 3; i++)
            {
                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                Thread.Sleep(500);
            }
            ins.Keyboard.TextEntry(acerto.ToString().Replace(".", ","));
            Thread.Sleep(500);
            btnOK();
            Thread.Sleep(5000);


        }

        internal static void PreparaAcerto(string v)
        {
            Thread.Sleep(1000);
            for (int i = 1; i <= 2; i++)
            {
                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                Thread.Sleep(500);
            }
            ins.Keyboard.TextEntry(v);

            Thread.Sleep(500);
            for (int i = 1; i <= 3; i++)
            {
                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                Thread.Sleep(500);
            }
            var data = DateTime.Now.ToString("dd/MM/yyyy");
            ins.Keyboard.TextEntry(data);

            Thread.Sleep(500);
            for (int i = 1; i <= 5; i++)
            {
                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                Thread.Sleep(500);
            }
            var data2 = DateTime.Now.ToString("yyMMdd");
            ins.Keyboard.TextEntry(data2);
        }

        internal static void ReposicionaDeposito()
        {
            Thread.Sleep(500);
            ins.Keyboard.KeyDown(VirtualKeyCode.LSHIFT);
            Thread.Sleep(500);
            ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            Thread.Sleep(500);
            ins.Keyboard.KeyUp(VirtualKeyCode.LSHIFT);
            Thread.Sleep(500);
            ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            Thread.Sleep(500);
            ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            Thread.Sleep(500);
        }

        internal static void SelecionaEstabelecimento(int v)
        {
            AguardaJanelaAtivar("Consultar Itens de Estoque", 60);

            switch (v)
            {
                case 2: ins.Keyboard.KeyPress(VirtualKeyCode.VK_2); break;
            }
            Thread.Sleep(500);
        }

        /// <summary>
        /// ALT + O
        /// </summary>
        internal static void btnOK()
        {
            ins.Keyboard.KeyDown(VirtualKeyCode.LMENU);
            Thread.Sleep(100);
            ins.Keyboard.KeyPress(VirtualKeyCode.VK_O);
            Thread.Sleep(100);
            ins.Keyboard.KeyUp(VirtualKeyCode.LMENU);
        }

        internal static void AcertarQuantidade(Acerto a)
        {
            Thread.Sleep(2000);

            for (int i = 1; i <= 2; i++)
            {
                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                Thread.Sleep(500);
            }

            //TM
            ins.Keyboard.TextEntry(a.TM.ToString());
            Thread.Sleep(500);

            for (int i = 1; i <= 3; i++)
            {
                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                Thread.Sleep(1000);
            }
            // Data
            ins.Keyboard.TextEntry(a.Data.ToString());
            Thread.Sleep(500);

            for (int i = 1; i <= 5; i++)
            {
                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                Thread.Sleep(500);
            }

            //documento 
            ins.Keyboard.TextEntry(a.Doc.ToString());
            Thread.Sleep(500);

            for (int i = 1; i <= 2; i++)
            {
                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                Thread.Sleep(500);
            }

            // produto
            ins.Keyboard.TextEntry(a.Produto.ToString());
            Thread.Sleep(500);

            ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            Thread.Sleep(2000);
            for (int i = 1; i <= 3; i++)
            {
                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                Thread.Sleep(500);
            }

            // quantidade
            ins.Keyboard.TextEntry(a.Quantidade.ToString());
            Thread.Sleep(500);

            for (int i = 1; i <= 4; i++)
            {
                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                Thread.Sleep(1000);
            }

            // obs
            ins.Keyboard.TextEntry(a.Obs.ToString());
            Thread.Sleep(500);


            btnOK();

            Thread.Sleep(1000);

            AguardaJanelaAtivar("Copiar Acertos de Estoque", 60);

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
        #endregion

        internal static void Login()
        {
            AbreAPP();

            var v = AutoItX.WinWaitActive("Identificação", "", 60);
            if (v == 0)
                throw new Exception();

            //ProcuraRecurso("btnOkLogin.PNG", 10, 256, 375, 74, 36, false, true);
            ProcuraRecurso("btnOkLogin.PNG", 10, 0, 0, 0, 0, false, false);

            Thread.Sleep(100);
            ins.Keyboard.TextEntry("332");
            Thread.Sleep(100);
            ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            Thread.Sleep(100);
            ins.Keyboard.TextEntry("1");
            Thread.Sleep(100);
            ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            Thread.Sleep(100);
            ins.Keyboard.TextEntry("TI");
            Thread.Sleep(100);
            ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            Thread.Sleep(100);
            ins.Keyboard.TextEntry("CID"); // USUARIO

            Thread.Sleep(100);
            ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            Thread.Sleep(100);
            ins.Keyboard.TextEntry("THALES10"); // SENHA
            Thread.Sleep(100);
            ins.Keyboard.KeyPress(VirtualKeyCode.RETURN);

            v = AutoItX.WinWaitActive("ERP Pronto - ABC71", "", 20);
            if (v == 0)
                throw new Exception();
        }

        internal static void LoginTeste()
        {
            AbreAPP();

            var v = AutoItX.WinWaitActive("Identificação", "", 60);
            if (v == 0)
                throw new Exception();

            //ProcuraRecurso("btnOkLogin.PNG", 10, 256, 375, 74, 36, false, true);
            ProcuraRecurso("btnOkLogin.PNG", 10, 0, 0, 0, 0, false, false);

            Thread.Sleep(100);
            ins.Keyboard.TextEntry("332");
            Thread.Sleep(100);
            ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            Thread.Sleep(100);
            ins.Keyboard.TextEntry("99");
            Thread.Sleep(100);
            ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            Thread.Sleep(100);
            ins.Keyboard.TextEntry("TI");
            Thread.Sleep(100);
            ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            Thread.Sleep(100);
            ins.Keyboard.TextEntry("CID"); // USUARIO

            Thread.Sleep(100);
            ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            Thread.Sleep(100);
            ins.Keyboard.TextEntry("THALES10"); // SENHA
            Thread.Sleep(100);
            ins.Keyboard.KeyPress(VirtualKeyCode.RETURN);
        }

        private static void AbreAPP()
        {
            FecharABC71();
            Process prc = new Process();
            prc.StartInfo.FileName = @"C:\Exports\erpPronto.jnlp";
            prc.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Maximized;
            prc.Start();

        }
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
        public static bool ProcuraRecurso(string recurso, int veses, int cutX, int cutY, int cutW, int cutH, bool click, bool mouse)
        {

            FileStream fs = File.OpenRead($@"..\..\Resources\{recurso}");
            Bitmap bmp = new Bitmap(fs);
            bool b = DetectaImagem.Start(bmp, click, veses, cutX, cutY, cutW, cutH, mouse, recurso);
            if (recurso == "VerificaSugestao.PNG" & b == false)
            {
                return b;
            }
            if (!b)
            {
                throw new Exception();
            }
            return b;

        }

        internal static void ConsultarEstabelecimento()
        {
            Thread.Sleep(1000);
            AutoItX.WinWaitActive("Consultar Estabelecimento");
            Thread.Sleep(1000);
            ins.Keyboard.KeyPress(VirtualKeyCode.RIGHT);
            Thread.Sleep(1000);

            for (int i = 1; i <= 3; i++)
            {
                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                Thread.Sleep(500);
                if (i == 1)
                {
                    ins.Keyboard.KeyPress(VirtualKeyCode.LEFT);
                    Thread.Sleep(500);
                    Clipboard.Clear();
                    ins.Keyboard.KeyDown(VirtualKeyCode.CONTROL);
                    Thread.Sleep(500);
                    ins.Keyboard.KeyPress(VirtualKeyCode.VK_C);
                    Thread.Sleep(500);
                    ins.Keyboard.KeyUp(VirtualKeyCode.CONTROL);
                    Thread.Sleep(500);
                    var X = Clipboard.GetText();
                    if (X.Length <= 0)
                    {
                        AutoItX.WinClose("Consultar Estabelecimento");
                        Thread.Sleep(1000);
                        MessageBox.Show("Refazer manualmente apartir de 'Consultar Filial'");
                    }
                }

            }
            ins.Keyboard.KeyPress(VirtualKeyCode.RETURN);
        }

        internal static void ConsultarFilial()
        {
            Thread.Sleep(1000);
            AutoItX.WinWaitActive("Consultar Filial");
            Thread.Sleep(1000);
            for (int i = 1; i <= 4; i++)
            {
                ins.Keyboard.KeyPress(VirtualKeyCode.RIGHT);
                Thread.Sleep(1000);
            }
            ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            Thread.Sleep(500);
            ins.Keyboard.KeyPress(VirtualKeyCode.DOWN);
            Thread.Sleep(500);
            ins.Keyboard.KeyPress(VirtualKeyCode.RIGHT);
            Thread.Sleep(500);
            Clipboard.Clear();
            Thread.Sleep(500);
            ins.Keyboard.KeyDown(VirtualKeyCode.CONTROL);
            Thread.Sleep(300);
            ins.Keyboard.KeyPress(VirtualKeyCode.VK_C);
            Thread.Sleep(300);
            ins.Keyboard.KeyUp(VirtualKeyCode.CONTROL);
            var x = Clipboard.GetText();
            Thread.Sleep(1000);
            ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            Thread.Sleep(500);
            ins.Keyboard.KeyPress(VirtualKeyCode.RETURN);
            if (x != "MATERIAL DE TERCEIRO")
            {
                AutoItX.WinClose("Consultar Filial");
                Thread.Sleep(1000);
                MessageBox.Show("ERRO: Refazer manualmente Apartir de 'Consultar Dados das Filiais'");
            }
        }

        internal static void ConsultarDadosDasFiliais()
        {
            Thread.Sleep(1000);
            ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            Thread.Sleep(500);
            ins.Keyboard.KeyPress(VirtualKeyCode.RETURN);
            Thread.Sleep(3000);
            for (int i = 1; i <= 6; i++)
            {
                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                Thread.Sleep(500);
            }
            ins.Keyboard.KeyPress(VirtualKeyCode.RETURN);
        }

        public static void Movimentos()
        {
            Thread.Sleep(1000);
            AutoItX.WinWaitActive("Consultar Movimentos de Estoque - Quantitativos");
            Thread.Sleep(1000);

            for (int i = 1; i <= 4; i++)
            {
                Thread.Sleep(100);
                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            }
            Thread.Sleep(100);
            ins.Keyboard.KeyPress(VirtualKeyCode.SPACE);
            Thread.Sleep(5000);

            ins.Keyboard.KeyPress(VirtualKeyCode.LWIN);
            Thread.Sleep(500);
            ins.Keyboard.KeyPress(VirtualKeyCode.LWIN);


            for (int i = 1; i <= 16; i++)
            {
                Thread.Sleep(100);
                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            }
            Thread.Sleep(100);


            Clipboard.Clear();
            Thread.Sleep(500);
            ins.Keyboard.KeyDown(VirtualKeyCode.CONTROL);
            Thread.Sleep(100);
            ins.Keyboard.KeyPress(VirtualKeyCode.VK_C);
            Thread.Sleep(100);
            ins.Keyboard.KeyUp(VirtualKeyCode.CONTROL);
            Thread.Sleep(500);

            var data = DateTime.Today;
            var n = data.AddMonths(-2);
            var d = n.AddDays(-data.Day + 1);
            ins.Keyboard.TextEntry(d.ToString("dd/MM/yyyy"));


            for (int i = 1; i <= 2; i++)
            {
                Thread.Sleep(100);
                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            }
            Thread.Sleep(100);

            for (int i = 1; i <= 8; i++)
            {
                Thread.Sleep(100);
                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            }
            Thread.Sleep(1000);

            ins.Keyboard.KeyPress(VirtualKeyCode.RETURN);
            Thread.Sleep(5000);

            ins.Keyboard.KeyDown(VirtualKeyCode.SHIFT);
            Thread.Sleep(100);
            for (int i = 1; i <= 30; i++)
            {
                Thread.Sleep(100);
                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            }
            Thread.Sleep(100);
            ins.Keyboard.KeyUp(VirtualKeyCode.SHIFT);
            Thread.Sleep(100);

            ins.Keyboard.KeyPress(VirtualKeyCode.RETURN);

            Thread.Sleep(5000);
        }

        internal static void EliminarPrateleira(string item)
        {

            //CODIGO


            ////DELETA VALOR 100
            if (t)
            {
                for (int i = 1; i <= 15; i++)
                {
                    Thread.Sleep(500);
                    ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                }
                Thread.Sleep(500);
                ins.Keyboard.KeyPress(VirtualKeyCode.DELETE);
                //ESCREVE 1
                ins.Keyboard.KeyPress(VirtualKeyCode.VK_1);

                for (int i = 1; i <= 8; i++)
                {
                    Thread.Sleep(500);
                    ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                }
                t = false;
            }
            else
            {
                for (int i = 1; i <= 6; i++)
                {
                    Thread.Sleep(500);
                    ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                }
            }


            Thread.Sleep(500);
            ins.Keyboard.TextEntry(item);
            Thread.Sleep(500);

            btnExecutar();
            Thread.Sleep(5000);

            btnAlterar();

            Thread.Sleep(3000);

            AguardaJanelaAtivar("Alterar Item de Estoque", 60);
            Thread.Sleep(3000);


            ins.Keyboard.KeyDown(VirtualKeyCode.SHIFT);
            Thread.Sleep(500);
            ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            Thread.Sleep(500);
            ins.Keyboard.KeyUp(VirtualKeyCode.SHIFT);
            Thread.Sleep(1000);

            for (int i = 1; i <= 2; i++)
            {
                ins.Keyboard.KeyPress(VirtualKeyCode.RIGHT);
                Thread.Sleep(3000);
            }
            ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            Thread.Sleep(500);
            ins.Keyboard.KeyPress(VirtualKeyCode.BACK);
            Thread.Sleep(500);


            btnOK();

            AutoItX.WinWaitClose("Alterar Item de Estoque");


            Thread.Sleep(5000);

            ins.Keyboard.KeyDown(VirtualKeyCode.SHIFT);
            Thread.Sleep(500);
            ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            Thread.Sleep(500);
            ins.Keyboard.KeyUp(VirtualKeyCode.SHIFT);
            Thread.Sleep(1000);

            ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
        }

        internal static void AlterarPrateleira(string cod, string prat)
        {
            Thread.Sleep(500);
            ins.Keyboard.TextEntry(cod);
            Thread.Sleep(500);

            btnExecutar();
            Thread.Sleep(1000);
            ProcuraRecurso("btnEditarRegistro.PNG", 20, 456, 639, 47, 29, false, false);
            Thread.Sleep(500);

            btnAlterar();

            //
            AguardaJanelaAtivar("Alterar Item de Estoque", 60);
            Thread.Sleep(1000);

            ProcuraRecurso("btnOK.PNG", 0, 639, 585, 36, 29, false, false);
            //


            
            Thread.Sleep(1000);

            ProcuraRecurso("Suprimentos1.PNG", 20, 351, 41, 100, 40, true, false);

            Thread.Sleep(1000);

            ProcuraRecurso("Suprimentos2.PNG", 20, 351, 41, 100, 40, false, false);

            prat = prat == string.Empty ? " " : prat;
            ins.Keyboard.TextEntry(prat);
            Thread.Sleep(100);


            btnOK();

            AutoItX.WinWaitClose("Alterar Item de Estoque");


            ProcuraRecurso("btnEditarRegistro.PNG", 20, 456, 639, 47, 29, false, false);
            Thread.Sleep(1000);

            //reposiciona o cursor
            for (int i = 1; i <= 18; i++)
            {
                Thread.Sleep(100);
                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            }

        }

        private static void PreparaJanelaItens()
        {
            for (int i = 1; i <= 15; i++)
            {
                Thread.Sleep(100);
                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            }
            Thread.Sleep(500);
            ins.Keyboard.KeyPress(VirtualKeyCode.DELETE);
            //ESCREVE 1
            ins.Keyboard.KeyPress(VirtualKeyCode.VK_1);

            for (int i = 1; i <= 8; i++)
            {
                Thread.Sleep(100);
                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            }
        }

        internal static void EliminarPrateleiraeTerceiros(string item, int deposito)
        {

            SelecionarDeposito(deposito);
            PosicionaCodigo();

            Thread.Sleep(500);
            ins.Keyboard.TextEntry(item);
            Thread.Sleep(500);

            btnExecutar();
            Thread.Sleep(5000);

            btnAlterar();

            Thread.Sleep(3000);

            AguardaJanelaAtivar("Alterar Item de Estoque", 60);
            Thread.Sleep(3000);


            ins.Keyboard.KeyDown(VirtualKeyCode.SHIFT);
            Thread.Sleep(500);
            ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            Thread.Sleep(500);
            ins.Keyboard.KeyUp(VirtualKeyCode.SHIFT);
            Thread.Sleep(1000);

            for (int i = 1; i <= 2; i++)
            {
                ins.Keyboard.KeyPress(VirtualKeyCode.RIGHT);
                Thread.Sleep(3000);
            }
            ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            Thread.Sleep(500);
            ins.Keyboard.KeyPress(VirtualKeyCode.BACK);
            Thread.Sleep(500);

            // FechaJanela();

            btnOK();

            AutoItX.WinWaitClose("Alterar Item de Estoque");


            Thread.Sleep(5000);

            ins.Keyboard.KeyDown(VirtualKeyCode.SHIFT);
            Thread.Sleep(500);
            ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            Thread.Sleep(500);
            ins.Keyboard.KeyUp(VirtualKeyCode.SHIFT);
            Thread.Sleep(1000);

            ins.Keyboard.KeyPress(VirtualKeyCode.TAB);


        }

        private static void PosicionaCodigo()
        {
            Thread.Sleep(500);
            for (int i = 1; i <= 4; i++)
            {
                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                Thread.Sleep(500);
            }
        }

        private static void SelecionarDeposito(int novodeposito)
        {
            ins.Keyboard.KeyPress(VirtualKeyCode.HOME);
            Thread.Sleep(4000);

            if (novodeposito == 1)
            {
                return;
            }

            var n = Convert.ToInt32(novodeposito.ToString().ToCharArray()[0].ToString());

            var d = Depositos(novodeposito);
            for (int i = 0; i < d; i++)
            {
                switch (n)
                {
                    case 1: ins.Keyboard.KeyPress(VirtualKeyCode.VK_1); break;
                    case 2: ins.Keyboard.KeyPress(VirtualKeyCode.VK_2); break;
                    case 3: ins.Keyboard.KeyPress(VirtualKeyCode.VK_3); break;
                    case 4: ins.Keyboard.KeyPress(VirtualKeyCode.VK_4); break;
                    case 5: ins.Keyboard.KeyPress(VirtualKeyCode.VK_5); break;
                    case 6: ins.Keyboard.KeyPress(VirtualKeyCode.VK_6); break;
                    case 7: ins.Keyboard.KeyPress(VirtualKeyCode.VK_7); break;
                    case 8: ins.Keyboard.KeyPress(VirtualKeyCode.VK_8); break;
                    case 9: ins.Keyboard.KeyPress(VirtualKeyCode.VK_9); break;
                }
                Thread.Sleep(4000);
            }
        }

        private static int Depositos(int deposito)
        {
            int valor = 0;
            switch (deposito)
            {
                case 1: valor = 0; break;
                case 2: valor = 1; break;
                case 3: valor = 1; break;
                case 4: valor = 1; break;
                case 5: valor = 1; break;
                case 6: valor = 1; break;
                case 7: valor = 1; break;
                case 8: valor = 1; break;
                case 9: valor = 1; break;
                case 10: valor = 1; break;
                case 11: valor = 2; break;
                case 12: valor = 3; break;
                case 13: valor = 4; break;
                case 14: valor = 5; break;
                case 15: valor = 6; break;
                case 16: valor = 7; break;
                case 17: valor = 8; break;
                case 18: valor = 9; break;
                case 19: valor = 10; break;
                case 20: valor = 2; break;
                case 21: valor = 3; break;
                case 22: valor = 4; break;
                case 23: valor = 5; break;
                case 24: valor = 6; break;
                case 25: valor = 7; break;
                case 26: valor = 8; break;
                case 27: valor = 9; break;
                case 28: valor = 10; break;
                case 29: valor = 11; break;
                case 30: valor = 2; break;
                case 31: valor = 3; break;
                case 32: valor = 4; break;
                case 33: valor = 5; break;
                case 34: valor = 6; break;
                case 35: valor = 7; break;
                case 36: valor = 8; break;
                case 37: valor = 9; break;
                case 38: valor = 10; break;
                case 39: valor = 11; break;
                case 40: valor = 2; break;
                case 41: valor = 3; break;
                case 42: valor = 4; break;
                case 43: valor = 5; break;
                case 44: valor = 6; break;
                case 45: valor = 7; break;
                case 46: valor = 8; break;
                case 47: valor = 9; break;
                case 48: valor = 10; break;
                case 49: valor = 11; break;
                case 50: valor = 2; break;
                case 51: valor = 3; break;
                case 52: valor = 4; break;
                case 53: valor = 5; break;
                case 54: valor = 6; break;
                case 55: valor = 7; break;
                case 56: valor = 8; break;
                case 57: valor = 9; break;
                case 58: valor = 10; break;
                case 59: valor = 11; break;
                case 60: valor = 2; break;
                case 61: valor = 3; break;
                case 62: valor = 4; break;
                case 63: valor = 5; break;
                case 64: valor = 6; break;
                case 65: valor = 7; break;
                case 66: valor = 8; break;
                case 67: valor = 9; break;
                case 68: valor = 10; break;
                case 69: valor = 11; break;
                case 70: valor = 2; break;
                case 71: valor = 3; break;
                case 72: valor = 4; break;
                case 73: valor = 5; break;
                case 74: valor = 6; break;
                case 75: valor = 7; break;
                case 76: valor = 8; break;
                case 77: valor = 9; break;
                case 78: valor = 10; break;
                case 79: valor = 11; break;
                case 80: valor = 2; break;
                case 81: valor = 3; break;
                case 82: valor = 4; break;
                case 83: valor = 5; break;
                case 84: valor = 6; break;
                case 85: valor = 7; break;
                case 86: valor = 8; break;
                case 87: valor = 9; break;
                case 88: valor = 10; break;
                case 89: valor = 11; break;
                case 90: valor = 2; break;
                case 91: valor = 3; break;
                case 92: valor = 4; break;
                case 93: valor = 5; break;
                case 94: valor = 6; break;
                case 95: valor = 7; break;
                case 96: valor = 8; break;
                case 97: valor = 9; break;
                case 98: valor = 10; break;
                case 99: valor = 11; break;
                case 100: valor = 11; break;
                case 101: valor = 12; break;
                case 102: valor = 13; break;
                case 103: valor = 14; break;
                case 104: valor = 15; break;
                case 105: valor = 16; break;
                case 106: valor = 17; break;
                case 107: valor = 18; break;
                case 108: valor = 19; break;
                case 109: valor = 20; break;
                case 110: valor = 21; break;
                case 111: valor = 22; break;
                case 112: valor = 23; break;
                case 113: valor = 24; break;
                case 114: valor = 25; break;
                case 115: valor = 26; break;
                case 116: valor = 27; break;
                case 117: valor = 28; break;
                case 118: valor = 29; break;
                case 119: valor = 30; break;
                case 120: valor = 31; break;
                case 121: valor = 32; break;
                case 122: valor = 33; break;
                case 123: valor = 34; break;
                case 124: valor = 35; break;
                case 125: valor = 36; break;
                case 126: valor = 37; break;
                case 127: valor = 38; break;
                case 128: valor = 39; break;
                case 129: valor = 40; break;
                case 130: valor = 41; break;
                case 131: valor = 42; break;
                case 132: valor = 43; break;
                case 133: valor = 44; break;
                case 134: valor = 45; break;
                case 135: valor = 46; break;
                case 136: valor = 47; break;
                case 137: valor = 48; break;
                case 138: valor = 49; break;
                case 139: valor = 50; break;
                case 140: valor = 51; break;
                case 141: valor = 52; break;
                case 142: valor = 53; break;
                case 143: valor = 54; break;
                case 144: valor = 55; break;
                case 145: valor = 56; break;
                case 146: valor = 57; break;
                case 147: valor = 58; break;
                case 148: valor = 59; break;
                case 149: valor = 60; break;
                case 150: valor = 61; break;
                case 151: valor = 62; break;
                case 152: valor = 63; break;
                case 153: valor = 64; break;
                case 154: valor = 65; break;
                case 155: valor = 66; break;
                case 156: valor = 67; break;
                case 157: valor = 68; break;
                case 158: valor = 69; break;
                case 159: valor = 70; break;
                case 160: valor = 71; break;
                case 161: valor = 72; break;
                case 162: valor = 73; break;
                case 163: valor = 74; break;
                case 164: valor = 75; break;
                case 165: valor = 76; break;
                case 166: valor = 77; break;
                case 167: valor = 78; break;
                case 168: valor = 79; break;
                case 169: valor = 80; break;
                case 170: valor = 81; break;
                case 171: valor = 82; break;
                case 172: valor = 83; break;
                case 173: valor = 84; break;
                case 174: valor = 85; break;
                case 175: valor = 86; break;
                case 176: valor = 87; break;
                case 177: valor = 88; break;
                case 178: valor = 89; break;
                case 179: valor = 90; break;
                case 180: valor = 91; break;
                case 181: valor = 92; break;
                case 182: valor = 93; break;
                case 183: valor = 94; break;
                case 184: valor = 95; break;
                case 185: valor = 96; break;
                case 186: valor = 97; break;
                case 187: valor = 98; break;
                case 188: valor = 99; break;
                case 189: valor = 100; break;
                case 190: valor = 101; break;
                case 191: valor = 102; break;
                case 192: valor = 103; break;
                case 193: valor = 104; break;
                case 194: valor = 105; break;
                case 195: valor = 106; break;
                case 196: valor = 107; break;
                case 197: valor = 108; break;
                case 198: valor = 109; break;
                case 199: valor = 110; break;
                case 200: valor = 12; break;
                case 201: valor = 13; break;
                case 202: valor = 14; break;
                case 203: valor = 15; break;
                case 204: valor = 16; break;
                case 205: valor = 17; break;
                case 206: valor = 18; break;
                case 207: valor = 19; break;
                case 208: valor = 20; break;
                case 209: valor = 21; break;
                case 210: valor = 22; break;
                case 211: valor = 23; break;
                case 212: valor = 24; break;
                case 213: valor = 25; break;
                case 214: valor = 26; break;
                case 215: valor = 27; break;
                case 216: valor = 28; break;
                case 217: valor = 29; break;
                case 218: valor = 30; break;
                case 219: valor = 31; break;
                case 220: valor = 32; break;
                case 221: valor = 33; break;
                case 222: valor = 34; break;
                case 223: valor = 35; break;
                case 224: valor = 36; break;
                case 225: valor = 37; break;
                case 226: valor = 38; break;
                case 227: valor = 39; break;
                case 228: valor = 40; break;
                case 229: valor = 41; break;
                case 230: valor = 42; break;
                case 231: valor = 43; break;
                case 232: valor = 44; break;
                case 233: valor = 45; break;
                case 234: valor = 46; break;
                case 235: valor = 47; break;
                case 236: valor = 48; break;
                case 237: valor = 49; break;
                case 238: valor = 50; break;
                case 239: valor = 51; break;
                case 240: valor = 52; break;
                case 241: valor = 53; break;
                case 242: valor = 54; break;
                case 243: valor = 55; break;
                case 244: valor = 56; break;
                case 245: valor = 57; break;
                case 246: valor = 58; break;
                case 247: valor = 59; break;
                case 248: valor = 60; break;
                case 249: valor = 61; break;
                case 250: valor = 62; break;
                case 251: valor = 63; break;
                case 252: valor = 64; break;
                case 253: valor = 65; break;
                case 254: valor = 66; break;
                case 255: valor = 67; break;
                case 256: valor = 68; break;
                case 257: valor = 69; break;
                case 258: valor = 70; break;
                case 259: valor = 71; break;
                case 260: valor = 72; break;
                case 261: valor = 73; break;
                case 262: valor = 74; break;
                case 263: valor = 75; break;
                case 264: valor = 76; break;
                case 265: valor = 77; break;
                case 266: valor = 78; break;
                case 267: valor = 79; break;
                case 268: valor = 80; break;
                case 269: valor = 81; break;
                case 270: valor = 82; break;
                case 271: valor = 83; break;
                case 272: valor = 84; break;
                case 273: valor = 85; break;
                case 274: valor = 86; break;
                case 275: valor = 87; break;
                case 276: valor = 88; break;
                case 277: valor = 89; break;
                case 278: valor = 90; break;
                case 279: valor = 91; break;
                case 280: valor = 92; break;
                case 281: valor = 93; break;
                case 282: valor = 94; break;
                case 283: valor = 95; break;
                case 284: valor = 96; break;
                case 285: valor = 97; break;
                case 286: valor = 98; break;
                case 287: valor = 99; break;
                case 288: valor = 100; break;
                case 289: valor = 101; break;
                case 290: valor = 102; break;
                case 291: valor = 103; break;
                case 292: valor = 104; break;
                case 293: valor = 105; break;
                case 294: valor = 106; break;
                case 295: valor = 107; break;
                case 296: valor = 108; break;
                case 297: valor = 109; break;
                case 298: valor = 110; break;
                case 299: valor = 111; break;
                case 300: valor = 12; break;
                case 301: valor = 13; break;
                case 302: valor = 14; break;
                case 303: valor = 15; break;
                case 304: valor = 16; break;
                case 305: valor = 17; break;
                case 306: valor = 18; break;
                case 307: valor = 19; break;
                case 308: valor = 20; break;
                case 309: valor = 21; break;
                case 310: valor = 22; break;
                case 311: valor = 23; break;
                case 312: valor = 24; break;
                case 313: valor = 25; break;
                case 314: valor = 26; break;
                case 315: valor = 27; break;
                case 316: valor = 28; break;
                case 317: valor = 29; break;
                case 318: valor = 30; break;
                case 319: valor = 31; break;
                case 320: valor = 32; break;
                case 321: valor = 33; break;
                case 322: valor = 34; break;
                case 323: valor = 35; break;
                case 324: valor = 36; break;
                case 325: valor = 37; break;
                case 326: valor = 38; break;
                case 327: valor = 39; break;
                case 328: valor = 40; break;
                case 329: valor = 41; break;
                case 330: valor = 42; break;
                case 331: valor = 43; break;
                case 332: valor = 44; break;
                case 333: valor = 45; break;
                case 334: valor = 46; break;
                case 335: valor = 47; break;
                case 336: valor = 48; break;
                case 337: valor = 49; break;
                case 338: valor = 50; break;
                case 339: valor = 51; break;
                case 340: valor = 52; break;
                case 341: valor = 53; break;
                case 342: valor = 54; break;
                case 343: valor = 55; break;
                case 344: valor = 56; break;
                case 345: valor = 57; break;
                case 346: valor = 58; break;
                case 347: valor = 59; break;
                case 348: valor = 60; break;
                case 349: valor = 61; break;
                case 350: valor = 62; break;
                case 351: valor = 63; break;
                case 352: valor = 64; break;
                case 353: valor = 65; break;
                case 354: valor = 66; break;
                case 355: valor = 67; break;
                case 356: valor = 68; break;
                case 357: valor = 69; break;
                case 358: valor = 70; break;
                case 359: valor = 71; break;
                case 360: valor = 72; break;
                case 361: valor = 73; break;
                case 362: valor = 74; break;
                case 363: valor = 75; break;
                case 364: valor = 76; break;
                case 365: valor = 77; break;
                case 366: valor = 78; break;
                case 367: valor = 79; break;
                case 368: valor = 80; break;
                case 369: valor = 81; break;
                case 370: valor = 82; break;
                case 371: valor = 83; break;
                case 372: valor = 84; break;
                case 373: valor = 85; break;
                case 374: valor = 86; break;
                case 375: valor = 87; break;
                case 376: valor = 88; break;
                case 377: valor = 89; break;
                case 378: valor = 90; break;
                case 379: valor = 91; break;
                case 380: valor = 92; break;
                case 381: valor = 93; break;
                case 382: valor = 94; break;
                case 383: valor = 95; break;
                case 384: valor = 96; break;
                case 385: valor = 97; break;
                case 386: valor = 98; break;
                case 387: valor = 99; break;
                case 388: valor = 100; break;
                case 389: valor = 101; break;
                case 390: valor = 102; break;
                case 391: valor = 103; break;
                case 392: valor = 104; break;
                case 393: valor = 105; break;
                case 394: valor = 106; break;
                case 395: valor = 107; break;
                case 396: valor = 108; break;
                case 397: valor = 109; break;
                case 398: valor = 110; break;
                case 399: valor = 111; break;
                case 400: valor = 12; break;
                case 401: valor = 13; break;
                case 402: valor = 14; break;
                case 403: valor = 15; break;
                case 404: valor = 16; break;
                case 405: valor = 17; break;
                case 406: valor = 18; break;
                case 407: valor = 19; break;
                case 408: valor = 20; break;
                case 409: valor = 21; break;
                case 410: valor = 22; break;
                case 411: valor = 23; break;
                case 412: valor = 24; break;
                case 413: valor = 25; break;
                case 414: valor = 26; break;
                case 415: valor = 27; break;
                case 416: valor = 28; break;
                case 417: valor = 29; break;
                case 418: valor = 30; break;
                case 419: valor = 31; break;
                case 420: valor = 32; break;
                case 421: valor = 33; break;
                case 422: valor = 34; break;
                case 423: valor = 35; break;
                case 424: valor = 36; break;
                case 425: valor = 37; break;
                case 426: valor = 38; break;
                case 427: valor = 39; break;
                case 428: valor = 40; break;
                case 429: valor = 41; break;
                case 430: valor = 42; break;
                case 431: valor = 43; break;
                case 432: valor = 44; break;
                case 433: valor = 45; break;
                case 434: valor = 46; break;
                case 435: valor = 47; break;
                case 436: valor = 48; break;
                case 437: valor = 49; break;
                case 438: valor = 50; break;
                case 439: valor = 51; break;
                case 440: valor = 52; break;
                case 441: valor = 53; break;
                case 442: valor = 54; break;
                case 443: valor = 55; break;
                case 444: valor = 56; break;
                case 445: valor = 57; break;
                case 446: valor = 58; break;
                case 447: valor = 59; break;
                case 448: valor = 60; break;
                case 449: valor = 61; break;
                case 450: valor = 62; break;
                case 451: valor = 63; break;
                case 452: valor = 64; break;
                case 453: valor = 65; break;
                case 454: valor = 66; break;
                case 455: valor = 67; break;
                case 456: valor = 68; break;
                case 457: valor = 69; break;
                case 458: valor = 70; break;
                case 459: valor = 71; break;
                case 460: valor = 72; break;
                case 461: valor = 73; break;
                case 462: valor = 74; break;
                case 463: valor = 75; break;
                case 464: valor = 76; break;
                case 465: valor = 77; break;
                case 466: valor = 78; break;
                case 467: valor = 79; break;
                case 468: valor = 80; break;
                case 469: valor = 81; break;
                case 470: valor = 82; break;
                case 471: valor = 83; break;
                case 472: valor = 84; break;
                case 473: valor = 85; break;
                case 474: valor = 86; break;
                case 475: valor = 87; break;
                case 476: valor = 88; break;
                case 477: valor = 89; break;
                case 478: valor = 90; break;
                case 479: valor = 91; break;
                case 480: valor = 92; break;
                case 481: valor = 93; break;
                case 482: valor = 94; break;
                case 483: valor = 95; break;
                case 484: valor = 96; break;
                case 485: valor = 97; break;
                case 486: valor = 98; break;
                case 487: valor = 99; break;
                case 488: valor = 100; break;
                case 489: valor = 101; break;
                case 490: valor = 102; break;
                case 491: valor = 103; break;
                case 492: valor = 104; break;
                case 493: valor = 105; break;
                case 494: valor = 106; break;
                case 495: valor = 107; break;
                case 496: valor = 108; break;
                case 497: valor = 109; break;
                case 498: valor = 110; break;
                case 499: valor = 111; break;
                case 500: valor = 12; break;
                case 501: valor = 13; break;
                case 502: valor = 14; break;
                case 503: valor = 15; break;
                case 504: valor = 16; break;
                case 505: valor = 17; break;
                case 506: valor = 18; break;
                case 507: valor = 19; break;
                case 508: valor = 20; break;
                case 509: valor = 21; break;
                case 510: valor = 22; break;
                case 511: valor = 23; break;
                case 512: valor = 24; break;
                case 513: valor = 25; break;
                case 514: valor = 26; break;
                case 515: valor = 27; break;
                case 516: valor = 28; break;
                case 517: valor = 29; break;
                case 518: valor = 30; break;
                case 519: valor = 31; break;
                case 520: valor = 32; break;
                case 521: valor = 33; break;
                case 522: valor = 34; break;
                case 523: valor = 35; break;
                case 524: valor = 36; break;
                case 525: valor = 37; break;
                case 526: valor = 38; break;
                case 527: valor = 39; break;
                case 528: valor = 40; break;
                case 529: valor = 41; break;
                case 530: valor = 42; break;
                case 531: valor = 43; break;
                case 532: valor = 44; break;
                case 533: valor = 45; break;
                case 534: valor = 46; break;
                case 535: valor = 47; break;
                case 536: valor = 48; break;
                case 537: valor = 49; break;
                case 538: valor = 50; break;
                case 539: valor = 51; break;
                case 540: valor = 52; break;
                case 541: valor = 53; break;
                case 542: valor = 54; break;
                case 543: valor = 55; break;
                case 544: valor = 56; break;
                case 545: valor = 57; break;
                case 546: valor = 58; break;
                case 547: valor = 59; break;
                case 548: valor = 60; break;
                case 549: valor = 61; break;
                case 550: valor = 62; break;
                case 551: valor = 63; break;
                case 552: valor = 64; break;
                case 553: valor = 65; break;
                case 554: valor = 66; break;
                case 555: valor = 67; break;
                case 556: valor = 68; break;
                case 557: valor = 69; break;
                case 558: valor = 70; break;
                case 559: valor = 71; break;
                case 560: valor = 72; break;
                case 561: valor = 73; break;
                case 562: valor = 74; break;
                case 563: valor = 75; break;
                case 564: valor = 76; break;
                case 565: valor = 77; break;
                case 566: valor = 78; break;
                case 567: valor = 79; break;
                case 568: valor = 80; break;
                case 569: valor = 81; break;
                case 570: valor = 82; break;
                case 571: valor = 83; break;
                case 572: valor = 84; break;
                case 573: valor = 85; break;
                case 574: valor = 86; break;
                case 575: valor = 87; break;
                case 576: valor = 88; break;
                case 577: valor = 89; break;
                case 578: valor = 90; break;
                case 579: valor = 91; break;
                case 580: valor = 92; break;
                case 581: valor = 93; break;
                case 582: valor = 94; break;
                case 583: valor = 95; break;
                case 584: valor = 96; break;
                case 585: valor = 97; break;
                case 586: valor = 98; break;
                case 587: valor = 99; break;
                case 588: valor = 100; break;
                case 589: valor = 101; break;
                case 590: valor = 102; break;
                case 591: valor = 103; break;
                case 592: valor = 104; break;
                case 593: valor = 105; break;
                case 594: valor = 106; break;
                case 595: valor = 107; break;
                case 596: valor = 108; break;
                case 597: valor = 109; break;
                case 598: valor = 110; break;
                case 599: valor = 111; break;
                case 600: valor = 12; break;
                case 601: valor = 13; break;
                case 602: valor = 14; break;
                case 603: valor = 15; break;
                case 604: valor = 16; break;
                case 605: valor = 17; break;
                case 606: valor = 18; break;
                case 607: valor = 19; break;
                case 608: valor = 20; break;
                case 609: valor = 21; break;
                case 610: valor = 22; break;
                case 611: valor = 23; break;
                case 612: valor = 24; break;
                case 613: valor = 25; break;
                case 614: valor = 26; break;
                case 615: valor = 27; break;
                case 616: valor = 28; break;
                case 617: valor = 29; break;
                case 618: valor = 30; break;
                case 619: valor = 31; break;
                case 620: valor = 32; break;
                case 621: valor = 33; break;
                case 622: valor = 34; break;
                case 623: valor = 35; break;
                case 624: valor = 36; break;
                case 625: valor = 37; break;
                case 626: valor = 38; break;
                case 627: valor = 39; break;
                case 628: valor = 40; break;
                case 629: valor = 41; break;
                case 630: valor = 42; break;
                case 631: valor = 43; break;
                case 632: valor = 44; break;
                case 633: valor = 45; break;
                case 634: valor = 46; break;
                case 635: valor = 47; break;
                case 636: valor = 48; break;
                case 637: valor = 49; break;
                case 638: valor = 50; break;
                case 639: valor = 51; break;
                case 640: valor = 52; break;
                case 641: valor = 53; break;
                case 642: valor = 54; break;
                case 643: valor = 55; break;
                case 644: valor = 56; break;
                case 645: valor = 57; break;
                case 646: valor = 58; break;
                case 647: valor = 59; break;
                case 648: valor = 60; break;
                case 649: valor = 61; break;
                case 650: valor = 62; break;
                case 651: valor = 63; break;
                case 652: valor = 64; break;
                case 653: valor = 65; break;
                case 654: valor = 66; break;
                case 655: valor = 67; break;
                case 656: valor = 68; break;
                case 657: valor = 69; break;
                case 658: valor = 70; break;
                case 659: valor = 71; break;
                case 660: valor = 72; break;
                case 661: valor = 73; break;
                case 662: valor = 74; break;
                case 663: valor = 75; break;
                case 664: valor = 76; break;
                case 665: valor = 77; break;
                case 666: valor = 78; break;
                case 667: valor = 79; break;
                case 668: valor = 80; break;
                case 669: valor = 81; break;
                case 670: valor = 82; break;
                case 671: valor = 83; break;
                case 672: valor = 84; break;
                case 673: valor = 85; break;
                case 674: valor = 86; break;
                case 675: valor = 87; break;
                case 676: valor = 88; break;
                case 677: valor = 89; break;
                case 678: valor = 90; break;
                case 679: valor = 91; break;
                case 680: valor = 92; break;
                case 681: valor = 93; break;
                case 682: valor = 94; break;
                case 683: valor = 95; break;
                case 684: valor = 96; break;
                case 685: valor = 97; break;
                case 686: valor = 98; break;
                case 687: valor = 99; break;
                case 688: valor = 100; break;
                case 689: valor = 101; break;
                case 690: valor = 102; break;
                case 691: valor = 103; break;
                case 692: valor = 104; break;
                case 693: valor = 105; break;
                case 694: valor = 106; break;
                case 695: valor = 107; break;
                case 696: valor = 108; break;
                case 697: valor = 109; break;
                case 698: valor = 110; break;
                case 699: valor = 111; break;
                case 700: valor = 12; break;
                case 701: valor = 13; break;
                case 702: valor = 14; break;
                case 703: valor = 15; break;
                case 704: valor = 16; break;
                case 705: valor = 17; break;
                case 706: valor = 18; break;
                case 707: valor = 19; break;
                case 708: valor = 20; break;
                case 709: valor = 21; break;
                case 710: valor = 22; break;
                case 711: valor = 23; break;
                case 712: valor = 24; break;
                case 713: valor = 25; break;
                case 714: valor = 26; break;
                case 715: valor = 27; break;
                case 716: valor = 28; break;
                case 717: valor = 29; break;
                case 718: valor = 30; break;
                case 719: valor = 31; break;
                case 720: valor = 32; break;
                case 721: valor = 33; break;
                case 722: valor = 34; break;
                case 723: valor = 35; break;
                case 724: valor = 36; break;
                case 725: valor = 37; break;
                case 726: valor = 38; break;
                case 727: valor = 39; break;
                case 728: valor = 40; break;
                case 729: valor = 41; break;
                case 730: valor = 42; break;
                case 731: valor = 43; break;
                case 732: valor = 44; break;
                case 733: valor = 45; break;
                case 734: valor = 46; break;
                case 735: valor = 47; break;
                case 736: valor = 48; break;
                case 737: valor = 49; break;
                case 738: valor = 50; break;
                case 739: valor = 51; break;
                case 740: valor = 52; break;
                case 741: valor = 53; break;
                case 742: valor = 54; break;
                case 743: valor = 55; break;
                case 744: valor = 56; break;
                case 745: valor = 57; break;
                case 746: valor = 58; break;
                case 747: valor = 59; break;
                case 748: valor = 60; break;
                case 749: valor = 61; break;
                case 750: valor = 62; break;
                case 751: valor = 63; break;
                case 752: valor = 64; break;
                case 753: valor = 65; break;
                case 754: valor = 66; break;
                case 755: valor = 67; break;
                case 756: valor = 68; break;
                case 757: valor = 69; break;
                case 758: valor = 70; break;
                case 759: valor = 71; break;
                case 760: valor = 72; break;
                case 761: valor = 73; break;
                case 762: valor = 74; break;
                case 763: valor = 75; break;
                case 764: valor = 76; break;
                case 765: valor = 77; break;
                case 766: valor = 78; break;
                case 767: valor = 79; break;
                case 768: valor = 80; break;
                case 769: valor = 81; break;
                case 770: valor = 82; break;
                case 771: valor = 83; break;
                case 772: valor = 84; break;
                case 773: valor = 85; break;
                case 774: valor = 86; break;
                case 775: valor = 87; break;
                case 776: valor = 88; break;
                case 777: valor = 89; break;
                case 778: valor = 90; break;
                case 779: valor = 91; break;
                case 780: valor = 92; break;
                case 781: valor = 93; break;
                case 782: valor = 94; break;
                case 783: valor = 95; break;
                case 784: valor = 96; break;
                case 785: valor = 97; break;
                case 786: valor = 98; break;
                case 787: valor = 99; break;
                case 788: valor = 100; break;
                case 789: valor = 101; break;
                case 790: valor = 102; break;
                case 791: valor = 103; break;
                case 792: valor = 104; break;
                case 793: valor = 105; break;
                case 794: valor = 106; break;
                case 795: valor = 107; break;
                case 796: valor = 108; break;
                case 797: valor = 109; break;
                case 798: valor = 110; break;
                case 799: valor = 111; break;
                case 800: valor = 12; break;
                case 801: valor = 13; break;
                case 802: valor = 14; break;
                case 803: valor = 15; break;
                case 804: valor = 16; break;
                case 805: valor = 17; break;
                case 806: valor = 18; break;
                case 807: valor = 19; break;
                case 808: valor = 20; break;
                case 809: valor = 21; break;
                case 810: valor = 22; break;
                case 811: valor = 23; break;
                case 812: valor = 24; break;
                case 813: valor = 25; break;
                case 814: valor = 26; break;
                case 815: valor = 27; break;
                case 816: valor = 28; break;
                case 817: valor = 29; break;
                case 818: valor = 30; break;
                case 819: valor = 31; break;
                case 820: valor = 32; break;
                case 821: valor = 33; break;
                case 822: valor = 34; break;
                case 823: valor = 35; break;
                case 824: valor = 36; break;
                case 825: valor = 37; break;
                case 826: valor = 38; break;
                case 827: valor = 39; break;
                case 828: valor = 40; break;
                case 829: valor = 41; break;
                case 830: valor = 42; break;
                case 831: valor = 43; break;
                case 832: valor = 44; break;
                case 833: valor = 45; break;
                case 834: valor = 46; break;
                case 835: valor = 47; break;
                case 836: valor = 48; break;
                case 837: valor = 49; break;
                case 838: valor = 50; break;
                case 839: valor = 51; break;
                case 840: valor = 52; break;
                case 841: valor = 53; break;
                case 842: valor = 54; break;
                case 843: valor = 55; break;
                case 844: valor = 56; break;
                case 845: valor = 57; break;
                case 846: valor = 58; break;
                case 847: valor = 59; break;
                case 848: valor = 60; break;
                case 849: valor = 61; break;
                case 850: valor = 62; break;
                case 851: valor = 63; break;
                case 852: valor = 64; break;
                case 853: valor = 65; break;
                case 854: valor = 66; break;
                case 855: valor = 67; break;
                case 856: valor = 68; break;
                case 857: valor = 69; break;
                case 858: valor = 70; break;
                case 859: valor = 71; break;
                case 860: valor = 72; break;
                case 861: valor = 73; break;
                case 862: valor = 74; break;
                case 863: valor = 75; break;
                case 864: valor = 76; break;
                case 865: valor = 77; break;
                case 866: valor = 78; break;
                case 867: valor = 79; break;
                case 868: valor = 80; break;
                case 869: valor = 81; break;
                case 870: valor = 82; break;
                case 871: valor = 83; break;
                case 872: valor = 84; break;
                case 873: valor = 85; break;
                case 874: valor = 86; break;
                case 875: valor = 87; break;
                case 876: valor = 88; break;
                case 877: valor = 89; break;
                case 878: valor = 90; break;
                case 879: valor = 91; break;
                case 880: valor = 92; break;
                case 881: valor = 93; break;
                case 882: valor = 94; break;
                case 883: valor = 95; break;
                case 884: valor = 96; break;
                case 885: valor = 97; break;
                case 886: valor = 98; break;
                case 887: valor = 99; break;
                case 888: valor = 100; break;
                case 889: valor = 101; break;
                case 890: valor = 102; break;
                case 891: valor = 103; break;
                case 892: valor = 104; break;
                case 893: valor = 105; break;
                case 894: valor = 106; break;
                case 895: valor = 107; break;
                case 896: valor = 108; break;
                case 897: valor = 109; break;
                case 898: valor = 110; break;
                case 899: valor = 111; break;
                case 900: valor = 12; break;
                case 901: valor = 13; break;
                case 902: valor = 14; break;
                case 903: valor = 15; break;
                case 904: valor = 16; break;
                case 905: valor = 17; break;
                case 906: valor = 18; break;
                case 907: valor = 19; break;
                case 908: valor = 20; break;
                case 909: valor = 21; break;
                case 910: valor = 22; break;
                case 911: valor = 23; break;
                case 912: valor = 24; break;
                case 913: valor = 25; break;
                case 914: valor = 26; break;
                case 915: valor = 27; break;
                case 916: valor = 28; break;
                case 917: valor = 29; break;
                case 918: valor = 30; break;
                case 919: valor = 31; break;
                case 920: valor = 32; break;
                case 921: valor = 33; break;
                case 922: valor = 34; break;
                case 923: valor = 35; break;
                case 924: valor = 36; break;
                case 925: valor = 37; break;
                case 926: valor = 38; break;
                case 927: valor = 39; break;
                case 928: valor = 40; break;
                case 929: valor = 41; break;
                case 930: valor = 42; break;
                case 931: valor = 43; break;
                case 932: valor = 44; break;
                case 933: valor = 45; break;
                case 934: valor = 46; break;
                case 935: valor = 47; break;
                case 936: valor = 48; break;
                case 937: valor = 49; break;
                case 938: valor = 50; break;
                case 939: valor = 51; break;
                case 940: valor = 52; break;
                case 941: valor = 53; break;
                case 942: valor = 54; break;
                case 943: valor = 55; break;
                case 944: valor = 56; break;
                case 945: valor = 57; break;
                case 946: valor = 58; break;
                case 947: valor = 59; break;
                case 948: valor = 60; break;
                case 949: valor = 61; break;
                case 950: valor = 62; break;
                case 951: valor = 63; break;
                case 952: valor = 64; break;
                case 953: valor = 65; break;
                case 954: valor = 66; break;
                case 955: valor = 67; break;
                case 956: valor = 68; break;
                case 957: valor = 69; break;
                case 958: valor = 70; break;
                case 959: valor = 71; break;
                case 960: valor = 72; break;
                case 961: valor = 73; break;
                case 962: valor = 74; break;
                case 963: valor = 75; break;
                case 964: valor = 76; break;
                case 965: valor = 77; break;
                case 966: valor = 78; break;
                case 967: valor = 79; break;
                case 968: valor = 80; break;
                case 969: valor = 81; break;
                case 970: valor = 82; break;
                case 971: valor = 83; break;
                case 972: valor = 84; break;
                case 973: valor = 85; break;
                case 974: valor = 86; break;
                case 975: valor = 87; break;
                case 976: valor = 88; break;
                case 977: valor = 89; break;
                case 978: valor = 90; break;
                case 979: valor = 91; break;
                case 980: valor = 92; break;
                case 981: valor = 93; break;
                case 982: valor = 94; break;
                case 983: valor = 95; break;
                case 984: valor = 96; break;
                case 985: valor = 97; break;
                case 986: valor = 98; break;
                case 987: valor = 99; break;
                case 988: valor = 100; break;
                case 989: valor = 101; break;
                case 990: valor = 102; break;
                case 991: valor = 103; break;
                case 992: valor = 104; break;
                case 993: valor = 105; break;
                case 994: valor = 106; break;
                case 995: valor = 107; break;
                case 996: valor = 108; break;
                case 997: valor = 109; break;
                case 998: valor = 110; break;
                case 999: valor = 111; break;

            }
            return valor;
        }

        internal static void AguardaJanelaAtivar(string janela, int tempo)
        {
            var b = AutoItX.WinWaitActive(janela, "", tempo);
            if (b == 0)
            {
                throw new Exception();
            }
        }

        internal static void ItensDeEstoque()
        {
            InputSimulator ins = new InputSimulator();

            AutoItX.WinWaitActive("Consultar Itens de Estoque");
            Thread.Sleep(3000);

            for (int i = 1; i <= 2; i++)
            {
                Thread.Sleep(100);
                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            }
            Thread.Sleep(100);
            //ins.Keyboard.TextEntry("B-");
            Thread.Sleep(100);

            for (int i = 1; i <= 12; i++)
            {
                Thread.Sleep(150);
                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            }
            Thread.Sleep(150);

            ins.Keyboard.KeyPress(VirtualKeyCode.DELETE);//DELETA VALOR 100
            Thread.Sleep(100);
            for (int i = 1; i <= 12; i++)
            {
                Thread.Sleep(100);
                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            }
            Thread.Sleep(100);
            ins.Keyboard.KeyPress(VirtualKeyCode.RETURN);//BOTAO EXECUTAR
            Thread.Sleep(5000);
            for (int i = 1; i <= 9; i++)
            {
                Thread.Sleep(100);
                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            }
            Thread.Sleep(100);
            ins.Keyboard.KeyPress(VirtualKeyCode.RETURN);//BOTAO EXPORTAR REGISTROS
            Thread.Sleep(2000);

            AutoItX.WinWaitActive("Exportar Dados");

            Thread.Sleep(100);

        }

        internal static void CarregarForaEstoque_DeTerceiro(string janela)
        {

            Thread.Sleep(1000);
            // TICANDO SEM SALDO E ZERANDO MAX.
            for (int i = 1; i <= 4; i++)
            {
                Thread.Sleep(100);
                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            }
            ins.Keyboard.KeyPress(VirtualKeyCode.SPACE);
            Thread.Sleep(500);

            ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            Thread.Sleep(500);

            //ZERANDO MAX.
            ins.Keyboard.KeyPress(VirtualKeyCode.VK_0);

            Thread.Sleep(100); // POSICAO DATA
            ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            Thread.Sleep(500);

            ins.Keyboard.KeyPress(VirtualKeyCode.DELETE);
            Thread.Sleep(100);
            //DATA VAZIO
            ins.Keyboard.TextEntry("01/01/2017"); // AQUI

            Thread.Sleep(500);

            //POSIÇÃO EXECUTAR OK
            for (int i = 1; i <= 11; i++)
            {
                Thread.Sleep(300);
                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            }
            Thread.Sleep(1000); //EXECUTANDO OK
            ins.Keyboard.KeyPress(VirtualKeyCode.RETURN);

            Thread.Sleep(5000);

            ins.Keyboard.KeyDown(VirtualKeyCode.SHIFT);
            Thread.Sleep(300);
            for (int i = 1; i <= 7; i++)
            {
                Thread.Sleep(300);
                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            }
            Thread.Sleep(300);
            ins.Keyboard.KeyUp(VirtualKeyCode.SHIFT);
            Thread.Sleep(1000);

            ins.Keyboard.KeyPress(VirtualKeyCode.RETURN);
            Thread.Sleep(5000);
        }

        internal static void CarregarPVs()
        {
            AutoItX.WinActivate("Consultar Pedidos não Faturados");
            AutoItX.WinWait("Consultar Pedidos não Faturados");
            Thread.Sleep(1000);
            for (int i = 1; i <= 2; i++)
            {
                Thread.Sleep(100);
                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            }
            Thread.Sleep(100);
            ins.Keyboard.KeyPress(VirtualKeyCode.RETURN); // botao EXECUTAR
            Thread.Sleep(3000);

            for (int i = 1; i <= 6; i++)
            {
                Thread.Sleep(100);
                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            }
            Thread.Sleep(100);
            ins.Keyboard.KeyPress(VirtualKeyCode.RETURN); // botao Exportar Registros
            Thread.Sleep(500);
            AutoItX.WinActivate("Exportar Dados");
            AutoItX.WinWait("Exportar Dados");
        }

        internal static void ConsultarPedidosDeCompra()
        {
            Thread.Sleep(1000);

            ins.Keyboard.KeyDown(VirtualKeyCode.SHIFT);
            Thread.Sleep(100);
            ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            Thread.Sleep(100);
            ins.Keyboard.KeyUp(VirtualKeyCode.SHIFT);
            Thread.Sleep(100);
            ins.Keyboard.KeyPress(VirtualKeyCode.LEFT);
            Thread.Sleep(2000);
            for (int i = 1; i <= 11; i++)
            {
                Thread.Sleep(100);
                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            }
            Thread.Sleep(100);
            Thread.Sleep(100);
            ins.Keyboard.KeyPress(VirtualKeyCode.VK_0);
            Thread.Sleep(100);
            ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            Thread.Sleep(100);
            ins.Keyboard.KeyPress(VirtualKeyCode.VK_C);
            Thread.Sleep(100);

            for (int i = 1; i <= 12; i++)
            {
                Thread.Sleep(100);
                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            }

            Thread.Sleep(100);
            ins.Keyboard.KeyPress(VirtualKeyCode.RETURN);
            Thread.Sleep(5000);

            for (int i = 1; i <= 7; i++)
            {
                Thread.Sleep(100);
                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            }
            Thread.Sleep(100);
            ins.Keyboard.KeyPress(VirtualKeyCode.RETURN);
            Thread.Sleep(1000);
        }

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
        }

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
        }

        internal static void Subescrever(int tempoFechamento)
        {
            if (AutoItX.WinExists("ERP Pronto - ABC71") == 1)
            {
                AutoItX.WinWaitActive("Sobrescrever");
                Thread.Sleep(500);
                ins.Keyboard.KeyPress(VirtualKeyCode.RETURN);
                AutoItX.WinWaitClose("Sobrescrever");
                Thread.Sleep(tempoFechamento);
            }
        }

        internal static void ExportarDadosFull(string path, string file, int tempo)
        {
            Thread.Sleep(1000);
            if (AutoItX.WinExists("ERP Pronto - ABC71") == 0)
            {
                return;
            }
            AutoItX.WinWaitActive("Exportar Dados");

            Thread.Sleep(1000);

            for (int i = 1; i <= 3; i++) //posicionando disponivel
            {
                Thread.Sleep(100);
                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            }

            ins.Keyboard.KeyDown(VirtualKeyCode.CONTROL);
            Thread.Sleep(100);
            ins.Keyboard.KeyPress(VirtualKeyCode.VK_A);// seleciona tudo disponivel
            Thread.Sleep(100);
            ins.Keyboard.KeyUp(VirtualKeyCode.CONTROL);
            Thread.Sleep(100);

            ins.Keyboard.KeyDown(VirtualKeyCode.LSHIFT);
            Thread.Sleep(100);
            ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            Thread.Sleep(100);
            ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            Thread.Sleep(100);
            ins.Keyboard.KeyUp(VirtualKeyCode.LSHIFT);
            Thread.Sleep(100);
            ins.Keyboard.KeyPress(VirtualKeyCode.RETURN);
            Thread.Sleep(3000); //aguardando mover tudo


            for (int i = 1; i <= 6; i++) //posicionando disponivel
            {
                Thread.Sleep(100);
                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            }
            Thread.Sleep(100);
            ins.Keyboard.TextEntry(file);//


            Thread.Sleep(1000);
            ins.Keyboard.KeyPress(VirtualKeyCode.TAB);

            Thread.Sleep(100);
            ins.Keyboard.KeyPress(VirtualKeyCode.RETURN);
            Thread.Sleep(100);

            AutoItX.WinWaitActive("Aguarde");
            Thread.Sleep(5000);
            if (AutoItX.WinActive("Erro") == 1)
            {

                switch (file)
                {
                    case "ExportSaldo.txt":
                        FecharABC71();
                        ControllerERP_Pronto.Saldo();
                        break;
                    case "PedidosDeCompras.txt":
                        FecharABC71();
                        ControllerERP_Pronto.PedidoCompra();
                        break;
                    case "PedidosDeVendas.txt":
                        FecharABC71();
                        ControllerERP_Pronto.PedidoVenda();
                        break;
                    case "Movimentos.txt":
                        FecharABC71();
                        ControllerERP_Pronto.Movimento();
                        break;
                    case "ForaDeEstoque.txt":
                        FecharABC71();
                        ControllerERP_Pronto.ForaDeEstoque();
                        break;
                    case "DeTerceiro.txt":
                        FecharABC71();
                        ControllerERP_Pronto.DeTerceiro();
                        break;
                    case "ItensDeEstoque.txt":
                        FecharABC71();
                        ControllerERP_Pronto.ItensDeEstoque();
                        break;
                }
                MessageBox.Show($"Reinicie o processo de {file}");

            }
            AutoItX.WinWaitActive("Download de Arquivos");
            Thread.Sleep(1000);

            ins.Keyboard.KeyDown(VirtualKeyCode.LMENU);
            Thread.Sleep(100);
            ins.Keyboard.KeyPress(VirtualKeyCode.VK_T);
            Thread.Sleep(100);
            ins.Keyboard.KeyUp(VirtualKeyCode.LMENU);
            Thread.Sleep(100);

            //
            for (int i = 1; i <= 6; i++)
            {
                Thread.Sleep(100);
                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            }
            Thread.Sleep(100);
            for (int i = 1; i <= 200; i++)
            {
                Thread.Sleep(10);
                ins.Keyboard.KeyPress(VirtualKeyCode.BACK);
            }

            Thread.Sleep(100);
            ins.Keyboard.TextEntry(path);
            Thread.Sleep(100);

            for (int i = 1; i <= 2; i++)
            {
                Thread.Sleep(100);
                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            }
            Thread.Sleep(100);
            ins.Keyboard.KeyPress(VirtualKeyCode.RETURN);
            if (tempo != 0)
            {
                Thread.Sleep(tempo);
            }
            else
            {
                MessageBox.Show("Aguardando o Download ser comcluido \n\n Click 'OK' ao concluir!!", "Aguardando o Download", MessageBoxButtons.YesNo);
            }
        }

        internal static void ConsultarSaldosDeEstoque()
        {
            Thread.Sleep(1000);

            for (int i = 1; i <= 10; i++)
            {
                Thread.Sleep(100);
                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            }
            Thread.Sleep(100);

            ins.Keyboard.KeyPress(VirtualKeyCode.VK_0);
            Thread.Sleep(100);
            ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            Thread.Sleep(100);
            ins.Keyboard.KeyPress(VirtualKeyCode.RETURN);
            Thread.Sleep(5000);

            for (int i = 1; i <= 9; i++)
            {
                Thread.Sleep(100);
                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            }
            Thread.Sleep(100);


            ins.Keyboard.KeyPress(VirtualKeyCode.RETURN);

            AutoItX.WinWaitActive("Exportar Dados");
            Thread.Sleep(100);
        }

        internal static void ConsultarSaldosDeEstoqueDeTerceiro(int e, int d)
        {
            Thread.Sleep(1000);

            //seleciona estabelecimento
            if (e > 0)
            {
                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                Thread.Sleep(1000);
            }
            ins.Keyboard.KeyPress(VirtualKeyCode.VK_2);
            Thread.Sleep(1000);

            //SELECIONA DEPOSITO
            ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            Thread.Sleep(1000);
            for (int i = 0; i < d; i++)
            {
                ins.Keyboard.KeyPress(VirtualKeyCode.DOWN);
                Thread.Sleep(1000);
            }


            //inclui zero itens para puxar todos os itens
            for (int i = 1; i <= 9; i++)
            {
                Thread.Sleep(300);
                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            }
            Thread.Sleep(300);

            ins.Keyboard.KeyPress(VirtualKeyCode.VK_0);
            Thread.Sleep(500);
            ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            Thread.Sleep(1000);
            //botao OK                                                                
            ins.Keyboard.KeyPress(VirtualKeyCode.RETURN);
            Thread.Sleep(5000);

            //seleciona botao export
            for (int i = 1; i <= 7; i++)
            {
                Thread.Sleep(500);
                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
            }
            Thread.Sleep(500);


            ins.Keyboard.KeyPress(VirtualKeyCode.RETURN);

            AutoItX.WinWaitActive("Exportar Dados");
            Thread.Sleep(500);
        }

        internal static void BuscarJanela(string codJanela, string nomeJanela)
        {
            var p = AutoItX.WinWaitActive("ERP Pronto - ABC71", "", 60);
            if (p == 0)
                throw new Exception();

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

            Thread.Sleep(2000);

            if (AutoItX.WinExists("Confirma") == 1)
            {
                ins.Keyboard.KeyPress(VirtualKeyCode.RETURN);
            }

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

            AutoItX.WinMinimizeAll();

            p = AutoItX.WinWaitActive(nomeJanela, "", 60);
            if (p == 0)
                throw new Exception();

        }//ok

        internal static void MovimentarAcertar(List<Apontamento> la, string janela)
        {
            Thread.Sleep(1000);

            ProcuraRecurso("btnIncluir.png", 5, 0, 0, 0, 0, true, false);

            btnIncluir();

            var p = AutoItX.WinWaitActive(janela, "", 60);
            if (p == 0)
                throw new Exception();

            Thread.Sleep(1000);

            ProcuraRecurso("btnOK2.PNG", 5, 0, 0, 0, 0, false, false);

            //prepara a janela DE UM BUG CHATO
            if (janela.Contains("Movimento") & la.Count > 1)
            {
                for (int i = 1; i <= 11; i++)
                {
                    ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                    Thread.Sleep(100);
                }
                ins.Keyboard.TextEntry("CONTATO");
                Thread.Sleep(500);
                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                ProcuraRecurso("Zero.PNG", 2, 0, 0, 0, 0, false, false);
                Thread.Sleep(1000);
                for (int i = 1; i <= 11; i++)
                {
                    ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                    Thread.Sleep(100);
                }
            }

            //

            int ij = 0;
            foreach (var l in la)
            {
                Thread.Sleep(500);
                for (int i = 1; i <= 2; i++)
                {
                    ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                    Thread.Sleep(500);
                }
                ins.Keyboard.TextEntry(l.TM);
                for (int i = 1; i <= 3; i++)
                {
                    ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                    Thread.Sleep(500);
                }
                ins.Keyboard.TextEntry(l.Data);
                Thread.Sleep(500);

                if (janela.Contains("Acertos"))
                {
                    for (int i = 1; i <= 5; i++)
                    {
                        ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                        Thread.Sleep(100);
                    }
                }
                else
                {
                    for (int i = 1; i <= 4; i++)
                    {
                        ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                        Thread.Sleep(100);
                    }
                }
                ins.Keyboard.TextEntry(l.OP);

                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                Thread.Sleep(500);
                ins.Keyboard.TextEntry(ij++.ToString());// sequencia

                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                Thread.Sleep(500);
                ins.Keyboard.TextEntry(l.Produto);

                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                Thread.Sleep(2000);

                if (janela.Contains("Movimento") & la.Count == 1)
                {
                    ins.Keyboard.TextEntry(l.KG);
                    Thread.Sleep(100);

                    for (int i = 1; i <= 5; i++)
                    {
                        ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                        Thread.Sleep(100);
                    }

                    ins.Keyboard.TextEntry(l.Livre2);

                    Thread.Sleep(500);

                    btnOK();

                    ProcuraRecurso("btnOK2.PNG", 5, 0, 0, 0, 0, false, false);
                    break;
                }

                for (int i = 1; i <= 3; i++)
                {
                    ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                    Thread.Sleep(500);
                }
                ins.Keyboard.TextEntry(l.KG);

                if (janela.Contains("Acertos"))
                {
                    for (int i = 1; i <= 4; i++)
                    {
                        ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                        Thread.Sleep(500);
                    }
                }
                else
                {
                    for (int i = 1; i <= 5; i++)
                    {
                        ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                        Thread.Sleep(500);
                    }
                }

                ins.Keyboard.TextEntry(l.Livre2);

                Thread.Sleep(500);

                btnOK();

                ProcuraRecurso("btnOK2.PNG", 5, 0, 0, 0, 0, false, false);
            }

            p = AutoItX.WinActivate("ERP Pronto - ABC71", "");
            if (p == 0)
                throw new Exception();

        }

        internal static void PreparaJanelaSaldo()
        {
            ProcuraRecurso("btnExecutar.PNG", 100, 450, 151, 37, 29, false, true);

            for (int i = 1; i <= 10; i++)
            {
                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                Thread.Sleep(100);
            }
            ins.Keyboard.TextEntry("1");
            for (int i = 1; i <= 11; i++)
            {
                ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                Thread.Sleep(100);
            }
        }

        internal static List<string> ConsultarSaldosDeEstoque(List<string> listaProduto)
        {
            List<string> ls = new List<string>();
            foreach (var item in listaProduto)
            {
                ins.Keyboard.TextEntry(item);
                btnExecutar();
                ProcuraRecurso("btnExecuta2.PNG", 100, 450, 151, 37, 29, false, true);
                for (int i = 1; i <= 4; i++)
                {
                    ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                    Thread.Sleep(100);
                }

                for (int i = 1; i <= 7; i++)
                {
                    ins.Keyboard.KeyPress(VirtualKeyCode.RIGHT);
                    Thread.Sleep(100);
                }

                CopiarParaAreaDeTransferencia();

                ls.Add($"{item} ; {Clipboard.GetText()}");

                for (int i = 1; i <= 9; i++)
                {
                    ins.Keyboard.KeyPress(VirtualKeyCode.TAB);
                    Thread.Sleep(100);
                }

            }
            AutoItX.WinActivate("Apontamentos", "");
            return ls;
        }

    }
}