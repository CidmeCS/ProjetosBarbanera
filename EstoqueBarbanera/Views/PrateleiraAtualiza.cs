using Estoque.Classes;
using Estoque.Classes.ERP;
using Estoque.DAO;
using Estoque.Entidade;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estoque.Views
{
    public partial class PrateleiraAtualiza : Form
    {
        static string path = @"C:\Exports\ListaAtualizaPrateleira.txt";
        public List<Saldo> saldo = new List<Saldo>();
        private List<Prateleiras> la;

        public PrateleiraAtualiza()
        {
            InitializeComponent();
        }


        private void PateleiraLoad(object sender, EventArgs e)
        {
            Crud c = new Crud();
            saldo = c.ListaSaldo();

            CarregaLista();
        }

        private void CarregaLista()
        {
            if (File.Exists(path) == false)
            {
                return;
            }
            var lines = File.ReadAllLines(path);

            if (lines.Count() == 0)
            {
                return;
            }

            la = new List<Prateleiras>();

            foreach (var line in lines)
            {
                var t = line.Split(';');
                Prateleiras p = new Prateleiras();
                p.Produto = t[0];
                p.Descricao = t[1];
                p.PrateleiraAtual = t[2];
                p.PrateleiraNova = t[3];
                la.Add(p);
            }

            int i = 0;
            foreach (var t in la)
            {
                dgvPrateleira.Rows.Add();
                dgvPrateleira.Rows[i].Cells["Produto"].Value = t.Produto;
                dgvPrateleira.Rows[i].Cells["Descricao"].Value = t.Descricao;
                dgvPrateleira.Rows[i].Cells["PrateleiraAtual"].Value = t.PrateleiraAtual;
                dgvPrateleira.Rows[i].Cells["PrateleiraNova"].Value = t.PrateleiraNova;
                i++;
            }

            dgvPrateleira.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void cellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0) //produto
                {
                    var l = e.RowIndex;
                    var produto = dgvPrateleira.CurrentCell.Value.ToString().ToUpper();
                    var item = saldo.Where(p => p.Produto == produto).FirstOrDefault();

                    dgvPrateleira.Rows[l].Cells["Produto"].Value = item.Produto;
                    dgvPrateleira.Rows[l].Cells["Descricao"].Value = item.Descricao;
                    dgvPrateleira.Rows[l].Cells["PrateleiraAtual"].Value = item.Prateleira;
                    dgvPrateleira.Rows[l].Cells["PrateleiraNova"].Value = "";
                }
                if (e.ColumnIndex == 3)
                {
                    var l = e.RowIndex;
                    dgvPrateleira.Rows[l].Cells["PrateleiraNova"].Value = dgvPrateleira.Rows[l].Cells["PrateleiraNova"].Value.ToString().ToUpper();


                    la = new List<Prateleiras>();
                    int i = 0;
                    foreach (DataGridViewRow item in dgvPrateleira.Rows)
                    {
                        if (item.Cells["Produto"].Value == null)
                        {
                            continue;
                        }

                        Prateleiras p = new Prateleiras();
                        p.Produto = dgvPrateleira.Rows[i].Cells["Produto"].Value.ToString();
                        p.Descricao = dgvPrateleira.Rows[i].Cells["Descricao"].Value.ToString();
                        p.PrateleiraAtual = dgvPrateleira.Rows[i].Cells["PrateleiraAtual"].Value.ToString();
                        p.PrateleiraNova = dgvPrateleira.Rows[i].Cells["PrateleiraNova"].Value.ToString();
                        la.Add(p);
                        i++;
                    }

                    File.Delete(path);
                    SalvaTXT();

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }



        private void SalvaTXT()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var it in la)
            {
                sb.AppendLine($"{it.Produto};{it.Descricao};{it.PrateleiraAtual};{it.PrateleiraNova}");
            }

            File.AppendAllText(path, sb.ToString());
        }
        public static void SalvaTXT(List<Prateleiras> la)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var it in la)
            {
                sb.AppendLine($"{it.Produto};{it.Descricao};{it.PrateleiraAtual};{it.PrateleiraNova}");
            }

            File.AppendAllText(path, sb.ToString());
        }

        private void btnAlteraNoERP_Click(object sender, EventArgs e)
        {
            if (la is null || la.Count == 0 )
            {
                return;
            }
            ControllerERP_Pronto.AlterarPrateleira(la);
            MessageBox.Show("Prateleiras Alteradas (ERP, Saldos e Etiquetas)", "Prateleiras OK");
        }

        private void btnLimparLinha_Click(object sender, EventArgs e)
        {
            var linha = dgvPrateleira.CurrentRow;
            var i = linha.Index;
            la.RemoveAt(i);
            File.Delete(path);
            SalvaTXT();
            dgvPrateleira.Rows.Remove(linha);
        }

        private void btnLimparTudo_Click(object sender, EventArgs e)
        {
            dgvPrateleira.Rows.Clear();
            File.Delete(path);
            la.Clear();

        }

        private void btnAlteraSaldos_Click(object sender, EventArgs e)
        {
            if (la is null || la.Count == 0)
            {
                return;
            }
            Crud crud = new Crud();
            foreach (var l in la)
            {
                crud.AlterarPrateleiraSaldo(l.Produto, l.PrateleiraNova);
            }
            MessageBox.Show("Prateleiras Alteradas (Saldos)", "Prateleiras OK");
        }

        private void btnAlteraETQ_Click(object sender, EventArgs e)
        {
            if (la is null || la.Count == 0)
            {
                return;
            }
            Crud crud = new Crud();
            foreach (var l in la)
            {
                crud.AlterarPrateleiraEtiqueta(l.Produto, l.PrateleiraNova);
            }
            MessageBox.Show("Prateleiras Alteradas (Etiquetas)", "Prateleiras OK");
        }

        private void btnAlteraSaldoEtq_Click(object sender, EventArgs e)
        {
            if (la is null || la.Count == 0)
            {
                return;
            }
            Crud crud = new Crud();
            foreach (var l in la)
            {
                crud.AlterarPrateleiraSaldo(l.Produto, l.PrateleiraNova);
                crud.AlterarPrateleiraEtiqueta(l.Produto, l.PrateleiraNova);
            }
            MessageBox.Show("Prateleiras Alteradas (Saldos e Etiquetas)","Prateleiras OK");
        }
    }
}
