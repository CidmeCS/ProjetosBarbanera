using Estoque.DAO;
using Estoque.Entidade;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Immutable;
using Estoque.Classes;
using System.Data.SqlClient;
using System.IO;
using WindowsInput;
using AutoIt;
using WindowsInput.Native;
using System.Threading;
using Microsoft.EntityFrameworkCore.Internal;
using MoreLinq.Extensions;

namespace Estoque.Views
{
    public partial class Etiquetas : Form
    {

        List<EtiquetaMovimentos> Registros = new List<EtiquetaMovimentos>();
        private List<Divergentes> dv;
        private bool b = false, s = false;
        private List<PedidoDeVenda> pvsFull;
        private List<ForaDeEstoque> feFull;
        private List<NotasFiscaisDinamicaProduto> nfFull;
        private List<PedidoDeCompra> pcFull;
        private List<OrdensDeProducao> opFull;

        public Etiquetas()
        {
            InitializeComponent();

            if (backgroundWorker1.IsBusy != true)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void CarregaDados()
        {
            Crud c = new Crud();
            while (true)
            {
                if (Principal.liberado)
                {
                    pvsFull = c.ListPedidoDeVenda().ToList();
                    feFull = c.ListaForaDeEstoque().Where(p => p.SaldoQtde > 0).ToList();
                    nfFull = c.ListaNotasFiscaisDinamicaProduto().Where(p => p.DataMovimento > DateTime.Today.AddDays(-31)).ToList();
                    opFull = c.ListaOrdensDeProducao().Where(p => p.Produto.StartsWith("PP2-") & p.StatusOP == "Liberada").ToList();
                    pcFull = c.ListPedidoDeCompra().Where(p => p.Saldo > 0).ToList();
                    break;
                }
            }
        }

        private void Load_AE(object sender, EventArgs e)
        {
            dgvMovimentos2.Columns["Codigo"].DefaultCellStyle.BackColor = Color.LightGreen;
            dgvMovimentos2.Columns["Saida"].DefaultCellStyle.BackColor = Color.Cyan;
            dgvMovimentos2.Columns["Entrada"].DefaultCellStyle.BackColor = Color.Coral;
            dgvMovimentos2.Columns["Atualiza"].DefaultCellStyle.BackColor = Color.DarkSeaGreen;
        }

        private void cellEndEdite(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                var rows = dgvMovimentos2.Rows;
                var cod = dgvMovimentos2.CurrentCell.Value.ToString().ToUpper();
                int i = 0;
                foreach (DataGridViewRow row in rows)
                {
                    if (row.Cells["Codigo"].Value == null)
                    {
                        continue;
                    }
                    if (cod == row.Cells["Codigo"].Value.ToString().ToUpper())
                    {
                        i++;
                        if (i >= 2)
                        {
                            dgvMovimentos2.Rows.Remove(row);
                            InputSimulator ins = new InputSimulator();
                            Thread.Sleep(500);
                            ins.Keyboard.KeyPress(VirtualKeyCode.DOWN);
                            return;
                        }
                    }
                }

                Crud c = new Crud();
                var etiquetas = c.ListarEtiqueta().Where(p => p.Codigo == cod);
                var linha = e.RowIndex;

                if (etiquetas.Count() == 0)
                {
                    dgvMovimentos2.Rows[linha].Cells["Codigo"].Value = "";
                    return;
                }

                var etiqueta = etiquetas.First();

                dgvMovimentos2.Rows[linha].Cells["Codigo"].Value = etiqueta.Codigo;
                dgvMovimentos2.Rows[linha].Cells["Descricao"].Value = etiqueta.Descricao;
                dgvMovimentos2.Rows[linha].Cells["UND"].Value = etiqueta.UND;
                dgvMovimentos2.Rows[linha].Cells["SaldoAtual"].Value = etiqueta.SaldoAtual;
                dgvMovimentos2.Rows[linha].Cells["Convertido"].Value = etiqueta.Convertido;
                dgvMovimentos2.Rows[linha].Cells["Prateleira"].Value = etiqueta.Prateleira;
                dgvMovimentos2.Rows[linha].Cells["Livre17"].Value = etiqueta.Livre17;
            }

            if (e.ColumnIndex == 6)
            {
                Crud c = new Crud();
                var row = dgvMovimentos2.CurrentRow;
                var cod = row.Cells["Codigo"].Value.ToString().ToUpper();
                var etiqueta = c.ListarEtiqueta().Where(p => p.Codigo == cod).First();
                var valor = Math.Round(Convert.ToDecimal(row.Cells["Saida"].Value.ToString().Replace(".", ",")), 3);
                var newEtq = Classes.Conversor.Converte(etiqueta, valor, "-");
                var linha = e.RowIndex;
                dgvMovimentos2.Rows[linha].Cells["Saida"].Value = valor;
                dgvMovimentos2.Rows[linha].Cells["Entrada"].Value = "0.000";
                dgvMovimentos2.Rows[linha].Cells["Atualiza"].Value = "0.000";
                dgvMovimentos2.Rows[linha].Cells["NewSaldoAtual"].Value = newEtq.SaldoAtual;
                dgvMovimentos2.Rows[linha].Cells["NewConvertido"].Value = newEtq.Convertido;

                AtualizaRegistros(6);
            }
            if (e.ColumnIndex == 7)
            {
                Crud c = new Crud();
                var row = dgvMovimentos2.CurrentRow;
                var cod = row.Cells["Codigo"].Value.ToString().ToUpper();
                var etiqueta = c.ListarEtiqueta().Where(p => p.Codigo == cod).First();
                var valor = Math.Round(Convert.ToDecimal(row.Cells["Entrada"].Value.ToString().Replace(".", ",")), 3);
                var newEtq = Classes.Conversor.Converte(etiqueta, valor, "+");
                var linha = e.RowIndex;
                dgvMovimentos2.Rows[linha].Cells["Saida"].Value = "0.000";
                dgvMovimentos2.Rows[linha].Cells["Entrada"].Value = valor;
                dgvMovimentos2.Rows[linha].Cells["Atualiza"].Value = "0.000";
                dgvMovimentos2.Rows[linha].Cells["NewSaldoAtual"].Value = newEtq.SaldoAtual;
                dgvMovimentos2.Rows[linha].Cells["NewConvertido"].Value = newEtq.Convertido;

                AtualizaRegistros(7);
            }
            if (e.ColumnIndex == 8)
            {
                Crud c = new Crud();
                var row = dgvMovimentos2.CurrentRow;
                var cod = row.Cells["Codigo"].Value.ToString().ToUpper();
                var etiqueta = c.ListarEtiqueta().Where(p => p.Codigo == cod).First();
                var valor = Math.Round(Convert.ToDecimal(row.Cells["Atualiza"].Value.ToString().Replace(".", ",")), 3);
                var newEtq = Classes.Conversor.Converte(etiqueta, valor, "A");
                var linha = e.RowIndex;
                dgvMovimentos2.Rows[linha].Cells["Saida"].Value = "0.000";
                dgvMovimentos2.Rows[linha].Cells["Entrada"].Value = "0.000";
                dgvMovimentos2.Rows[linha].Cells["Atualiza"].Value = valor;
                dgvMovimentos2.Rows[linha].Cells["NewSaldoAtual"].Value = newEtq.SaldoAtual;
                dgvMovimentos2.Rows[linha].Cells["NewConvertido"].Value = newEtq.Convertido;

                AtualizaRegistros(8);
            }
        }

