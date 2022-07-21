using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportExportERP.Entidade
{
    public class ForaDeEstoque
    {
        [Key]
        public int Id { get; set; }
        public string Op { get; set; }
        public string DocEn { get; set; }
        public string Serie { get; set; }
        public string Produto { get; set; }
        public string Traducao { get; set; }
        public string TM { get; set; }
        public DateTime Data { get; set; }
        public string Fornecedor { get; set; }
        //public string Cliente { get; set; }
        public string DocFiscal { get; set; }
        public string Serie2 { get; set; }
        public string Cont { get; set; }
        public string Lt { get; set; }
        public double QtdeNf { get; set; }
        public double ValorNf { get; set; }
        public double ValorCusto { get; set; }
        public double SaldoQtde { get; set; }
        public double SaldoCusto { get; set; }
        public string Observacao { get; set; }
        public string NomeFantasia { get; set; }
        public string Descricao { get; set; }
        public double ValorUnitario { get; set; }
        public string TextoEspecificoFatBalcao { get; set; }
        public string ObsNFBalcao { get; set; }
        public string TIPO_MOVTO_NF { get; set; }
        public string NRO_FORNEC { get; set; }
        public string SEQ_FORNEC { get; set; }
        public double QT_ENVIADA { get; set; }
        public double VR_ENV_NF { get; set; }
        public double VR_ENVIADO { get; set; }
        public double QT_DEVOLV { get; set; }
        public double VR_DEV_NF { get; set; }
        public double VR_DEVOLV { get; set; }
        public string ESTAB { get; set; }
        public string Cont2 { get; set; }
        public string DEPOSITO { get; set; }
        public string TIPO_FE { get; set; }
        public string SEQ { get; set; }
        public string EMP_FIL { get; set; }
        public string DT_VENCTO { get; set; }
        public DateTime DT_DOC_F { get; set; }
        public double QT_FECH { get; set; }
        public double QT_FECH_AN { get; set; }
        public double VR_FECH { get; set; }
        public double VR_FECH_AN { get; set; }
        public double VR_FECH_NF { get; set; }
        public double VR_FEAN_NF { get; set; }
        public string VRI_ENVIAD { get; set; }
        public string VRI_DEVOLV { get; set; }
        public string VRI_FECH { get; set; }
        public string VRI_FECH_AN { get; set; }
        public string VRU_ENVIAD { get; set; }
        public string VRU_DEVOLV { get; set; }
        public string VRU_FECH { get; set; }
        public string VRU_FECH_AN { get; set; }
        public string REF_UNID { get; set; }
        public string REF_LOCAL { get; set; }
        public string C_CUSTO { get; set; }
        public string DG_CCUSTO { get; set; }
        public string C_CUSTO2 { get; set; }
        public string DG_CCUSTO2 { get; set; }
        public string CONTA { get; set; }
        public string DG_CONTA { get; set; }
        public string CONTA2 { get; set; }
        public string DG_CONTA2 { get; set; }
        public string TIPO_CONTAB { get; set; }
        public DateTime DATA_ALTER { get; set; }
        public string TIME_STAMP { get; set; }
        public string HORA_ALTER { get; set; }
        public string ORIGEM_MOVTO { get; set; }
        public string ORDEM_ENVIO { get; set; }

    }
}
