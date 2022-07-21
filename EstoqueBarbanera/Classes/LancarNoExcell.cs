using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Estoque.Entidade;
using System.Collections.Generic;
using Estoque.DAO;
using System.Drawing;
using static Estoque.Classes.Inventario;
using static Estoque.Classes.InativarItensParados;
using Estoque.Views;

namespace Estoque.Classes
{
    internal class LancarNoExcell
    {


        internal static void InativarItensParados(DataTable m)
        {
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                excelPackage.Workbook.Properties.Author = "Cid M Evangelista";
                excelPackage.Workbook.Properties.Title = "Meu Excel";

                var sheet = excelPackage.Workbook.Worksheets.Add("InativarItensParados");

                sheet.Name = "InativarItensParados";
                sheet.PrinterSettings.LeftMargin = 0.3m;
                sheet.PrinterSettings.RightMargin = 0.2m;
                //sheet.PrinterSettings.FitToPage = true;
                //sheet.PrinterSettings.FitToHeight = 150;
                //sheet.PrinterSettings.FitToWidth = 150;
                sheet.PrinterSettings.PaperSize = ePaperSize.A4;

                sheet.SetValue(1, 1, "Produto");
                sheet.SetValue(1, 2, "Descricao");
                sheet.SetValue(1, 3, "Unidade");
                sheet.SetValue(1, 4, "SaldoAtual");
                sheet.SetValue(1, 5, "Prateleira");
                sheet.SetValue(1, 6, "DiassemMovimento");
                sheet.SetValue(1, 7, "DataCadastro");
                sheet.SetValue(1, 8, "Cadastro_Ha_Dias");
                sheet.SetValue(1, 9, "Movimentos");
                sheet.SetValue(1, 10, "ListaMovimentos");
                sheet.SetValue(1, 11, "Grupo");
                sheet.SetValue(1, 12, "UltimoMovimento");
                sheet.SetValue(1, 13, "DiasUltimoMovimento");

                int line = 0;
                foreach (DataRow item in m.Rows)
                {
                    sheet.SetValue(line + 2, 1, item["Produto"]);
                    sheet.SetValue(line + 2, 2, item["Descricao"]);
                    sheet.SetValue(line + 2, 3, item["Unidade"]);
                    sheet.SetValue(line + 2, 4, item["SaldoAtual"]); //data cadastro
                    sheet.SetValue(line + 2, 5, item["Prateleira"]);
                    sheet.SetValue(line + 2, 6, item["DiassemMovimento"]);
                    sheet.SetValue(line + 2, 7, item["DataCadastro"]);
                    sheet.SetValue(line + 2, 8, item["Cadastro_Ha_Dias"]);
                    sheet.SetValue(line + 2, 9, item["Movimentos"]);
                    sheet.SetValue(line + 2, 10, item["ListaMovimentos"]);
                    sheet.SetValue(line + 2, 11, item["Grupo"]);
                    sheet.SetValue(line + 2, 12, item["UltimoMovimento"]);
                    sheet.SetValue(line + 2, 13, item["DiasUltimoMovimento"]);
                    ++line;
                }
                sheet.PrinterSettings.Orientation = eOrientation.Portrait;
                sheet.PrinterSettings.PaperSize = ePaperSize.A4;

                DateTime dts = DateTime.Today;
                ExcelHeaderFooterText footer = sheet.HeaderFooter.OddFooter;
                ExcelHeaderFooterText header = sheet.HeaderFooter.OddHeader;
                header.LeftAlignedText = "InativarItensParados";
                footer.RightAlignedText = dts.ToLongDateString();
                //footer.LeftAlignedText = dts.ToLongDateString();

                //

                var modelTable = sheet.Cells["A1:M" + (m.Rows.Count + 1)];

                sheet.View.ZoomScale = 110;
                sheet.View.PageBreakView = true;
                modelTable.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                sheet.Cells["A1:M1"].AutoFilter = true;
                sheet.View.FreezePanes(2, 1); //congela a primeira linha

                sheet.PrinterSettings.FooterMargin = 0.5M;
                sheet.PrinterSettings.HeaderMargin = 0.0M;
                sheet.PrinterSettings.TopMargin = 0.5M;
                sheet.PrinterSettings.BottomMargin = 0.5M;
                sheet.PrinterSettings.LeftMargin = 0.5M / 2.5M;
                sheet.PrinterSettings.FooterMargin = 0.5M / 2.5M;

                sheet.Cells["G:G"].Style.Numberformat.Format = "dd/MM/yyyy";
                sheet.Cells["L:L"].Style.Numberformat.Format = "dd/MM/yyyy";

                modelTable.Style.Font.Size = 8;

                modelTable.AutoFitColumns();

                modelTable.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                modelTable.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                sheet.Column(10).Style.WrapText = true;


                // Aqui você coloca a lógica que precisa escrever nas planilhas.

                string path = @"C:\Exports\InativarItensParados.xlsx";
                File.WriteAllBytes(path, excelPackage.GetAsByteArray());


                MessageBox.Show("MaterialParado pronta, Tempo Decorrido: ", "PRONTO!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                Process.Start(@"C:\Exports\InativarItensParados.xlsx");
            }
        }

        internal static void ManutencaoBarrasLongas(List<BarrasLongas> ManutencaoBarrasLongas)
        {
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                excelPackage.Workbook.Properties.Author = "Cid M Evangelista";
                excelPackage.Workbook.Properties.Title = "Meu Excel";

                var sheet = excelPackage.Workbook.Worksheets.Add("ManutencaoBarrasLongas");

                sheet.Name = "ManutencaoBarrasLongas";
                sheet.PrinterSettings.LeftMargin = 0.3m;
                sheet.PrinterSettings.RightMargin = 0.2m;
                //sheet.PrinterSettings.FitToPage = true;
                //sheet.PrinterSettings.FitToHeight = 150;
                //sheet.PrinterSettings.FitToWidth = 150;
                sheet.PrinterSettings.PaperSize = ePaperSize.A4;

                sheet.SetValue(1, 1, "Produto");
                sheet.SetValue(1, 2, "Descricao");
                sheet.SetValue(1, 3, "Prateleira");
                sheet.SetValue(1, 4, "SaldoAtual");
                sheet.SetValue(1, 5, "Metros");
                sheet.SetValue(1, 6, "DiasSemMovs");
                //sheet.SetValue(1, 7, "PedCompras");
                //sheet.SetValue(1, 8, "ConsPrevOS");
                sheet.SetValue(1, 7, "NovaPrat");

                int line = 0;
                foreach (var item in ManutencaoBarrasLongas.OrderBy(p => p.Prateleira))
                {
                    if (item.Produto != null)
                    {
                        sheet.SetValue(line + 2, 1, item.Produto);
                        sheet.SetValue(line + 2, 2, item.Descricao);
                        sheet.SetValue(line + 2, 3, item.Prateleira);
                        sheet.SetValue(line + 2, 4, item.SaldoAtual);
                        sheet.SetValue(line + 2, 5, item.Metros);
                        sheet.SetValue(line + 2, 6, item.DiasSemMovimentos);
                        //sheet.SetValue(line + 2, 7, item.PedCompras);
                        //sheet.SetValue(line + 2, 8, item.ConsPrevOS);
                        sheet.SetValue(line + 2, 7, item.NovaPrateleira);
                        ++line;
                    }
                }

                DateTime dts = DateTime.Today;
                ExcelHeaderFooterText footer = sheet.HeaderFooter.OddFooter;
                ExcelHeaderFooterText header = sheet.HeaderFooter.OddHeader;
                header.LeftAlignedText = "ManutencaoBarrasLongas";
                footer.RightAlignedText = dts.ToLongDateString();
                footer.LeftAlignedText = dts.ToString("dd/M/yyyy") + " - Linhas: " + ManutencaoBarrasLongas.Count();
                //

                var modelTable = sheet.Cells["A1:G" + (ManutencaoBarrasLongas.Count() + 1)];
                sheet.View.ZoomScale = 185;
                sheet.View.PageBreakView = true;
                sheet.Cells.Style.VerticalAlignment = ExcelVerticalAlignment.Center;


                sheet.PrinterSettings.FooterMargin = 0.5M;
                sheet.PrinterSettings.HeaderMargin = 0.0M;
                sheet.PrinterSettings.TopMargin = 0.5M;
                sheet.PrinterSettings.BottomMargin = 0.5M;
                sheet.PrinterSettings.LeftMargin = 0.5M / 2.5M;
                sheet.PrinterSettings.FooterMargin = 0.5M / 2.5M;

                modelTable.Style.Font.Size = 8;


                modelTable.AutoFitColumns();

                modelTable.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                modelTable.Style.Border.Left.Style = ExcelBorderStyle.Thin;



                // Aqui você coloca a lógica que precisa escrever nas planilhas.

                string path = @"C:\Exports\ManutencaoBarrasLongas.xlsx";
                File.WriteAllBytes(path, excelPackage.GetAsByteArray());


                Process.Start(path);
                //return path;
            }
        }

