using Estoque.DAO;
using Estoque.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Classes
{
     public class ReceberNFs
    {

        

        /// <summary>
        /// Lista Totas as notas com o nome do cliente ou fornecedor, estabelecimento e deposito
        /// </summary>
        /// <returns></returns>
        internal List<Notas> Recebe()
        {
            Crud c = new Crud();
            var nfs = c.ListaNotasFiscaisDinamicaProduto();
            var dep = c.ListaDepositoDeTerceiro();


            return  (from n in nfs
                     join d in dep on n.Deposito equals d.Deposito into jj from j in jj.DefaultIfEmpty()
                     where 
                     !n.DescricaoTipoMovimento.Contains("VENDA") & 
                     n.DescricaoTipoMovimento != "COMPRAS PARA CONSUMO NAC" &
                     n.DescricaoTipoMovimento != "AQUIS SERV TERCEIRO NFS"
                     select new Notas {
                             NotaFiscal = n.NotaFiscal,
                             Fornecedor = n.NomeFantasia + " " + n.Fornecedor,
                             Deposito = n.Estabelecimento == "2" ? "E:"+n.Estabelecimento +  " D:" + n.Deposito + " C:"+ j?.Nome ?? String.Empty : "", // Lista Totas as notas com o nome do cliente ou fornecedor, estabelecimento e deposito
                             Produto = n.Produto,
                             Descricao = n.DescricaodoProduto, 
                             Quantidade = n.Quantidade,
                             TM = n.TipoMovto,
                             DataMvto = n.DataMovimento,
                             DataEmissao = n.DatadeEmissao,
                             NumPedido = n.Pedido,
                             Tipo = n.DescricaoTipoMovimento
                         }).OrderBy(p => p.NotaFiscal).ToList();

        }



        internal List<Notas> Pesquisa(string Coluna, string texto, List<Entidade.NotasFiscaisDinamicaProduto> r, List<Entidade.DepositoDeTerceiro> h)
        {

            var nfs = r;
            var dep = h;

            switch (Coluna)
            {
                case "NotaFiscal":
                    return (from n in nfs
                            join d in dep on n.Deposito equals d.Deposito into jj
                            from j in jj.DefaultIfEmpty()
                            where
                            !n.DescricaoTipoMovimento.Contains("VENDA") &
                            n.DescricaoTipoMovimento != "COMPRAS PARA CONSUMO NAC" &
                            n.DescricaoTipoMovimento != "AQUIS SERV TERCEIRO NFS" &
                            n.NotaFiscal == Convert.ToInt32(texto == "" ? "0" : texto)
                            select new Notas
                            {
                                NotaFiscal = n.NotaFiscal,
                                Fornecedor = (n.NomeFantasia + "; " + n.Fornecedor).Trim(),
                                Deposito = n.Estabelecimento == "2" ? "E:" + n.Estabelecimento + " D:" + n.Deposito + " C:" + j?.Nome ?? String.Empty : "",
                                Produto = n.Produto,
                                Descricao = n.DescricaodoProduto,
                                Quantidade = n.Quantidade,
                                TM = n.TipoMovto,
                                DataMvto = n.DataMovimento,
                                DataEmissao = n.DatadeEmissao,
                                NumPedido = n.Pedido,
                                Tipo = n.DescricaoTipoMovimento
                            }).OrderBy(p => p.NotaFiscal).ToList();

                case "NomeFantasia":
                    return (from n in nfs
                            join d in dep on n.Deposito equals d.Deposito into jj
                            from j in jj.DefaultIfEmpty()
                            where
                            !n.DescricaoTipoMovimento.Contains("VENDA") &
                            n.DescricaoTipoMovimento != "COMPRAS PARA CONSUMO NAC" &
                            n.DescricaoTipoMovimento != "AQUIS SERV TERCEIRO NFS" &
                            n.NomeFantasia.Contains(texto)
                            select new Notas
                            {
                                NotaFiscal = n.NotaFiscal,
                                Fornecedor = n.NomeFantasia + " " + n.Fornecedor,
                                Deposito = n.Estabelecimento == "2" ? "E:" + n.Estabelecimento + " D:" + n.Deposito + " C:" + j?.Nome ?? String.Empty : "",
                                Produto = n.Produto,
                                Descricao = n.DescricaodoProduto,
                                Quantidade = n.Quantidade,
                                TM = n.TipoMovto,
                                DataMvto = n.DataMovimento,
                                DataEmissao = n.DatadeEmissao,
                                NumPedido = n.Pedido,
                                Tipo = n.DescricaoTipoMovimento
                            }).OrderBy(p => p.NotaFiscal).ToList();

            }


            return (from n in nfs
                    join d in dep on n.Deposito equals d.Deposito into jj
                    from j in jj.DefaultIfEmpty()
                    where
                    !n.DescricaoTipoMovimento.Contains("VENDA") &
                    n.DescricaoTipoMovimento != "COMPRAS PARA CONSUMO NAC" &
                    n.DescricaoTipoMovimento != "AQUIS SERV TERCEIRO NFS" &
                    n.NotaFiscal == Convert.ToInt32(texto)
                    select new Notas
                    {
                        NotaFiscal = n.NotaFiscal,
                        Fornecedor = n.NomeFantasia + " " + n.Fornecedor,
                        Deposito = n.Estabelecimento == "2" ? "E:" + n.Estabelecimento + " D:" + n.Deposito + " C:" + j?.Nome ?? String.Empty : "",
                        Produto = n.Produto,
                        Descricao = n.DescricaodoProduto,
                        Quantidade = n.Quantidade,
                        TM = n.TipoMovto,
                        DataMvto = n.DataMovimento,
                        DataEmissao = n.DatadeEmissao,
                        NumPedido = n.Pedido,
                        Tipo = n.DescricaoTipoMovimento
                    }).OrderBy(p => p.NotaFiscal).ToList();

        }

        internal List<Notas> Pesquisa(string Coluna, string texto, List<Entidade.DepositoDeTerceiro> h)
        {
            Crud c = new Crud();

            
            
            var dep = h;

            switch (Coluna)
            {
                case "NotaFiscal":
                     var nfs = c.ListaNotasFiscaisDinamicaProduto().Where(p=>p.NotaFiscal == Convert.ToInt64(texto));
                    return (from n in nfs
                            join d in dep on n.Deposito equals d.Deposito into jj
                            from j in jj.DefaultIfEmpty()
                            where
                            !n.DescricaoTipoMovimento.Contains("VENDA") &
                            n.DescricaoTipoMovimento != "COMPRAS PARA CONSUMO NAC" &
                            n.DescricaoTipoMovimento != "AQUIS SERV TERCEIRO NFS" &
                            n.NotaFiscal == Convert.ToInt32(texto == "" ? "0" : texto)
                            select new Notas
                            {
                                NotaFiscal = n.NotaFiscal,
                                Fornecedor = n.NomeFantasia + " " + n.Fornecedor,
                                Deposito = n.Estabelecimento == "2" ? "E:" + n.Estabelecimento + " D:" + n.Deposito + " C:" + j?.Nome ?? String.Empty : "",
                                Produto = n.Produto,
                                Descricao = n.DescricaodoProduto,
                                Quantidade = n.Quantidade,
                                TM = n.TipoMovto,
                                DataMvto = n.DataMovimento,
                                DataEmissao = n.DatadeEmissao,
                                NumPedido = n.Pedido,
                                Tipo = n.DescricaoTipoMovimento
                            }).OrderBy(p => p.NotaFiscal).ToList();

                case "NomeFantasia":
                    var nfs2 = c.ListaNotasFiscaisDinamicaProduto().Where(p => p.NomeFantasia == texto);

                    return (from n in nfs2
                            join d in dep on n.Deposito equals d.Deposito into jj
                            from j in jj.DefaultIfEmpty()
                            where
                            !n.DescricaoTipoMovimento.Contains("VENDA") &
                            n.DescricaoTipoMovimento != "COMPRAS PARA CONSUMO NAC" &
                            n.DescricaoTipoMovimento != "AQUIS SERV TERCEIRO NFS" &
                            n.NomeFantasia.Contains(texto)
                            select new Notas
                            {
                                NotaFiscal = n.NotaFiscal,
                                Fornecedor = n.NomeFantasia + " " + n.Fornecedor,
                                Deposito = n.Estabelecimento == "2" ? "E:" + n.Estabelecimento + " D:" + n.Deposito + " C:" + j?.Nome ?? String.Empty : "",
                                Produto = n.Produto,
                                Descricao = n.DescricaodoProduto,
                                Quantidade = n.Quantidade,
                                TM = n.TipoMovto,
                                DataMvto = n.DataMovimento,
                                DataEmissao = n.DatadeEmissao,
                                NumPedido = n.Pedido,
                                Tipo = n.DescricaoTipoMovimento
                            }).OrderBy(p => p.NotaFiscal).ToList();

            }

            return null;

            //var nfs3 = c.ListaNotasFiscaisDinamicaProduto().Where(p => p.NomeFantasia == texto);


            //return (from n in nfs
            //        join d in dep on n.Deposito equals d.Deposito into jj
            //        from j in jj.DefaultIfEmpty()
            //        where
            //        !n.DescricaoTipoMovimento.Contains("VENDA") &
            //        n.DescricaoTipoMovimento != "COMPRAS PARA CONSUMO NAC" &
            //        n.DescricaoTipoMovimento != "AQUIS SERV TERCEIRO NFS" &
            //        n.NotaFiscal == Convert.ToInt32(texto)
            //        select new Notas
            //        {
            //            NotaFiscal = n.NotaFiscal,
            //            Fornecedor = n.NomeFantasia + " " + n.Fornecedor,
            //            Deposito = n.Estabelecimento == "2" ? "E:" + n.Estabelecimento + " D:" + n.Deposito + " C:" + j?.Nome ?? String.Empty : "",
            //            Produto = n.Produto,
            //            Descricao = n.DescricaodoProduto,
            //            Quantidade = n.Quantidade,
            //            TM = n.TipoMovto,
            //            DataMvto = n.DataMovimento,
            //            DataEmissao = n.DatadeEmissao,
            //            NumPedido = n.Pedido,
            //            Tipo = n.DescricaoTipoMovimento
            //        }).OrderBy(p => p.NotaFiscal).ToList();

        }
    }

    internal class Notas
    {
        public int NotaFiscal { get; set; }
        public string Fornecedor { get; set; }
        public string Produto { get; set; }
        public string Deposito { get; internal set; }
        public string Descricao { get; set; }
        public double Quantidade { get; set; }
        public string TM { get; set; }
        public DateTime DataMvto { get; set; }
        public DateTime DataEmissao { get; set; }
        public int NumPedido { get; internal set; }
        public string Tipo { get; internal set; }
        public string Atencao { get; internal set; }
    }
}
