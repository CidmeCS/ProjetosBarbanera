using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Estoque.Views;
using Estoque.Classes;
using System.Collections;
using System.IO;
using Estoque.DAO;
using System.Linq;
using System.Data;
using Estoque.Entidade;
using System.Diagnostics;
using System.Threading;
using Estoque.Classes.ERP;
using System.Threading.Tasks;
using System.Drawing;
using BackUpMysqlDll;
using System.Text.RegularExpressions;
using System.Text;
using System.IO.Ports;
using AutoIt;

namespace Estoque
{
    public partial class Principal : Form
    {
        private List<string> CodDescValor;
        DataGridViewRow row;
        public static  bool liberado = false;

        public Principal()
        {
            InitializeComponent();
        }

        private void btnExports_Click(object sender, EventArgs e)
        {
            //frmExport export = new frmExport();
            //export.ShowDialog();

            MessageBox.Show("Favor Usar o Novo Export", "Novo Export");

        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            PesquisarItem();
        }

        private void PesquisarItem()
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            var ds = Pesquisar.Start(cbbPesquisar.Text, txtPesquisar.Text);
            dataGridView1.DataSource = ds.Tables[0];
            foreach (DataGridViewRow dgvrow in dataGridView1.Rows)
            {
                try
                {
                    if (Convert.ToDecimal(dgvrow.Cells[4].Value.ToString()) > 0)
                    {
                        dgvrow.Cells[4].Style.BackColor = Color.Aqua;
                    }
                }
                catch (Exception)
                {
                }
                try
                {
                    if (Convert.ToDecimal(dgvrow.Cells[7].Value.ToString()) > 0)
                    {
                        dgvrow.Cells[7].Style.BackColor = Color.Yellow;
                    }
                }
                catch (Exception)
                {
                }
            }
            lblLinhas.Text = ds.Tables[0].Rows.Count.ToString() + " LINHAS RETORNADAS";
        }

        private void SequenciaCodigo()
        {
            // dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            var lista = Pesquisar.SequenciaCodigo();
            dataGridView1.DataSource = lista;
            foreach (DataGridViewRow dgvrow in dataGridView1.Rows)
            {
                try
                {
                    if (Convert.ToDecimal(dgvrow.Cells[4].Value.ToString()) > 0)
                    {
                        dgvrow.Cells[4].Style.BackColor = Color.Aqua;
                    }
                }
                catch (Exception)
                {
                }
                try
                {
                    if (Convert.ToDecimal(dgvrow.Cells[7].Value.ToString()) > 0)
                    {
                        dgvrow.Cells[7].Style.BackColor = Color.Yellow;
                    }
                }
                catch (Exception)
                {
                }
            }
            lblLinhas.Text = lista.Count.ToString() + " LINHAS RETORNADAS";
        }

        private void cbbMedidas(object sender, EventArgs e)
        {
            var x = comboBox1.Text;
            lblMedidas.Text = Medidas.Start(x);
        }

        private void DataGridView(object sender, DataGridViewCellEventArgs e)
        {
            row = dataGridView1.CurrentRow;
            CodDescValor = DataGridVieww.Start(row);
            try
            {
                txtKg_Metro.Text = CodDescValor[3];
                label3.Text = "Kg/M: " + CodDescValor[3];
                txtCod_Produto.Text = row.Cells[0].Value.ToString();
                txtProduto_MatPrima.Text = row.Cells[1].Value.ToString();

                if (Convert.ToDecimal(row.Cells[4].Value.ToString()) > 0)
                {
                    PedidoDeCompraDoItem pci = new PedidoDeCompraDoItem(row);
                    pci.ShowDialog();
                    Crud crud = new Crud();
                    var b = crud.ListPedidoDeCompra().Where(p => p.Produto == row.Cells[0].Value.ToString() & p.Saldo > 0).ToList();
                }
                if (Convert.ToDecimal(row.Cells[7].Value.ToString()) > 0)
                {
                    //PrevisaoConsumo pc = new PrevisaoConsumo(row);
                    //pc.ShowDialog();
                    //Crud crud = new Crud();

                }
            }
            catch (Exception)
            {
            }

        }

