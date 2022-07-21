using Estoque.Entidade;
using System.Collections.Generic;

namespace Estoque.DAO
{
    internal interface IMovimento
    {
        List<Movimento> ListaMovimento();
    }
}