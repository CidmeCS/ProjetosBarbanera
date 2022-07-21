using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Entidade
{
    public class Leituras : IEquatable<Leituras>
    {
        public string Seq { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd HHmmss}")]
        public DateTime Data { get; set; }
        public string ID { get; set; }
        public string Produto { get; set; }
        public string Descricao { get; set; }
        public string Unid { get; set; }
        public string Prateleira { get; set; }
        public string SaldoAtual { get; set; }
        public string Livre17 { get; set; }
        public string Convertido { get; set; }

        public bool Equals(Leituras other)
        {
            return this.ID == other.ID;
        }

        public override int GetHashCode()
        {
            return this.ID.GetHashCode();
        }
    }
}
