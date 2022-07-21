using Estoque.Classes;
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
    public partial class frmMaterialParado : Form
    {
        private DataSet ds;

        public frmMaterialParado()
        {
            InitializeComponent();
        }

        private void ProdutosAcabados(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ds = new DataSet();
            ds = MaterialParado.ProdutosAcabados();
            dataGridView1.DataSource = ds.Tables[0];
            lblLinhas.Text = ds.Tables[0].Rows.Count.ToString() + " LINHAS RETORNADAS";
        }

        private void SemiAcabados_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Implementar SemiAcabados");
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //var ds = MaterialParado.SemiAcabados();
            //dataGridView1.DataSource = ds.Tables[0];
            //lblLinhas.Text = ds.Tables[0].Rows.Count.ToString() + " LINHAS RETORNADAS";
        }

        private void Imprimir(object sender, EventArgs e)
        {
            MaterialParado.ProdutosAcabados();
            var m = MaterialParado.mp;
            LancarNoExcell.MaterialParado(m);
        }
    }
}
