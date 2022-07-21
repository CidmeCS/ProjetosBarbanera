using System;
using System.Text;

namespace Estoque.Entidade
{
    public class ClassParaExcell
    {
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string Prateleira { get; set; }
        public double SaldoKg { get; set; }
        public string Unid { get; set; }
        public double SaldoM { get; set; }
        public string Inventario { get; set; }
        public string Origem { get; set; }
        public string Grupo { get; set; }
        public double EstqMinimo { get; set; }
        public string Fornecedor { get; internal set; }
        public DateTime Data { get; internal set; }


        public bool Equals(ClassParaExcell other)
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
