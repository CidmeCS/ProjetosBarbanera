using Estoque.Entidade;
using System.Collections.Generic;

namespace Estoque.DAO
{
    internal interface IDepositoDeTerceiro
    {
        void AdicionaDepositoDeTerceiro(List<DepositoDeTerceiro> dt);
        void TruncateDepositoDeTerceiro();
        List<DepositoDeTerceiro> ListaDepositoDeTerceiro();
    }
}