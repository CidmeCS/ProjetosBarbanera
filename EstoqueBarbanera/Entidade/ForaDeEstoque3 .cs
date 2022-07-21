using System;

namespace Estoque.Entidade
{
    public class ForaDeEstoque3
    {
        public string Produto { get;  set; }
        public string Descricao { get;  set; }
        public double SaldoQtde { get;  set; }
        public double QtdeNf { get;  set; }
        public DateTime Data { get;  set; }
        public int DocFistal { get;  set; }
        public string NomeFantasia { get;  set; }
    }
}