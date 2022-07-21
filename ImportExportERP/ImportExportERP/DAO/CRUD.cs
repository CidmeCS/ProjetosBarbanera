using System;
using System.Collections.Generic;
using System.Linq;
using ImportExportERP.Entidade;
using ImportExportERP.Data;
using Microsoft.EntityFrameworkCore;
using System.Windows.Forms;
using System.Diagnostics;

namespace ImportExportERP
{
    internal class CRUD : IDisposable, ISqlServer, IMySql

    {
        private static MySqlContext ContextoMySql;
        private static SqlServerContext ContextoSqlServer;

        public CRUD()
        {
            ContextoMySql = new MySqlContext();
            ContextoSqlServer = new SqlServerContext();
        }

        public void Dispose()
        {
            ContextoMySql.Dispose();
            ContextoSqlServer.Dispose();
        }


        #region SQL Server

        #region Saldo

        public void AdicionaSaldoSqlServer(List<Saldo> dt)
        {
            ContextoSqlServer.Saldos.AddRange(dt);
            ContextoSqlServer.SaveChanges();
        }

        public void TruncateSaldoSqlServer()
        {
            ContextoSqlServer.Database.ExecuteSqlCommand("TRUNCATE TABLE Saldos");
        }

        public IList<Saldo> ListSaldoSqlServer()
        {
            return ContextoSqlServer.Saldos.ToList();
        }
        #endregion

        #region PedidoDeCompra
        public void AdicionaPedidoDeCompraSqlServer(List<PedidoDeCompra> dt)
        {
            ContextoSqlServer.PedidosDeCompra.AddRange(dt);
            ContextoSqlServer.SaveChanges();
        }

        public void TruncatePedidoDeCompraSqlServer()
        {
            //ContextoMySql.Database.ExecuteSqlCommand("TRUNCATE TABLE PedidosDeCompra");
            ContextoSqlServer.Database.ExecuteSqlCommand("TRUNCATE TABLE PedidosDeCompra");
        }

        public IList<PedidoDeCompra> ListPedidoDeCompraSqlServer()
        {
            return ContextoSqlServer.PedidosDeCompra.ToList();
        }
        #endregion

        #region PedidoDeVenda
        public void AdicionaPedidoDeVendaSqlServer(List<PedidoDeVenda> dt)
        {
            ContextoSqlServer.PedidosDeVenda.AddRange(dt);
            ContextoSqlServer.SaveChanges();
        }

        public void TruncatePedidoDeVendaSqlServer()
        {
            ContextoSqlServer.Database.ExecuteSqlCommand("TRUNCATE TABLE PedidosDeVenda");
        }

        public IList<PedidoDeVenda> ListPedidoDeVendaSqlServer()
        {
            return ContextoSqlServer.PedidosDeVenda.ToList();
        }
        #endregion

        #region Movimento
        public void AdicionaMovimentoSqlServer(List<Movimento> dt)
        {
            ContextoSqlServer.Movimentos.AddRange(dt);
            ContextoSqlServer.SaveChanges();
        }

        public void TruncateMovimentoSqlServer()
        {
            ContextoSqlServer.Database.ExecuteSqlCommand("TRUNCATE TABLE Movimentos");
        }

        public IList<Movimento> ListMovimentoSqlServer()
        {
            return ContextoSqlServer.Movimentos.ToList();
        }

        public void DeleteMovimentoSqlServer(List<Movimento> dt)
        {
            ContextoSqlServer.Movimentos.RemoveRange(dt);
            ContextoSqlServer.SaveChanges();

        }
        #endregion

        #region ForaDeEstoque
        public void AdicionaForaDeEstoqueSqlServer(List<ForaDeEstoque> dt)
        {
            ContextoSqlServer.ForaDeEstoques.AddRange(dt);
            ContextoSqlServer.SaveChanges();
        }

        public void TruncateForaDeEstoqueSqlServer()
        {
            ContextoSqlServer.Database.ExecuteSqlCommand("TRUNCATE TABLE ForaDeEstoques");
        }

        public IList<ForaDeEstoque> ListForaDeEstoqueSqlServer()
        {
            return ContextoSqlServer.ForaDeEstoques.ToList();
        }
        #endregion

        #region DeTerceiro
        public void AdicionaDeTerceiroSqlServer(List<DeTerceiros> dt)
        {
            ContextoSqlServer.DeTerceiros.AddRange(dt);
            ContextoSqlServer.SaveChanges();
        }

        public void TruncateDeTerceiroSqlServer()
        {
            ContextoSqlServer.Database.ExecuteSqlCommand("TRUNCATE TABLE DeTerceiros");
        }

