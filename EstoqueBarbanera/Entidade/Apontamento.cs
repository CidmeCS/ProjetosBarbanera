using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Entidade
{
    class Apontamento
    {
        public string OP { get; set; }
        public string Produto { get; internal set; }
        public string Descricao { get; internal set; }
        public string Metros { get; internal set; }
        public string KG { get; internal set; }
        public string Data { get; internal set; }
        public string TM { get; internal set; }
        public string Livre2 { get; internal set; }
        public double SaldoEtiqueta { get; internal set; }
    }
}
