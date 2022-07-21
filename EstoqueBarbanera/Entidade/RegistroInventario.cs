using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Estoque.Entidade
{
    public class RegistroInventario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Produto { get; set; }
        public string Descricao { get; set; }
        public string Prateleira { get; set; }
        public string Unid { get; set; }
        public double SaldoAtual { get; set; }
        public double ValorConvertido { get; set; }
        public double Inventario { get; set; }
        [DataType(DataType.Date)]
        public DateTime DiaInventario { get; set; }
        public string DiasMov { get; set; }
        public double Acerto { get; set; }
        public double Livre17 { get; set; }
        public int _Indice { get; internal set; }
    }
    public class RegistroInventario2 : IEquatable<RegistroInventario2>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Produto { get; set; }
        public string Descricao { get; set; }
        public string Prateleira { get; set; }
        public string Unid { get; set; }
        public double SaldoAtual { get; set; }
        public double ValorConvertido { get; set; }
        public double Inventario { get; set; }
        [DataType(DataType.Date)]
        public DateTime DiaInventario { get; set; }
        public string DiasMov { get; set; }
        public double Acerto { get; set; }
        public double Livre17 { get; set; }
        public string OperadorInclusao { get; set; }

        public bool Equals(RegistroInventario2 other)
        {

            //Check whether the compared object is null.
            if (Object.ReferenceEquals(other, null)) return false;

            //Check whether the compared object references the same data.
            if (Object.ReferenceEquals(this, other)) return true;

            //Check whether the products' properties are equal.
            return Produto.Equals(other.Produto);
        }

        // If Equals() returns true for a pair of objects
        // then GetHashCode() must return the same value for these objects.

        public override int GetHashCode()
        {
            //Get hash code for the Code field.
            int hashProductCode = Produto.GetHashCode();

            //Calculate the hash code for the product.
            return hashProductCode;
        }
    }
}