        private void AtualizaRegistros(int col)
        {
            Registros.Clear();

            foreach (DataGridViewRow r in dgvMovimentos2.Rows)
            {
                if (r.Cells[1].Value == null)
                {
                    continue;
                }
                string oprtor = string.Empty;
                decimal valor = 0M;

                try
                {
                    if (col == 6)
                    {
                        oprtor = "-";
                        valor = (decimal)r.Cells["Saida"].Value;
                    }
                }
                catch (Exception)
                {
                }

                try
                {
                    if (col == 7)
                    {
                        oprtor = "+";
                        valor = (decimal)r.Cells["Entrada"].Value;
                    }
                }
                catch (Exception)
                {
                }

                try
                {
                    if (col == 8)
                    {
                        oprtor = "A";
                        valor = (decimal)r.Cells["Atualiza"].Value;
                    }
                }
                catch (Exception)
                {
                }

                if (oprtor == string.Empty)
                {
                    continue;
                }

                if (r.Cells["NewSaldoAtual"].Value == null)
                {
                    continue;
                }
                if (r.Cells["NewConvertido"].Value == null)
                {
                    continue;
                }

                Registros.Add(new EtiquetaMovimentos
                {
                    Codigo = r.Cells["Codigo"].Value.ToString(),
                    Descricao = r.Cells["Descricao"].Value.ToString(),
                    UND = r.Cells["UND"].Value.ToString(),
                    SaldoAtual = (decimal)r.Cells["SaldoAtual"].Value,
                    Convertido = (decimal)r.Cells["Convertido"].Value,
                    Prateleira = r.Cells["Prateleira"].Value.ToString(),
                    Operacao = oprtor,
                    NewSaldoAtual = (decimal)r.Cells["NewSaldoAtual"].Value,
                    NewConvewtido = (decimal)r.Cells["NewConvertido"].Value,
                    Livre17 = (decimal)r.Cells["Livre17"].Value,
                    Data = DateTime.Now,
                    ValorMovimento = valor

                });
            }
        }

        private void btnAtualizaEtiqueta_Click(object sender, EventArgs e)
        {
            // Insere Registros
            Crud c = new Crud();
            c.AdicionaEtiquetaMovimentos(Registros);


            List<Etiqueta> le = new List<Etiqueta>();
            List<Saldo> ls = new List<Saldo>();
            //Atualiza Etiquetas
            foreach (var i in Registros)
            {
                var et = c.ListarEtiqueta().Where(p => p.Codigo == i.Codigo).First();
                et.SaldoAtual = i.NewSaldoAtual;
                et.Convertido = i.NewConvewtido;
                le.Add(et);

                var sa = c.ListaSaldo().Where(p => p.Produto == i.Codigo).First();
                sa.SaldoAtual = (double)i.NewSaldoAtual;
                ls.Add(sa);

            }

            if (le.Count == 0)
            {
                return;
            }


            c.AlteraSaldo(ls);
            c.AlterarEtiquetas(le);

            Registros.Clear();
            dgvMovimentos2.Rows.Clear();

        }

        private void btn50Ultimos_Click(object sender, EventArgs e)
        {
            Crud c = new Crud();
            var l = c.ListaEtiquetaMovimentos().OrderByDescending(p => p.Id).Take(50).ToList();
            var s = DeListParaTable.ConvertListToTableGeneric<EtiquetaMovimentos>(l);
            dgvMovimentos.DataSource = s;
        }

