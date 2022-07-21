using Estoque.Entidade;
using System.Collections.Generic;

namespace Estoque.DAO
{
    internal interface IEtiquetaMovimentos
    {
        void AdicionaEtiquetaMovimentos(List<EtiquetaMovimentos> em);
        List<EtiquetaMovimentos> ListaEtiquetaMovimentos();

        void DeletarEtiquetaMovimento(EtiquetaMovimentos emt);


    }
}