using System.ComponentModel.DataAnnotations;
namespace ImportExportERP.Entidade
    
{
    public class DepositoDeTerceiro
    {
        [Key]
        public int Id { get; set; }
        public string Deposito { get; set; }
        public string Nome { get; set; }
    }
}