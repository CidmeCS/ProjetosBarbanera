using Estoque.Classes;
using Estoque.Classes.ERP;
using Estoque.DAO;
using Estoque.Entidade;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Json.Net;
using System.Diagnostics;
using System.Net;

namespace Estoque.Views
{
    public partial class Apontamentos : Form
    {
        private List<Saldo> saldo;
        private List<Saldo> saldo2;
        private List<Movimento> movim;
        private List<Entidade.Atualizacao> atualizacao;
        private bool ve;
        private bool vr;
        private List<Apontamento> la;
        private decimal dg;
        private DateTime mesFechado;
        public string fileName = "";
        string g = string.Empty;



        public string DataLancar { get; private set; }

        public Apontamentos()
        {
            InitializeComponent();
            Crud c = new Crud();
            this.saldo2 = c.ListaSaldo();
        }

        private void CellEnterEditEstorno(object sender, DataGridViewCellEventArgs e)
        {

            bool b = false;
            // OP
            if (e.ColumnIndex == 0) // OP
            {
                try
                {
                    var fo = (DataGridView)sender;
                    g = fo.CurrentCell.Value.ToString().ToUpper();
                    Console.WriteLine("Coluna " + e.ColumnIndex + " - " + e.RowIndex);
                    var d = movim.Where(p => p.Documento == g.ToUpper()).Count();
                    if (d <= 0 & g != "NF")
                    {
                        dgvEstorno.Rows[e.RowIndex].Cells["OP"].Value = string.Empty;
                        dgvEstorno.Rows.Remove(dgvEstorno.Rows[dgvEstorno.Rows.Count - 2]);
                    }
                    else
                    {
                        if (g == "NF")
                        {
                            dgvEstorno.Rows[e.RowIndex].Cells["OP"].Value = "NF";
                        }
                        var itens = movim.Where(p => p.Documento == fo.CurrentCell.Value.ToString());
                        label3.Text = string.Empty;
                        HashSet<string> hs = new HashSet<string>();
                        foreach (var i in itens)
                        {
                            label3.Text += i.Codigo + "\n";
                            hs.Add(i.Codigo);
                        }
                        if (hs.Count() == 1)
                        {
                            label3.Text = string.Empty;
                            dgvEstorno.Rows[e.RowIndex].Cells["Produto"].Value = string.Empty;
                            dgvEstorno.Rows[e.RowIndex].Cells["Descricao"].Value = string.Empty;
                            dgvEstorno.Rows[e.RowIndex].Cells["Metros"].Value = string.Empty;
                            dgvEstorno.Rows[e.RowIndex].Cells["KG"].Value = string.Empty;
                            dgvEstorno.Rows[e.RowIndex].Cells["Produto"].Value = hs.First();

                            this.dgvEstorno.CurrentCell = this.dgvEstorno[e.ColumnIndex + 1, e.RowIndex];
                            DataGridViewCellEventArgs ef = new DataGridViewCellEventArgs(e.ColumnIndex + 1, e.RowIndex);
                            CellEnterEditEstorno(dgvEstorno, ef);
                            this.dgvEstorno.CurrentCell = this.dgvEstorno[e.ColumnIndex, e.RowIndex];
                            DataGridViewCellEventArgs ff = new DataGridViewCellEventArgs(e.ColumnIndex, e.RowIndex);
                        }
                        else
                        {
                            dgvEstorno.Rows[e.RowIndex].Cells["Produto"].Value = string.Empty;
                            dgvEstorno.Rows[e.RowIndex].Cells["Descricao"].Value = string.Empty;
                            dgvEstorno.Rows[e.RowIndex].Cells["Metros"].Value = string.Empty;
                            dgvEstorno.Rows[e.RowIndex].Cells["KG"].Value = string.Empty;
                        }
                    }
                }
                catch (Exception ex)
                { }
            }

            //produto
            if (e.ColumnIndex == 1) // PRODUTO
            {
                string cod = string.Empty;
                try
                {
                    var fo = (DataGridView)sender;
                    cod = (string)fo.CurrentCell.Value;
                    Console.WriteLine("Coluna " + e.ColumnIndex + " Linha " + e.RowIndex);
                    var d = movim.Where(p => p.Codigo == cod.ToUpper() & p.Documento == dgvEstorno.Rows[e.RowIndex].Cells["OP"].Value.ToString()).Count();
                    label3.Text = string.Empty;
                    foreach (var i in movim.Where(p => p.Codigo == cod.ToUpper() & p.Documento == dgvEstorno.Rows[e.RowIndex].Cells["OP"].Value.ToString()).OrderByDescending(p => p.DataInclusao).ThenBy(p => p.HoraInclusao))
                    {
                        label3.Text += $"TM:  {i.TM}  QTD:  {i.Quantidade}  Data: {i.DataInclusao.ToString("dd/MM/yy")} Hora: {i.HoraInclusao} \n";
                    }

                    if (d <= 0 & g != "NF")
                    {
                        dgvEstorno.Rows[e.RowIndex].Cells["Produto"].Value = "OP e Cod nao combinam";
                        var lp = movim.Where(p => p.Documento == dgvEstorno.Rows[e.RowIndex].Cells["OP"].Value.ToString()).ToList();
                        string lk = "";
                        foreach (var item in lp)
                        {
                            lk += item.Codigo + "\n";
                        }
                        MessageBox.Show(lk, "OP e Cod nao combinam");

                        return;
                    }
                    //verifica data
                    var vData = movim.Where(p => p.Codigo == cod.ToUpper() & p.Documento == dgvEstorno.Rows[e.RowIndex].Cells["OP"].Value.ToString() & p.TM == 330).ToList();
                    if (vData.Count == 0)
                    {
                        vData = movim.Where(p => p.Codigo == cod.ToUpper()).ToList();
                    }
                    var mesAtual = DateTime.Today.Month;
                    var mesLanca = vData.OrderByDescending(p => p.Data).FirstOrDefault().Data.Month;
                    //descobre o ultimo dia do mes
                    var meslan = new DateTime(DateTime.Today.Year, DateTime.Today.AddMonths(-1).Month, DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.AddMonths(-1).Month));
                    DataLancar = String.Empty;
                    DataLancar = mesAtual == mesLanca ? DateTime.Today.ToString("dd/MM/yyyy") : meslan.ToString("dd/MM/yyyy");
                    if (vData.Count == 0)
                    {
                        dgvEstorno.Rows[e.RowIndex].Cells["Produto"].Value = string.Empty;
                    }
                    var dd = saldo.Where(p => p.Produto == cod.ToUpper()).First();
                    dgvEstorno.Rows[e.RowIndex].Cells["Descricao"].Value = $"{dd.Descricao}; {dd.SaldoAtual}; {dd.Unid}; {dd.Prateleira}";
                }
                catch (Exception)
                {
                    MessageBox.Show($"Provavelmente o item {cod.ToUpper()} esteja inatívo");
                    label3.Text += $"{dgvEstorno.Rows[e.RowIndex].Cells["Produto"].Value}";
                    dgvEstorno.Rows[e.RowIndex].Cells["Produto"].Value = string.Empty;
                    this.dgvEstorno.CurrentCell = this.dgvEstorno[e.ColumnIndex - 1, e.RowIndex];
                }
            }

