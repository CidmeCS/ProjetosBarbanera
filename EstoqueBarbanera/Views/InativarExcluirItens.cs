using Estoque.Classes;
using Estoque.Classes.ERP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estoque.Views
{
    public partial class InativarExcluirItens : Form
    {
        private string filePath;

        public InativarExcluirItens()
        {
            InitializeComponent();
        }

        private void btnListarParaExcel_Click(object sender, EventArgs e)
        {
            var table = InativarItensParados.Start();
            LancarNoExcell.InativarItensParados(table);
        }

        private void btnAbrePlanilha_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Exports\InativarItensParados.xlsx");
        }

        private void btnCarregaPlanilha_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = @"C:\Export\";
                openFileDialog.Filter = "xlsx files (*.xlsx)|*.xlsx";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                }
            }
        }

        private void btnExcluiItens_Click(object sender, EventArgs e)
        {
            var dtContent = RegistrarInventario.GetDataTableFromExcel(filePath);
            List<string> produtos = new List<string>();
            foreach (DataRow item in dtContent.Rows)
            {
                produtos.Add(item.Field<string>("Produto"));
            }
            produtos.Sort();
            ControllerERP_Pronto.ExcluirItens(produtos, filePath);
        }
    }
}
