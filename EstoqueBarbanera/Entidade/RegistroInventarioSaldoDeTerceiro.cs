using System;
using System.ComponentModel.DataAnnotations;

namespace Estoque.Entidade
{
    public class RegistroInventarioSaldoDeTerceiro
    {
        [Key]
        public int Id { get; set; }
        public string Produto { get; internal set; }
        public string Descricao { get; internal set; }
        public string Prateleira { get; internal set; }
        public string Unid { get; internal set; }
        public double SaldoAtual { get; internal set; }
        public double DeTerceiro { get; internal set; }
        public string Inventario { get; internal set; }
        public DateTime DiaInventario { get; internal set; }
        public string ClienteDeposito { get; internal set; }
    }
}