using ImportExportERP.Classes;
using ImportExportERP.Data;
using ImportExportERP.Entidade;
using ImportExportERP.Properties;
using ListarJanelasAbertas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using WindowsInput;
using WindowsInput.Native;
using DateTime = System.DateTime;
using WinForms = System.Windows.Forms;


namespace ImportExportERP.Views

{
    public partial class Principal : WinForms.Form
    {
        private Exportar ex;
        private string mesageexpprt;
        private StringBuilder messageimport;
        private List<string> pendentesExport;
        private List<string> pendentesImport;
        public static int kl;
        private bool auto = false;

        public object sender { get; set; }
        public bool livre { get; set; } = false;
        public static TimeSpan DataCheck { get; set; }
        public Principal(string[] args)
        {
            InitializeComponent();
            if (args.Count() == 1)
            {
                auto = true;
            }
            new Mensagerias(rtbMensagens);
        }

        private async void btnExportarSqlServer_Click(object sender, EventArgs e)
        {
            bool r = Unidades();
            if (r)
            {
                do
                {
                    ExportDoERP(groupBox1);
                    this.sender = sender;
                    progressBar1.Style = ProgressBarStyle.Blocks;
                    progressBar1.Value = 0;
                    backgroundWorker1.RunWorkerAsync();

                } while (cbLoop.Checked);
            }

        }

        private async void btnExportarMySql_Click(object sender, EventArgs e)
        {
            rtbMensagens.ResetText();
            //TesteRanorex();


            progressBar1.Value = 0;

            lbltarefaConcluida.Text = string.Empty;

            //bool r = Unidades();
            if (true)
            {
                do
                {
                    ++kl;
                    ExportDoERP(groupBox1);

                } while (cbLoop.Checked);
                this.sender = sender;
                progressBar1.Style = ProgressBarStyle.Blocks;
                progressBar1.Value = 0;
                backgroundWorker1.RunWorkerAsync();
            }
            // esta funcionando, mas o fernando nunca liga o pc entao desliguei por um momento
            // o botao esta funcionando


        }

        //private void TesteRanorex()
        //{

        //    ExportFullRepository repo = ExportFullRepository.Instance;

        //    Report.Log(ReportLevel.Info, "Application", "Run application 'C:\\Exports\\erpPronto.jnlp' in normal mode.", new RecordItemIndex(0));
        //    Host.Local.RunApplication("C:\\Exports\\erpPronto.jnlp", "", "", false);

        //    Report.Log(ReportLevel.Info, "Wait", "Waiting 10s to exist. Associated repository item: 'Identificacao'", repo.Identificacao.SelfInfo, new ActionTimeout(10000), new RecordItemIndex(1));
        //    repo.Identificacao.SelfInfo.WaitForExists(10000);
        //}

        private async void btnExportarAmbos_Click(object sender, EventArgs e)
        {
            DateTime hoje = DateTime.Today;
            DateTime data = hoje.AddMonths(-2).AddDays(-hoje.Day + 1);
            DateTime dataPC = hoje.AddYears(-2).AddDays(-hoje.Day + 1);
            return;

            bool r = Unidades();
            if (r)
            {
                do
                {
                    ExportDoERP(groupBox1);
                    this.sender = sender;
                    progressBar1.Style = ProgressBarStyle.Blocks;
                    progressBar1.Value = 0;
                    backgroundWorker1.RunWorkerAsync();

                } while (cbLoop.Checked);
            }
        }

