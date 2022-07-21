using ImportExportERP.Entidade;
using System.Collections.Generic;

namespace ImportExportERP
{
    internal interface IMySql
    {
        void AdicionaSaldoMySql(List<Saldo> dt);
        void TruncateSaldoMySql();
        IList<Saldo> ListSaldoMySql();

        void AdicionaPedidoDeCompraMySql(List<PedidoDeCompra> dt);
        void TruncatePedidoDeCompraMySql();
        IList<PedidoDeCompra> ListPedidoDeCompraMySql();
        void DeletePedidoDeCompraMySql(List<PedidoDeCompra> dt);


        void AdicionaPedidoDeVendaMySql(List<PedidoDeVenda> dt);
        void TruncatePedidoDeVendaMySql();
        IList<PedidoDeVenda> ListPedidoDeVendaMySql();

        void AdicionaMovimentoMySql(List<Movimento> dt);
        void TruncateMovimentoMySql();
        IList<Movimento> ListMovimentoMySql();
        void DeleteMovimentoMySql(List<Movimento> dt);

        void AdicionaForaDeEstoqueMySql(List<ForaDeEstoque> dt);
        void TruncateForaDeEstoqueMySql();
        IList<ForaDeEstoque> ListForaDeEstoqueMySql();
        void DeleteForaDeEstoqueMySql(List<ForaDeEstoque> dt);

        void AdicionaDeTerceiroMySql(List<DeTerceiros> dt);
        void TruncateDeTerceiroMySql();
        IList<DeTerceiros> ListDeTerceiroMySql();
        void DeleteDeTerceiroMySql(List<DeTerceiros> dt);

        void AdicionaItemDeEstoqueMySql(List<ItensDeEstoque> dt);
        void TruncateItemDeEstoqueMySql();
        IList<ItensDeEstoque> ListItemDeEstoqueMySql();

        void AdicionaDepositoDeTerceiroMySql(List<DepositoDeTerceiro> dt);
        void TruncateDepositoDeTerceiroMySql();
        IList<DepositoDeTerceiro> ListaDepositoDeTerceiroMySql();

        void AdicionaSaldoDeTerceiroMySql(List<SaldoDeTerceiro> dt);
        void TruncateSaldoDeTerceiroMySql();
        IList<SaldoDeTerceiro> ListSaldoDeTerceiroMySql();

        void TruncateAtualizaAtualizacaoMySql();
        void AtualizaAtualizacaoMySql(List<Atualizacao> at);
        IList<Atualizacao> ListAtualizacaoMySql();

        void AdicionaOrdensDeProducaoMySql(List<OrdensDeProducao> dt);
        void TruncateOredensDeProducaoMySql();
        IList<OrdensDeProducao> ListOrdensDeProducaoMySql();

        void AdicionaNotasFiscaisDinamicaProdutoMySql(List<NotasFiscaisDinamicaProduto> dt);
        void TruncateNotasFiscaisDinamicaProdutoMySql();
        IList<NotasFiscaisDinamicaProduto> ListNotasFiscaisDinamicaProdutoMySql();
        void DeleteNotasFiscaisDinamicaProdutoMySql(List<NotasFiscaisDinamicaProduto> dt);

    }
}