        internal static string PedidoDeCompraSaldosParaEliminar(List<PedidoNFs> listaMatarSaldo)
        {
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                excelPackage.Workbook.Properties.Author = "Cid M Evangelista";
                excelPackage.Workbook.Properties.Title = "Meu Excel";

                var sheet = excelPackage.Workbook.Worksheets.Add("ListaMatarSaldo");

                sheet.Name = "ListaMatarSaldo";
                sheet.PrinterSettings.LeftMargin = 0.3m;
                sheet.PrinterSettings.RightMargin = 0.2m;
                //sheet.PrinterSettings.FitToPage = true;
                //sheet.PrinterSettings.FitToHeight = 150;
                //sheet.PrinterSettings.FitToWidth = 150;
                sheet.PrinterSettings.PaperSize = ePaperSize.A4;

                sheet.SetValue(1, 1, "PedidoDeCompra");
                sheet.SetValue(1, 2, "Data");
                sheet.SetValue(1, 3, "NotaFiscal");
                sheet.SetValue(1, 4, "Fornecedor");
                sheet.SetValue(1, 5, "Produto");
                sheet.SetValue(1, 6, "Descricao");
                sheet.SetValue(1, 7, "QtdePedido");
                sheet.SetValue(1, 8, "QtdeEntregue");
                sheet.SetValue(1, 9, "LinhaPed");
                sheet.SetValue(1, 10, "Saldo");


                int line = 0;
                foreach (var item in listaMatarSaldo)
                {
                    if (item.Produto != null)
                    {
                        sheet.SetValue(line + 2, 1, item.PedidoDeCompra);
                        sheet.SetValue(line + 2, 2, item.Data.ToString("dd/MM/yyyy"));
                        sheet.SetValue(line + 2, 3, item.NotaFiscal);
                        sheet.SetValue(line + 2, 4, item.Fornecedor);
                        sheet.SetValue(line + 2, 5, item.Produto);
                        sheet.SetValue(line + 2, 6, item.Descricao);
                        sheet.SetValue(line + 2, 7, item.QtdePedido);
                        sheet.SetValue(line + 2, 8, item.QtdeEntregue);
                        sheet.SetValue(line + 2, 9, item.LinhaPed);
                        sheet.SetValue(line + 2, 10, item.Saldo);
                        ++line;
                    }
                }

                DateTime dts = DateTime.Today;
                ExcelHeaderFooterText footer = sheet.HeaderFooter.OddFooter;
                ExcelHeaderFooterText header = sheet.HeaderFooter.OddHeader;
                header.LeftAlignedText = "ListaMatarSaldo";
                footer.RightAlignedText = dts.ToLongDateString();
                footer.LeftAlignedText = dts.ToString("dd/M/yyyy") + " - Linhas: " + listaMatarSaldo.Count();
                //

                var modelTable = sheet.Cells["A1:J" + (listaMatarSaldo.Count() + 1)];
                sheet.View.ZoomScale = 120;
                sheet.View.PageBreakView = true;
                sheet.Cells.Style.VerticalAlignment = ExcelVerticalAlignment.Center;


                sheet.PrinterSettings.FooterMargin = 0.5M;
                sheet.PrinterSettings.HeaderMargin = 0.0M;
                sheet.PrinterSettings.TopMargin = 0.5M;
                sheet.PrinterSettings.BottomMargin = 0.5M;
                sheet.PrinterSettings.LeftMargin = 0.5M / 2.5M;
                sheet.PrinterSettings.FooterMargin = 0.5M / 2.5M;

                modelTable.Style.Font.Size = 8;


                modelTable.AutoFitColumns();

                modelTable.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                modelTable.Style.Border.Left.Style = ExcelBorderStyle.Thin;



                // Aqui você coloca a lógica que precisa escrever nas planilhas.

                string path = @"C:\Exports\ListaMatarSaldo.xlsx";
                File.WriteAllBytes(path, excelPackage.GetAsByteArray());


                //Process.Start(@"C:\Exports\ListaMatarSaldo.xlsx");
                return path;
            }
        }

        internal static void Divergentes(List<Divergentes> result)
        {
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                excelPackage.Workbook.Properties.Author = "Cid M Evangelista";
                excelPackage.Workbook.Properties.Title = "Meu Excel";

                var sheet = excelPackage.Workbook.Worksheets.Add("Divergentes");

                sheet.Name = "Divergentes";
                sheet.PrinterSettings.LeftMargin = 0.3m;
                sheet.PrinterSettings.RightMargin = 0.2m;
                //sheet.PrinterSettings.FitToPage = true;
                //sheet.PrinterSettings.FitToHeight = 150;
                //sheet.PrinterSettings.FitToWidth = 150;
                sheet.PrinterSettings.PaperSize = ePaperSize.A4;
                sheet.PrinterSettings.Orientation = eOrientation.Landscape;

                sheet.SetValue(1, 1, "Produto");
                sheet.SetValue(1, 2, "Descrição");
                sheet.SetValue(1, 3, "Unid");
                sheet.SetValue(1, 4, "Prateleira");
                sheet.SetValue(1, 5, "Saldo Sistema");
                sheet.SetValue(1, 6, "Saldo Etiqueta");
                sheet.SetValue(1, 7, "Saldo Divergente");
                sheet.SetValue(1, 8, "Livre17 Sistema");
                sheet.SetValue(1, 9, "Livre17 Etiqueta");
                sheet.SetValue(1, 10, "Convertido Sistema");
                sheet.SetValue(1, 11, "Convertido Etiqueta");
                sheet.SetValue(1, 12, "Convertido Divergente");

                sheet.Cells["A1:L1"].Style.WrapText = true;  //quebra de texto quebra de linha
                sheet.Cells["A1:L1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;  //quebra de texto quebra de linha


                int line = 0;
                foreach (var item in result)
                {
                    if (item.Produto != null)
                    {
                        sheet.SetValue(line + 2, 1, item.Produto);
                        sheet.SetValue(line + 2, 2, item.Descricao);
                        sheet.SetValue(line + 2, 3, item.Unid);
                        sheet.SetValue(line + 2, 4, item.Prateleira);
                        if (item.Prateleira.Contains("S: "))
                        {
                            sheet.Cells[line + 2, 4].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                            sheet.Cells[line + 2, 4].Style.Fill.BackgroundColor.SetColor(Color.Yellow);
                        }
                        sheet.SetValue(line + 2, 5, Math.Round(item.SaldoSistema, 3));
                        sheet.SetValue(line + 2, 6, Math.Round(item.SaldoEtiqueta, 3));
                        sheet.SetValue(line + 2, 7, Math.Round(item.SaldoDivergente, 3));

                        if (item.SaldoDivergente != 0)
                        {
                            sheet.Cells[line + 2, 7].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                            sheet.Cells[line + 2, 7].Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                        }
                        sheet.SetValue(line + 2, 8, item.Livre17Sistema);
                        sheet.SetValue(line + 2, 9, item.Livre17Etiqueta);
                        if (item.Livre17Sistema != item.Livre17Etiqueta)
                        {
                            sheet.Cells[line + 2, 8].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                            sheet.Cells[line + 2, 8].Style.Fill.BackgroundColor.SetColor(Color.Aquamarine);

                            sheet.Cells[line + 2, 9].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                            sheet.Cells[line + 2, 9].Style.Fill.BackgroundColor.SetColor(Color.Aquamarine);
                        }
                        sheet.SetValue(line + 2, 10, Math.Round(item.ConvertidoSistema, 3));
                        sheet.SetValue(line + 2, 11, Math.Round(item.ConvertidoEtiqueta, 3));
                        sheet.SetValue(line + 2, 12, Math.Round(item.ConvertidoDivergente, 3));
                        ++line;
                    }
                }

                sheet.Cells["E:G"].Style.Numberformat.Format = "###,##0.000";
                sheet.Cells["J:K"].Style.Numberformat.Format = "###,##0.000";

                DateTime dts = DateTime.Today;
                ExcelHeaderFooterText footer = sheet.HeaderFooter.OddFooter;
                ExcelHeaderFooterText header = sheet.HeaderFooter.OddHeader;
                header.LeftAlignedText = "Divergentes";
                footer.RightAlignedText = dts.ToLongDateString();
                footer.LeftAlignedText = dts.ToString("dd/MM/yyyy") + " - Linhas: " + result.Count;
                //

                var modelTable = sheet.Cells["A1:L" + (result.Count() + 1)];
                sheet.View.ZoomScale = 120;
                sheet.View.PageBreakView = true;
                sheet.Cells.Style.VerticalAlignment = ExcelVerticalAlignment.Center;


                sheet.PrinterSettings.FooterMargin = 0.5M;
                sheet.PrinterSettings.HeaderMargin = 0.0M;
                sheet.PrinterSettings.TopMargin = 0.5M;
                sheet.PrinterSettings.BottomMargin = 0.5M;
                sheet.PrinterSettings.LeftMargin = 0.5M / 2.5M;
                sheet.PrinterSettings.FooterMargin = 0.5M / 2.5M;

                modelTable.Style.Font.Size = 8;


                modelTable.AutoFitColumns();

                modelTable.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                modelTable.Style.Border.Left.Style = ExcelBorderStyle.Thin;



                // Aqui você coloca a lógica que precisa escrever nas planilhas.

                string path = @"C:\Exports\Divergentes.xlsx";
                File.WriteAllBytes(path, excelPackage.GetAsByteArray());

                Process.Start(@"C:\Exports\Divergentes.xlsx");
            }

        }

        internal static void InventarioSmart(decimal value, DataTable dt, Label r, Label q, DateTimePicker dtpInicio, DateTimePicker dtpFim)
        {
            List<RegistroInventario> ri = new List<RegistroInventario>();
            foreach (DataRow row in dt.Rows)
            {
                ri.Add(new RegistroInventario
                {
                    Produto = row["Produto"].ToString(),
                    Descricao = row["Descricao"].ToString(),
                    Prateleira = row["Prateleira"].ToString(),
                    Unid = row["Unid: SaldoAtual"].ToString(),
                    ValorConvertido = Convert.ToDouble(row["ValorConvertido"]),

                });
            }

            var riqtd = ri.Take((int)value);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                excelPackage.Workbook.Properties.Author = "Cid M Evangelista";
                excelPackage.Workbook.Properties.Title = "Meu Excel";

                var sheet = excelPackage.Workbook.Worksheets.Add("InventarioSmart");

                sheet.Name = "InventarioSmart";
                sheet.PrinterSettings.LeftMargin = 0.3m;
                sheet.PrinterSettings.RightMargin = 0.2m;
                //sheet.PrinterSettings.FitToPage = true;
                //sheet.PrinterSettings.FitToHeight = 150;
                //sheet.PrinterSettings.FitToWidth = 150;
                sheet.PrinterSettings.PaperSize = ePaperSize.A4;

                sheet.SetValue(1, 1, "Codigo");
                sheet.SetValue(1, 2, "Descrição");
                sheet.SetValue(1, 3, "Prateleira");
                sheet.SetValue(1, 4, "Saldo Kg");
                sheet.SetValue(1, 5, "Saldo M");
                sheet.SetValue(1, 6, "Inventario");


                int line = 0;
                foreach (var item in riqtd)
                {
                    if (item.Produto != null)
                    {
                        sheet.SetValue(line + 2, 1, item.Produto);
                        sheet.SetValue(line + 2, 2, item.Descricao);
                        sheet.SetValue(line + 2, 3, item.Prateleira);
                        sheet.SetValue(line + 2, 4, item.Unid);
                        sheet.SetValue(line + 2, 5, (item.ValorConvertido == 0 ? "" : item.ValorConvertido.ToString()));
                        ++line;
                    }
                }

                sheet.SetValue(line + 5, 2, r.Text);
                sheet.Cells[line + 5, 2].Style.WrapText = true;
                sheet.SetValue(line + 6, 2, "De " + dtpInicio.Value.ToString("dd/M/yyyy") + " até " + dtpFim.Value.ToString("dd/M/yyyy") + " - Linhas: " + value);
                sheet.SetValue(line + 7, 2, q.Text);




                DateTime dts = DateTime.Today;
                ExcelHeaderFooterText footer = sheet.HeaderFooter.OddFooter;
                ExcelHeaderFooterText header = sheet.HeaderFooter.OddHeader;
                header.LeftAlignedText = "InventarioSmart";
                footer.RightAlignedText = dts.ToLongDateString();
                footer.LeftAlignedText = "De " + dtpInicio.Value.ToString("dd/M/yyyy") + " até " + dtpFim.Value.ToString("dd/M/yyyy") + " - Linhas: " + value;
                //

                var modelTable = sheet.Cells["A1:F" + (riqtd.Count() + 1 + 6)];
                sheet.View.ZoomScale = 120;
                sheet.View.PageBreakView = true;
                sheet.Cells.Style.VerticalAlignment = ExcelVerticalAlignment.Center;


                sheet.PrinterSettings.FooterMargin = 0.5M;
                sheet.PrinterSettings.HeaderMargin = 0.0M;
                sheet.PrinterSettings.TopMargin = 0.5M;
                sheet.PrinterSettings.BottomMargin = 0.5M;
                sheet.PrinterSettings.LeftMargin = 0.5M / 2.5M;
                sheet.PrinterSettings.FooterMargin = 0.5M / 2.5M;

                modelTable.Style.Font.Size = 8;


                modelTable.AutoFitColumns();

                modelTable.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                modelTable.Style.Border.Left.Style = ExcelBorderStyle.Thin;



                // Aqui você coloca a lógica que precisa escrever nas planilhas.

                string path = @"C:\Exports\InventarioSmart.xlsx";
                File.WriteAllBytes(path, excelPackage.GetAsByteArray());

                sw.Stop();
                MessageBox.Show("Rotativo pronta, Tempo Decorrido: " + sw.Elapsed, "PRONTO!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                Process.Start(@"C:\Exports\InventarioSmart.xlsx");
            }

        }

        internal static void MaterialParado(List<MaterialParado> m)
        {
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                excelPackage.Workbook.Properties.Author = "Cid M Evangelista";
                excelPackage.Workbook.Properties.Title = "Meu Excel";




                var sheet = excelPackage.Workbook.Worksheets.Add("MaterialParado");

                sheet.Name = "MaterialParado";
                sheet.PrinterSettings.LeftMargin = 0.3m;
                sheet.PrinterSettings.RightMargin = 0.2m;
                //sheet.PrinterSettings.FitToPage = true;
                //sheet.PrinterSettings.FitToHeight = 150;
                //sheet.PrinterSettings.FitToWidth = 150;
                sheet.PrinterSettings.PaperSize = ePaperSize.A4;

                sheet.SetValue(1, 1, "Produto");
                sheet.SetValue(1, 2, "Descricao");
                sheet.SetValue(1, 3, "Unid");

                sheet.SetValue(1, 4, "SaldoAtual");
                sheet.SetValue(1, 5, "Disponivel");
                sheet.SetValue(1, 6, "INVENTARIADO");

                sheet.SetValue(1, 7, "Prateleira");
                sheet.SetValue(1, 8, "PedVendas");
                sheet.SetValue(1, 9, "PrevFabric");
                sheet.SetValue(1, 10, "Pedido");
                sheet.SetValue(1, 11, "DataPedido");
                sheet.SetValue(1, 12, "DataEntrega");
                sheet.SetValue(1, 13, "Quantidade");
                sheet.SetValue(1, 14, "CodigoCliente");



                int line = 0;
                foreach (var item in m)
                {

                    sheet.SetValue(line + 2, 1, item.Produto);
                    sheet.SetValue(line + 2, 2, item.Descricao);
                    sheet.SetValue(line + 2, 3, item.Unid);
                    sheet.SetValue(line + 2, 4, item.Disponivel);
                    sheet.SetValue(line + 2, 5, item.SaldoAtual);
                    sheet.SetValue(line + 2, 6, "");

                    sheet.SetValue(line + 2, 7, item.Prateleira);
                    sheet.SetValue(line + 2, 8, item.PedVendas);
                    sheet.SetValue(line + 2, 9, item.PrevFabric);
                    sheet.SetValue(line + 2, 10, item.Pedido);
                    sheet.SetValue(line + 2, 11, item.DataPedido);
                    sheet.SetValue(line + 2, 12, item.DataEntrega);
                    sheet.SetValue(line + 2, 13, item.Quantidade);
                    sheet.SetValue(line + 2, 14, item.CodigoCliente);

                    ++line;

                }


                sheet.PrinterSettings.Orientation = eOrientation.Landscape;
                sheet.PrinterSettings.PaperSize = ePaperSize.A4;



                DateTime dts = DateTime.Today;
                ExcelHeaderFooterText footer = sheet.HeaderFooter.OddFooter;
                ExcelHeaderFooterText header = sheet.HeaderFooter.OddHeader;
                //header.LeftAlignedText = "Codigo                         Descrição                                                                       Prat                   Kg                  MT            Invt               Origem:Data_TM_Doc_QTD_Operador_Hora";
                footer.RightAlignedText = dts.ToLongDateString();

                //

                var modelTable = sheet.Cells["A:N" + (m.Count + 1)];
                sheet.View.ZoomScale = 110;
                sheet.View.PageBreakView = true;
                sheet.Cells.Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                sheet.PrinterSettings.FooterMargin = 0.5M;
                sheet.PrinterSettings.HeaderMargin = 0.0M;
                sheet.PrinterSettings.TopMargin = 0.5M;
                sheet.PrinterSettings.BottomMargin = 0.5M;
                sheet.PrinterSettings.LeftMargin = 0.5M / 2.5M;
                sheet.PrinterSettings.FooterMargin = 0.5M / 2.5M;

                sheet.Cells["K:L"].Style.Numberformat.Format = "dd/MM/yyyy";

                modelTable.Style.Font.Size = 8;



                modelTable.AutoFitColumns();

                modelTable.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                modelTable.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                sheet.Column(14).Style.WrapText = true;


                // Aqui você coloca a lógica que precisa escrever nas planilhas.

                string path = @"C:\Exports\MaterialParado.xlsx";
                File.WriteAllBytes(path, excelPackage.GetAsByteArray());


                MessageBox.Show("MaterialParado pronta, Tempo Decorrido: ", "PRONTO!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                Process.Start(@"C:\Exports\MaterialParado.xlsx");
            }
        }

        internal static void LimparPrateleiraComSaldoZeroMinimoZero(List<ClassParaExcell> cpe)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                excelPackage.Workbook.Properties.Author = "Cid M Evangelista";
                excelPackage.Workbook.Properties.Title = "Meu Excel";
                var sheet = excelPackage.Workbook.Worksheets.Add("LimparPrateleiraComSaldoZeroMinimoZero");

                sheet.Name = "LimparPrateleiraComSaldoZeroMinimoZero";
                sheet.PrinterSettings.LeftMargin = 0.3m;
                sheet.PrinterSettings.RightMargin = 0.2m;
                sheet.PrinterSettings.PaperSize = ePaperSize.A4;

                sheet.SetValue(1, 1, "Codigo");
                sheet.SetValue(1, 2, "Descrição");
                sheet.SetValue(1, 3, "Prateleira");
                sheet.SetValue(1, 4, "Saldo Kg");
                sheet.SetValue(1, 5, "Saldo M");
                sheet.SetValue(1, 6, "Inventario");
                sheet.SetValue(1, 7, "OBS");

                //UNIR DS COM LISTA TXT

                //
                int line = 0;
                foreach (var item in cpe)
                {
                    if (item.Codigo != null)
                    {
                        sheet.SetValue(line + 2, 1, item.Codigo);
                        sheet.SetValue(line + 2, 2, item.Descricao);
                        sheet.SetValue(line + 2, 3, item.Prateleira);
                        //sheet.SetValue(line + 2, 4, item.SaldoKg);
                        if (item.Unid.Contains(":"))
                        {
                            sheet.SetValue(line + 2, 4, item.Unid);
                        }
                        else
                        {
                            sheet.SetValue(line + 2, 4, item.Unid + ": " + Math.Round(item.SaldoKg, 3));
                        }

                        sheet.SetValue(line + 2, 5, Math.Round(item.SaldoM, 3));

                        ++line;
                    }
                }



                DateTime dts = DateTime.Today;
                ExcelHeaderFooterText footer = sheet.HeaderFooter.OddFooter;
                ExcelHeaderFooterText header = sheet.HeaderFooter.OddHeader;
                header.LeftAlignedText = "LimparPrateleiraComSaldoZeroMinimoZero";
                footer.RightAlignedText = dts.ToLongDateString();
                footer.LeftAlignedText = "Linhas: " + cpe.Count;

                //

                var modelTable = sheet.Cells["A1:G" + (cpe.Count + 1)];
                sheet.View.ZoomScale = 120;
                sheet.View.PageBreakView = true;
                sheet.Cells.Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                //sheet.Column(7).ColumnMax = 40;

                sheet.PrinterSettings.FooterMargin = 0.5M;
                sheet.PrinterSettings.HeaderMargin = 0.0M;
                sheet.PrinterSettings.TopMargin = 0.5M;
                sheet.PrinterSettings.BottomMargin = 0.5M;
                sheet.PrinterSettings.LeftMargin = 0.5M / 2.5M;
                sheet.PrinterSettings.FooterMargin = 0.5M / 2.5M;

                modelTable.Style.Font.Size = 8;
                sheet.Column(7).Style.Font.Size = 5;


                modelTable.AutoFitColumns();

                modelTable.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                modelTable.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                sheet.Column(7).Style.WrapText = true;

                //string path2 = @"C:\Exports\Inventario2.xlsx";
                //File.WriteAllBytes(path2, excelPackage.GetAsByteArray());
                //Process.Start(@"C:\Exports\Inventario2.xlsx");

                string path = @"C:\Exports\LimparPrateleiraComSaldoZeroMinimoZero.xlsx";
                File.WriteAllBytes(path, excelPackage.GetAsByteArray());

                sw.Stop();
                MessageBox.Show("Inventario pronta, Tempo Decorrido: " + sw.Elapsed, "PRONTO!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                Process.Start(@"C:\Exports\LimparPrateleiraComSaldoZeroMinimoZero.xlsx");
            }
        }

        internal static void InventarioPorPrateleira(DataRowCollection rows)
        {

            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                excelPackage.Workbook.Properties.Author = "Cid M Evangelista";
                excelPackage.Workbook.Properties.Title = "Meu Excel";

                var sheet = excelPackage.Workbook.Worksheets.Add("InventarioPorPrateleira");

                sheet.Name = "InventarioPorPrateleira";
                sheet.PrinterSettings.LeftMargin = 0.3m;
                sheet.PrinterSettings.RightMargin = 0.2m;
                //sheet.PrinterSettings.FitToPage = true;
                //sheet.PrinterSettings.FitToHeight = 150;
                //sheet.PrinterSettings.FitToWidth = 150;
                sheet.PrinterSettings.PaperSize = ePaperSize.A4;

                sheet.SetValue(1, 1, "Produto");
                sheet.SetValue(1, 2, "Descrição");
                sheet.SetValue(1, 3, "Prateleira");
                sheet.SetValue(1, 4, "Unid");
                sheet.SetValue(1, 5, "SaldoAtual");
                sheet.SetValue(1, 6, "Convertido");
                sheet.SetValue(1, 7, "Inventario");


                int line = 0;
                foreach (DataRow item in rows)
                {
                    if (item[0] != null)
                    {
                        sheet.SetValue(line + 2, 1, item[0]);
                        sheet.SetValue(line + 2, 2, item[1]);
                        sheet.SetValue(line + 2, 3, item[2]);
                        sheet.SetValue(line + 2, 4, item[3]);
                        sheet.SetValue(line + 2, 5, item[4]);
                        sheet.SetValue(line + 2, 6, item[5]);

                        ++line;
                    }
                }


                DateTime dts = DateTime.Today;
                ExcelHeaderFooterText footer = sheet.HeaderFooter.OddFooter;
                ExcelHeaderFooterText header = sheet.HeaderFooter.OddHeader;
                header.LeftAlignedText = "InventarioPorPrateleira";
                footer.RightAlignedText = dts.ToLongDateString();
                footer.LeftAlignedText = "Linhas: " + rows.Count;
                //

                var modelTable = sheet.Cells["A1:G" + (rows.Count + 1)];
                sheet.View.ZoomScale = 120;
                sheet.View.PageBreakView = true;
                sheet.Cells.Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                //sheet.Column(7).ColumnMax = 40;




                sheet.PrinterSettings.FooterMargin = 0.5M;
                sheet.PrinterSettings.HeaderMargin = 0.0M;
                sheet.PrinterSettings.TopMargin = 0.5M;
                sheet.PrinterSettings.BottomMargin = 0.5M;
                sheet.PrinterSettings.LeftMargin = 0.5M / 2.5M;
                sheet.PrinterSettings.FooterMargin = 0.5M / 2.5M;

                modelTable.Style.Font.Size = 8;
                // sheet.Column(7).Style.Font.Size = 5;


                modelTable.AutoFitColumns();

                modelTable.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                modelTable.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                sheet.Column(7).Style.WrapText = true;


                // Aqui você coloca a lógica que precisa escrever nas planilhas.

                string path = @"C:\Exports\InventarioPorPrateleira.xlsx";
                File.WriteAllBytes(path, excelPackage.GetAsByteArray());


                Process.Start(@"C:\Exports\InventarioPorPrateleira.xlsx");
            }

        }

        internal static void ListaLimparPratelira(List<DataRow> list)
        {
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                excelPackage.Workbook.Properties.Author = "Cid M Evangelista";
                excelPackage.Workbook.Properties.Title = "Meu Excel";

                var sheet = excelPackage.Workbook.Worksheets.Add("LimparPrateleira");

                sheet.Name = "LimparPrateleira";
                sheet.PrinterSettings.LeftMargin = 0.3m;
                sheet.PrinterSettings.RightMargin = 0.2m;
                //sheet.PrinterSettings.FitToPage = true;
                //sheet.PrinterSettings.FitToHeight = 150;
                //sheet.PrinterSettings.FitToWidth = 150;
                sheet.PrinterSettings.PaperSize = ePaperSize.A4;

                sheet.SetValue(1, 1, "Produto");
                sheet.SetValue(1, 2, "Descrição");
                sheet.SetValue(1, 3, "UND");
                sheet.SetValue(1, 4, "Grupo");
                sheet.SetValue(1, 5, "SaldoAtual");
                sheet.SetValue(1, 6, "Prateleira");
                sheet.SetValue(1, 7, "DiasSMovs");
                sheet.SetValue(1, 8, "VzMovis");


                int line = 0;
                foreach (var item in list)
                {
                    if (item[0] != null)
                    {
                        sheet.SetValue(line + 2, 1, item[0]);
                        sheet.SetValue(line + 2, 2, item[1]);
                        sheet.SetValue(line + 2, 3, item[2]);
                        sheet.SetValue(line + 2, 4, item[3]);
                        sheet.SetValue(line + 2, 5, item[4]);
                        sheet.SetValue(line + 2, 6, item[5]);
                        sheet.SetValue(line + 2, 7, item[7]);
                        sheet.SetValue(line + 2, 8, item[6]);

                        ++line;
                    }
                }


                DateTime dts = DateTime.Today;
                ExcelHeaderFooterText footer = sheet.HeaderFooter.OddFooter;
                ExcelHeaderFooterText header = sheet.HeaderFooter.OddHeader;
                header.LeftAlignedText = "LimparPrateleira";
                footer.RightAlignedText = dts.ToLongDateString();
                footer.LeftAlignedText = "Linhas: " + list.Count;
                //

                var modelTable = sheet.Cells["A1:H" + (list.Count + 1)];
                sheet.View.ZoomScale = 120;
                sheet.View.PageBreakView = true;
                sheet.Cells.Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                //sheet.Column(7).ColumnMax = 40;




                sheet.PrinterSettings.FooterMargin = 0.5M;
                sheet.PrinterSettings.HeaderMargin = 0.0M;
                sheet.PrinterSettings.TopMargin = 0.5M;
                sheet.PrinterSettings.BottomMargin = 0.5M;
                sheet.PrinterSettings.LeftMargin = 0.5M / 2.5M;
                sheet.PrinterSettings.FooterMargin = 0.5M / 2.5M;

                modelTable.Style.Font.Size = 8;
                // sheet.Column(7).Style.Font.Size = 5;


                modelTable.AutoFitColumns();

                modelTable.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                modelTable.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                sheet.Column(7).Style.WrapText = true;


                // Aqui você coloca a lógica que precisa escrever nas planilhas.

                string path = @"C:\Exports\LimparPrateleira.xlsx";
                File.WriteAllBytes(path, excelPackage.GetAsByteArray());


                Process.Start(@"C:\Exports\LimparPrateleira.xlsx");
            }
        }

        internal static void Rotativo(List<RegistroInventario> r)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                excelPackage.Workbook.Properties.Author = "Cid M Evangelista";
                excelPackage.Workbook.Properties.Title = "Meu Excel";




                var sheet = excelPackage.Workbook.Worksheets.Add("Rotativo");

                sheet.Name = "Rotativo";
                sheet.PrinterSettings.LeftMargin = 0.3m;
                sheet.PrinterSettings.RightMargin = 0.2m;
                //sheet.PrinterSettings.FitToPage = true;
                //sheet.PrinterSettings.FitToHeight = 150;
                //sheet.PrinterSettings.FitToWidth = 150;
                sheet.PrinterSettings.PaperSize = ePaperSize.A4;

                sheet.SetValue(1, 1, "Codigo");
                sheet.SetValue(1, 2, "Descrição");
                sheet.SetValue(1, 3, "Prateleira");
                sheet.SetValue(1, 4, "Saldo Kg");
                sheet.SetValue(1, 5, "Saldo M");
                sheet.SetValue(1, 6, "Inventario");


                int line = 0;
                foreach (var item in r)
                {
                    if (item.Produto != null)
                    {
                        sheet.SetValue(line + 2, 1, item.Produto);
                        sheet.SetValue(line + 2, 2, item.Descricao);
                        sheet.SetValue(line + 2, 3, item.Prateleira + (item.Livre17 == 0 ? "" : " C-" + item.Livre17));
                        sheet.SetValue(line + 2, 4, item.Unid + ": " + item.SaldoAtual);
                        sheet.SetValue(line + 2, 5, (item.ValorConvertido == 0 ? "" : item.ValorConvertido.ToString()));
                        ++line;
                    }
                }


                DateTime dts = DateTime.Today;
                ExcelHeaderFooterText footer = sheet.HeaderFooter.OddFooter;
                ExcelHeaderFooterText header = sheet.HeaderFooter.OddHeader;
                header.LeftAlignedText = "Rotativo";
                footer.RightAlignedText = dts.ToLongDateString();
                footer.LeftAlignedText = "Linhas: " + r.Count;
                //

                var modelTable = sheet.Cells["A1:F" + (r.Count + 1)];
                sheet.View.ZoomScale = 120;
                sheet.View.PageBreakView = true;
                sheet.Cells.Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                //sheet.Column(7).ColumnMax = 40;




                sheet.PrinterSettings.FooterMargin = 0.5M;
                sheet.PrinterSettings.HeaderMargin = 0.0M;
                sheet.PrinterSettings.TopMargin = 0.5M;
                sheet.PrinterSettings.BottomMargin = 0.5M;
                sheet.PrinterSettings.LeftMargin = 0.5M / 2.5M;
                sheet.PrinterSettings.FooterMargin = 0.5M / 2.5M;

                // modelTable.Style.Font.Size = 8;
                sheet.Column(7).Style.Font.Size = 5;


                modelTable.AutoFitColumns();

                modelTable.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                modelTable.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                sheet.Column(7).Style.WrapText = true;


                // Aqui você coloca a lógica que precisa escrever nas planilhas.

                string path = @"C:\Exports\Rotativo.xlsx";
                File.WriteAllBytes(path, excelPackage.GetAsByteArray());

                sw.Stop();
                MessageBox.Show("Rotativo pronta, Tempo Decorrido: " + sw.Elapsed, "PRONTO!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                Process.Start(@"C:\Exports\Rotativo.xlsx");
            }
        }

        internal static void InventariarForaDeEstoqueComSaldo(List<ForaDeEstoque2> list)
        {
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                excelPackage.Workbook.Properties.Author = "Cid M Evangelista";
                excelPackage.Workbook.Properties.Title = "Meu Excel";
                string nome = "InventariarForaDeEstoqueComSald";
                var sheet = excelPackage.Workbook.Worksheets.Add(nome);

                sheet.Name = nome;
                sheet.PrinterSettings.LeftMargin = 0.3m;
                sheet.PrinterSettings.RightMargin = 0.2m;
                //sheet.PrinterSettings.FitToPage = true;
                //sheet.PrinterSettings.FitToHeight = 150;
                //sheet.PrinterSettings.FitToWidth = 150;
                sheet.PrinterSettings.PaperSize = ePaperSize.A4;

                sheet.SetValue(1, 1, "Produto");
                sheet.SetValue(1, 2, "Descricao");
                sheet.SetValue(1, 3, "Prateleira");
                sheet.SetValue(1, 4, "SaldoAtual");
                sheet.SetValue(1, 5, "Qtd Fornec");
                sheet.SetValue(1, 6, "Inventario");
                sheet.SetValue(1, 7, "Fornecedor");
                sheet.SetValue(1, 8, "DocFiscal");
                sheet.SetValue(1, 9, "TM");
                sheet.SetValue(1, 10, "Data");

                int line = 0;
                foreach (var item in list.OrderBy(p => p.Data).OrderBy(p => p.Produto))
                {
                    sheet.SetValue(line + 2, 1, item.Produto);
                    sheet.SetValue(line + 2, 2, item.Descricao);
                    sheet.SetValue(line + 2, 3, item.Prateleira);
                    sheet.SetValue(line + 2, 4, item.Unidade + ": " + item.SaldoFisico);
                    sheet.SetValue(line + 2, 5, item.ForaDeEstoque);
                    sheet.SetValue(line + 2, 6, "");
                    sheet.SetValue(line + 2, 7, item.NomeFantasia);
                    sheet.SetValue(line + 2, 8, item.DocFiscal);
                    sheet.SetValue(line + 2, 9, item.TM);
                    sheet.SetValue(line + 2, 10, item.Data.Year == 1 ? "" : item.Data.ToString("dd/MM/yyyy"));
                    ++line;
                }


                sheet.PrinterSettings.Orientation = eOrientation.Landscape;
                sheet.PrinterSettings.PaperSize = ePaperSize.A4;



                DateTime dts = DateTime.Today;
                ExcelHeaderFooterText footer = sheet.HeaderFooter.OddFooter;
                ExcelHeaderFooterText header = sheet.HeaderFooter.OddHeader;
                header.LeftAlignedText = nome;
                footer.RightAlignedText = dts.ToLongDateString();

                //

                var modelTable = sheet.Cells["A1:J" + (list.Count + 1)];
                sheet.View.ZoomScale = 110;
                sheet.View.PageBreakView = true;
                sheet.Cells.Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                sheet.PrinterSettings.FooterMargin = 0.5M;
                sheet.PrinterSettings.HeaderMargin = 0.0M;
                sheet.PrinterSettings.TopMargin = 0.5M;
                sheet.PrinterSettings.BottomMargin = 0.5M;
                sheet.PrinterSettings.LeftMargin = 0.5M / 2.5M;
                sheet.PrinterSettings.FooterMargin = 0.5M / 2.5M;

                sheet.Cells["J:J"].Style.Numberformat.Format = "dd/MM/yyyy";

                modelTable.Style.Font.Size = 8;

                modelTable.AutoFitColumns();

                modelTable.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                modelTable.Style.Border.Left.Style = ExcelBorderStyle.Thin;

                //SemQTDFornec(list, excelPackage, nome);
                SoSucata(list, excelPackage, nome);
                DemaisItens(list, excelPackage, nome);

                string path = $@"C:\Exports\{nome}.xlsx";
                File.WriteAllBytes(path, excelPackage.GetAsByteArray());

                Process.Start($@"C:\Exports\{nome}.xlsx");
            }
        }
        internal static string InventariarForaDeEstoqueComSaldo(List<ForaDeEstoque3> list)
        {
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                excelPackage.Workbook.Properties.Author = "Cid M Evangelista";
                excelPackage.Workbook.Properties.Title = "Meu Excel";
                string nome = "ForaDeEstoqueComSaldo";
                var sheet = excelPackage.Workbook.Worksheets.Add(nome);

                sheet.Name = nome;
                sheet.PrinterSettings.LeftMargin = 0.3m;
                sheet.PrinterSettings.RightMargin = 0.2m;
                //sheet.PrinterSettings.FitToPage = true;
                //sheet.PrinterSettings.FitToHeight = 150;
                //sheet.PrinterSettings.FitToWidth = 150;
                sheet.PrinterSettings.PaperSize = ePaperSize.A4;

                sheet.SetValue(1, 1, "Produto");
                sheet.SetValue(1, 2, "Descricao");
                sheet.SetValue(1, 3, "SaldoQtde");
                sheet.SetValue(1, 4, "QtdeNf");
                sheet.SetValue(1, 5, "Data");
                sheet.SetValue(1, 6, "DocFistal");
                sheet.SetValue(1, 7, "NomeFantasia");

                int line = 0;
                foreach (var item in list)
                {
                    sheet.SetValue(line + 2, 1, item.Produto);
                    sheet.SetValue(line + 2, 2, item.Descricao);
                    sheet.SetValue(line + 2, 3, item.SaldoQtde);
                    sheet.SetValue(line + 2, 4, item.QtdeNf);
                    sheet.SetValue(line + 2, 5, item.Data);
                    if (item.Data < DateTime.Today.AddDays(-30))
                    {
                        sheet.Cells[line + 2, 5].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        sheet.Cells[line + 2, 5].Style.Fill.BackgroundColor.SetColor(Color.Yellow);
                    }
                    sheet.SetValue(line + 2, 6, item.DocFistal);
                    sheet.SetValue(line + 2, 7, item.NomeFantasia);
                    ++line;
                }


                sheet.PrinterSettings.Orientation = eOrientation.Landscape;
                sheet.PrinterSettings.PaperSize = ePaperSize.A4;



                DateTime dts = DateTime.Today;
                ExcelHeaderFooterText footer = sheet.HeaderFooter.OddFooter;
                ExcelHeaderFooterText header = sheet.HeaderFooter.OddHeader;
                header.LeftAlignedText = nome;
                footer.RightAlignedText = dts.ToLongDateString();

                //

                var modelTable = sheet.Cells["A1:G" + (list.Count + 1)];
                sheet.View.ZoomScale = 110;
                sheet.View.PageBreakView = true;
                sheet.Cells.Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                sheet.PrinterSettings.FooterMargin = 0.5M;
                sheet.PrinterSettings.HeaderMargin = 0.0M;
                sheet.PrinterSettings.TopMargin = 0.5M;
                sheet.PrinterSettings.BottomMargin = 0.5M;
                sheet.PrinterSettings.LeftMargin = 0.5M / 2.5M;
                sheet.PrinterSettings.FooterMargin = 0.5M / 2.5M;

                sheet.Cells["E:E"].Style.Numberformat.Format = "dd/MM/yyyy";

                modelTable.Style.Font.Size = 8;

                modelTable.AutoFitColumns();

                modelTable.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                modelTable.Style.Border.Left.Style = ExcelBorderStyle.Thin;

                //SemQTDFornec(list, excelPackage, nome);
                //SoSucata(list, excelPackage, nome);
                //DemaisItens(list, excelPackage, nome);

                string path = $@"C:\Exports\{nome}.xlsx";
                File.WriteAllBytes(path, excelPackage.GetAsByteArray());

                //Process.Start($@"C:\Exports\{nome}.xlsx");
                return path;
            }
        }

        private static void SemQTDFornec(List<ForaDeEstoque2> list, ExcelPackage excelPackage, string nome)
        {
            var SemQTDFornec = "ForaDeEstoqueComSald - SemQTD Fornec";
            var sheet2 = excelPackage.Workbook.Worksheets.Copy(nome, SemQTDFornec);
            sheet2.Cells["E2:E" + (list.Count + 1)].Value = "";
            ExcelHeaderFooterText header2 = sheet2.HeaderFooter.OddHeader;
            header2.LeftAlignedText = SemQTDFornec;
        }

        private static void DemaisItens(List<ForaDeEstoque2> list, ExcelPackage excelPackage, string nome)
        {
            int line;
            var DemaisItens = "DemaisItens";
            var sheet4 = excelPackage.Workbook.Worksheets.Copy(nome, DemaisItens);
            sheet4.Cells["A2:J" + (list.Count() + 1)].Value = "";
            var nl = list.Where(p => p.Produto != "B-2601" & p.Produto != "B-2602" & p.Produto != "B-2603" & p.Produto != "B-2604" & p.Produto != "B-1837" & p.Produto != "B-2868").OrderBy(p => p.Data).OrderBy(p => p.Produto);
            line = 0;
            foreach (var item in nl)
            {
                sheet4.SetValue(line + 2, 1, item.Produto);
                sheet4.SetValue(line + 2, 2, item.Descricao);
                sheet4.SetValue(line + 2, 3, item.Prateleira);
                sheet4.SetValue(line + 2, 4, "");
                sheet4.SetValue(line + 2, 5, "");
                sheet4.SetValue(line + 2, 6, "");
                sheet4.SetValue(line + 2, 7, item.NomeFantasia);
                sheet4.SetValue(line + 2, 8, item.DocFiscal);
                sheet4.SetValue(line + 2, 9, item.TM);
                sheet4.SetValue(line + 2, 10, item.Data.Year == 1 ? "" : item.Data.ToString("dd/MM/yyyy"));
                if (item.Data < DateTime.Now.AddDays(-30) & item.Data.Year > 1)
                {
                    sheet4.Cells[line + 2, 10].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    sheet4.Cells[line + 2, 10].Style.Fill.BackgroundColor.SetColor(Color.Yellow);
                }
                ++line;
            }
            sheet4.DeleteRow(line + 2, list.Count() - nl.Count());
            ExcelHeaderFooterText header4 = sheet4.HeaderFooter.OddHeader;
            header4.LeftAlignedText = "InventariarForaDeEstoqueComSaldo - " + DemaisItens;
        }

        private static void SoSucata(List<ForaDeEstoque2> list, ExcelPackage excelPackage, string nome)
        {
            int line;
            var SoSucata = "SóSucata";
            var sheet3 = excelPackage.Workbook.Worksheets.Copy(nome, SoSucata);
            sheet3.Cells["A2:J" + (list.Count() + 1)].Value = "";
            var nl = list.Where(p => p.Produto == "B-2601" | p.Produto == "B-2602" | p.Produto == "B-2603" | p.Produto == "B-2604" | p.Produto == "B-1837" | p.Produto == "B-2868").OrderBy(p => p.Data).OrderBy(p => p.Produto);
            line = 0;
            foreach (var item in nl)
            {
                sheet3.SetValue(line + 2, 1, item.Produto);
                sheet3.SetValue(line + 2, 2, item.Descricao);
                sheet3.SetValue(line + 2, 3, item.Prateleira);
                sheet3.SetValue(line + 2, 4, item.Unidade + ": " + item.SaldoFisico);
                sheet3.SetValue(line + 2, 5, item.ForaDeEstoque);
                sheet3.SetValue(line + 2, 6, "");
                sheet3.SetValue(line + 2, 7, item.NomeFantasia);
                sheet3.SetValue(line + 2, 8, item.DocFiscal);
                sheet3.SetValue(line + 2, 9, item.TM);
                sheet3.SetValue(line + 2, 10, item.Data.Year == 1 ? "" : item.Data.ToString("dd/MM/yyyy"));
                if (item.Data < DateTime.Now.AddDays(-60) & item.Data.Year > 1)
                {
                    sheet3.Cells[line + 2, 10].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    sheet3.Cells[line + 2, 10].Style.Fill.BackgroundColor.SetColor(Color.Yellow);
                }
                ++line;
            }
            sheet3.DeleteRow(line + 2, list.Count() - nl.Count());
            ExcelHeaderFooterText header3 = sheet3.HeaderFooter.OddHeader;
            header3.LeftAlignedText = "InventariarForaDeEstoqueComSaldo - " + SoSucata;
        }

        internal static void InventariarSucata(List<SaldoSucata> listaSucata)
        {

            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                excelPackage.Workbook.Properties.Author = "Cid M Evangelista";
                excelPackage.Workbook.Properties.Title = "Meu Excel";

                var sheet = excelPackage.Workbook.Worksheets.Add("InventarioSucata");

                sheet.Name = "InventarioSucata";
                sheet.PrinterSettings.LeftMargin = 0.3m;
                sheet.PrinterSettings.RightMargin = 0.2m;
                sheet.PrinterSettings.PaperSize = ePaperSize.A4;

                sheet.SetValue(1, 1, "Codigo");
                sheet.SetValue(1, 2, "Descrição");
                sheet.SetValue(1, 3, "Prateleira");
                sheet.SetValue(1, 4, "SaldoAtual");
                sheet.SetValue(1, 5, "Disponivel");
                sheet.SetValue(1, 6, "Inventario");
                sheet.SetValue(1, 7, "DeTerceiro");

                int line = 0;
                foreach (var item in listaSucata)
                {
                    sheet.SetValue(line + 2, 1, item.Codigo);
                    sheet.SetValue(line + 2, 2, item.Desccricao);
                    sheet.SetValue(line + 2, 3, item.Prateleira);
                    sheet.SetValue(line + 2, 4, item.SaldoAtual);
                    sheet.SetValue(line + 2, 5, item.Disponivel);
                    sheet.SetValue(line + 2, 6, "");
                    sheet.SetValue(line + 2, 7, item.ForaEstoque);
                    ++line;
                }

                DateTime dts = DateTime.Today;
                ExcelHeaderFooterText footer = sheet.HeaderFooter.OddFooter;
                ExcelHeaderFooterText header = sheet.HeaderFooter.OddHeader;
                header.LeftAlignedText = "InventarioSucata";
                footer.RightAlignedText = dts.ToLongDateString();
                footer.LeftAlignedText = listaSucata.Count().ToString();

                var modelTable = sheet.Cells["A1:G" + (listaSucata.Count + 1)];
                sheet.View.ZoomScale = 120;
                sheet.View.PageBreakView = true;
                sheet.Cells.Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                //sheet.Column(7).ColumnMax = 40;

                sheet.PrinterSettings.FooterMargin = 0.5M;
                sheet.PrinterSettings.HeaderMargin = 0.0M;
                sheet.PrinterSettings.TopMargin = 0.5M;
                sheet.PrinterSettings.BottomMargin = 0.5M;
                sheet.PrinterSettings.LeftMargin = 0.5M / 2.5M;
                sheet.PrinterSettings.FooterMargin = 0.5M / 2.5M;
                sheet.PrinterSettings.Scale = 133;

                modelTable.Style.Font.Size = 8;
                //sheet.Column(7).Style.Font.Size = 5;

                modelTable.AutoFitColumns();

                modelTable.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                modelTable.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                sheet.Column(7).Style.WrapText = true;

                string path = @"C:\Exports\InventarioSucata.xlsx";
                File.WriteAllBytes(path, excelPackage.GetAsByteArray());

                Process.Start(@"C:\Exports\InventarioSucata.xlsx");
            }
        }

        internal static void InventariarDeTerceiroComSaldo(List<ForaDeEstoque2> lista)
        {
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                excelPackage.Workbook.Properties.Author = "Cid M Evangelista";
                excelPackage.Workbook.Properties.Title = "Meu Excel";
                var sheet = excelPackage.Workbook.Worksheets.Add("InventariarDeTerceiroComSaldo");

                sheet.Name = "InventariarDeTerceiroComSaldo";
                sheet.PrinterSettings.LeftMargin = 0.3m;
                sheet.PrinterSettings.RightMargin = 0.2m;
                //sheet.PrinterSettings.FitToPage = true;
                //sheet.PrinterSettings.FitToHeight = 150;
                //sheet.PrinterSettings.FitToWidth = 150;
                sheet.PrinterSettings.PaperSize = ePaperSize.A4;

                sheet.SetValue(1, 1, "Produto");
                sheet.SetValue(1, 2, "Descricao");
                sheet.SetValue(1, 3, "Prateleira");
                sheet.SetValue(1, 4, "SaldoAtual");
                sheet.SetValue(1, 5, "Qtd Fornec");
                sheet.SetValue(1, 6, "Inventario");
                sheet.SetValue(1, 7, "Cliente");
                sheet.SetValue(1, 8, "DocFiscal");
                sheet.SetValue(1, 9, "TM");
                sheet.SetValue(1, 10, "Data");

                int line = 0;
                foreach (var item in lista)
                {
                    sheet.SetValue(line + 2, 1, item.Produto);
                    sheet.SetValue(line + 2, 2, item.Descricao);
                    sheet.SetValue(line + 2, 3, item.Prateleira);
                    sheet.SetValue(line + 2, 4, item.Unidade + ": " + item.SaldoFisico);
                    sheet.SetValue(line + 2, 5, item.ForaDeEstoque);
                    sheet.SetValue(line + 2, 6, "");
                    sheet.SetValue(line + 2, 7, item.NomeFantasia);
                    sheet.SetValue(line + 2, 8, item.DocFiscal);
                    sheet.SetValue(line + 2, 9, item.TM);
                    sheet.SetValue(line + 2, 10, item.Data.ToString("dd/MM/yyyy"));
                    ++line;
                }

                sheet.PrinterSettings.Orientation = eOrientation.Landscape;
                sheet.PrinterSettings.PaperSize = ePaperSize.A4;

                DateTime dts = DateTime.Today;
                ExcelHeaderFooterText footer = sheet.HeaderFooter.OddFooter;
                ExcelHeaderFooterText header = sheet.HeaderFooter.OddHeader;
                header.LeftAlignedText = "InventariarDeTerceiroComSaldo";
                footer.RightAlignedText = dts.ToLongDateString();

                //

                var modelTable = sheet.Cells["A1:J" + (lista.Count + 1)];
                sheet.View.ZoomScale = 110;
                sheet.View.PageBreakView = true;
                sheet.Cells.Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                sheet.PrinterSettings.FooterMargin = 0.5M;
                sheet.PrinterSettings.HeaderMargin = 0.0M;
                sheet.PrinterSettings.TopMargin = 0.5M;
                sheet.PrinterSettings.BottomMargin = 0.5M;
                sheet.PrinterSettings.LeftMargin = 0.5M / 2.5M;
                sheet.PrinterSettings.FooterMargin = 0.5M / 2.5M;

                sheet.Cells["J:J"].Style.Numberformat.Format = "dd/MM/yyyy";

                modelTable.Style.Font.Size = 8;

                modelTable.AutoFitColumns();

                modelTable.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                modelTable.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                //sheet.Column(14).Style.WrapText = true;


                // Aqui você coloca a lógica que precisa escrever nas planilhas.

                string path = @"C:\Exports\InventariarDeTerceiroComSaldo.xlsx";
                File.WriteAllBytes(path, excelPackage.GetAsByteArray());


                MessageBox.Show("MaterialParado pronta, Tempo Decorrido: ", "PRONTO!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                Process.Start(@"C:\Exports\InventariarDeTerceiroComSaldo.xlsx");
            }
        }

        internal static void PCPInvestigar(List<Saldo> sa)
        {
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                //excelPackage.Workbook.Properties.Author = "Cid M Evangelista";
                //excelPackage.Workbook.Properties.Title = "Meu Excel";

                //var sheet = excelPackage.Workbook.Worksheets.Add("PCPInvestigar");

                //sheet.Name = "PCPInvestigar";
                //sheet.PrinterSettings.LeftMargin = 0.3m;
                //sheet.PrinterSettings.RightMargin = 0.2m;

                //sheet.PrinterSettings.PaperSize = ePaperSize.A4;

                //sheet.SetValue(2, 1, "Produto");
                //sheet.SetValue(2, 2, "Descricao");
                //sheet.SetValue(2, 3, "Unid");
                //sheet.SetValue(2, 4, "SaldoAtual");
                //sheet.SetValue(2, 5, "Disponivel");
                //sheet.SetValue(2, 6, "PedVendas");
                //sheet.SetValue(2, 7, "PedCompras");
                //sheet.SetValue(2, 8, "ConsuPrevOs");
                //sheet.SetValue(2, 9, "Entradas");
                //sheet.SetValue(2, 10, "Saidas");
                //sheet.SetValue(2, 11, "SaldoUltFech");
                //sheet.SetValue(2, 12, "ForaEstoque");
                //sheet.SetValue(2, 13, "PrevFabric");
                //sheet.SetValue(2, 14, "DiassemMovimento");
                //sheet.SetValue(2, 15, "Grupo");
                //sheet.SetValue(2, 16, "Cliente/Fornecedor");
                ////
                //int linha = 3;
                //foreach (var i in sa)
                //{
                //    StringBuilder sb = new StringBuilder();


                //    sheet.SetValue(linha, 1, i.Produto);
                //    sheet.SetValue(linha, 2, i.Descricao);
                //    sheet.SetValue(linha, 3, i.Unid);
                //    sheet.SetValue(linha, 4, i.SaldoAtual);
                //    sheet.SetValue(linha, 5, i.Disponivel);
                //    sheet.SetValue(linha, 6, i.PedVendas);
                //    sheet.SetValue(linha, 7, i.PedCompras);
                //    sheet.SetValue(linha, 8, i.ConsuPrevOs);
                //    sheet.SetValue(linha, 9, i.Entradas);
                //    sheet.SetValue(linha, 10, i.Saidas);
                //    sheet.SetValue(linha, 11, i.SaldoUltFech);
                //    sheet.SetValue(linha, 12, i.ForaEstoque);
                //    sheet.SetValue(linha, 13, i.PrevFabric);
                //    sheet.SetValue(linha, 14, i.DiassemMovimento);
                //    sheet.SetValue(linha, 15, i.Grupo);
                //    if (i.Grupo == "10000000")
                //    {
                //        sb = BuscaCliente(i.Produto);
                //        sheet.SetValue(linha, 16, sb);
                //    }
                //    else
                //    {
                //        sb = BuscaFornecedor(i.Produto);
                //        sheet.SetValue(linha, 16, sb);
                //    }
                //    DateTime g = DateTime.Today;

                //    switch (i.Grupo)
                //    {

                //        case "10000000":
                //            if (i.SaldoAtual != i.PedVendas)
                //            {
                //                sheet.Cells[linha, 4].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                //                sheet.Cells[linha, 4].Style.Fill.BackgroundColor.SetColor(Color.Yellow);
                //                sheet.Cells[linha, 6].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                //                sheet.Cells[linha, 6].Style.Fill.BackgroundColor.SetColor(Color.Yellow);
                //                string st = sb.ToString();
                //                var d = st.Split(' ');
                //                if (d.Count() > 2)
                //                {
                //                    g = Convert.ToDateTime(d[3]);
                //                }

                //            }
                //            if (g < DateTime.Today)
                //            {
                //                sheet.Cells[linha, 16].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                //                sheet.Cells[linha, 16].Style.Fill.BackgroundColor.SetColor(Color.Yellow);
                //            }
                //            ; break;
                //        case "11000000":
                //            if (i.SaldoAtual != i.ForaEstoque)
                //            {
                //                sheet.Cells[linha, 4].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                //                sheet.Cells[linha, 4].Style.Fill.BackgroundColor.SetColor(Color.Orange);
                //                sheet.Cells[linha, 12].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                //                sheet.Cells[linha, 12].Style.Fill.BackgroundColor.SetColor(Color.Orange);
                //            }; break;

                //    }

                //    linha++;
                //}
                //sheet.SetValue("B1", DateTime.Now);
                //sheet.Cells["B1"].Style.Numberformat.Format = "dd-MM-yyyy HH:mm";
                //sheet.Cells["B1"].AutoFitColumns(30);

                //var modelTable = sheet.Cells["A2:P" + (sa.Count + 2)];
                //modelTable.Style.Font.Size = 8;
                //modelTable.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                //modelTable.AutoFitColumns();
                //modelTable.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                //modelTable.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                //modelTable.Style.Border.Right.Style = ExcelBorderStyle.Thin;

                //var mt = sheet.Cells["P:P"];
                //mt.Style.WrapText = true;
                //mt.AutoFitColumns(50);
                //sheet.View.FreezePanes(3, 17);
                //sheet.View.ZoomScale = 86;

                //string path = @"C:\Exports\PCPInvestigar.xlsx";
                //File.WriteAllBytes(path, excelPackage.GetAsByteArray());

                //Process.Start(@"C:\Exports\PCPInvestigar.xlsx");
            }
        }

        internal static void InventarioDepositosDeTerceiro(object junto, bool envia)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                excelPackage.Workbook.Properties.Author = "Cid M Evangelista";
                excelPackage.Workbook.Properties.Title = "Meu Excel";




                var sheet = excelPackage.Workbook.Worksheets.Add("InventarioDepositosDeTerceiro");

                sheet.Name = "InventarioDepositosDeTerceiro";
                sheet.PrinterSettings.LeftMargin = 0.3m;
                sheet.PrinterSettings.RightMargin = 0.2m;
                //sheet.PrinterSettings.FitToPage = true;
                //sheet.PrinterSettings.FitToHeight = 150;
                //sheet.PrinterSettings.FitToWidth = 150;
                sheet.PrinterSettings.PaperSize = ePaperSize.A4;

                sheet.SetValue(1, 1, "Codigo");

                sheet.SetValue(1, 2, "Descricao");
                sheet.SetValue(1, 3, "Prateleira");
                sheet.SetValue(1, 4, "SaldoAtual");
                sheet.SetValue(1, 5, "DeTerceiro");
                //sheet.SetValue(1, 6, "Minimo");
                sheet.SetValue(1, 6, "Inventario");
                sheet.SetValue(1, 7, "Cliente/Deposito");
                sheet.SetValue(1, 8, "Data Doc Qtd");
                sheet.SetValue(1, 9, "Entregue");


                //UNIR DS COM LISTA TXT

                var lista = (List<SaldoDeTerceiro>)junto;

                //
                int line = 0;
                StringBuilder sb = new StringBuilder();
                HashSet<int> hs = new HashSet<int>();
                foreach (var item in lista)
                {
                    if (item.Produto != null)
                    {
                        sheet.SetValue(line + 2, 1, item.Produto);
                        sheet.SetValue(line + 2, 2, item.Descricao);
                        sheet.SetValue(line + 2, 3, item.Prateleira);
                        //sheet.SetValue(line + 2, 4, item.SaldoKg);
                        sheet.SetValue(line + 2, 4, item.Unid + ": " + Math.Round(item.SaldoAtual, 3));
                        sheet.SetValue(line + 2, 5, Math.Round(item.DeTerceiros, 3));
                        //sheet.SetValue(linha + 2, 6, cpe[linha].Codigo);
                        sheet.SetValue(line + 2, 7, item.DEPOSITO);
                        hs.Add(Convert.ToInt32(item.DEPOSITO.Split(' ').First()));
                        sheet.SetValue(line + 2, 8, item.Data.ToShortDateString() + " " + item.DESCR_2);
                        sheet.SetValue(line + 2, 9, item.Descricao2);

                        if (item.Data < DateTime.Today.AddDays(-60))
                        {
                            var s = DateTime.Today.AddDays(-60);
                            sheet.Cells[line + 2, 8].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                            sheet.Cells[line + 2, 8].Style.Fill.BackgroundColor.SetColor(Color.Yellow);
                            sheet.Cells[line + 2, 8].Style.Font.Bold = true;
                            sheet.Cells[line + 2, 8].Style.Font.Color.SetColor(Color.Black);
                        }
                        if (item.Data < DateTime.Today.AddDays(-120))
                        {
                            var s = DateTime.Today.AddDays(-120);
                            sheet.Cells[line + 2, 8].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                            sheet.Cells[line + 2, 8].Style.Fill.BackgroundColor.SetColor(Color.IndianRed);
                            sheet.Cells[line + 2, 8].Style.Font.Bold = true;
                            sheet.Cells[line + 2, 8].Style.Font.Color.SetColor(Color.White);
                        }
                        if (item.SaldoAtual > 0 & item.DeTerceiros == 0)
                        {
                            sheet.SetValue(line + 2, 9, "Material no poder do Cliente. Eliminar Saldo Atual");
                            sheet.Cells[line + 2, 8].Style.Fill.BackgroundColor.SetColor(Color.Black);
                            sheet.Cells[line + 2, 8].Style.Font.Bold = true;
                            sheet.Cells[line + 2, 8].Style.Font.Color.SetColor(Color.Yellow);

                            sheet.Cells[line + 2, 9].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                            sheet.Cells[line + 2, 9].Style.Fill.BackgroundColor.SetColor(Color.Black);
                            sheet.Cells[line + 2, 9].Style.Font.Bold = true;
                            sheet.Cells[line + 2, 9].Style.Font.Color.SetColor(Color.Yellow);

                            sheet.Cells[line + 2, 4].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                            sheet.Cells[line + 2, 4].Style.Fill.BackgroundColor.SetColor(Color.Black);
                            sheet.Cells[line + 2, 4].Style.Font.Bold = true;
                            sheet.Cells[line + 2, 4].Style.Font.Color.SetColor(Color.Yellow);
                        }


                        ++line;
                    }
                }
                var l = hs.ToList();
                l.Sort();
                l.ForEach(x => sb.Append(x + ","));
                sheet.SetValue(line + 3, 2, "Depositos Envolvidos com SaldoAtual/DeTerceiro positivos");
                sheet.SetValue(line + 4, 2, sb.Remove(sb.Length - 1, 1));

                DateTime dts = DateTime.Today;
                ExcelHeaderFooterText footer = sheet.HeaderFooter.OddFooter;
                ExcelHeaderFooterText header = sheet.HeaderFooter.OddHeader;
                header.LeftAlignedText = "InventarioDepositosDeTerceiro";
                footer.RightAlignedText = dts.ToLongDateString();

                //

                var modelTable = sheet.Cells["A1:I" + (lista.Count + 1)];
                sheet.View.ZoomScale = 120;
                sheet.View.PageBreakView = true;
                sheet.Cells.Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                sheet.Column(7).ColumnMax = 40;

                sheet.PrinterSettings.FooterMargin = 0.5M;
                sheet.PrinterSettings.HeaderMargin = 0.0M;
                sheet.PrinterSettings.TopMargin = 0.5M;
                sheet.PrinterSettings.BottomMargin = 0.5M;
                sheet.PrinterSettings.LeftMargin = 0.5M / 2.5M;
                sheet.PrinterSettings.FooterMargin = 0.5M / 2.5M;
                sheet.PrinterSettings.Scale = 80;

                modelTable.Style.Font.Size = 8;
                sheet.Column(7).Style.Font.Size = 8;


                modelTable.AutoFitColumns();

                modelTable.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                modelTable.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                sheet.Column(7).Style.WrapText = true;

                sheet.PrinterSettings.Orientation = eOrientation.Landscape;
                sheet.PrinterSettings.PaperSize = ePaperSize.A4;


                string path = @"C:\Exports\InventarioDepositosDeTerceiro.xlsx";
                File.WriteAllBytes(path, excelPackage.GetAsByteArray());

                sw.Stop();
                Process.Start(@"C:\Exports\InventarioDepositosDeTerceiro.xlsx");
                if (envia)
                {
                    if (MessageBox.Show("Deseja enviar email para Vendas?", "Enviar Email", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        OutLook.InventarioDepositoDeTerceiro(@"C:\Exports\InventarioDepositosDeTerceiro.xlsx");
                    }

                    return;
                }

            }
        }

        private static StringBuilder BuscaFornecedor(string produto)
        {
            StringBuilder sb = new StringBuilder();
            var dss = Crud.Select($"select NomeFantasia, data, SaldoQtde " +
                $"from foradeestoques " +
                $"where Produto = '{produto}' and SaldoQtde > 0 " +
                $"order by data");

            for (int i = 0; i < dss.Tables[0].Rows.Count; i++)
            {
                sb.AppendLine("" +
                    "Forn= " + dss.Tables[0].Rows[i].ItemArray[0].ToString() + ", " +
                    "Data= " + dss.Tables[0].Rows[i].ItemArray[1].ToString().Remove(10) + ", " +
                    "Saldo= " + dss.Tables[0].Rows[i].ItemArray[2].ToString()
                    );

            }
            return sb;
        }

        private static StringBuilder BuscaCliente(string produto)
        {
            StringBuilder sb = new StringBuilder();
            var dss = Crud.Select($"select NPedido, DataEntrega, CodigoCliente, Quantidade " +
                $"from pedidosdevenda " +
                $"where item = '{produto}' " +
                $"order by DataEntrega");

            for (int i = 0; i < dss.Tables[0].Rows.Count; i++)
            {
                sb.AppendLine("" +
                    "PV= " + dss.Tables[0].Rows[i].ItemArray[0].ToString() + " " +
                    "ENTG= " + dss.Tables[0].Rows[i].ItemArray[1].ToString().Remove(10) + " " +
                    "CLIT= " + dss.Tables[0].Rows[i].ItemArray[2].ToString().Substring(0, 7) + " " +
                    "QTD= " + dss.Tables[0].Rows[i].ItemArray[3].ToString()

                    );

            }
            return sb;
        }

        public static void InventarioMovimentos(List<ClassParaExcell> cpe, string lblqtd)
        {


            Stopwatch sw = new Stopwatch();
            sw.Start();
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                excelPackage.Workbook.Properties.Author = "Cid M Evangelista";
                excelPackage.Workbook.Properties.Title = "Meu Excel";

                var sheet = excelPackage.Workbook.Worksheets.Add("InventarioMovimentos");

                sheet.Name = "InventarioMovimentos";
                sheet.PrinterSettings.LeftMargin = 0.3m;
                sheet.PrinterSettings.RightMargin = 0.2m;
                //sheet.PrinterSettings.FitToPage = true;
                //sheet.PrinterSettings.FitToHeight = 150;
                //sheet.PrinterSettings.FitToWidth = 150;
                sheet.PrinterSettings.PaperSize = ePaperSize.A4;

                sheet.SetValue(1, 1, "Codigo");

                sheet.SetValue(1, 2, "Descrição");
                sheet.SetValue(1, 3, "Prateleira");
                sheet.SetValue(1, 4, "Saldo Kg");
                sheet.SetValue(1, 5, "Saldo M");
                sheet.SetValue(1, 6, "Inventario");
                sheet.SetValue(1, 7, "Origem\nData TM Doc QTD Operador Hora");

                //UNIR DS COM LISTA TXT

                //
                int line = 0;
                foreach (var item in cpe)
                {
                    if (item.Codigo != null)
                    {

                        sheet.SetValue(line + 2, 1, item.Codigo);
                        sheet.SetValue(line + 2, 2, item.Descricao);
                        if (item.Codigo == "_PV")
                        {
                            sheet.Cells[line + 2, 2, line + 2, 3].Merge = true;
                            sheet.SetValue(line + 2, 2, $"=SOMASE(AcabadosParaExpedicao.xlsx!$A:$A;A{line + 3};AcabadosParaExpedicao.xlsx!$E:$E)");
                        }
                        sheet.SetValue(line + 2, 3, item.Prateleira);
                        if (item.Unid.Contains(":"))
                        {
                            sheet.SetValue(line + 2, 4, item.Unid);
                        }
                        else
                        {
                            sheet.SetValue(line + 2, 4, item.Unid + ": " + Math.Round(item.SaldoKg, 3));
                        }
                        sheet.SetValue(line + 2, 5, Math.Round(item.SaldoM, 3));
                        sheet.SetValue(line + 2, 7, item.Origem);
                        ++line;
                    }
                }



                DateTime dts = DateTime.Today;
                ExcelHeaderFooterText footer = sheet.HeaderFooter.OddFooter;
                ExcelHeaderFooterText header = sheet.HeaderFooter.OddHeader;
                header.LeftAlignedText = "InventarioMovimentos";
                footer.RightAlignedText = dts.ToLongDateString();
                footer.LeftAlignedText = lblqtd;

                //

                var modelTable = sheet.Cells["A1:G" + (cpe.Count + 1)];
                sheet.View.ZoomScale = 120;
                sheet.View.PageBreakView = true;
                sheet.Cells.Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                sheet.Column(7).ColumnMax = 40;


                sheet.PrinterSettings.FooterMargin = 0.5M;
                sheet.PrinterSettings.HeaderMargin = 0.0M;
                sheet.PrinterSettings.TopMargin = 0.5M;
                sheet.PrinterSettings.BottomMargin = 0.5M;
                sheet.PrinterSettings.LeftMargin = 0.5M / 2.5M;
                sheet.PrinterSettings.FooterMargin = 0.5M / 2.5M;

                modelTable.Style.Font.Size = 8;
                sheet.Column(7).Style.Font.Size = 5;


                modelTable.AutoFitColumns();

                modelTable.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                modelTable.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                sheet.Column(7).Style.WrapText = true;

                var sheet2 = excelPackage.Workbook.Worksheets.Copy("InventarioMovimentos", "InventarioMovimentos2");
                sheet.DeleteColumn(7);
                sheet.Column(5).Width = 8;

                //string path2 = @"C:\Exports\Inventario2.xlsx";
                //File.WriteAllBytes(path2, excelPackage.GetAsByteArray());
                //Process.Start(@"C:\Exports\Inventario2.xlsx");

                string path = @"C:\Exports\InventarioMovimentos.xlsx";
                File.WriteAllBytes(path, excelPackage.GetAsByteArray());

                sw.Stop();
                MessageBox.Show("Inventario pronta, Tempo Decorrido: " + sw.Elapsed, "PRONTO!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                Process.Start(@"C:\Exports\InventarioMovimentos.xlsx");
            }
        }

        public static void InventariarPorGrupo(List<ClassParaExcell> cpe)
        {

            Stopwatch sw = new Stopwatch();
            sw.Start();
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                excelPackage.Workbook.Properties.Author = "Cid M Evangelista";
                excelPackage.Workbook.Properties.Title = "Meu Excel";

                var sheet = excelPackage.Workbook.Worksheets.Add("InventariarPorGrupo");

                sheet.Name = "InventariarPorGrupo";
                sheet.PrinterSettings.LeftMargin = 0.3m;
                sheet.PrinterSettings.RightMargin = 0.2m;
                //sheet.PrinterSettings.FitToPage = true;
                //sheet.PrinterSettings.FitToHeight = 150;
                //sheet.PrinterSettings.FitToWidth = 150;
                sheet.PrinterSettings.PaperSize = ePaperSize.A4;

                sheet.SetValue(1, 1, "Codigo");

                sheet.SetValue(1, 2, "Descrição");
                sheet.SetValue(1, 3, "Prateleira");
                sheet.SetValue(1, 4, "Saldo Kg");
                sheet.SetValue(1, 5, "Saldo M");
                //sheet.SetValue(1, 6, "Minimo");
                sheet.SetValue(1, 6, "Inventario");
                sheet.SetValue(1, 7, "Grupo");

                //UNIR DS COM LISTA TXT

                //
                int line = 0;
                foreach (var item in cpe)
                {
                    if (item.Codigo != null)
                    {
                        sheet.SetValue(line + 2, 1, item.Codigo);
                        sheet.SetValue(line + 2, 2, item.Descricao);
                        sheet.SetValue(line + 2, 3, item.Prateleira);
                        //sheet.SetValue(line + 2, 4, item.SaldoKg);
                        if (item.Unid.Contains(":"))
                        {
                            sheet.SetValue(line + 2, 4, item.Unid);
                        }
                        else
                        {
                            sheet.SetValue(line + 2, 4, item.Unid + ": " + Math.Round(item.SaldoKg, 3));
                        }

                        sheet.SetValue(line + 2, 5, Math.Round(item.SaldoM, 3));
                        //sheet.SetValue(linha + 2, 6, cpe[linha].Codigo);
                        sheet.SetValue(line + 2, 7, item.Grupo);
                        ++line;
                    }
                }


                DateTime dts = DateTime.Today;
                ExcelHeaderFooterText footer = sheet.HeaderFooter.OddFooter;
                ExcelHeaderFooterText header = sheet.HeaderFooter.OddHeader;
                header.LeftAlignedText = "InventariarPorGrupo";
                footer.RightAlignedText = dts.ToLongDateString();


                //

                var modelTable = sheet.Cells["A1:G" + (cpe.Count + 1)];
                sheet.View.ZoomScale = 120;
                sheet.View.PageBreakView = true;
                sheet.Cells.Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                sheet.Column(7).ColumnMax = 40;




                sheet.PrinterSettings.FooterMargin = 0.5M;
                sheet.PrinterSettings.HeaderMargin = 0.0M;
                sheet.PrinterSettings.TopMargin = 0.5M;
                sheet.PrinterSettings.BottomMargin = 0.5M;
                sheet.PrinterSettings.LeftMargin = 0.5M / 2.5M;
                sheet.PrinterSettings.FooterMargin = 0.5M / 2.5M;

                modelTable.Style.Font.Size = 8;
                //sheet.Column(7).Style.Font.Size = 5;


                modelTable.AutoFitColumns();

                modelTable.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                modelTable.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                sheet.Column(7).Style.WrapText = true;

                //string path2 = @"C:\Exports\Inventario2.xlsx";
                //File.WriteAllBytes(path2, excelPackage.GetAsByteArray());
                //Process.Start(@"C:\Exports\Inventario2.xlsx");

                string path = @"C:\Exports\InventariarPorGrupo.xlsx";
                File.WriteAllBytes(path, excelPackage.GetAsByteArray());

                sw.Stop();
                MessageBox.Show("Inventario pronta, Tempo Decorrido: " + sw.Elapsed, "PRONTO!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                Process.Start(@"C:\Exports\InventariarPorGrupo.xlsx");
            }
        }

        public static void InventarioPersonalizado(List<RegistroInventario> ri)
        {

            Stopwatch sw = new Stopwatch();
            sw.Start();
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                excelPackage.Workbook.Properties.Author = "Cid M Evangelista";
                excelPackage.Workbook.Properties.Title = "Meu Excel";

                var sheet = excelPackage.Workbook.Worksheets.Add("InventarioPersonalizado");

                sheet.Name = "InventarioPersonalizado";
                sheet.PrinterSettings.LeftMargin = 0.3m;
                sheet.PrinterSettings.RightMargin = 0.2m;
                //sheet.PrinterSettings.FitToPage = true;
                //sheet.PrinterSettings.FitToHeight = 150;
                //sheet.PrinterSettings.FitToWidth = 150;
                sheet.PrinterSettings.PaperSize = ePaperSize.A4;

                sheet.SetValue(1, 1, "Codigo");
                sheet.SetValue(1, 2, "Descrição");
                sheet.SetValue(1, 3, "Prateleira");
                sheet.SetValue(1, 4, "Saldo Kg");
                sheet.SetValue(1, 5, "Saldo M");
                sheet.SetValue(1, 6, "Inventario");

                //UNIR DS COM LISTA TXT

                //
                int line = 0;
                foreach (var item in ri)
                {
                    if (item.Produto != null)
                    {
                        sheet.SetValue(line + 2, 1, item.Produto);
                        sheet.SetValue(line + 2, 2, item.Descricao);
                        sheet.SetValue(line + 2, 3, item.Prateleira + " C- " + item.Livre17);
                        sheet.SetValue(line + 2, 4, item.Unid + ": " + Math.Round(item.SaldoAtual, 3));
                        sheet.SetValue(line + 2, 5, Math.Round(item.ValorConvertido, 3));
                        ++line;
                    }
                }

                DateTime dts = DateTime.Today;
                ExcelHeaderFooterText footer = sheet.HeaderFooter.OddFooter;
                ExcelHeaderFooterText header = sheet.HeaderFooter.OddHeader;
                header.LeftAlignedText = "InventarioPersonalizado";
                footer.RightAlignedText = dts.ToLongDateString();

                var modelTable = sheet.Cells["A1:F" + (ri.Count + 1)];
                sheet.View.ZoomScale = 120;
                sheet.View.PageBreakView = true;
                sheet.Cells.Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                sheet.Column(7).ColumnMax = 40;

                sheet.PrinterSettings.FooterMargin = 0.5M;
                sheet.PrinterSettings.HeaderMargin = 0.0M;
                sheet.PrinterSettings.TopMargin = 0.5M;
                sheet.PrinterSettings.BottomMargin = 0.5M;
                sheet.PrinterSettings.LeftMargin = 0.5M / 2.5M;
                sheet.PrinterSettings.FooterMargin = 0.5M / 2.5M;

                modelTable.Style.Font.Size = 8;
                //sheet.Column(7).Style.Font.Size = 5;


                modelTable.AutoFitColumns();

                modelTable.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                modelTable.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                sheet.Column(7).Style.WrapText = true;

                string path = @"C:\Exports\InventarioPersonalizado.xlsx";
                File.WriteAllBytes(path, excelPackage.GetAsByteArray());

                sw.Stop();
                MessageBox.Show("Inventario pronta, Tempo Decorrido: " + sw.Elapsed, "PRONTO!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                Process.Start(@"C:\Exports\InventarioPersonalizado.xlsx");
            }
        }

        internal static void SemiAcabadosParaFornecedores(List<ClassParaExcell> cpe)
        {

            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                excelPackage.Workbook.Properties.Author = "Cid M Evangelista";
                excelPackage.Workbook.Properties.Title = "Meu Excel";

                var sheet = excelPackage.Workbook.Worksheets.Add("SemiAcabadosParaFornecedores");

                sheet.Name = "SemiAcabadosParaFornecedores";
                sheet.PrinterSettings.LeftMargin = 0.3m;
                sheet.PrinterSettings.RightMargin = 0.2m;
                //sheet.PrinterSettings.FitToPage = true;
                //sheet.PrinterSettings.FitToHeight = 150;
                //sheet.PrinterSettings.FitToWidth = 150;
                sheet.PrinterSettings.PaperSize = ePaperSize.A4;

                sheet.SetValue(1, 1, "Código");
                sheet.SetValue(1, 2, "Item");
                sheet.SetValue(1, 3, "Prateleira");
                sheet.SetValue(1, 4, "Fornecedor / Data");
                sheet.SetValue(1, 5, "Quantidade");


                //UNIR DS COM LISTA TXT
                //DataTable dt = Transforma.TransformandoDataRow(ds, File.OpenRead(@"C:\Users\Estoque\Documents\Exports\ListaCodOrigem.txt"));
                //
                var dts = Crud.Select($"select Produto, NomeFantasia, Data from foradeestoques where SaldoQtde > 0");
                List<PedidoDeCompra> pc = new List<PedidoDeCompra>();
                foreach (DataRow item in dts.Tables[0].Rows)
                {
                    pc.Add(new PedidoDeCompra
                    {
                        Produto = item["Produto"].ToString(),
                        Fornecedor = item["NomeFantasia"].ToString(),
                        Data = (DateTime)item["Data"]
                    });
                }

                //
                var ape = (from c in cpe
                           join p in pc on c.Codigo equals p.Produto
                           orderby c.Prateleira, p.Produto

                           select new { c.Codigo, c.Descricao, c.Prateleira, p.Fornecedor, p.Data, c.SaldoKg }).ToList();




                var linha = 2;
                foreach (var a in ape)
                {

                    sheet.SetValue(linha, 1, a.Codigo);
                    sheet.SetValue(linha, 2, a.Descricao);
                    sheet.SetValue(linha, 3, a.Prateleira);
                    sheet.SetValue(linha, 4,
                        "FORN= " + a.Fornecedor + "\n" +
                        "DATA= " + a.Data.ToString("dd/MM/yyyy")
                        );

                    linha++;
                }

                linha++;
                linha++;

                sheet.SetValue(linha, 2, "Abaixo... \n" +
                    "Materiais sem Prateleiras \n" +
                    "e com saldo positivo - Alinhar com PCP");
                var mm = sheet.Cells[linha, 2];
                mm.Style.WrapText = true;

                linha++;
                linha++;

                sheet.SetValue(linha, 1, "Código");
                sheet.SetValue(linha, 2, "Item");
                sheet.SetValue(linha, 3, "Prateleira");
                sheet.SetValue(linha, 4, "Quantidade");
                sheet.SetValue(linha, 5, "PrevisaoConsumo");


                linha++;

                Crud cc = new Crud();


                //Saldo > 0 , prateleira == "" e nao esta na lista do fora estoque ()
                var l = (from c in cpe
                         join p in cc.ListaSaldo() on c.Codigo equals p.Produto
                         where c.Grupo == "11000000" & c.SaldoKg > 0 & c.Prateleira == "" //& c.Codigo != p.Codigo
                         orderby c.Prateleira, c.Codigo
                         select new { c.Codigo, c.Descricao, c.Prateleira, c.Fornecedor, c.Data, c.SaldoKg, p.ConsuPrevOs }).ToList();


                foreach (var j in l.OrderBy(p => p.Codigo))
                {
                    foreach (var a in ape.OrderBy(p => p.Codigo))
                    {

                        if (j.Codigo == a.Codigo)
                        {
                            l.RemoveAll(p => p.Codigo == a.Codigo);
                        }


                    }
                }

                foreach (var a in l)
                {
                    sheet.SetValue(linha, 1, a.Codigo);
                    sheet.SetValue(linha, 2, a.Descricao);
                    sheet.SetValue(linha, 3, a.Prateleira);
                    sheet.SetValue(linha, 4, Math.Round(a.SaldoKg, 3));
                    sheet.SetValue(linha, 5, a.ConsuPrevOs);

                    linha++;
                }


                DateTime dtss = DateTime.Now;
                ExcelHeaderFooterText footer = sheet.HeaderFooter.OddFooter;
                ExcelHeaderFooterText header = sheet.HeaderFooter.OddHeader;
                header.LeftAlignedText = "SemiAcabadosParaFornecedores";
                footer.RightAlignedText = dtss.ToShortTimeString() + " " + dtss.ToLongDateString();

                var modelTable = sheet.Cells["A1:E" + linha];  //(ape.Count + 1)];
                modelTable.Style.Font.Size = 8;
                modelTable.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                var mt = sheet.Cells["D:D"];
                mt.Style.WrapText = true;



                modelTable.AutoFitColumns();
                mt.AutoFitColumns(30);
                modelTable.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                modelTable.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                modelTable.Style.Border.Right.Style = ExcelBorderStyle.Thin;

                // Aqui você coloca a lógica que precisa escrever nas planilhas.

                string path = @"C:\Exports\ConsultaSemiAcabados.xlsx";
                File.WriteAllBytes(path, excelPackage.GetAsByteArray());

                Process.Start(@"C:\Exports\ConsultaSemiAcabados.xlsx");

                MessageBox.Show("Qualidade Pronto");
            }
        }

        internal static void AcabadosParaExpedicao(List<ClassParaExcell> cpe)
        {
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                excelPackage.Workbook.Properties.Author = "Cid M Evangelista";
                excelPackage.Workbook.Properties.Title = "Meu Excel";

                var sheet = excelPackage.Workbook.Worksheets.Add("AcabadosParaExpedicao");

                sheet.Name = "AcabadosParaExpedicao";
                sheet.PrinterSettings.LeftMargin = 0.3m;
                sheet.PrinterSettings.RightMargin = 0.2m;
                //sheet.PrinterSettings.FitToPage = true;
                //sheet.PrinterSettings.FitToHeight = 150;
                //sheet.PrinterSettings.FitToWidth = 150;
                sheet.PrinterSettings.PaperSize = ePaperSize.A4;

                sheet.SetValue(1, 1, "Código");
                sheet.SetValue(1, 2, "Item");
                sheet.SetValue(1, 3, "Endereço");
                sheet.SetValue(1, 4, "PedidoVenda");


                //UNIR DS COM LISTA TXT
                //DataTable dt = Transforma.TransformandoDataRow(ds, File.OpenRead(@"C:\Users\Estoque\Documents\Exports\ListaCodOrigem.txt"));
                //
                var ds = Crud.Select("SELECT Item, NPedido, DataEntrega, RazaoSocial FROM pedidosdevenda");
                List<PedidoDeVenda> pv = new List<PedidoDeVenda>();
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    pv.Add(new PedidoDeVenda
                    {
                        Item = item["Item"].ToString(),
                        NPedido = item["NPedido"].ToString(),
                        DataEntrega = (DateTime)item["DataEntrega"],
                        RazaoSocial = item["RazaoSocial"].ToString()
                    });
                }

                var ape = (from c in cpe
                           join p in pv on c.Codigo equals p.Item
                           orderby p.NPedido, c.Codigo
                           select new { c.Codigo, c.Descricao, c.Prateleira, p.NPedido, p.DataEntrega, p.RazaoSocial }).ToList();

                var linha = 2;
                foreach (var a in ape)
                {

                    sheet.SetValue(linha, 1, a.Codigo);
                    sheet.SetValue(linha, 2, a.Descricao);
                    sheet.SetValue(linha, 3, a.Prateleira);
                    sheet.SetValue(linha, 4,
                        "PV= " + a.NPedido + "\n" +
                        "ENTG= " + a.DataEntrega.ToString("dd/MM/yyyy") + "\n" +
                        "CLIT= " + a.RazaoSocial
                        );

                    linha++;
                }

                DateTime dts = DateTime.Now;
                ExcelHeaderFooterText footer = sheet.HeaderFooter.OddFooter;
                ExcelHeaderFooterText header = sheet.HeaderFooter.OddHeader;
                header.LeftAlignedText = "AcabadosParaExpedicao";
                footer.RightAlignedText = dts.ToShortTimeString() + " " + dts.ToLongDateString();

                var modelTable = sheet.Cells["A1:E" + (ape.Count + 1)];
                modelTable.Style.Font.Size = 8;
                modelTable.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                var mt = sheet.Cells["D:D"];
                mt.Style.WrapText = true;

                modelTable.AutoFitColumns();
                mt.AutoFitColumns(30);
                modelTable.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                modelTable.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                modelTable.Style.Border.Right.Style = ExcelBorderStyle.Thin;

                string path = @"C:\Exports\AcabadosParaExpedicao.xlsx";
                File.WriteAllBytes(path, excelPackage.GetAsByteArray());

                Process.Start(@"C:\Exports\AcabadosParaExpedicao.xlsx");
            }
        }

        internal static void InventarioDiario(List<RegistroInventario2> id, string lblqtd)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                excelPackage.Workbook.Properties.Author = "Cid M Evangelista";
                excelPackage.Workbook.Properties.Title = "Meu Excel";

                var sheet = excelPackage.Workbook.Worksheets.Add("InventarioDiario");

                sheet.Name = "InventarioDiario";
                sheet.PrinterSettings.LeftMargin = 0.3m;
                sheet.PrinterSettings.RightMargin = 0.2m;
                //sheet.PrinterSettings.FitToPage = true;
                //sheet.PrinterSettings.FitToHeight = 150;
                //sheet.PrinterSettings.FitToWidth = 150;
                sheet.PrinterSettings.Orientation = eOrientation.Portrait;
                sheet.PrinterSettings.PaperSize = ePaperSize.A4;

                sheet.SetValue(1, 1, "Codigo");
                sheet.SetValue(1, 2, "Descrição");
                sheet.SetValue(1, 3, "Prateleira");
                sheet.SetValue(1, 4, "Saldo Kg");
                sheet.SetValue(1, 5, "Saldo M");
                sheet.SetValue(1, 6, "Inventario");

                //UNIR DS COM LISTA TXT

                //
                int line = 0;
                foreach (var item in id)
                {
                    if (item.Produto != null)
                    {
                        sheet.SetValue(line + 2, 1, item.Produto);
                        sheet.SetValue(line + 2, 2, item.Descricao);
                        sheet.SetValue(line + 2, 3, item.Prateleira + (item.Livre17 > 0 ? " C- " + item.Livre17 : "") + " -" + item.OperadorInclusao.Substring(0, 2));
                        sheet.SetValue(line + 2, 4, item.Unid + ": " + Math.Round(item.SaldoAtual, 3));
                        sheet.SetValue(line + 2, 5, Math.Round(item.ValorConvertido, 3));
                        ++line;
                    }
                }

                DateTime dts = DateTime.Today;
                ExcelHeaderFooterText footer = sheet.HeaderFooter.OddFooter;
                ExcelHeaderFooterText header = sheet.HeaderFooter.OddHeader;
                header.LeftAlignedText = "InventarioDiario";
                footer.RightAlignedText = dts.ToLongDateString();
                footer.LeftAlignedText = lblqtd + ", " + id.Count + " Linhas";


                var modelTable = sheet.Cells["A1:F" + (id.Count + 1)];
                sheet.View.ZoomScale = 120;
                sheet.View.PageBreakView = true;
                sheet.Cells.Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                sheet.Column(7).ColumnMax = 40;

                sheet.PrinterSettings.FooterMargin = 0.5M;
                sheet.PrinterSettings.HeaderMargin = 0.0M;
                sheet.PrinterSettings.TopMargin = 0.5M;
                sheet.PrinterSettings.BottomMargin = 0.5M;
                sheet.PrinterSettings.LeftMargin = 0.5M / 2.5M;
                sheet.PrinterSettings.FooterMargin = 0.5M / 2.5M;

                modelTable.Style.Font.Size = 8;
                //sheet.Column(7).Style.Font.Size = 5;


                modelTable.AutoFitColumns();

                modelTable.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                modelTable.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                sheet.Column(7).Style.WrapText = true;

                string path = @"C:\Exports\InventarioDiario.xlsx";
                File.WriteAllBytes(path, excelPackage.GetAsByteArray());

                sw.Stop();
                MessageBox.Show("Inventario pronta, Tempo Decorrido: " + sw.Elapsed, "PRONTO!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                Process.Start(@"C:\Exports\InventarioDiario.xlsx");
            }
        }
    }
}