        public IList<DeTerceiros> ListDeTerceiroSqlServer()
        {
            return ContextoSqlServer.DeTerceiros.ToList();
        }
        #endregion

        #region ItensDeEstoque
        public void AdicionaItemDeEstoqueSqlServer(List<ItensDeEstoque> dt)
        {
            ContextoSqlServer.ItensDeEstoques.AddRange(dt);
            ContextoSqlServer.SaveChanges();
        }

        public void TruncateItemDeEstoqueSqlServer()
        {
            ContextoSqlServer.Database.ExecuteSqlCommand("TRUNCATE TABLE ItensDeEstoques");
        }

        public IList<ItensDeEstoque> ListItemDeEstoqueSqlServer()
        {
            return ContextoSqlServer.ItensDeEstoques.ToList();
        }
        #endregion

        #region DepositoDeTerceiro
        public void AdicionaDepositoDeTerceiroSqlServer(List<DepositoDeTerceiro> dt)
        {
            ContextoSqlServer.DepositoDeTerceiros.AddRange(dt);
            ContextoSqlServer.SaveChanges();
        }

        public void TruncateDepositoDeTerceiroSqlServer()
        {
            ContextoSqlServer.Database.ExecuteSqlCommand("TRUNCATE TABLE DepositoDeTerceiros");
        }

        public IList<DepositoDeTerceiro> ListaDepositoDeTerceiroSqlServer()
        {
            return ContextoSqlServer.DepositoDeTerceiros.ToList();
        }
        #endregion

        #region SaldoDeTerceiro
        public void AdicionaSaldoDeTerceiroSqlServer(List<SaldoDeTerceiro> dt)
        {
            ContextoSqlServer.SaldoDeTerceiros.AddRange(dt);
            ContextoSqlServer.SaveChanges();
        }

        public void TruncateSaldoDeTerceiroSqlServer()
        {
            ContextoSqlServer.Database.ExecuteSqlCommand("TRUNCATE TABLE SaldoDeTerceiros");
        }

        public IList<SaldoDeTerceiro> ListSaldoDeTerceiroSqlServer()
        {
            return ContextoSqlServer.SaldoDeTerceiros.ToList();
        }
        #endregion

        #region Atualizacao

        public IList<Atualizacao> ListAtualizacaoSqlServer()
        {
            return ContextoSqlServer.Atualizacoes.ToList();
        }

        public void AtualizaAtualizacaoSqlServer(List<Atualizacao> dt)
        {
            ContextoSqlServer.Atualizacoes.AddRange(dt);
            var i = ContextoSqlServer.SaveChanges();
        }

        public void TruncateAtualizaAtualizacaoSqlServer()
        {
            ContextoSqlServer.Database.ExecuteSqlCommand("TRUNCATE TABLE Atualizacoes");
        }


        #endregion

        #region OrdensDeProducao
        public void AdicionaOrdensDeProducaoSqlServer(List<OrdensDeProducao> dt)
        {
            ContextoSqlServer.OrdensDeProducoes.AddRange(dt);
            ContextoSqlServer.SaveChanges();
        }

        public void TruncateOredensDeProducaoSqlServer()
        {
            ContextoSqlServer.Database.ExecuteSqlCommand("TRUNCATE TABLE OrdensDeProducoes");
        }

        public IList<OrdensDeProducao> ListOrdensDeProducaoSqlServer()
        {
            return ContextoSqlServer.OrdensDeProducoes.ToList();
        }

        #endregion

        #endregion

        #region SQL MySql

        #region Saldo

        public void AdicionaSaldoMySql(List<Saldo> dt)
        {
            ContextoMySql.Saldos.AddRange(dt);
            ContextoMySql.SaveChanges();
        }

        public void TruncateSaldoMySql()
        {
            ContextoMySql.Database.ExecuteSqlCommand("TRUNCATE TABLE Saldos");
        }

        public IList<Saldo> ListSaldoMySql()
        {
            return ContextoMySql.Saldos.ToList();
        }
        #endregion

        #region PedidoDeCompra
        public void AdicionaPedidoDeCompraMySql(List<PedidoDeCompra> dt)
        {
            ContextoMySql.PedidosDeCompra.AddRange(dt);
            ContextoMySql.SaveChanges();
        }

        public void TruncatePedidoDeCompraMySql()
        {
            ContextoMySql.Database.ExecuteSqlCommand("TRUNCATE TABLE PedidosDeCompra");
        }

