using Estoque.Entidade;
using System;
using System.Collections.Generic;

namespace Estoque.DAO
{
    public interface IDataBackUP
    {
        List<DataBackUP> ListaDataBackUP();
        void AlteraDataBackUP(DataBackUP db);
    }
}