using ImportExportERP.Views;
using System;
using System.Windows.Forms;

namespace ImportExportERP
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new Principal(args)); // padrao
            //Application.Run(new ParaEtiquetas());
            //Application.Run(new PadronizarColunasDados());

        }
    }
}
