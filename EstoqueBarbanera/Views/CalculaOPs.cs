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
    public partial class CalculaOPs : Form
    {
        public CalculaOPs()
        {
            InitializeComponent();
        }

        private void btnBuscaOP_Click(object sender, EventArgs e)
        {
            Classes.CalculaOPs co = new Classes.CalculaOPs();
            var lista = co.CalcularOP(txtOP.Text);
            dataGridView1.DataSource = lista;

        }
    }
}
