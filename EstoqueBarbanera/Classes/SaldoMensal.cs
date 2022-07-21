using Estoque.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Linq;
using OfficeOpenXml;

namespace Estoque.Classes
{
    internal class SaldoMensal
    {

        
        public static List<TipoItemSped> resum;
        public static List<ListaSaldoMensal> result;

        public static string anotacao = 
            "FAZER INVENTARIO DO ÚLTIMO MES FECHADO, SÓ DE CUSTO, \n" +
            "CRIA A CAPA DE LOTE, \n" +
            "NUMERO == ANOMESDIA (200608) == 20/06/2020 INVERTIDO \n" +
            "COM MES FECHADO FLEGADO, \n " +
            "DATA ATUAL CORRENTE \n " +
            "INCLUI O ITEM \n " +
            "NUMERO FICHA == 01 \n" +
            "TIPO INVENTARIO == UC - VALOR UNITARIO PARA MOEDA CORRENTE \n" +
            "ADICIONA O VALOR UNITADRIO \n" +
            "EFETIVA INVENTARIO \n" +
            "ANOTA O ULTIMO MES FECHADO/ANO CORRENTE \n" +
            "TIPO DE INVENTARIO == ACUMULAR SALDOS INSERE O NUMERO DA  CAPA DO LOTE";

        public static List<string> iS { get; private set; }
        public static List<ListaSaldoMensal> lsm { get; private set; }

