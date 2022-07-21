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

namespace Estoque.Views
{
    public partial class ReceberNFs : Form
    {
        HashSet<Int64> NotasFiscais = new HashSet<Int64>();
        private List<NotasFiscaisDinamicaProduto> r;
        private List<NotasFiscaisDinamicaProduto> rt;
        private List<DepositoDeTerceiro> h;
        private List<Notas> ln;
        private NotasFiscaisDinamicaProduto rr;
        StringBuilder sb;
        private List<PedidoNFs> listaMatarSaldo = new List<PedidoNFs>();
        DateTime data;

        public ReceberNFs()
        {
            InitializeComponent();
            DateTime hoje = DateTime.Today;
            data = hoje.AddMonths(-2).AddDays(-hoje.Day + 1);
            Crud c = new Crud();
            rt = c.ListaNotasFiscaisDinamicaProduto().ToList();
            r = rt.Where(P => P.DataMovimento >= data).ToList();
            h = c.ListaDepositoDeTerceiro();
        }

        /// <summary>
        /// Lista Totas as notas com o nome do cliente ou fornecedor, estabelecimento e deposito
        /// </summary>
        /// <returns></returns>
        private void btnReceberNFs_Click(object sender, EventArgs e)
        {
            Estoque.Classes.ReceberNFs rn = new Estoque.Classes.ReceberNFs();
            var lista = rn.Recebe();
            dataGridView1.DataSource = lista;
            lblAcao.Text = $"{lista.Count} linhas >> em btn Receber NFs";
        }

        private void btnOPsComSaldo_Click(object sender, EventArgs e)
        {
            ComprasComSaldos ocs = new ComprasComSaldos();
            listaMatarSaldo.Clear();
            listaMatarSaldo = ocs.RelatorioParaMatarSaldos();
            dataGridView1.DataSource = listaMatarSaldo;
            lblAcao.Text = $"{listaMatarSaldo.Count} linhas >> em btn OPs Com Saldo Para Eliminar";
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            DateTime data = new DateTime(2015, 01, 01);
            Pesquisar();

        }

        private void Pesquisar(DateTime data)
        {
            Estoque.Classes.ReceberNFs rn = new Estoque.Classes.ReceberNFs();
            var lista = rn.Pesquisa(cbbPesquisar.Text, txtPesquisar.Text, h);
            dataGridView1.DataSource = lista;
            lblAcao.Text = $"{lista.Count} linhas >> em btn Pesquisar NFs";
            txtNFs2.Text = txtPesquisar.Text;
            Carrega3();
            txtPesquisar.Clear();
            txtCodBarras.Focus();
        }
        private void Pesquisar()
        {
            string FoncFant = string.Empty;
            Estoque.Classes.ReceberNFs rn = new Estoque.Classes.ReceberNFs();
            var lista = rn.Pesquisa(cbbPesquisar.Text, txtPesquisar.Text, r, h);
            try
            {
                FoncFant = lista[0].Fornecedor.Split(';')[0];
            }
            catch (Exception)
            {
            }
            List<string> TMs;
            foreach (var item in lista)
            {
                var rtnf = this.rt.Where(p => p.NomeFantasia == FoncFant & p.Produto == item.Produto & p.NotaFiscal != Convert.ToInt64(txtPesquisar.Text)).ToList();
                TMs = rtnf.Select(p => p.TipoMovto).ToList();
                var s = TMs.Contains(item.TM);
                var at = "";
                if (TMs.Count > 1 & s == false)
                {
                    at = "AtençãoTM";
                }
                else
                {
                    at = "OK";
                }
                item.Atencao = at;
            }

            dataGridView1.DataSource = lista;

            foreach (DataGridViewRow dgvrow in dataGridView1.Rows)
            {
                if (dgvrow.Cells["Atencao"].Value.ToString() != "OK")
                {
                    dgvrow.Cells["Atencao"].Style.BackColor = Color.Coral;
                    dgvrow.Cells["TM"].Style.BackColor = Color.Coral;
                }
                else
                {
                    dgvrow.Cells["Atencao"].Style.BackColor = Color.LightSkyBlue;
                }
            }


            lblAcao.Text = $"{lista.Count} linhas >> em btn Pesquisar NFs";
            txtNFs2.Text = txtPesquisar.Text;
            Carrega3();
            txtPesquisar.Clear();
            txtCodBarras.Focus();
        }

        private void btnListaCompras_Click(object sender, EventArgs e)
        {
            ComprasComSaldos ocs = new ComprasComSaldos();
            var lista = ocs.ListarCompras();
            dataGridView1.DataSource = lista;

            lblAcao.Text = $"{lista.Count} linhas >> em btn Lista de OPs";
        }

