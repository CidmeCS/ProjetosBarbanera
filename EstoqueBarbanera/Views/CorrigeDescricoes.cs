using Estoque.Classes;
using Estoque.Classes.ERP;
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
    public partial class CorrigeDescricoes : Form
    {
        public string antigo { get; private set; }

        private string novo;
        private List<SaldoT> lista;

        public CorrigeDescricoes()
        {
            InitializeComponent();
        }

        private void btnDosOutrosSetores_Click(object sender, EventArgs e)
        {
            CorrigeDescricaoItem cde = new CorrigeDescricaoItem(dataGridView1, lblLinhas);
            cde.Corrige();
        }

        private void btnListaParaCorrigir_Click(object sender, EventArgs e)
        {

            dataGridView2.Rows.Clear();
            Crud c = new Crud();

            antigo = tbBusca.Text;
            novo = tbCorrecao.Text;
            int quantidade = ((int)numericUpDown1.Value);
            if (quantidade == 0)
            {
                quantidade = 999999;
            }


            lista = new List<SaldoT>(from l in c.ListaSaldo().Where(p => p.Grupo == comboBox1.Text)
                                     where l.Descricao.StartsWith(antigo)
                                     orderby l.Descricao
                                     select new SaldoT
                                     {
                                         Produto = l.Produto,
                                         Descricao = l.Descricao,
                                         Descricao2 = l.Descricao2,
                                         DESCR_2 = l.DESCR_2
                                     }).Take(quantidade).ToList();

            label1.Text = lista.Count().ToString();

            if (lista.Count > 0)
            {
                dataGridView2.Rows.Add(lista.Count);

                int seq = 0;
                foreach (var i in lista)
                {
                    dataGridView2.Rows[seq].Cells["Produto"].Value = i.Produto;
                    dataGridView2.Rows[seq].Cells["Descricao"].Value = i.Descricao;
                    dataGridView2.Rows[seq].Cells["Desc1"].Value = i.Descricao2;
                    dataGridView2.Rows[seq].Cells["Desc2"].Value = i.DESCR_2;
                    seq++;
                }
            }
        }

        private void btnCorrigeDoGrid_Click(object sender, EventArgs e)
        {
            List<SaldoT> list = new List<SaldoT>();
            foreach (DataGridViewRow i in dataGridView2.Rows)
            {
                if (i.Cells["Produto"].Value == null)
                {
                    continue;
                }
                list.Add(new SaldoT
                {
                    Produto = i.Cells["Produto"].Value.ToString(),
                    Descricao = i.Cells["Descricao"].Value.ToString(),
                    Descricao2 = i.Cells["Desc1"].Value.ToString(),
                    DESCR_2 = i.Cells["Desc2"].Value == null ? "" : i.Cells["Desc2"].Value.ToString()
                });
            }

            if (list.Count > 0 & MessageBox.Show("Deseja Alterar no ERP?", "Atualização", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ControllerERP_Pronto.CorrigeTubo(list);
                MessageBox.Show("FIM", "FIM");
            }
        }

        private void btnAjudaGrid_Click(object sender, EventArgs e)
        {
            var NLO = CorrigeDescricaoItem.CorrigeTubo(lista, antigo, novo);

            dataGridView2.Rows.Clear();
            dataGridView2.Rows.Add(NLO.Count);
            int seq = 0;
            foreach (var i in NLO)
            {
                dataGridView2.Rows[seq].Cells["Produto"].Value = i.Produto;
                dataGridView2.Rows[seq].Cells["Descricao"].Value = i.Descricao;
                dataGridView2.Rows[seq].Cells["Desc1"].Value = i.Descricao2;
                dataGridView2.Rows[seq].Cells["Desc2"].Value = i.DESCR_2;
                seq++;
            }
        }

        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string Descricao = string.Empty;
            string Desc1 = string.Empty;
            string Desc2 = string.Empty;
            try
            {
                if (e.ColumnIndex >= 2)
                {
                    Desc1 = dataGridView2.Rows[e.RowIndex].Cells["Desc1"].Value.ToString().Trim();
                    if (dataGridView2.Rows[e.RowIndex].Cells["Desc2"].Value != null)
                    {
                        Desc2 = dataGridView2.Rows[e.RowIndex].Cells["Desc2"].Value.ToString().Trim();
                    }
                    Descricao = $"{Desc1} {Desc2}".Trim();
                    dataGridView2.Rows[e.RowIndex].Cells["Descricao"].Value = Descricao.Trim();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

    internal class SaldoT
    {
        public string Produto { get; set; }
        public string Descricao { get; set; }
        public string Descricao2 { get; set; }
        public string DESCR_2 { get; set; }
    }
}
