using Estoque.Classes;
using Estoque.DAO;
using MySql.Data.MySqlClient;
using SautinSoft;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace Estoque.Views
{
    public partial class frmEstoqueMinimoComPrevisao : Form
    {
        public frmEstoqueMinimoComPrevisao()
        {
            InitializeComponent();

        }
        HashSet<DataGridViewRow> rows = new HashSet<DataGridViewRow>();
        HashSet<LinhasGridView> rows2 = new HashSet<LinhasGridView>();
        HashSet<string> SalvarDB = new HashSet<string>();


        ArrayList EnviarEmailPietro = new ArrayList();
        ArrayList EnviarEmailPCP = new ArrayList();

        MySqlConnection Con;
        public int id;

        private void btnSolicitar(object sender, EventArgs e)
        {
            try
            {
                Con = new MySqlConnection(StringConexao.sCon());

                foreach (var item in rows2)
                {
                    if (item.PEDIR.Length == 0 | item.QTD_Pedida.ToString().Length == 0)
                    {
                        
                        MessageBox.Show("A Celula Pedir esta vázia\n" +
                            $"Produto: {item.Produto}\n" +
                            $"Descricao: {item.Descricao}\n" +
                            $"ID: {item.ID}\n" +
                            $"QTD_Pedida: {item.QTD_Pedida}\n" +
                            $"Cancelando Trabalhos");
                        rows2.Clear();
                        atualiza();
                        lblqtd2.Text = "QTD selecionar: 0";
                        goto ir;
                    }
                }

                foreach (var item in rows2)
                {
                    DateTime dt = DateTime.Today;
                    string data = dt.ToString("dd/MM/yyyy HH:mm");

                    //var x = PedirQuantidade(item);

                    string commando = " INSERT INTO Solicitacao (Produto, Descricao, QTD, UND, DataHora, PrazoSolicitado) " +
                        "VALUES (@Produto, @Descricao, @QTD, @UND, @DataHora, @PrazoSolicitado)";
                    MySqlCommand cmd = new MySqlCommand(commando, Con);
                    cmd.Parameters.Add("@Produto", MySqlDbType.VarChar).Value = item.Produto;
                    cmd.Parameters.Add("@Descricao", MySqlDbType.VarChar).Value = item.Descricao;
                    cmd.Parameters.Add("@QTD", MySqlDbType.Double).Value = item.QTD_Pedida;
                    cmd.Parameters.Add("@UND", MySqlDbType.VarChar).Value = item.Unid;
                    cmd.Parameters.Add("@DataHora", MySqlDbType.Date).Value = (dt.ToString("yyyy-MM-dd"));
                    cmd.Parameters.Add("@PrazoSolicitado", MySqlDbType.VarChar).Value = dt.AddDays(7).ToString("dd/MM/yyyy");
                    Con.Open();
                    cmd.ExecuteNonQuery();
                    Con.Close();
                }


            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                Con.Close();
            }

            if (EnviarEmailPCP.Count > 0)
            {
                EnviarEmailPCP.Insert(0, "PCP-1");
                EmailMulti(EnviarEmailPCP, null);
            }
            if (EnviarEmailPietro.Count > 0)
            {
                string path = PreencherFormulariosRequisicaoParaCompras.Start(EnviarEmailPietro);
                EnviarEmailPietro.Insert(0, "Pie-2");
                EmailMulti(EnviarEmailPietro, path);
            }
            atualiza();
            rows2.Clear();
            lblqtd2.Text = "QTD Seleção: " + rows2.Count.ToString();
            rows.Clear();
            EnviarEmailPietro.Clear();
            EnviarEmailPCP.Clear();
            ir:;
        }

        private static decimal PedirQuantidade(LinhasGridView item)
        {
            var x = item.PEDIR.Replace('.', ',').Split(' ');
            var t = Convert.ToDecimal(x.Last().Trim());
            var p = Math.Ceiling(t);
            return p;
        }

        private static double PedirQuantidade(DataGridViewRow item)
        {
            var x = item.Cells[12].Value.ToString().Replace('.', ',').Split(' ');
            var t = Convert.ToDouble(x.Last().Trim());
            var p = Math.Ceiling(t);
            return p;
        }

        private void EmailMulti(ArrayList EnviarEmail, string path)
        {
            DateTime dt = DateTime.Today;
            string data = dt.AddDays(7).ToString("dd/MM/yyyy");

            string saudacao;
            int hora = Convert.ToInt32(DateTime.Now.Hour.ToString());

            Console.WriteLine("Horas: " + hora);
            if (hora >= 12)
            {
                saudacao = "Boa tarde. ";
            }
            else
                saudacao = "Bom dia. ";
            try
            {
                Outlook.Application oApp = new Outlook.Application();
                Outlook.MailItem oMsg = (Outlook.MailItem)oApp.CreateItem(Outlook.OlItemType.olMailItem);

                if (EnviarEmail[0].Equals("PCP-1"))
                {
                    EnviarEmail.RemoveAt(0);
                    oMsg.To = "pcp@barbanera.com.br";
                }
                else if (EnviarEmail[0].Equals("Pie-2"))
                {
                    EnviarEmail.RemoveAt(0);
                    oMsg.To = "estoque@barbanera.com.br; compras@barbanera.com.br; pietro@barbanera.com.br";
                    var v = 0;
                    foreach (LinhasGridView itens in EnviarEmail)
                    {
                        if (itens.Descricao.Contains("CAIXA DE PAPELAO"))
                        {
                            oMsg.CC = "lrpsig@gmail.com";
                        }
                    }
                    oMsg.Attachments.Add(path);
                }

                StringBuilder mensagemPadrao = new StringBuilder();
                mensagemPadrao.AppendLine(saudacao + "<br/>");
                mensagemPadrao.AppendLine("Segue em anexo Requisicao(oes) Para Compra(as) <br/>");
                mensagemPadrao.AppendLine("<br/>");

                foreach (LinhasGridView itens in EnviarEmail)
                {



                    mensagemPadrao.AppendLine("Código: " + itens.Produto + "<br/>");

                    mensagemPadrao.AppendLine("Descrição: " + itens.Descricao + "<br/>");

                    mensagemPadrao.AppendLine("Unid: " + itens.Unid + "<br/><br/>");

                    mensagemPadrao.AppendLine("SaldoAtual: " + itens.SaldoAtual + "  >>  Disponivel: " + itens.Disponivel + "<br/>");

                    mensagemPadrao.AppendLine("PedCompra: " + itens.PedCompra + "<br/>");

                    mensagemPadrao.AppendLine("PrevFabric: " + itens.PrevFabric + "<br/>---------------------<br/>");

                    mensagemPadrao.AppendLine("EstqMinimo: " + itens.EstqMinimo + "<br/>");

                    mensagemPadrao.AppendLine("ConsPrevOS: " + itens.ConsuPrevOs + "<br/>");

                    mensagemPadrao.AppendLine("EstqMaximo: " + itens.EstqMaximo + "<br/><br/>");

                    mensagemPadrao.AppendLine("Qtd Pedida: " + itens.QTD_Pedida + "<br/>");

                    mensagemPadrao.AppendLine("Prazo: " + data + "<br/>");
                    mensagemPadrao.AppendLine("-------------------------------------<br/><br/>");




                }

                mensagemPadrao.AppendLine("<br/>Atenciosamente: <br/> Equipe do Estoque <br/>");

                oMsg.BodyFormat = Outlook.OlBodyFormat.olFormatPlain;

                oMsg.HTMLBody = "<html><h5>" + mensagemPadrao.ToString() + "</h5></html>";



                oMsg.Subject = "Requisicao(oes) Para Compra(as)";
                oMsg.Display();
                // oMsg.Send();
                oMsg = null;
                oApp = null;
            }
            catch (Exception ex)
            {
            }
        }


        private void Email()
        {
            string saudacao;
            int hora = Convert.ToInt32(DateTime.Now.Hour.ToString());

            Console.WriteLine("Horas: " + hora);
            if (hora >= 12)
            {
                saudacao = "Boa tarde. ";
            }
            else
                saudacao = "Bom dia. ";

            try
            {

                Outlook.Application oApp = new Outlook.Application();
                Outlook.MailItem oMsg = (Outlook.MailItem)oApp.CreateItem(Outlook.OlItemType.olMailItem);


                StringBuilder mensagem = new StringBuilder();

                mensagem.AppendLine(saudacao + "<br/>");
                mensagem.AppendLine("Segue abaixo Solicitação de Materiais - Estoque Mínimo <br/>");
                mensagem.AppendLine("<br/>");

                DataGridViewRow row = dataGridView1.CurrentRow;


                mensagem.AppendLine("Código: " + row.Cells[0].Value.ToString() + "<br/>");
                mensagem.AppendLine("Descrição: " + row.Cells[1].Value.ToString() + "<br/>");
                mensagem.AppendLine("Unid: " + row.Cells[2].Value.ToString() + "<br/>");
                mensagem.AppendLine("Saldo: " + row.Cells[3].Value.ToString() + "<br/>");
                mensagem.AppendLine("Estq Mímimo: " + row.Cells[4].Value.ToString() + "<br/>");
                mensagem.AppendLine("Qtd Pedida: " + row.Cells[14].Value.ToString() + "<br/>");
                mensagem.AppendLine("OP: Estoque Mínimo <br/>");
                mensagem.AppendLine("Prazo: " + row.Cells[17].Value.ToString() + "<br/>");

                mensagem.AppendLine(); mensagem.AppendLine();

                mensagem.AppendLine(" Att: <br/> Equipe do Estoque <br/>");


                oMsg.BodyFormat = Outlook.OlBodyFormat.olFormatPlain;

                oMsg.HTMLBody = "<html><h5>" + mensagem.ToString() + "</h5></html>";

                if (row.Cells[0].Value.ToString().StartsWith("PP1-") |
                    row.Cells[0].Value.ToString().StartsWith("PP2-") |
                    row.Cells[0].Value.ToString().StartsWith("PP3-") |
                    row.Cells[0].Value.ToString().Equals("HKHHBL-1287") |
                    row.Cells[0].Value.ToString().Equals("HKHHCG-1213-03") |
                    row.Cells[0].Value.ToString().Equals("HKHHCG-1243")
                    )
                {
                    oMsg.To = "pcp@barbanera.com.br";
                }
                else //TODO O RESTO DOS MINIMOS PARA O PIETRO
                {
                    oMsg.To = "estoque@barbanera.com.br";
                    oMsg.CC = "lrpsig@gmail.com";
                    oMsg.Attachments.Add("");

                }

                /*
                 * 
                 * PARA O PIETRO
                else if (

                    row.Cells[1].Value.ToString().StartsWith("CORD CU ") |
                    row.Cells[1].Value.ToString().StartsWith("CORD AL ") |
                    row.Cells[1].Value.ToString().StartsWith("PRATA 88/12 ") |

                    row.Cells[0].Value.ToString() == "B-1766" |
                    row.Cells[0].Value.ToString() == "B-1768" |
                    row.Cells[0].Value.ToString() == "B-1767" |
                    row.Cells[0].Value.ToString() == "B-1764" |
                    row.Cells[0].Value.ToString() == "B-1763" |
                    row.Cells[0].Value.ToString() == "B-1947"

                    )
                {
                    oMsg.To = "pietro@barbanera.com.br";
                }

                else //TODO O RESTO PARA O QUALIDADE
                {
                    oMsg.To = "inspecaorir@barbanera.com.br";
                }
                */

                //  oMsg.CC = "cidevangelista@hotmail.com";


                oMsg.Subject = "Requisicao Para Compras";
                //Outlook.Recipients oRecips = (Outlook.Recipients)oMsg.Recipients;
                //Outlook.Recipient oRecip = (Outlook.Recipient)oRecips.Add("compras@barbanera.com.br");

                //oRecip.Resolve();
                oMsg.Send();
                //oRecip = null;
                //oRecips = null;
                oMsg = null;
                oApp = null;
            }
            catch (Exception ex)
            {
            }
        }

        private void EstoqueMinima_Load(object sender, EventArgs e)
        {

            atualiza();

        }

        public void atualiza()
        {
            EstoqueMinimo em = new EstoqueMinimo();
            em.estoqueMinimo2();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = em.ds.Tables[0];


            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Columns[12].DefaultCellStyle.ForeColor = Color.Red;
            dataGridView1.Columns[12].DefaultCellStyle.SelectionBackColor = Color.BlueViolet;

            dataGridView1.Columns[14].DefaultCellStyle.ForeColor = Color.Red;
            dataGridView1.Columns[14].DefaultCellStyle.Font = new Font(dataGridView1.Font, FontStyle.Bold);
            dataGridView1.Columns[14].DefaultCellStyle.SelectionBackColor = Color.Black;

            dataGridView1.Columns[17].DefaultCellStyle.ForeColor = Color.Red;
            dataGridView1.Columns[17].DefaultCellStyle.Font = new Font(dataGridView1.Font, FontStyle.Bold);
            dataGridView1.Columns[17].DefaultCellStyle.SelectionBackColor = Color.Black;
            lblLinhas.Text = em.ds.Tables[0].Rows.Count.ToString() + " LINHAS RETORNADAS";


        }

        private void btnFinalizar(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            if (row.Cells[13].Value.ToString().Length == 0)
            {
                goto fim;
            }

            if (MessageBox.Show("Deseja Realmente Finalizar?", "FINALIZAR", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                
                DateTime dt = DateTime.Now;
                string data = dt.ToString("dd/MM/yyyy HH:mm");
                try// verifica erros no bloco
                {


                    Con = new MySqlConnection(StringConexao.sCon());
                    string commando = " UPDATE Solicitacao SET FimStatus = @FimStatus WHERE ID = @ID";
                    MySqlCommand cmd = new MySqlCommand(commando, Con);
                    cmd.Parameters.Add("@ID", MySqlDbType.Int32).Value = (row.Cells[13].Value.ToString());
                    cmd.Parameters.Add("@FimStatus", MySqlDbType.VarChar).Value = data;

                    Con.Open();
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    rows2.Clear();
                    lblqtd2.Text = "QTD Seleção: " + rows2.Count.ToString();
                    EnviarEmailPietro.Clear();
                    EnviarEmailPCP.Clear();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    Con.Close();
                    rows2.Clear();
                    lblqtd2.Text = "QTD Seleção: " + rows2.Count.ToString();
                    EnviarEmailPietro.Clear();
                    EnviarEmailPCP.Clear();
                }

                atualiza();
            }

            fim:;

        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            rows2.Clear();
            lblqtd2.Text = "QTD Seleção: " + rows2.Count.ToString();
            EnviarEmailPietro.Clear();
            EnviarEmailPCP.Clear();
            atualiza();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            string cbPesq = txtPesquisar.Text; // a variavel recebe o controle
            cbPesq = ("%" + cbPesq + "%");
            try// verifica erros no bloco
            {


                Con = new MySqlConnection(StringConexao.sCon()); // inicializa uma nova instancia da classe system.data.sqlcliente.sqlconnection onde recebe uma string que contem a connection string
                                                                 // abre a conexão4
                                                                 // cria a string de comando select para o banco de dados
                string pesquisar = txtPesquisar.Text;

                string commando = "SELECT * FROM Solicitacao WHERE " + cbbPesquisar.Text + " LIKE '" + cbPesq + "' " +
                    "ORDER BY Descricao ASC"; // cria a string de comando select para o banco de dados
                MySqlCommand cmd = new MySqlCommand(commando, Con);
                Con.Open();
                cmd.ExecuteReader(); //envia um texto do objeto cmd para o command.conection e constroi um sqldatareader
                Con.Close();

                MySqlDataAdapter da = new MySqlDataAdapter(commando, StringConexao.sCon());// cria um objeto datataadapter e preenche com os objetos commando e com conexão


                DataSet ds = new DataSet();
                ds.Reset();
                da.Fill(ds); // preenche o dataset com o dataadapter, 

                dataGridView1.DataSource = null;

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                dataGridView1.DataSource = ds.Tables[0]; // o datagridview é preenchida com a tabala 0 do dataset
                //Fecha a conexão // fecha a conexão
            } // fim do bloco verificador de erros
            catch (Exception ex) // procura o tipo de erro
            {
                MessageBox.Show(ex.Message); // se houver algum erro uma mensagem é exibida
                Con.Close();//Fecha a conexão// e fecha a conexão
            }
        }

        private void cbbPesquisar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;

            id = BuscarID(row);
            PreencherCampos(row);
        }

        private void PreencherCampos(DataGridViewRow row)
        {
            lblProduto.Text = "Produto: " + row.Cells[0].Value.ToString();
            lblDescricao.Text = "Descricao: " + row.Cells[1].Value.ToString();
            lblUnidade.Text = "Unid: " + row.Cells[2].Value.ToString();
            lblSaldoAtual.Text = "SaldoAtual: " + row.Cells[3].Value.ToString();
            lblPedCompras.Text = "PedCompras: " + row.Cells[4].Value.ToString();
            lblPrevFabric.Text = "PrevFabric: " + row.Cells[5].Value.ToString();
            lblEstqMinimo.Text = "EstqMinimo: " + row.Cells[6].Value.ToString();
            lblConsuPrevOs.Text = "ConsuPrevOS: " + row.Cells[7].Value.ToString();
            lblEstoqMaximo.Text = "EstqMaximo: " + row.Cells[8].Value.ToString();
            lblPrateleira.Text = "Prateleira: " + row.Cells[9].Value.ToString();
            lblGrupo.Text = "Grupo: " + row.Cells[10].Value.ToString();
            lblDiasSemMov.Text = "DiasSemMov: " + row.Cells[11].Value.ToString();
            lblPedir.Text = "Pedir: " + row.Cells[12].Value.ToString();
            lblID.Text = "ID: " + row.Cells[13].Value.ToString();
            lblQtdPedida.Text = "QtdPedida: " + row.Cells[14].Value.ToString();
            lblOP.Text = "OP: " + row.Cells[15].Value.ToString();
            lblDataHora.Text = "DataHora: " + row.Cells[16].Value.ToString();
            lblPrazoPedidoQTD.Text = "PrazoPedQtd: " + row.Cells[17].Value.ToString();
            lblAndamento.Text = "Andamento: " + row.Cells[18].Value.ToString();
            lblFimStatus.Text = "FimStatus: " + row.Cells[19].Value.ToString();
            lblNFOK.Text = "NF-OK: " + row.Cells[20].Value.ToString();
            lblPedirMais.Text = "PedirMais: " + row.Cells[21].Value.ToString();
            lblAtrazado.Text = "Atrazado: " + row.Cells[22].Value.ToString();

        }

        private int BuscarID(DataGridViewRow row)
        {
            try
            {

                Con = new MySqlConnection(StringConexao.sCon()); // inicializa uma nova instancia da classe system.data.sqlcliente.sqlconnection onde recebe uma string que contem a connection string
                Con.Open();// abre a conexão4



                string commando = $"SELECT * FROM solicitacao where " +
                    $"Produto = '{row.Cells[0].Value.ToString()}' AND " +
                    $"QTD = '{row.Cells[14].Value.ToString()}' ";
                //+
                //    $"AND DataHora = '{ Convert.ToDateTime(row.Cells[16].Value).ToString("yyyy-MM-dd")}' ";


                MySqlCommand cmd = new MySqlCommand(commando, Con);
                DataAdapter da = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                da.Fill(ds);
                Con.Close();
                if (ds.Tables[0].Rows.Count == 0)
                {
                    lblID.Text = "ID Vázio";
                    return 0;
                }
                lblID.Text =
                    ds.Tables[0].Rows[0].ItemArray[0].ToString() + ", " +
                    ds.Tables[0].Rows[0].ItemArray[1].ToString() + ", " +
                    ds.Tables[0].Rows[0].ItemArray[2].ToString() + ", " +
                    ds.Tables[0].Rows[0].ItemArray[3].ToString();
                id = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[0].ToString());
                return id;


            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                Con.Close();

                return 0;

            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            if (row.Cells[13].Value.ToString().Length == 0)
            {
                goto fim;
            }
            if (MessageBox.Show("Deseja Realmente Alterar?", "ALTERAR", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {

                
                DateTime dt = DateTime.Today;
                string data = dt.ToString("dd/MM/yyyy HH:mm");
                try// verifica erros no bloco
                {

                    Con = new MySqlConnection(StringConexao.sCon());
                    string commando = "UPDATE solicitacao SET QTD = @QTD  WHERE ID = @ID ";

                    MySqlCommand cmd = new MySqlCommand(commando, Con);
                    cmd.Parameters.Add("@ID", MySqlDbType.Int32).Value = row.Cells[13].Value.ToString();
                    cmd.Parameters.Add("@QTD", MySqlDbType.Double).Value = (row.Cells[14].Value.ToString());
                    //cmd.Parameters.Add("@DataHora", MySqlDbType.Date).Value = (dt.ToString("yyyy-MM-dd"));
                    //cmd.Parameters.Add("@PrazoSolicitado", MySqlDbType.VarChar).Value = dt.AddDays(7).ToString("dd/MM/yyyy");
                    Con.Open();
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    rows2.Clear();
                    lblqtd2.Text = "QTD Seleção: " + rows2.Count.ToString();
                    EnviarEmailPietro.Clear();
                    EnviarEmailPCP.Clear();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    Con.Close();
                    rows2.Clear();
                    lblqtd2.Text = "QTD Seleção: " + rows2.Count.ToString();
                    EnviarEmailPietro.Clear();
                    EnviarEmailPCP.Clear();
                }
                //Email();
                atualiza();

            }

            fim:;

        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            if (row.Cells[13].Value.ToString().Length == 0)
            {
                goto fim;
            }
            if (MessageBox.Show("Deseja Realmente Deletar?", "DELETAR", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
               
                DateTime dt = DateTime.Today;
                string data = dt.ToString("dd/MM/yyyy HH:mm");
                try// verifica erros no bloco
                {

                    Con = new MySqlConnection(StringConexao.sCon());
                    string commando = "DELETE FROM solicitacao WHERE ID= @ID;";

                    MySqlCommand cmd = new MySqlCommand(commando, Con);
                    cmd.Parameters.Add("@ID", MySqlDbType.Int32).Value = row.Cells[13].Value.ToString();

                    Con.Open();
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    rows2.Clear();
                    lblqtd2.Text = "QTD Seleção: " + rows2.Count.ToString();
                    EnviarEmailPietro.Clear();
                    EnviarEmailPCP.Clear();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    Con.Close();
                    rows2.Clear();
                    lblqtd2.Text = "QTD Seleção: " + rows2.Count.ToString();
                    EnviarEmailPietro.Clear();
                    EnviarEmailPCP.Clear();
                }
                //Email();
                atualiza();
               

            }
            fim:;
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            btnAlterar.Enabled = true;
            btnDeletar.Enabled = true;
            btnFinaliza.Enabled = true;
            btnEstoqueMinimo.Enabled = true;
            DataGridViewRow row = dataGridView1.CurrentRow;

            if (row.Cells[14].Value.ToString().Length == 0)
            {
                goto fim;
            }

            //PedirQuantidade(row);

            rows2.Add(new LinhasGridView
            {
                Produto = row.Cells[0].Value.ToString(),
                Descricao = row.Cells[1].Value.ToString(),
                Unid = row.Cells[2].Value.ToString(),
                SaldoAtual = row.Cells[3].Value.ToString(),
                PedCompra = row.Cells[4].Value.ToString(),
                PrevFabric = row.Cells[5].Value.ToString(),
                EstqMinimo = row.Cells[6].Value.ToString(),
                ConsuPrevOs = row.Cells[7].Value.ToString(),
                EstqMaximo = row.Cells[8].Value.ToString(),
                Prateleira = row.Cells[9].Value.ToString(),
                Grupo = row.Cells[10].Value.ToString(),
                DiasSemMov = row.Cells[11].Value.ToString(),
                PEDIR = row.Cells[12].Value.ToString(),
                ID = row.Cells[13].Value.ToString(),
                QTD_Pedida = (double)row.Cells[14].Value, //PedirQuantidade(row),//
                OP = row.Cells[15].Value.ToString(),
                DataHora = row.Cells[16].Value.ToString(),
                PrazoPedidoQTD = row.Cells[17].Value.ToString(),
                Andamento = row.Cells[18].Value.ToString(),
                FimStattus = row.Cells[19].Value.ToString(),
                NFOk = row.Cells[20].Value.ToString(),
                PedirMais = row.Cells[21].Value.ToString(),
                Atrazado = row.Cells[22].Value.ToString(),
                Disponivel = row.Cells[23].Value.ToString(),
                PedVenda = row.Cells[24].Value.ToString(),

            });

            if (
                    row.Cells[0].Value.ToString().StartsWith("PP1-") |
                    row.Cells[0].Value.ToString().StartsWith("PP2-") |
                    row.Cells[0].Value.ToString().StartsWith("PP3-")
                    //|
                    //row.Cells[0].Value.ToString().Equals("HKHHBL-1287") |
                    //row.Cells[0].Value.ToString().Equals("HKHHCG-1213-03") |
                    //row.Cells[0].Value.ToString().Equals("HKHHCG-1243")
                    )
            {
                EnviarEmailPCP.Add(rows2.Last());
            }
            else
            {
                EnviarEmailPietro.Add(rows2.Last());
            }

            row.DefaultCellStyle.BackColor = Color.Aqua;

            lblqtd2.Text = "QTD Seleção: " + rows2.Count.ToString();
            fim:;
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }
    }
}