        private void btnCriarKgM_Click(object sender, EventArgs e)
        {

            Classes.Conversor.Start(row, txtKg_Metro.Text);


        }

        private void btnTabConvExcel_Click(object sender, EventArgs e)
        {
            TabConvercaoExcel.Start();
        }

        private void btnSaldoMensal_Click(object sender, EventArgs e)
        {
            Views.SaldoMensal sm = new Views.SaldoMensal();
            sm.ShowDialog();

        }

        private void btnCalculos_Click(object sender, EventArgs e)
        {
            frmCalculo c = new frmCalculo();
            c.ShowDialog();
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            Inventarios i = new Inventarios();
            i.ShowDialog();
        }

        private void EstoqueMinimoComPrevisao(object sender, EventArgs e)
        {
            frmEstoqueMinimoComPrevisao emcp = new frmEstoqueMinimoComPrevisao();
            emcp.ShowDialog();
        }

        private void btnMaterialParado_Click(object sender, EventArgs e)
        {

            frmMaterialParado mp = new frmMaterialParado();
            mp.ShowDialog();

        }

        private void btnTeste_Click(object sender, EventArgs e)
        {
            Thread.Sleep(5000);

            var s = AutoItX.WinActivate("ERP Pronto - ABC71");

            //ERP_Pronto.ProcuraRecurso("btnIncluir2.PNG", 20, 319, 656, 33, 21, true, false);

        }

        private void TestePortaSerial()
        {
            try
            {
                var ports = SerialPort.GetPortNames().ToList();
                ports.Sort();

                serialPort1.PortName = ports[1];
                serialPort1.BaudRate = 9600;
                serialPort1.DataBits = 8;
                serialPort1.StopBits = StopBits.One;
                serialPort1.Parity = Parity.None;

                serialPort1.Open();

                serialPort1.Write("OLA ");
                char[] c = new char[5] { 'A', 'B', 'C', 'D', 'E' };
                byte[] b = new byte[5] { 70, 71, 72, 73, 74 };
                serialPort1.Write(c, 0, 5);
                serialPort1.Write(b, 0, 5);
                serialPort1.WriteLine("");


                serialPort1.Close();

            }
            catch (Exception ex)
            {
                serialPort1.Close();
            }
        }

        private void btnInativarItensParados_Click(object sender, EventArgs e)
        {

            InativarExcluirItens iei = new InativarExcluirItens();
            iei.ShowDialog();
        }

        private void btnEntregaDeTerceiro_Click(object sender, EventArgs e)
        {
            Views.EntregaItemDeTerceiro edt = new Views.EntregaItemDeTerceiro();
            edt.ShowDialog();
        }

        private void btnDigitalizaOPsScaneadas_Click(object sender, EventArgs e)
        {
            DigitalizaOPs dgo = new DigitalizaOPs();
            dgo.ShowDialog();
        }

        private void btnVerificaOPsLiberadas_Click(object sender, EventArgs e)
        {

            Verificar_OPs_Liberadas vol = new Verificar_OPs_Liberadas();
            vol.ShowDialog();

        }

        private void btnRFID_Click(object sender, EventArgs e)
        {
            RFID_Manutencao m = new RFID_Manutencao();
            m.ShowDialog();

        }

        private void btnReceberNFs_Click(object sender, EventArgs e)
        {
            Estoque.Views.ReceberNFs rn = new Estoque.Views.ReceberNFs();
            rn.ShowDialog();


        }

        private void btnCalcularOPs_Click(object sender, EventArgs e)
        {
            Views.CalculaOPs co = new Views.CalculaOPs();
            co.ShowDialog();
        }

