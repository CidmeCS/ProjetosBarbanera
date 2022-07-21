using ImportExportERP.Entidade;
using System.Collections.Generic;

namespace ImportExportERP
{
    internal interface ISqlServer
    {
        void AdicionaSaldoSqlServer(List<Saldo> dt);
        void TruncateSaldoSqlServer();
        IList<Saldo> ListSaldoSqlServer();

        void AdicionaPedidoDeCompraSqlServer(List<PedidoDeCompra> dt);
        void TruncatePedidoDeCompraSqlServer();
        IList<PedidoDeCompra> ListPedidoDeCompraSqlServer();

        void AdicionaPedidoDeVendaSqlServer(List<PedidoDeVenda> dt);
        void TruncatePedidoDeVendaSqlServer();
        IList<PedidoDeVenda> ListPedidoDeVendaSqlServer();

        void AdicionaMovimentoSqlServer(List<Movimento> dt);
        void TruncateMovimentoSqlServer();
        IList<Movimento> ListMovimentoSqlServer();
        void DeleteMovimentoSqlServer(List<Movimento> dt);

        void AdicionaForaDeEstoqueSqlServer(List<ForaDeEstoque> dt);
        void TruncateForaDeEstoqueSqlServer();
        IList<ForaDeEstoque> ListForaDeEstoqueSqlServer();

        void AdicionaDeTerceiroSqlServer(List<DeTerceiros> dt);
        void TruncateDeTerceiroSqlServer();
        IList<DeTerceiros> ListDeTerceiroSqlServer();

        void AdicionaItemDeEstoqueSqlServer(List<ItensDeEstoque> dt);
        void TruncateItemDeEstoqueSqlServer();
        IList<ItensDeEstoque> ListItemDeEstoqueSqlServer();

        void AdicionaDepositoDeTerceiroSqlServer(List<DepositoDeTerceiro> dt);
        void TruncateDepositoDeTerceiroSqlServer();
        IList<DepositoDeTerceiro> ListaDepositoDeTerceiroSqlServer();

        void AdicionaSaldoDeTerceiroSqlServer(List<SaldoDeTerceiro> dt);
        void TruncateSaldoDeTerceiroSqlServer();
        IList<SaldoDeTerceiro> ListSaldoDeTerceiroSqlServer();

        void TruncateAtualizaAtualizacaoSqlServer();
        void AtualizaAtualizacaoMySql(List<Atualizacao> at);
        IList<Atualizacao> ListAtualizacaoSqlServer();

        void AdicionaOrdensDeProducaoSqlServer(List<OrdensDeProducao> dt);
        void TruncateOredensDeProducaoSqlServer();
        IList<OrdensDeProducao> ListOrdensDeProducaoSqlServer();

        void AdicionaNotasFiscaisDinamicaProdutoSqlServer(List<NotasFiscaisDinamicaProduto> dt);
        void TruncateNotasFiscaisDinamicaProdutoMSqlServer();
        IList<NotasFiscaisDinamicaProduto> ListNotasFiscaisDinamicaProdutoSqlServer();
    }
}