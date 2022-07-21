using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Entidade
{
    public class SaudeEtiqueta : IEquatable<SaudeEtiqueta>
    {
        public string Produto { get; set; }
        public string Descricao { get; set; }
        public double SaldoAtual { get; set; }
        public string Prateleira { get; set; }

        public bool Equals(SaudeEtiqueta other)
        {
            return this.Produto == other.Produto;
        }

        public override int GetHashCode()
        {
            return this.Produto.GetHashCode();
        }
    }
}
