using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImportExportERP.Entidade
{
    public class RegistroInventario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Produto { get; set; }
        public string Descricao { get; set; }
        public string Unid { get; set; }
        public double SaldoAtual { get; set; }
        public double Inventario { get; set; }
        [DataType(DataType.Date)]
        public DateTime DiaInventario { get; set; }
        public string DiasMov { get; set; }
        public double Acerto { get; set; }
    }
}