using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Entidade
{
    public class SaldoDivergente
    {
        [Key]
        public int Id { get; internal set; }
        public string Produto { get; internal set; }

        [Column(TypeName = "decimal(18, 3)")]
        public decimal Divergente { get; internal set; }
        public string OBS { get; internal set; }
        public DateTime Data { get; internal set; }
    }
}
