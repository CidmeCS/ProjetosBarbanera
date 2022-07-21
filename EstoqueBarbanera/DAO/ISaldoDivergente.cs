using Estoque.Entidade;
using System.Collections.Generic;

namespace Estoque.DAO
{
    public interface ISaldoDivergente
    {
        List<SaldoDivergente> ListarSaldoDivergente();
        void AlterarSaldoDivergente(List<SaldoDivergente> le);
        void AdicionarSaldoDivergente(List<SaldoDivergente> le);

        void DeletarSaldoDivergente(List<SaldoDivergente> leD);
        void TruncateSaldoDivergente();
    }
}