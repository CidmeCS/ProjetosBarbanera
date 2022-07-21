using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Entidade
{
    class SendApontaRFID
    {
        public string Produto { get; internal set; }
        public string Metros { get; internal set; }
        public string Operacao { get; internal set; }
        public string Prateleira { get; internal set; }
    }
}
