using Estoque.Classes;
using Estoque.DAO;
using Estoque.Entidade;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estoque.Views
{
    public partial class Verificar_OPs_Liberadas : Form
    {
        private List<OrdensDeProducao> Lista;
        private DataGridViewRow row;
        private List<NovasOPs> list;

        public Verificar_OPs_Liberadas()
        {
            InitializeComponent();

            Crud C = new Crud();
            Lista = new List<OrdensDeProducao>();
            Lista.AddRange(C.ListaOrdensDeProducao());
        }

        private void btnTodos_Click(object sender, EventArgs e)
        {
            DeListParaTable dlpt = new DeListParaTable();
            dataGridView1.DataSource = dlpt.OrdensDeProducaoTudo(Lista);
        }

        private void btnSoManutencao_Click(object sender, EventArgs e)
        {
            SoManutencao();
        }

        private void SoManutencao()
        {
            DeListParaTable dlpt = new DeListParaTable();

            Crud c = new Crud();
            var mov = c.ListaMovimento();

            var Lista2 = (from o in Lista
                          join mv in mov
                          on o.NroOP equals Convert.ToInt32(mv.OS) into gj
                          from m in gj.DefaultIfEmpty()
                          where o.NroOP >= Convert.ToInt16(txtOP.Text) & (o.DtCancelamento.Length > 0 | o.DtEncerramento.Length > 0)
                          orderby o.NroOP
                          select new NovasOPs
                          {
                              OPs = o.NroOP,
                              Status = o.StatusOP,
                              Data = o.StatusOP == "Cancelada" ? o.DtCancelamento : o.DtEncerramento,
                              Acao = "Retirar",
                              Movimentacoes = $"" +
                              $"{m?.Codigo ?? String.Empty}, " +
                              $"{m?.Quantidade.ToString() ?? String.Empty}, " +
                              $"{m?.Data.ToString("dd/MM/yyyy") ?? String.Empty}, " +
                              $"{m?.TM}"
                          }).ToList();



            var List = dlpt.OrdensDeProducao(Lista2);



            dataGridView1.DataSource = (DataTable)List[0];

            var ld = Lista.Where(p => p.StatusOP == "Liberada" & p.NroOP >= Convert.ToInt16(txtOP.Text)).Count();

            lblStatistica.Text =
                $"Liberada  = {ld}\n" +
                $"Cancelada = {(int)List[1]}\n" +
                $"Encerrada = {(int)List[2]}\n" +
                $"PDFs = {(int)List[3]}";
            list = (List<NovasOPs>)List[4];
        }

        private void dataGridView1_Click(object sender, DataGridViewCellEventArgs e)
        {
            row = dataGridView1.CurrentRow;

            txtPdfFake.Text = row.Cells[0].Value.ToString();

        }

        private void btnPdfFake_Click(object sender, EventArgs e)
        {
            try
            {
                var destino = $@"Z:\Cid\OPs scaneadas\{txtPdfFake.Text} FakeOP.pdf";
                File.Copy(@"Z:\Cid\OPs scaneadas\ModeloFakeOP\Doc.pdf", destino, false);
                if (File.Exists(destino))
                {
                    lblFake.Text = $"A OP Fake foi gerada em\n{destino}\ncom sucesso!";
                }
                SoManutencao();
                txtPdfFake.Clear();
            }
            catch (Exception)
            {
            }
        }

        private void txtPDFFakeLista_Click(object sender, KeyPressEventArgs e)
        {
            KeyPress(e);
        }

        private void txtPDFNaoFakeLista_Click(object sender, KeyPressEventArgs e)
        {
            KeyPress(e);
        }

        private static void KeyPress(KeyPressEventArgs e)
        {
            if (e.KeyChar == '.' || e.KeyChar == ';' || e.KeyChar == ',' || e.KeyChar == ' ' || e.KeyChar == ':')
            {
                //troca o . pela virgula
                e.KeyChar = ',';
            }

            //aceita apenas números, tecla backspace.
            else if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }


        private void btnPdfFakeLista_Click(object sender, EventArgs e)
        {
            if (txtPDFFakeLista.Text.Length >= 4)
            {

                var naoFake = txtPDFFakeLista.Text.Split(',');
                foreach (var i in naoFake)
                {
                    list.RemoveAll(p => p.OPs == Convert.ToInt32(i));
                }

            }
                foreach (var item in list)
                {
                    var destino = $@"Z:\Cid\OPs scaneadas\{item.OPs} FakeOP.pdf";
                    File.Copy(@"Z:\Cid\OPs scaneadas\ModeloFakeOP\Doc.pdf", destino, true);
                }

                SoManutencao();
        }

        private void btnPdfNaoFakeLista_Click(object sender, EventArgs e)
        {
            if (txtPDFNaoFakeLista.Text.Length >= 4)
            {

                var Fake = txtPDFNaoFakeLista.Text.Split(',');
                

                foreach (var item in Fake)
                {
                    var destino = $@"Z:\Cid\OPs scaneadas\{item} FakeOP.pdf";
                    File.Copy(@"Z:\Cid\OPs scaneadas\ModeloFakeOP\Doc.pdf", destino, true);
                }

                SoManutencao();
            }
        }

        public class NovasOPs
        {
            public int OPs { get; set; }
            public string Status { get; set; }
            public string Data { get; set; }
            public string Acao { get; set; }
            public string Movimentacoes { get; set; }
        }

        private void btnSoLiberadas_Click(object sender, EventArgs e)
        {
            DeListParaTable dlpt = new DeListParaTable();
            dataGridView1.DataSource = dlpt
                .OrdensDeProducaoTudo(Lista
                    .Where(p => p.StatusOP == "Liberada")
                    .OrderBy(p => p.NroOP)
                    .ToList());
        }
    }
}