        public List<EtiquetaMovimentos> Pesquisar(string campo, string valor)
        {
            Crud c = new Crud();
            List<EtiquetaMovimentos> lista = null;
            switch (campo)
            {
                case "Id": lista = c.ListaEtiquetaMovimentos().Where(p => p.Id == Convert.ToInt32(valor)).ToList(); break;
                case "Codigo": lista = c.ListaEtiquetaMovimentos().Where(p => p.Codigo.Contains(valor)).ToList(); break;
                case "Descricao": lista = c.ListaEtiquetaMovimentos().Where(p => p.Descricao.Contains(valor)).ToList(); break;
                case "Operacao": lista = c.ListaEtiquetaMovimentos().Where(p => p.Operacao == valor).ToList(); break;
                case "ValorMovimento": lista = c.ListaEtiquetaMovimentos().Where(p => p.ValorMovimento == Convert.ToDecimal(valor)).ToList(); break;
                case "SaldoAtual": lista = c.ListaEtiquetaMovimentos().Where(p => p.SaldoAtual == Convert.ToDecimal(valor)).ToList(); break;
                case "Prateleira": lista = c.ListaEtiquetaMovimentos().Where(p => p.Prateleira.Contains(valor)).ToList(); break;
                case "Livre17": lista = c.ListaEtiquetaMovimentos().Where(p => p.Livre17 == Convert.ToDecimal(valor)).ToList(); break;
                case "Convertido": lista = c.ListaEtiquetaMovimentos().Where(p => p.Convertido == Convert.ToDecimal(valor)).ToList(); break;
                case "NewConvewtido": lista = c.ListaEtiquetaMovimentos().Where(p => p.NewConvewtido == Convert.ToDecimal(valor)).ToList(); break;
                case "NewSaldoAtual": lista = c.ListaEtiquetaMovimentos().Where(p => p.NewSaldoAtual == Convert.ToDecimal(valor)).ToList(); break;
                case "UND": lista = c.ListaEtiquetaMovimentos().Where(p => p.UND.Contains(valor)).ToList(); break;
            }
            return lista;
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            var lista = Pesquisar(comboBox1.Text, txtCampo.Text);
            var s = DeListParaTable.ConvertListToTableGeneric<EtiquetaMovimentos>(lista);
            dgvMovimentos.DataSource = s;
        }

        private void btnCriaListaApartirDeSaldo_Click(object sender, EventArgs e)
        {
            Crud c = new Crud();
            var Saldo = c.ListaSaldo().Where(p => p.Prateleira != "").ToList();
            List<Etiqueta> le = new List<Etiqueta>();
            c.TruncateEtiquetas();

            int index = 0;

            foreach (var s in Saldo)
            {

                Etiqueta et = new Etiqueta();
                et.Descricao = s.Descricao;
                et.SaldoAtual = (decimal)s.SaldoAtual;
                et.Livre17 = s.Livre17;
                et.Grupo = s.Grupo;
                et.UND = s.Unid;


                var cv = Classes.Conversor.GetConvertido(et);
                le.Add(new Etiqueta
                {
                    Codigo = s.Produto,
                    Descricao = s.Descricao,
                    SaldoAtual = (decimal)s.SaldoAtual,
                    Prateleira = s.Prateleira,
                    Livre17 = s.Livre17,
                    Convertido = cv.Convertido,
                    Grupo = s.Grupo,
                    UND = s.Unid
                });

                index++;

                if (index == 1000)  // add a cada 1000 linhas
                {
                    c.AdicionarEtiquetas(le);
                    index = 0;
                    le.Clear();
                }
            }
            c.AdicionarEtiquetas(le); // add as demais linhas. menor que 1000;
        }

        private void cellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            var linha = e.RowIndex;
            var opcao = dgvGerenciamento.Rows[linha].Cells["OpcaoG"].Value;
            Crud c = new Crud();
            if (e.ColumnIndex == 1)
            {
                if (opcao == null)
                {
                    MessageBox.Show("Selecione uma opcao", "OPCAO");
                    dgvGerenciamento.Rows[linha].Cells["CodigoG"].Value = string.Empty;
                    return;
                }

                var cod = dgvGerenciamento.CurrentCell.Value.ToString().ToUpper();
                dgvGerenciamento.CurrentCell.Value = cod;

                if (opcao.ToString() == "Antecipar" | opcao.ToString() == "Criar")
                {
                    var cd = c.ListarEtiqueta().Where(p => p.Codigo == cod);
                    if (cd.Count() > 0)
                    {
                        MessageBox.Show("Esse codigo ja existe.\nCrie/Antecipe outro", "Codigo existente");
                        return;
                    }
                }

                Etiqueta et = new Etiqueta();
                var convertidoX = 0M;
                switch (opcao.ToString())
                {
                    case "Antecipar": return;
                    case "Criar":
                        var es = c.ListaSaldo().Where(p => p.Produto == cod).FirstOrDefault();
                        if (es == null)
                        {
                            return;
                        }
                        et.Codigo = es.Produto;
                        et.Descricao = es.Descricao;
                        et.SaldoAtual = (decimal)es.SaldoAtual;
                        et.Livre17 = es.Livre17;
                        et.Grupo = es.Grupo;
                        et.UND = es.Unid;
                        et.Prateleira = es.Prateleira;
                        break;
                    default:
                        var ee = c.ListarEtiqueta().Where(p => p.Codigo == cod).FirstOrDefault();
                        if (ee == null)
                        {
                            return;
                        }
                        et.Codigo = ee.Codigo;
                        et.Descricao = ee.Descricao;
                        et.SaldoAtual = (decimal)ee.SaldoAtual;
                        et.Livre17 = ee.Livre17;
                        et.Grupo = ee.Grupo;
                        et.UND = ee.UND;
                        et.Prateleira = ee.Prateleira;
                        et.Convertido = ee.Convertido;
                        convertidoX = ee.Convertido;
                        break;
                }

                var convertido = Classes.Conversor.GetConvertido(et);

                if (opcao.ToString() == "Alterar")
                {
                    convertido.Convertido = convertidoX;
                }

                dgvGerenciamento.Rows[linha].Cells["CodigoG"].Value = et.Codigo;
                dgvGerenciamento.Rows[linha].Cells["DescricaoG"].Value = et.Descricao;
                dgvGerenciamento.Rows[linha].Cells["UndG"].Value = et.UND;
                dgvGerenciamento.Rows[linha].Cells["PrateleiraG"].Value = et.Prateleira;
                dgvGerenciamento.Rows[linha].Cells["SaldoAtualG"].Value = et.SaldoAtual.ToString().Replace(".", ",");
                dgvGerenciamento.Rows[linha].Cells["ConvertidoG"].Value = convertido.Convertido.ToString().Replace(".", ",");
                dgvGerenciamento.Rows[linha].Cells["Livre17G"].Value = et.Livre17.ToString().Replace(".", ",");
                dgvGerenciamento.Rows[linha].Cells["GrupoG"].Value = et.Grupo;
            }

