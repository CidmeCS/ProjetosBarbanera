using PCP.Entidade;
using System.Collections.Generic;

namespace PCP.DAO
{
    internal interface ISaldo
    {
       
        List<Saldo> ListaSaldo();
        void AlteraSaldo(Saldo saldo);
        void AlteraSaldo(List<Saldo> saldos);
    }
}