        public IList<PedidoDeCompra> ListPedidoDeCompraMySql()
        {
            return ContextoMySql.PedidosDeCompra.ToList();
        }

        public void DeletePedidoDeCompraMySql(List<PedidoDeCompra> dt)
        {
            ContextoMySql.PedidosDeCompra.RemoveRange(dt);
            ContextoMySql.SaveChanges();
        }
        #endregion

        #region PedidoDeVenda
        public void AdicionaPedidoDeVendaMySql(List<PedidoDeVenda> dt)
        {
            ContextoMySql.PedidosDeVenda.AddRange(dt);
            ContextoMySql.SaveChanges();
        }

        public void TruncatePedidoDeVendaMySql()
        {
            ContextoMySql.Database.ExecuteSqlCommand("TRUNCATE TABLE PedidosDeVenda");
        }

        public IList<PedidoDeVenda> ListPedidoDeVendaMySql()
        {
            return ContextoMySql.PedidosDeVenda.ToList();
        }
        #endregion

        #region Movimento
        public void AdicionaMovimentoMySql(List<Movimento> dt)
        {
            ContextoMySql.Movimentos.AddRange(dt);
            ContextoMySql.SaveChanges();
        }

        public void TruncateMovimentoMySql()
        {
            ContextoMySql.Database.ExecuteSqlCommand("TRUNCATE TABLE Movimentos");
        }

        public IList<Movimento> ListMovimentoMySql()
        {
            return ContextoMySql.Movimentos.ToList();
        }

        public void DeleteMovimentoMySql(List<Movimento> dt)
        {
            ContextoMySql.Movimentos.RemoveRange(dt);
            ContextoMySql.SaveChanges();
        }

        #endregion

        #region ForaDeEstoque
        public void AdicionaForaDeEstoqueMySql(List<ForaDeEstoque> dt)
        {
            ContextoMySql.ForaDeEstoques.AddRange(dt);
            ContextoMySql.SaveChanges();
        }

        public void TruncateForaDeEstoqueMySql()
        {
            ContextoMySql.Database.ExecuteSqlCommand("TRUNCATE TABLE ForaDeEstoques");
        }

        public IList<ForaDeEstoque> ListForaDeEstoqueMySql()
        {
            return ContextoMySql.ForaDeEstoques.ToList();
        }

        public void DeleteForaDeEstoqueMySql(List<ForaDeEstoque> dt)
        {
            ContextoMySql.ForaDeEstoques.RemoveRange(dt);
            ContextoMySql.SaveChanges();
        }
        #endregion

        #region DeTerceiro
        public void AdicionaDeTerceiroMySql(List<DeTerceiros> dt)
        {
            ContextoMySql.DeTerceiros.AddRange(dt);
            ContextoMySql.SaveChanges();
        }

        public void TruncateDeTerceiroMySql()
        {
            ContextoMySql.Database.ExecuteSqlCommand("TRUNCATE TABLE DeTerceiros");
        }

        public IList<DeTerceiros> ListDeTerceiroMySql()
        {
            return ContextoMySql.DeTerceiros.ToList();
        }
        public void DeleteDeTerceiroMySql(List<DeTerceiros> dt)
        {
            ContextoMySql.DeTerceiros.RemoveRange(dt);
            ContextoMySql.SaveChanges();
        }
        #endregion

        #region ItensDeEstoque
        public void AdicionaItemDeEstoqueMySql(List<ItensDeEstoque> dt)
        {
            ContextoMySql.ItensDeEstoques.AddRange(dt);
            ContextoMySql.SaveChanges();
        }

        public void TruncateItemDeEstoqueMySql()
        {
            ContextoMySql.Database.ExecuteSqlCommand("TRUNCATE TABLE ItensDeEstoques");
        }

        public IList<ItensDeEstoque> ListItemDeEstoqueMySql()
        {
            return ContextoMySql.ItensDeEstoques.ToList();
        }
        #endregion

        #region DepositoDeTerceiro
        public void AdicionaDepositoDeTerceiroMySql(List<DepositoDeTerceiro> dt)
        {
            ContextoMySql.DepositoDeTerceiros.AddRange(dt);
            ContextoMySql.SaveChanges();
        }

        public void TruncateDepositoDeTerceiroMySql()
        {
            ContextoMySql.Database.ExecuteSqlCommand("TRUNCATE TABLE DepositoDeTerceiros");
        }

        public IList<DepositoDeTerceiro> ListaDepositoDeTerceiroMySql()
        {
            return ContextoMySql.DepositoDeTerceiros.ToList();
        }
        #endregion

