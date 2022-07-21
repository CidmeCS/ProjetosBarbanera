using Estoque.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using Estoque.Entidade;
using Estoque.DAO;
using System.Threading;
using Microsoft.EntityFrameworkCore.Internal;
using MoreLinq;
using System.Diagnostics;

namespace Estoque.Views
{
    public partial class RFID_Inventario : Form
    {
        List<String> links;
        private List<Leituras> leituras;
        String linha;
        private string linhaDgvLeituras;
        private string linhaDgvInventarios;
        private string ipConectado;
        private List<Divergentes> dv;
        private string ip;
        List<string> column = new List<string>() { "Produto", "Descricao", "Unid", "Prateleira", "SaldoSistema", "SaldoEtiqueta", "SaldoDivergente", "Livre17Sistema", "Livre17Etiqueta", "ConvertidoSistema", "ConvertidoEtiqueta", "ConvertidoDivergente", "STATUS" };
        private List<Saldo> saldo = new List<Saldo>();

        public RFID_Inventario()
        {
            InitializeComponent();
        }

        private void RFID_Load(object sender, EventArgs e)
        {
            Start();
            CarregaPendencias();
            Crud crd = new Crud();
            saldo = crd.ListaSaldo();
        }

        private void btnObterLinks_Click(object sender, EventArgs e)
        {
            Start();
        }

        public void Start()
        {
            using (WebClient wc = new WebClient())
            {
                try
                {
                    webBrowser1.Navigate(new Uri("http://rfid.local/"));
                }
                catch (Exception ex)
                { }
            }

        }

