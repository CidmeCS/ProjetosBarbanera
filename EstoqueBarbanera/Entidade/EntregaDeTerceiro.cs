using System.ComponentModel.DataAnnotations;

namespace Estoque.Entidade
{
    public class EntregaDeTerceiro
    {
        [Key]
        public int Id { get; set; }
        public string Produto { get;  set; }
        public string Descricao { get;  set; }
        public double Quantidade { get;  set; }
        public string Deposito { get;  set; }
        public string EntreguePara { get;  set; }
        public string Data { get;  set; }
    }
}