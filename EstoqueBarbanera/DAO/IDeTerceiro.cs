using Estoque.Entidade;
using System.Collections.Generic;

namespace Estoque.DAO
{
    internal interface IDeTerceiro
    {
        void AdicionaDeTerceiro(List<DeTerceiro> dt);
        void TruncateDeTerceiro();
        IList<DeTerceiro> ListaDeTerceiro();
    }
}