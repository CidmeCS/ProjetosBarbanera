using Estoque.DAO;
using Estoque.Entidade;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estoque.Classes
{
    public class OPsComSaldo
    {
        internal List<PedidoNFs> RelatorioParaMatarSaldos()
        {
            Crud c = new Crud();

            var pcompra = c.ListPedidoDeCompra().Where(p => p.Saldo > 0 & p.QtdeEntregue > 0);
            var nfs = c.ListaNotasFiscaisDinamicaProduto().OrderByDescending(p => p.NotaFiscal).ToList();

            var lista = (from pc in pcompra
                         join nf in nfs
                         on pc.Produto equals nf.Produto
                         into pn
                         from j in pn.DefaultIfEmpty()
                         //where /*pc.Saldo > 0 & j?.NotaFiscal > 0 &*/ pc.QtdeEntregue > 0
                         orderby pc.Pedido
                         select new PedidoNFs
                         {
                             PedidoDeCompra = Convert.ToInt32(pc.Pedido),
                             Data = pc.Data,
                             NotaFiscal = j?.NotaFiscal ?? 0,
                             //NotaFiscal = nf.NotaFiscal,
                             Fornecedor = pc.Fornecedor + " " + pc.FORNEC,
                             Produto = pc.Produto,
                             Descricao = pc.DescricaoAlternativa,
                             QtdePedido = pc.Quantidade,
                             QtdeEntregue = pc.QtdeEntregue,
                             LinhaPed = Convert.ToInt16(pc.LinhaPed),
                             Saldo = pc.Saldo
                         }).ToList();
            
            //remove semelhantes
            var listaDistinta = new List<PedidoNFs>();
            var pcOld = 0;
            var nfOld = 0;
            var prOld = String.Empty;
            foreach (var h in lista)
            {
                if (h.Produto == prOld & h.PedidoDeCompra == pcOld & h.NotaFiscal != nfOld)
                {

                }
                else
                {
                    listaDistinta.Add(h);
                }
                pcOld = h.PedidoDeCompra;
                nfOld = h.NotaFiscal;
                prOld = h.Produto;
            }
            return listaDistinta;
        }

        internal List<PedidoNFs> ApenasListaOPs()
        {
            Crud c = new Crud();

            var pcompra = c.ListPedidoDeCompra();

            var lista = (from pc in pcompra
                         select new PedidoNFs
                         {
                             PedidoDeCompra = Convert.ToInt32(pc.Pedido),
                             Data = pc.Data,
                             Fornecedor = pc.Fornecedor + " " + pc.FORNEC,
                             Produto = pc.Produto,
                             Descricao = pc.DescricaoAlternativa,
                             QtdePedido = pc.Quantidade,
                             QtdeEntregue = pc.QtdeEntregue,
                             LinhaPed = Convert.ToInt16(pc.LinhaPed),
                             Saldo = pc.Saldo
                         }).OrderBy(p => p.PedidoDeCompra).ToList();

            return lista;

        }

        internal static DataTable CarregaDataTable(ref List<PedidoNFs> listaMatarSaldo)
        {

            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = @"C:\Export\";
                openFileDialog.Filter = "xlsx files (*.xlsx)|*.xlsx";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                }
            }

            var dtContent = RegistrarInventario.GetDataTableFromExcel(filePath);

            List<PedidoNFs> pn = new List<PedidoNFs>();
            List<PedidoNFs> pnremove = new List<PedidoNFs>();
            foreach (DataRow item in dtContent.Rows)
            {
                PedidoNFs p = new PedidoNFs();
                p.PedidoDeCompra = Convert.ToInt32(item.ItemArray[0].ToString());
                p.Data = Convert.ToDateTime(item.ItemArray[1].ToString());
                p.NotaFiscal = Convert.ToInt32(item.ItemArray[2].ToString());
                p.Fornecedor = item.ItemArray[3].ToString();
                p.Produto = item.ItemArray[4].ToString();
                p.Descricao = item.ItemArray[5].ToString();
                p.QtdePedido = Convert.ToDouble(item.ItemArray[6].ToString());
                p.QtdeEntregue = Convert.ToDouble(item.ItemArray[7].ToString());
                p.LinhaPed = Convert.ToInt16(item.ItemArray[8].ToString());
                p.Saldo = Convert.ToDouble(item.ItemArray[9].ToString());

                pn.Add(p);

                int i = 0;
                foreach (var h in pn)
                {
                    if (h.PedidoDeCompra == p.PedidoDeCompra & h.Produto == p.Produto)
                    {
                        i++;
                        if (i > 1)
                        {
                            pnremove.Add(p);
                        }
                    }
                }
            }
            var ex = pn.Except(pnremove).ToList();
            listaMatarSaldo = ex;

            ////
            ////



            return dtContent;
        }
    }

    internal class PedidoNFs
    {
        public int PedidoDeCompra { get; internal set; }
        public DateTime Data { get; internal set; }
        public int NotaFiscal { get; internal set; }
        public string Fornecedor { get; internal set; }
        public string Produto { get; internal set; }
        public string Descricao { get; internal set; }
        public double QtdePedido { get; internal set; }
        public double QtdeEntregue { get; internal set; }
        public int LinhaPed { get; internal set; }
        public double Saldo { get; internal set; }
    }
}
