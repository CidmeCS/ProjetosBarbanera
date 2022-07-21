using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Entidade
{
    public class Etiqueta
    {
        [Key]
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }


        [Column(TypeName = "decimal(18, 3)")]
        public decimal SaldoAtual { get; set; }


        public string Prateleira { get; set; }


        [Column(TypeName = "decimal(18, 5)")]
        public decimal Livre17 { get; set; }


        [Column(TypeName = "decimal(18, 2)")]
        public decimal Convertido { get; set; }
        public string Grupo { get; set; }
        public string UND { get; set; }
    }
}