            if (e.ColumnIndex == 2)
            {
                var descricao = dgvGerenciamento.CurrentCell.Value.ToString().ToUpper();
                dgvGerenciamento.CurrentCell.Value = descricao;
            }
            if (e.ColumnIndex == 3)
            {
                var und = dgvGerenciamento.CurrentCell.Value.ToString().ToUpper();
                dgvGerenciamento.CurrentCell.Value = und;
            }

            if (e.ColumnIndex == 4)
            {
                var prat = dgvGerenciamento.CurrentCell.Value.ToString().ToUpper();
                dgvGerenciamento.CurrentCell.Value = prat;
            }

            if (e.ColumnIndex == 5)
            {
                var saldo = dgvGerenciamento.Rows[linha].Cells["SaldoAtualG"].Value.ToString().Replace(".", ",");
                dgvGerenciamento.Rows[linha].Cells["SaldoAtualG"].Value = saldo;
                if (opcao.ToString() == "Alterar" | opcao.ToString() == "Criar")
                {
                    var cod = dgvGerenciamento.Rows[linha].Cells["CodigoG"].Value.ToString();
                    var etqS = c.ListaSaldo().Where(p => p.Produto == cod).FirstOrDefault();
                    Etiqueta etq = new Etiqueta();
                    etq.Codigo = etqS.Produto;
                    etq.Descricao = etqS.Descricao;
                    etq.SaldoAtual = Convert.ToDecimal(saldo);
                    etq.Livre17 = etqS.Livre17;
                    etq.Grupo = etqS.Grupo;
                    etq.UND = etqS.Unid;
                    etq.Prateleira = etqS.Prateleira;
                    var convertido = Classes.Conversor.GetConvertido(etq);
                    dgvGerenciamento.Rows[linha].Cells["ConvertidoG"].Value = convertido.Convertido;
                    if (0 == Convert.ToDecimal(dgvGerenciamento.Rows[linha].Cells["Livre17G"].Value.ToString().Replace(",", ".")))
                    {
                        dgvGerenciamento.Rows[linha].Cells["ConvertidoG"].Value = "0.00";
                    }
                }

            }
            if (e.ColumnIndex == 6)
            {
                var convertido = dgvGerenciamento.Rows[linha].Cells["ConvertidoG"].Value.ToString().Replace(".", ",");
                dgvGerenciamento.Rows[linha].Cells["ConvertidoG"].Value = convertido;
                if (opcao.ToString() == "Alterar" | opcao.ToString() == "Criar")
                {
                    var cod = dgvGerenciamento.Rows[linha].Cells["CodigoG"].Value.ToString();
                    var etqS = c.ListaSaldo().Where(p => p.Produto == cod).FirstOrDefault();
                    Etiqueta etq = new Etiqueta();
                    etq.Codigo = etqS.Produto;
                    etq.Descricao = etqS.Descricao;
                    etq.Convertido = Convert.ToDecimal(convertido);
                    etq.Livre17 = etqS.Livre17;
                    etq.Grupo = etqS.Grupo;
                    etq.UND = etqS.Unid;
                    etq.Prateleira = etqS.Prateleira;
                    var saldo = Classes.Conversor.GetSaldoAtual(etq);
                    dgvGerenciamento.Rows[linha].Cells["SaldoAtualG"].Value = saldo.SaldoAtual;
                }
            }
            if (e.ColumnIndex == 7)
            {
                var livre17 = dgvGerenciamento.Rows[linha].Cells["Livre17G"].Value.ToString().Replace(".", ",");
                dgvGerenciamento.Rows[linha].Cells["Livre17G"].Value = livre17;
            }
        }

        private void btnLimpaTudo_Click(object sender, EventArgs e)
        {
            Registros.Clear();
            dgvMovimentos2.Rows.Clear();
        }

        private void btnLimpalinha_Click(object sender, EventArgs e)
        {
            var row = dgvMovimentos2.CurrentRow;
            if (row == null)
            {
                MessageBox.Show("Selecione uma Linha", "Selecione Linha");
                return;
            }
            var index = row.Index;
            if (Registros.Count == 0)
            {
                dgvMovimentos2.Rows.Remove(row);
                return;
            }
            Registros.RemoveAt(index);
            dgvMovimentos2.Rows.Remove(row);
        }

