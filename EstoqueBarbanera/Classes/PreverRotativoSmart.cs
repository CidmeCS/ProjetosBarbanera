using Estoque.Entidade;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estoque.Classes
{
    public class PreverRotativoSmart
    {
        public List<RegistroInventario> ir;
        public DateTime inicio, fim;
        public Label lblQuantidade;
        public DataGridView dataGridView1;
        public DataTable dtSmart = null;
        private DeListParaTable dlpt;

        public List<string> InventarioMovimento { get; private set; }
        public List<string> rotativo { get; private set; }
        public List<string> @is { get; private set; }
        public Dictionary<int, string> l { get; private set; }
        public int invert { get; private set; }
        //public object[] t { get; private set; }
        public int o { get; private set; }
        public List<string> poupados { get; private set; }

        public PreverRotativoSmart(DateTime inicio, DateTime fim, Label lblQuantidade, DataGridView dataGridView1)
        {
            this.inicio = inicio;
            this.fim = fim;
            this.lblQuantidade = lblQuantidade;
            this.dataGridView1 = dataGridView1;
        }
        internal DataTable Start(int qtd )
        {
            if (qtd > 0)
            {
                InventarioMovimento = Inventario.Inventariar(inicio, fim).Select(p => p.Codigo).ToList();
                rotativo = new List<string>();
                rotativo.AddRange(PreverRotativo());
                @is = rotativo.Except(InventarioMovimento).ToList();
                l = new Dictionary<int, string>();
                invert = dtSmart.Rows.Count;
                //t = dtSmart.Rows[2].ItemArray;

                for (int i = 0; i < invert; i++)
                {
                    o = dtSmart.Columns["Produto"].Ordinal;
                    l.Add(i, dtSmart.Rows[i].ItemArray[o].ToString());
                }
                
                poupados = l.Values.Except(@is).ToList();
                poupados = poupados.OrderByDescending(c => c).ToList();

                var hh  = l.Values.Except(@is); 

                foreach (var item in poupados)
                {
                    var ddd = l.Where(p => p.Value == item).First();
                    dtSmart.Rows[ddd.Key].Delete();
                }
                dtSmart.AcceptChanges();
            }
            else
            {
                MessageBox.Show("Informe Datas");
            }

            dtSmart.DefaultView.Sort = "Prateleira asc";
            dtSmart = dtSmart.DefaultView.ToTable();
            return dtSmart;
        }

        public List<string> PreverRotativo()
        {
            List<string> lista = new List<string>();
            var hoje = DateTime.Today;
            var ultimodia = new DateTime(DateTime.Today.Year, 12, 31);
            TimeSpan data = ultimodia - hoje;
            decimal dias = (data.Days - (data.Days / 7) * 2) - (30 / 12 * hoje.Month);
            int x = (int)ultimodia.Subtract(hoje).TotalDays;



            ir = new List<RegistroInventario>();
            ir = InventarioRotativo.ObterDados().OrderBy(p => p.Produto).ToList();
            dtSmart = new DataTable();
            dlpt = new DeListParaTable();
            var lt = dlpt.RotativoSmart(ir);
            dtSmart.Merge(lt);


            decimal qtd = ir.Count / dias;

            lblQuantidade.Text = "Para não atrasar,\n Inventariar: " + Math.Ceiling(qtd);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.DataSource = dtSmart;

            //ds = new DataSet();
            //ds = InventarioRotativo.ObterDados(nudInventarioRotativo.Value, hoje);

            foreach (var item in ir)
            {
                lista.Add(item.Produto);
            }
            lista.Sort();
            return lista;
        }
    }
}
