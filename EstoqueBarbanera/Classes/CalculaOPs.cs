using Estoque.DAO;
using Estoque.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Classes
{
    public class CalculaOPs
    {
        internal List<OrdensDeProducao> CalcularOP(string text)
        {
            Crud c = new Crud();
            var ops = c.ListaOrdensDeProducao().Where(p => p.NroOP == Convert.ToInt32(text)).ToList();
            return ops;
        }
    }
}
