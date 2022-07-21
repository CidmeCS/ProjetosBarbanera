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
    public partial class PCP : Form
    {
        public PCP()
        {
            InitializeComponent();
        }

        private void btnAtualiza_Click(object sender, EventArgs e)
        {
            Atualiza();
        }

        private void Atualiza()
        {
            Crud c = new Crud();

            var lista = c.ListaSaldo().Where(p=> (p.Grupo == "10000000" | p.Grupo == "11000000") & p.SaldoAtual > 0D & p.Prateleira == "").OrderBy(p=> p.Grupo).ThenBy(p=>p.Produto).ToList();
            var lista10 = (from i in lista
                           where (i.PedVendas - i.SaldoAtual != i.PrevFabric) & i.Grupo == "10000000"
                           select new { i.Produto, i.Descricao, i.Prateleira, i.Disponivel, i.SaldoAtual, i.SaldoUltFech, i.Entradas, i.Saidas, i.PedCompras, i.PedVendas, i.ForaEstoque, i.DeTerceiros, i.PrevFabric, i.ConsuPrevOs, i.DiassemMovimento, i.Grupo }).ToList();
            var lista11 = (from i in lista
                           where i.Grupo == "11000000"
                           & i.SaldoAtual != i.ForaEstoque
                           select new { i.Produto, i.Descricao, i.Prateleira, i.Disponivel, i.SaldoAtual, i.SaldoUltFech, i.Entradas, i.Saidas, i.PedCompras, i.PedVendas, i.ForaEstoque, i.DeTerceiros, i.PrevFabric, i.ConsuPrevOs, i.DiassemMovimento, i.Grupo }).ToList();

            lista10.AddRange(lista11);
            var table = DeListParaTable.ConvertListToTableGeneric(lista10);

            dgvPCP.DataSource = table;
        
        }

        private void PCP_Load(object sender, EventArgs e)
        {
            Atualiza();
        }

        private void btnEliminaLinha_Click(object sender, EventArgs e)
        {
            var row = dgvPCP.CurrentRow;
            var cod = row.Cells["Produto"].Value.ToString();

            Crud c = new Crud();
            var saldo = c.ListaSaldo().Where(p=>p.Produto == cod).First();
            saldo.SaldoAtual = 0D;
            c.AlteraSaldo(saldo);
            dgvPCP.Rows.Remove(row);
        }

        private void btnEliminaTudo_Click(object sender, EventArgs e)
        {
            var rows = dgvPCP.Rows;

            List<Saldo> ls = new List<Saldo>();
            Crud c = new Crud();
            foreach (DataGridViewRow r in rows)
            {
                if (r.Cells["Produto"].Value == null)
                {
                    continue;
                }

                var cod = r.Cells["Produto"].Value.ToString();
                var saldo = c.ListaSaldo().Where(p=>p.Produto == cod).First();
                saldo.SaldoAtual = 0D;
                ls.Add(saldo);
            }

            c.AlteraSaldo(ls);
            dgvPCP.Rows.Clear();
        }
    }
}
