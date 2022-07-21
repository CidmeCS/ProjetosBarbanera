using Estoque.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estoque.Views
{
    public partial class frmExport : Form
    {
        /*
        private StringBuilder erro = new StringBuilder();
        private string erro2;

        public string Janela { get; private set; }

        public frmExport()
        {
            InitializeComponent();
            lblAtualizacao.Text = Atualizacao.Get();
        }



        private void btnExportar_Click(object sender, EventArgs e)
        {
            List<int> li = new List<int>();
            var xl = txtSaldoDeterceiros.Text.Split(',');
            foreach (var i in xl)
            {
                if (i.Contains("-"))
                {
                    var s = i.Split('-');
                    int pr = Convert.ToInt32(s[0]);
                    int sc = Convert.ToInt32(s[1]);
                    for (int ii = pr; ii <= sc; ii++)
                    {
                        li.Add(ii);
                    }
                }
                else if(cdSaldoDeTerceiro.Checked == true & i.Length > 0)
                {
                    li.Add(Convert.ToInt32(i));
                }
            }
            var fila = new List<string>();
            foreach (CheckBox item in groupBox1.Controls)
            {
                switch (item.Checked)
                {
                    case true:
                        fila.Add(item.Text);
                        break;
                }
            }
            fila.Sort();
            foreach (var item in fila)
            {
                if (item == "08 E.Saldo DeTerceiro")
                {
                    if (MessageBox.Show($"Quantidade de Depositos? = {txtSaldoDeterceiros}","Quantidade de Depositos",MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        continue;
                    }
                }
                Janela = item;
                var x = Exports.Start(item, li);


                erro.AppendLine(x);
                erro2 = x;

                new Thread(ListBox).Start();


            }
            Atualizacao.Set();
            lblAtualizacao.Text = Atualizacao.Get();

            MessageBox.Show("Exportados >> " + erro);
        }

        private void ListBox()
        {
            if (listBox1.InvokeRequired) listBox1.BeginInvoke((MethodInvoker)delegate
            {
                listBox1.Items.Add(Janela);
                listBox1.Items.Add(erro2);
            }


            );

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cbSaldo_CheckedChanged(object sender, EventArgs e)
        {
            cbSaldoImport.Checked = cbSaldo.Checked;
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
                cbSaldo.Checked = true;
                cbMovimento.Checked = true;
                cbPedidoVenda.Checked = true;
                cbDeTerceiro.Checked = true;
                cbForaEstoque.Checked = true;
                cbPedidoCompra.Checked = true;

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
            }
            else
            {
                cbSaldo.Checked = false;
                cbPedidoVenda.Checked = false;
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
            if (cdSaldoDeTerceiro.Checked == true)
            {
                cbSaldoDeTerceiroImport.Checked = true;
            }
            else
            {
                cbSaldoDeTerceiroImport.Checked = false;
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
                cbItensEstoque.Checked = true;
                cbDeTerceiro.Checked = true;
            }
            else
            {
                cbItensEstoque.Checked = false;
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
        */
    }
}
