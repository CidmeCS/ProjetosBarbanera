using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Entidade
{
    public class PedidoDeVenda
    {
        [Key]
        public int Id { get; set; }
        public DateTime DataEntrega { get; set; }  //
        public string Seq { get; set; }
        public double Quantidade { get; set; }
        public string StatusdoItem { get; set; }
        public DateTime DataPedido { get; set; }
        public string MotivosBloqueio { get; set; }
        public string Vendedor { get; set; }
        public string NPedido { get; set; }          //
        public string Bloq { get; set; }
        public string Item { get; set; }               //
        public string Descricao { get; set; }
        public double Disponivel { get; set; }
        public string Deposito { get; set; }
        public string Estabelecimento { get; set; }
        public string OrdemCompra { get; set; }
        public double PrecoUnitário { get; set; }
        public double ValorTotal { get; set; }
        public string RazaoSocial { get; set; }          //
        public string NomeFantasia { get; set; }
        public string GrupoItem { get; set; }
        public string TextoEspecifico { get; set; }
        public string CodigoCliente { get; set; }
        public string DESCR_1 { get; set; }
        public string DESCR_2 { get; set; }
        public string VendaConfirmada { get; set; }
    }
}