        private bool Unidades()
        {
            bool r = false;
            bool z = Directory.Exists(@"Z:\");
            bool y = Directory.Exists(@"Y:\");
            if (z & y)
            {
                r = true;
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    Process.Start("explorer.exe", @"Z:\");
                    Thread.Sleep(3000);
                    Process.Start("explorer.exe", @"Y:\");
                    Thread.Sleep(3000);
                    var x = Process.GetProcessesByName("explorer");

                    var zz = x.Where(p => p.MainWindowTitle == "17-bq-público (\\\\Servidor) (Z:)").ToList();
                    var yy = x.Where(p => p.MainWindowTitle == "c (\\\\Estoque2) (Y:)").ToList();
                    zz.AddRange(yy);
                    if (zz.Count > 0)
                    {
                        foreach (var item in zz)
                        {
                            item.CloseMainWindow();
                        }
                        r = true;
                        break;
                    }
                    else
                    {
                        Mensagerias.Send($@"Verifique se as Unidade Z:\\ ou Y:\\ estão conectadas...\nZ:\\ { z} \nY:\\ { y}");
                        r = false;
                    }
                }
            }
            return r;
        }

        private void Comeco(object sender)
        {
            HabilitaDesabilitaBotoes(false);

            messageimport = ex.Exportando(sender);
            Import.AtualizaTudo();
            dataGridView1.BeginInvoke(new Action(async () =>
            {
                dataGridView1.DataSource = await Classes.Atualizacao.Tudo();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                Mensagerias.Send("Exportados >> \n" + messageimport + "\n" + mesageexpprt + "\n-----------------------------------\n");
            }));


            HabilitaDesabilitaBotoes(true);
        }

        private void HabilitaDesabilitaBotoes(bool v)
        {
            btnExportarSqlServer.BeginInvoke(new Action(async () =>
            {
                //btnExportarSqlServer.Enabled = v;
            }));
            btnExportarAmbos.BeginInvoke(new Action(async () =>
            {
                //btnExportarAmbos.Enabled = v;
            }));
            btnExportarMySql.BeginInvoke(new Action(async () =>
            {
                btnExportarMySql.Enabled = v;
            }));
        }

        private void cbSaldo_CheckedChanged(object sender, EventArgs e)
        {
            cbSaldoImport.Checked = cbSaldo.Checked;
            //cbItensEstoqueImport.Checked = cbSaldo.Checked;
            //cbItensEstoque.Checked = cbSaldo.Checked;
        }

        private void cbPedidoCompra_CheckedChanged(object sender, EventArgs e)
        {
            cbPedidoCompraImport.Checked = cbPedidoCompra.Checked;
        }

        private void cbPedidoVenda_CheckedChanged(object sender, EventArgs e)
        {
            cbPedidoVendaImport.Checked = cbPedidoVenda.Checked;
        }

        private void cbMovimento_CheckedChanged(object sender, EventArgs e)
        {
            cbMovimentoImport.Checked = cbMovimento.Checked;
        }

        private void cbForaEstoque_CheckedChanged(object sender, EventArgs e)
        {
            cbForaEstoqueImport.Checked = cbForaEstoque.Checked;
        }

        private void cbDeTerceiro_CheckedChanged(object sender, EventArgs e)
        {
            cbDeTerceiroImport.Checked = cbDeTerceiro.Checked;
        }

        private void cbItensEstoque_CheckedChanged(object sender, EventArgs e)
        {
            cbItensEstoqueImport.Checked = cbItensEstoque.Checked;
        }

        private void cbEstoqueMinimo(object sender, EventArgs e)
        {
            if (cbEstqMinomo.Checked == true)
            {
                cbSaldo.Checked = true;
                cbPedidoCompra.Checked = true;

            }
            else
            {
                cbSaldo.Checked = false;
                cbPedidoCompra.Checked = false;
            }
        }

        private void cbInventarios_CheckedChange(object sender, EventArgs e)
        {

            if (cbInventarios.Checked == true)
            {
                if (MessageBox.Show("" +
                   "Antes de fazer ExportsInventario" +
                   "\n" +
                   "Solicitar ao PCP efetivar as OPs." +
                   "\n" +
                   "Solicitar aos demais setores encerrar possíveis pendências que afetem o estoque quantitativamente..." +
                   "\n" +
                   "\n" +
                   "Continuar com o ExportInventario?", "ATENÇÃO - Export Inventario", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    cbSaldo.Checked = true;
                    cbMovimento.Checked = true;
                    cbPedidoVenda.Checked = true;
                    cbDeTerceiro.Checked = true;
                    cbForaEstoque.Checked = true;
                    cbPedidoCompra.Checked = true;

                }
                else
                {
                    cbInventarios.Checked = false;
                }


            }
            else
            {
                cbSaldo.Checked = false;
                cbMovimento.Checked = false;
                cbPedidoVenda.Checked = false;
                cbDeTerceiro.Checked = false;
                cbForaEstoque.Checked = false;
                cbPedidoCompra.Checked = false;

            }

        }

        private void cbSaldoMensalFinalDoMes_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSaldoMensalFinalDoMes.Checked == true)
            {
                cbItensEstoque.Checked = true;
            }
            else
            {
                cbItensEstoque.Checked = false;
            }

        }

        private void cbMaterialParado_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMaterialParado.Checked == true)
            {
                cbSaldo.Checked = true;
                cbPedidoVenda.Checked = true;
                cbItensEstoque.Checked = true;
            }
            else
            {
                cbSaldo.Checked = false;
                cbPedidoVenda.Checked = false;
                cbItensEstoque.Checked = false;
            }
        }