        private void btnAplicaEtiquetas_Click(object sender, EventArgs e)
        {
            var rows = dgvGerenciamento.Rows;

            List<Etiqueta> leC = new List<Etiqueta>();
            List<Etiqueta> leA = new List<Etiqueta>();
            List<Etiqueta> leD = new List<Etiqueta>();
            Crud c = new Crud();

            foreach (DataGridViewRow r in rows)
            {
                if (r.Cells["OpcaoG"].Value == null)
                {
                    continue;
                }


                var opcao = r.Cells["OpcaoG"].Value.ToString();

                switch (opcao)
                {
                    case "Antecipar":
                        leC.Add(new Etiqueta
                        {
                            Codigo = r.Cells["CodigoG"].Value.ToString(),
                            Descricao = r.Cells["DescricaoG"].Value.ToString(),
                            UND = r.Cells["UndG"].Value.ToString(),
                            SaldoAtual = Convert.ToDecimal(r.Cells["SaldoAtualG"].Value),
                            Convertido = Convert.ToDecimal(r.Cells["ConvertidoG"].Value),
                            Livre17 = Convert.ToDecimal(r.Cells["Livre17G"].Value),
                            Prateleira = r.Cells["PrateleiraG"].Value.ToString(),
                            Grupo = r.Cells["GrupoG"].Value.ToString()
                        }); break;
                    case "Criar":
                        leC.Add(new Etiqueta
                        {
                            Codigo = r.Cells["CodigoG"].Value.ToString(),
                            Descricao = r.Cells["DescricaoG"].Value.ToString(),
                            UND = r.Cells["UndG"].Value.ToString(),
                            SaldoAtual = Convert.ToDecimal(r.Cells["SaldoAtualG"].Value),
                            Convertido = Convert.ToDecimal(r.Cells["ConvertidoG"].Value),
                            Livre17 = Convert.ToDecimal(r.Cells["Livre17G"].Value),
                            Prateleira = r.Cells["PrateleiraG"].Value.ToString(),
                            Grupo = r.Cells["GrupoG"].Value.ToString()
                        }); break;
                    case "Alterar":
                        var ID = c.ListarEtiqueta().Where(p => p.Codigo == r.Cells["CodigoG"].Value.ToString()).First().Id;
                        leA.Add(new Etiqueta
                        {
                            Id = ID,
                            Codigo = r.Cells["CodigoG"].Value.ToString(),
                            Descricao = r.Cells["DescricaoG"].Value.ToString(),
                            UND = r.Cells["UndG"].Value.ToString(),
                            SaldoAtual = Convert.ToDecimal(r.Cells["SaldoAtualG"].Value),
                            Convertido = Convert.ToDecimal(r.Cells["ConvertidoG"].Value),
                            Livre17 = Convert.ToDecimal(r.Cells["Livre17G"].Value),
                            Prateleira = r.Cells["PrateleiraG"].Value.ToString(),
                            Grupo = r.Cells["GrupoG"].Value.ToString()
                        }); break;
                    case "Deletar":
                        var etq = c.ListarEtiqueta().Where(p => p.Codigo == r.Cells["CodigoG"].Value.ToString()).First();
                        leD.Add(etq);
                        break;
                }
            }

            c.Dispose();
            Crud cc = new Crud();
            if (leC.Count > 0)
            {
                cc.AdicionarEtiquetas(leC);
                leC.Clear();
            }
            if (leA.Count > 0)
            {
                cc.AlterarEtiquetas(leA);

                List<Saldo> ls = new List<Saldo>();
                foreach (var i in leA)
                {
                    var saldo = c.ListaSaldo().Where(p => p.Produto == i.Codigo).First();
                    saldo.SaldoAtual = (double)i.SaldoAtual;
                    ls.Add(saldo);
                }
                cc.AlteraSaldo(ls);
                leA.Clear();
            }
            if (leD.Count > 0)
            {
                cc.DeletarEtiquetas(leD);
                leD.Clear();
            }

            dgvGerenciamento.Rows.Clear();
        }

        private void btnObterDivergentes_Click(object sender, EventArgs e)
        {
            ObterDivergentes();

        }