        internal static string LancarEXCEL()
        {
            
            ObterDados();

            using (var excelPackage = new OfficeOpenXml.ExcelPackage())
            {
                excelPackage.Workbook.Properties.Author = "Cid M Evangelista";
                excelPackage.Workbook.Properties.Title = "Meu Excel";


                var sheet = excelPackage.Workbook.Worksheets.Add("ExportConsulta");
                sheet.Name = "ExportConsulta";
                sheet.SetValue("I1", "FILTRE OS GRUPOS 10, 11, 12, 15 E 20");
                sheet.Cells["I1"].Style.WrapText = true;
                sheet.Cells["I1"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                sheet.Cells["I1"].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
                sheet.Cells["D3:D10000"].Style.Numberformat.Format = "#,##0.000";
                sheet.Cells["E3:I10000"].Style.Numberformat.Format = "_-R$* #,##0.00_-;-$* #,##0.00_-;_-$* \"-\"??_-;_-@_-";

                sheet.Cells["A2:L2"].AutoFilter = true;

                //primeira linha
                sheet.SetValue("A2", "Código");
                sheet.SetValue("B2", "Descrição");
                sheet.SetValue("C2", "Unidade");
                sheet.SetValue("D2", "Saldo Físico");
                sheet.SetValue("E2", "Preco Compra");
                sheet.SetValue("F2", "Preço Venda");
                sheet.SetValue("G2", "Custo Médio");
                sheet.SetValue("H2", "Saldo x Custo Médio");
                sheet.SetValue("I2", "Saldo x Preço (Compra/Venda)");
                sheet.SetValue("J2", "Grupo");
                sheet.SetValue("K2", "Posição Fiscal");
                sheet.SetValue("L2", "Tipo Item Sped");


                int l = 3;
                foreach (var item in lsm)
                {
                    sheet.SetValue("A" + l, item.Codigo);
                    sheet.SetValue("B" + l, item.Descricao);
                    sheet.SetValue("C" + l, item.Unidade);
                    sheet.SetValue("D" + l, item.SaldoFisico);
                    sheet.SetValue("E" + l, item.PrecoCompra);
                    sheet.SetValue("F" + l, item.PrecoVenda);
                    sheet.SetValue("G" + l, item.CustoMedio);
                    sheet.SetValue("H" + l, item.SaldoCustoMedio);
                    sheet.SetValue("I" + l, item.SaldoPrecoCompraVenda);
                    sheet.SetValue("J" + l, item.Grupo);
                    sheet.SetValue("K" + l, item.PosicaoFiscal);
                    sheet.SetValue("L" + l, item.TipoItemSped);
                    l++;
                }

                
                //sheet = FiltrandoGrupo(sheet);

                sheet.View.ZoomScale = 70;
                sheet.Cells["A2:L" + lsm.Count + 1].AutoFitColumns();
                sheet.Cells["A2:L2"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                sheet.Cells["A2:L2"].Style.Fill.BackgroundColor.SetColor(Color.CadetBlue);
                sheet.Cells["H2"].Style.Fill.BackgroundColor.SetColor(Color.Coral);
                sheet.Cells["I2"].Style.Fill.BackgroundColor.SetColor(Color.Tomato);
                sheet.View.FreezePanes(3, 1);

                PlanilhaResumo(lsm, excelPackage);
                PlanilhaResumoCustoMedio(lsm, excelPackage);

                var dia = DateTime.Today;
                string path = @"C:\Exports\SaldoMensal " + dia.ToString("yyyy-MM-dd") + ".xlsx";
                File.WriteAllBytes(path, excelPackage.GetAsByteArray());
                Process.Start(path);
                Thread.Sleep(10000);

                Pendencias();
                return path;
            }
        }

        public static void ObterDados()
        {
            Crud c = new Crud();
            var lie = c.ListaItensDeEstoque();

           //populando a classe ListaSaldoMensal dom o daset do banco
            lsm = new List<ListaSaldoMensal>();
            foreach (var item in lie)
            {
                lsm.Add(new ListaSaldoMensal
                {
                    Codigo = item.Codigo,
                    Descricao = item.Descricao,
                    Unidade = item.Unidade,
                    SaldoFisico = item.SaldoFisico,
                    PrecoCompra = item.PrecoCompra,
                    PrecoVenda = item.PrecoVenda,
                    CustoMedio = item.CustoMedio,
                    SaldoCustoMedio = item.SaldoFisico * item.CustoMedio,
                    SaldoPrecoCompraVenda = item.Grupo == "10000000"  ? Math.Round(item.SaldoFisico * item.PrecoVenda,3) : item.Grupo != "11000000" ? Math.Round(item.SaldoFisico * item.PrecoCompra,3) : 0.00,
                    Grupo = item.Grupo,
                    PosicaoFiscal = item.PosicaoFiscal,
                    TipoItemSped = item.TipoItemSped,
                    ItemCadastradoEm = item.ItemCadastradoEm
                });
            }
        }

        private static void Pendencias()
        {
            using (var excelPackage2 = new OfficeOpenXml.ExcelPackage())
            {
                excelPackage2.Workbook.Properties.Author = "Cid M Evangelista";
                excelPackage2.Workbook.Properties.Title = "Meu Excel";

                Pendencias(lsm, excelPackage2, "10000000", "Produto Acabado");
                Pendencias(lsm, excelPackage2, "11000000", "Produto em Processo");
                Pendencias(lsm, excelPackage2, "12000000", "Matéria-Prima");
                Pendencias(lsm, excelPackage2, "15000000", "Produto Intermediário");
                Pendencias(lsm, excelPackage2, "16000000", "Material de Uso e Consumo");
                Pendencias(lsm, excelPackage2, "17000000", "Subproduto");
                Pendencias(lsm, excelPackage2, "20000000", "Outros insumos");

                Grupo11NaoValorizado(lsm, excelPackage2);

                NaoValorizadoTodos(lsm, excelPackage2);


                var dia2 = DateTime.Today;
                string path2 = @"C:\Exports\SaldoMensalPendencias " + dia2.ToString("yyyy-MM-dd") + ".xlsx";
                File.WriteAllBytes(path2, excelPackage2.GetAsByteArray());
                Process.Start(path2);
                Thread.Sleep(10000);
            }
        }

        private static void NaoValorizadoTodos(List<ListaSaldoMensal> lsm, ExcelPackage excelPackage2)
        {
            DateTime data = ObtemData();

            var ppnv = (from l in lsm
                        where
          l.SaldoFisico > 0 &
          (
          l.Grupo == "10000000" |
          l.Grupo == "12000000" |
          l.Grupo == "15000000" |
          l.Grupo == "16000000" |
          l.Grupo == "17000000" |
          l.Grupo == "20000000"
          ) &
          l.SaldoPrecoCompraVenda == 0 &
          l.ItemCadastradoEm <= data
                        select l).ToList();

            var sheet4 = excelPackage2.Workbook.Worksheets.Add("SEM VALOR EXCETO G11");
            sheet4.Name = "SEM VALOR EXCETO G11";

            //primeira linha
            sheet4.SetValue("A1", "Código");
            sheet4.SetValue("B1", "Descrição");
            sheet4.SetValue("C1", "Unidade");
            sheet4.SetValue("D1", "Saldo Físico");
            sheet4.SetValue("E1", "Preco Compra");
            sheet4.SetValue("F1", "Preço Venda");
            sheet4.SetValue("G1", "Custo Médio");
            sheet4.SetValue("H1", "Saldo x Custo Médio");
            sheet4.SetValue("I1", "Saldo x Preço (Compra/Venda)");
            sheet4.SetValue("J1", "Grupo");
            sheet4.SetValue("K1", "Posição Fiscal");
            sheet4.SetValue("L1", "Tipo Item Sped");
            sheet4.SetValue("M1", "DataCadastro");
            int r = 2;
            foreach (var item in ppnv)
            {
                sheet4.SetValue(r, 1, item.Codigo);
                sheet4.SetValue(r, 2, item.Descricao);
                sheet4.SetValue(r, 3, item.Unidade);
                sheet4.SetValue(r, 4, item.SaldoFisico);
                sheet4.SetValue(r, 5, item.PrecoCompra);
                sheet4.SetValue(r, 6, item.PrecoVenda);
                sheet4.SetValue(r, 7, item.CustoMedio);
                sheet4.SetValue(r, 8, item.SaldoCustoMedio);
                sheet4.SetValue(r, 9, item.SaldoPrecoCompraVenda);
                sheet4.SetValue(r, 10, item.Grupo);
                sheet4.SetValue(r, 11, item.PosicaoFiscal);
                sheet4.SetValue(r, 12, item.TipoItemSped);
                sheet4.SetValue(r, 13, item.ItemCadastradoEm);
                r++;
            }

            sheet4.Cells["A1:M" + r].AutoFitColumns();
            sheet4.Cells[r + 2, 2].Style.WrapText = true;
            sheet4.SetValue(r + 2, 2, @"Incluir Valor no Cadastro do item. \n
                                    Você pode usar o app E:\Macro Recorder\incluir preço 2.mcrn\
                                    Use duas colunas no excel: Codigo e Preço/Valor. APENAS!!");
            sheet4.View.ZoomScale = 85;
            sheet4.View.FreezePanes(2, 1);
            sheet4.Cells["A1:M1"].AutoFilter = true;
            sheet4.Cells["M:M"].Style.Numberformat.Format = "dd-MM-yyyy";
        }

        public static List<ListaSaldoMensal> ListarGrupo11NaoValorizado()
        {
            DateTime data = ObtemData();
            ObterDados();
            
            return (from l in lsm
                        where
          l.SaldoFisico > 0 &
          l.Grupo == "11000000" &
          l.SaldoCustoMedio == 0 &
          l.ItemCadastradoEm.Date <= data
                        select l).ToList();

        }

        private static void Grupo11NaoValorizado(List<ListaSaldoMensal> lsm, OfficeOpenXml.ExcelPackage excelPackage)
        {
            DateTime data = ObtemData();

            //PPs Nao valorizados
            var ppnv = (from l in lsm
                        where
          l.SaldoFisico > 0 &
          l.Grupo == "11000000" &
          l.SaldoCustoMedio == 0 &
          l.ItemCadastradoEm.Date <= data
                        select l).ToList();

            var sheet4 = excelPackage.Workbook.Worksheets.Add("GRUPO 11 NAO VALORIZADO");
            sheet4.Name = "GRUPO 11 NAO VALORIZADO";

            //primeira linha
            sheet4.SetValue("A1", "Código");
            sheet4.SetValue("B1", "Descrição");
            sheet4.SetValue("C1", "Unidade");
            sheet4.SetValue("D1", "Saldo Físico");
            sheet4.SetValue("E1", "Preco Compra");
            sheet4.SetValue("F1", "Preço Venda");
            sheet4.SetValue("G1", "Custo Médio");
            sheet4.SetValue("H1", "Saldo x Custo Médio");
            sheet4.SetValue("I1", "Saldo x Preço (Compra/Venda)");
            sheet4.SetValue("J1", "Grupo");
            sheet4.SetValue("K1", "Posição Fiscal");
            sheet4.SetValue("L1", "Tipo Item Sped");
            sheet4.SetValue("M1", "DataCadastro");
            int r = 2;
            foreach (var item in ppnv)
            {
                sheet4.SetValue(r, 1, item.Codigo);
                sheet4.SetValue(r, 2, item.Descricao);
                sheet4.SetValue(r, 3, item.Unidade);
                sheet4.SetValue(r, 4, item.SaldoFisico);
                sheet4.SetValue(r, 5, item.PrecoCompra);
                sheet4.SetValue(r, 6, item.PrecoVenda);
                sheet4.SetValue(r, 7, item.CustoMedio);
                sheet4.SetValue(r, 8, item.SaldoCustoMedio);
                sheet4.SetValue(r, 9, item.SaldoPrecoCompraVenda);
                sheet4.SetValue(r, 10, item.Grupo);
                sheet4.SetValue(r, 11, item.PosicaoFiscal);
                sheet4.SetValue(r, 12, item.TipoItemSped);
                sheet4.SetValue(r, 13, item.ItemCadastradoEm);
                r++;
            }

            sheet4.Cells["A1:M" + r].AutoFitColumns();
            sheet4.Cells[r + 2, 2].Style.WrapText = true;
            sheet4.SetValue(r + 2, 2, anotacao);
            sheet4.View.ZoomScale = 85;

            sheet4.View.FreezePanes(2, 1);
            sheet4.Cells["A1:M1"].AutoFilter = true;
            sheet4.Cells["M:M"].Style.Numberformat.Format = "dd-MM-yyyy";

            //
        }

        public static DateTime ObtemData()
        {
            DateTime hoje = DateTime.Today;
            DateTime data = new DateTime();
            if (hoje.Day >= 28)
            {
                data = hoje.AddDays(-hoje.Day);
            }
            else if (hoje.Day >= 1)
            {
                data = hoje.AddMonths(-1).AddDays(-hoje.Day);
            }

            return data;
        }

        private static void Pendencias(List<ListaSaldoMensal> lsm, OfficeOpenXml.ExcelPackage excelPackage, string grupo, string itemsped)
        {
            result = (from l in lsm
                      where (
                      l.Grupo == grupo & l.TipoItemSped != itemsped) |
                      (l.Grupo == grupo & l.PosicaoFiscal.Length < 8)
                      select l).ToList();

            if (result.Count > 0)
            {
                var sheet3 = excelPackage.Workbook.Worksheets.Add("GRUPO " + grupo);
                sheet3.Name = "GRUPO " + grupo;

                int r = 1;
                sheet3.SetValue("A1", "Codigo");
                sheet3.SetValue("B1", "Descricao");
                sheet3.SetValue("C1", "Grupo");
                sheet3.SetValue("D1", "PosiçãoFiscal");
                sheet3.SetValue("E1", "TipoItemSPED");
                sheet3.SetValue("G5", $"Inconsistência: Posição fiscal com Menos de 8 digitos ou TipoItemSPED incorreto");
                sheet3.SetValue("G6", $"Grupo = {grupo}");
                sheet3.SetValue("G7", $"ItemSped {itemsped}");
                foreach (var item in result)
                {
                    r++;
                    sheet3.SetValue(r, 1, item.Codigo);
                    sheet3.SetValue(r, 2, item.Descricao);
                    sheet3.SetValue(r, 3, item.Grupo);
                    sheet3.SetValue(r, 4, item.PosicaoFiscal);
                    sheet3.SetValue(r, 5, item.TipoItemSped);
                }

                sheet3.Cells["A:E"].AutoFitColumns();

                sheet3.View.FreezePanes(2, 1);
                sheet3.Cells["A1:E1"].AutoFilter = true;
            }
        }

        private static void PlanilhaResumo(List<ListaSaldoMensal> lsm, OfficeOpenXml.ExcelPackage excelPackage)
        {
            var sheet2 = excelPackage.Workbook.Worksheets.Add("RESUMO");
            sheet2.Name = "RESUMO";

            //colunas

            resum = lsm.GroupBy(v => v.TipoItemSped).Where(p => p.Key.Length > 0).Select(g => new TipoItemSped
            {
                TipoItemSpedd = g.Key,
                SaldoPrecoCompraVenda = g.Sum(p => p.SaldoPrecoCompraVenda),
                SaldoCustoMedio = g.Sum(p => p.SaldoCustoMedio),
            }).ToList();

            int c = 2;
            int r = 2;
            sheet2.SetValue(r, c, "Tipo Item SPED");
            sheet2.SetValue(r, c + 1, "Valor");
            sheet2.SetValue(r, c + 2, "Da Coluna");

            sheet2.Cells["B2:D2"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            sheet2.Cells["B2:D2"].Style.Fill.BackgroundColor.SetColor(Color.CadetBlue);
            foreach (var item in resum)
            {
                sheet2.SetValue(++r, c, item.TipoItemSpedd);
                sheet2.SetValue(r, c + 1, item.TipoItemSpedd == "Produto em Processo" ? item.SaldoCustoMedio : item.SaldoPrecoCompraVenda);
                sheet2.SetValue(r, c + 2, item.TipoItemSpedd == "Produto em Processo" ? "Saldo x Custo Médio" : "Saldo x Preço (Compra/Venda)");
                if (item.TipoItemSpedd == "Outras" & item.SaldoPrecoCompraVenda < 0)
                {
                    sheet2.SetValue(r, c + 1, "");
                }
            }

            //sheet2.Cells["C20"].Formula = "=SOMA(C3:C19)";
            sheet2.SetValue("C20", "=SOMA(C3:C19)");
            sheet2.SetValue("B20", "TOTAL GERAL");
            sheet2.Cells["B20:C20"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            sheet2.Cells["B20:C20"].Style.Font.Bold = true;
            sheet2.Cells["B2:D2"].Style.Font.Bold = true;
            sheet2.Cells["B20:C20"].Style.Fill.BackgroundColor.SetColor(Color.CadetBlue);

            // descobre a celula para pintar
            int s = 0;
            for (int i = 1; i < 30; i++)
            {
                var sss = (string)sheet2.GetValue(i, 2);
                if ((string)sheet2.GetValue(i, 2) == "Produto em Processo")
                {
                    s = i;
                    break;
                }

            }

            sheet2.Cells[$"B{s}:D{s}"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            sheet2.Cells[$"B{s}:D{s}"].Style.Fill.BackgroundColor.SetColor(Color.Coral);

            sheet2.Cells["C3:C19"].Style.Numberformat.Format = "_-R$* #,##0.00_-;-$* #,##0.00_-;_-$* \"-\"??_-;_-@_-";
            sheet2.Cells["B:D"].AutoFitColumns();
        }

        private static void PlanilhaResumoCustoMedio(List<ListaSaldoMensal> lsm, OfficeOpenXml.ExcelPackage excelPackage)
        {
            var sheet2 = excelPackage.Workbook.Worksheets.Add("RESUMO CUSTO MÉDIO");
            sheet2.Name = "RESUMO CUSTO MÉDIO";

            //colunas

            resum = lsm.GroupBy(v => v.TipoItemSped).Where(p => p.Key.Length > 0).Select(g => new TipoItemSped
            {
                TipoItemSpedd = g.Key,
                SaldoPrecoCompraVenda = g.Sum(p => p.SaldoPrecoCompraVenda),
                SaldoCustoMedio = g.Sum(p => p.SaldoCustoMedio),
            }).ToList();

            int c = 2;
            int r = 2;
            sheet2.SetValue(r, c, "Tipo Item SPED");
            sheet2.SetValue(r, c + 1, "Valor");
            sheet2.SetValue(r, c + 2, "Da Coluna");

            sheet2.Cells["B2:D2"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            sheet2.Cells["B2:D2"].Style.Fill.BackgroundColor.SetColor(Color.CadetBlue);
            foreach (var item in resum)
            {
                sheet2.SetValue(++r, c, item.TipoItemSpedd);
                sheet2.SetValue(r, c + 1, item.SaldoCustoMedio);
                sheet2.SetValue(r, c + 2, "Saldo x Custo Médio");
            }
            
            sheet2.SetValue("C20", "=SOMA(C3:C19)");
            sheet2.SetValue("B20", "TOTAL GERAL");
            sheet2.Cells["B20:C20"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            sheet2.Cells["B20:C20"].Style.Font.Bold = true;
            sheet2.Cells["B2:D2"].Style.Font.Bold = true;
            sheet2.Cells["B20:C20"].Style.Fill.BackgroundColor.SetColor(Color.CadetBlue);

            sheet2.Cells["C3:C19"].Style.Numberformat.Format = "_-R$* #,##0.00_-;-$* #,##0.00_-;_-$* \"-\"??_-;_-@_-";
            sheet2.Cells["B:D"].AutoFitColumns();
        }

        public class Colunas
        {
            public string Nome { get; set; }
            public int Orddinal { get; set; }
        }

        public class ListaSaldoMensal
        {
            public string Codigo { get; set; }
            public string Descricao { get; internal set; }
            public string Unidade { get; internal set; }
            public double SaldoFisico { get; internal set; }
            public double PrecoCompra { get; internal set; }
            public double PrecoVenda { get; internal set; }
            public double CustoMedio { get; internal set; }
            public double SaldoCustoMedio { get; internal set; }
            public double SaldoPrecoCompraVenda { get; internal set; }
            public string Grupo { get; internal set; }
            public string PosicaoFiscal { get; internal set; }
            public string TipoItemSped { get; internal set; }
            public DateTime ItemCadastradoEm { get; internal set; }
        }

        public class TipoItemSped
        {
            public string TipoItemSpedd { get; set; }
            public double SaldoPrecoCompraVenda { get; internal set; }
            public double SaldoCustoMedio { get; internal set; }
        }


    }
}