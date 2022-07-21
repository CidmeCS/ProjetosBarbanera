using Estoque.DAO;

using System.Data;
using System.IO;

namespace Estoque.Classes
{
    internal class ExportParaExcell
    {
        internal static void Start()
        {

            using (var excelPackage = new OfficeOpenXml.ExcelPackage())
            {
                excelPackage.Workbook.Properties.Author = "Cid M Evangelista";
                excelPackage.Workbook.Properties.Title = "Meu Excel";


                var sheet = excelPackage.Workbook.Worksheets.Add("ExportConsulta");
                sheet.Name = "ExportConsulta";

                sheet.SetValue(1, 1, "Produto");
                sheet.SetValue(1, 2, "Descrição");
                sheet.SetValue(1, 3, "Unid");
                sheet.SetValue(1, 4, "Saldo Atual");
                sheet.SetValue(1, 5, "Estq. Mínimo");
                sheet.SetValue(1, 6, "Estq. Máximo");
                sheet.SetValue(1, 7, "Prateleira");
                sheet.SetValue(1, 8, "Ped.Compras");
                sheet.SetValue(1, 9, "Grupo");
                sheet.SetValue(1, 10, "Dias sem Movimento");


                //
                DataSet ds = new DataSet();
                ds = Crud.Select("SELECT Produto, Descricao, Unid, SaldoAtual, EstqMinimo, EstqMaximo, Prateleira, PedCompras, Grupo, DiassemMovimento FROM estoque.saldos order by Descricao asc");
                //string[,] stg = new string[ds.Tables[0].Rows.Count, 10]; //linha , coluna
                for (int linha = 0; linha < ds.Tables[0].Rows.Count; linha++)
                {

                    for (int coluna = 0; coluna < 10; coluna++)
                    {
                        sheet.SetValue(linha + 2, coluna + 1, ds.Tables[0].Rows[linha].ItemArray[coluna].ToString());
                    }

                }
                //

                // Aqui você coloca a lógica que precisa escrever nas planilhas.

                string path = @"Z:\Cid\ExportConsulta.xlsx";
                File.WriteAllBytes(path, excelPackage.GetAsByteArray());

            }
        }
    }
}