        private void ObterDivergentes()
        {
            var resultFinal = ObterDivergentes(true);
            var table = DeListParaTable.ConvertListToTableGeneric<Divergentes>(resultFinal);
            dgvDivergentes.DataSource = table;
            dgvDivergentes.Columns["SaldoSistema"].DefaultCellStyle.BackColor = Color.Coral;
            dgvDivergentes.Columns["SaldoEtiqueta"].DefaultCellStyle.BackColor = Color.SpringGreen;

            Crud c = new Crud();
            var lsdX = c.ListarSaldoDivergente();
            var table2 = DeListParaTable.ConvertListToTableGeneric<SaldoDivergente>(lsdX);
            dgvDivergentes.Columns["Descricao"].Width = 250;
            dgvDivergentes.Columns["Unid"].Width = 50;
            dgvDivergentes.Columns["OBS"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvDivergentes.Columns["OBS"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            dgvSaldoDivergente.DataSource = table2;
        }

        private List<Divergentes> ObterDivergentes(bool b)
        {
            CompareInventario(b);
            decimal max = numericUpDown1.Value, min = numericUpDown1.Value * -1;
            var result = dv.Where(p => p.SaldoDivergente > max | p.SaldoDivergente < min).ToList();
            var result2 = dv.Where(p => p.Prateleira.Contains("S: ")).ToList();
            var result3 = dv.Where(p => p.Livre17Sistema != p.Livre17Etiqueta).ToList();
            result.AddRange(result2);
            result.AddRange(result3);
            var resultFinal = result.Distinct().OrderBy(p => p.Prateleira).ToList();
            return resultFinal;
        }

        private void CompareInventario(bool b)
        {
            while (pcFull == null) { }

            dv = new List<Divergentes>();
            Crud c = new Crud();
            var saldo = c.ListaSaldo();
            var etiquetas = c.ListarEtiqueta();
            var nfsFull = nfFull.Where(p => p.DatadeEmissao > DateTime.Today.AddDays((int)nupDias.Value));

            foreach (var etq in etiquetas)
            {
                var r = saldo.Where(p => p.Produto == etq.Codigo).First();




                if (r != null)
                {
                    Divergentes d = new Divergentes();
                    d.Produto = r.Produto;
                    d.Descricao = r.Descricao;
                    d.Unid = r.Unid;
                    d.Prateleira = r.Prateleira == etq.Prateleira ? r.Prateleira : "S: " + r.Prateleira + ", E: " + etq.Prateleira;
                    d.SaldoSistema = (decimal)r.SaldoAtual;
                    d.SaldoEtiqueta = Convert.ToDecimal(etq.SaldoAtual);
                    d.SaldoDivergente = Math.Round(Convert.ToDecimal(etq.SaldoAtual) - (decimal)r.SaldoAtual, 3);
                    d.Livre17Sistema = r.Livre17;
                    d.Livre17Etiqueta = Convert.ToDecimal(etq.Livre17);
                    d.ConvertidoEtiqueta = Convert.ToDecimal(etq.Convertido);

                    etq.SaldoAtual = (decimal)r.SaldoAtual;
                    var convertido = Classes.Conversor.GetConvertido(etq);
                    d.ConvertidoSistema = convertido.Convertido; //Math.Round(r.Livre17 == 0 ? 0 : (decimal)r.SaldoAtual / r.Livre17, 3);
                    d.ConvertidoDivergente = Math.Round(d.ConvertidoEtiqueta - d.ConvertidoSistema, 3);
                    d.OBS = "";

                    if (d.SaldoDivergente == 0)
                    {
                        dv.Add(d);
                        continue;
                    }

                    if (etq.Grupo == "10000000")
                    {
                        StringBuilder sb = new StringBuilder();
                        double total = 0;
                        var pvs = pvsFull.Where(p => p.Item == etq.Codigo).ToList();
                        foreach (var pv in pvs)
                        {
                            var cliente = pv.NomeFantasia.Length <= 6 ? pv.NomeFantasia : pv.NomeFantasia.Substring(0, 6);
                            sb.AppendLine($"PV{pv.NPedido} QT{pv.Quantidade} {cliente} {pv.DataEntrega.ToString("dd-MM")}");
                            total += pv.Quantidade;
                        }
                        sb.AppendLine($"Total {total}");
                        d.OBS = pvs.Count > 0 ? sb.ToString() : "";
                    }

                    if (etq.Grupo == "11000000")
                    {
                        StringBuilder sb = new StringBuilder(), sbOP = new StringBuilder();
                        bool pcp = false;
                        double total = 0;
                        var fes = feFull.Where(p => p.Produto == etq.Codigo & p.SaldoQtde > 0).ToList();
                        string E = etq.Codigo.Replace("PP1-", "PP2-");
                        var ops = opFull.Where(p => p.Produto == E).ToList();
                        foreach (var fe in fes)
                        {
                            sb.AppendLine($"{fe.NomeFantasia} >> {fe.SaldoQtde}");
                            total += fe.SaldoQtde;
                        }

                        if (total == 0)
                        {
                            fes = feFull.Where(p => p.SaldoQtde == (double)d.SaldoDivergente).ToList();
                            foreach (var fe in fes)
                            {
                                sb.AppendLine($"{fe.NomeFantasia} >> {fe.SaldoQtde} >> {fe.Produto}");
                                total += fe.SaldoQtde;
                                pcp = true;
                            }
                        }
                        if (ops.Count > 0)
                        {
                            foreach (var op in ops)
                            {
                                sbOP.AppendLine($"{op.NroOP} {op.Saldo}");
                            }
                        }
                        sb.AppendLine(sbOP.ToString().Trim());
                        string _pcp = pcp == true ? "COM PCP" : "";
                        sb.AppendLine($"Total {total} {_pcp}");
                        d.OBS = fes.Count > 0 ? sb.ToString() : "";
                    }

                    if (etq.Grupo != "10000000" & etq.Grupo != "11000000")
                    {
                        //se tiver NF
                        double total = 0;
                        StringBuilder sb = new StringBuilder();
                        var nfs = nfsFull.Where(p => p.Produto == etq.Codigo).ToList();// & p.Quantidade == (double)d.SaldoDivergente).ToList();
                        foreach (var nf in nfs)
                        {
                            sb.AppendLine($"{nf.NomeFantasia} >> QT{nf.Quantidade} >> NF{nf.NotaFiscal}");
                            total += nf.Quantidade;
                        }
                        sb = sb.ToString().Length == 0 ? sb.Clear() : sb.AppendLine($"Total {total}");
                        d.OBS = nfs.Count > 0 ? sb.ToString() : "";

                        //Se nao tiver nf, pesquisa se tem PC
                        if (total == 0)
                        {
                            var pcs = pcFull.Where(p => p.Produto == etq.Codigo & p.Entrega <= DateTime.Today.AddDays(7)).OrderBy(p => p.Pedido).ToList();
                            foreach (var pc in pcs)
                            {
                                sb.AppendLine($"PC{pc.Pedido} QT{pc.Saldo} DT{pc.Entrega.ToString("dd/MM/yy")}");
                                total += pc.Saldo;
                            }
                            sb.AppendLine($"Total {total}");
                            d.OBS = pcs.Count > 0 ? sb.ToString() : "";
                        }
                    }

                    dv.Add(d);
                }
            }

            if (b)
            {
                dgvDivergentes.DataSource = dv.OrderBy(p => p.Prateleira).ToList();
            }
        }

        private void brnImprimirDivergentes_Click(object sender, EventArgs e)
        {
            var resultFinal = ObterDivergentes(false);
            LancarNoExcell.Divergentes(resultFinal);
        }

        private void btnEstornar_Click(object sender, EventArgs e)
        {
            var row = dgvMovimentos.CurrentRow;
            Crud c = new Crud();
            var id = (int)row.Cells["Id"].Value;
            var cod = (string)row.Cells["Codigo"].Value;
            var emt = c.ListaEtiquetaMovimentos().Where(p => p.Id == id).FirstOrDefault();
            c.DeletarEtiquetaMovimento(emt);

            var etq = c.ListarEtiqueta().Where(p => p.Codigo == cod).FirstOrDefault();

            etq.SaldoAtual = emt.SaldoAtual;
            etq.Convertido = emt.Convertido;

            List<Etiqueta> letq = new List<Etiqueta>();

            letq.Add(etq);
            c.AlterarEtiquetas(letq);

            var sa = c.ListaSaldo().Where(p => p.Produto == cod).First();
            sa.SaldoAtual = (double)emt.SaldoAtual;
            c.AlteraSaldo(sa);




        }

        private void btnAddLinhas_Click(object sender, EventArgs e)
        {
            var qtd = nupAddLinhas.Value;
            if (qtd == 0)
            {
                return;
            }

            var row = dgvGerenciamento.Rows[0];

            if (row.Cells["OpcaoG"].Value == null)
            {
                return;
            }
            var opcao = row.Cells["OpcaoG"].Value.ToString();

            for (int i = 0; i < qtd; i++)
            {
                dgvGerenciamento.Rows.Add(row.Cells["OpcaoG"].Value = opcao);

            }
        }

        private void btnObservacoes_Click(object sender, EventArgs e)
        {
            var rows = dgvDivergentes.Rows;
            List<SaldoDivergente> lsd = new List<SaldoDivergente>();
            foreach (DataGridViewRow row in rows)
            {
                if (row.Cells["Produto"].Value == null)
                {
                    continue;
                }

                if (row.Cells["OBS"].Value.ToString() == "")
                {
                    continue;
                }

                SaldoDivergente sd = new SaldoDivergente();
                sd.Produto = row.Cells["Produto"].Value.ToString();
                sd.Divergente = (decimal)row.Cells["SaldoDivergente"].Value;
                sd.OBS = row.Cells["OBS"].Value.ToString();
                sd.Data = DateTime.Now;

                lsd.Add(sd);
            }

            Crud c = new Crud();
            c.AdicionarSaldoDivergente(lsd);

            var lsdX = c.ListarSaldoDivergente();

            var table = DeListParaTable.ConvertListToTableGeneric<SaldoDivergente>(lsdX);

            dgvSaldoDivergente.DataSource = table;


        }

        private void btnExcluirOBS_Click(object sender, EventArgs e)
        {
            var row = dgvSaldoDivergente.CurrentRow;
            var id = (int)row.Cells["Id"].Value;
            Crud c = new Crud();
            var lsd = c.ListarSaldoDivergente().Where(p => p.Id == id).ToList();
            c.DeletarSaldoDivergente(lsd);

            dgvSaldoDivergente.DataSource = c.ListarSaldoDivergente();
        }

        private void btnExcluiTodosOBSs_Click(object sender, EventArgs e)
        {
            Crud c = new Crud();
            //var lsd = c.ListarSaldoDivergente();
            c.TruncateSaldoDivergente();
            //c.DeletarSaldoDivergente(lsd);

            dgvSaldoDivergente.DataSource = c.ListarSaldoDivergente();
        }

        private void dgvDivergentes_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 12)
            {
                var linha = e.RowIndex;
                var valor = dgvDivergentes.Rows[linha].Cells["OBS"].Value.ToString().ToUpper();
                dgvDivergentes.Rows[linha].Cells["OBS"].Value = valor;

            }
            if (e.ColumnIndex == 4)
            {
                var row = dgvDivergentes.CurrentRow;
                var cod = row.Cells["Produto"].Value.ToString();
                var saldoS = (decimal)row.Cells["SaldoSistema"].Value;
                var livre17 = (decimal)row.Cells["Livre17Sistema"].Value;
                var saldoE = (decimal)row.Cells["SaldoEtiqueta"].Value;
                var convertidoE = (decimal)row.Cells["ConvertidoEtiqueta"].Value;

                Crud c = new Crud();
                var et = c.ListarEtiqueta().Where(p => p.Codigo == cod).First();
                et.SaldoAtual = saldoS;
                et.Livre17 = livre17;
                var convertidoS = Classes.Conversor.GetConvertido(et);
                row.Cells["ConvertidoSistema"].Value = convertidoS.Convertido;
                row.Cells["SaldoDivergente"].Value = Math.Round(saldoE - saldoS, 3);
                row.Cells["ConvertidoDivergente"].Value = Math.Round(convertidoE - convertidoS.Convertido, 2);
            }
        }

