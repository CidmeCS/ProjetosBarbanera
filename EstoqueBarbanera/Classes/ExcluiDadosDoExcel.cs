using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Reflection;

namespace Estoque.Classes
{
    public static class ExcluiDadosDoExcel
    {
        internal static void ExcluiUmaCelula(string item, string filePath)
        {
            string cell = ObterUmaCelula(item, filePath);
            DeleteCell(cell, filePath);
        }

        private static void DeleteCell(string cell, string filePath)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("\nDeleting the Records...");
            Console.BackgroundColor = ConsoleColor.Black;

            Excel.Application xlApp = new Excel.Application();

            Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(
                filePath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);

            Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            //Excel.Range range1 = xlWorkSheet.get_Range("A2", "B2");

            //// To Delete Entire Row - below rows will shift up  
            //range1.EntireRow.Delete(Type.Missing);

            Excel.Range range2 = xlWorkSheet.get_Range(cell, cell);
            range2.Cells.Clear();

            // To Delete Cells - Below cells will shift up  
            // range2.Cells.Delete(Type.Missing);  

            // Disable file override confirmaton message  
            xlApp.DisplayAlerts = false;
            xlWorkBook.SaveAs(filePath, Excel.XlFileFormat.xlOpenXMLWorkbook,
                Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlNoChange,
                Excel.XlSaveConflictResolution.xlLocalSessionChanges, Missing.Value, Missing.Value,
                Missing.Value, Missing.Value);
            xlWorkBook.Close();
            xlApp.Quit();

            Marshal.ReleaseComObject(xlWorkSheet);
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);
        }

        private static string ObterUmaCelula(string item, string filePath)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("\nReading the Excel File...");
            Console.BackgroundColor = ConsoleColor.Black;

            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(filePath);
            Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            Excel.Range xlRange = xlWorkSheet.UsedRange;
            int totalRows = xlRange.Rows.Count;
            int totalColumns = xlRange.Columns.Count;

            string firstValue, secondValue;
            string cell = string.Empty;
            for (int rowCount = 1; rowCount <= totalRows; rowCount++)
            {

                firstValue = Convert.ToString((xlRange.Cells[rowCount, 1] as Excel.Range).Text);
                if (item == firstValue)
                {
                    cell = "A" + rowCount;
                    Console.WriteLine($"{firstValue} {cell}"/*+ "\t" + secondValue*/);
                    break;
                }
                //secondValue = Convert.ToString((xlRange.Cells[rowCount, 2] as Excel.Range).Text);
            }

            xlWorkBook.Close();
            xlApp.Quit();

            Marshal.ReleaseComObject(xlWorkSheet);
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);

            Console.WriteLine("End of the file...");
            return cell;
        }
    }
}
