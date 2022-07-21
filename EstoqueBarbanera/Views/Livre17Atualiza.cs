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
    public partial class Livre17Atualiza : Form
    {
        static string path = @"C:\Exports\ListaAtualizaLivre17.txt";
        public List<Saldo> saldo = new List<Saldo>();
        private List<Livre17> la;
        public Livre17Atualiza()
        {
            InitializeComponent();
        }

        private void dgvLivre17_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0) //produto
                {
                    var l = e.RowIndex;
                    var produto = dgvLivre17.CurrentCell.Value.ToString().ToUpper();
                    var item = saldo.Where(p => p.Produto == produto).FirstOrDefault();

                    dgvLivre17.Rows[l].Cells["Produto"].Value = item.Produto;
                    dgvLivre17.Rows[l].Cells["Descricao"].Value = item.Descricao;
                    dgvLivre17.Rows[l].Cells["Livre17Atual"].Value = item.Livre17;
                    dgvLivre17.Rows[l].Cells["Livre17New"].Value = "";
                }
                if (e.ColumnIndex == 3)
                {
                    var l = e.RowIndex;
                    dgvLivre17.Rows[l].Cells["Livre17New"].Value = dgvLivre17.Rows[l].Cells["Livre17New"].Value.ToString().ToUpper();


                    la = new List<Livre17>();
                    int i = 0;
                    foreach (DataGridViewRow item in dgvLivre17.Rows)
                    {
                        if (item.Cells["Produto"].Value == null)
                        {
                            continue;
                        }

                        Livre17 p = new Livre17();
                        p.Produto = dgvLivre17.Rows[i].Cells["Produto"].Value.ToString();
                        p.Descricao = dgvLivre17.Rows[i].Cells["Descricao"].Value.ToString();
                        p.Livre17Atual = dgvLivre17.Rows[i].Cells["Livre17Atual"].Value.ToString();
                        p.Livre17New = dgvLivre17.Rows[i].Cells["Livre17New"].Value.ToString();
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


        private void Livre17Load(object sender, EventArgs e)
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

            la = new List<Livre17>();

            foreach (var line in lines)
            {
                var t = line.Split(';');
                Livre17 p = new Livre17();
                p.Produto = t[0];
                p.Descricao = t[1];
                p.Livre17Atual = t[2];
                p.Livre17New = t[3];
                la.Add(p);
            }

            int i = 0;
            foreach (var t in la)
            {
                dgvLivre17.Rows.Add();
                dgvLivre17.Rows[i].Cells["Produto"].Value = t.Produto;
                dgvLivre17.Rows[i].Cells["Descricao"].Value = t.Descricao;
                dgvLivre17.Rows[i].Cells["Livre17Atual"].Value = t.Livre17Atual;
                dgvLivre17.Rows[i].Cells["Livre17New"].Value = t.Livre17New;
                i++;
            }

            dgvLivre17.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void SalvaTXT()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var it in la)
            {
                sb.AppendLine($"{it.Produto};{it.Descricao};{it.Livre17Atual};{it.Livre17New}");
            }

            File.AppendAllText(path, sb.ToString());
        }
        public static void SalvaTXT(List<Livre17> la)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var it in la)
            {
                sb.AppendLine($"{it.Produto};{it.Descricao};{it.Livre17Atual};{it.Livre17New}");
            }

            File.AppendAllText(path, sb.ToString());
        }

        private void btnAlteraNoERP_Click_1(object sender, EventArgs e)
        {

            if (la is null || la.Count == 0)
            {
                return;
            }
            ControllerERP_Pronto.AlterarLivre17(la);
           
            MessageBox.Show("Livres17 Alteradas (ERP, Saldos e ETQs)", "Livre17 OK");
        }

        private void btnLimparLinha_Click_1(object sender, EventArgs e)
        {
            var linha = dgvLivre17.CurrentRow;
            var i = linha.Index;
            la.RemoveAt(i);
            File.Delete(path);
            SalvaTXT();
            dgvLivre17.Rows.Remove(linha);
        }

        private void btnLimparTudo_Click_1(object sender, EventArgs e)
        {
            dgvLivre17.Rows.Clear();
            File.Delete(path);
            la.Clear();
        }

        private void btnPersonalizado_Click(object sender, EventArgs e)
        {
           
            var lista = saldo.Where(p=>p.Prateleira.StartsWith("BC-")).ToList();

            la = new List<Livre17>();

            foreach (var l in lista)
            {
                la.Add(new Livre17 { 
                    Produto = l.Produto,
                    Descricao = l.Descricao,
                    Livre17Atual = l.Livre17.ToString(),
                    Livre17New = ""
                });
            }

            foreach (var l in la)
            {
                dgvLivre17.Rows.Add(l.Produto, l.Descricao, l.Livre17Atual, l.Livre17New) ;
            }
            
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
                crud.AlterarLivre17Saldo(l.Produto, l.Livre17New);
                crud.AlterarLivre17Etiqueta(l.Produto, l.Livre17New);
            }
            MessageBox.Show("Livres17 Alteradas (Saldos e ETQs)", "Livre17 OK");
        }

        private void btnAlteraSaldo_Click(object sender, EventArgs e)
        {
            if (la is null || la.Count == 0)
            {
                return;
            }
            Crud crud = new Crud();
            foreach (var l in la)
            {
                crud.AlterarLivre17Saldo(l.Produto, l.Livre17New);
            }
            MessageBox.Show("Livres17 Alteradas (Saldos)", "Livre17 OK");
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
                crud.AlterarLivre17Etiqueta(l.Produto, l.Livre17New);
            }
            MessageBox.Show("Livres17 Alteradas (ETQs)", "Livre17 OK");
        }
    }

}

