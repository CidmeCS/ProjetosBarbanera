using Estoque.DAO;
using Estoque.Entidade;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Estoque.Classes
{
    internal class EntradaInventario
    {
        TextBox txtEntradaInventario;
        List<SaldoShort> l, s, m;
        DataGridView dataGridView1;
        ComboBox cbGrupo, cbPPs;
        Label lblProximo, lblCarregado;
        
        public EntradaInventario(TextBox txtEntradaInventario, List<SaldoShort> l, List<SaldoShort> s, DataGridView dataGridView1, 
            List<SaldoShort> m, ComboBox cbGrupo, ComboBox cbPPs, Label lblProximo, Label lblCarregado)
        {
            this.txtEntradaInventario = txtEntradaInventario;
            this.l = l;
            this.s = s;
            this.dataGridView1 = dataGridView1;
            this.m = m;
            this.cbGrupo = cbGrupo;
            this.cbPPs = cbPPs;
            this.lblProximo = lblProximo;
            this.lblCarregado = lblCarregado;
        }

        internal void Start(KeyEventArgs e)
        {
            List<SaldoShort> y = new List<SaldoShort>();


            if (e.KeyCode == Keys.Enter)
            {
                var t = txtEntradaInventario.Text;
                string tt = null;
                if (!(t.Contains(';')))
                {
                    tt = t.Replace(t.Substring(t.LastIndexOf('/'), 1).ToCharArray().First(), ';');
                    t = tt;

                }

                var enter = t.Split(';').ToList();

                //var k = from j in l where j.Produto == enter[0] select j.Grupo;

                var f = from j in l where j.Produto == enter[0] select j;

                //lance individual
                s.Add(new SaldoShort
                {
                    Produto = enter[0],
                    SaldoAtual = Convert.ToDouble(enter[1]),
                    Descricao = f.Select(h => h.Descricao).ToList().First(),
                    Unid = f.Select(h => h.Unid).ToList().First(),
                    Prateleira = f.Select(h => h.Prateleira).ToList().First(),
                    Disponivel = f.Select(h => h.Disponivel).ToList().First(),
                    PedVendas = f.Select(h => h.PedVendas).ToList().First(),
                    ForaEstoque = f.Select(h => h.ForaEstoque).ToList().First(),
                    Grupo = f.Select(h => h.Grupo).ToList().First(),


                });

                y.AddRange(s);
                //lance somatorio
                var q = (from h in s where h.Produto == enter[0] select h).Sum(u => u.SaldoAtual);
                var w = (from h in l where h.Produto == enter[0] select h.SaldoAtual).First();
                y.Add(new SaldoShort { Produto = enter[0], SaldoAtual = q, Descricao = "Somatorio", Prateleira = "Falta " + (w - q) });
                //lance de consulta
                y.AddRange(l.Where(p => p.Produto == enter[0]));

                dataGridView1.DataSource = y.ToList();
                dataGridView1.Rows[s.Count - 1].DefaultCellStyle.BackColor = Color.Green;
                dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;


                var tl = from h in l where h.Produto == enter[0] select h.SaldoAtual;
                if (q == tl.ToList()[0])
                {
                    dataGridView1.Rows[s.Count].DefaultCellStyle.BackColor = Color.Aqua;
                    dataGridView1.Rows[s.Count + 1].DefaultCellStyle.BackColor = Color.Aqua;
                    var indexx = m.FindIndex(mt => mt.Produto.Equals(enter[0]));
                    if (indexx >= 0)
                    {
                        m.RemoveAt(indexx);
                    }
                    var cb = cbGrupo.Text.Split('-').First().ToString();
                    var prod = cbPPs.Text;
                    if (cb == "000000")
                    {
                        cb = "";
                    }
                    Remove1(cb, prod);
                }
                else
                {
                    dataGridView1.Rows[s.Count].DefaultCellStyle.BackColor = Color.Yellow;
                    dataGridView1.Rows[s.Count + 1].DefaultCellStyle.BackColor = Color.Red;
                }
                txtEntradaInventario.Clear();
            }
        }

        public void Remove1(string cb, string prod)
        {
            var a = (from n in m where n.Grupo.Contains(cb) & !n.Prateleira.Equals("") & n.Produto.StartsWith(prod) orderby n.Prateleira select (n.Prateleira, n.Produto)).ToList();
            StringBuilder sb = new StringBuilder();
            foreach (var item in a)
            {
                if (a[0].Prateleira == item.Prateleira)
                {
                    sb.AppendLine(item.Prateleira + " > " + item.Produto);
                }
            }
            lblProximo.Text = sb.ToString();
        }

        public void Carregando()
        {
            if (l is null)
            {
                DataSet dsa = new DataSet();
                dsa = Crud.Select("SELECT * FROM saldos");
                l = new List<SaldoShort>();
                foreach (DataRow item in dsa.Tables[0].Rows)
                {

                    l.Add(new SaldoShort
                    {
                        Produto = item.ItemArray[1].ToString(),
                        Descricao = item.ItemArray[3].ToString(),
                        Unid = item.ItemArray[4].ToString(),
                        Grupo = item.ItemArray[6].ToString(),

                        SaldoAtual = (double)item.ItemArray[8],
                        Prateleira = item.ItemArray[29].ToString(),
                        Disponivel = (double)item.ItemArray[7],
                        //Entradas = (double)item.ItemArray[7],
                        //Saidas = (double)item.ItemArray[8],
                        PedVendas = (double)item.ItemArray[13],
                        //ProdPrevOS = (double)item.ItemArray[13],
                        ForaEstoque = (double)item.ItemArray[18],
                        //DeTerceiros = (double)item.ItemArray[16],
                        //PrevFabric = (double)item.ItemArray[7],

                    });
                }
                m.AddRange(l);
                lblCarregado.Text = "Tabela Carregada";

            }
            else
            {
                lblCarregado.Text = "A Tabela já está Carregada";
            }
        }
    }
}