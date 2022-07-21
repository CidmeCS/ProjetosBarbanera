using Estoque.Entidade;
using System.Collections.Generic;
using System.Data;

namespace Estoque.DAO
{
    interface ISaldoDeTerceiro
    {
        void AdicionaSaldoDeTerceiro(List<SaldoDeTerceiro> st);
        void TruncateSaldoDeTerceiro();
        List<SaldoDeTerceiro> ListaSaldoDeTerceiro();

    }
}
