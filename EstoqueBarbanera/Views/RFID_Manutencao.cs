using Estoque.Classes;
using Estoque.DAO;
using Estoque.Entidade;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estoque.Views
{
    public partial class RFID_Manutencao : Form
    {
        DataGridView dgvv = new DataGridView();
        private List<Leituras> ll = new List<Leituras>();
        private List<Leituras> ll2 = new List<Leituras>();
        private int seq;
        private string linha;
        private string fileName;
        private string texto;
        private List<Saldo> listaSaldo;

        public RFID_Manutencao()
        {
            InitializeComponent();
            Crud c = new Crud();
            listaSaldo = c.ListaSaldo();

        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            var ds = Pesquisar.Start2(cbbPesquisar.Text, txtPesquisar.Text);
            dgv.DataSource = ds.Tables[0];
            lblLinhas.Text = ds.Tables[0].Rows.Count.ToString() + " LINHAS RETORNADAS";
        }

        private void dgvDoubleClick_DClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgv.CurrentRow;

            string ProdutoL = row.Cells["Produto"].Value.ToString();
            if (ll2.FindAll(p => p.Produto == ProdutoL).Count > 0)
            {
                MessageBox.Show($"Ja exixtem os Produtos '{ProdutoL}' na Lista", "Item ambiguo");
                return;
            }

            if (e.ColumnIndex == 9)
            {
                txtPrateleira.Text = row.Cells["Prateleira"].Value.ToString();

                return;
            }

            if (ll.Count == 5)
            {
                MessageBox.Show("Lista com 5 Itens. Elimine na Lista", "Limite de 5 Itens");
                return;
            }

            var Produto = row.Cells["Produto"].Value.ToString();
            var Descricao = row.Cells["Descricao"].Value.ToString();
            var Unid = row.Cells["Unid"].Value.ToString();
            var Saldo = Convert.ToDecimal(row.Cells["SaldoAtual"].Value.ToString());
            var Livre17 = Convert.ToDecimal(row.Cells["Livre17"].Value.ToString() == "" ? 0 : Convert.ToDecimal(row.Cells["Livre17"].Value.ToString()));
            var Convertido = row.Cells["undConvtd"].Value.ToString() == "" ? 0 : Convert.ToDecimal(row.Cells["undConvtd"].Value.ToString());

            if (ll.Count > 0)
            {
                var repetido = ll.Exists(p => p.Produto == Produto);
                if (repetido)
                {
                    return;
                }
            }


            checkedListBox1.Items.Add(Produto + " ; " +
                           Descricao + " ; " +
                           Unid + " ; " +
                           Saldo + " ; " +
                           Livre17 + " ; " +
                           Convertido, true);

            ll.Add(new Leituras
            {
                Produto = Produto,
                Descricao = Descricao,
                Unid = Unid,
                SaldoAtual = Saldo.ToString(),
                Livre17 = Livre17.ToString(),
                Convertido = Convertido.ToString(),
                Seq = "",
                Prateleira = ""

            });
        }

        private void dgvCellValueChange_Click(object sender, DataGridViewCellEventArgs e)
        {
            var ee = e.ColumnIndex;
            var row = dgv.CurrentRow;
            var qtd = row.Cells["SaldoAtual"].Value.ToString();

            // // calcula kilo em metro
            //if (ee == 3) //quantidade mudada, mas convertido tambem >> qtd / l17 = convertido
            //{
            //    var saldo = Convert.ToDecimal(row.Cells["SaldoAtual"].Value.ToString());
            //    var liv17 = Convert.ToDecimal(row.Cells["Livre17"].Value.ToString() == "" ? "0" : row.Cells["Livre17"].Value.ToString());
            //    decimal convertido = 0;
            //    convertido = (liv17 == 0 ? convertido = 0 : saldo / liv17);
            //    dgv.Rows[e.RowIndex].Cells["undConvtd"].Value = Math.Round(convertido, 3);
            //}

            // // calcula metro em kilo
            if (ee == 13) //quantidade mudada, mas convertido tambem >> qtd / l17 = convertido
            {
                var UndConvtd = Convert.ToDecimal(row.Cells["UndConvtd"].Value.ToString());
                var liv17 = Convert.ToDecimal(row.Cells["Livre17"].Value.ToString() == "" ? "0" : row.Cells["Livre17"].Value.ToString());
                decimal SaldoAtual = 0;
                SaldoAtual = (liv17 == 0 ? SaldoAtual = 0 : UndConvtd * liv17);
                dgv.Rows[e.RowIndex].Cells["SaldoAtual"].Value = Math.Round(SaldoAtual, 3);
            }

        }

        private void CheckBoxList_DClick(object sender, EventArgs e)
        {
            var s = (CheckedListBox)sender;

            var ss = s.SelectedItem;
            checkedListBox1.Items.Remove(ss);
            var Produto = ss.ToString().Substring(0, ss.ToString().IndexOf(" ")).Trim();
            try
            {
                var r = ll.Where(p => p.Produto == Produto).First();
                ll.Remove(r);
                dgvAddCards.DataSource = DeListParaTable.ConvertListToTableGeneric<Leituras>(ll2);
            }
            catch (Exception)
            {
            }

        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            CriaFile(txtUIDCard);

            sendFile(fileName);

            LimpaControles();

        }

        private void CriaFile(TextBox uidCard)
        {
            if (uidCard.TextLength < 8)
            {
                MessageBox.Show("Campo UID Card incompleto");
                txtUIDCard.Focus();
                return;
            }
            if ((txtPrateleira.Text != ll[0].Prateleira) | txtPrateleira.TextLength == 0)
            {
                MessageBox.Show("Prencha o Campo Prateleira", "Prateleira!!");
                return;
            }
            seq = 1;
            var u = uidCard.Text;
            var uid = $"{u.Substring(0, 2)} {u.Substring(2, 2)} {u.Substring(4, 2)} {u.Substring(6, 2)}";

            var dir = Directory.CreateDirectory(@"C:\Exports\RFID");
            fileName = $@"C:\Exports\RFID\{uid} - {DateTime.Now.ToString("yyyy-MM-dd HHmmss")}.txt";
            var x = File.Create(fileName);
            x.Close();


            foreach (var l in ll)
            {
                l.ID = uid;
                l.Seq = seq.ToString();
                linha = $"{seq}\t{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}\t{l.ID}\t{l.Produto}\t{l.Descricao}\t{l.Unid}\t{l.SaldoAtual.ToString().Replace(",", ".")}\t{l.Prateleira}\t{l.Livre17.ToString().Replace(",", ".")}\t{l.Convertido.ToString().Replace(",", ".")}";
                File.AppendAllText(fileName, linha + "\n", Encoding.Default);
                seq++;
            }
        }

        private void LimpaControles()
        {
            ll.Clear();
            checkedListBox1.Items.Clear();
            txtUIDCard.Text = string.Empty;
            txtPrateleira.Text = string.Empty;
            seq = 0;
            linha = string.Empty;
        }

        private void btnAplicaPrateleira_Click(object sender, EventArgs e)
        {
            if (txtPrateleira.TextLength <= 0)
            {
                MessageBox.Show("Prateleira Vazia", "Prateleira");
                return;
            }
            if (ll.Count == 0)
            {
                MessageBox.Show("Primeiro preencha os dados dos itens", "Prateleira");
                return;
            }
            try
            {
                foreach (var l in ll)
                {
                    l.Prateleira = txtPrateleira.Text;
                }
                MessageBox.Show("Prateleira Aplicada", "Prateleira");
            }
            catch (Exception)
            {
                MessageBox.Show("ERRO PA... Pratelira Nao Aplicada", "Prateleira", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void UIDCard_KeyPress(object sender, KeyPressEventArgs e)
        {
            String f = e.KeyChar.ToString().ToUpper();
            string c = "ABCDEF1234567890";
            var verifica = c.Contains(f);
            if (verifica || e.KeyChar == (char)Keys.Back) ;
            else
                e.Handled = true;
        }

        private void btnSendFile_Click(object sender, EventArgs e)
        {
            sendFile(fileName);
        }

        private List<object> MontaObjeto(string texto)
        {
            List<Produto> lp = new List<Produto>();
            var linhas = texto.Split('\n').TakeWhile(p => p.Length > 0).ToList();

            foreach (var linha in linhas)
            {
                Produto p = new Produto();
                var colunas = linha.Split('\t');
                p.seq = colunas[0];
                p.dataHora = colunas[1];
                p.id = colunas[2];
                p.produto = colunas[3];
                p.deescricao = colunas[4];
                p.und = colunas[5];
                p.quantidade = colunas[6];
                p.prateleira = colunas[7];
                p.conversor = colunas[8];
                p.convertido = colunas[9];
                lp.Add(p);
            }
            //
            List<object> obj = new List<object>();
            obj.Add(fileName);
            obj.Add(lp);
            return obj;
        }

        private void sendFile(string fileName)
        {
            using (var client = new WebClient())
            {
                try
                {
                    var page = client.UploadFile("http://rfid.local/criacard", "POST", fileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERRO NA LEITORA, RESPOSTA SEM RETORNO", "PROVAVEL ERRO");
                }
            }
            //PARA TESTES
            /*
            for (int i = 0; i < 10; i++)
            {
                using (var client = new WebClient())
                {
                    try
                    {
                        var page = client.UploadFile("http://rfid.local/criacard", "POST", fileName);
                        break;
                    }
                    catch (Exception ex)
                    {
                        if (i == 9)
                        {
                            MessageBox.Show("ERRO NA LEITORA, RESPOSTA SEM RETORNO", "PROVAVEL ERRO");
                        }
                    }
                }
                Thread.Sleep(3000);
            }
            */
        }
        private void CriaCards()
        {
            for (int i = 0; i < 10; i++)
            {
                using (var client = new WebClient())
                {
                    try
                    {
                        var page = client.UploadFile("http://rfid.local/criacard", "POST", @"C:\Exports\CriaCards.txt");
                        break;
                    }
                    catch (Exception ex)
                    {
                        if (i == 9)
                        {
                            MessageBox.Show("ERRO NA LEITORA, RESPOSTA SEM RETORNO", "PROVAVEL ERRO");
                            break;
                        }
                    }
                }
                Thread.Sleep(3000);
            }
            MessageBox.Show("Dados Enviados", "Dados Enviados");
        }
        private void send1Item(string fileName)
        {
            for (int i = 0; i < 10; i++)
            {
                using (var client = new WebClient())
                {
                    try
                    {
                        var page = client.UploadFile("http://rfid.local/send1Item", "POST", fileName);
                        break;
                    }
                    catch (Exception ex)
                    {
                        if (i == 9)
                        {
                            MessageBox.Show("ERRO NA LEITORA, RESPOSTA SEM RETORNO", "PROVAVEL ERRO");
                            break;
                        }
                    }
                }
                Thread.Sleep(3000);
            }
            MessageBox.Show("Dados Enviados", "Dados Enviados");

        }

        private void BuscaFiles_Changes(object sender, EventArgs e)
        {
            if (txtBuscaUID.TextLength < 8)
            {
                return;
            }
            var u = txtBuscaUID.Text;
            var uid = $"{u.Substring(0, 2)} {u.Substring(2, 2)} {u.Substring(4, 2)} {u.Substring(6, 2)}";
            var path = @"C:\Exports\RFID";
            var dirs = Directory.GetFiles(path).ToList();
            var dirs2 = dirs.Where(p => p.Contains(uid)).OrderByDescending(p => p).ToList();
            listBox1.Items.Clear();
            foreach (var item in dirs2)
            {
                listBox1.Items.Add(item);
            }
        }

        private void ListBox_DClixk(object sender, EventArgs e)
        {
            texto = String.Empty;
            var s = (ListBox)sender;

            var path = (string)s.SelectedItem;
            fileName = path;
            texto = File.ReadAllText(path, Encoding.Default);
            MensagemView mv = new MensagemView(texto);
            mv.ShowDialog();
        }

        private void btnCriaPasta_Click(object sender, EventArgs e)
        {
            using (var client = new WebClient())
            {
                try
                {
                    var page = client.UploadString("http://rfid.local/criapasta", "?????????");
                }
                catch (Exception ex)
                {
                }
            }
        }

        private void btnDelPasta_Click(object sender, EventArgs e)
        {
            using (var client = new WebClient())
            {
                try
                {
                    var page = client.UploadString("http://rfid.local/delpasta", "???????????");
                }
                catch (Exception)
                {
                }
            }
        }

        private void btnInclui1Item_Click(object sender, EventArgs e)
        {
            var posicao = comboBox1.Text;
            if (posicao == "POSICAO")
            {
                MessageBox.Show("ESCOLHA UMA POSICAO");
                return;
            }
            if (txtPrateleira.TextLength == 0 | ll[0].Prateleira.Length == 0)
            {
                MessageBox.Show("Selecione uma prateleira");
                return;
            }

            CriaFile(txtInclui1Item);

            MudaPosicao(fileName);

            send1Item(fileName);

            LimpaControles();
        }

        private void MudaPosicao(string fileName)
        {
            var posicao = comboBox1.Text;
            String newPosition = String.Empty;
            switch (posicao)
            {
                case "DISPONIVEL": newPosition = "6"; break;
                case "1": newPosition = "1"; break;
                case "2": newPosition = "2"; break;
                case "3": newPosition = "3"; break;
                case "4": newPosition = "4"; break;
                case "5": newPosition = "5"; break;
            }
            var texto = File.ReadAllText(fileName);
            var textoRemove = texto.Remove(0, 1);
            var textoInsert = textoRemove.Insert(0, newPosition);
            File.WriteAllText(fileName, textoInsert, Encoding.Default);
        }
        private void CellEndEdit2(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    var dgv = (DataGridView)sender;
                    var Produto = dgv.CurrentCell.Value.ToString().ToUpper();

                    var lista = listaSaldo.Where(p => p.Produto == Produto).ToList().First();
                    dgvMovimentos2.Rows[e.RowIndex].Cells["Codigo"].Value = lista.Produto;
                    dgvMovimentos2.Rows[e.RowIndex].Cells["Descricao"].Value = lista.Descricao;
                    dgvMovimentos2.Rows[e.RowIndex].Cells["SaldoAtual"].Value = lista.Livre17 == 0 ? Math.Round((decimal)lista.SaldoAtual, 3).ToString().Replace(",", ".") : Math.Round((decimal)lista.SaldoAtual / lista.Livre17, 2).ToString().Replace(",", ".");
                    dgvMovimentos2.Rows[e.RowIndex].Cells["Prateleira"].Value = lista.Prateleira;
                    if (lista.Prateleira == "")
                    {
                        dgvMovimentos2.Rows[e.RowIndex].Cells["Prateleira"].ReadOnly = false;
                        dgvMovimentos2.Rows[e.RowIndex].Cells["Prateleira"].Style.BackColor = Color.Coral;
                    }
                }
                if (e.ColumnIndex == 3)
                {
                    dgvMovimentos2.Rows[e.RowIndex].Cells["Prateleira"].Value = dgvMovimentos2.Rows[e.RowIndex].Cells["Prateleira"].Value.ToString().ToUpper();
                }
                if (e.ColumnIndex == 4 | e.ColumnIndex == 5)
                {
                    decimal Saida = Math.Round(dgvMovimentos2.Rows[e.RowIndex].Cells["Saida"].Value == null ? 0.00M : Convert.ToDecimal(dgvMovimentos2.Rows[e.RowIndex].Cells["Saida"].Value), 2);
                    decimal Entrada = Math.Round(dgvMovimentos2.Rows[e.RowIndex].Cells["Entrada"].Value == null ? 0.00M : Convert.ToDecimal(dgvMovimentos2.Rows[e.RowIndex].Cells["Entrada"].Value), 2);
                    decimal SaldoAtual = Math.Round(Convert.ToDecimal(dgvMovimentos2.Rows[e.RowIndex].Cells["SaldoAtual"].Value.ToString().Replace(".", ",")), 2);
                    //decimal Livre17 = Convert.ToDecimal(dgvMovimentos2.Rows[e.RowIndex].Cells["SaldoAtual"].Value.ToString().Replace(".", ","));
                    var SaldoES = Entrada - Saida == 0 ? 0.00M : Math.Round(Entrada - Saida, 2);
                    //decimal livre17 = listaSaldo.Where(p => p.Produto == dgvMovimentos2.Rows[e.RowIndex].Cells["Codigo"].Value.ToString()).ToList().First().Livre17;
                    decimal ResultFinal = Entrada - Saida == 0 ? 0.00M : Math.Round(SaldoAtual + SaldoES, 2);
                    dgvMovimentos2.Rows[e.RowIndex].Cells["SaldoES"].Value = Math.Round(SaldoES, 2).ToString().Replace(",", ".");
                    dgvMovimentos2.Rows[e.RowIndex].Cells["ResultadoFinal"].Value = Math.Round(ResultFinal, 2).ToString().Replace(",", ".");
                    dgvMovimentos2.Rows[e.RowIndex].Cells["Atualiza"].Value = 0.00M;

                    AtualizaAnotacao();
                }
                if (e.ColumnIndex == 8)
                {
                    decimal Saida = 0.00M;
                    decimal Entrada = 0.00M;
                    decimal SaldoAtual = 0.00M;
                    var SaldoES = 0.00M;
                    decimal livre17 = listaSaldo.Where(p => p.Produto == dgvMovimentos2.Rows[e.RowIndex].Cells["Codigo"].Value.ToString()).ToList().First().Livre17;
                    decimal ResultFinal = 0.00M;
                    dgvMovimentos2.Rows[e.RowIndex].Cells["Saida"].Value = 0.00M;
                    dgvMovimentos2.Rows[e.RowIndex].Cells["Entrada"].Value = 0.00M;
                    dgvMovimentos2.Rows[e.RowIndex].Cells["SaldoES"].Value = 0.00M;
                    dgvMovimentos2.Rows[e.RowIndex].Cells["ResultadoFinal"].Value = 0.00M;

                    AtualizaAnotacao();
                }
            }
            catch (Exception ex)
            { }
        }

        private void AtualizaAnotacao()
        {
            AnotacaoRFID arfid;
            List<AnotacaoRFID> la = new List<AnotacaoRFID>();
            foreach (DataGridViewRow row in dgvMovimentos2.Rows)
            {
                if (row.Cells["Codigo"].Value == null)
                {
                    continue;
                }
                arfid = new AnotacaoRFID();
                arfid.Produto = row.Cells["Codigo"].Value.ToString().ToUpper();
                arfid.Descricao = row.Cells["Descricao"].Value.ToString();
                arfid.SaldoAtual = row.Cells["SaldoAtual"].Value.ToString();
                arfid.Prateleira = row.Cells["Prateleira"].Value.ToString();
                arfid.Saida = Math.Round(row.Cells["Saida"].Value == null ? 0M : Convert.ToDecimal(row.Cells["Saida"].Value.ToString()), 2);
                arfid.Entrada = Math.Round(row.Cells["Entrada"].Value == null ? 0M : Convert.ToDecimal(row.Cells["Entrada"].Value.ToString()), 2);
                arfid.SaldoES = Math.Round(Convert.ToDecimal(row.Cells["SaldoES"].Value.ToString().Replace(".", ",")), 2);
                arfid.ResultadoFinal = Math.Round(Convert.ToDecimal(row.Cells["ResultadoFinal"].Value.ToString().Replace(".", ",")), 2);
                arfid.Atualiza = Math.Round(Convert.ToDecimal(row.Cells["Atualiza"].Value.ToString()), 2);
                la.Add(arfid);
            }
            Crud c = new Crud();
            c.ExcluiTudoAnotacaoRFID();
            if (la.Count > 0)
            {
                c.AdicionaAnotacaoRFID(la);
            }
        }

        private void btnLimpalinha_Click(object sender, EventArgs e)
        {
            try
            {
                var dc = dgvMovimentos2.CurrentRow;
                dgvMovimentos2.Rows.Remove(dc);
                AtualizaAnotacao();
            }
            catch (Exception ex)
            {
            }
        }

        private void btnLimpaTudo_Click(object sender, EventArgs e)
        {
            dgvMovimentos2.Rows.Clear();
            Crud c = new Crud();
            c.ExcluiTudoAnotacaoRFID();
        }

        private void Load_L(object sender, EventArgs e)
        {
            RecuperaGridSendCards();

            Crud c = new Crud();
            var nota = c.ListaAnotacaoRFID().OrderBy(p => p.Prateleira).ToList();
            ///dgvMovimentos2.DataSource = nota;
            int i = 0;
            if (nota.Count > 0)
            {
                dgvMovimentos2.Rows.Add(nota.Count);
            }
            foreach (var item in nota)
            {
                dgvMovimentos2.Rows[i].Cells["Codigo"].Value = item.Produto;
                dgvMovimentos2.Rows[i].Cells["Descricao"].Value = item.Descricao;
                dgvMovimentos2.Rows[i].Cells["SaldoAtual"].Value = item.SaldoAtual;
                dgvMovimentos2.Rows[i].Cells["Prateleira"].Value = item.Prateleira;
                dgvMovimentos2.Rows[i].Cells["Saida"].Value = Math.Round(item.Saida, 2);
                dgvMovimentos2.Rows[i].Cells["Entrada"].Value = Math.Round(item.Entrada, 2);
                dgvMovimentos2.Rows[i].Cells["SaldoES"].Value = Math.Round(item.SaldoES, 2);
                dgvMovimentos2.Rows[i].Cells["ResultadoFinal"].Value = Math.Round(item.ResultadoFinal, 2);
                dgvMovimentos2.Rows[i].Cells["Atualiza"].Value = Math.Round(item.Atualiza, 2);
                i++;
            }

            dgvMovimentos2.Columns["Codigo"].DefaultCellStyle.BackColor = Color.LightGreen;
            dgvMovimentos2.Columns["Saida"].DefaultCellStyle.BackColor = Color.Cyan;
            dgvMovimentos2.Columns["Entrada"].DefaultCellStyle.BackColor = Color.Coral;
            dgvMovimentos2.Columns["Atualiza"].DefaultCellStyle.BackColor = Color.DarkSeaGreen;

        }

        private void btnSendCartaoES_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dgvMovimentos2.Rows)
            {
                if (item.Cells["Codigo"].Value == null)
                {
                    continue;
                }
                if (item.Cells["Prateleira"].Value == null)
                {
                    MessageBox.Show("PREENCHA O CAMPO PRATELEIRA", "PRATELEIRA ERRO");
                    return;
                }
            }
            //DEIXA APENAS OS DEZ ULTIMOS
            var s = Directory.GetFiles($@"C:\Exports", "*AtuaCard*.txt", SearchOption.TopDirectoryOnly).OrderByDescending(p => p).ToList().Skip(10).ToList();
            foreach (var item in s)
            {
                File.Delete(item);
            }
            StringBuilder sb = new StringBuilder();
            Crud c = new Crud();
            var lista = c.ListaAnotacaoRFID().OrderBy(p => p.Prateleira);
            string operadorConversor = string.Empty;
            foreach (var item in lista)
            {
                var itx = listaSaldo.Where(p => p.Produto == item.Produto).First();
                if (itx.Grupo == "12000000" & itx.Unid == "KG" & itx.Livre17 > 0M)
                {
                    operadorConversor = "M";
                }
                else if (itx.Livre17 > 0M)
                {
                    operadorConversor = "D";
                }
                else { operadorConversor = "N"; }


                var prateleiraPermitidas = PrateleirasPermitidas.ObterListaSiglas();
                bool b = false;
                foreach (var pp in prateleiraPermitidas)
                {
                    if (item.Prateleira.StartsWith(pp))
                    {
                        b = true;
                    }
                }
                if (b == false)
                {
                    continue;
                }
                var cod = item.Produto;
                var qtd = item.SaldoES;
                var atu = item.Atualiza;
                string opr = string.Empty; // SM = Somar; SB = Subtrair;
                string ptl = item.Prateleira;
                if (atu > 0)
                {
                    opr = "A";
                    sb.AppendLine($"{cod};{Math.Round(atu, 2).ToString().Replace(",", ".")};{opr};{ptl};{operadorConversor}");

                }
                else
                {
                    if (qtd == 0)
                    {
                        opr = "Z";
                    }
                    if (qtd > 0)
                    {
                        opr = "+";
                    }
                    if (qtd < 0)
                    {
                        opr = "-";
                    }
                    qtd = qtd > 0 ? qtd : qtd * -1;
                    string qtdS = Math.Round(qtd, 2).ToString().Replace(",", ".");
                    sb.AppendLine($"{cod};{qtdS.Replace(",", ".")};{opr};{ptl};{operadorConversor}");
                }
            }


            fileName = $@"C:\Exports\AtuaCard_{DateTime.Now.ToString("yyyy-MM-dd HHmmss")}.txt";
            File.AppendAllText(fileName, sb.ToString().Trim(), Encoding.UTF8);
            for (int i = 0; i < 10; i++)
            {
                using (var client = new WebClient())
                {
                    try
                    {
                        client.UploadFile("http://rfid.local/atuacard", fileName);
                        break;
                    }
                    catch (Exception ex)
                    {
                        if (i == 9)
                        {
                            MessageBox.Show("ERRO NA LEITORA, RESPOSTA SEM RETORNO", "PROVAVEL ERRO");
                        }
                    }
                }
                Thread.Sleep(3000);
            }
            MessageBox.Show("Dados Enviados", "Dados Enviados");
        }

        private void btnObterListaDeArquivosESP32_Click(object sender, EventArgs e)
        {
            ObterListaDeArquivosESP32();
        }

        private void ObterListaDeArquivosESP32()
        {
            String textobruto = string.Empty;
            List<String> arquivos = new List<string>();
            using (WebClient wc = new WebClient())
            {
                try
                {
                    textobruto = wc.DownloadString("http://rfid.local/");
                }
                catch (Exception ex)
                { }
            }
            var linhas = textobruto.Split('/').ToList().FindAll(prop => prop.Contains(".txt'>"));
            linhas.Sort();
            var ln = linhas.Distinct().ToList();
            clbArquivosESP32.Items.Clear();
            foreach (var item in ln)
            {
                clbArquivosESP32.Items.Add("/" + item.Replace("'>", ""));
            }
        }

        private void btnDeletarSelecao_Click(object sender, EventArgs e)
        {
            List<string> ls = new List<string>();

            foreach (var item in clbArquivosESP32.CheckedItems)
            {
                ls.Add(item.ToString());
            }

            foreach (var item in ls)
            {
                using (var client = new WebClient())
                {
                    try
                    {
                        client.UploadString(new Uri("http://rfid.local/delfile"), item);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERRO NA LEITORA, RESPOSTA SEM RETORNO. erro: " + ex, "PROVAVEL ERRO");
                    }
                    Thread.Sleep(1000);
                }
            }
            ObterListaDeArquivosESP32();
        }

        private void btnAddCard_Click(object sender, EventArgs e)
        {
            //se o ID esta na mesma prateleira
            try
            {
                List<Leituras> ll5 = new List<Leituras>();
                ll5.AddRange(ll);
                ll5.AddRange(ll2);

                var dist = ll5.Distinct().ToList();
                foreach (var item in dist)
                {
                    var fall = ll5.FindAll(p => p.ID == item.ID);
                    var prats = fall.GroupBy(p => p.Prateleira).ToList();
                    if (prats.Count > 1)
                    {
                        string prat = "";
                        foreach (var item2 in prats)
                        {
                            prat += item2.Key + ", ";
                        }
                        MessageBox.Show($"Essa ID '{item.ID}' esta em mais de uma Prateleira '{prat}'", " ERRO de ID vs Prateleira");
                        return;
                    }
                }
            }
            catch (Exception)
            {
            }

            if (txtUIDCard.TextLength < 8)
            {
                MessageBox.Show("Campo UID Card incompleto");
                txtUIDCard.Focus();
                return;
            }
            if ((txtPrateleira.Text != ll[0].Prateleira) | txtPrateleira.TextLength == 0)
            {
                MessageBox.Show("Prencha o Campo Prateleira", "Prateleira!!");
                return;
            }
            if (ll.Count <= 0)
            {
                MessageBox.Show("Add Dados do Grid", "Dados do Grid!!");
                return;
            }

            int i = 1;
            var ll3 = ll2.FindAll(p => p.ID == txtUIDCard.Text);
            if ((ll3.Count + ll.Count) > 5)
            {
                MessageBox.Show("A quantidade de itens por cartao excedeu 5 itens", "Quantidade Excessiva");
                return;
            }
            if (ll3.Count > 0)
            {
                i = ll3.Count + 1;
            }

            string igual = "";
            foreach (var item1 in ll)
            {
                foreach (var item2 in ll2)
                {
                    if (item1.Produto == item2.Produto)
                    {
                        igual += item1.Produto + ", ";
                    }
                }
            }
            if (igual != "")
            {
                MessageBox.Show($"Ja exixtem os Produtos '{igual}' na Lista", "Item ambiguo");
                return;
            }

            string id1 = txtUIDCard.Text.Substring(0, 2);
            string id2 = txtUIDCard.Text.Substring(2, 2);
            string id3 = txtUIDCard.Text.Substring(4, 2);
            string id4 = txtUIDCard.Text.Substring(6, 2);
            string newID = $"{id1} {id2} {id3} {id4}";



            ll.ForEach(p => p.ID = newID);
            ll.ForEach(p => p.Seq = i++.ToString());
            ll.ForEach(p => p.Data = DateTime.Now);
            ll2.AddRange(ll);
            var ll4 = ll2.OrderBy(p => p.ID).ToList();
            ll2.Clear();
            ll2.AddRange(ll4);
            dgvAddCards.DataSource = DeListParaTable.ConvertListToTableGeneric<Leituras>(ll2);
            SalvaListaSenCards();
            LimpaControles();
        }

        private void SalvaListaSenCards()
        {
            List<string> ls = new List<string>();
            StringBuilder sb = new StringBuilder();
            foreach (var x in ll2)
            {
                sb.AppendLine($"{x.Seq}\t{x.Data}\t{x.ID}\t{x.Produto}\t{x.Descricao}\t{x.Unid}\t{x.Prateleira}\t{x.SaldoAtual.ToString().Replace(",", ".")}\t{x.Livre17.ToString().Replace(",", ".")}\t{x.Convertido.ToString().Replace(",", ".")}");
            }
            string notas = sb.ToString();
            notas.Trim();
            File.Delete($@"C:/Exports/CriaCards.txt");
            File.AppendAllText($@"c:/Exports/CriaCards.txt", notas);
        }

        private void btnSendCards_Click(object sender, EventArgs e)
        {
            LimpaControles();
            ll2.Clear();
            CriaCards();


        }

        private void btnSelecionaTudo_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clbArquivosESP32.Items.Count; i++)
            {
                clbArquivosESP32.SetItemChecked(i, true);
            }

        }

        private void btnDeletaLinha_Click(object sender, EventArgs e)
        {
            try
            {
                var dc = dgvAddCards.CurrentRow;
                var Produto = dc.Cells["Produto"].Value.ToString();
                ll2.RemoveAll(p => p.Produto == Produto);
                dgvAddCards.Rows.Remove(dc);
                SalvaListaSenCards();
            }
            catch (Exception ex)
            {
            }
        }

        private void dgvAddCards_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgvAddCards.CurrentRow;
            decimal SaldoAtual = Math.Round(Convert.ToDecimal(row.Cells["SaldoAtual"].Value.ToString().Replace(".", ",")), 3);
            decimal Livre17 = Convert.ToDecimal(row.Cells["Livre17"].Value.ToString().Replace(".", ","));
            decimal Convertido = Math.Round(Convert.ToDecimal(row.Cells["Convertido"].Value.ToString().Replace(".", ",")), 2);
            string Produto = row.Cells["Produto"].Value.ToString();
            decimal NewConvertido = 0M;
            decimal NewSaldoAtual = 0M;
            decimal NewLivre17 = 0M;


            //new SaldoAtual e Livre17
            if (e.ColumnIndex == 7 | e.ColumnIndex == 8)
            {
                NewConvertido = Livre17 == 0 ? 0M : Math.Round(SaldoAtual / Livre17, 2);
                NewLivre17 = Livre17;
                NewSaldoAtual = SaldoAtual;
                dgvAddCards.Rows[e.RowIndex].Cells["Convertido"].Value = NewConvertido.ToString();

            }

            //new Convertido
            if (e.ColumnIndex == 9)
            {
                NewSaldoAtual = Math.Round(Convertido * Livre17, 3);
                NewLivre17 = Livre17;
                NewConvertido = Convertido;
                dgvAddCards.Rows[e.RowIndex].Cells["SaldoAtual"].Value = Math.Round(NewSaldoAtual, 3);
            }

            var hh = ll2.Find(p => p.Produto == Produto);
            foreach (var item in ll2)
            {
                if (item.Produto == hh.Produto)
                {
                    item.SaldoAtual = NewSaldoAtual.ToString();
                    item.Livre17 = NewLivre17.ToString();
                    item.Convertido = NewConvertido.ToString();
                }
            }

            AtualizaTXT();
            SalvaListaSenCards();
        }

        private void AtualizaTXT()
        {
            ll2.Clear();
            foreach (DataGridViewRow item in dgvAddCards.Rows)
            {
                if (item.Cells["Produto"].Value == null)
                {
                    break;
                }
                ll2.Add(new Leituras
                {
                    Seq = item.Cells["Seq"].Value.ToString(),
                    Data = Convert.ToDateTime(item.Cells["Data"].Value.ToString()),
                    ID = item.Cells["ID"].Value.ToString(),
                    Produto = item.Cells["Produto"].Value.ToString(),
                    Descricao = item.Cells["Descricao"].Value.ToString(),
                    Unid = item.Cells["Unid"].Value.ToString(),
                    Prateleira = item.Cells["Prateleira"].Value.ToString(),
                    SaldoAtual = item.Cells["SaldoAtual"].Value.ToString(),
                    Livre17 = item.Cells["Livre17"].Value.ToString(),
                    Convertido = item.Cells["Convertido"].Value.ToString()
                });
            }
        }

        private void btnRecuperaGrid_Click(object sender, EventArgs e)
        {
            RecuperaGridSendCards();
        }

        private void RecuperaGridSendCards()
        {
            try
            {
                var linhas = File.ReadAllLines($@"C:/Exports/CriaCards.txt").ToList();
                ll2.Clear();
                dgvAddCards.Rows.Clear();
                foreach (var l in linhas)
                {
                    var tl = l.Split('\t');
                    ll2.Add(new Leituras
                    {
                        Seq = tl[0],
                        Data = Convert.ToDateTime(tl[1]),
                        ID = tl[2],
                        Produto = tl[3],
                        Descricao = tl[4],
                        Unid = tl[5],
                        Prateleira = tl[6],
                        SaldoAtual = tl[7],
                        Livre17 = tl[8],
                        Convertido = tl[9]

                    }); ;

                }
                var ll4 = ll2.OrderBy(p => p.ID).ToList();
                ll2.Clear();
                ll2.AddRange(ll4);
                DataTable dt = DeListParaTable.ConvertListToTableGeneric<Leituras>(ll2);
                dgvAddCards.DataSource = dt;
            }
            catch (Exception)
            {

            }
        }

        private void btnClearGrid_Click(object sender, EventArgs e)
        {
        F:
            try
            {
                int qtd = dgvAddCards.Rows.Count;

                if (qtd == 1)
                {
                    ll2.Clear();
                    return;
                }

                for (int i = 0; i < qtd; i++)
                {
                    dgvAddCards.Rows.RemoveAt(i);
                }
            }
            catch (Exception ex)
            {
                goto F;
                Debug.WriteLine(ex.Message);
            }
        }

        private void btnAlteraPrateleira_Click(object sender, EventArgs e)
        {
            var linhas = dgvAddCards.SelectedRows;
            if (linhas.Count == 0)
            {
                MessageBox.Show("Selecione a linha inteira","SELECIONE UMA LINHA");
                return;
            }
            List<Prateleiras> la = new List<Prateleiras>();
            foreach (DataGridViewRow item in linhas)
            {
                Prateleiras p = new Prateleiras();
                p.Produto = item.Cells["Produto"].Value.ToString();
                p.Descricao = item.Cells["Descricao"].Value.ToString();
                p.PrateleiraAtual = listaSaldo.Where(g => g.Produto == p.Produto).FirstOrDefault().Prateleira;
                p.PrateleiraNova = item.Cells["Prateleira"].Value.ToString();
                la.Add(p);
            }

            PrateleiraAtualiza.SalvaTXT(la);
            MessageBox.Show("Pedido incluso na lista feito com sucesso", "PEDIDO PARA ALTERAR PRATELEIRA");


        }

        private void cellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgvAddCards.CurrentRow;
            if (e.ColumnIndex == 6)
            {
                row.Cells["Prateleira"].Value = row.Cells["Prateleira"].Value.ToString().ToUpper();
            }
        }
    }
    [Serializable()]
    internal class Produto
    {
        internal string seq;
        internal string dataHora;
        internal string id;
        internal string produto;
        internal string deescricao;
        internal string und;
        internal string quantidade;
        internal string prateleira;
        internal string conversor;
        internal string convertido;
    }
}
