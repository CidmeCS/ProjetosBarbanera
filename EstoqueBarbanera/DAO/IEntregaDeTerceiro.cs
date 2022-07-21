using Estoque.Entidade;
using System.Collections.Generic;

namespace Estoque.DAO
{
    internal interface IEntregaDeTerceiro
    {
        void AdicionarItemEntregaDeTerceiro(List<EntregaDeTerceiro> entrega);
        List<EntregaDeTerceiro> ListaItemEntregaDeTerceiro();
        void RemoveEntregaDeTerceiro(List<EntregaDeTerceiro> lista);
    }
}