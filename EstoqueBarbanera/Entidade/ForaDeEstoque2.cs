using System;

namespace Estoque.Entidade
{
    public class ForaDeEstoque2
    {
        public string Produto { get; internal set; }
        public string Descricao { get; internal set; }
        public string Prateleira { get; internal set; }
        public string Unidade { get; internal set; }
        public double SaldoFisico { get; internal set; }
        public double ForaDeEstoque { get; internal set; }
        public string NomeFantasia { get; internal set; }
        public string DocFiscal { get; internal set; }
        public string TM { get; internal set; }
        public DateTime Data { get; internal set; }
    }
}