        private void cbPCPInvestigar_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPCPInvestigar.Checked == true)
            {
                cbSaldo.Checked = true;

                cbPedidoVenda.Checked = true;

                cbForaEstoque.Checked = true;


            }
            else
            {
                cbSaldo.Checked = false;

                cbPedidoVenda.Checked = false;

                cbForaEstoque.Checked = false;


            }
        }

        private void cdSaldoDeTerceiro_CheckedChanged(object sender, EventArgs e)
        {


            if (cbSaldoDeTerceiro.Checked == true)
            {
                cbSaldoDeTerceiroImport.Checked = true;
                cbEstabDeTerceiro.Checked = true;

            }
            else
            {
                cbSaldoDeTerceiroImport.Checked = false;
                cbEstabDeTerceiro.Checked = false;

            }
        }

        private void cbEstabDeTerceiro_CheckedChanged(object sender, EventArgs e)
        {
            if (cbEstabDeTerceiro.Checked == true)
            {
                cbEstabDeTerceiroImport.Checked = true;
            }
            else
            {
                cbEstabDeTerceiroImport.Checked = false;
            }
        }

        private void cbConsultaSaldo_CheckedChanged(object sender, EventArgs e)
        {
            if (cbConsultaSaldo.Checked == true)
            {
                cbSaldo.Checked = true;
                cbItensEstoque.Checked = true;
            }
            else
            {
                cbSaldo.Checked = false;
                cbItensEstoque.Checked = false;
            }
        }

        private void cbInventarioForaEstoqC_Saldo_CheckedChanged(object sender, EventArgs e)
        {
            if (cbInventarioForaEstoqC_Saldo.Checked == true)
            {
                cbItensEstoque.Checked = true;
                cbForaEstoque.Checked = true;
            }
            else
            {
                cbItensEstoque.Checked = false;
                cbForaEstoque.Checked = false;
            }
        }

        private void cbInventarioDeTerceiroC_Saldo_CheckedChanged(object sender, EventArgs e)
        {
            if (cbInventarioDeTerceiroC_Saldo.Checked == true)
            {
                cbSaldoDeTerceiro.Checked = true;
                cbEstabDeTerceiro.Checked = true;
                cbDeTerceiro.Checked = true;
            }
            else
            {
                cbSaldoDeTerceiro.Checked = false;
                cbEstabDeTerceiro.Checked = false;
                cbDeTerceiro.Checked = false;
            }
        }

        private void cbLimparPrateleiraComSaldoZeroMinimoZero_CheckedChanged(object sender, EventArgs e)
        {
            if (cbLimparPrateleiraComSaldoZeroMinimoZero.Checked == true)
            {
                cbSaldo.Checked = true;
                cbMovimento.Checked = true;
            }
            else
            {
                cbSaldo.Checked = false;
                cbMovimento.Checked = false;
            }
        }

        private void cbInventariarPorGrupo_CheckedChanged(object sender, EventArgs e)
        {
            if (cbInventariarPorGrupo.Checked == true)
            {
                cbSaldo.Checked = true;
                cbItensEstoque.Checked = true;
            }
            else
            {
                cbSaldo.Checked = false;
                cbItensEstoque.Checked = false;
            }
        }

        public async void Principal_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = await Classes.Atualizacao.Tudo();
            lblTeste.Text = "Suporte ERP 2179-3150";
            lblMaquina.Text = MySqlContext.maquina;
            if (auto)
            {
                AplicaTudo();
            }

        }

        private void cbOrdensDeProducao_Click(object sender, EventArgs e)
        {
            if (cbOrdensDeProducao.Checked == true)
            {
                cbOrdensDeProducaoImport.Checked = true;
                cbMovimento.Checked = true;
            }
            else
            {
                cbOrdensDeProducaoImport.Checked = false;
            }
        }

        private void cbExportMovimentoTotal_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMovimentoTotal.Checked == true)
            {
                cbMovimentoTotalImport.Checked = true;
            }
            else
            {
                cbMovimentoTotalImport.Checked = false;
            }
        }

        private void cbExportNFsDinamicaProduto_CheckedChanged(object sender, EventArgs e)
        {

            if (cbNFsDinamicaProduto.Checked == true)
            {
                DateTime hoje = DateTime.Today;
                DateTime data = hoje.AddMonths(-2).AddDays(-hoje.Day + 1);

                cbNFsDinamicaProdutoImport.Checked = true;
                dtpInicio.Value = data;
            }
        }

        private void cbOPsSaldoRecebeNFs_CheckedChanged(object sender, EventArgs e)
        {
            dtpInicio.Text = DateTime.Today.AddDays(-60).ToShortDateString();
            if (cbOPsSaldoRecebeNFs.Checked == true)
            {
                cbNFsDinamicaProduto.Checked = true;
                //cbPedidoCompra.Checked = true;
                //cbEstabDeTerceiro.Checked = true;
            }
            else
            {
                cbNFsDinamicaProduto.Checked = false;
                //cbPedidoCompra.Checked = false;
                //cbEstabDeTerceiro.Checked = false;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (Exportar.jj == Continua.Sim)
            {
                new Import(backgroundWorker1);
                Comeco(this.sender);

                //so sincroniza depois das 7:22
                var hora = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 07, 22, 00);
                if (DateTime.Now >= hora)
                {
                    ControllerERP_Pronto.SincronizaFiles();
                }
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            lbltarefaConcluida.Text = e.ProgressPercentage.ToString() + "%";
            lblDownloadCorrente.Text = Exportar.lbl;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                //caso a operação seja cancelada, informa ao usuario.
                lbltarefaConcluida.Text = "Operação Cancelada pelo Usuário!";

                //habilita o Botao cancelar
                //                                  btnCancelar.Enabled = true;
                //limpa a label
                lbltarefaConcluida.Text = string.Empty;
            }
            else if (e.Error != null)
            {
                //informa ao usuario do acontecimento de algum erro.
                lbltarefaConcluida.Text = "Aconteceu um erro durante a execução do processo!";
            }
            else
            {
                //informa que a tarefa foi concluida com sucesso.
                lbltarefaConcluida.Text = "Tarefa Concluida com sucesso!";

            }
        }

        private void cbInventarioDiario_CheckedChanged(object sender, EventArgs e)
        {
            if (cbInventarioDiario.Checked == true)
            {
                cbItensEstoque.Checked = true;
                cbMovimento.Checked = true;
            }
            else
            {
                cbItensEstoque.Checked = false;
                cbMovimento.Checked = false;
            }
        }

        private void dtpInicio_ValueChanged(object sender, EventArgs e)
        {
            DataCheck = DateTime.Today - dtpInicio.Value;
        }

        private void cbLoop_CheckedChanged(object sender, EventArgs e)
        {
            if (cbLoop.Checked)
            {
                LimpaImports();
            }
        }

        public void LimpaImports()
        {
            cbSaldoImport.Checked = false;
            cbItensEstoqueImport.Checked = false;
            cbPedidoCompraImport.Checked = false;
            cbPedidoVendaImport.Checked = false;
            cbMovimentoImport.Checked = false;
            cbForaEstoqueImport.Checked = false;
            cbDeTerceiroImport.Checked = false;
            cbMovimentoTotalImport.Checked = false;
            cbOrdensDeProducaoImport.Checked = false;
            cbNFsDinamicaProdutoImport.Checked = false;
            cbSaldoDeTerceiroImport.Checked = false;
            cbEstabDeTerceiroImport.Checked = false;
        }

        public void LimpaTudo()
        {

            cbSaldo.Checked = false;
            cbItensEstoque.Checked = false;
            cbPedidoCompra.Checked = false;
            cbPedidoVenda.Checked = false;
            cbMovimento.Checked = false;
            cbForaEstoque.Checked = false;
            cbDeTerceiro.Checked = false;
            cbMovimentoTotal.Checked = false;
            cbOrdensDeProducao.Checked = false;
            cbNFsDinamicaProduto.Checked = false;
            cbSaldoDeTerceiro.Checked = false;
            cbEstabDeTerceiro.Checked = false;

            LimpaImports();
        }

        public void AplicaTudo()
        {

            cbSaldo.Checked = true;
            cbItensEstoque.Checked = true;
            cbPedidoCompra.Checked = true;
            cbPedidoVenda.Checked = true;
            cbMovimento.Checked = true;
            cbForaEstoque.Checked = true;
            cbDeTerceiro.Checked = true;
            cbOrdensDeProducao.Checked = true;
            cbNFsDinamicaProduto.Checked = true;
            cbSaldoDeTerceiro.Checked = true;
            cbEstabDeTerceiro.Checked = true;
            auto = true;
        }

        private void cbInventarioRotativo_CheckedChanged(object sender, EventArgs e)
        {
            if (cbInventarioRotativo.Checked)
            {
                cbSaldoImport.Checked = true;
                cbItensEstoqueImport.Checked = true;
                cbPedidoCompraImport.Checked = true;
                cbPedidoVendaImport.Checked = true;
                cbMovimentoImport.Checked = true;
                cbForaEstoqueImport.Checked = true;
                cbDeTerceiroImport.Checked = true;

                cbSaldo.Checked = true;
                cbItensEstoque.Checked = true;
                cbPedidoCompra.Checked = true;
                cbPedidoVenda.Checked = true;
                cbMovimento.Checked = true;
                cbForaEstoque.Checked = true;
                cbDeTerceiro.Checked = true;
            }
            else
            {
                LimpaTudo();
            }
        }

        private void brnSincronizaFiles_Click(object sender, EventArgs e)
        {
            ControllerERP_Pronto.SincronizaFiles();
        }

        public partial class BuscaErro : WinForms.Form
        {
            public static List<string> PendentesImport { get; private set; }
            public static List<string> PendentesExport { get; private set; }
            public static TimeSpan DataCheck { get; private set; }

            public BuscaErro()
            {

            }


            public static List<string> be(BackgroundWorker bgw)
            {
                bool continua = true;
                int i = 0;
                while (continua)
                {
                    var erro = ListaDeJanelasAbertas.Lista().Exists(p => p == "Erro");
                    if (erro)
                    {
                        PendentesImport = Exportar.ListaImport;
                        PendentesExport = Exportar.PendentesExport;
                        DataCheck = Principal.DataCheck;

                        ERP_Pronto.FecharABC71();
                        Start.p.BeginInvoke(new Action(async () => { Start.p.Dispose(); }));
                        Thread.Sleep(2000);
                        new Principal(null);
                        continua = false;


                    }

                    bgw.ReportProgress(++i, "Erro");

                    Thread.Sleep(1000);
                }
                return null;
            }
        }

        public partial class Start : WinForms.Form
        {
            BackgroundWorker bgw;
            public static Principal p;
            private Label lblTeste;

            public static List<string> PendentesImport { get; internal set; }
            public static List<string> PendentesExport { get; internal set; }

            public Start()
            {

                BackgroundWorker bgw = new BackgroundWorker();
                bgw.WorkerReportsProgress = true;
                bgw.WorkerSupportsCancellation = true;
                this.bgw = bgw;
                p = new Principal(null);
                lblTeste = p.lblTeste;
                Parallel.Invoke(new Action(async () => { InicializaBackGoundWorker(bgw); p.ShowDialog(); }));

                //InicializaBackGoundWorker(bgw);
                //p.ShowDialog();

            }

            private void InicializaBackGoundWorker(BackgroundWorker bgw)
            {


                bgw.DoWork += new DoWorkEventHandler(bgw_DoWork);
                bgw.ProgressChanged +=
                            new ProgressChangedEventHandler(bgw_ProgressChanged);
                bgw.RunWorkerCompleted +=
                           new RunWorkerCompletedEventHandler(bgw_RunWorkerCompleted);

                bgw.RunWorkerAsync(lblTeste);
            }

            private void bgw_DoWork(object sender, DoWorkEventArgs e)
            {
                var x = BuscaErro.be(bgw);

            }

            private void bgw_ProgressChanged(object sender, ProgressChangedEventArgs e)
            {
                lblTeste.Text = "Teste " + e.ProgressPercentage.ToString();
                var x = (string)e.UserState;
            }

            private void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
                if (e.Cancelled)
                {
                    //caso a operação seja cancelada, informa ao usuario.
                    lblTeste.Text = "Operação Cancelada pelo Usuário!";

                    //habilita o Botao cancelar
                    //                                  btnCancelar.Enabled = true;
                    //limpa a label
                    lblTeste.Text = string.Empty;
                }
                else if (e.Error != null)
                {
                    //informa ao usuario do acontecimento de algum erro.
                    lblTeste.Text = "Aconteceu um erro durante a execução do processo!";
                }
                else
                {
                    //informa que a tarefa foi concluida com sucesso.
                    lblTeste.Text = "Tarefa Concluida com sucesso!";

                }
            }
        }

        private void lblAllExports_Click(object sender, EventArgs e)
        {
            cbSaldo.Checked = true;
            cbItensEstoque.Checked = true;
            cbPedidoCompra.Checked = true;
            cbPedidoVenda.Checked = true;
            cbMovimento.Checked = true;
            cbForaEstoque.Checked = true;
            cbDeTerceiro.Checked = true;
            //cbMovimentoTotal.Checked = true;
            cbOrdensDeProducao.Checked = true;
            cbNFsDinamicaProduto.Checked = true;
            cbSaldoDeTerceiro.Checked = true;
            cbEstabDeTerceiro.Checked = true;
        }

        private void lblImportsDB_Click(object sender, EventArgs e)
        {
            cbSaldoImport.Checked = true;
            cbItensEstoqueImport.Checked = true;
            cbPedidoCompraImport.Checked = true;
            cbPedidoVendaImport.Checked = true;
            cbMovimentoImport.Checked = true;
            cbForaEstoqueImport.Checked = true;
            cbDeTerceiroImport.Checked = true;
            //cbMovimentoTotalImport.Checked = true;
            cbOrdensDeProducaoImport.Checked = true;
            cbNFsDinamicaProdutoImport.Checked = true;
            cbSaldoDeTerceiroImport.Checked = true;
            cbEstabDeTerceiroImport.Checked = true;
        }

        private void cbNFsDinamicaProdutoImport_CheckedChanged(object sender, EventArgs e)
        {
            if (cbNFsDinamicaProdutoImport.Checked == true)
            {
                DateTime hoje = DateTime.Today;
                DateTime data = hoje.AddMonths(-2).AddDays(-hoje.Day + 1);

                dtpInicio.Value = data;
            }
        }

        private void btnExportarMySqlFULL_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            lbltarefaConcluida.Text = string.Empty;
            ExportDoERP(groupBox2);
            this.sender = sender;
            progressBar1.Style = ProgressBarStyle.Blocks;
            progressBar1.Value = 0;
            backgroundWorker1.RunWorkerAsync();
        }

        private void ExportDoERP(GroupBox groupBox)
        {
            ex = new Exportar(groupBox, txtDepartamento, txtUser, txtPassWord, dtpInicio, lblDownloadCorrente, txtFilial, rtbMensagens);
            mesageexpprt = ex.Inicio();
        }
    }
}


