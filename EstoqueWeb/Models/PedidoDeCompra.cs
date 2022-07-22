using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace EstoqueWeb.Models
{
    public class PedidoDeCompra
    {
        [Key]
        public int Id { get; set; }
        public string Pedido { get; set; }
        public DateTime Data { get; set; }
        public DateTime Entrega { get; set; }
        public string Produto { get; set; }
        public double ValorUnitario { get; set; }
        public double PrecoTotal { get; set; }
        public string Unidade { get; set; }
        public string Requisicao { get; set; }
        public string LinhaReq { get; set; }
        public string CCusto { get; set; }
        public string DescricaoAlternativa { get; set; }
        public string Fornecedor { get; set; }
        public string Indice { get; set; }
        public string DescricaodaMoeda { get; set; }
        public double Quantidade { get; set; }
        public double QtdeEntregue { get; set; }
        public string LinhaPed { get; set; }
        public double Saldo { get; set; }
        public string Situacao { get; set; }
        public string STA_REG { get; set; }
        public string Descricao { get; set; }
        public string Observacoes { get; set; }
        public string DigCCusto { get; set; }
        public string Título { get; set; }
        public string Traducao { get; set; }
        public string BaixaManual { get; set; }
        public string BaixaNF { get; set; }
        public string UnidadeEstq { get; set; }
        public string QtdeEstq { get; set; }
        public string EMP_FIL { get; set; }
        public string ESTAB { get; set; }
        public string DEPOSITO { get; set; }
        public string FORNEC { get; set; }
        public string NR_COTACAO { get; set; }
        public string OS { get; set; }
        public string PRIORIDADE { get; set; }
        public string DT_ENT_PREV { get; set; }
        public string DT_ENT_ORIG { get; set; }
        public string DT_ULT_ENT { get; set; }
        public string PORC_ICM { get; set; }
        public string VEZES_ENT { get; set; }
        public string LISTA { get; set; }
        public string BASE_UNIT { get; set; }
        public string PERC_DESC { get; set; }
        public string PERC_IPI { get; set; }
        public string VLR_DESC { get; set; }
        public string VLR_IPI { get; set; }
        public string VR_ENTR { get; set; }
        public string SEQ_ALT { get; set; }
        public string COD_TRIB { get; set; }
        public string TRAT_FISC { get; set; }
        public string COD_GEN { get; set; }
        public string CONTA { get; set; }
        public string DG_CONTA { get; set; }
        public string CONTA2 { get; set; }
        public string DG_CONTA2 { get; set; }
        public string C_CUSTO2 { get; set; }
        public string DG_CCUSTO2 { get; set; }
        public string GERA_FLUXO { get; set; }
        public string LIVRE { get; set; }
        public string BATCH_PROG { get; set; }
        public string BATCH_DATA { get; set; }
        public string BATCH_HORA { get; set; }
        public string ESTAGIO { get; set; }
        public string DT_INIC_EXEC { get; set; }
        public string PERIODO { get; set; }
        public string PROJETO_OBRA { get; set; }
        public string PROJETO_ETAPA { get; set; }
        public string APROVADOR_PROX { get; set; }
        public string APROV_AVISADO { get; set; }
        public string DT_APROVACAO { get; set; }
        public string DT_VALIDADE { get; set; }
        public string SOLICITANTE { get; set; }
        public string UNID_FORN { get; set; }
        public string FATOR_UN_FORN { get; set; }
        public string CUSTO_QT_SOLIC { get; set; }
        public string CUSTO_QT_APROV { get; set; }
        public string COND_PAGTO { get; set; }
        public string TIPO_DESPESA { get; set; }
    }
}