        private void ObterDados(Stream page)
        {
            try
            {
                StreamReader sr = new StreamReader(page, Encoding.Default);

                links = new List<string>();

                while ((linha = sr.ReadToEnd()) != null)
                {
                    var dd = linha.Split(new string[] { "Lista de Inventarios:</br><a href='", "'", "/a", "/br", "a ", "<", ">", "<a>", "</a>", "</br>", "<br>", "href='", "<a " }, StringSplitOptions.RemoveEmptyEntries).Distinct().OrderBy(p => p).ToList();
                    links.AddRange(dd);
                    var inventarios = links.Where(p => p.Contains("Inventarios")).ToList();
                    var leituras = links.Where(p => p.Contains("Leituras")).ToList();

                    inventarios.Sort();
                    leituras.Sort();

                    inventarios.Reverse();
                    leituras.Reverse();

                    DeListParaTable dlpt = new DeListParaTable();
                    var inv = dlpt.ConvertListToDataTableListString(inventarios);
                    var lei = dlpt.ConvertListToDataTableListString(leituras);

                    //dgvInventarios.DataSource = inv;
                    //dgvLeituras.DataSource = lei;
                    //dgvInventarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    //dgvLeituras.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    break;
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void btnAddIP_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> ip = new List<string>();
                IPAddress ipaddress = IPAddress.Parse(txtIP.Text);
                ip.Add(ipaddress.ToString());
                File.AppendAllLines("C:\\Exports\\IPs.txt", ip);
            }
            catch (Exception)
            {
                MessageBox.Show("IP Inválido", "ERRO");
                return;
            }
        }
        private void ObterDadosDoLinkDistintos()
        {
            lblLinkCarregadp.Text = "Link Carregado...";
            string nwc = String.Empty;
            using (WebClient wc = new WebClient())
            {
                try
                {

                    nwc = wc.DownloadString(webBrowser1.Url);
                    //Thread.Sleep(2000);

                }
                catch (Exception ex)
                {
                    Start();
                    dgvResult.DataSource = "";
                    return; //nwc = wc.DownloadString(webBrowser1.Url);
                }
            }
            var linhas = nwc.Split('\n', '\r').ToList();
            leituras = new List<Leituras>();
            foreach (var linha in linhas)
            {
                var cells = linha.Split('\t');

                if (cells[0].Length == 0)
                {
                    continue;
                }

                Leituras l = new Leituras();
                l.Seq = cells[0];
                l.Data = Convert.ToDateTime(cells[1]);
                l.ID = cells[2];
                l.Produto = cells[3];
                l.Descricao = cells[4];
                l.Unid = cells[5];
                l.SaldoAtual = cells[6].Replace(".", ",");
                l.Prateleira = cells[7];
                l.Livre17 = cells[8].Replace(".", ",");
                l.Convertido = cells[9] == "" ? "0" : cells[9].Replace(".", ",");
                leituras.Add(l);
            }

            leituras.Reverse();

            var leiturasDistintas = leituras.DistinctBy(m => new { m.ID, m.Produto }).ToList();
            leituras.Clear();
            leituras.AddRange(leiturasDistintas);

            leituras.Reverse();

            DeListParaTable dlpt = new DeListParaTable();
            var inv = dlpt.ConvertListToDataTable(leituras);
            dgvResult.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResult.DataSource = inv;

            var uidsDistintas = leituras.GroupBy(p => p.ID).Count();
            lblLinkCarregadp.Text = $"Link Carregado: {webBrowser1.Url},  QTD UIDs: {uidsDistintas}, QTD Itens {leituras.Count}";
            faltouLer(leituras);
        }



        private void faltouLer(List<Leituras> leituras)
        {
            var Prateliras = PrateleirasPermitidas.ObterListaPrateleiras();
            var Lidas = leituras.Select(p => p.Prateleira).ToList();


            var FaltouLer = Prateliras.Except(Lidas).OrderBy(p => p).ToList();

            DeListParaTable dlpt = new DeListParaTable();
            var inv = dlpt.ConvertListToDataTableListString(FaltouLer);
            dgvFaltouLer.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFaltouLer.DataSource = inv;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void wbNavegado_Click(object sender, WebBrowserNavigatedEventArgs e)
        {

            var pg = webBrowser1.DocumentText.StartsWith("Lista");
            if (pg | webBrowser1.DocumentText == "")
            {
                return;
            }

            var url = webBrowser1.Url;
            webBrowser1.GoBack();
            //ObterDadosDoLinkALL();
            ObterDadosDoLinkDistintos();

        }

        private void btnCompareInventario_Click(object sender, EventArgs e)
        {
            CompareInventario(true);
        }

        private void CompareInventario(bool b)
        {
            if (leituras == null)
            {
                MessageBox.Show("Selecione um inventário");
                return;
            }
            dv = new List<Divergentes>();
            Crud c = new Crud();
            var saldo = c.ListaSaldo();
            foreach (var item in leituras)
            {
                var r = saldo.Where(p => p.Produto == item.Produto).First();
                if (r != null)
                {
                    Divergentes d = new Divergentes();
                    d.Produto = r.Produto;
                    d.Descricao = r.Descricao;
                    d.Unid = r.Unid;
                    d.Prateleira = r.Prateleira == item.Prateleira ? r.Prateleira : "S: " + r.Prateleira + ", E: " + item.Prateleira;
                    d.SaldoSistema = (decimal)r.SaldoAtual;
                    d.SaldoEtiqueta = Convert.ToDecimal(item.SaldoAtual);
                    d.SaldoDivergente = Math.Round(Convert.ToDecimal(item.SaldoAtual) - (decimal)r.SaldoAtual, 3);
                    d.Livre17Sistema = r.Livre17;
                    d.Livre17Etiqueta = Convert.ToDecimal(item.Livre17);
                    d.ConvertidoSistema = Math.Round(r.Livre17 == 0 ? 0 : (decimal)r.SaldoAtual / r.Livre17, 3);
                    d.ConvertidoEtiqueta = Convert.ToDecimal(item.Convertido);
                    d.ConvertidoDivergente = Math.Round(d.ConvertidoEtiqueta - d.ConvertidoSistema, 3);
                    dv.Add(d);
                }
            }
            if (b)
            {
                dgvResult.DataSource = dv.OrderBy(p => p.Prateleira).ToList();
            }
        }



        private void btnImprimirComparacao_Click(object sender, EventArgs e)
        {
            if (leituras == null)
            {
                MessageBox.Show("Selecione um inventário");
                return;
            }
            CompareInventario(true);
            var result = dv;//.Where(p => p.SaldoDivergente > max | p.SaldoDivergente < min).ToList();
            var result2 = dv.Where(p => p.Prateleira.Contains("S: ")).ToList();
            var result3 = dv.Where(p => p.Livre17Sistema != p.Livre17Etiqueta).ToList();
            result.AddRange(result2);
            result.AddRange(result3);
            var resultFinal = result.Distinct().OrderBy(p => p.Prateleira).ToList();
            LancarNoExcell.Divergentes(resultFinal);
        }

        private void btnListaDeCartoes_Click(object sender, EventArgs e)
        {
            ListarCartoes();
            btnAtualizaListaDeCartoes.Enabled = true;
        }

        private void ListarCartoes()
        {
            var lista = File.ReadAllLines(@"C:\Exports\StatusCartoes.txt").ToList();
            ListaCartoes lc;
            List<ListaCartoes> llc = new List<ListaCartoes>();
            foreach (var l in lista)
            {
                var lt = l.Split('\t');
                lc = new ListaCartoes();
                lc.UID = lt[0];
                lc.Prateleira = lt[1];
                lc.Status = lt[2];
                llc.Add(lc);
            }


            DeListParaTable dlpt = new DeListParaTable();
            var inv = dlpt.ConvertListToDataTable(llc);
            dgvFaltouLer.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFaltouLer.DataSource = inv;

        }

        private void btnAtualizaListaDeCartoes_Click(object sender, EventArgs e)
        {

            ListaCartoes lc;
            List<ListaCartoes> llc = new List<ListaCartoes>();
            foreach (DataGridViewRow row in dgvFaltouLer.Rows)
            {
                if (row.Cells["UID"].Value == null)
                {
                    break;
                }
                lc = new ListaCartoes();
                lc.UID = row.Cells["UID"].Value.ToString().ToUpper();
                lc.Prateleira = row.Cells["Prateleira"].Value.ToString().ToUpper();
                lc.Status = row.Cells["Status"].Value.ToString().ToUpper().StartsWith("A") == true ? "ATIVO" : "INATIVO";
                llc.Add(lc);
            }

            File.Delete(@"C:\Exports\StatusCartoes.txt");
            List<string> newLista = new List<string>();

            foreach (var item in llc)
            {
                newLista.Add(item.UID + "\t" + item.Prateleira + "\t" + item.Status);
            }

            File.WriteAllLines(@"C:\Exports\StatusCartoes.txt", newLista);

            ListarCartoes();
            btnAtualizaListaDeCartoes.Enabled = false;

        }

        private void btnVisaizaComarDivergentes_Click(object sender, EventArgs e)
        {
            var resultFinal = ObterDivergentes();
            var table = DeListParaTable.ConvertListToTableGeneric<Divergentes>(resultFinal);
            dgvResult.DataSource = table;

        }

        private void brnImprimirDivergentes_Click(object sender, EventArgs e)
        {
            var resultFinal = ObterDivergentes();
            LancarNoExcell.Divergentes(resultFinal);
        }

        public List<Divergentes> ObterDivergentes()
        {
            if (leituras == null)
            {
                MessageBox.Show("Selecione um inventário");
                return null;
            }
            CompareInventario(false);
            decimal max = numericUpDown1.Value, min = numericUpDown1.Value * -1;
            var result = dv.Where(p => p.SaldoDivergente > max | p.SaldoDivergente < min).ToList();
            var result2 = dv.Where(p => p.Prateleira.Contains("S: ")).ToList();
            var result3 = dv.Where(p => p.Livre17Sistema != p.Livre17Etiqueta).ToList();
            result.AddRange(result2);
            result.AddRange(result3);
            var resultFinal = result.Distinct().OrderBy(p => p.Prateleira).ToList();
            return resultFinal;
        }

        private void acertoDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var select = dgvResult.CurrentRow;
                dgvResult.Rows.Remove(select);
            }
            catch (Exception ex)
            {
            }
        }