        private void btnObterDadosDasOPs_Click(object sender, EventArgs e)
        {
            ObterDaddosDeOPs oddo = new ObterDaddosDeOPs();
            oddo.ShowDialog();

        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbbPesquisar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        private void btnRFIDInventario_Click(object sender, EventArgs e)
        {
            RFID_Inventario i = new RFID_Inventario();
            i.ShowDialog();
        }

        private void btnApontamentos_Click(object sender, EventArgs e)
        {
            Apontamentos ap = new Apontamentos();
            ap.ShowDialog();
        }

        private void FormLoad(object sender, EventArgs e)
        {

            if (backgroundWorker1.IsBusy != true)
            {
                // Start the asynchronous operation.
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void BackUpDB()
        {
            Crud c = new Crud();
            DataBackUP db = new DataBackUP();
            db = c.ListaDataBackUP().Where(p=>p.ID == 1).First();

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.BeginInvoke(new Action(() =>
            {
                dataGridView1.DataSource = c.ListaAtualizacao().OrderByDescending(p => p.Data).ToList();
                liberado = true;

            }));


            lblLinhas.BeginInvoke(new Action(() =>
            {
                lblLinhas.Text = "Suporte ERP 2179-3150";
            }));
            lblMaquina.BeginInvoke(new Action(() =>
            {
                lblMaquina.Text = StringConexao.maquina;
            }));

            try
            {
                var s = db.Data;

            }
            catch (Exception)
            {
                lblBackUP.BeginInvoke(new Action(() =>
                {
                    lblBackUP.Text = $"O BackUp nao foi realizado e nao foi consultado. Verificar manualmente";
                }));


                return;
            }
            if (db.Data.ToString("ddMMyy") != DateTime.Today.ToString("ddMMyy"))
            {
                Thread t = new Thread(BackUPMySql.Sincronizar);
                t.Start();
                db.Data = DateTime.Now;
                c.AlteraDataBackUP(db);
            }
            lblBackUP.BeginInvoke(new Action(() =>
            {
                lblBackUP.Text = $"BackUp realizado {db.Data}";
            }));

        }

        private void btnCarregaAtualizacoes_Click(object sender, EventArgs e)
        {
            Crud c = new Crud();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.DataSource = c.ListaAtualizacao().OrderByDescending(p => p.Data).ToList();
        }

        private void btnManutencaoDescricao_Click(object sender, EventArgs e)
        {
            CorrigeDescricoes cd = new CorrigeDescricoes();
            cd.ShowDialog();

        }

        private void Pesquisar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                PesquisarItem();
            }
        }

        private void btnManutemcaoBarrasLongas_Click(object sender, EventArgs e)
        {
            ManutencaoBarrasLongas mbl = new ManutencaoBarrasLongas();
            mbl.ShowDialog();
        }

        private void btnSequenciaCodigo_Click(object sender, EventArgs e)
        {
            SequenciaCodigo();
        }

        private void btnPrateleiraAtualiza_Click(object sender, EventArgs e)
        {
            PrateleiraAtualiza pa = new PrateleiraAtualiza();
            pa.ShowDialog();
        }

        private void btnAtualizaEtiqueta_Click(object sender, EventArgs e)
        {
            Etiquetas ae = new Etiquetas();
            ae.ShowDialog();
        }

        private void btnLivre17Atualiza_Click(object sender, EventArgs e)
        {
            Livre17Atualiza la = new Livre17Atualiza();
            la.ShowDialog();
        }

        private void btnG11SemPrateleiraComSaldo_Click(object sender, EventArgs e)
        {
            G11SemPrateleiraComSaldo G11 = new G11SemPrateleiraComSaldo();
            G11.ShowDialog();
        }

        private void btnPCP_Click(object sender, EventArgs e)
        {
            PCP pcp = new PCP();
            pcp.ShowDialog();
        }

        private void btnForaEstoque_Click(object sender, EventArgs e)
        {
            ForaDeEstoqueForm fe = new ForaDeEstoqueForm();
            fe.ShowDialog();
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            BackUpDB();
            while (liberado == false)
            {

            }
            ForaDeEstoqueForm.EnviaEmail(false);
        }
    }
}
