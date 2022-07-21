using Estoque.Classes;
using Estoque.DAO;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace Estoque.Views
{
    public partial class frmEstoqueMinimo : Form
    {
        public frmEstoqueMinimo()
        {
            InitializeComponent();
            
        }
        HashSet<DataGridViewRow> rows = new HashSet<DataGridViewRow>();
        HashSet<string> SalvarDB = new HashSet<string>();
        object objeto = new ArrayList();
        ArrayList EnviarEmailPietro = new ArrayList();
        ArrayList EnviarEmailPCP = new ArrayList();

        MySqlConnection Con;
        public int id;

        private void btnEstoqueMinimo_Click(object sender, EventArgs e)
        {
            if (SalvarDB.Count == 0)
            {
                if (MessageBox.Show("Deseja Realmente Solicitar?", "SOLICITAR", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    DataGridViewRow row = dataGridView1.CurrentRow;
                    DateTime dt = DateTime.Now;
                    string data = dt.ToString("dd/MM/yyyy HH:mm");
                    try// verifica erros no bloco
                    {


                        Con = new MySqlConnection(StringConexao.sCon());
                        string commando = " INSERT INTO tblSolicitacao (Produto, Descricao, QTD, UND, DataHora, PrazoSolicitado) " +
                            "VALUES (@Produto, @Descricao, @QTD, @UND, @DataHora, @PrazoSolicitado)";
                        MySqlCommand cmd = new MySqlCommand(commando, Con);
                        cmd.Parameters.Add("@Produto", MySqlDbType.VarChar).Value = (row.Cells[0].Value.ToString());
                        cmd.Parameters.Add("@Descricao", MySqlDbType.VarChar).Value = (row.Cells[1].Value.ToString());
                        cmd.Parameters.Add("@QTD", MySqlDbType.Double).Value = (row.Cells[13].Value.ToString());
                        cmd.Parameters.Add("@UND", MySqlDbType.VarChar).Value = (row.Cells[2].Value.ToString());
                        cmd.Parameters.Add("@DataHora", MySqlDbType.VarChar).Value = (data);
                        cmd.Parameters.Add("@PrazoSolicitado", MySqlDbType.VarChar).Value = data;
                        Con.Open();
                        cmd.ExecuteNonQuery();
                        Con.Close();

                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                        Con.Close();
                    }
                    Email();
                    SalvarDB.Clear();
                    objeto = null;
                    atualiza();

                }

            }
            else
            {
                if (EnviarEmailPCP.Count > 0)
                {
                    EnviarEmailPCP.Insert(0, "PCP-1");
                    EmailMulti(EnviarEmailPCP);
                }
                if (EnviarEmailPietro.Count > 0)
                {
                    EnviarEmailPietro.Insert(0, "Pie-2");
                    EmailMulti(EnviarEmailPietro);
                }



                try
                {

                    Con = new MySqlConnection(StringConexao.sCon());
                    foreach (var item in SalvarDB)
                    {
                        DateTime dt = DateTime.Now;
                        string data = dt.ToString("dd/MM/yyyy HH:mm");

                        var sp = new string[] { ", " };
                        var i = item.Replace("'", "").Split(sp, StringSplitOptions.RemoveEmptyEntries);
                        //

                        string commando = " INSERT INTO tblSolicitacao (Produto, Descricao, QTD, UND, DataHora, PrazoSolicitado) " +
                            "VALUES (@Produto, @Descricao, @QTD, @UND, @DataHora, @PrazoSolicitado)";
                        MySqlCommand cmd = new MySqlCommand(commando, Con);
                        cmd.Parameters.Add("@Produto", MySqlDbType.VarChar).Value = (i[0]);
                        cmd.Parameters.Add("@Descricao", MySqlDbType.VarChar).Value = (i[1]);
                        cmd.Parameters.Add("@QTD", MySqlDbType.Double).Value = (i[2]);
                        cmd.Parameters.Add("@UND", MySqlDbType.VarChar).Value = (i[3]);
                        cmd.Parameters.Add("@DataHora", MySqlDbType.VarChar).Value = (data);
                        cmd.Parameters.Add("@PrazoSolicitado", MySqlDbType.VarChar).Value = dt.AddDays(7).ToString("dd/MM/yyyy");
                        Con.Open();
                        cmd.ExecuteNonQuery();
                        Con.Close();

                        //
                    }

                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    Con.Close();
                }

                SalvarDB.Clear();
                objeto = null;
                atualiza();
            }

        }

        private void EmailMulti(ArrayList EnviarEmail)
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
                    oMsg.To = "estoque@barbanera.com.br";
                    var v = 0;
                    foreach (IEnumerable itens in EnviarEmail)
                    {
                        foreach (DataGridViewTextBoxCell item in itens)
                        {
                            var x = item.Value.ToString();
                            if (item.Value.ToString().Contains("CAIXA DE PAPELAO") & v == 0)
                            {
                                oMsg.CC = "lrpsig@gmail.com";
                                v++;
                            }
                        }
                    }



                }

                StringBuilder mensagemPadrao = new StringBuilder();


                mensagemPadrao.AppendLine(saudacao + "<br/>");
                mensagemPadrao.AppendLine("Segue abaixo Solicitação de Materiais - Estoque Mínimo <br/>");
                mensagemPadrao.AppendLine("<br/>");

                foreach (IEnumerable itens in EnviarEmail)
                {
                    foreach (DataGridViewTextBoxCell item in itens)
                    {
                        if (item.Value is null)
                        {
                            continue;
                        }
                        switch (item.ColumnIndex)
                        {
                            case 0:
                                mensagemPadrao.AppendLine("Código: " + item.Value + "<br/>");
                                break;
                            case 1:
                                mensagemPadrao.AppendLine("Descrição: " + item.Value + "<br/>");
                                break;
                            case 2:
                                mensagemPadrao.AppendLine("Unid: " + item.Value + "<br/>");
                                break;
                            case 3:
                                mensagemPadrao.AppendLine("Saldo: " + item.Value + "<br/>");
                                break;
                            case 4:
                                mensagemPadrao.AppendLine("Estq Mímimo: " + item.Value + "<br/>");
                                break;
                            case 12:
                                mensagemPadrao.AppendLine("Qtd Pedida: " + item.Value + "<br/>");
                                break;
                            case 15:
                                mensagemPadrao.AppendLine("Prazo: " + data + "<br/>");
                                mensagemPadrao.AppendLine("-------------------------------------<br/><br/>");
                                break;


                        }
                    }

                }

                mensagemPadrao.AppendLine("<br/>Atenciosamente: <br/> Equipe do Estoque <br/>");


                oMsg.BodyFormat = Outlook.OlBodyFormat.olFormatPlain;

                oMsg.HTMLBody = "<html><h5>" + mensagemPadrao.ToString() + "</h5></html>";



                oMsg.Subject = "Solicitação de Materiais";
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
                mensagem.AppendLine("Qtd Pedida: " + row.Cells[13].Value.ToString() + "<br/>");
                mensagem.AppendLine("OP: Estoque Mínimo <br/>");
                mensagem.AppendLine("Prazo: " + DateTime.Today.AddDays(7).ToShortDateString() + "<br/>");

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


                oMsg.Subject = "Solicitação de Materiais";
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
            dataGridView1.Columns[11].DefaultCellStyle.ForeColor = Color.Red;
            dataGridView1.Columns[11].DefaultCellStyle.SelectionBackColor = Color.BlueViolet;

            dataGridView1.Columns[13].DefaultCellStyle.ForeColor = Color.Red;
            dataGridView1.Columns[13].DefaultCellStyle.Font = new Font(dataGridView1.Font, FontStyle.Bold);
            dataGridView1.Columns[13].DefaultCellStyle.SelectionBackColor = Color.Black;

            dataGridView1.Columns[16].DefaultCellStyle.ForeColor = Color.Red;
            dataGridView1.Columns[16].DefaultCellStyle.Font = new Font(dataGridView1.Font, FontStyle.Bold);
            dataGridView1.Columns[16].DefaultCellStyle.SelectionBackColor = Color.Black;


        }

        private void btnFinalizar(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja Realmente Finalizar?", "FINALIZAR", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                DataGridViewRow row = dataGridView1.CurrentRow;
                DateTime dt = DateTime.Now;
                string data = dt.ToString("dd/MM/yyyy HH:mm");
                try// verifica erros no bloco
                {


                    Con = new MySqlConnection(StringConexao.sCon());
                    string commando = " UPDATE tblSolicitacao SET FimStatus = @FimStatus WHERE ID = @ID";
                    MySqlCommand cmd = new MySqlCommand(commando, Con);
                    cmd.Parameters.Add("@ID", MySqlDbType.Int32).Value = (row.Cells[12].Value.ToString());
                    cmd.Parameters.Add("@FimStatus", MySqlDbType.VarChar).Value = data;

                    Con.Open();
                    cmd.ExecuteNonQuery();
                    Con.Close();

                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    Con.Close();
                }

                atualiza();
            }



        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
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

                string commando = "SELECT * FROM tblSolicitacao WHERE " + cbbPesquisar.Text + " LIKE '" + cbPesq + "' " +
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
        }

        private int BuscarID(DataGridViewRow row)
        {
            try
            {

                Con = new MySqlConnection(StringConexao.sCon()); // inicializa uma nova instancia da classe system.data.sqlcliente.sqlconnection onde recebe uma string que contem a connection string
                Con.Open();// abre a conexão4



                string commando = $"SELECT * FROM tblsolicitacao where " +
                    $"Produto = '{row.Cells[0].Value.ToString()}' AND " +
                    $"QTD = '{row.Cells[13].Value.ToString()}' " +
                    $"AND DataHora = '{row.Cells[15].Value.ToString()}' ";


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
                return Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[0].ToString());


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
            if (MessageBox.Show("Deseja Realmente Alterar?", "ALTERAR", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                DataGridViewRow row = dataGridView1.CurrentRow;
                DateTime dt = DateTime.Now;
                string data = dt.ToString("dd/MM/yyyy HH:mm");
                try// verifica erros no bloco
                {

                    Con = new MySqlConnection(StringConexao.sCon());
                    string commando = "UPDATE tblsolicitacao SET QTD = @QTD, PrazoSolicitado = @PrazoSolicitado, DataHora = @DataHora WHERE ID = @ID ";

                    MySqlCommand cmd = new MySqlCommand(commando, Con);
                    cmd.Parameters.Add("@ID", MySqlDbType.Int32).Value = row.Cells[12].Value.ToString();
                    cmd.Parameters.Add("@QTD", MySqlDbType.Double).Value = (row.Cells[13].Value.ToString());
                    cmd.Parameters.Add("@DataHora", MySqlDbType.VarChar).Value = (data);
                    cmd.Parameters.Add("@PrazoSolicitado", MySqlDbType.VarChar).Value = (row.Cells[16].Value.ToString());
                    Con.Open();
                    cmd.ExecuteNonQuery();
                    Con.Close();

                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    Con.Close();
                }
                //Email();
                atualiza();

            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja Realmente Deletar?", "DELETAR", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                DataGridViewRow row = dataGridView1.CurrentRow;
                DateTime dt = DateTime.Now;
                string data = dt.ToString("dd/MM/yyyy HH:mm");
                try// verifica erros no bloco
                {

                    Con = new MySqlConnection(StringConexao.sCon());
                    string commando = "DELETE FROM tblsolicitacao WHERE ID= @ID;";

                    MySqlCommand cmd = new MySqlCommand(commando, Con);
                    cmd.Parameters.Add("@ID", MySqlDbType.Int32).Value = row.Cells[12].Value.ToString();

                    Con.Open();
                    cmd.ExecuteNonQuery();
                    Con.Close();

                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    Con.Close();
                }
                //Email();
                atualiza();

            }
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            if (rows.Contains(row))
            {

            }
            else
            {
                rows.Add(row);


                var qtd = row.Cells[13].Value.ToString();

                SalvarDB.Add(
                    "'" + row.Cells[0].Value.ToString() + "', " + //produto
                    "'" + row.Cells[1].Value.ToString() + "', " + //descricao
                    "'" + row.Cells[13].Value.ToString() + "', " +//quantidade solicitada
                    "'" + row.Cells[2].Value.ToString() + "', " +//unidade de medida
                    "'" + "'<<DATA>>', " + // data e hora da solicitaçpão
                    "'" + row.Cells[16].Value.ToString() + "'" //data solicitada
                    );

                if (
                        row.Cells[0].Value.ToString().StartsWith("PP1-") |
                        row.Cells[0].Value.ToString().StartsWith("PP2-") |
                        row.Cells[0].Value.ToString().StartsWith("PP3-") |
                        row.Cells[0].Value.ToString().Equals("HKHHBL-1287") |
                        row.Cells[0].Value.ToString().Equals("HKHHCG-1213-03") |
                        row.Cells[0].Value.ToString().Equals("HKHHCG-1243")

                        )
                {
                    EnviarEmailPCP.Add(objeto = row.Cells);
                }
                else
                {
                    EnviarEmailPietro.Add(objeto = row.Cells);
                }

                row.DefaultCellStyle.BackColor = Color.Aqua;
            }
        }
    }
}
