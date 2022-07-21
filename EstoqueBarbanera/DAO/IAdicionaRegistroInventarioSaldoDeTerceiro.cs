using Estoque.Entidade;
using System.Collections.Generic;

namespace Estoque.DAO
{
    interface IAdicionaRegistroInventarioSaldoDeTerceiro
    {
        void AdicionaRegistroInventarioSaldoDeTerceiro(List<RegistroInventarioSaldoDeTerceiro> list);
        List<RegistroInventarioSaldoDeTerceiro> ListaRegistroInventarioSaldoDeTerceiro(int count);
        void RemoverRegistroInventarioSaldoDeTerceiro(RegistroInventarioSaldoDeTerceiro list);
        List<RegistroInventarioSaldoDeTerceiro> ListaRegistroInventarioSaldoDeTerceiro(int id, int count);
    }
}