using Estoque.Classes;
using Estoque.Classes.ERP;
using Estoque.DAO;
using Estoque.Entidade;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Estoque.Classes.Inventario;

namespace Estoque.Views
{
    public partial class Inventarios : Form
    {
        public static DateTime inicio;
        public static DateTime fim;
        private static int qtd;
        public static HashSet<string> person = new HashSet<string>();
        StringBuilder sb;
        internal static object ppp;
        public static List<string> cod = new List<string>();
        public static List<string> Item = new List<string>();
        DataSet ds, dsa;
        List<RegistroInventario> ri = new List<RegistroInventario>();
        DataTable dt = null;
        DataGridViewRow row;
        List<SaldoShort> l = null, s = new List<SaldoShort>(), m = new List<SaldoShort>();
        private List<Entidade.RegistroInventario> lri;
        List<ClassParaExcell> cpe;
        List<DateTime> periodos;
        EntradaInventario ei;
        private object[] junto;
        InventarioDepositosDeTerceiro iddt;
        private List<ForaDeEstoque2> lista;
        public List<RegistroInventario> ListaInventarioDiario { get; private set; }
        public List<RegistroInventario2> ListaInventarioDiario2 { get; private set; }
        public List<object> LimparPrateleira { get; private set; }
        public DataRow[] dtx { get; private set; }
        internal List<SaldoSucata> ListaSucata { get; private set; }
        public DataTable lir { get; private set; }
        PreverRotativoSmart prs;
        private List<DataRow> dtb2;
        private Inventario iv;
        private DataTable table;

        public Inventarios()
        {
            InitializeComponent();
            lblUltimoInventario.Text = Crud.UltimoInventario();
            ei = new EntradaInventario(txtEntradaInventario, l, s, dataGridView1, m, cbGrupo, cbPPs, lblProximo, lblCarregado);
            person.Clear();
        }
        public void dtpInicio_ValueChanged(object sender, EventArgs e)
        {
            inicio = dtpInicio.Value;
            qtd = VerificaFeriados.Start(inicio.ToShortDateString(), fim.ToShortDateString());
            lblqtd.Text = "De " + inicio.ToString("dd/MM/yyyy") + " a " + fim.ToString("dd/MM/yyyy") + " = " + qtd.ToString() + " Dias";
        }

        public void dtpFim_ValueChanged(object sender, EventArgs e)
        {
            fim = dtpFim.Value;
            qtd = VerificaFeriados.Start(inicio.ToShortDateString(), fim.ToShortDateString());
            lblqtd.Text = "De " + inicio.ToString("dd/MM/yyyy") + " a " + fim.ToString("dd/MM/yyyy") + " = " + qtd.ToString() + " Dias";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox2.Text = CarregarTexBox.Start(textBox1.Text);
        }

