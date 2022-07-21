using Estoque.Entidade;
using System.Collections.Generic;

namespace Estoque.DAO
{
    internal interface IOrdensDeProducao
    {
        List<OrdensDeProducao> ListaOrdensDeProducao();
    }
}