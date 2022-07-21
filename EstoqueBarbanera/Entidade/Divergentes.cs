using System;
using System.ComponentModel.DataAnnotations;

namespace Estoque.Entidade
{
    public class Divergentes   : IEquatable<Divergentes>
    {
       
        public string Produto { get; internal set; }
        public string Descricao { get; internal set; }
        public string Unid { get; internal set; }
        public string Prateleira { get; internal set; }
        public decimal SaldoSistema { get; set; }
        public decimal SaldoEtiqueta { get; set; }
        public decimal SaldoDivergente { get; internal set; }
        public decimal Livre17Sistema { get; internal set; }
        public decimal Livre17Etiqueta { get; internal set; }
        public decimal ConvertidoSistema { get; internal set; }
        public decimal ConvertidoEtiqueta { get; internal set; }
        public decimal ConvertidoDivergente { get; internal set; }
        public string OBS { get; set; }

        public bool Equals(Divergentes other)
        {
            return this.Produto == other.Produto;
        }

        public override int GetHashCode()
        {
            return this.Produto.GetHashCode();
        }
    }
}