        private void btnEnviaParaAcerto_Click(object sender, EventArgs e)
        {
            EnviarParaAcerto();
        }

        /// <summary>
        /// Acerta o Saldo e envia para acerto no ERP Pronto. A linha selecionada.
        /// </summary>
        private void EnviarParaAcerto()
        {
            var r = dgvDivergentes.CurrentRow;


            Apontamento a;
            List<Apontamento> la = new List<Apontamento>();



            a = new Apontamento();
            a.OP = DateTime.Today.ToString("yyMMdd"); ;
            a.Produto = r.Cells["Produto"].Value.ToString();
            a.Descricao = r.Cells["Descricao"].Value.ToString() + " >> " + r.Cells["Prateleira"].Value.ToString();

            string metros = Math.Round(Convert.ToDecimal(r.Cells["ConvertidoDivergente"].Value.ToString()), 2).ToString("N2");
            a.Metros = metros;

            a.KG = r.Cells["SaldoDivergente"].Value.ToString().Replace("-", "");
            a.Data = DateTime.Today.ToString("dd/MM/yyyy");
            a.TM = r.Cells["SaldoDivergente"].Value.ToString().Contains("-") ? "560" : "260";
            a.Livre2 = "AcertoAutomatico";
            a.SaldoEtiqueta = Math.Round(Convert.ToDouble(r.Cells["SaldoEtiqueta"].Value), 3);
            la.Add(a);

            string lines = string.Empty;
            foreach (var al in la)
            {
                lines += (al.OP + "\t" + al.Produto + "\t" + al.Descricao + "\t" + al.Metros + "\t" + al.KG + "\t" + al.Data + "\t" + al.TM + "\t" + al.Livre2 + "\n");
            }
            File.AppendAllText($@"C:\Exports\ListaSalvaMovAcert.txt", lines);

            //atualizabanco de dados para nao retornar no grig
            Crud c = new Crud();
            foreach (var i in la)
            {
                var it = c.ListaSaldo().Where(p => p.Produto == i.Produto).First();
                it.SaldoAtual = i.SaldoEtiqueta;
                c.AlteraSaldo(it);
            }
        }

