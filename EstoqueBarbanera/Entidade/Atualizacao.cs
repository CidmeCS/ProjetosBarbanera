using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Entidade
{
    public class Atualizacao
    {
        [Key]
        public string Entidade { get; set; }
        public DateTime Data { get; set; }
    }
}
