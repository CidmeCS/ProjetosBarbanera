using Estoque.Classes;
using Estoque.Classes.ERP;
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
    public partial class ManutencaoBarrasLongas : Form
    {
        List<BarrasLongas> lbl;
        private Dictionary<string, string> dic;
        private DataTable dtt;

        public ManutencaoBarrasLongas()
        {
            InitializeComponent();
        }

        private void Load_(object sender, EventArgs e)
        {
            Atualiza();
        }

        private void Atualiza()
        {

            double metros = Convert.ToDouble(txtMetros.Text);

            lblCriterio.Text = "Critérios: " +
                            "\nPrateleira BL-, " +
                            $"\nMetro <= {metros}, " +
                            "\nPedCompras = 0, " +
                            "\nPrevConsuOS < SaldoAtual" +
                            "\nOrderBy DiasSemMovimento DESC";

            Crud c = new Crud();
            var result = c.ListaSaldo().Where(p =>
                p.Prateleira.StartsWith("BL-")
                & (p.SaldoAtual / (double)p.Livre17) <= metros 
                & p.PedCompras == 0
                & p.ConsuPrevOs < p.SaldoAtual
                ).OrderByDescending(p => p.DiassemMovimento).ToList();

            lbl = new List<BarrasLongas>();
            foreach (var item in result)
            {
                lbl.Add(new BarrasLongas
                {
                    Produto = item.Produto,
                    Descricao = item.Descricao,
                    Prateleira = item.Prateleira,
                    SaldoAtual = item.SaldoAtual,
                    Metros = Math.Round(item.SaldoAtual / (double)item.Livre17, 3),
                    DiasSemMovimentos = item.DiassemMovimento,
                    PedCompras = item.PedCompras,
                    ConsPrevOS = item.ConsuPrevOs
                });
            }

            dataGridView1.DataSource = lbl;
        }

        private void btnAtualiza_Click(object sender, EventArgs e)
        {
            Atualiza();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            LancarNoExcell.ManutencaoBarrasLongas(lbl);
        }

        private void btnCarregarExcelPreenchido_Click(object sender, EventArgs e)
        {

            var dt = RegistrarInventario.CarregaDataSet();

            dtt = new DataTable("Seleção");
            dtt.Columns.Add("Produto");
            dtt.Columns.Add("Descricao");
            dtt.Columns.Add("Prateleira");
            dtt.Columns.Add("SaldoAtual");
            dtt.Columns.Add("Metros");
            dtt.Columns.Add("DiasSemMovs");
            dtt.Columns.Add("NovaPrat");

            var ss = dt.Select("NovaPrat <> ''");
            foreach (var item in ss)
            {
                
                dtt.Rows.Add(item.ItemArray);

            }
            dataGridView1.DataSource = dtt;
            if (MessageBox.Show("Deseja aplicar no ERP?", "Manutenção no ERP", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                dic = new Dictionary<string, string>();
                foreach (DataRow item in dtt.Rows)
                {
                    dic.Add(item.ItemArray[0].ToString(), item.ItemArray[6].ToString());
                }
                ControllerERP_Pronto.AlterarPrateleira(dic);
            }
        }

        private void btnAlteraPrateleira_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count <= 0)
            {
               return;
            }
            if (btnAlteraPrateleira.Text == "Aplicar")
            {

                dic = new Dictionary<string, string>();
                foreach (DataRow item in dtt.Rows)
                {
                    dic.Add(item.ItemArray[0].ToString(), item.ItemArray[6].ToString());
                }
                ControllerERP_Pronto.AlterarPrateleira(dic);

                btnAlteraPrateleira.Text = "4- Altera Prateleira";

            }
            if (MessageBox.Show("Deseja Alterar as Prateleiras?", "Alterar Prateleiras", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                btnAlteraPrateleira.Text = "Aplicar";
            }
        }
    }

    public class BarrasLongas
    {
        public string Produto { get; internal set; }
        public string Descricao { get; internal set; }
        public string Prateleira { get; internal set; }
        public double SaldoAtual { get; internal set; }
        public double Metros { get; internal set; }
        public double DiasSemMovimentos { get; internal set; }
        public double PedCompras { get; internal set; }
        public double ConsPrevOS { get; internal set; }
        public string NovaPrateleira { get; internal set; }
    }
}
