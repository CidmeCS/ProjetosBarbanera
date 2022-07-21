using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Estoque.DAO;
using Estoque.Entidade;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace Estoque.Classes
{
    public class OutLook
    {
        public static void EmailSaldo(string path)
        {
            DateTime dt = DateTime.Today;
            var x = Process.GetProcesses();
            bool b = true;
            while (b)
            {
                foreach (var item in x)
                {
                    var file = $"SaldoMensal {dt.ToString("yyyy-MM-dd")}.xlsx - Excel";
                    if (item.MainWindowTitle == file)
                    {
                        b = true;
                        MessageBox.Show($"Feche o arquivo {file}", "ArquivoAberto");
                        x = Process.GetProcesses();
                        break;
                    }
                    else
                    {
                        b = false;
                    }
                }
            }

            var mr = dt.AddMonths(-1);
            var MesReferencia = mr.ToString("MMMM/yyyy");

            string dataAtual = dt.ToString("dd/MM/yyyy");

            string saudacao;
            int hora = Convert.ToInt32(DateTime.Now.Hour.ToString());

            Console.WriteLine("Horas: " + hora);
            if (hora >= 12)
            {
                saudacao = "Boa tarde, Pietro.";
            }
            else
                saudacao = "Bom dia, Pietro.";
            try
            {
                Outlook.Application oApp = new Outlook.Application();
                Outlook.MailItem oMsg = (Outlook.MailItem)oApp.CreateItem(Outlook.OlItemType.olMailItem);


                oMsg.To = "pietro@barbanera.com.br";
                oMsg.Attachments.Add(path);

                StringBuilder mensagemPadrao = new StringBuilder();
                mensagemPadrao.AppendLine(saudacao + "<br/>");
                mensagemPadrao.AppendLine($"Segue em anexo SaldoMensal referente ao mês {MesReferencia} <br/>");
                mensagemPadrao.AppendLine("<br/>");

                mensagemPadrao.AppendLine("<br/>Atenciosamente: <br/> Equipe do Estoque <br/>");

                oMsg.BodyFormat = Outlook.OlBodyFormat.olFormatPlain;

                oMsg.HTMLBody = "<html><h5>" + mensagemPadrao.ToString() + "</h5></html>";



                oMsg.Subject = $"SaldoMensal-{MesReferencia}";
                oMsg.Display();
                // oMsg.Send();
                oMsg = null;
                oApp = null;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Primeiramente, gere o saldo mensal", "ERRO");
            }
        }

        internal static bool ForaDeEstoqueComSaldo(string path, List<ForaDeEstoque3> lista)
        {
            string saudacao = Saudacao("Alessanda, João e Putti");
            try
            {
                Outlook.Application oApp = new Outlook.Application();
                Outlook.MailItem oMsg = (Outlook.MailItem)oApp.CreateItem(Outlook.OlItemType.olMailItem);


                oMsg.To = "compras@barbanera.com.br; inspecaorir@barbanera.com.br; lrpsig@gmail.com";

                oMsg.Attachments.Add(path);

                StringBuilder mensagemPadrao = new StringBuilder();
                mensagemPadrao.AppendLine(saudacao + "<br/>");
                mensagemPadrao.AppendLine($"Segue uma lista de materiais em poder de terceiros para acompanhamento e solução de pendências.<br/>");
                mensagemPadrao.AppendLine($"Está ordenado por 'Data' crescente.<br/>");
                mensagemPadrao.AppendLine($"O estoque não tem ferramentas para tratar cada assunto, mas somos cobrados pela acuracidade desses dados e inventario. Portanto estamos enviando semanalmente esses dados para os setores que tem as ferramentas para tratar as pendências.<br/>");
                mensagemPadrao.AppendLine($"<br/>");

                //TABLE INI
                mensagemPadrao.AppendLine("<html><style>table, th, td {border:1px solid black; }</style><table style=width:50%>");

                // tr ini
                mensagemPadrao.AppendLine($"<tr>");
                // ths ini e fim  cabeçalhos
                Type myType = typeof(ForaDeEstoque3);
                var myFields = myType.GetProperties();
                foreach (var field in myFields)
                {
                    mensagemPadrao.AppendLine($"<th>{field.Name}</th>");
                }
                // tr fim 
                //
                // tr dados
                foreach (var item in lista)
                {
                    mensagemPadrao.AppendLine($"<tr>");
                    mensagemPadrao.AppendLine($"<td>{item.Produto}</td>");
                    mensagemPadrao.AppendLine($"<td>{item.Descricao}</td>");
                    mensagemPadrao.AppendLine($"<td>{item.SaldoQtde}</td>");
                    mensagemPadrao.AppendLine($"<td>{item.QtdeNf}</td>");
                    mensagemPadrao.AppendLine($"<td>{item.Data.ToString("dd-MM-yyyy")}</td>");
                    mensagemPadrao.AppendLine($"<td>{item.DocFistal}</td>");
                    mensagemPadrao.AppendLine($"<td>{item.NomeFantasia}</td>");
                    mensagemPadrao.AppendLine($"</tr>");
                }

                mensagemPadrao.AppendLine($"</table><bt/>");

                Crud c = new Crud();
                var data = c.ListaAtualizacao().Where(p => p.Entidade == "ForaDeEstoque.txt").First().Data;

                mensagemPadrao.AppendLine($"Export de: {data}");
                //TABLE FIM


                mensagemPadrao.AppendLine("<br/>");

                mensagemPadrao.AppendLine("<br/>Atenciosamente: <br/> Equipe do Estoque <br/>");

                oMsg.BodyFormat = Outlook.OlBodyFormat.olFormatPlain;

                oMsg.HTMLBody = "<html><h5>" + mensagemPadrao.ToString() + "</h5></html>";



                oMsg.Subject = $"ForaDeEstoqueComSaldo";
                //oMsg.Display();
                //oMsg.Save();
                oMsg.Send();
                oMsg = null;
                oApp = null;
                MessageBox.Show("Lista ForaDeEstoqueComSaldo enviado com sucesso", "Lista ForaDeEstoqueComSaldo");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("A Lista ForaDeEstoqueComSaldo nao foi enviado!", "ERRO");
                return false;
            }
        }

        internal static void PedidoDeComprasSaldosParaMatarParaCompras(string path)
        {
            string saudacao = Saudacao("Alessandra");
            try
            {
                Outlook.Application oApp = new Outlook.Application();
                Outlook.MailItem oMsg = (Outlook.MailItem)oApp.CreateItem(Outlook.OlItemType.olMailItem);


                oMsg.To = "compras@barbanera.com.br";
                oMsg.Attachments.Add(path);

                StringBuilder mensagemPadrao = new StringBuilder();
                mensagemPadrao.AppendLine(saudacao + "<br/>");
                mensagemPadrao.AppendLine($"Segue em anexo uma lista para zerar saldos nos pedidos de compras.<br/>");
                mensagemPadrao.AppendLine($"Poderá deixar anotado na planilha apenas os itens que eu deva atualizar/zerar no sistema?<br/>");
                mensagemPadrao.AppendLine($"Lembramos que as colunas devem ser mantidas na sua ordem original.<br/>");
                mensagemPadrao.AppendLine("<br/>");

                mensagemPadrao.AppendLine("<br/>Atenciosamente: <br/> Equipe do Estoque <br/>");

                oMsg.BodyFormat = Outlook.OlBodyFormat.olFormatPlain;

                oMsg.HTMLBody = "<html><h5>" + mensagemPadrao.ToString() + "</h5></html>";



                oMsg.Subject = $"Pedidos de Compras com Saldo";
                oMsg.Display();
                // oMsg.Send();
                oMsg = null;
                oApp = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Primeiramente, Gere as OPs Com Saldos Para Eliminar", "ERRO");
            }
        }

        private static string Saudacao(string nomes)
        {
            string saudacao;
            int hora = Convert.ToInt32(DateTime.Now.Hour.ToString());

            Console.WriteLine("Horas: " + hora);
            if (hora >= 12)
            {
                saudacao = $"Boa tarde, {nomes}.";
            }
            else
                saudacao = $"Bom dia, Alessandra {nomes}.";
            return saudacao;
        }

        internal static void ErroItemSped(List<ItensDeEstoque> itemSped, string destinatario, string tipoitem)
        {
            string saudacao;
            int hora = Convert.ToInt32(DateTime.Now.Hour.ToString());

            Console.WriteLine("Horas: " + hora);
            if (hora >= 12)
            {
                saudacao = "Boa tarde!";
            }
            else
                saudacao = "Bom dia!";
            try
            {
                Outlook.Application oApp = new Outlook.Application();
                Outlook.MailItem oMsg = (Outlook.MailItem)oApp.CreateItem(Outlook.OlItemType.olMailItem);


                oMsg.To = destinatario;
                //oMsg.Attachments.Add(path);

                StringBuilder mensagemPadrao = new StringBuilder();
                mensagemPadrao.AppendLine(saudacao + "<br/>");
                mensagemPadrao.AppendLine($"Segue abaixo itens que precisam de atenção com o item speed.<br/><br/>");
                mensagemPadrao.AppendLine($"ItemSped Correto para todos: {tipoitem}.<br/><br/>");
                foreach (var item in itemSped)
                {
                    mensagemPadrao.AppendLine($"Codigo: {item.Codigo}, ItemSped Incorreto: {item.TipoItemSped}.<br/>");
                }

                mensagemPadrao.AppendLine("<br/>Atenciosamente: <br/> Equipe do Estoque <br/>");

                oMsg.BodyFormat = Outlook.OlBodyFormat.olFormatPlain;

                oMsg.HTMLBody = "<html><h5>" + mensagemPadrao.ToString() + "</h5></html>";

                oMsg.Subject = $"Itens com erros no itemSped";

                if (MessageBox.Show("Confirme se é para enviar o email e aplicar mudancas no banco de dados", "CONFIRMAÇÃO", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    itemSped.ForEach(p => p.TipoItemSped = tipoitem);
                    Crud c = new Crud();
                    c.AlterarItensDeEstoque(itemSped);
                    //oMsg.Display();
                    oMsg.Send();
                    MessageBox.Show("Email enviado e Banco de Dados aplicado", "CONFIRMAÇÃO");
                }
                oMsg = null;
                oApp = null;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERRO >> {ex}", "ERRO");
            }
        }

        internal static void ErroPosicaoFiscal(List<ItensDeEstoque> posicaoFiscal, string email)
        {
            string saudacao;
            int hora = Convert.ToInt32(DateTime.Now.Hour.ToString());

            Console.WriteLine("Horas: " + hora);
            if (hora >= 12)
            {
                saudacao = "Boa tarde!";
            }
            else
                saudacao = "Bom dia!";
            try
            {
                Outlook.Application oApp = new Outlook.Application();
                Outlook.MailItem oMsg = (Outlook.MailItem)oApp.CreateItem(Outlook.OlItemType.olMailItem);


                oMsg.To = email;
                //oMsg.Attachments.Add(path);

                StringBuilder mensagemPadrao = new StringBuilder();
                mensagemPadrao.AppendLine(saudacao + "<br/>");
                mensagemPadrao.AppendLine($"Segue abaixo itens que precisam de atenção com a Posição Fiscal.<br/><br/>");

                mensagemPadrao.AppendLine($"A posição Fiscal dos itens abaixo contem menos de 8 digitos.<br/><br/>");
                foreach (var item in posicaoFiscal)
                {
                    mensagemPadrao.AppendLine($"Codigo: {item.Codigo}, Posição Fiscal Incorreto: {item.PosicaoFiscal}.<br/>");
                }

                mensagemPadrao.AppendLine("<br/>Atenciosamente: <br/> Equipe do Estoque <br/>");

                oMsg.BodyFormat = Outlook.OlBodyFormat.olFormatPlain;

                oMsg.HTMLBody = "<html><h5>" + mensagemPadrao.ToString() + "</h5></html>";

                oMsg.Subject = $"Itens com erros no itemSped";

                if (MessageBox.Show("Confirme se é para enviar o email e aplicar mudancas no banco de dados", "CONFIRMAÇÃO", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    while (true)
                    {
                        if (posicaoFiscal.Where(p => p.PosicaoFiscal.Length < 8).Count() > 0)
                        {
                            posicaoFiscal.Where(p => p.PosicaoFiscal.Length < 8).ToList().ForEach(p => p.PosicaoFiscal += "0");
                        }
                        else
                        {
                            break;
                        }
                    }

                    Crud c = new Crud();
                    c.AlterarItensDeEstoque(posicaoFiscal);
                    //oMsg.Display();
                    oMsg.Send();
                    MessageBox.Show("Email enviado e Banco de Dados aplicado", "CONFIRMAÇÃO");
                }
                oMsg = null;
                oApp = null;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERRO >> {ex}", "ERRO");
            }
        }

        internal static void InventarioDepositoDeTerceiro(string path)
        {
            string saudacao;
            int hora = Convert.ToInt32(DateTime.Now.Hour.ToString());

            Console.WriteLine("Horas: " + hora);
            if (hora >= 12)
            {
                saudacao = "Boa tarde.";
            }
            else
                saudacao = "Bom dia.";
            try
            {
                Outlook.Application oApp = new Outlook.Application();
                Outlook.MailItem oMsg = (Outlook.MailItem)oApp.CreateItem(Outlook.OlItemType.olMailItem);


                oMsg.To = "vendas2@barbanera.com.br";
                oMsg.CC = "vendas@barbanera.com.br, pietro@barbanera.com.br";
                oMsg.Attachments.Add(path);

                StringBuilder mensagemPadrao = new StringBuilder();
                mensagemPadrao.AppendLine(saudacao + "<br/>");
                mensagemPadrao.AppendLine($"Segue uma lista de Materiais de Terceiro que estão a mais de 2 e 4 meses no deposito da Barbanera (Amarelo e Vermelho).<br/><br/>");
                mensagemPadrao.AppendLine($"Existe itens que devem ser devolvidos ao cliente?<br/><br/>");
                mensagemPadrao.AppendLine($"A coluna Entregue, diz que o estoque já entregou para o solicitante em anotação.<br/><br/>");
                mensagemPadrao.AppendLine($"Algumas linhas aparentemente são idênticas mas requer atenção especial em todas as colunas da linha.<br/>");
                mensagemPadrao.AppendLine("<br/>");

                mensagemPadrao.AppendLine("<br/>Atenciosamente: <br/> Equipe do Estoque <br/>");

                oMsg.BodyFormat = Outlook.OlBodyFormat.olFormatPlain;

                oMsg.HTMLBody = "<html><h5>" + mensagemPadrao.ToString() + "</h5></html>";


                oMsg.Subject = $"InventarioDepositosDeTerceiro.xlsx";
                oMsg.Display();
                // oMsg.Send();
                oMsg = null;
                oApp = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Primeiramente, Gere as OPs Com Saldos Para Eliminar", "ERRO");
            }
        }
    }
}
