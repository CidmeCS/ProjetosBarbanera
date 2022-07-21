using Estoque.DAO;
using IronOcr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estoque.Views
{
    public partial class ObterDaddosDeOPs : Form
    {

        public ObterDaddosDeOPs()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            int roteiro = 0;
            string Produto = "";
            bool Pedidos;
            bool Componente = false;
            List<string> Lista = new List<string>();

            richTextBox1.Clear();
            var file = File.Open($@"C:\Exports\ObterOPs\OP{txtOP.Text}.pdf", FileMode.Open, FileAccess.ReadWrite);


            var Ocr = new AdvancedOcr()
            {
                Language = IronOcr.Languages.Portuguese.OcrLanguagePack,
                ColorSpace = AdvancedOcr.OcrColorSpace.GrayScale,
                EnhanceResolution = true,
                EnhanceContrast = true,
                CleanBackgroundNoise = true,
                ColorDepth = 4,
                RotateAndStraighten = false,
                DetectWhiteTextOnDarkBackgrounds = false,
                ReadBarCodes = false,
                Strategy = AdvancedOcr.OcrStrategy.Fast,
                InputImageType = AdvancedOcr.InputTypes.AutoDetect
            };

            Rectangle r = new Rectangle(300, 0, 500, 200);
            //var Result = Ocr.ReadPdf(file, r, 1);
            var Result2 = Ocr.ReadPdf(file, 1);

            richTextBox1.Text = Result2.Text;

            var linhas = Result2.Text.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries).Where(p => p != "\r");
            int linha = 0;
            Pedidos = true;

            foreach (var item in linhas)
            {
                linha++;
                //Primeira Linha
                if (linha == 1)
                {
                    continue;
                }
                //op e datas 
                if (linha == 2)
                {
                    var semespacos = item.Replace(" ", "").Trim();

                    Lista.Add("");

                    //OP
                    var op = Regex.Match(item, @"\d{4}");
                    Lista.Add("OP: " +  op.Value);
                    Lista.Add("");


                    int i = semespacos.IndexOf(op.Value) + op.Value.Length;

                    var datas = semespacos.Remove(0, i);

                    //DATAS
                    var DataAbertura = datas.Substring(0, 8);
                    var DataIniProd = datas.Substring(8, 8);
                    var DataFimProd = datas.Substring(16, 8);
                    Lista.Add("Data Abertura: " + DataAbertura + ", Dt.InicProd: " + DataIniProd + ", Dt.FimProd: " + DataFimProd);
                    Lista.Add("");


                }
                //Produto e Descrição
                if (linha == 3)
                {
                    var tiraproduto = item.Remove(0, 9);

                    var tt = item.Trim();
                    var semund = tt.Remove(tt.Length - 2, 2);

                    var t = semund.Split(new string[] { "Produto: ", " - ", "Qtde.: " }, StringSplitOptions.RemoveEmptyEntries);

                    // Prod desc qtd
                    Produto = t[0];
                    var Descricao = t[1];
                    var QtdeTotal = t[2];
                    // unidade
                    var unid = tt.Substring(tt.Length - 2, 2);

                    Lista.Add(
                        "Produto: " + Produto +
                        ", Descrição: " + Descricao +
                        ", Qtde: " + QtdeTotal + " " + unid
                        );
                    Lista.Add("");
                }

                //Operação
                if (linha == 4)
                {
                    //Operação
                    var operacao = item.Remove(0, 10).Trim();
                    Lista.Add("Operação: " + operacao);
                    Lista.Add("");

                }

                if (linha == 5 | linha == 6)
                {
                    continue;
                }

                if (linha >= 7 & linha < 20)
                {
                    if (item.Trim().Contains("ROTEIRO"))
                    {
                        Pedidos = false;
                        linha = 20;
                        continue;
                    }

                    if (item.Contains("Obs. da Operação"))
                    {
                        linha = 20;
                        continue;
                    }

                    if (item.Trim().Contains("PEDIDOS"))
                    {
                        Pedidos = true;
                    }

                    if (Pedidos)
                    {

                        if (item.Contains("Nº Pedido do Cliente: "))
                        {
                            var PedidoCliente = item.Remove(0, 22).Trim();
                            Lista.Add("Nº Pedido o Cliente" + PedidoCliente);
                            Lista.Add("");

                        }
                        else
                        {
                            var p = item.Trim().Split();
                            //PedidoVenda Seq. Cliente Quantidade
                            var PedidoVenda = p[0];
                            var Seq = p[1];
                            var Qtde = p[p.Count() - 2];
                            var Cliente = item.Substring(11, item.IndexOf(Qtde) - 11).Trim();

                            Lista.Add("Pedido de Venda: " + PedidoVenda + ", Seq.: " + Seq + ", Cliente: " + Cliente + ", Qtde: " +Qtde);
                            

                        }
                    }
                }

                if (linha >= 20)
                {
                    if (item.Trim().Contains("ROTEIRO") | item.Trim().Contains("Roteiro"))
                    {
                        roteiro += 1;
                        continue;
                    }
                    if (roteiro == 2)
                    {
                        roteiro = 0;
                        continue;
                    }

                    if (item.Trim().Contains("COMPONENTES") | item.Trim().Contains("Componente"))
                    {
                        Componente = true;
                        Lista.Add(""); Lista.Add("");
                        continue;
                    }

                    if (Componente)
                    {
                        var observacoes = item.Trim().Contains("Observações:");
                        if (observacoes)
                        {
                            break;
                        }
                        var t = item.Trim().Split(' ');
                        //Codigo Quantidade
                        var Codigo = t[1];

                        //Obter descricao, prateleira, UN, livre17, e converter...

                        Crud c = new Crud();
                        var u = c.ListaItensDeEstoque().Where(p => p.Codigo.Equals("B-448")).ToList().First();

                        var QuatidadeComponente = t.Last();

                        decimal convertido = 0M;

                        if(u.Livre17.Length > 0)
                        convertido = Math.Round(Convert.ToDecimal(QuatidadeComponente) / Convert.ToDecimal(u.Livre17),3);

                        Lista.Add($"{Codigo}, {u.Descricao}, { u.Prateleira},\n{QuatidadeComponente} {u.Unidade}, \nConvertido > {convertido}, \nLivre17: {u.Livre17}");
                        Lista.Add("");

                    }
                }
            }
            richTextBox2.Lines = Lista.ToArray();
        }
    }
}
