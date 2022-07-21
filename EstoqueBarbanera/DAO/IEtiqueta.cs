using Estoque.Entidade;
using System.Collections.Generic;

namespace Estoque.DAO
{
    internal interface IEtiqueta
    {
        List<Etiqueta> ListarEtiqueta();
        void AlterarEtiquetas(List<Etiqueta> le);
        void AdicionarEtiquetas(List<Etiqueta> le);

        void DeletarEtiquetas(List<Etiqueta> leD);
        void TruncateEtiquetas();
    }
}