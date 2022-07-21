using Estoque.Classes;
using Estoque.DAO;
using Estoque.Entidade;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.ComponentModel.Design;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Estoque.Views
{
    public partial class ForaDeEstoqueForm : Form
    {
        public ForaDeEstoqueForm()
        {
            InitializeComponent();
        }

        private void ForaDeEstoqueForm_Load(object sender, EventArgs e)
        {
            List<ForaDeEstoque3> lista = Obter();
            DataTable table = DeListParaTable.ConvertListToTableGeneric(lista);
            dgvForaDeEstoque.DataSource = table;
        }

        private static List<ForaDeEstoque3> Obter()
        {
            Crud c = new Crud();
            var lista = (from l in c.ListaForaDeEstoque()
                         where l.SaldoQtde > 0
                         orderby l.Data ascending
                         select new ForaDeEstoque3 { Produto = l.Produto, Descricao = l.Descricao, SaldoQtde = l.SaldoQtde, QtdeNf = l.QtdeNf, Data = l.Data, DocFistal = Convert.ToInt32(l.DocFiscal), NomeFantasia = l.NomeFantasia }).ToList();
            return lista;
        }

        private void btnEnviaEmail_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja Enviar esse relatorio por email?", "Enviar Email", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                EnviaEmail(true);
            }
        }

        /// <summary>
        /// True = envia direto
        /// False = analisa se é segunda e envia. mas senao enviou segunda, envia no proximo dia da respectiva semana
        /// </summary>
        /// <param name="b"></param>
        public static void EnviaEmail(bool b)
        {
            DateTime hoje = DateTime.Now;
            Crud crud = new Crud();
            DataBackUP data = crud.ListaDataBackUP().Where(p => p.ID == 2).First();
            DateTime DataUltimoEnvio = data.Data;
            var DiaSemana = data.Data.DayOfWeek;

            TimeSpan TotalDias = hoje - DataUltimoEnvio;

            TimeSpan ts = TimeSpan.FromDays(7);

            if (StringConexao.maquina != "Estoque")
            {
                return;
            }

            if (TotalDias > ts | b == true)
            {
                var lista = Obter();
                string path = LancarNoExcell.InventariarForaDeEstoqueComSaldo(lista);
                bool status = OutLook.ForaDeEstoqueComSaldo(path, lista);

                if (status)
                {
                    data.Data = hoje;
                    crud.AlteraDataBackUP(data);
                }
            }

        }
    }
}
