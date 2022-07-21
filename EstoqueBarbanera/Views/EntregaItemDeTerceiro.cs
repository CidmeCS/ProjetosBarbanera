using Estoque.Classes;
using Estoque.DAO;
using Estoque.Entidade;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estoque.Views
{
    public partial class EntregaItemDeTerceiro : Form
    {
        private List<EntregaDeTerceiro> edt;
        DataGridViewRow row;
        private DataTable lista;

        public List<EntregaDeTerceiro> ListaManutencaoEntregas { get; private set; }

        public EntregaItemDeTerceiro()
        {
            InitializeComponent();
        }

        private void EntregaItemDeTerceiro_Load(object sender, EventArgs e)
        {
            InventarioDepositosDeTerceiro iddt = new InventarioDepositosDeTerceiro();
            lista = iddt.Lista();
            dataGridView1.DataSource = lista;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            row = dataGridView1.CurrentRow;
            txtProduto.Text = row.Cells["Produto"].Value.ToString();
            txtDescricao.Text = row.Cells["Descricao"].Value.ToString();
            txtCliente.Text = row.Cells["DEPOSITO"].Value.ToString();
            txtData.Text = DateTime.Today.ToString("dd/MM/yyyy") + " " + DateTime.Now.ToString("HH:mm");
            txtQuantidade.Focus();
        }

        private void btnEntregar_Click(object sender, EventArgs e)
        {
            if (txtEntreguePara.TextLength > 0 & txtQuantidade.TextLength > 0 & txtProduto.TextLength > 0)
            {
                Classes.EntregaItemDeTerceiro edt = new Classes.EntregaItemDeTerceiro();
                edt.Entregar(row, txtQuantidade, txtEntreguePara);

                Lista();

                txtCliente.Clear();
                txtData.Clear();
                txtDescricao.Clear();
                txtEntreguePara.Clear();
                txtProduto.Clear();
                txtQuantidade.Clear();
                txtQuantidade.Focus();
            }


        }

        private void Lista()
        {
            Crud c = new Crud();
            var liedt = c.ListaItemEntregaDeTerceiro();
            var ddt = c.ListaDepositoDeTerceiro();

            var l = (from lt in liedt
                     join d in ddt on lt.Deposito equals d.Deposito into gj
                     from g in gj.DefaultIfEmpty()

                     select new ListaEntregaDeTerceiro
                     {
                         Id = lt.Id,
                         Produto = lt.Produto,
                         Descricao = lt.Descricao,
                         Deposito = lt.Deposito,
                         Data = lt.Data,
                         EntreguePara = lt.EntreguePara,
                         Quantidade = lt.Quantidade
                     }).OrderByDescending(p=>p.Id).ToList();

            var list = DeListParaTable.ConvertListToTableGeneric<ListaEntregaDeTerceiro>(l);

            dataGridView2.DataSource = list;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Lista();
        }

        public class ListaEntregaDeTerceiro
        {
            public int Id { get; internal set; }
            public string Produto { get; internal set; }
            public string Descricao { get; internal set; }
            public string Deposito { get; internal set; }
            public string Data { get; internal set; }
            public string EntreguePara { get; internal set; }
            public double Quantidade { get; internal set; }
        }

        private void btnZeradosMasEntregues_Click(object sender, EventArgs e)
        {


            //
            InventarioDepositosDeTerceiro iddt = new InventarioDepositosDeTerceiro();

            ListaManutencaoEntregas = iddt.ListaManutencao();

            dataGridView2.DataSource = ListaManutencaoEntregas;
            //


            //DataTable table = new DataTable();
            //table.Columns.Add("Produto", typeof(String));
            //table.Columns.Add("Descricao", typeof(String));
            //table.Columns.Add("Prateleira", typeof(String));
            //table.Columns.Add("Unid/Saldo", typeof(String));
            //table.Columns.Add("DeTerceiros", typeof(Double));
            //table.Columns.Add("Inventario", typeof(String));
            //table.Columns.Add("Deposito", typeof(String));
            //table.Columns.Add("Entrega", typeof(String));
            //// Presuming the DataTable has a column named Date.
            //string expression;
            //expression = "DeTerceiros = 0 and Entrega <> '' and [Unid/Saldo] Like '%: 0%' ";
            //DataRow[] foundRows;

            //// Use the Select method to find all rows matching the filter.
            //foundRows = lista.Select(expression);
            //var i = foundRows.Count();
            //DataRow row;
            //foreach (var item in foundRows)
            //{
            //    row = table.NewRow();

            //    row[0] = item.ItemArray[0];
            //    row[1] = item.ItemArray[1];
            //    row[2] = item.ItemArray[2];
            //    row[3] = item.ItemArray[3];
            //    row[4] = item.ItemArray[4];
            //    row[5] = item.ItemArray[5];
            //    row[6] = item.ItemArray[6];
            //    row[7] = item.ItemArray[7];

            //    table.Rows.Add(row);

            //}

        }

        private void btnLiberarEntregas_Click(object sender, EventArgs e)
        {
            Crud c = new Crud();
            var x = ListaManutencaoEntregas;


            c.RemoveEntregaDeTerceiro(x);

            InventarioDepositosDeTerceiro iddt = new InventarioDepositosDeTerceiro();

            ListaManutencaoEntregas = iddt.ListaManutencao();

            dataGridView2.DataSource = ListaManutencaoEntregas;

            MessageBox.Show("Limpo os itens zerados e entregues", "Manutenção OK!!");

        }

        private void btnRemoveEntregaUnitario_Click(object sender, EventArgs e)
        {
            if (btnRemoveEntregaUnitario.Text == "Aplicar")
            {

                Crud c = new Crud();
                c.RemoveEntregaDeTerceiro(edt);

                Lista();

                btnRemoveEntregaUnitario.Text = "2 - Remove Entrega Unitario";

            }
            else
            {
                if (MessageBox.Show($"Deseja Devolver a Entrega?\n" +
                    $"Id {edt.Select(p => p.Id).First()},\nProduto {edt.Select(p => p.Produto).First()}"
                    , "Devolução de entrega", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    btnRemoveEntregaUnitario.Text = "Aplicar";
                }
            }



        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            edt = new List<EntregaDeTerceiro>();
            row = dataGridView2.CurrentRow;

            try
            {
                edt.Add(new EntregaDeTerceiro
                {
                    Id = (int)row.Cells["Id"].Value,
                    Produto = row.Cells["Produto"].Value.ToString(),
                    Descricao = row.Cells["Descricao"].Value.ToString(),
                    Quantidade = (double)row.Cells["Quantidade"].Value,
                    Deposito = row.Cells["Deposito"].Value.ToString(),
                    EntreguePara = row.Cells["EntreguePara"].Value.ToString(),
                    Data = row.Cells["Data"].Value.ToString()
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("FALTA IMPLEMENTAR");
        }
    }
}
