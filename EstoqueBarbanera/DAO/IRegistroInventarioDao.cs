using Estoque.Entidade;
using System.Collections.Generic;
using System.Data;

namespace Estoque.DAO
{
    internal interface IRegistroInventario
    {
        void AdicionaRegistroInventario(List<RegistroInventario> ri);
        List<RegistroInventario> ListaRegistroInventario(int inicial, int qtd);
        List<RegistroInventario> ListaRegistroInventario(int count);
        List<RegistroInventario> ListaRegistroInventario();
        void RemoverRegistroInventario(RegistroInventario ri);

    }
}