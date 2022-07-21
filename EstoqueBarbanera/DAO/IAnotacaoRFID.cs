using Estoque.Entidade;
using System.Collections.Generic;

namespace Estoque.DAO
{
    internal interface IAnotacaoRFID
    {
        void AdicionaAnotacaoRFID(List<AnotacaoRFID> arfid);
        void ExcluiTudoAnotacaoRFID();

        List<AnotacaoRFID> ListaAnotacaoRFID();

    }
}