using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SincronizaProjetosEstoque
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSincroniza_Click(object sender, EventArgs e)
        {

            AtualizaExportImport();
            AtualizaGerenciADOR();

            MessageBox.Show("Gerenciador & ExportImport Atualizados", "Atualizado");
        }

        private static void AtualizaGerenciADOR()
        {
            try
            {
                Directory.Delete("Y:\\Users\\Estoque\\Documents\\EstoqueDeskTop", true);
                Directory.CreateDirectory("Y:\\Users\\Estoque\\Documents\\EstoqueDeskTop");

                var destinoImport = "Y:\\Users\\Estoque\\Documents\\EstoqueDeskTop\\Debug.zip";
                var sourceImport = "Y:\\Users\\Estoque\\Documents\\EstoqueDeskTop\\";

                var sourceProj = @"E:\GitHub\SynologyDrive\EstoqueBarbanera\bin\Debug";

                ZipFile.CreateFromDirectory(sourceProj, destinoImport, CompressionLevel.Optimal, true, Encoding.Default);
                ZipFile.ExtractToDirectory(destinoImport, sourceImport, Encoding.Default);

                File.Delete(destinoImport);
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private static void AtualizaExportImport()
        {
            try
            {
                Directory.Delete("Y:\\Users\\Estoque\\Documents\\EstoqueExportImport",true);
                Directory.CreateDirectory("Y:\\Users\\Estoque\\Documents\\EstoqueExportImport");

                var destBin = "Y:\\Users\\Estoque\\Documents\\EstoqueExportImport\\bin.zip";
                var destResources = "Y:\\Users\\Estoque\\Documents\\EstoqueExportImport\\Resources.zip";
                var root = "Y:\\Users\\Estoque\\Documents\\EstoqueExportImport\\";

                var sourceBin = @"E:\GitHub\SynologyDrive\ImportExportERP\ImportExportERP\bin";
                var sourceResources = @"E:\GitHub\SynologyDrive\ImportExportERP\ImportExportERP\Resources";

                ZipFile.CreateFromDirectory(sourceBin, destBin, CompressionLevel.Optimal, true, Encoding.Default);
                ZipFile.CreateFromDirectory(sourceResources, destResources, CompressionLevel.Optimal, true, Encoding.Default);

                ZipFile.ExtractToDirectory(destBin, root, Encoding.Default);
                ZipFile.ExtractToDirectory(destResources, root, Encoding.Default);

                File.Delete(destBin);
                File.Delete(destResources);

                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnImportExport_Click(object sender, EventArgs e)
        {
            AtualizaExportImport();
            MessageBox.Show("ExportImport Atualizado", "Atualizado");
        }

        private void btnSincGeral_Click(object sender, EventArgs e)
        {
            AtualizaGerenciADOR();
            MessageBox.Show("Gerenciador Atualizado", "Atualizado");
        }
    }
}