        private void btnEnviaParaApontamentoAcerto_Click(object sender, EventArgs e)
        {
            var lista = dgvResult.Rows;
            File.Delete($@"C:\Exports\ListaSalvaMovAcert.txt");
            Apontamento a;
            List<Apontamento> la = new List<Apontamento>();
            foreach (DataGridViewRow r in lista)
            {
                if (r.Cells["Produto"].Value == null)
                {
                    break;
                }

                a = new Apontamento();
                a.OP = DateTime.Today.ToString("yyMMdd"); ;
                a.Produto = r.Cells["Produto"].Value.ToString();
                a.Descricao = r.Cells["Descricao"].Value.ToString() + " >> " + r.Cells["Prateleira"].Value.ToString();

                string metros = Math.Round(Convert.ToDecimal(r.Cells["ConvertidoDivergente"].Value.ToString()), 2).ToString("N2");
                a.Metros = metros;

                a.KG = r.Cells["SaldoDivergente"].Value.ToString().Replace("-", "");
                a.Data = DateTime.Today.ToString("dd/MM/yyyy");
                a.TM = r.Cells["SaldoDivergente"].Value.ToString().Contains("-") ? "560" : "260";
                a.Livre2 = "AcertoAutomatico";
                a.SaldoEtiqueta = Math.Round(Convert.ToDouble(r.Cells["SaldoEtiqueta"].Value), 3);
                la.Add(a);
            }
            string lines = string.Empty;
            foreach (var al in la)
            {
                lines += (al.OP + "\t" + al.Produto + "\t" + al.Descricao + "\t" + al.Metros + "\t" + al.KG + "\t" + al.Data + "\t" + al.TM + "\t" + al.Livre2 + "\n");
            }
            File.AppendAllText($@"C:\Exports\ListaSalvaMovAcert.txt", lines);

            //atualizabanco de dados para nao retornar no grig
            Crud c = new Crud();
            foreach (var i in la)
            {
                var it = c.ListaSaldo().Where(p => p.Produto == i.Produto).First();
                it.SaldoAtual = i.SaldoEtiqueta;
                c.AlteraSaldo(it);
            }
            btnEnviaParaApontamentoAcerto.Enabled = false;
        }

