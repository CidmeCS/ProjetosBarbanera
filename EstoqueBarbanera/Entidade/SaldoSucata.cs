namespace Estoque.Entidade
{
    class SaldoSucata
    {
        public string Codigo { get; set; }
        public string Desccricao { get; set; }
        public string Prateleira { get; set; }
        public double SaldoAtual { get; set; }
        public double Disponivel { get; set; }
        public double Inventario { get; set; }
        public double ForaEstoque { get; set; }
    }
}