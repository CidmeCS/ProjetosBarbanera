using Estoque.Entidade;
using System.Collections.Generic;

namespace Estoque.DAO
{
    internal interface IForaDeEstoque
    {
        void AdicionaForaDeEstoque(List<ForaDeEstoque> dt);
        void TruncateForaDeEstoque();
        IList<ForaDeEstoque> ListaForaDeEstoque();
    }
}