            //metro
            if (e.ColumnIndex == 3)
            {
                try
                {
                    var fo = (DataGridView)sender;
                    var g = (string)fo.Rows[e.RowIndex].Cells["Produto"].Value;
                    var s = (string)fo.Rows[e.RowIndex].Cells["OP"].Value;
                    Console.WriteLine("Coluna " + e.ColumnIndex + " - " + e.RowIndex);
                    var d = MultiplicaOuDivide(e, g, fo, "Descricao", "Metros");
                    dgvEstorno.Rows[e.RowIndex].Cells["KG"].Value = Math.Round(d, 3);

                    var X = movim.Where(p => p.Codigo == g & p.Documento == s).ToList();
                    double vl = 0;
                    foreach (var i in X)
                    {
                        if (i.TM == 330)
                        {
                            vl += i.Quantidade;
                        }
                        if (i.TM == 90)
                        {
                            vl -= i.Quantidade;
                        }
                    }

                    if (vl < (double)d & this.g != "NF")
                    {
                        MessageBox.Show($"O estorno de {d} excede as requisicoes. Limite de {vl}");
                        dgvEstorno.Rows[e.RowIndex].Cells["KG"].Value = string.Empty;
                        dgvEstorno.Rows[e.RowIndex].Cells["Metros"].Value = string.Empty;
                    }
                }
                catch (Exception)
                {
                    dgvEstorno.Rows[e.RowIndex].Cells["KG"].Value = string.Empty;
                    dgvEstorno.Rows[e.RowIndex].Cells["Metros"].Value = string.Empty;
                }
            }
            // kilo/ und geral
            if (e.ColumnIndex == 4)
            {
                try
                {
                    var fo = (DataGridView)sender;
                    var d = Convert.ToDouble(fo.Rows[e.RowIndex].Cells["KG"].Value.ToString());
                    var g = (string)fo.Rows[e.RowIndex].Cells["Produto"].Value;
                    var s = (string)fo.Rows[e.RowIndex].Cells["OP"].Value;
                    Console.WriteLine("Coluna " + e.ColumnIndex + " - " + e.RowIndex);
                    var df = MultiplicaOuDivideReq(e, g, fo, "Descricao", "KG");
                    dgvEstorno.Rows[e.RowIndex].Cells["Metros"].Value = Math.Round(df, 3);

                    var X = movim.Where(p => p.Codigo == g & p.Documento == s).ToList();
                    double vl = 0;
                    foreach (var i in X)
                    {
                        if (i.TM == 330)
                        {
                            vl += i.Quantidade;
                        }
                        if (i.TM == 90)
                        {
                            vl -= i.Quantidade;
                        }
                    }

                    if (vl < d & this.g != "NF")
                    {
                        MessageBox.Show($"O estorno de {d} excede as requisicoes. Limite de {vl}");
                        dgvEstorno.Rows[e.RowIndex].Cells["KG"].Value = string.Empty;
                        dgvEstorno.Rows[e.RowIndex].Cells["Metros"].Value = string.Empty;
                    }
                }
                catch (Exception ex)
                {
                    dgvEstorno.Rows[e.RowIndex].Cells["KG"].Value = string.Empty;
                    dgvEstorno.Rows[e.RowIndex].Cells["Metros"].Value = string.Empty;
                }
            }

        }

        private decimal MultiplicaOuDivide(DataGridViewCellEventArgs e, string g, DataGridView dgv, string descricao, string metros)
        {
            decimal retorno = 0;
            var ss = saldo.Where(p => p.Produto == g).First().Livre17;
            var Descricao = dgv.Rows[e.RowIndex].Cells[descricao].Value.ToString();
            var B = saldo.Where(p => p.Produto == g).First().Livre17;

            if (B > 0 & (Descricao.StartsWith("BARRA ") | Descricao.StartsWith("TUBO ") | Descricao.StartsWith("BUCHA BRONZE ") | Descricao.StartsWith("PERFIL CU ")))
            {
                retorno = Convert.ToDecimal(dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) * Convert.ToDecimal(saldo.Where(p => p.Produto == g).First().Livre17);
            }
            else if (B > 0)
            {
                retorno = Convert.ToDecimal(dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) / Convert.ToDecimal(saldo.Where(p => p.Produto == g).First().Livre17);
            }
            else if (B <= 0)
            {
                retorno = Convert.ToDecimal(dgv.Rows[e.RowIndex].Cells[metros].Value);
            }
            return retorno;
        }

        private void Load_(object sender, EventArgs e)
        {
            if (File.Exists(@"C:\Exports\MesFechado.txt"))
            {
                mesFechado = Convert.ToDateTime(File.ReadAllText(@"C:\Exports\MesFechado.txt").Trim());
                lblMesFechado.Text = "Mês Fechado: " + mesFechado.ToString("dd-MM-yyyy");
            }
            else { lblMesFechado.Text = "Mês Fechado: "; }

            Crud c = new Crud();
            saldo = c.ListaSaldo();
            movim = c.ListaMovimento().Where(p => p.Data > mesFechado).ToList();
            atualizacao = c.ListaAtualizacao();

            lblUltimaAtualizacao.Text = $@"Última Atualização: 
                    ExportSaldo: {atualizacao.Where(p => p.Entidade == "ExportSaldo.txt").First().Data}
                    Movimentos: {atualizacao.Where(p => p.Entidade == "Movimentos.txt").First().Data}";

            btnRecuperaListaMovAcert_Click(dgvMovAcert, e);
            btnRecuperaLista_Click(dgvEstorno, e);
            btnRecuperaListaRequisicao_Click(dgvRequisicao, e);

        }

