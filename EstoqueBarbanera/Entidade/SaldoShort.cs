using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Entidade
{
    class SaldoShort
    {
        public string Produto { get; set; }
        public string Descricao { get; set; }
        public string Unid { get; set; }
        public double SaldoAtual { get; set; }
        public string Prateleira { get; set; }
        public double Disponivel { get; set; }
        //public double Entradas { get; set; }
        //public double Saidas { get; set; }
        public double PedVendas { get; set; }
       
        //public double ProdPrevOS { get; set; }
        //public double ForaEstoque { get; set; }
        //public double DeTerceiros { get; set; }
        //public double PrevFabric { get; set; }
        //public double DiassemMovimento { get; set; }
        public string Grupo { get; set; }
        public object ForaEstoque { get; internal set; }
    }
}
