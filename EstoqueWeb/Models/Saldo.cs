using System.ComponentModel.DataAnnotations;

namespace EstoqueWeb.Models
{
    public class Saldo
    {
        [Key]
        public int Id { get; set; }
        public string Produto { get; set; }
        public string Traducao { get; set; }
        public string Descricao { get; set; }
        public string Unid { get; set; }
        public string Lote { get; set; }
        public string Grupo { get; set; }
        public double Disponivel { get; set; }
        public double SaldoAtual { get; set; }
        public double SaldoUltFech { get; set; }
        public double Entradas { get; set; }
        public double Saidas { get; set; }
        public double PedCompras { get; set; }
        public double PedVendas { get; set; }
        public double ConsuPrevOs { get; set; }
        public double JaRequisOS { get; set; }
        public double ProdPrevOS { get; set; }
        public double ProdEntrOS { get; set; }
        public double ForaEstoque { get; set; }
        public double Transito { get; set; }
        public double DeTerceiros { get; set; }
        public double VendaConsign { get; set; }
        public double CompraEntrFutura { get; set; }
        public double VendaEntrFutura { get; set; }
        public double CompraConsig { get; set; }
        public double AguardandoCQ { get; set; }
        public double EstqMinimo { get; set; }
        public double EstqMaximo { get; set; }
        public double ReservaDeVendas { get; set; }
        public string Prateleira { get; set; }
        public double SaldoPedidoDataEntregaExcedida { get; set; }
        public double PrevFabric { get; set; }
        public double DiassemMovimento { get; set; }
        public string EMP_FIL { get; set; }
        public string ESTAB { get; set; }
        public string DEPOSITO { get; set; }
        public string QT_CCON { get; set; }
        public string GR1 { get; set; }
        public string DESCR_2 { get; set; }
        public string FORNECED_2 { get; set; }
        public string DESCR_3 { get; set; }
        public double RESERVADO_11 { get; set; }
        public double ValorUltFech { get; set; }
        public double CustoMedioSimulado { get; set; }
        public double CustoMedio { get; set; }
        public double PrecoListaPadrao { get; set; }
        public string Descricao2 { get; set; }
    }
}
