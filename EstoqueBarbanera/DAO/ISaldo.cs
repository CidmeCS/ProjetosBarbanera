using Estoque.Entidade;
using System.Collections.Generic;

namespace Estoque.DAO
{
    internal interface ISaldo
    {
        void AdicionaSaldo(List<Saldo> dt);
        void TruncateSaldo();
        List<Saldo> ListaSaldo();
        void AlterarPrateleiraSaldo(List<string> l);
        void AlteraSaldo(Saldo saldo);
        void AlteraSaldo(List<Saldo> saldos);

        void AlterarPrateleiraSaldo(string produto, string prateleiraNova);
       
    }
}