using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Entidade
{
    public class OrdensDeProducao
    {
        [Key]
        public int Id { get; set; }
        public int NroOP { get; set; }
        public string StatusOP { get; set; }
        public string Estabelecimento { get; set; }
        public string Deposito { get; set; }
        public string Produto { get; set; }
        public string Traducao { get; set; }
        public string QuantidadePrev { get; set; }
        public string QuantidadeDigitada { get; set; }
        public string Fator { get; set; }
        public string Saldo { get; set; }
        public string Roteiro { get; set; }
        public string DtInicRoteiro { get; set; }
        public string DtAbertura { get; set; }
        public string HrAbertura { get; set; }
        public string Programacao { get; set; }
        public string Plano { get; set; }
        public string DtInicProd { get; set; }
        public string DtFimProd { get; set; }
        public string RefLote { get; set; }
        public string TipodeOP { get; set; }
        public string Descricao { get; set; }
        public string TipodeCusto { get; set; }
        public string PesoparaRateio1 { get; set; }
        public string PesoparaRateio2 { get; set; }
        public string PesoparaRateio3 { get; set; }
        public string PesoparaRateio4 { get; set; }
        public string EMPRESA { get; set; }
        public string FILIAL { get; set; }
        public string STATUS { get; set; }
        public string QuantidadeApont { get; set; }
        public string NR_OP_ORIGEM { get; set; }
        public string DtEncerramento { get; set; }
        public string DtCancelamento { get; set; }
        public string DtLiberacao { get; set; }
        public string HrEncerramento { get; set; }
        public string HrCancelamento { get; set; }
        public string HrLiberacao { get; set; }
        public string HrInicioProd { get; set; }
        public string HrFimProd { get; set; }
        public string COD_OBS_GEN { get; set; }
        public string Descricao1 { get; set; }
        public string Descricao2 { get; set; }
        public string Observacao { get; set; }
        public string DocOrigem { get; set; }
        public string Operador { get; set; }
        public string DataAlter { get; set; }
        public string HoraAlter { get; set; }
        public string RESERVADO_02 { get; set; }
        public string MaxProducao { get; set; }
        public string Grupo { get; set; }
        public string DescricaoGrupo { get; set; }
        public string PedidosDeVenda { get; set; }

    }
}

