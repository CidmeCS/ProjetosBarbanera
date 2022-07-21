using Estoque.DAO;
using Estoque.Entidade;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Estoque.Classes
{
    public class InventarioDepositosDeTerceiro
    {
        public Object[] FiltandoDados()
        {
            Crud c = new Crud();
            var es = c.ListaDeTerceiro().Where(s=>s.SaldoQtde > 0).OrderByDescending(p => p.Data).ToList();

            List<DeTerceiro> lm = new List<DeTerceiro>();
            int i = 0;
            foreach (var item in es)
            {
                if (!lm.Exists(p => p.Produto == item.Produto))
                {
                    var t = es.FindAll(p => p.Produto == item.Produto).ToList().First();
                    lm.Add(t);
                    continue;
                }
                else if (lm.Exists(p => p.DocFiscal != item.DocFiscal))
                {
                    lm.Add(item);
                }
            }

            var saldo = c.ListaSaldoDeTerceiro();
            var dpst = c.ListaDepositoDeTerceiro();
            var ff = c.ListaItemEntregaDeTerceiro();

            // Nova Implementação para fazer 30/10/2020
            //var tdt = c.ListaDeTerceiro();     cruzar tabela DeTerceiros neste select para listar docs fiscais para cada movimento que esteja pendente

            var dadosFiltrados = (from s in saldo
                                  join d in dpst on s.DEPOSITO equals d.Deposito.ToString()
                                  join f in ff on new { ProdutoS = s.Produto, DepositoS = s.DEPOSITO } equals new { ProdutoS = f.Produto, DepositoS = f.Deposito.Substring(0, 3).Trim() } into gj
                                  from g in gj.DefaultIfEmpty()
                                      //join f in ff on new { ProdutoS = s.Produto, DepositoS = s.DEPOSITO } equals new { ProdutoS = f.Produto, DepositoS = f.Deposito.Substring(0,2).Trim() }

                                      //join t in tdt on s.Produto equals t.Produto into oo from o in oo.DefaultIfEmpty()

                                  where s.SaldoAtual > 0 | s.DeTerceiros > 0
                                  orderby s.Prateleira
                                  select new SaldoDeTerceiro
                                  {
                                      Produto = s.Produto,
                                      Descricao = s.Descricao,
                                      Prateleira = s.Prateleira,
                                      Unid = s.Unid,
                                      SaldoAtual = s.SaldoAtual,
                                      DeTerceiros = s.DeTerceiros,
                                      DEPOSITO = s.DEPOSITO + " " + d.Nome,
                                      Descricao2 = (g?.EntreguePara ?? "").Length == 0 ? "" : $"QTD: {g.Quantidade}, Data: {g.Data}, E.Para: {g.EntreguePara}",

                                  }).ToList();


            var df = (from d in dadosFiltrados
                      join e in lm on d.Produto equals e.Produto into gj
                      from gp in gj.DefaultIfEmpty()
                          //join e in lm on new { ProdutoS = d.Produto, DepositoS = d.DEPOSITO } equals new { ProdutoS = e.Produto, DepositoS = e.DEPOSITO} into gj from gp in gj.DefaultIfEmpty()
                      orderby d.Prateleira
                      select new SaldoDeTerceiro
                      {
                          Produto = d.Produto,
                          Descricao = d.Descricao,
                          Prateleira = d.Prateleira,
                          Unid = d.Unid,
                          SaldoAtual = d.SaldoAtual,
                          DeTerceiros = d.DeTerceiros,
                          DEPOSITO = d.DEPOSITO,
                          Descricao2 = d.Descricao2,
                          Data = gp == null ? new DateTime(0001, 01, 01) : gp.Data,
                          DESCR_2 = gp == null ? "" : gp.DocFiscal + " - " + gp.QtdeNf

                      }).ToList();

            DeListParaTable dlpt = new DeListParaTable();
            var tabela = dlpt.InventarioDepositosDeTerceiro(df.ToList());
            Object[] obj = new Object[] { tabela, df.ToList() };
            return obj;
        }

        public DataTable Lista()
        {
            Crud c = new Crud();
            var saldo = c.ListaSaldoDeTerceiro();
            var dpst = c.ListaDepositoDeTerceiro();
            var ff = c.ListaItemEntregaDeTerceiro();
            var dadosFiltrados = (from s in saldo
                                  join d in dpst on s.DEPOSITO equals d.Deposito.ToString()
                                  join f in ff on new { ProdutoS = s.Produto, DepositoS = s.DEPOSITO } equals new { ProdutoS = f.Produto, DepositoS = f.Deposito.Substring(0, 2).Trim() }
                                  into gj
                                  from g in gj.DefaultIfEmpty()

                                  orderby s.Produto
                                  select new SaldoDeTerceiro
                                  {
                                      Produto = s.Produto,
                                      Descricao = s.Descricao,
                                      Prateleira = s.Prateleira,
                                      Unid = s.Unid,
                                      SaldoAtual = s.SaldoAtual,
                                      DeTerceiros = s.DeTerceiros,
                                      DEPOSITO = s.DEPOSITO + " " + d.Nome,
                                      Descricao2 = (g?.EntreguePara ?? "").Length == 0 ? "" : $"QTD: {g.Quantidade}, Data: {g.Data}, E.Para: {g.EntreguePara}",
                                      //data e nF nao dá. tem que ter mais um select de movimentos...

                                  }).ToList();
            DeListParaTable dlpt = new DeListParaTable();
            var tabela = dlpt.InventarioDepositosDeTerceiro(dadosFiltrados.ToList());

            return tabela;
        }

        public List<EntregaDeTerceiro> ListaManutencao()
        {
            Crud c = new Crud();
            var saldo = c.ListaSaldoDeTerceiro();
            var dpst = c.ListaDepositoDeTerceiro();
            var ff = c.ListaItemEntregaDeTerceiro();
            var dadosFiltrados = (from s in saldo
                                  join d in dpst on s.DEPOSITO equals d.Deposito.ToString()
                                  join f in ff on s.Produto equals f.Produto
                                  where s.SaldoAtual == 0 & s.DeTerceiros == 0


                                  orderby s.Produto
                                  select new EntregaDeTerceiro
                                  {
                                      Id = f.Id,
                                      Produto = f.Produto,
                                      Descricao = f.Descricao,
                                      Quantidade = f.Quantidade,
                                      Deposito = f.Deposito,
                                      EntreguePara = f.EntreguePara,
                                      Data = f.Data

                                  }).ToList();
            return dadosFiltrados;
        }


    }
}