        #region SaldoDeTerceiro
        public void AdicionaSaldoDeTerceiroMySql(List<SaldoDeTerceiro> dt)
        {
            ContextoMySql.SaldoDeTerceiros.AddRange(dt);
            ContextoMySql.SaveChanges();
        }

        public void TruncateSaldoDeTerceiroMySql()
        {
            ContextoMySql.Database.ExecuteSqlCommand("TRUNCATE TABLE SaldoDeTerceiros");
        }

        public IList<SaldoDeTerceiro> ListSaldoDeTerceiroMySql()
        {
            return ContextoMySql.SaldoDeTerceiros.ToList();
        }
        #endregion

        #region Atualizacao

        public IList<Atualizacao> ListAtualizacaoMySql()
        {
            IList<Atualizacao> la = null;
            try
            {
                la = ContextoMySql.Atualizacoes.ToList();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
            return la;
        }

        public void AtualizaAtualizacaoMySql(List<Atualizacao> dt)
        {
            ContextoMySql.Atualizacoes.AddRange(dt);
            var i = ContextoMySql.SaveChanges();
        }

        public void TruncateAtualizaAtualizacaoMySql()
        {
            ContextoMySql.Database.ExecuteSqlCommand("TRUNCATE TABLE Atualizacoes");
        }

        #endregion

        #region OrdensDeProducao

        public void AdicionaOrdensDeProducaoMySql(List<OrdensDeProducao> dt)
        {
            ContextoMySql.OrdensDeProducoes.AddRange(dt);
            ContextoMySql.SaveChanges();
        }

        public void TruncateOredensDeProducaoMySql()
        {
            ContextoMySql.Database.ExecuteSqlCommand("TRUNCATE TABLE OrdensDeProducoes");
        }

        public IList<OrdensDeProducao> ListOrdensDeProducaoMySql()
        {
            return ContextoMySql.OrdensDeProducoes.ToList();
        }

        #endregion

        #region NotasFiscaisDinamicaProdutos

        //sqlServer
        public void AdicionaNotasFiscaisDinamicaProdutoSqlServer(List<NotasFiscaisDinamicaProduto> dt)
        {
            var dt2 = DescricaoCompleta(dt);
            ContextoSqlServer.NotasFiscaisDinamicaProdutos.AddRange(dt2);
            ContextoSqlServer.SaveChanges();
        }

        public void TruncateNotasFiscaisDinamicaProdutoMSqlServer()
        {
            ContextoSqlServer.Database.ExecuteSqlCommand("TRUNCATE TABLE NotasFiscaisDinamicaProdutos");
        }

        public IList<NotasFiscaisDinamicaProduto> ListNotasFiscaisDinamicaProdutoSqlServer()
        {
            return ContextoSqlServer.NotasFiscaisDinamicaProdutos.ToList();
        }



        //mysql
        public void AdicionaNotasFiscaisDinamicaProdutoMySql(List<NotasFiscaisDinamicaProduto> dt)
        {
            var dt2 = DescricaoCompleta(dt);
            ContextoMySql.NotasFiscaisDinamicaProdutos.AddRange(dt2);
            ContextoMySql.SaveChanges();
        }
        public void TruncateNotasFiscaisDinamicaProdutoMySql()
        {
            ContextoMySql.Database.ExecuteSqlCommand("TRUNCATE TABLE NotasFiscaisDinamicaProdutos");
        }
        public IList<NotasFiscaisDinamicaProduto> ListNotasFiscaisDinamicaProdutoMySql()
        {
            return ContextoMySql.NotasFiscaisDinamicaProdutos.ToList();
        }
        private List<NotasFiscaisDinamicaProduto> DescricaoCompleta(List<NotasFiscaisDinamicaProduto> dt)
        {
            //
            var list = ListItemDeEstoqueMySql();
            foreach (var item in dt)
            {
                var produto = item.Produto;
                var lista = list.Where(f => f.Codigo == produto).ToList();
                if (lista.Count == 0)
                {
                    continue;
                }


                dt
                    .Where(p => p.Produto == produto)
                    .ToList()
                    .ForEach(a => a.DescricaodoProduto = lista
                        .Select(p => p.DescricaoCompleta)
                        .First())
                        ;

            }
            return dt;
            //
        }
        public void DeleteNotasFiscaisDinamicaProdutoMySql(List<NotasFiscaisDinamicaProduto> dt)
        {
            ContextoMySql.NotasFiscaisDinamicaProdutos.RemoveRange(dt);
            ContextoMySql.SaveChanges();
        }


        #endregion



        #endregion
    }
}