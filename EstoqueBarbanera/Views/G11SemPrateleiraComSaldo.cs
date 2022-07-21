using Estoque.Classes;
using Estoque.DAO;
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
    public partial class G11SemPrateleiraComSaldo : Form
    {
        public G11SemPrateleiraComSaldo()
        {
            InitializeComponent();
        }

        private void btnEliminaLinha_Click(object sender, EventArgs e)
        {
            var row = dgvResult.CurrentRow;
            var cod = row.Cells["Produto"].Value.ToString();
            Crud c = new Crud();
            var saldo = c.ListaSaldo().Where(p=>p.Produto  == cod).First();
            saldo.SaldoAtual = 0D;
            c.AlteraSaldo(saldo);
            CarregarDados();
        }

        private void G11SemPrateleiraComSaldo_Load(object sender, EventArgs e)
        {
            CarregarDados();
        }

        private void CarregarDados()
        {
            Crud c = new Crud();

            var lista = c.ListaSaldo().Where(p => p.Grupo == "11000000" & p.SaldoAtual > 0 & p.Prateleira == "").ToList();
            var lista2 = (from lc in lista
                          orderby lc.Produto
                          select new { lc.Produto, lc.Descricao, lc.Prateleira, lc.SaldoAtual, lc.ConsuPrevOs, lc.ForaEstoque, lc.PrevFabric }).ToList();

            dgvResult.DataSource = DeListParaTable.ConvertListToTableGeneric(lista2.ToList());
        }

        private void btnEliminaTudo_Click(object sender, EventArgs e)
        {
            Crud c = new Crud();

            var lista = c.ListaSaldo().Where(p => p.Grupo == "11000000" & p.SaldoAtual > 0 & p.Prateleira == "").ToList();

            lista.ForEach(P => P.SaldoAtual = 0D);

            c.AlteraSaldo(lista);

            CarregarDados();
        }
    }
}
