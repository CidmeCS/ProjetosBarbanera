using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Estoque.Classes;
using Estoque.Classes.ERP;
using Estoque.DAO;
using Estoque.Entidade;
using static Estoque.Classes.SaldoMensal;

namespace Estoque.Views
{
    public partial class SaldoMensal : Form
    {
        internal List<Classes.SaldoMensal.ListaSaldoMensal> ListaCustoMedio { get; private set; }
        public string PathSaldo { get; private set; }

        public SaldoMensal()
        {
            InitializeComponent();
        }

        private void btnSaldoMensal_Click(object sender, EventArgs e)
        {
            PathSaldo = Classes.SaldoMensal.LancarEXCEL();
        }

        private void brnVerificaPPs_Click(object sender, EventArgs e)
        {
            ListaCustoMedio = Classes.SaldoMensal.ListarGrupo11NaoValorizado();
            ListaCustoMedio.ForEach(p => p.CustoMedio = 10);
            //var l = DeListParaTable.ConvertListToDataTable(ListaCustoMedio);
            var l = DeListParaTable.ConvertListToTableGeneric<ListaSaldoMensal>(ListaCustoMedio);
            dataGridView1.DataSource = l;
            dataGridView1.EditMode = DataGridViewEditMode.EditOnKeystroke;
            lblStatusBotao.Text = "brnVerificaPPs_Click";
        }

