using ImportExportERP.Entidade;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ImportExportERP
{
    internal class ParaEtiquetas
    {

        public ParaEtiquetas()
        {
           // Start();
        }

        internal static void Start()
        {
            var listaPV = PadronizarColunasDados.listaPV;
            var fullpath = @"C:\Exports\PedidosDeVendasEtiquetas.txt";

            File.WriteAllText(fullpath, "NroPedido\tOrdemCompra\tSeq\tItem\tDescricao\tQuantidade\tRazaoSocial\n", Encoding.Default);

            foreach (var linha in listaPV)
            {
                File.AppendAllText(fullpath, linha.NPedido + "\t" + linha.OrdemCompra + "\t" + linha.Seq + "\t" + linha.Item + "\t" + linha.Descricao + "\t" + linha.Quantidade + "\t" + linha.RazaoSocial + "\n", Encoding.Default);
            }

        }
    }
}