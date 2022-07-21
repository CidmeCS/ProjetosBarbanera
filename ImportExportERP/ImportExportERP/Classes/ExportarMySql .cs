using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImportExportERP.Classes;
using ImportExportERP.Entidade;
using ImportExportERP.Views;

namespace ImportExportERP.Classes
{
    public class ExportarMySql : Principal
    {
        public static void Start(TextBox txtSaldoDeterceiros, CheckBox cdSaldoDeTerceiro, GroupBox groupBox1, string Janela, TextBox txtDepartamento, 
            TextBox txtUser, TextBox txtPassWord, StringBuilder erro, string erro2, Label lblAtualizacao, 
            IOrderedEnumerable<DepositoDeTerceiro> sh, object sender, EventArgs e)
        {
            List<int> li = new List<int>();
            var xl = txtSaldoDeterceiros.Text.Split(',', ';');
            
            var cx = sh.Count();
            foreach (var i in xl)
            {
                if (i.Contains("-"))
                {
                    var s = i.Split('-');
                    int pr = Convert.ToInt32(s[0]);
                    int sc = Convert.ToInt32(s[1]);
                    for (int ii = pr; ii <= sc; ii++)
                    {
                        if (cx >= ii)
                        {
                            li.Add(ii);
                        }
                        else
                        {
                            MessageBox.Show($"Informe corretamente os depositos \n{cx + " depositos apenas"}", "Correcao de Valores");
                            txtSaldoDeterceiros.Focus();
                            goto ir;
                        }
                    }
                }
                else if (cdSaldoDeTerceiro.Checked == true)
                {
                    try
                    {
                        if (cx >= Convert.ToInt32(i))
                        {
                            li.Add(Convert.ToInt32(i));
                        }
                        else
                        {
                            MessageBox.Show($"Informe corretamente os depositos \n{cx + " depositos apenas"}", "Correcao de Valores");
                            txtSaldoDeterceiros.Focus();
                            goto ir;
                        }

                    }
                    catch (FormatException)
                    {

                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine();
                        foreach (var it in sh)
                        {
                            sb.AppendLine(it.Deposito + " - " + it.Nome);
                        }
                        MessageBox.Show($"Informe corretamente os valores {sb}", "Correcao de Valores");
                        txtSaldoDeterceiros.Focus();
                        goto ir;
                    }

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
                if (item == "09 E.Saldo DeTerceiro")
                {
                    if (MessageBox.Show($"Quantidade de Depositos? = {txtSaldoDeterceiros.Text}", "Quantidade de Depositos", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        goto ir;
                    }
                }
                Janela = item;
                new ERP_Pronto(txtDepartamento, txtUser, txtPassWord);
                var x = ExportsMySql.Start(item, li);

                erro.AppendLine(x);
                erro2 = x;

                List<Saldo> p = new List<Saldo>
                {
                    new Saldo{
                        Produto = Janela,
                        Descricao = erro2
                    }
                };
                
            }
            Atualizacao.Set();
            lblAtualizacao.Text = Atualizacao.Get();

            MessageBox.Show("Exportados >> " + erro);
        ir:;
        }
    }
}