        private void btnAcertarConformeSistema_Click(object sender, EventArgs e)
        {
            var row = dgvDivergentes.CurrentRow;
            string cod = row.Cells["Produto"].Value.ToString();
            decimal saldoS = (decimal)row.Cells["SaldoSistema"].Value;
            decimal convertidoS = (decimal)row.Cells["ConvertidoSistema"].Value;

            Crud c = new Crud();
            var et = c.ListarEtiqueta().Where(p => p.Codigo == cod).ToList();
            var sa = c.ListaSaldo().Where(p => p.Produto == cod).ToList();

            et[0].SaldoAtual = saldoS;
            et[0].Convertido = convertidoS;
            c.AlterarEtiquetas(et);

            sa[0].SaldoAtual = (double)saldoS;
            c.AlteraSaldo(sa);

            ObterDivergentes();
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Text == "Inventario" & b == false)
            {
                ObterDivergentes();
                b = true;
            }
            if (tabControl1.SelectedTab.Text == "Saude" & s == false)
            {
                VerificarSaudeEtiquetas();
                s = true;
            }
        }

        private void VerificarSaudeEtiquetas()
        {
            ListaParaCriarEtiquetas();

        }

        private void ListaParaCriarEtiquetas()
        {
            Crud crud = new Crud();
            var saldos = (from s in crud.ListaSaldo().Where(p => p.SaldoAtual > 0 & p.Prateleira != "").ToList()
                          select new SaudeEtiqueta { Produto = s.Produto, Descricao = s.Descricao, SaldoAtual = s.SaldoAtual, Prateleira = s.Prateleira }
                        ).ToList();
            var etiqts = (from s in crud.ListarEtiqueta()
                          select new SaudeEtiqueta { Produto = s.Codigo, Descricao = s.Descricao, SaldoAtual = (double)s.SaldoAtual, Prateleira = s.Prateleira }
                            ).ToList();

            //DistinctBy(m => new { m.ID, m.Produto }).ToList();
            var intersect = saldos.Except(etiqts).ToList();

            var rable = DeListParaTable.ConvertListToTableGeneric(intersect);
            dgvSaude.DataSource = rable;
        }

        private void AddGerenciamento_Click(object sender, EventArgs e)
        {
            var produto = dgvSaude.CurrentRow.Cells["Produto"].Value.ToString();
            int index = dgvGerenciamento.Rows.Add();
            dgvGerenciamento.Rows[index].Cells["OpcaoG"].Value = "Criar";
            dgvGerenciamento.Rows[index].Cells["CodigoG"].Value = produto;
            lblSend.Text = $"{produto} enviado...";

        }

        private void AddTodosGerenciamneto_Click(object sender, EventArgs e)
        {
            var rows = dgvSaude.Rows;
            foreach (DataGridViewRow row in rows)
            {
                if (row.Cells["Produto"].Value == null)
                {
                    continue;
                }

                int index = dgvGerenciamento.Rows.Add();
                dgvGerenciamento.Rows[index].Cells["OpcaoG"].Value = "Criar";
                dgvGerenciamento.Rows[index].Cells["CodigoG"].Value = row.Cells["Produto"].Value;
            }
            lblSend.Text = $"Todos o itens já foram enviados para a aba Gerenciamento";
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            CarregaDados();
        }

        private void btnAcertarSistema_Click(object sender, EventArgs e)
        {
            EnviarParaAcerto();
            ObterDivergentes();
        }
    }
}
