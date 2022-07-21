using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportExportERP.Entidade
{
    public class Movimento
    {
        [Key]
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string TM { get; set; }
        public string Codigo { get; set; }
        public string Lote { get; set; }
        public string Documento { get; set; }
        public string AC { get; set; }
        public double Quantidade { get; set; }
        public double ValorMovimento { get; set; }
        public string OS { get; set; }
        public string Descricao { get; set; }
        public string Unidade { get; set; }
        public string TipodeContabilização { get; set; }
        public string ClienteFornecedor { get; set; }
        public string NomeFantasia { get; set; }
        public string Contabiliza { get; set; }
        public string ContaContabil { get; set; }
        public string Dig { get; set; }
        public string CentrodeCusto { get; set; }
        public string Dig2 { get; set; }
        public string Livre2 { get; set; }
        public string DescrTipoMovto { get; set; }
        public double CUSTO_INF { get; set; }
        public double SaldoAtual { get; set; }
        public double ConsMedio { get; set; }
        public double VALOR { get; set; }
        public string DESC_RATEA { get; set; }
        public string REF_LOTE { get; set; }
        public double QTDE_BRUTA { get; set; }
        public string FLAG { get; set; }
        public string EMP_FIL { get; set; }
        public string ESTAB { get; set; }
        public string DEPOSITO { get; set; }
        public double CustoMedioSimulado { get; set; }
        public string NR_TRANSF_CG { get; set; }
        public string OperadorInclusao { get; set; }
        public DateTime DataInclusao { get; set; }
        public string HoraInclusao { get; set; }
        public double CustoMedio { get; set; }
        public string Roteiro { get; set; }
        public string DataInicioRoteiro { get; set; }
        public string QuantidadeDigitada { get; set; }
        public string Fator { get; set; }
        public string OPERACAO { get; set; }
        public string DescrMovto { get; set; }

    }
}