        private void myTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 13)
            {
                if (textBox2.TextLength > 0)
                {
                    person.Add(textBox1.Text);

                    sb = new StringBuilder();
                    foreach (var item in person)
                    {
                        if (textBox2.TextLength > 0)
                        {
                            sb.AppendLine(item);
                        }
                    }
                    richTextBox1.Text = sb.ToString();
                    cod.Add(textBox1.Text);
                    Item.Add(textBox2.Text);
                }
            }
        }

        private void btnPreverInventarioMovimentos(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            btnBotao.Text = btn.Text;
            cpe = new List<ClassParaExcell>();
            if (qtd > 0)
            {
                cpe = Inventariar(inicio, fim);
                DataTable x = new DataTable();
                List<string> ls = new List<string> { "B-1837", "B-2601", "B-2602", "B-2603", "B-2604", "B-2868" };
                foreach (var c in ls)
                {
                    cpe.RemoveAll(p => p.Codigo == c);
                }
                x = ConverterListClassParaExcellEmTablel.Start(cpe);
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                Parallel.Invoke(() => dataGridView1.DataSource = x);

                lblPrevRotativo.Text = "Previsao de " + x.Rows.Count.ToString() + " Linhas";
            }
            else
            {
                MessageBox.Show("Informe Datas");

            }

        }

        private void btnGerarInventarioMovimentos(object sender, EventArgs e)
        {

            var btn = (Button)sender;
            btnBotao.Text = btn.Text;
            if (!(cpe is null))
            {
                LancarNoExcell.InventarioMovimentos(cpe, lblqtd.Text + ", " + lblPrevRotativo.Text.Remove(0, 11));
                LancarNoExcell.AcabadosParaExpedicao(cpe);
                LancarNoExcell.SemiAcabadosParaFornecedores(cpe);
            }
            else
            {
                MessageBox.Show("Carregue o Passo \n\n'1- Prever Inventario na Tela'", "");
            }
        }

        private void btnInventariarPersonalizado_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            btnBotao.Text = btn.Text;
            InventarioPersonalizado ip = new InventarioPersonalizado(dataGridView1);
            var d = richTextBox1.Lines.Where(p => p.Length > 0).ToList();
            var f = d.Take(d.Count).ToList();
            ri = null;
            ri = new List<RegistroInventario>();
            ri = ip.Start(f);
            DeListParaTable dlpt = new DeListParaTable();
            var t = dlpt.InventarioPersonalizado(ri);
            dataGridView1.DataSource = t;
            textBox1.Clear();
            textBox2.Clear();
            richTextBox1.Clear();
            person.Clear();


        }
        private void btnGerarInventarioPersonalizadoExcel_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            btnBotao.Text = btn.Text;
            if (ri != null)
            {
                LancarNoExcell.InventarioPersonalizado(ri);
            }
            else
            {
                MessageBox.Show("Nao foi carregado dados", "Carregar Dados");
            }
        }

        private void btnInventarioRotativo_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            btnBotao.Text = btn.Text;
            var i = nudInventarioRotativo.Value;
            if (MessageBox.Show($"Deseja inventariar apenas {i} Itens?", "Inventario Rotativo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var hoje = DateTime.Today;
                ri = new List<RegistroInventario>();
                ri = Classes.InventarioRotativo.ObterDados();
                Classes.InventarioRotativo.Start(ri.Take((int)nudInventarioRotativo.Value).ToList());
            }
        }

        private void PreverRotativo(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            btnBotao.Text = btn.Text;
            PreverRotativoSmart pr = new PreverRotativoSmart(DateTime.Today, DateTime.Today, lblRotativo, dataGridView1);
            pr.PreverRotativo();
        }

        private void PeverZeradosSemPrateleira(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            btnBotao.Text = btn.Text;
            InventarioRotativo ir = new InventarioRotativo();
            lri = new List<RegistroInventario>();
            lri = ir.ObterDadosZeradosSemPrateleira();

            //join i in itens on s.Produto equals i.Codigo
            Crud c = new Crud();
            var itens = c.ListaItensDeEstoque();
            var newLri = (from l in lri
                          join i in itens on l.Produto equals i.Codigo
                          select (new
                          {
                              Produto = l.Produto,
                              Descricao = l.Descricao,
                              Prateleira = l.Prateleira,
                              Unid = l.Unid,
                              SaldoAtual = l.SaldoAtual,
                              ValorConvertido = l.ValorConvertido,
                              Inventario = l.Inventario,
                              DiaInventario = l.DiaInventario,
                              DiasMov = l.DiasMov,
                              Acerto = l.Acerto,
                              DataCadastro = i.ItemCadastradoEm
                          }));

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.DataSource = newLri.ToList();
            lblQuantidadeZerados.Text = lri.Count.ToString() + " Linhas - Saldos Zerados e\n Sem Prateleiras";
        }

        private void btnAplicarZerados_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            btnBotao.Text = btn.Text;
            if (btnAplicarZerados.Text == "Aplicar")
            {
                var ri = RegistrarInventario.AplicarZerados(lri);
                dataGridView1.DataSource = ri;
                btnAplicarZerados.Text = "2- Aplicar Zerados";
                goto IncluirPeriodo;
            }
            else if (MessageBox.Show("Deseja Registrar o Inventario?", "Registar Inventario", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                btnAplicarZerados.Text = "Aplicar";
            }
        IncluirPeriodo:;
        }


        private void PreverRotativoSmart(object sender, EventArgs e)
        {
            if (ri == null | ri.Count > 0)
            {
                goto A;
            }
            var btn = (Button)sender;
            btnBotao.Text = btn.Text;
            prs = new PreverRotativoSmart(inicio, fim, lblQuantidadeSmart, dataGridView1);
            dt = new DataTable();
            dt = prs.Start(qtd);

            try
            {
                lblRotativoSmart.Text = $"" +
                    $"Itens: {InventarioRotativo.saldos.Count}\n" +
                    $"Inventariados {InventarioRotativo.regInvt.Count}\n" +
                    $"Inventariar Movimentos {prs.InventarioMovimento.Count}\n" +
                    $"Falta Inventariar {prs.rotativo.Count}\n" +
                    $"Inventario Smart {prs.@is.Count}\n" +
                    $"Poupados {prs.poupados.Count}";
            }
            catch (Exception)
            {
            }

            //

            ri = new List<RegistroInventario>();
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                ri.Add(new RegistroInventario
                {
                    _Indice = i++,
                    Produto = row["Produto"].ToString(),
                    Descricao = row["Descricao"].ToString(),
                    Prateleira = row["Prateleira"].ToString(),
                    Unid = row["Unid: SaldoAtual"].ToString(),
                    ValorConvertido = Convert.ToDouble(row["ValorConvertido"]),

                });
            }
        A:
            List<RegistroInventario> riqtd = new List<RegistroInventario>();
            riqtd = ri.Take((int)nudInvRotSmart.Value).ToList();
            dataGridView1.DataSource = riqtd;
        }

        private void GerarInventarioSmart(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            btnBotao.Text = btn.Text;
            if (nudInvRotSmart.Value > 0 & dt != null)
            {
                LancarNoExcell.InventarioSmart(nudInvRotSmart.Value, dt, lblRotativoSmart, lblQuantidadeSmart, dtpInicio, dtpFim);
            }
            else
            {
                MessageBox.Show("A previsao tem que ser carregada e a quantidade apontada", "ATENÇÃO");
            }
        }

        private void btnCarregarExcel_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            btnBotao.Text = btn.Text;
            var ds = RegistrarInventario.CarregaDataSet();
            dataGridView1.DataSource = ds;
            for (int i = 0; i < ds.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells[5].Value = dataGridView1.Rows[i].Cells[5].Value.ToString().Replace(".", ",");
            }
            lblLinhasCarregadas.Text = $"Linhas {ds.Rows.Count} carregadas";
        }

        private void btnRegistrarInventario_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            btnBotao.Text = btn.Text;
            if (qtd <= 0)
            {
                MessageBox.Show("Incluir Periodo");
                return;
            }
            if (btnRegistrarInventario.Text == "Aplicar")
            {
                RegistrarInventario ri = new RegistrarInventario();
                var lir = ri.AplicarRegistros(dataGridView1, dtpInicio, dtpFim);
                dataGridView1.DataSource = null;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.DataSource = lir;
                btnRegistrarInventario.Text = "2- Registrar Inventario";
                lblLinhasCarregadas.Text = $"{lir.Rows.Count} linhas registradas";
                var acertos = VerificaSeHaAcertos.VerificarObter(dataGridView1);
                if (acertos.Count > 0)
                {
                    if (MessageBox.Show("Deseja Registrar os Acertos no ERP?", "Registar Inventario no ERP", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        ControllerERP_Pronto.APlicarAcertos(acertos);
                    }
                }
                return;
            }
            if (MessageBox.Show("Deseja Registrar o Inventario?", "Registar Inventario", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                btnRegistrarInventario.Text = "Aplicar";
            }
        }

        private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                row = dataGridView1.CurrentRow;

                var x = e.ColumnIndex;
                var y = e.RowIndex;

                DataGridView d = new DataGridView();
                d = (DataGridView)sender;
                var yy = d.EditingControl.Text;
                dataGridView1.EditingControl.Text = yy.Replace(".", ",");
            }
            catch (Exception y)

            {

            }
        }

        private void btnPesquisarInventario_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            btnBotao.Text = btn.Text;
            var reg = RegistrarInventario.Pesquisar(cbPesquisaInventarios, txtPesquisarInventario);
            DeListParaTable dlpt = new DeListParaTable();
            var table = dlpt.Pesquisa(reg);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.DataSource = table;
            lblLinhas.Text = "Linhas Retornadas " + reg.Count();
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            btnBotao.Text = btn.Text;
            RegistrarInventario.RemoverRegistroInventario(row);
            Crud c = new Crud();
            var id = Convert.ToInt32(row.Cells[0].Value);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.DataSource = c.ListaRegistroInventario(id - 8, 16);
            //btnPesquisarInventario.PerformClick();
        }

        //private void btnListarAcabados_Click(object sender, EventArgs e)
        //{
        //    var x = Inventario.ListarAcabados();
        //    dataGridView1.DataSource = ((DataSet)x[0]).Tables[0];
        //    lblCarregado.Text = ((string)x[1]);
        //}



        private void btnPCPInvestigar_Click(object sender, EventArgs e)
        {
            //var btn = (Button)sender;
            //btnBotao.Text = btn.Text;
            //var ds = PCPInvestigar.Acabados();
            //dataGridView1.DataSource = ds.Tables[0];

        }

        private void cbGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbGrupo.Text == "11000000-SemiAcabados")
            {
                cbPPs.Enabled = true;
            }
            else
            {
                cbPPs.Text = "";
                cbPPs.Enabled = false;
            }
        }

        private void btnInventariarR(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            btnBotao.Text = btn.Text;
            var cb = cbGrupo.Text.Split('-').First().ToString();
            var x = Inventario.InventariarPorGrupo(cbPPs.Text, cb);
            dataGridView1.DataSource = null;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.DataSource = ((DataSet)x[0]).Tables[0];
            lblInventarioSemiAcabado.Text = ((StringBuilder)x[1]).ToString();
            if (((DataSet)x[0]).Tables[0].Rows.Count > 0)
            {
                lblProximo.Text = ((DataSet)x[0]).Tables[0].Rows[0].ItemArray[2].ToString() + " > " + ((DataSet)x[0]).Tables[0].Rows[0].ItemArray[0].ToString();
            }
        }

        private void btnListarPrateleiraComSaldoZeroMinimoZero_Click(object sender, EventArgs e)
        {
            LimparPrateleira = null;
            var btn = (Button)sender;
            btnBotao.Text = btn.Text;
            LimparPrateleira = Inventario.LimparPrateleiraComSaldoZeroMinimoZero();
            dataGridView1.DataSource = ((DataSet)LimparPrateleira[0]).Tables[0];
            lblLimparPrateleiraComSaldoZeroMinimoZero.Text = LimparPrateleira[1].ToString();
            btnListar.Enabled = true;
        }

        private void btnLimparPrateleira_Click(object sender, EventArgs e)
        {
            List<string> cod = new List<string>();
            DataSet ds = new DataSet();
            ds = (DataSet)LimparPrateleira[0];
            dtx = null;
            dtx = ds.Tables[0].Select("DiasSemMovimento > 70 ");

            try
            {
                DataTable dt1 = dtx.CopyToDataTable();

                var query = from contact in dt1.AsEnumerable()
                            orderby contact.Field<string>("Prateleira")
                            select contact;

                var dtb = query.CopyToDataTable();
                dtb2 = query.ToList();

                dataGridView1.DataSource = dtb;
                btnListar.Enabled = false;
                btnLimpar.Enabled = true;
                if (MessageBox.Show("Deseja Imprimir?", "Impressão", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    LancarNoExcell.ListaLimparPratelira(dtb2);
                }
            }
            catch (InvalidOperationException)
            {
            }

        }
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Deseja Excluir no Sistema automatico?", "Excluir NO Sistema Automatico", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    List<string> l = new List<string>();
                    foreach (var item in dtb2)
                    {
                        l.Add(item[0].ToString());
                    }
                    ControllerERP_Pronto.LimparPrateleira(l);
                    MessageBox.Show("Prateliras Limpas", "Tarefa Finalizada");

                    foreach (DataRow item in dtx)
                    {
                        cod.Add(item.ItemArray[0].ToString());
                    }
                    Crud c = new Crud();
                    c.AlterarPrateleiraItensDeEstoque(cod);
                    c.AlterarPrateleiraSaldo(cod);
                    List<Etiqueta> et = new List<Etiqueta>();
                    foreach (var cd in cod)
                    {
                        var etq = c.ListarEtiqueta().Where(p => p.Codigo == cd).First();
                        et.Add(etq);
                    }
                    c.DeletarEtiquetas(et);
                    MessageBox.Show("As prateleiras e as etiquetas estão limpas!!", "Patreleiras Limpas");
                    btnLimpar.Enabled = false;
                }

            }
            catch (Exception)
            {

            }

        }



        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            btnBotao.Text = btn.Text;
            Crud c = new Crud();
            var saldo = c.ListaSaldoDeTerceiro();
            var dpst = c.ListaDepositoDeTerceiro();
            List<SaldoDeTerceiro> junto1 = new List<SaldoDeTerceiro>();

            var q = saldo.Where(x => x.GetProperyValue(cbbPesquisar.Text).ToString().Contains(txtPesquisar.Text));

            junto1 = (from s in q
                      join d in dpst
                      on s.DEPOSITO equals d.Deposito.ToString()
                      where s.Descricao.Contains(txtPesquisar.Text)
                      orderby s.Prateleira
                      select new SaldoDeTerceiro
                      {
                          Produto = s.Produto,
                          Descricao = s.Descricao,
                          Prateleira = s.Prateleira,
                          Unid = s.Unid,
                          SaldoAtual = s.SaldoAtual,
                          DeTerceiros = s.DeTerceiros,
                          DEPOSITO = s.DEPOSITO + " " + d.Nome
                      }).ToList();

            dataGridView1.DataSource = DeListParaTable.ConvertListToTableGeneric<SaldoDeTerceiro>(junto1);

            List<string> colunas = new List<string>() { "Produto", "Descricao", "Prateleira", "Unid", "SaldoAtual", "DeTerceiros", "DEPOSITO" };
            List<DataGridViewColumn> lg = new List<DataGridViewColumn>();

            foreach (DataGridViewColumn item in dataGridView1.Columns)
            {
                if (colunas.Contains(item.Name))
                {
                    continue;
                }
                lg.Add(item);
            }
            foreach (var item in lg)
            {
                dataGridView1.Columns.Remove(item);
            }
        }

        private void btnPreverInventarioDepositosDeTerceiro_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            btnBotao.Text = btn.Text;
            PreverInventarioDepositosDeTerceiro();
        }

        private void PreverInventarioDepositosDeTerceiro()
        {
            iddt = new InventarioDepositosDeTerceiro();
            junto = iddt.FiltandoDados();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.DataSource = junto[0];
        }

        private void btnGerarInventarioDepositodeTerceiroExcel_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            btnBotao.Text = btn.Text;
            LancarNoExcell.InventarioDepositosDeTerceiro(junto[1], false);

        }

        private void btnRegistrarIventarioDepositosDeTerceiros_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            btnBotao.Text = btn.Text;
            DataTable registrosEfetivados = RegistrarInventario.RegistrarIventarioDepositosDeTerceiros(dataGridView1);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.DataSource = registrosEfetivados;
        }

        private void btnInventariarForaDeEstoqueComSaldo_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            btnBotao.Text = btn.Text;
            lista = new List<ForaDeEstoque2>();
            lista = Inventario.InventariarForaDeEstoqueComSaldo();
            DeListParaTable dlpt = new DeListParaTable();
            var dt = dlpt.InventariarForaDeEstoqueComSaldo(lista);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.DataSource = dt;
        }

        private void lblProximo_Click(object sender, EventArgs e)
        {
            var jp = new char[] { '>', '\r', '\n' };
            var ff = lblProximo.Text.Split(jp);
            var cod = ff[1].Trim();
            try
            {
                var jj = m.FindIndex(p => p.Produto.Equals(cod));
                m.RemoveAt(jj);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                ei.Carregando();
            }

            var cb = cbGrupo.Text.Split('-').First().ToString();
            var prod = cbPPs.Text;

            ei.Remove1(cb, prod);
        }

        private void btnCarregarNoExcelInventarioSaldosDeTerceiro_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            btnBotao.Text = btn.Text;
            btnCarregarInventario.PerformClick();
        }

        private void btnPesquisarRegistroSaldoDeTerceiro_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            btnBotao.Text = btn.Text;
            var reg = RegistrarInventario.PesquisarInventarioSaldoDeTerceiro(cbbInventarioSaldosDeTerceiro, txtInventarioSaldosDeTerceiro);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.DataSource = reg;
            //lbl???.Text = "Linhas Retornadas " + reg.Count();
        }

        private void btnDeletarRegistroInventarioSaldodeTerceiro_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            btnBotao.Text = btn.Text;
            RegistrarInventario.RemoverRegistroInventarioSaldoDeTerceiro(row);
            Crud c = new Crud();
            var id = Convert.ToInt32(row.Cells[0].Value);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.DataSource = c.ListaRegistroInventarioSaldoDeTerceiro(id - 8, 16);
        }

        private void btnGerarInventarioForaDeEstoqueComSaldoExcel_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            btnBotao.Text = btn.Text;
            LancarNoExcell.InventariarForaDeEstoqueComSaldo(lista);
        }

        private void btnInventariarDeTerceiroComSaldo_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            btnBotao.Text = btn.Text;
            lista = new List<ForaDeEstoque2>();
            lista = Inventario.InventariarDeTerceiroComSaldo();
            DeListParaTable dlpt = new DeListParaTable();
            var dt = dlpt.InventariarForaDeEstoqueComSaldo(lista);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.DataSource = dt;
        }

        private void frmInventarios_Load(object sender, EventArgs e)
        {
            var g = "";
            List<string> l = new List<string>();
            foreach (Control item in Controls)
            {
                if (item.Text.StartsWith("0"))
                {
                    l.Add(item.Text);
                }
            }
            l.Sort();
            foreach (var item in l)
            {
                listView1.Items.Add(item);
            }

        }


        private void btnGerarInventarioForaEstoqueComSaldoExcel_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            btnBotao.Text = btn.Text;
            LancarNoExcell.InventariarDeTerceiroComSaldo(lista);
        }


        private void txtEntradaInventario_KeyDown(object sender, KeyEventArgs e)
        {
            ei.Start(e);
        }

        private void btnLimparPrateleiras_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            btnBotao.Text = btn.Text;
            MudancasNoERP lpt = new MudancasNoERP(dataGridView1);
            lpt.ZerarPrateleiraNoERP();
        }

        private void btnPreverInventarioDeSucata_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            btnBotao.Text = btn.Text;
            ListaSucata = new List<SaldoSucata>();
            ListaSucata = Inventario.InventariarSucatas().ToList();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.DataSource = ListaSucata;
        }

        private void btnGerarInventarioDeSucata_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            btnBotao.Text = btn.Text;
            LancarNoExcell.InventariarSucata(ListaSucata);
        }

        private void btnRegistrarInventarioDeSucata_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            btnBotao.Text = btn.Text;
            if (ListaSucata.Count() <= 0)
            {
                MessageBox.Show("Favor Gerar a lista primeiro");
                return;
            }
            if (btnRegistrarInventarioDeSucata.Text == "Aplicar")
            {
                RegistrarInventario ri = new RegistrarInventario();

                lir = ri.AplicarRegistrosSucatas(dataGridView1);
                dataGridView1.DataSource = null;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.DataSource = lir;
                btnRegistrarInventarioDeSucata.Text = "3-Registrar Inventario De Sucata";

                lblLinhasCarregadas.Text = $"{lir.Rows.Count} linhas registradas";

                return;
            }
            else if (MessageBox.Show("Deseja Registrar o Inventario?", "Registar Inventario", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                btnRegistrarInventarioDeSucata.Text = "Aplicar";
            }
        }

        private void btnLancarAcertosNoERP_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            btnBotao.Text = btn.Text;
            MudancasNoERP lpt = new MudancasNoERP();
            lpt.AcertoSucata();
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            btnBotao.Text = btn.Text;
            PreverInventarioDepositosDeTerceiro();
            LancarNoExcell.InventarioDepositosDeTerceiro(junto[1], true);
        }

        private void btnLimparLinha_Click(object sender, EventArgs e)
        {
            try
            {
                var dc = dataGridView1.CurrentRow;
                dataGridView1.Rows.Remove(dc);
                int dv = dc.Index;
                dtb2.RemoveAt(dv);
            }
            catch (Exception ex)
            {
            }
        }

        private void btnPorPrateleiraListar_Click(object sender, EventArgs e)
        {
            var tbl = BuscaPorPrateleira();
            lblLinhas2.Text = tbl.Rows.Count.ToString();
            dataGridView1.DataSource = tbl;

        }

        private void btnListarPrateleiras_Click(object sender, EventArgs e)
        {
            Crud c = new Crud();

            var lista = (from l in c.ListaSaldo()
                         where l.Prateleira != ""
                         orderby l.Prateleira
                         select new { l.Prateleira, }).GroupBy(p => p.Prateleira).ToList();

            dataGridView1.DataSource = lista;
        }

        private void btnPorPrateleiraExcel_Click(object sender, EventArgs e)
        {
            LancarNoExcell.InventarioPorPrateleira(table.Rows);
        }

        public DataTable BuscaPorPrateleira()
        {
            iv = new Inventario();
            Crud c = new Crud();
            var valor = txtPrateleira.Text;
            var lista3 =  (from l in iv.BuscarPorPrateleira(valor)
                         select new { 
                             l.Produto, l.Descricao, 
                             Prateleira = l.Livre17 > 0M ? (l.Prateleira + " C-" + l.Livre17):l.Prateleira, 
                             l.Unid, l.SaldoAtual,  
                             Convertido = Classes.Conversor.GetConvertido(c.ListarEtiqueta().Where(p=>p.Codigo == l.Produto).FirstOrDefault()).Convertido}).ToList();

            table = DeListParaTable.ConvertListToTableGeneric(lista3);
            return table;

        }

        private void txtEntradaInventario_Click(object sender, EventArgs e)
        {
            ei.Carregando();
        }

        private void btnPreverInventarioDiario_Click(object sender, EventArgs e)
        {
            if (qtd > 0)
            {
                InventarioDiario id = new InventarioDiario(dtpInicio, dtpFim, cbOperadorInclusao);
                ListaInventarioDiario2 = id.Start();

                DeListParaTable dlpt = new DeListParaTable();
                var t = dlpt.InventarioDiario(ListaInventarioDiario2);

                lblInventarioDiario.Text = "Linhas Retornadas: " + ListaInventarioDiario2.Count;
                dataGridView1.DataSource = t;
            }

        }
        private void btnGerarInventarioDiarioExcel_Click(object sender, EventArgs e)
        {
            if (qtd > 0)
            {
                LancarNoExcell.InventarioDiario(ListaInventarioDiario2, lblqtd.Text);
            }
        }

    }
}
