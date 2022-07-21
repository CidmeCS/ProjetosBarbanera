using Estoque.Entidade;
using System.Collections.Generic;

namespace Estoque.DAO
{
    internal interface IItensDeEstoque
    {
        void AdicionaItensDeEstoque(List<ItensDeEstoque> dt);
        void TruncateItensDeEstoque();
        List<ItensDeEstoque> ListaItensDeEstoque();
        void AlterarPrateleiraItensDeEstoque(List<string> l);
    }
}