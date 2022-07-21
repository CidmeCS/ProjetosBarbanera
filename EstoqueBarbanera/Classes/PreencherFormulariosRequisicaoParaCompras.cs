using Estoque.Classes3;
using Estoque.DAO;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Style;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Estoque.Classes
{
    internal class PreencherFormulariosRequisicaoParaCompras
    {
        static DateTime dts, dts2;
        static string path;
        static string produto;



        internal static string Start(ArrayList linhas)
        {
            Directory.CreateDirectory($@"Z:\Cid\Requisicoes");

            CriarFormulario(linhas);
            return path;

        }

        private static void CriarFormulario(ArrayList linhas)
        {
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                excelPackage.Workbook.Properties.Author = "Cid M Evangelista";
                excelPackage.Workbook.Properties.Title = "Requisição Para Compras";
                var pathimg = $@"Z:\Cid\Requisicoes\logobarbanera.png";
                var sheet = excelPackage.Workbook.Worksheets.Add("Requisição Para Compras");

                int l = 0;

                //margens da pagina
                sheet.Name = "Requisição Para Compras";
                sheet.PrinterSettings.LeftMargin = 0.25m;
                sheet.PrinterSettings.RightMargin = 0.25m;
                sheet.PrinterSettings.TopMargin = 0.50m;
                sheet.PrinterSettings.BottomMargin = 0.50m;
                sheet.PrinterSettings.PaperSize = ePaperSize.A4;
                sheet.PrinterSettings.Scale = 95;

                //largura da coluna
                sheet.Column(4).Width = 44; // coluna D
                sheet.Column(5).Width = 15.5; // coluna E
                sheet.Column(3).Width = 15.5; // COLUNA C
                sheet.Column(6).Width = 10; // COLUNA F

                //images
                Image logo = Image.FromFile(pathimg);
                ExcelPicture picture1 = null, picture2 = null, picture3 = null, picture4 = null, picture5 = null, picture6 = null, picture7 = null, picture8 = null, picture9 = null, picture10 = null, picture11 = null, picture12 = null, picture13 = null, picture14 = null, picture15 = null, picture16 = null, picture17 = null, picture18 = null, picture19 = null, picture20 = null;
                List<ExcelPicture> ep = new List<ExcelPicture>() { picture1, picture2, picture3, picture4, picture5, picture6, picture7, picture8, picture9, picture10, picture11, picture12, picture13, picture14, picture15, picture16, picture17, picture18, picture19, picture20 };

                List<ExcelPicture> imag = new List<ExcelPicture>();
                int r = 0;
                foreach (LinhasGridView item in linhas)
                {

                    //LINHA, COLUNA
                    //CABEÇALHOS
                    sheet.SetValue(l + 1, 1, "LOGO");
                    sheet.SetValue(l + 1, 3, "REQUISIÇÃO \r PARA COMPRAS");
                    sheet.SetValue(l + 1, 5, "RC-07/04 (Revisão 0 - 09/2017)");
                    sheet.SetValue(l + 2, 5, "Nº");

                    //mesclar
                    sheet.Cells[l + 1, 1, l + 2, 2].Merge = true; //mescla de A1:B2 LOGO
                    sheet.Cells[l + 1, 3, l + 2, 4].Merge = true; //mescla de C1:D2 REQUISICAO PARA COMPRAS
                    sheet.Cells[l + 1, 5, l + 1, 6].Merge = true; //mescla de E1:F1 RC-07/04 (l+Revisão 0 - 09/2017)
                    sheet.Cells[l + 2, 5, l + 2, 6].Merge = true; //mescla de E2:F2 Nº
                    sheet.Cells[l + 3, 3, l + 3, 5].Merge = true; //mescla de E2:F2 Nº

                    sheet.Cells[l + 12, 1, l + 12, 3].Merge = true; //revenda
                    sheet.Cells[l + 13, 1, l + 13, 3].Merge = true; //fornecedor
                    sheet.Cells[l + 14, 1, l + 14, 3].Merge = true; //elaborado
                    sheet.Cells[l + 15, 1, l + 15, 3].Merge = true; //requisitado

                    sheet.Cells[l + 12, 4, l + 13, 4].Merge = true; //certificado

                    sheet.Cells[l + 12, 5, l + 13, 5].Merge = true; //comprador
                    sheet.Cells[l + 12, 6, l + 13, 6].Merge = true; //recibo
                    sheet.Cells[l + 14, 5, l + 15, 6].Merge = true; //data preenchimento
                    sheet.Cells[l + 6, 1, l + 6, 2].Merge = true; //quantidade do estoque

                    //mesclar linhas Descricao **campos em branco
                    for (int i = 4; i <= 11; i++)
                    {
                        sheet.Cells[l + i, 3, l + i, 5].Merge = true;
                    }
                    sheet.Cells[l + 7, 3, l + 8, 5].Merge = true; //mescla pedido venda 

                    // quebra de texto
                    sheet.Cells[l + 1, 3, l + 2, 4].Style.WrapText = true;
                    sheet.Cells[l + 12, 4].Style.WrapText = true;
                    sheet.Cells[l + 14, 1, l + 15, 4].Style.WrapText = true;
                    sheet.Cells[l + 14, 5, l + 15, 6].Style.WrapText = true;
                    sheet.Cells[l + 4, 1, l + 11, 5].Style.WrapText = true;
                    sheet.Cells[l + 7, 3].Style.WrapText = true; 

                    //alinhando vertical
                    sheet.Cells[l + 1, 1, l + 2, 6].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    sheet.Cells[l + 1, 5].Style.VerticalAlignment = ExcelVerticalAlignment.Top;
                    sheet.Cells[l + 12, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    sheet.Cells[l + 12, 4].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    sheet.Cells[l + 13, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    sheet.Cells[l + 15, 4].Style.VerticalAlignment = ExcelVerticalAlignment.Top;
                    sheet.Cells[l + 12, 5, l + 15, 6].Style.VerticalAlignment = ExcelVerticalAlignment.Top;
                    sheet.Cells[l + 4, 1, l + 11, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    sheet.Cells[l + 4, 3, l + 11, 5].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    //alinhando horizontal
                    sheet.Cells[l + 1, 1, l + 1, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    sheet.Cells[l + 3, 1, l + 3, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    sheet.Cells[l + 1, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    sheet.Cells[l + 12, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    sheet.Cells[l + 12, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    sheet.Cells[l + 12, 5, l + 15, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    sheet.Cells[l + 4, 1, l + 11, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    sheet.SetValue(l + 3, 1, "QUANT.");
                    sheet.SetValue(l + 3, 2, "UNIDADE");
                    sheet.SetValue(l + 3, 3, "DESCRIÇÃO DO MATERIAL");
                    sheet.SetValue(l + 3, 6, "OP");

                    sheet.SetValue(l + 12, 1, "REVENDA (  )  USINA (  )  OUTRO (  )");
                    sheet.SetValue(l + 13, 1, "FORNECEDOR:");
                    sheet.SetValue(l + 14, 1, "ELABORADO\rPOR:");
                    sheet.SetValue(l + 15, 1, "REQUISITADO\rPOR:");
                    sheet.SetValue(l + 12, 4, "CERTIFICADO DE MATERIAL\rEXIGÍVEL(  )            NÃO EXIGÍVEL(  )");
                    sheet.SetValue(l + 14, 4, "PRAZO\rSOLICITADO  ____/____/_______");
                    sheet.SetValue(l + 15, 4, "ASSINATURA");
                    sheet.SetValue(l + 12, 5, "COMPRADOR(A)");
                    sheet.SetValue(l + 12, 6, "RECEBIDO");
                    dts2 = DateTime.Now;
                    sheet.SetValue(l + 14, 5, $"DATA DE PREENCHIMENTO \r\r{dts2.ToLongDateString()}");

                    //bordas docinteiro
                    sheet.Cells[l + 1, 1, l + 15, 6].Style.Border.BorderAround(ExcelBorderStyle.Thin);

                    //grade dados
                    sheet.Cells[l + 3, 1, l + 15, 6].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    sheet.Cells[l + 3, 1, l + 15, 6].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    sheet.Cells[l + 3, 1, l + 15, 6].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    sheet.Cells[l + 3, 1, l + 15, 6].Style.Border.Right.Style = ExcelBorderStyle.Thin;

                    //altura linas 
                    sheet.Row(l + 1).Height = 35; //linha 1
                    sheet.Row(l + 2).Height = 35; //linha 2
                    for (int i = 4; i < 15; i++)
                    {
                        sheet.Row(l + i).Height = 25; //linhas restantes
                    }
                    sheet.Row(l + 14).Height = 30;
                    sheet.Row(l + 15).Height = 30;

                    //tamanho da fonte
                    sheet.Cells[l + 1, 3].Style.Font.Size = 18;
                    sheet.Cells[l + 1, 5].Style.Font.Size = 8;
                    sheet.Cells[l + 2, 5].Style.Font.Size = 18;
                    sheet.Cells[l + 4, 3, l + 11, 3].Style.Font.Size = 10;
                    sheet.Cells[l + 7, 3].Style.Font.Size = 8;

                    //negrito fonte
                    sheet.Cells[l + 1, 3].Style.Font.Bold = true;

                    // inserir imagem

                    ep[r] = sheet.Drawings.AddPicture(r.ToString(), logo);
                    ep[r].From.Column = 0;
                    ep[r].From.Row = l;
                    ep[r].SetSize(99);
                    ep[r].SetPosition(2 + (r * 542), 20);

                    //inserir dados
                    string cod = null;

                    sheet.SetValue(l + 4, 3, "Codigo: " + item.Produto);
                    produto = item.Produto;
                    DataSet ds = new DataSet();
                    ds = Crud.Select($"SELECT ID FROM estoque.solicitacao where Produto = '{item.Produto}' order by ID desc limit 1");
                    cod = ds.Tables[0].Rows[0].ItemArray[0].ToString();

                    sheet.SetValue(l + 5, 3, "Descricao: " + item.Descricao); ;
                    sheet.SetValue(l + 4, 2, item.Unid); ; // unidade
                    sheet.SetValue(l + 6, 1, "QTD Estq: " + item.QTD_Pedida); ; //qtd pedidda

                    sheet.SetValue(l + 4, 1, item.PEDIR.ToString().Split(';')[0].Trim().Replace(".000", ""));
                    sheet.SetValue(l + 5, 1, item.PEDIR.ToString().Split(';')[1].Trim().Replace(".000", "").Replace("-", "")); ; // qtd pedida
                    sheet.SetValue(l + 6, 3, "Saldo: " + item.SaldoAtual + "\rDisponivel: " + item.Disponivel);
                    sheet.SetValue(l + 7, 3, "PedCompra: " + item.PedCompra + " >>\r" + BuscaPedCompras.Start(item.Produto) + "\rReqCompra: " + BuscarRequisicaoCompra.Start(item.Produto)); 
                    sheet.SetValue(l + 9, 3, "PrevisaoFabricacao: " + item.PrevFabric);
                    sheet.SetValue(l + 10, 3, "EstoqueMinimo: " + item.EstqMinimo + "\rEstoqueMaximo: " + item.EstqMaximo);
                    sheet.SetValue(l + 11, 3, "Consumo Prev OS: " + item.ConsuPrevOs + " >> " + BuscaOS.Start(produto)); ;
                    sheet.SetValue(l + 2, 5, "Nº: E-" + cod); ;

                    r++;
                    l += 16;

                }
                dts = DateTime.Now;
                path = $@"Z:\Cid\Requisicoes\Requisicao {dts.ToString("yyyy-MM-dd HH-mm")}.xlsx";
                File.WriteAllBytes(path, excelPackage.GetAsByteArray());
                SalvarEmPDF.Start(path);
                Process.Start(path);
            }
        }
    }
}