        private void btnPesquisar2_Click(object sender, EventArgs e)
        {
            DateTime hoje = DateTime.Today;
            DateTime data = hoje.AddMonths(-2).AddDays(hoje.Day - 1);
            ln = new List<Notas>();
            foreach (var r in NotasFiscais)
            {
                Estoque.Classes.ReceberNFs rn = new Estoque.Classes.ReceberNFs();
                var lista = rn.Pesquisa("NotaFiscal", r.ToString(), this.r, h);

                ln.AddRange(lista);

            }
            dataGridView1.DataSource = ln.OrderBy(p => p.NotaFiscal).ToList();

        }

        private void txtNFs(object sender, EventArgs e)
        {
            Carrega();
        }

        private void Carrega()
        {
            if (txtNFs2.Text.Length <= 0)
                lblDescricao.Text = "*";
            else
                try
                {
                    lblDescricao.Text = Pesquisar(Convert.ToInt64(txtNFs2.Text));
                }
                catch (Exception)
                {

                }
        }

        private string Pesquisar(Int64 text)
        {
            string ClienteFornecedor = "";

            try
            {
                rr = r.Where(f => f.NotaFiscal == text).First(); ;

            }
            catch (Exception)
            {
                return null;
            }

            if (rr.NomeFantasia.Length > 0)
            {
                ClienteFornecedor = rr.NomeFantasia;
            }
            if (rr.NomeFantasia.Length <= 0)
            {
                string deposito = string.Empty;
                switch (rr.Deposito.Length)
                {
                    case 1: deposito = "00" + rr.Deposito; break;
                    case 2: deposito = "0" + rr.Deposito; break;
                    default: deposito = rr.Deposito; break;
                }
                ClienteFornecedor = rr.Deposito + "-" + h.Where(p => p.Deposito == deposito).First().Nome;
            }
            return ClienteFornecedor;

        }



        private void myTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Carrega2(e);
        }

        private void Carrega2(KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Carrega3();
            }
        }

        private void Carrega3()
        {
            if (txtNFs2.TextLength > 0)
            {
                try
                {
                    NotasFiscais.Add(Convert.ToInt64(txtNFs2.Text));

                }
                catch (Exception)
                {
                    return;
                }
                rtbNFs.Text = "";
                sb = new StringBuilder();
                foreach (var item in NotasFiscais)
                {
                    sb.AppendLine(item.ToString());
                }
                rtbNFs.Text = sb.ToString();

            }
            txtNFs2.Clear();
        }

        private void btnLimpaLista_Click(object sender, EventArgs e)
        {
            rtbNFs.Clear();
            NotasFiscais.Clear();
            r = null;
            ln = null;
            rr = null;
            sb = null;

        }

        private void brnGeraListaExcel_Click(object sender, EventArgs e)
        {
            var path = LancarNoExcell.PedidoDeCompraSaldosParaEliminar(listaMatarSaldo);
            OutLook.PedidoDeComprasSaldosParaMatarParaCompras(path);
        }

        private void btnObterRetornoDeCompras_Click(object sender, EventArgs e)
        {
            DataTable ds = ComprasComSaldos.CarregaDataTable(ref listaMatarSaldo);
            dataGridView1.DataSource = ds;
        }

        private void btnZerarSaldos_Click(object sender, EventArgs e)
        {
            if (listaMatarSaldo == null)
            {
                MessageBox.Show("Primeiramente, 3-Obter Retorno de Compras", "ERRO");
                return;
            }
            ControllerERP_Pronto.ZerarSaldos(listaMatarSaldo);
        }

        private void txtCarregaXYZ(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 13)
            {
                if (txtCodBarras.TextLength >= 34 & txtCodBarras.TextLength <= 44)
                {
                    var cod = txtCodBarras.Text;
                    var nf = cod.Substring(25, 9);
                    txtNFs2.Text = txtPesquisar.Text = nf;
                    txtCodBarras.Clear();
                    Pesquisar();
                    Carrega3();
                    txtPesquisar.Clear();
                    txtCodBarras.Focus();
                }
            }
        }

        private void btnLimpaLinhaSelecionada_Click(object sender, EventArgs e)
        {
            var linhaSelecionada = dataGridView1.CurrentRow;
            var Pedido = linhaSelecionada.Cells[0].Value.ToString();
            var LinhaPed = linhaSelecionada.Cells[8].Value.ToString();
            var lin = linhaSelecionada.Index;
            listaMatarSaldo.RemoveAt(lin);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = listaMatarSaldo;
            lblAcao.Text = $"{listaMatarSaldo.Count} linhas >> em btn OPs Com Saldo Para Eliminar";

            Crud c = new Crud();
            var pca = c.ListPedidoDeCompra().Where(p => p.Pedido == Pedido & p.LinhaPed == LinhaPed).ToList();
            c.DeletaPedidoDeCompra(pca);


        }
    }
}