        private void btnEliminaMomentaneamente_Click(object sender, EventArgs e)
        {
            try
            {
                var linha = dgvResult.CurrentRow;
                string lista = string.Empty;
                for (int i = 0; i < 12; i++)
                {
                    lista += $"{linha.Cells[i].Value}\t";
                }
                lista += comboBox1.Text;

                File.AppendAllText($@"C:\Exports\ListaEliminaMomentaneamente.txt", $"{lista}\r");


                int idx = 0;
                if (dataGridView1.Columns.Count == 0)
                {
                    foreach (DataGridViewColumn c in dgvResult.Columns)
                    {
                        dataGridView1.Columns.Add(c.Name, c.Name);
                        Debug.Write($"\"{c.Name}\", ");
                    }
                    dataGridView1.Columns.Add("STATUS", "STATUS");
                }

                List<string> ls = new List<string>();
                foreach (DataGridViewCell item in linha.Cells)
                {
                    ls.Add(item.Value.ToString());
                }
                ls.Add(comboBox1.Text);

                dataGridView1.Rows.Add(ls.ToArray());

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                dgvResult.Rows.Remove(linha);

            }
            catch (Exception ex)
            {

            }
        }


        private void CarregaPendencias()
        {

            for (int i = 0; i < 13; i++)
            {
                dataGridView1.Columns.Add(column[i], column[i]);
            }
            var linhas = File.ReadAllLines($@"C:\Exports\ListaEliminaMomentaneamente.txt");

            foreach (var linha in linhas)
            {
                var splt = linha.Split('\t');
                dataGridView1.Rows.Add(splt);
            }

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LimpaLinha_Click(object sender, EventArgs e)
        {
            try
            {
                var row = dataGridView1.CurrentRow;
                string[] splt = new string[13];
                var linhas = File.ReadAllLines($@"C:\Exports\ListaEliminaMomentaneamente.txt").ToList();
                int i = row.Index;
                linhas.RemoveAt(i);
                File.Delete($@"C:\Exports\ListaEliminaMomentaneamente.txt");
                File.AppendAllLines($@"C:\Exports\ListaEliminaMomentaneamente.txt", linhas);
                dataGridView1.Rows.RemoveAt(i);
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            }
            catch (Exception ex)
            {
            }

        }
    }
}
