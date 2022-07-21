using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Entidade
{
    public class Prateleiras
    {
        public string Produto { get; internal set; }
        public string Descricao { get; internal set; }
        public string PrateleiraAtual { get; internal set; }
        public string PrateleiraNova { get; internal set; }
    }
}