        private void btnAplicaPPs_Click(object sender, EventArgs e)
        {
            if (lblStatusBotao.Text == "brnVerificaPPs_Click")
            {
                if (MessageBox.Show("O Esses dados já foram Inventariados no ERP?", "ATENÇÃO", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    List<string> lista = new List<string>();
                    Crud c = new Crud();
                    var lines = dataGridView1.Rows;
                    foreach (DataGridViewRow item in lines)
                    {
                        if (item.Cells[0].Value != null)
                        {
                            if (item.Cells["CustoMedio"].Value.ToString().Trim().Replace(",", ".") == "0")
                            {
                                MessageBox.Show("Não pode ter CustoMédio  == 0", "CustoMédio Zerado");
                                lista.Clear();
                                return;
                            }
                            lista.Add(item.Cells["Codigo"].Value.ToString().Trim() + "\t" + item.Cells["CustoMedio"].Value.ToString().Trim().Replace(",", "."));
                        }
                    }
                    c.AlteraItemsDeEstoque(lista);
                    lblStatusBotao.Text = "btnAplicaPPs_Click";
                    MessageBox.Show("Novos Custo Médios de PPs aplicados no Banco de Dados", "Status OK");
                }
            }

        }

        private void btnAplicarNoERP_Click(object sender, EventArgs e)
        {
            if (ListaCustoMedio == null)
            {
                return;
            }
            ControllerERP_Pronto.ValorizarCustoMedio(ListaCustoMedio);
            MessageBox.Show("Valorização no ERP Pronto OK", "FIM");
        }

        private void btnEnviarEmailPietro_Click(object sender, EventArgs e)
        {
            OutLook.EmailSaldo(PathSaldo);
        }

        private void btnVerificaGrupo10SemItemSpedouPosiFiscal_Click(object sender, EventArgs e)
        {
            Crud c = new Crud();
            var lsm = c.ListaItensDeEstoque().Where(p => p.Grupo == "10000000").ToList();


            var ItemSped = (from l in lsm
                            where (l.Grupo == "10000000" & l.TipoItemSped != "Produto Acabado")
                            select l).ToList();

            var PosicaoFiscal = (from l in lsm
                                 where l.Grupo == "10000000" & l.PosicaoFiscal.Length < 8
                                 select l).ToList();
            List<ItensDeEstoque> li = new List<ItensDeEstoque>();
            li.AddRange(ItemSped);
            li.AddRange(PosicaoFiscal);
            dataGridView1.DataSource = li.ToList();

            if (ItemSped.Count > 0)
            {
                OutLook.ErroItemSped(ItemSped, "vendas@barbanera.com.br", "Produto Acabado");
            }
            else
            {
                MessageBox.Show("Sem item Sped para reparar");
            }


            if (PosicaoFiscal.Count > 0)
            {
                OutLook.ErroPosicaoFiscal(PosicaoFiscal, "vendas@Barbanera.com.br");
            }
            else
            {
                MessageBox.Show("Sem Posicao Fiscal para reparar");
            }
            dataGridView1.DataSource = li.ToList();
        }

        private void btnVerificaG12ErroPfiscal_Click(object sender, EventArgs e)
        {
            Crud c = new Crud();
            var lsm = c.ListaItensDeEstoque().Where(p => p.Grupo == "12000000" | p.Grupo == "15000000" | p.Grupo == "16000000" | p.Grupo == "17000000" | p.Grupo == "20000000").ToList();

            var PosicaoFiscal = (from l in lsm
                                 where l.PosicaoFiscal.Length < 8
                                 select l).ToList();

            dataGridView1.DataSource = PosicaoFiscal.ToList();

            if (PosicaoFiscal.Count > 0)
            {
                OutLook.ErroPosicaoFiscal(PosicaoFiscal, "compras@Barbanera.com.br");
            }
            else
            {
                MessageBox.Show("Sem Posicao Fiscal para reparar");
            }

        }

        private void btnVerificaGrupoRelItemSPED_Click(object sender, EventArgs e)
        {
            Crud c = new Crud();
            var lsm = c.ListaItensDeEstoque();

            var _12 = lsm.Where(p => p.Grupo == "12000000").ToList();
            var MP = (from l in _12
                      where (l.TipoItemSped != "Matéria-Prima")
                      select l).ToList();
            MP.ForEach(p => p.TipoItemSped = "Matéria-Prima");

            var _15 = lsm.Where(p => p.Grupo == "15000000").ToList();
            var PI = (from l in _15
                      where (l.TipoItemSped != "Produto Intermediário")
                      select l).ToList();
            PI.ForEach(p => p.TipoItemSped = "Produto Intermediário");

            var _16 = lsm.Where(p => p.Grupo == "16000000").ToList();
            var MUC = (from l in _16
                       where (l.TipoItemSped != "Material de Uso e Consumo")
                       select l).ToList();
            MUC.ForEach(p => p.TipoItemSped = "Material de Uso e Consumo");

            var _17 = lsm.Where(p => p.Grupo == "17000000").ToList();
            var SP = (from l in _17
                      where (l.TipoItemSped != "Subproduto")
                      select l).ToList();
            SP.ForEach(p => p.TipoItemSped = "Subproduto");

            var _20 = lsm.Where(p => p.Grupo == "20000000").ToList();
            var OI = (from l in _20
                      where (l.TipoItemSped != "Outros insumos")
                      select l).ToList();
            OI.ForEach(p => p.TipoItemSped = "Outros insumos");

            List<ItensDeEstoque> li = new List<ItensDeEstoque>();
            li.AddRange(MP);
            li.AddRange(PI);
            li.AddRange(MUC);
            li.AddRange(SP);
            li.AddRange(OI);
            var l2 = (from l in li orderby l.Codigo select new { Codigo = l.Codigo, Grupo = l.Grupo, Descricao = l.Descricao, TipoItemSped = l.TipoItemSped }).ToList();
            dataGridView1.DataSource = l2;

            if (l2.Count > 0)
            {
                if (MessageBox.Show($"Temos, {l2.Count} itens para incluir o ItemSped. Deseja Alterar no ERP?", "Alteração no ERP", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ControllerERP_Pronto.AplicaTipoItemSped(li);
                }
            }
            else
            {
                MessageBox.Show("Sem item Sped para reparar");
            }


            //if (PosicaoFiscal.Count > 0)
            //{
            //    OutLook.ErroPosicaoFiscal(PosicaoFiscal, "compras@Barbanera.com.br");
            //}
            //else
            //{
            //    MessageBox.Show("Sem Posicao Fiscal para reparar");
            //}
            //li.Clear();
            //dataGridView1.DataSource = li.ToList();

        }

        private void btnVerificaGrupo11_Click(object sender, EventArgs e)
        {
            Crud c = new Crud();
            var lsm = c.ListaItensDeEstoque().Where(p => p.Grupo == "11000000").ToList();


            var ItemSped = (from l in lsm
                            where (l.Grupo == "11000000" & l.TipoItemSped != "Produto em Processo")
                            select l).ToList();

            var PosicaoFiscal = (from l in lsm
                                 where l.Grupo == "11000000" & l.PosicaoFiscal.Length < 8
                                 select l).ToList();
            List<ItensDeEstoque> li = new List<ItensDeEstoque>();
            li.AddRange(ItemSped);
            li.AddRange(PosicaoFiscal);
            dataGridView1.DataSource = li.ToList();

            if (ItemSped.Count > 0)
            {
                OutLook.ErroItemSped(ItemSped, "pcp@barbanera.com.br", "Produto em Processo");
            }
            else
            {
                MessageBox.Show("Sem item Sped para reparar");
            }


            if (PosicaoFiscal.Count > 0)
            {
                OutLook.ErroPosicaoFiscal(PosicaoFiscal, "pcp@Barbanera.com.br");
            }
            else
            {
                MessageBox.Show("Sem Posicao Fiscal para reparar");
            }
        }

        private void btnGruposEstranhos_Click(object sender, EventArgs e)
        {
            if (btnGruposEstranhos.Text == "Grupos Estranhos")
            {
                Crud c = new Crud();
                var lsm = c.ListaItensDeEstoque().Where(p => p.Grupo == "0").ToList();
                var lsm2 = (from l in lsm select new GruposEstranhos { Codigo = l.Codigo, Descricao = l.Descricao, Grupo = l.Grupo, TipoItemSped = l.TipoItemSped, Quantidade = l.SaldoFisico, Prateleira = l.Prateleira }).ToList();
                var ge = DeListParaTable.ConvertListToTableGeneric<GruposEstranhos>(lsm2);
                dataGridView1.DataSource = ge;
                dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
                btnGruposEstranhos.Text = "Aplicar Alterações 'GruposEstranhos'";
            }
            else
            {

                Dictionary<string, string> d = new Dictionary<string, string>();
                foreach (DataGridViewRow item in dataGridView1.Rows)
                {
                    if (item.Cells["Codigo"].Value == null)
                    {
                        break;
                    }
                    var cod = item.Cells["Codigo"].Value.ToString().ToUpper();
                    var grp = item.Cells["Grupo"].Value.ToString().ToUpper();
                    if (grp != "12000000" & grp != "15000000" & grp != "16000000" & grp != "17000000" & grp != "20000000")
                    {
                        MessageBox.Show($"GRUPO ANOTADO {grp} DIFERENTE DE 12,15,16,17,E 20. COM 8 CARACTERES ");
                        return;
                    }
                    d.Add(cod, grp);

                }
                ControllerERP_Pronto.AlteraGrupo(d);
                btnGruposEstranhos.Text = "Grupos Estranhos";
                dataGridView1.DataSource = null;
            }
        }
    }
}
