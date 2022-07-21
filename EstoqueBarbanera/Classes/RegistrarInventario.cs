using Estoque.Entidade;
using Estoque.Data;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Estoque.DAO;
using Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;

namespace Estoque.Classes
{
    public class RegistrarInventario
    {

        internal static DataTable CarregaDataSet()
        {
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = @"C:\Export\";
                openFileDialog.Filter = "xlsx files (*.xlsx)|*.xlsx";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                }
            }

            var dtContent = GetDataTableFromExcel(filePath);
            return dtContent;

        }

        public  static DataTable GetDataTableFromExcel(string path, bool hasHeader = true)
        {
            using (var pck = new OfficeOpenXml.ExcelPackage())
            {
                using (var stream = File.OpenRead(path))
                {
                    pck.Load(stream);
                }
                var ws = pck.Workbook.Worksheets.First();
                DataTable tbl = new DataTable("X");
                //primeira linha
                foreach (var firstRowCell in ws.Cells[1, 1, 1, ws.Dimension.End.Column])
                {
                    tbl.Columns.Add(hasHeader ? firstRowCell.Text : string.Format("Column {0}", firstRowCell.Start.Column));
                }
                var startRow = hasHeader ? 2 : 1;
                //linhas
                for (int rowNum = startRow; rowNum <= ws.Dimension.End.Row; rowNum++)
                {
                    var wsRow = ws.Cells[rowNum, 1, rowNum, ws.Dimension.End.Column];

                    var ff = ws.Cells[rowNum, 6].ToString();

                    if (ws.Cells[rowNum, 6].ToString().Length == 0)
                    {

                        continue;
                    }
                    DataRow row = tbl.Rows.Add();
                    //celulas

                    //elimina celulas vazias
                    bool b = false;
                    foreach (var item in wsRow)
                    {
                        if (item.Address.StartsWith("A") | item.Address.StartsWith("B") | item.Address.StartsWith("D") | item.Address.StartsWith("F"))
                        {
                            if (item.Text.Length == 0)
                            {
                                b = true;
                            }
                        }
                    }
                    if (b == false)
                    {
                        foreach (ExcelRangeBase cell in wsRow)
                        {
                            row[cell.Start.Column - 1] = cell.Text.ToUpper();
                        }
                    }

                }
                var colunas = tbl.Columns;
                var hj = "";
                foreach (var item in colunas)
                {
                    hj = item.ToString();
                    break;
                }
                string expressao = $"{hj} <> ''";
                DataTable tbl2 = new DataTable("Y");
                foreach (var item in colunas)
                {
                    tbl2.Columns.Add(item.ToString());
                }
                var dr = tbl.Select(expressao);
                foreach (DataRow item in dr)
                {
                    tbl2.Rows.Add(item.ItemArray);
                }
                return tbl2;
            }
        }

        public static List<RegistroInventario> AplicarZerados(List<RegistroInventario> lir)
        {
            Crud crud = new Crud();
            crud.AdicionaRegistroInventario(lir);
            return crud.ListaRegistroInventario(lir.Count);

            // RegistroInventario ri = new RegistroInventario();
            // List<RegistroInventario> list = new List<RegistroInventario>();
            // var lines = dgv.Rows;
            // foreach (DataGridViewRow item in lines)
            // {
            //     try
            //     {
            //         if (item.Cells[0].Value.ToString().Length > 0 && item.Cells[5].Value.ToString().Length > 0)
            //         {
            //             var saldoAtual = item.Cells[3].Value.ToString().Split(':').Last().Trim().Replace(".", ",");
            //             var inventario = item.Cells[5].Value.ToString().Split(':').Last().Trim().Replace(".", ",");
            //             list.Add(new RegistroInventario
            //             {
            //                 Produto = (string)item.Cells[0].Value,
            //                 Descricao = (string)item.Cells[1].Value,
            //                 Unid = (string)item.Cells[3].Value.ToString().Split(':').First().Trim(),
            //                 SaldoAtual = Convert.ToDouble(saldoAtual),
            //                 Inventario = Convert.ToDouble(inventario),
            //                 DiaInventario = Convert.ToDateTime(DateTime.Today.ToString("yyyy-MM-dd")),
            //                 DiasMov = dtpInicio.Value.ToShortDateString() + " - " + dtpFim.Value.ToShortDateString(),
            //                 Acerto = Math.Round((Convert.ToDouble(saldoAtual) - Convert.ToDouble(inventario)) * -1, 4)

            //             }
            //             );
            //         }
            //     }
            //     catch (NullReferenceException)
            //     {


            //     }

            // }

            // Crud crud = new Crud();
            //return crud.Adiciona(list);


        }

        internal static object PesquisarInventarioSaldoDeTerceiro(ComboBox cbb, System.Windows.Forms.TextBox txt)
        {
            IQueryable<RegistroInventarioSaldoDeTerceiro> reg = null;
            using (var ctx = new EstoqueContext())
            {
                switch (cbb.Text)
                {
                    case "Id":

                        reg = from s in ctx.RegistrosInventarioSaldoDeTerceiro
                              where s.Id == Convert.ToInt32(txt.Text)
                              select s;
                        ; break;
                    case "Produto":

                        reg = from s in ctx.RegistrosInventarioSaldoDeTerceiro
                              where s.Produto.Contains(txt.Text)
                              select s;
                        ; break;
                    case "Descricao":

                        reg = from s in ctx.RegistrosInventarioSaldoDeTerceiro
                              where s.Descricao.Contains(txt.Text)
                              select s;
                        ; break;
                    case "Unid":

                        reg = from s in ctx.RegistrosInventarioSaldoDeTerceiro
                              where s.Unid.Contains(txt.Text)
                              select s;
                        ; break;
                    case "SaldoAtual":

                        reg = from s in ctx.RegistrosInventarioSaldoDeTerceiro
                              where s.SaldoAtual.ToString().Contains(txt.Text)
                              select s;
                        ; break;
                    case "Inventario":

                        reg = from s in ctx.RegistrosInventarioSaldoDeTerceiro
                              where s.Inventario.ToString().Contains(txt.Text)
                              select s;
                        ; break;
                    case "DiaInventario":

                        reg = from s in ctx.RegistrosInventarioSaldoDeTerceiro
                              where s.DiaInventario.ToString().Contains(txt.Text)
                              select s;
                        ; break;
                    case "Prateleira":

                        reg = from s in ctx.RegistrosInventarioSaldoDeTerceiro
                              where s.Prateleira.ToString().Contains(txt.Text)
                              select s;
                        ; break;
                    case "DeTerceiro":

                        reg = from s in ctx.RegistrosInventarioSaldoDeTerceiro
                              where s.DeTerceiro.ToString().Contains(txt.Text)
                              select s;
                        ; break;


                }
                List<RegistroInventarioSaldoDeTerceiro> ri = new List<RegistroInventarioSaldoDeTerceiro>();

                ri.AddRange(reg.ToList());

                return ri;
            }
        }

        public static void RemoverRegistroInventario(DataGridViewRow row)
        {

            using (var ctx = new EstoqueContext())
            {
                RegistroInventario list = new RegistroInventario
                {
                    Id = Convert.ToInt32(row.Cells[0].Value)
                };
                Crud crud = new Crud();
                crud.RemoverRegistroInventario(list);
            }

        }

        internal static DataTable RegistrarIventarioDepositosDeTerceiros(DataGridView dgv)
        {
            RegistroInventarioSaldoDeTerceiro ri = new RegistroInventarioSaldoDeTerceiro();
            List<RegistroInventarioSaldoDeTerceiro> list = new List<RegistroInventarioSaldoDeTerceiro>();
            var lines = dgv.Rows;
            foreach (DataGridViewRow item in lines)
            {
                try
                {
                    if (item.Cells[0].Value.ToString().Length > 0 && item.Cells[5].Value.ToString().Length > 0)
                    {
                        var saldoAtual = item.Cells[3].Value.ToString().Split(':').Last().Trim().Replace(".", ",");
                        list.Add(new RegistroInventarioSaldoDeTerceiro
                        {
                            Produto = (string)item.Cells[0].Value,
                            Descricao = (string)item.Cells[1].Value,
                            Prateleira = (string)item.Cells[2].Value.ToString().Split(new string[] { " C-" }, StringSplitOptions.None).FirstOrDefault().Trim(),
                            Unid = (string)item.Cells[3].Value.ToString().Split(':').First().Trim(),
                            SaldoAtual = Convert.ToDouble(saldoAtual),
                            DeTerceiro = Convert.ToDouble(item.Cells[4].Value),
                            Inventario = (string)item.Cells[5].Value,
                            DiaInventario = Convert.ToDateTime(DateTime.Today.ToString("yyyy-MM-dd")),
                            ClienteDeposito = (string)item.Cells[6].Value
                        }
                        );
                    }
                }
                catch (NullReferenceException)
                {
                }
            }
            Crud c = new Crud();
            c.AdicionaRegistroInventarioSaldoDeTerceiro(list);
            var l = c.ListaRegistroInventarioSaldoDeTerceiro(list.Count);

            DeListParaTable dlpt = new DeListParaTable();
            var tbl = dlpt.RegistroInventarioSaldoDeTerceiro(l);
            return tbl;
        }

        internal static void RemoverRegistroInventarioSaldoDeTerceiro(DataGridViewRow row)
        {
            using (var ctx = new EstoqueContext())
            {
                RegistroInventarioSaldoDeTerceiro list = new RegistroInventarioSaldoDeTerceiro()
                {
                    Id = Convert.ToInt32(row.Cells[0].Value)
                };
                Crud crud = new Crud();
                crud.RemoverRegistroInventarioSaldoDeTerceiro(list);
            }
        }

        public DataTable AplicarRegistros(DataGridView dgv, DateTimePicker dtpInicio, DateTimePicker dtpFim)
        {
            RegistroInventario ri = new RegistroInventario();
            List<RegistroInventario> list = new List<RegistroInventario>();
            var lines = dgv.Rows;
            foreach (DataGridViewRow item in lines)
            {
                if (item.Cells[0].Value != null)// & (item.Cells[5].Value != null & item.Cells[5].Value.ToString().Length > 0))
                {
                    if (item.Cells[5].Value != null & item.Cells[5].Value.ToString().Length > 0)// & (item.Cells[5].Value != null & item.Cells[5].Value.ToString().Length > 0))
                    {
                        var saldoAtual = item.Cells[3].Value.ToString().Split(':').Last().Trim().Replace(".", ",");
                        var inventario = item.Cells[5].Value.ToString().Split(':').Last().Trim().Replace(".", ",");
                        try
                        {

                            try
                            {
                                list.Add(new RegistroInventario
                                {
                                    Produto = (string)item.Cells[0].Value,
                                    Descricao = (string)item.Cells[1].Value,
                                    Prateleira = (string)item.Cells[2].Value.ToString().Split(new string[] { " C-" }, StringSplitOptions.None).FirstOrDefault().Trim(),
                                    Unid = (string)item.Cells[3].Value.ToString().Split(':').First().Trim(),

                                    SaldoAtual = Convert.ToDouble(saldoAtual),
                                    Inventario = Convert.ToDouble(inventario),
                                    DiaInventario = Convert.ToDateTime(DateTime.Today.ToString("yyyy-MM-dd")),
                                    DiasMov = dtpInicio.Value.ToShortDateString() + " - " + dtpFim.Value.ToShortDateString(),
                                    Acerto = Math.Round((Convert.ToDouble(saldoAtual) - Convert.ToDouble(inventario)) * -1, 4),
                                    ValorConvertido = Convert.ToDouble(item.Cells["ValorConvertido"].Value)
                                }
                            );
                            }
                            catch (ArgumentException)
                            {
                                list.Add(new RegistroInventario
                                {
                                    Produto = (string)item.Cells[0].Value,
                                    Descricao = (string)item.Cells[1].Value,
                                    Prateleira = (string)item.Cells[2].Value.ToString().Split(new string[] { " C-" }, StringSplitOptions.None).FirstOrDefault().Trim(),
                                    Unid = (string)item.Cells[3].Value.ToString().Split(':').First().Trim(),
                                    SaldoAtual = Convert.ToDouble(saldoAtual),
                                    Inventario = Convert.ToDouble(inventario),
                                    DiaInventario = Convert.ToDateTime(DateTime.Today.ToString("yyyy-MM-dd")),
                                    DiasMov = dtpInicio.Value.ToShortDateString() + " - " + dtpFim.Value.ToShortDateString(),
                                    Acerto = Math.Round((Convert.ToDouble(saldoAtual) - Convert.ToDouble(inventario)) * -1, 4)
                                });
                            }

                        }
                        catch (ArgumentException)
                        {
                            list.Add(new RegistroInventario
                            {
                                Produto = (string)item.Cells[0].Value,
                                Descricao = (string)item.Cells[1].Value,
                                Prateleira = (string)item.Cells[2].Value.ToString().Split(new string[] { " C-" }, StringSplitOptions.None).FirstOrDefault().Trim(),
                                Unid = (string)item.Cells[3].Value.ToString().Split(':').First().Trim(),
                                SaldoAtual = Convert.ToDouble(saldoAtual),
                                Inventario = Convert.ToDouble(inventario),
                                DiaInventario = Convert.ToDateTime(DateTime.Today.ToString("yyyy-MM-dd")),
                                DiasMov = dtpInicio.Value.ToShortDateString() + " - " + dtpFim.Value.ToShortDateString(),
                                Acerto = Math.Round((Convert.ToDouble(saldoAtual) - Convert.ToDouble(inventario)) * -1, 4)
                            });
                        }
                    }
                }
            }

            Crud c = new Crud();
            c.AdicionaRegistroInventario(list);
            var l = c.ListaRegistroInventario(list.Count);

            DeListParaTable dlpt = new DeListParaTable();
            var tbl = dlpt.ConvertListToDataTable(l.OrderBy(p=>p.Id).ToList());
            return tbl;
        }
        public DataTable AplicarRegistrosSucatas(DataGridView dgv)
        {
            var tempo = DateTime.Now;
            RegistroInventario ri = new RegistroInventario();
            List<RegistroInventario> list = new List<RegistroInventario>();
            var lines = dgv.Rows;
            foreach (DataGridViewRow item in lines)
            {
                if (item.Cells[0].Value != null)// & (item.Cells[5].Value != null & item.Cells[5].Value.ToString().Length > 0))
                {
                    if (item.Cells[5].Value != null & item.Cells[5].Value.ToString().Length > 0)// & (item.Cells[5].Value != null & item.Cells[5].Value.ToString().Length > 0))
                    {
                        var disponivel = item.Cells[4].Value.ToString().Trim().Replace(".", ",");
                        var inventario = item.Cells[5].Value.ToString().Trim().Replace(".", ",");

                        list.Add(new RegistroInventario
                        {
                            Produto = (string)item.Cells[0].Value,
                            Descricao = (string)item.Cells[1].Value,
                            Prateleira = (string)item.Cells[2].Value,
                            Unid = "KG",

                            SaldoAtual = Convert.ToDouble(disponivel),
                            Inventario = Convert.ToDouble(inventario),
                            DiaInventario = Convert.ToDateTime(DateTime.Today.ToString("yyyy-MM-dd")),
                            DiasMov = tempo.ToShortDateString() + " - " + tempo.ToShortDateString(),
                            Acerto = Math.Round((Convert.ToDouble(disponivel) - Convert.ToDouble(inventario)) * -1, 3),
                            ValorConvertido = 0
                        });
                    }
                }
            }

            Crud c = new Crud();
            c.AdicionaRegistroInventario(list);
            var l = c.ListaRegistroInventario(list.Count);

            DeListParaTable dlpt = new DeListParaTable();
            var tbl = dlpt.ConvertListToDataTable(l);
            return tbl;
        }

        internal static List<RegistroInventario> Pesquisar(ComboBox cbb, System.Windows.Forms.TextBox txt)
        {
            IQueryable<RegistroInventario> reg = null;
            using (var ctx = new EstoqueContext())
            {
                switch (cbb.Text)
                {
                    case "Id":

                        reg = from s in ctx.RegistrosInventario
                              where s.Id == Convert.ToInt32(txt.Text)
                              select s;
                        ; break;
                    case "Produto":

                        reg = from s in ctx.RegistrosInventario
                              where s.Produto.Contains(txt.Text)
                              select s;
                        ; break;
                    case "Descricao":

                        reg = from s in ctx.RegistrosInventario
                              where s.Descricao.Contains(txt.Text)
                              select s;
                        ; break;
                    case "Unid":

                        reg = from s in ctx.RegistrosInventario
                              where s.Unid.Contains(txt.Text)
                              select s;
                        ; break;
                    case "SaldoAtual":

                        reg = from s in ctx.RegistrosInventario
                              where s.SaldoAtual.ToString().Contains(txt.Text)
                              select s;
                        ; break;
                    case "Inventario":

                        reg = from s in ctx.RegistrosInventario
                              where s.Inventario.ToString().Contains(txt.Text)
                              select s;
                        ; break;
                    case "DiaInventario":

                        reg = from s in ctx.RegistrosInventario
                              where s.DiaInventario.ToString().Contains(txt.Text)
                              select s;
                        ; break;
                    case "Prateleira":

                        reg = from s in ctx.RegistrosInventario
                              where s.Prateleira.ToString().Contains(txt.Text)
                              select s;
                        ; break;



                }

                var xx = reg.ToList();
                List<RegistroInventario> ri = new List<RegistroInventario>();

                ri.AddRange(reg.ToList());

                return ri;
            }
        }


    }

}

