using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Entidade
{
    public class ItensDeEstoque
    {
        [Key]
        public int Id { get; set; }
        public string Codigo { get; set; }
        public double PrecoCompra { get; set; }
        public string Traducao { get; set; }
        public string Unidade { get; set; }
        public string Grupo { get; set; }
        public string Lotes { get; set; }
        public string NS { get; set; }
        public string Descricao { get; set; }
        public double QuantidadeDisponivel { get; set; }
        public double SaldoFisico { get; set; }
        public string QuantidadeporUnidade { get; set; }
        public string Cubagem { get; set; }
        public string PesoBruto { get; set; }
        public string PesoLiquido { get; set; }
        public string DatadaCompra { get; set; }
        public string Prateleira { get; set; }
        public string Status { get; set; }
        public DateTime ItemCadastradoEm { get; set; }
        public string PosicaoFiscal { get; set; }
        public string ComplPosicaoFiscal { get; set; }
        public string UnidAlterDIPI { get; set; }
        public string FatorUnidDIPI { get; set; }
        public string Procedência { get; set; }
        public string UnAlterDIPI { get; set; }
        public string EXdaTIPI { get; set; }
        public string CoddoFabricantedoProduto { get; set; }
        public string ExpPalm { get; set; }
        public double PrecoVenda { get; set; }
        public string Codigo2 { get; set; }
        public string DESCR_1 { get; set; }
        public string DESCR_2 { get; set; }
        public string DescricaoCompleta { get; set; }
        public string CodigoExterno { get; set; }
        public string ESTAB { get; set; }
        public string DEPOSITO { get; set; }
        public double QtdUltFech { get; set; }
        public double ENTRADAS { get; set; }
        public double SAIDAS { get; set; }
        public string OS_PREVIST { get; set; }
        public double ForadeEstoque { get; set; }
        public string VendasConsig { get; set; }
        public double ComprasConsig { get; set; }
        public double ResVendas { get; set; }
        public double PedVenda { get; set; }
        public double Preco { get; set; }
        public string QT_ALT_OBR { get; set; }
        public double EmpReqCompra { get; set; }
        public string UnidadeAlternativa { get; set; }
        public double FatordeConversao { get; set; }
        public string CodFamilia { get; set; }
        public string DescricaodaFamilia { get; set; }
        public string CodEAN13 { get; set; }
        public double EstoqueMinimo { get; set; }
        public double EstoqueMáximo { get; set; }
        public double Tolerancia { get; set; }
        public double Leadtime { get; set; }
        public string CodigodoRecolhimento { get; set; }
        public string AliquotadeIPI { get; set; }
        public string Livre1 { get; set; }
        public string Livre2 { get; set; }
        public string Livre3 { get; set; }
        public string Livre4 { get; set; }
        public string Livre5 { get; set; }
        public string Livre6 { get; set; }
        public string Livre7 { get; set; }
        public string Livre8 { get; set; }
        public string Livre9 { get; set; }
        public string Livre10 { get; set; }
        public string Livre11 { get; set; }
        public string Livre12 { get; set; }
        public DateTime Livre13 { get; set; }
        public DateTime Livre14 { get; set; }
        public DateTime Livre15 { get; set; }
        public DateTime Livre16 { get; set; }
        public string Livre17 { get; set; }
        public string Livre18 { get; set; }
        public string Livre19 { get; set; }
        public string Livre20 { get; set; }
        public string CodigodeServico { get; set; }
        public string ContaContabil { get; set; }
        public string ContaConsumo { get; set; }
        public string CentrodeCusto { get; set; }
        public string GeneroCotepe { get; set; }
        public string TipoItemSped { get; set; }
        public string CodigoProdutoSimilar { get; set; }
        public double ValorUltFech { get; set; }
        public double CustoMedioSimulado { get; set; }
        public double CustoMedio { get; set; }
        public string RESERVADO_11 { get; set; }
        public string CodigodeTributacaoAM { get; set; }
        public string GrupodeFamilia { get; set; }
        public string DescricaoGrupoFamilia { get; set; }
        public string DescricaoCompleta2 { get; set; }
        public string Descricaos { get; set; }
        public string CEST { get; set; }
        public string Conta { get; set; }
        public string DgConta { get; set; }
        public string ContaCons { get; set; }
        public string DgContaCons { get; set; }
        public string CentroCusto { get; set; }
        public string DgCentroCusto { get; set; }
        public string PrecodeReposicao { get; set; }
        public string Reinf { get; set; }
        public string GoodsReceipt { get; set; }
        public string DescricaodoGrupo { get; set; }
        public string CodigodeTributacao { get; set; }
        public string CodigodeTributacaoAlternativo { get; set; }
        public string Familia { get; set; }
        public string Formadepedir { get; set; }
        public string FatorUnidadeNCM { get; set; }
        public string Fatordaunidade { get; set; }
        public string Unidadealternativaexportacao { get; set; }
        public string FatorunidadeDIPIexportacao { get; set; }
        public string Aplicacao { get; set; }

        public bool Equals(ItensDeEstoque other)
        {

            //Check whether the compared object is null.
            if (Object.ReferenceEquals(other, null)) return false;

            //Check whether the compared object references the same data.
            if (Object.ReferenceEquals(this, other)) return true;

            //Check whether the products' properties are equal.
            return Codigo.Equals(other.Codigo);
        }

        // If Equals() returns true for a pair of objects
        // then GetHashCode() must return the same value for these objects.

        public override int GetHashCode()
        {
            //Get hash code for the Code field.
            int hashProductCode = Codigo.GetHashCode();

            //Calculate the hash code for the product.
            return hashProductCode;
        }

    }
}