        private void CellValueChange_(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                var vl = (DataGridView)sender;
                try
                {
                    dgvEstorno.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = vl.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().ToUpper();
                }
                catch (Exception)
                {
                }
            }
            if (e.ColumnIndex == 3 | e.ColumnIndex == 4)
            {
                var vl = (DataGridView)sender;
                try
                {
                    dgvEstorno.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = vl.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().ToUpper().Replace(".", ",");
                }
                catch (Exception)
                {
                }
            }

        }

        private void btnEstornar_Click(object sender, EventArgs e)
        {
            ListaSalvaRetorno();
            VerificaEstornos();

            if (la.Count == 0 | !ve)
            {
                return;
            }
            var S = la.Where(p => p.OP != "NF").ToList();
            ControllerERP_Pronto.EstornarApontamentos(S, mesFechado);
            MessageBox.Show("Estornos Apontados", "Apontamentos");
        }

        private void btnRequisitar_Click(object sender, EventArgs e)
        {
            ListaSalvaRequisicao();
            VerificaRequisicao();

            if (la.Count == 0 | !vr)
            {
                return;
            }

            ControllerERP_Pronto.RequisitarApontamentos(la);
            MessageBox.Show("Requisicoes Apontadas", "Apontamentos");
        }

        private void VerificaEstornos()
        {
            ve = true;
            la = new List<Apontamento>();
            Apontamento ap;
            int i = 1;
            foreach (DataGridViewRow row in dgvEstorno.Rows)
            {
                ap = new Apontamento();
                if (i == dgvEstorno.RowCount)
                {
                    break;
                }

                if (row.Cells["OP"].Value == string.Empty)
                {
                    row.Cells["OP"].Style.BackColor = Color.Aqua;
                    ve = false;
                }
                else
                {
                    ap.OP = row.Cells["OP"].Value.ToString();
                }

                if ((row.Cells["Produto"].Value.ToString() == "OP E COD NAO COMBINAM") | (row.Cells["Produto"].Value == string.Empty))
                {
                    row.Cells["Produto"].Style.BackColor = Color.Aqua;
                    ve = false;
                }
                else
                {
                    ap.Produto = row.Cells["Produto"].Value.ToString();
                    ap.Data = DataLancar;
                }

                if (row.Cells["Descricao"].Value == string.Empty)
                {
                    row.Cells["Descricao"].Style.BackColor = Color.Aqua;
                    ve = false;
                }
                else
                {
                    ap.Descricao = row.Cells["Descricao"].Value.ToString();
                }

                if (row.Cells["Metros"].Value == string.Empty)
                {
                    row.Cells["Metros"].Style.BackColor = Color.Aqua;
                    ve = false;
                }
                else
                {
                    ap.Metros = row.Cells["Metros"].Value.ToString();
                }

                if (row.Cells["KG"].Value == string.Empty)
                {
                    row.Cells["KG"].Style.BackColor = Color.Aqua;
                    ve = false;
                }
                else
                {
                    ap.KG = row.Cells["KG"].Value.ToString();
                }

                i++;
                la.Add(ap);

            }
            var d = la.OrderBy(p => p.OP).ToList();

            la.Clear();
            la.AddRange(d);
            if (ve)
            {
                foreach (DataGridViewRow row in dgvEstorno.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        cell.Style.BackColor = Color.White;
                    }
                }
            }
        }

        private void btnLimpaEstornoTudo_Click(object sender, EventArgs e)
        {
            dgvEstorno.Rows.Clear();
            ListaSalvaRetorno();
        }

        private void btnLimpaEstornoLinhaSelecionada_Click(object sender, EventArgs e)
        {
            LimpaLinha(sender);
        }

        private void btnVerificar_Click(object sender, EventArgs e)
        {
            VerificaEstornos();
        }

        private void btnTeste_Click(object sender, EventArgs e)
        {

        }

        private void btnSalvaLista_Click(object sender, EventArgs e)
        {
            ListaSalvaRetorno();

        }

        private void btnRecuperaLista_Click(object sender, EventArgs e)
        {
            try
            {
                var lista = File.ReadAllLines($@"C:\Exports\ListaSalvaEstorno.txt", Encoding.Default).ToList();

                if (lista.Count > 0)
                {
                    Apontamento a;
                    List<Apontamento> la = new List<Apontamento>();
                    foreach (var l in lista)
                    {
                        var Cells = l.Split('\t');
                        a = new Apontamento();
                        a.OP = Cells[0];
                        a.Produto = Cells[1];
                        a.Descricao = Cells[2];
                        a.Metros = Cells[3];
                        a.KG = Cells[4];
                        a.Data = Cells[5];
                        la.Add(a);
                    }

                    dgvEstorno.Rows.Clear();
                    dgvEstorno.Rows.Insert(0, la.Count);
                    for (int i = 0; i < la.Count; i++)
                    {
                        dgvEstorno.Rows[i].Cells["OP"].Value = la[i].OP;
                        dgvEstorno.Rows[i].Cells["Produto"].Value = la[i].Produto;
                        dgvEstorno.Rows[i].Cells["Descricao"].Value = la[i].Descricao;
                        dgvEstorno.Rows[i].Cells["Metros"].Value = la[i].Metros;
                        dgvEstorno.Rows[i].Cells["Kg"].Value = la[i].KG;
                        DataLancar = la[i].Data;
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void btnTeste_Click_1(object sender, EventArgs e)
        {
        }

        private void btnLimpalinhaRequisicao_Click(object sender, EventArgs e)
        {
            LimpaLinha(sender);
        }

        private void LimpaLinha(object sender)
        {
            Button b = (Button)sender;
            if (b.Name == "btnLimpalinhaRequisicao")
            {
                try
                {
                    var dc = dgvRequisicao.CurrentRow;
                    dgvRequisicao.Rows.Remove(dc);
                    ListaSalvaRequisicao();
                }
                catch (Exception ex)
                {
                }
            }
            if (b.Name == "btnLimpaLinhaSelecionadaEstorno")
            {
                try
                {
                    var dc = dgvEstorno.CurrentRow;
                    dgvEstorno.Rows.Remove(dc);
                    ListaSalvaRetorno();
                }
                catch (Exception ex)
                {
                }
            }
            if (b.Name == "btnLimpaLinhaMovAcert")
            {
                try
                {
                    var dc = dgvMovAcert.CurrentRow;
                    dgvMovAcert.Rows.Remove(dc);
                    ListaSalvaMovAcert();
                }
                catch (Exception ex)
                {
                }
            }
        }

        private void btnLimpaTudoRequisicao_Click(object sender, EventArgs e)
        {
            dgvRequisicao.Rows.Clear();
            ListaSalvaRequisicao();
        }

        private void btnSalvaListaRequisicao_Click(object sender, EventArgs e)
        {
            ListaSalvaRequisicao();
        }

        private void btnRecuperaListaRequisicao_Click(object sender, EventArgs e)
        {
            dg = 0;
            if (!File.Exists(@"C:\Exports\ListaSalvaRequisicao.txt"))
            {
                return;
            }
            var lista = File.ReadAllLines($@"C:\Exports\ListaSalvaRequisicao.txt", Encoding.Default).ToList();
            if (lista.Count > 0)
            {

                Apontamento a;
                List<Apontamento> la = new List<Apontamento>();
                foreach (var ls in lista)
                {
                    var Cells = ls.Split('\t');
                    a = new Apontamento();
                    a.OP = Cells[0];
                    a.Produto = Cells[1];
                    a.Descricao = Cells[2];
                    a.Metros = Cells[3];
                    a.KG = Cells[4];
                    a.Data = Cells[5];
                    la.Add(a);
                }

                dgvRequisicao.Rows.Clear();
                dgvRequisicao.Rows.Insert(0, la.Count);
                var l = la.OrderBy(p => p.OP).ToList();
                for (int i = 0; i < l.Count; i++)
                {
                    dgvRequisicao.Rows[i].Cells["OPr"].Value = l[i].OP;
                    dgvRequisicao.Rows[i].Cells["Produtor"].Value = l[i].Produto;
                    dgvRequisicao.Rows[i].Cells["Descricaor"].Value = l[i].Descricao;
                    dgvRequisicao.Rows[i].Cells["Metrosr"].Value = l[i].Metros;
                    dgvRequisicao.Rows[i].Cells["Kgr"].Value = l[i].KG;
                    DataLancar = l[i].Data;
                }
            }
        }

        private void btnVerificaRequisicao_Click(object sender, EventArgs e)
        {
            VerificaRequisicao();
        }

        private void VerificaRequisicao()
        {
            vr = true;
            la = new List<Apontamento>();
            Apontamento ap;
            int i = 1;
            foreach (DataGridViewRow row in dgvRequisicao.Rows)
            {
                ap = new Apontamento();
                if (i == dgvRequisicao.RowCount)
                {
                    break;
                }

                if (row.Cells["OPr"].Value is null || row.Cells["OPr"].Value == string.Empty)
                {
                    row.Cells["OPr"].Style.BackColor = Color.Aqua;
                    vr = false;
                }
                else
                {
                    ap.OP = row.Cells["OPr"].Value.ToString();
                }

                if ((row.Cells["Produtor"].Value is null) || (row.Cells["Produtor"].Value.ToString() == "OP E COD NAO COMBINAM") | (row.Cells["Produtor"].Value == string.Empty))
                {
                    row.Cells["Produtor"].Style.BackColor = Color.Aqua;
                    vr = false;
                }
                else
                {
                    ap.Produto = row.Cells["Produtor"].Value.ToString();
                    ap.Data = DataLancar;
                }

                if (row.Cells["Descricaor"].Value is null || row.Cells["Descricaor"].Value == string.Empty)
                {
                    row.Cells["Descricaor"].Style.BackColor = Color.Aqua;
                    vr = false;
                }
                else
                {
                    ap.Descricao = row.Cells["Descricaor"].Value.ToString();
                }

                if (row.Cells["Metrosr"].Value is null || row.Cells["Metrosr"].Value == string.Empty)
                {
                    row.Cells["Metrosr"].Style.BackColor = Color.Aqua;
                    vr = false;
                }
                else
                {
                    ap.Metros = row.Cells["Metrosr"].Value.ToString();
                }

                if (row.Cells["Kgr"].Value is null || row.Cells["Kgr"].Value == string.Empty)
                {
                    row.Cells["Kgr"].Style.BackColor = Color.Aqua;
                    vr = false;
                }
                else
                {
                    ap.KG = row.Cells["Kgr"].Value.ToString();
                }

                if (row.Cells["Kgr"].Value is null || row.Cells["Kgr"].Value == string.Empty)
                {
                    row.Cells["Kgr"].Style.BackColor = Color.Aqua;
                    vr = false;
                }
                else
                {
                    ap.KG = row.Cells["Kgr"].Value.ToString();
                }

                i++;
                la.Add(ap);
            }
            var lb = la.OrderBy(p => p.OP).ToList();
            la.Clear();
            la = lb;
            if (vr)
            {
                foreach (DataGridViewRow row in dgvRequisicao.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        cell.Style.BackColor = Color.White;
                    }
                }
            }
        }

        private void CellValueChangeReq(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                var vl = (DataGridView)sender;
                try
                {
                    dgvRequisicao.Rows[e.RowIndex].Cells[e.ColumnIndex].Value =
                        vl.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().ToUpper();
                }
                catch (Exception)
                {
                }
            }
            if (e.ColumnIndex == 3 | e.ColumnIndex == 4)
            {
                var vl = (DataGridView)sender;
                try
                {
                    dgvRequisicao.Rows[e.RowIndex].Cells[e.ColumnIndex].Value =
                        vl.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().ToUpper().Replace(".", ",");
                }
                catch (Exception)
                {
                }
            }
        }

        private void CellEndEditRequisicao(object sender, DataGridViewCellEventArgs e)
        {
            bool b = false;

            if (e.ColumnIndex == 0)
            {
                this.dgvRequisicao.Sort(this.dgvRequisicao.Columns["OPr"], ListSortDirection.Ascending);
            }

            if (e.ColumnIndex == 1) // PRODUTO
            {
                dgvRequisicao.Rows[e.RowIndex].Cells["Descricaor"].Value = string.Empty;
                try
                {
                    var fo = (DataGridView)sender;
                    var cod = (string)fo.CurrentCell.Value;
                    var dd = saldo.Where(p => p.Produto == cod.ToUpper()).First();
                    dgvRequisicao.Rows[e.RowIndex].Cells["Descricaor"].Value = $"{dd.Descricao}; {dd.SaldoAtual}; {dd.Unid}; {dd.Prateleira}";
                    dgvRequisicao.Rows[e.RowIndex].Cells["Metrosr"].Value = "0";
                    dgvRequisicao.Rows[e.RowIndex].Cells["Kgr"].Value = "0";
                }
                catch (Exception)
                {

                }
            }
            if (e.ColumnIndex == 3)
            {
                try
                {
                    var rows = (DataGridView)sender;
                    var produto = (string)rows.Rows[e.RowIndex].Cells["Produtor"].Value;
                    var d = MultiplicaOuDivide(e, produto, rows, "Descricaor", "Metrosr");
                    dgvRequisicao.Rows[e.RowIndex].Cells["Kgr"].Value = Math.Round(d, 3);
                    var de = Apoio01(produto, rows, rows.Rows[e.RowIndex]);
                    label7.Text = de.ToString();
                    Apoio2(de);

                }
                catch (Exception ex)
                {
                    dgvRequisicao.Rows[e.RowIndex].Cells["Kgr"].Value = string.Empty;
                    dgvRequisicao.Rows[e.RowIndex].Cells["Metrosr"].Value = string.Empty;
                }
            }
            if (e.ColumnIndex == 4)
            {
                try
                {
                    var rows = (DataGridView)sender;
                    var produto = (string)rows.Rows[e.RowIndex].Cells["Produtor"].Value;
                    var d = MultiplicaOuDivideReq(e, produto, rows, "Descricaor", "Kgr");
                    dgvRequisicao.Rows[e.RowIndex].Cells["Metrosr"].Value = Math.Round(d, 3);
                    var de = Apoio01(produto, rows, rows.Rows[e.RowIndex]);
                    label7.Text = de.ToString();
                    Apoio2(de);


                }
                catch (Exception)
                {
                    dgvRequisicao.Rows[e.RowIndex].Cells["Kgr"].Value = string.Empty;
                    dgvRequisicao.Rows[e.RowIndex].Cells["Metrosr"].Value = string.Empty;
                }
            }
        }

        private void Apoio2(decimal de)
        {
            if (rbSaldo.Checked == true)
            {
                lblMeta.Text = (Convert.ToDecimal(lblSaldo.Text) - de).ToString();
            }
            if (rbPrateleira.Checked == true)
            {
                lblMeta.Text = (Convert.ToDecimal(lblPrateleira.Text) - de).ToString();

            }
            if (rbSubtracao.Checked == true)
            {
                lblMeta.Text = (Convert.ToDecimal(lblSubtracao.Text) - de).ToString();
            }
        }

        private decimal Apoio01(string produto, DataGridView rows, DataGridViewRow row)
        {
            decimal d = 0;
            //rows.Rows.Remove(row);
            foreach (DataGridViewRow item in rows.Rows)
            {
                if (item.Cells["Produtor"].Value == null)
                {
                    break;
                }
                if (item.Cells["Produtor"].Value.ToString() == produto)
                {
                    d += item.Cells["Kgr"].Value == "" ? 0 : Convert.ToDecimal(item.Cells["Kgr"].Value);
                }
            }
            return d;
        }

        private decimal MultiplicaOuDivideReq(DataGridViewCellEventArgs e, string g, DataGridView dgv, string descricao, string metros)
        {
            decimal retorno = 0;
            var Descricao = dgv.Rows[e.RowIndex].Cells[descricao].Value.ToString();
            var B = saldo.Where(p => p.Produto == g).First().Livre17;

            if (B > 0 & (Descricao.StartsWith("BARRA ") | Descricao.StartsWith("TUBO ") | Descricao.StartsWith("BUCHA BRONZE ") | Descricao.StartsWith("PERFIL CU ")))
            {
                retorno = Convert.ToDecimal(dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) / Convert.ToDecimal(saldo.Where(p => p.Produto == g).First().Livre17);
            }
            else if (B > 0)
            {
                retorno = Convert.ToDecimal(dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) * Convert.ToDecimal(saldo.Where(p => p.Produto == g).First().Livre17);

            }
            else if (B <= 0)
            {
                retorno = Convert.ToDecimal(dgv.Rows[e.RowIndex].Cells[metros].Value);

            }

            return retorno;

        }

        private void btnAtualiza_Click(object sender, EventArgs e)
        {
            try
            {
                var item = @"E:\GitHub\ImportExportERP\ImportExportERP\bin\Debug\ImportExportERP.exe";
                Process.Start(item, "1");
                return;
            }
            catch (Exception)
            { }

            //O app esta no DELL ou no estoque2 (fernando)
            try
            {
                var x = Directory.GetDirectories($@"C:\Users\{Environment.UserName}\Documents").ToList();
                List<string> g = new List<string>(x);

                foreach (var i in x)
                {
                    if (i == $@"C:\Users\{Environment.UserName}\Documents\My Music" | i == $@"C:\Users\{Environment.UserName}\Documents\My Pictures" | i == $@"C:\Users\{Environment.UserName}\Documents\My Videos")
                    {
                        g.Remove(i);
                    }
                }

                foreach (var item in g)
                {
                    var d = Directory.GetFiles(item, "ImportExportERP.exe", SearchOption.AllDirectories);
                    if (d.Length > 0)
                    {
                        Process.Start(d.First(), "1");
                    }
                }
            }
            catch (Exception)
            {
            }

        }

        private void dgvMovAcert_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1) // 
            {
                dgvMovAcert.Rows[e.RowIndex].Cells["DataMA"].Value = string.Empty;
                dgvMovAcert.Rows[e.RowIndex].Cells["DataMA"].Value = DateTime.Today.ToString("dd/MM/yyyy");
            }
            if (e.ColumnIndex == 2) // 
            {
                dgvMovAcert.Rows[e.RowIndex].Cells["DocumentoMA"].Value = string.Empty;
                dgvMovAcert.Rows[e.RowIndex].Cells["DocumentoMA"].Value = DateTime.Today.ToString("yyMMdd");
            }
            if (e.ColumnIndex == 0 & e.RowIndex > 0) // 
            {
                dgvMovAcert.Rows.Add();
                dgvMovAcert.Rows[e.RowIndex].Cells["TMMA"].Value = dgvMovAcert.Rows[e.RowIndex - 1].Cells["TMMA"].Value;
                dgvMovAcert.Rows[e.RowIndex].Cells["DataMA"].Value = DateTime.Today.ToString("dd/MM/yyyy");
                dgvMovAcert.Rows[e.RowIndex].Cells["DocumentoMA"].Value = dgvMovAcert.Rows[e.RowIndex - 1].Cells["DocumentoMA"].Value;
                dgvMovAcert.Rows[e.RowIndex].Cells["Livre2MA"].Value = dgvMovAcert.Rows[e.RowIndex - 1].Cells["Livre2MA"].Value;
            }

        }

        private void dgvMovAcert_CellEndEditClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3) // produto
            {
                dgvMovAcert.Rows[e.RowIndex].Cells["DescricaoMA"].Value = string.Empty;
                try
                {
                    var fo = (DataGridView)sender;
                    var cod = (string)fo.CurrentCell.Value;
                    var dd = saldo.Where(p => p.Produto == cod.ToUpper()).First();
                    dgvMovAcert.Rows[e.RowIndex].Cells["DescricaoMA"].Value = $"{dd.Descricao}; {dd.SaldoAtual}; {dd.Unid}; {dd.Prateleira}";
                }
                catch (Exception)
                {

                }
            }
            if (e.ColumnIndex == 5) // KG
            {
                try
                {
                    var fo = (DataGridView)sender;
                    var g = (string)fo.Rows[e.RowIndex].Cells["ProdutoMA"].Value;
                    Console.WriteLine("Coluna " + e.ColumnIndex + " - " + e.RowIndex);
                    var d = MultiplicaOuDivide(e, g, fo, "DescricaoMA", "MetrosMA");
                    dgvMovAcert.Rows[e.RowIndex].Cells["KgMA"].Value = Math.Round(d, 3);
                }
                catch (Exception)
                {
                    dgvMovAcert.Rows[e.RowIndex].Cells["KgMA"].Value = string.Empty;
                    dgvMovAcert.Rows[e.RowIndex].Cells["MetrosMA"].Value = string.Empty;
                }
            }
            if (e.ColumnIndex == 6) // Metros
            {
                try
                {
                    var fo = (DataGridView)sender;
                    var g = (string)fo.Rows[e.RowIndex].Cells["ProdutoMA"].Value;
                    Console.WriteLine("Coluna " + e.ColumnIndex + " - " + e.RowIndex);
                    var d = MultiplicaOuDivideReq(e, g, fo, "DescricaoMA", "MetrosMA");
                    dgvMovAcert.Rows[e.RowIndex].Cells["MetrosMA"].Value = Math.Round(d, 3);
                }
                catch (Exception)
                {
                    dgvMovAcert.Rows[e.RowIndex].Cells["KgMA"].Value = string.Empty;
                    dgvMovAcert.Rows[e.RowIndex].Cells["MetrosMA"].Value = string.Empty;
                }
            }
            if (e.ColumnIndex == 7) // Metros
            {
                try
                {
                    dgvMovAcert.Rows[e.RowIndex].Cells["Livre2MA"].Value = dgvMovAcert.Rows[e.RowIndex].Cells["Livre2MA"].Value.ToString().ToUpper();
                }
                catch (Exception)
                {

                }
            }
        }

        private void dgvMovAcert_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                var vl = (DataGridView)sender;
                try
                {
                    dgvMovAcert.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = vl.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().ToUpper();
                }
                catch (Exception)
                {
                }
            }
            if (e.ColumnIndex == 5 | e.ColumnIndex == 6)
            {
                var vl = (DataGridView)sender;
                try
                {
                    dgvMovAcert.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = vl.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().ToUpper().Replace(".", ",");
                }
                catch (Exception)
                {
                }
            }

        }

        private void btnLimpaLinhaMovAcert_Click(object sender, EventArgs e)
        {
            LimpaLinha(sender);
        }

        private void btnLimpaTudoMovAcert_Click(object sender, EventArgs e)
        {
            dgvMovAcert.Rows.Clear();
            ListaSalvaMovAcert();
        }

        private void btnSalvaListaMovAcert_Click(object sender, EventArgs e)
        {
            ListaSalvaMovAcert();
        }

        private void btnRecuperaListaMovAcert_Click(object sender, EventArgs e)
        {
            try
            {
                var lista = File.ReadAllLines($@"C:\Exports\ListaSalvaMovAcert.txt", Encoding.Default).ToList();
                if (lista.Count > 0)
                {

                    Apontamento a;
                    List<Apontamento> la = new List<Apontamento>();
                    foreach (var l in lista)
                    {
                        var Cells = l.Split('\t');
                        a = new Apontamento();
                        a.OP = Cells[0];
                        a.Produto = Cells[1];
                        a.Descricao = Cells[2];
                        a.Metros = Cells[3];
                        a.KG = Cells[4];
                        a.Data = Cells[5];
                        a.TM = Cells[6];
                        a.Livre2 = Cells[7];
                        la.Add(a);
                    }

                    dgvMovAcert.Rows.Clear();
                    dgvMovAcert.Rows.Insert(0, la.Count);
                    for (int i = 0; i < la.Count; i++)
                    {
                        dgvMovAcert.Rows[i].Cells["DocumentoMA"].Value = la[i].OP;
                        dgvMovAcert.Rows[i].Cells["ProdutoMA"].Value = la[i].Produto;
                        dgvMovAcert.Rows[i].Cells["DescricaoMA"].Value = la[i].Descricao;
                        dgvMovAcert.Rows[i].Cells["MetrosMA"].Value = la[i].Metros;
                        dgvMovAcert.Rows[i].Cells["KgMA"].Value = la[i].KG;
                        dgvMovAcert.Rows[i].Cells["DataMA"].Value = la[i].Data;
                        dgvMovAcert.Rows[i].Cells["TMMA"].Value = la[i].TM;
                        dgvMovAcert.Rows[i].Cells["Livre2MA"].Value = la[i].Livre2;
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void btnVerificaMovAcert_Click(object sender, EventArgs e)
        {
            VerificaMovAcert();
        }

        private void VerificaMovAcert()
        {
            vr = true;
            la = new List<Apontamento>();
            Apontamento ap;
            int i = 1;
            foreach (DataGridViewRow row in dgvMovAcert.Rows)
            {
                ap = new Apontamento();
                if (i == dgvMovAcert.RowCount)
                {
                    break;
                }

                if (row.Cells["DocumentoMA"].Value is null || row.Cells["DocumentoMA"].Value == string.Empty)
                {
                    row.Cells["DocumentoMA"].Style.BackColor = Color.Aqua;
                    vr = false;
                }
                else
                {
                    ap.OP = row.Cells["DocumentoMA"].Value.ToString();
                }

                if ((row.Cells["ProdutoMA"].Value is null) || (row.Cells["ProdutoMA"].Value == string.Empty))
                {
                    row.Cells["ProdutoMA"].Style.BackColor = Color.Aqua;
                    vr = false;
                }
                else
                {
                    ap.Produto = row.Cells["ProdutoMA"].Value.ToString();
                    ap.Data = DataLancar;
                }

                if (row.Cells["DescricaoMA"].Value is null || row.Cells["DescricaoMA"].Value == string.Empty)
                {
                    row.Cells["DescricaoMA"].Style.BackColor = Color.Aqua;
                    vr = false;
                }
                else
                {
                    ap.Descricao = row.Cells["DescricaoMA"].Value.ToString();
                }

                if (row.Cells["MetrosMA"].Value is null || row.Cells["MetrosMA"].Value == string.Empty)
                {
                    row.Cells["MetrosMA"].Style.BackColor = Color.Aqua;
                    vr = false;
                }
                else
                {
                    ap.Metros = row.Cells["MetrosMA"].Value.ToString();
                }

                if (row.Cells["KgMA"].Value is null || row.Cells["KgMA"].Value == string.Empty)
                {
                    row.Cells["KgMA"].Style.BackColor = Color.Aqua;
                    vr = false;
                }
                else
                {
                    ap.KG = row.Cells["KgMA"].Value.ToString();
                }

                if (row.Cells["TMMA"].Value is null || row.Cells["TMMA"].Value == string.Empty)
                {
                    row.Cells["TMMA"].Style.BackColor = Color.Aqua;
                    vr = false;
                }
                else
                {
                    ap.KG = row.Cells["Livre2MA"].Value.ToString();
                }
                if (row.Cells["Livre2MA"].Value is null || row.Cells["Livre2MA"].Value == string.Empty)
                {
                    row.Cells["Livre2MA"].Style.BackColor = Color.Aqua;
                    vr = false;
                }
                else
                {
                    ap.KG = row.Cells["Livre2MA"].Value.ToString();
                }

                i++;
                la.Add(ap);
            }
            var lb = la.OrderBy(p => p.OP).ToList();
            la.Clear();
            la = lb;
            if (vr)
            {
                foreach (DataGridViewRow row in dgvMovAcert.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        cell.Style.BackColor = Color.White;
                    }
                }
            }
        }

        private void btnMovAcert_Click(object sender, EventArgs e)
        {
            ListaSalvaMovAcert();

            List<Apontamento> la = new List<Apontamento>();

            foreach (DataGridViewRow r in dgvMovAcert.Rows)
            {
                int i = 0;
                if (dgvMovAcert.Rows.Count == 0)
                {
                    break;
                }

                if (r.Cells["DocumentoMA"].Value == null)
                {
                    break;
                }

                Apontamento a = new Apontamento();
                a.OP = r.Cells["DocumentoMA"].Value.ToString();
                a.Produto = r.Cells["ProdutoMA"].Value.ToString();
                a.Descricao = r.Cells["DescricaoMA"].Value.ToString();
                a.Metros = r.Cells["MetrosMA"].Value.ToString();
                a.KG = r.Cells["KgMA"].Value.ToString();
                a.Data = r.Cells["DataMA"].Value.ToString();
                a.TM = r.Cells["TMMA"].Value.ToString();
                a.Livre2 = "A: " + r.Cells["Livre2MA"].Value.ToString();
                la.Add(a);
                i++;
            }
            var laA = la.Where(p => p.TM == "260" | p.TM == "560").OrderBy(p => p.TM).ToList();
            var laM = la.Where(p => p.TM == "331" | p.TM == "91").OrderByDescending(p => p.TM).ToList();
            ControllerERP_Pronto.MovimentarAcertar(laA, laM);
        }

        private void Calculando_TextChange(object sender, EventArgs e)
        {
            var linhas = rtbQuantidades.Lines.ToList();
            decimal valor = 0;
            foreach (var l in linhas)
            {
                if (l == "")
                {
                    valor += 0;
                    continue;
                }
                valor += Convert.ToDecimal(l);
            }
            lblTotal.Text = valor.ToString();



        }

        private void rtbKeyPress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }
        }

        private void btnConsultasERP_Click(object sender, EventArgs e)
        {
            List<string> ls = new List<string>();
            foreach (var item in rtbConsultasERP.Lines)
            {
                var t = item.Split(';');
                ls.Add(t[0].Trim().ToUpper());
            }

            var newLinhas = ControllerERP_Pronto.ConsultaSaldo(ls);
            rtbConsultasERP.Clear();
            rtbConsultasERP.Lines = newLinhas.ToArray();

            btnGravaConsulta_Click(sender, e);

        }

        private void btnLimpaConsulta_Click(object sender, EventArgs e)
        {
            rtbConsultasERP.Clear();
        }

        private void btnGravaConsulta_Click(object sender, EventArgs e)
        {
            if (File.Exists("C:\\Exports\\GravaConsultaSaldo.txt"))
            {
                File.Delete("C:\\Exports\\GravaConsultaSaldo.txt");
            }
            else
            {
                using (File.Create("C:\\Exports\\GravaConsultaSaldo.txt"))
                {

                }

            }

            File.AppendAllLines("C:\\Exports\\GravaConsultaSaldo.txt", rtbConsultasERP.Lines, Encoding.Default);

        }

        private void btnRecupera_Click(object sender, EventArgs e)
        {
            if (File.Exists("C:\\Exports\\GravaConsultaSaldo.txt"))
            {
                rtbConsultasERP.Lines = File.ReadAllLines("C:\\Exports\\GravaConsultaSaldo.txt", Encoding.Default);
            }
        }

        private void btnDeleta_Click(object sender, EventArgs e)
        {
            if (File.Exists("C:\\Exports\\GravaConsultaSaldo.txt"))
            {
                File.Delete("C:\\Exports\\GravaConsultaSaldo.txt");
            }
        }

        private void rtbConsultasERP_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                var x = (RichTextBox)sender;
                var d = x.SelectedText.Split(';');
                KeyPressEventArgs ev = new KeyPressEventArgs('\r');
                dg = (Convert.ToDecimal(d[1].Trim()) - Convert.ToDecimal(lblTotal.Text));
                lblSubtracao.Text = dg.ToString();
                lblSaldo.Text = d[1].Trim();
                lblPrateleira.Text = lblTotal.Text;
            }
            catch (Exception ex)
            {
            }
        }

        private void btnLimpaCalc_Click(object sender, EventArgs e)
        {
            rtbQuantidades.Clear();
        }

        private void btnGravaCalc_Click(object sender, EventArgs e)
        {
            if (File.Exists("C:\\Exports\\GravaCalc.txt"))
            {
                File.Delete("C:\\Exports\\GravaCalc.txt");
            }
            else
            {
                using (File.Create("C:\\Exports\\GravaCalc.txt"))
                { }
            }
            File.AppendAllLines("C:\\Exports\\GravaCalc.txt", rtbQuantidades.Lines, Encoding.Default);
        }

        private void btnRecuperaCalc_Click(object sender, EventArgs e)
        {
            if (File.Exists("C:\\Exports\\GravaCalc.txt"))
            {
                rtbQuantidades.Lines = File.ReadAllLines("C:\\Exports\\GravaCalc.txt", Encoding.Default);
            }
        }

        private void btnAddListaRequisicao_Click(object sender, EventArgs e)
        {
            dg = 0;
            if (File.Exists($@"C:\Exports\ListaSalvaRequisicao.txt"))
            {
                Apontamento a;
                List<Apontamento> la = new List<Apontamento>();
                int i = 1;
                foreach (DataGridViewRow r in dgvRequisicao.Rows)
                {
                    if (i == dgvRequisicao.Rows.Count)
                    {
                        break;
                    }
                    a = new Apontamento();
                    a.OP = r.Cells["OPr"].Value == null ? "0" : r.Cells["OPr"].Value.ToString();
                    a.Produto = r.Cells["Produtor"].Value == null ? "0" : r.Cells["Produtor"].Value.ToString();
                    a.Descricao = r.Cells["Descricaor"].Value == null ? "0" : r.Cells["Descricaor"].Value.ToString();
                    a.Metros = r.Cells["Metrosr"].Value == null ? "0" : r.Cells["Metrosr"].Value.ToString();
                    a.KG = r.Cells["KGr"].Value == null ? "0" : r.Cells["KGr"].Value.ToString();
                    a.Data = DateTime.Today.ToString("dd/MM/yyyy");
                    la.Add(a);
                    i++;
                }
                string lines = string.Empty;
                foreach (var al in la)
                {
                    lines += (al.OP + "\t" + al.Produto + "\t" + al.Descricao + "\t" + al.Metros + "\t" + al.KG + "\t" + al.Data + "\n");
                }
                File.AppendAllText($@"C:\Exports\ListaSalvaRequisicao.txt", lines);
            }
        }

        private void dgvRequisicao_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                dgvRequisicao.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = lblMeta.Text;
            }
            if (e.ColumnIndex == 3)
            {
                dgvRequisicao.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = lblMeta.Text;
            }

        }

        private void lblMesFechado_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja Obter o Mês Fechado?", "Mês Fechado", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ControllerERP_Pronto.ObterMesFechado();
                Application.Restart();
            }
        }

        private void btnSugestaoRequisitar_Click(object sender, EventArgs e)
        {
            List<RequisitaSugestao> rs = new List<RequisitaSugestao>();
            lblOPsSemSugestoes.Text = $"OPs Sem Sugestões";
            int i = 0; //
            foreach (DataGridViewRow row in dgvRequisicao.Rows)
            {
                if (row.Cells[0].Value == null)
                {
                    break;
                }

                Crud c = new Crud();
                var x = movim.Where(p => p.Documento == row.Cells[0].Value.ToString() & p.TM == 330 & p.DataInclusao > mesFechado).ToList();
                if (x.Count > 0 & i < 3)  // & i < 3
                {
                    MessageBox.Show($"A OP {row.Cells[0].Value.ToString()} não pode ser sugerida", "Não Sugerir");
                    lblOPsSemSugestoes.Text += $"\n{row.Cells[0].Value.ToString()}";
                    i++;  //
                    continue;
                }

                rs.Add(new RequisitaSugestao
                {
                    OP = row.Cells[0].Value.ToString(),
                    QTD = row.Cells[1].Value.ToString()
                });
            }
            if (rs.Count > 0)
            {
                if (MessageBox.Show("Deseja Continuar?", "Continue...", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ControllerERP_Pronto.RequisitarSugestao(rs);
                }
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            PesquisarItem();
        }

        private void PesquisarItem()
        {
            List<Saldo> ds;
            dgvConsultas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            ds = saldo.Where(s => s.Descricao.Contains(txtPesquisar.Text)).ToList();
            List<Saldo2> p = new List<Saldo2>();
            foreach (var item in ds)
            {
                p.Add(new Saldo2
                {
                    Produto = item.Produto,
                    Descricao = item.Descricao,
                });
            }
            dgvConsultas.DataSource = p.ToList();
        }

        private void Pesquisa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                PesquisarItem();
            }
        }

        private void btnPesquisaDocumento_Click(object sender, EventArgs e)
        {
            PesquisaDocumento();
        }

        private void PesquisaDocumento()
        {
            List<Movimento> ds;
            dgvConsultas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            ds = movim.Where(s => s.Codigo == txtPesquisaOPs.Text).ToList();
            var ca = new { X = "", y = 0 };
            Movimento2 m2 = new Movimento2();
            List<Movimento2> mv2 = new List<Movimento2>();
            foreach (var item in ds)
            {
                double livre17 = (double)saldo2.Where(p => p.Produto == item.Codigo).First().Livre17;
                mv2.Add(new Movimento2
                {
                    DataInclusao = item.DataInclusao,
                    Data = item.Data,
                    Codigo = item.Codigo,
                    TM = item.TM,
                    DocOS = item.Documento,
                    QTD = item.Quantidade,
                    QtdConvtd = Math.Round(item.Quantidade / livre17, 2),
                    Operador = item.OperadorInclusao
                });
            }
            dgvConsultas.DataSource = mv2.OrderByDescending(p => p.DataInclusao).ThenByDescending(p => p.DocOS).ToList();
        }

        private class Movimento2
        {
            public DateTime DataInclusao { get; internal set; }
            public DateTime Data { get; internal set; }
            public string Codigo { get; internal set; }
            public int TM { get; internal set; }
            public string DocOS { get; internal set; }
            public double QTD { get; internal set; }
            public string Operador { get; internal set; }
            public double QtdConvtd { get; internal set; }
        }

        private void btnPesquisaProdutos_Click(object sender, EventArgs e)
        {
            List<Movimento> ds;
            dgvConsultas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            ds = movim.Where(s => s.Documento == txtPesquisaProdutos.Text).ToList();
            var ca = new { X = "", y = 0 };
            Movimento2 m2 = new Movimento2();
            List<Movimento2> mv2 = new List<Movimento2>();
            foreach (var item in ds)
            {
                mv2.Add(new Movimento2
                {
                    DataInclusao = item.DataInclusao,
                    Data = item.Data,
                    Codigo = item.Codigo,
                    TM = item.TM,
                    DocOS = item.Documento,
                    QTD = item.Quantidade,
                    Operador = item.OperadorInclusao
                });
            }
            dgvConsultas.DataSource = mv2.OrderByDescending(p => p.DataInclusao).ToList();
        }

        private void btnSendRFIDEstorno_Click(object sender, EventArgs e)
        {
            SendRFID("E");
        }
        private void btnSendRFIDNovimentoAcerto_Click(object sender, EventArgs e)
        {
            SendRFID("MA");
        }
        private void btnSendRFIDRequisicao_Click(object sender, EventArgs e)
        {
            SendRFID("R");
        }

        private void SendRFID(string s)
        {

            switch (s)
            {
                case "R": ListaSalvaRequisicao(); break;
                case "E": ListaSalvaRetorno(); break;
                case "MA": ListaSalvaMovAcert(); break;
            }

            for (int i = 0; i < 10; i++)
            {
                using (var client = new WebClient())
                {
                    try
                    {
                        client.UploadFile("http://rfid.local/atuacard", fileName);
                        MessageBox.Show("Dados enviados para a Leitora!!", "SUCESSO");
                        fileName = "";
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
            }
        }

        private void ListaSalvaRetorno()
        {
            File.Delete($@"C:\Exports\ListaSalvaEstorno.txt");
            Apontamento a;
            List<Apontamento> la = new List<Apontamento>();
            int i = 1;
            foreach (DataGridViewRow r in dgvEstorno.Rows)
            {
                if (i == dgvEstorno.Rows.Count)
                {
                    break;
                }
                a = new Apontamento();
                a.OP = r.Cells["OP"].Value.ToString();
                a.Produto = r.Cells["Produto"].Value.ToString();
                a.Descricao = r.Cells["Descricao"].Value.ToString();

                string metros = Math.Round(Convert.ToDecimal(r.Cells["Metros"].Value.ToString()), 2).ToString("N2");
                a.Metros = metros.Replace(",", ".");

                a.KG = r.Cells["KG"].Value.ToString();
                a.Data = DataLancar;
                la.Add(a);
                i++;
            }
            string lines = string.Empty;
            string rfid = string.Empty;
            List<SendApontaRFID> lsar = new List<SendApontaRFID>();

            foreach (var al in la)
            {
                lines += (al.OP + "\t" + al.Produto + "\t" + al.Descricao + "\t" + al.Metros + "\t" + al.KG + "\t" + al.Data + "\n");

                string prateleira = saldo2.Where(p => p.Produto == al.Produto).FirstOrDefault().Prateleira;
                if (prateleira.Length <= 0)
                {
                    MessageBox.Show($@"O item '{al.Produto} {al.Descricao} não tem prateleira. A etiqueta não será alterada. Inclua os dados na etiqueta de outra forma'", "Manutenção Etiquetas");
                    continue;
                }

                lsar.Add(new SendApontaRFID
                {
                    Produto = al.Produto,
                    Metros = al.Metros,
                    Operacao = "+",
                    Prateleira = prateleira
                });
            }

            var lsar2 = lsar.OrderBy(p => p.Prateleira);
            var prateleiraPermitidas = PrateleirasPermitidas.ObterListaSiglas();
            foreach (var al in lsar2)
            {
                foreach (var p in prateleiraPermitidas)
                {
                    if (al.Prateleira.StartsWith(p))
                    {
                        rfid += ($"{al.Produto};{al.Metros};{al.Operacao};{al.Prateleira}\n");
                    }
                }
            }
            rfid.Trim();
            File.AppendAllText($@"C:\Exports\ListaSalvaEstorno.txt", lines);
            fileName = $@"C:\Exports\AtuaCard_{DateTime.Now.ToString("yyyy-MM-dd HHmmss")}.txt";
            File.AppendAllText(fileName, rfid.ToString().Trim(), Encoding.UTF8);
        }

        private void ListaSalvaRequisicao()
        {
            dg = 0;
            File.Delete($@"C:\Exports\ListaSalvaRequisicao.txt");
            Apontamento a;
            List<Apontamento> la = new List<Apontamento>();
            int i = 1;
            foreach (DataGridViewRow r in dgvRequisicao.Rows)
            {
                if (i == dgvRequisicao.Rows.Count)
                {
                    break;
                }
                a = new Apontamento();
                a.OP = r.Cells["OPr"].Value == null ? "0" : r.Cells["OPr"].Value.ToString();
                a.Produto = r.Cells["Produtor"].Value == null ? "0" : r.Cells["Produtor"].Value.ToString();
                a.Descricao = r.Cells["Descricaor"].Value == null ? "0" : r.Cells["Descricaor"].Value.ToString();

                string metros = Math.Round(Convert.ToDecimal(r.Cells["Metrosr"].Value == null ? "0" : r.Cells["Metrosr"].Value.ToString()), 2).ToString("N2");
                a.Metros = metros;

                a.KG = r.Cells["KGr"].Value == null ? "0" : r.Cells["KGr"].Value.ToString();
                a.Data = DateTime.Today.ToString("dd/MM/yyyy");
                la.Add(a);
                i++;
            }
            string lines = string.Empty;
            string rfid = string.Empty;
            List<SendApontaRFID> lsar = new List<SendApontaRFID>();
            foreach (var al in la)
            {
                lines += (al.OP + "\t" + al.Produto + "\t" + al.Descricao + "\t" + al.Metros + "\t" + al.KG + "\t" + al.Data + "\n");

                string prateleira = saldo2.Where(p => p.Produto == al.Produto).FirstOrDefault().Prateleira;
                if (prateleira.Length <= 0)
                {
                    MessageBox.Show($@"O item '{al.Produto} {al.Descricao} não tem prateleira. A etiqueta não será alterada. Inclua os dados na etiqueta de outra forma'", "Manutenção Etiquetas");
                    continue;
                }

                lsar.Add(new SendApontaRFID
                {
                    Produto = al.Produto,
                    Metros = al.Metros,
                    Operacao = "-",
                    Prateleira = prateleira
                });
            }

            var lsar2 = lsar.OrderBy(p => p.Prateleira);
            var prateleiraPermitidas = PrateleirasPermitidas.ObterListaSiglas();
            foreach (var al in lsar2)
            {
                foreach (var p in prateleiraPermitidas)
                {
                    if (al.Prateleira.StartsWith(p))
                    {
                        rfid += ($"{al.Produto};{al.Metros};{al.Operacao};{al.Prateleira}\n");
                    }
                }
            }

            rfid.Trim();

            File.AppendAllText($@"C:\Exports\ListaSalvaRequisicao.txt", lines);
            fileName = $@"C:\Exports\AtuaCard_{DateTime.Now.ToString("yyyy-MM-dd HHmmss")}.txt";
            File.AppendAllText(fileName, rfid.ToString().Trim(), Encoding.UTF8);
        }

        private void ListaSalvaMovAcert()
        {
            File.Delete($@"C:\Exports\ListaSalvaMovAcert.txt");
            Apontamento a;
            List<Apontamento> la = new List<Apontamento>();
            int i = 1;
            foreach (DataGridViewRow r in dgvMovAcert.Rows)
            {
                if (i == dgvMovAcert.Rows.Count)
                {
                    break;
                }
                a = new Apontamento();
                a.OP = r.Cells["DocumentoMA"].Value.ToString();
                a.Produto = r.Cells["ProdutoMA"].Value.ToString();
                a.Descricao = r.Cells["DescricaoMA"].Value.ToString();

                string metros = Math.Round(Convert.ToDecimal(r.Cells["MetrosMA"].Value.ToString()), 2).ToString("N2");
                a.Metros = metros;

                a.KG = r.Cells["KgMA"].Value.ToString();
                a.Data = r.Cells["DataMA"].Value.ToString();
                a.TM = r.Cells["TMMA"].Value.ToString();
                a.Livre2 = r.Cells["Livre2MA"].Value.ToString();
                la.Add(a);
                i++;
            }
            string lines = string.Empty;
            string rfid = string.Empty;
            List<SendApontaRFID> lsar = new List<SendApontaRFID>();
            foreach (var al in la)
            {
                lines += (al.OP + "\t" + al.Produto + "\t" + al.Descricao + "\t" + al.Metros + "\t" + al.KG + "\t" + al.Data + "\t" + al.TM + "\t" + al.Livre2 + "\n");

                char opr = '\0';
                if (al.TM == "331" | al.TM == "560")
                {
                    opr = '-';
                }
                else if (al.TM == "260" | al.TM == "91")
                {
                    opr = '+';
                }

                string prateleira = saldo2.Where(p => p.Produto == al.Produto).FirstOrDefault().Prateleira;
                if (prateleira.Length <= 0)
                {
                    MessageBox.Show($@"O item '{al.Produto} {al.Descricao} não tem prateleira. A etiqueta não será alterada. Inclua os dados na etiqueta de outra forma'", "Manutenção Etiquetas");
                    continue;
                }

                lsar.Add(new SendApontaRFID
                {
                    Produto = al.Produto,
                    Metros = al.Metros,
                    Operacao = opr.ToString(),
                    Prateleira = prateleira
                });
            }
            
            var lsar2 = lsar.OrderBy(p => p.Prateleira);
            var prateleiraPermitidas = PrateleirasPermitidas.ObterListaSiglas();
            foreach (var al in lsar2)
            {
                foreach (var p in prateleiraPermitidas)
                {
                    if (al.Prateleira.StartsWith(p))
                    {
                        rfid += ($"{al.Produto};{al.Metros};{al.Operacao};{al.Prateleira}\n");
                    }
                }
            }
            rfid.Trim();
            File.AppendAllText($@"C:\Exports\ListaSalvaMovAcert.txt", lines);
            fileName = $@"C:\Exports\AtuaCard_{DateTime.Now.ToString("yyyy-MM-dd HHmmss")}.txt";
            File.AppendAllText(fileName, rfid.ToString().Trim(), Encoding.UTF8);
        }


        private void PressEnter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                PesquisaDocumento();
            }
        }

        private void op_dClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string op = string.Empty;
            string cd = string.Empty;
            string pdt = string.Empty;
            var x = dgvConsultas.CurrentRow;

            try
            {
                op = x.Cells["DocOS"].Value.ToString();
                cd = x.Cells["Codigo"].Value.ToString();
            }
            catch (Exception) { }

            try
            {
                cd = pdt = x.Cells["Produto"].Value.ToString();
            }
            catch (Exception) { }

            var saldo = saldo2.Where(p => p.Produto == cd).FirstOrDefault();

            if (tabControl.SelectedTab.Text == "Requisições")
            {
                if (e.ColumnIndex == 4)
                {
                    int nr = dgvRequisicao.Rows.Add(1);
                    dgvRequisicao.Rows[nr].Cells["OPr"].Value = op;
                    dgvRequisicao.Rows[nr].Cells["Produtor"].Value = cd;
                    dgvRequisicao.Rows[nr].Cells["Descricaor"].Value = $"{saldo.Descricao}; {saldo.SaldoAtual}; {saldo.Unid}; {saldo.Prateleira}";
                }
            }

            if (tabControl.SelectedTab.Text == "Estornos")
            {
                if (e.ColumnIndex == 4)
                {
                    int nr = dgvEstorno.Rows.Add(1);
                    dgvEstorno.Rows[nr].Cells["OP"].Value = op;
                    dgvEstorno.Rows[nr].Cells["Produto"].Value = cd;
                    dgvEstorno.Rows[nr].Cells["Descricao"].Value = $"{saldo.Descricao}; {saldo.SaldoAtual}; {saldo.Unid}; {saldo.Prateleira}";
                }
            }

            if (tabControl.SelectedTab.Text == "Movimentos/Acertos")
            {
                if (e.ColumnIndex == 0)
                {
                    try
                    {
                        int nr = dgvMovAcert.Rows.Count - 2;
                        dgvMovAcert.Rows[nr].Cells["ProdutoMA"].Value = pdt;
                        dgvMovAcert.Rows[nr].Cells["DescricaoMA"].Value = $"{saldo.Descricao}; {saldo.SaldoAtual}; {saldo.Unid}; {saldo.Prateleira}";
                        return;
                    }
                    catch (Exception) { }

                    try
                    {
                        int nr = dgvMovAcert.Rows.Count - 1;
                        dgvMovAcert.Rows[nr].Cells["ProdutoMA"].Value = pdt;
                        dgvMovAcert.Rows[nr].Cells["DescricaoMA"].Value = $"{saldo.Descricao}; {saldo.SaldoAtual}; {saldo.Unid}; {saldo.Prateleira}";
                        return;
                    }
                    catch (Exception ex)
                    {

                        Debug.WriteLine(ex);
                    }
                }
            }
        }
    }
}
