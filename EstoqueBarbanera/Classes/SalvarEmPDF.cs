using SautinSoft;
using System;
using System.IO;

namespace Estoque.Classes
{
    internal class SalvarEmPDF
    {
        internal static void Start(string path)
        {
            //tem que tirar a versao trial
            ExcelToPdf epdf = new ExcelToPdf();
            string pdfFile = Path.ChangeExtension(path, ".pdf");
            epdf.PageStyle.PageSize.A4();
            epdf.PageStyle.PageOrientation.Portrait();
            epdf.PageStyle.PageMarginTop.mm(5);
            epdf.PageStyle.PageMarginBottom.mm(5);
            epdf.PageStyle.PageMarginLeft.mm(5);
            epdf.PageStyle.PageMarginRight.mm(5);
            epdf.ConvertFile(path, pdfFile);
            //epdf.ConvertByteToFile(v, pdfFile);

        }
    }
}