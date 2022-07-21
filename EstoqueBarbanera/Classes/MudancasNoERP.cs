using Estoque.Classes.ERP;
using Estoque.DAO;
using Estoque.Entidade;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estoque.Classes
{
    public class MudancasNoERP
    {
        public static List<SaldoDeTerceiroNew> lista { get; private set; }

        DataGridView dgv;

        public MudancasNoERP(DataGridView dgv)
        {
            this.dgv = dgv;
        }

        public MudancasNoERP()
        {
        }

        internal void ZerarPrateleiraNoERP()
        {
            Crud cd = new Crud();

            lista = (from l in cd.ListaSaldoDeTerceiro()
                     where l.SaldoAtual == 0 & l.DeTerceiros == 0 & l.Prateleira != ""
                     orderby l.DEPOSITO, l.Produto
                     select new SaldoDeTerceiroNew
                     {
                         Produto = l.Produto,
                         Descricao = l.Descricao,
                         Prateleira = l.Prateleira,
                         SaldoAtual = l.SaldoAtual,
                         DeTerceiros = l.DeTerceiros,
                         ESTAB = l.ESTAB,
                         DEPOSITO = l.DEPOSITO
                     }).ToList();

            dgv.DataSource = lista;

            if (MessageBox.Show("Deseja Limpar Prateleiras DeTerceiros? \nSaldoAtual = 0\nDeterceiros = 0\nPrateleira <> '' ", "Limpar Prateliras DeTerceiros", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                LimparPrateleirasDeTerceiros(lista.Select(c => new ViewModel { Produto = c.Produto, DEPOSITO = c.DEPOSITO }).ToList());
            }
        }

        private static void LimparPrateleirasDeTerceiros(List<ViewModel> lista)
        {
            ERP_Pronto.Login();
            ERP_Pronto.BuscarJanela("ESTQBR", "Consultar Itens de Estoque");
            ERP_Pronto.SelecionaEstabelecimento(2);
            ERP_Pronto.AplicaSemelhanca();
            ERP_Pronto.PosicionaDeposito();
            Thread.Sleep(1000);

            foreach (var item in lista)
            {
                var deposito = item.DEPOSITO.Trim();
                var produto = item.Produto.Trim();


                ERP_Pronto.EliminarPrateleiraeTerceiros(produto, Convert.ToInt32(deposito));

                bool x = ERP_Pronto.VerificaPrateleiraEliminada();

                Crud c = new Crud();
                c.AlterarPrateleiraItensDeSaldoDeTerceiro(produto);
                ERP_Pronto.ReposicionaDeposito();
            }

            MessageBox.Show("Prateleiras de Itens de Terceiros Eliminadas", "Prateleiras Eliminadas");

        }

        internal void AcertoSucata()
        {
            Crud c = new Crud();
            var acerto260 = c.ListaRegistroInventario().OrderByDescending(p => p.Id).Take(6).Where(p => p.Acerto > 0).ToList();
            var acerto560 = c.ListaRegistroInventario().OrderByDescending(p => p.Id).Take(6).Where(p => p.Acerto < 0).ToList();
            ERP_Pronto.Login();
            ERP_Pronto.BuscarJanela("EPMVACBR", "Consultar Movimentos de Estoque - Acertos");
            ERP_Pronto.AguardaJanelaAtivar("Consultar Movimentos de Estoque - Acertos", 60);
            ERP_Pronto.NovoRegistro();
            ERP_Pronto.AguardaJanelaAtivar("Incluir Acertos de Estoque", 60);

            if (acerto260.Count() > 0)
            {
                foreach (var item in acerto260)
                {
                    ERP_Pronto.PreparaAcerto("260");
                    ERP_Pronto.LancarAcerto(item.Produto, item.Acerto);
                }
            }

            if (acerto560.Count() > 0)
            {
                foreach (var item in acerto560)
                {
                    ERP_Pronto.PreparaAcerto("560");
                    ERP_Pronto.LancarAcerto(item.Produto, item.Acerto);
                }
            }

            ERP_Pronto.FecharABC71();
            MessageBox.Show("Acertos Lançados com Sucesso", "Acertos OK");

        }
    }

    internal class ViewModel
    {
        public string Produto { get; internal set; }
        public string DEPOSITO { get; internal set; }
    }

    public class SaldoDeTerceiroNew
    {
        public string Produto { get; set; }
        public string Descricao { get; internal set; }
        public string Prateleira { get; internal set; }
        public double SaldoAtual { get; internal set; }
        public double DeTerceiros { get; internal set; }
        public string ESTAB { get; internal set; }
        public string DEPOSITO { get; internal set; }
    }
}
