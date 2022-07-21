using Estoque.DAO;
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Estoque
{
    internal class TabConvercaoExcel
    {
        internal static void Start()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            using (var excelPackage = new OfficeOpenXml.ExcelPackage())
            {
                excelPackage.Workbook.Properties.Author = "Cid M Evangelista";
                excelPackage.Workbook.Properties.Title = "Meu Excel";


                var sheet = excelPackage.Workbook.Worksheets.Add("Plan1");
                sheet.Name = "Plan1";

                sheet.SetValue(1, 1, "Codigo");
                sheet.SetValue(1, 2, "Descrição");
                sheet.SetValue(1, 3, "Und");
                sheet.SetValue(1, 4, "Kg_Metro");



                //
                DataSet ds = new DataSet();
                ds = Crud.Select("SELECT * FROM conversor order by descricao asc");

                for (int linha = 0; linha < ds.Tables[0].Rows.Count; linha++)
                {

                    for (int coluna = 0; coluna < 4; coluna++)
                    {
                        sheet.SetValue(linha + 2, coluna + 1, ds.Tables[0].Rows[linha].ItemArray[coluna].ToString());
                    }

                }

                string path = @"Z:\Cid\tabConversao.xlsx";
                File.WriteAllBytes(path, excelPackage.GetAsByteArray());
                sw.Stop();
                MessageBox.Show("tabConversao pronta, Tempo Decorrido: " + sw.Elapsed);

            }
        }
    }
}