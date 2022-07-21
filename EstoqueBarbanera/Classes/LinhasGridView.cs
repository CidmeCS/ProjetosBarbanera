using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Classes
{
    class LinhasGridView
    {
        public string Produto { get; set; }
        public string Descricao { get; set; }
        public string Unid { get; set; }
        public string SaldoAtual { get; set; }
        public string PedCompra { get; set; }
        public string PrevFabric { get; set; }
        public string EstqMinimo { get; set; }
        public string ConsuPrevOs { get; set; }
        public string EstqMaximo { get; set; }
        public string Prateleira { get; set; }
        public string Grupo { get; set; }
        public string DiasSemMov { get; set; }
        public string PEDIR { get; set; }
        public string ID { get; set; }
        public double QTD_Pedida { get; set; }
        public string OP { get; set; }
        public string DataHora { get; set; }
        public string PrazoPedidoQTD { get; set; }
        public string Andamento { get; set; }
        public string FimStattus { get; set; }
        public string NFOk { get; set; }
        public string PedirMais { get; set; }
        public string Atrazado { get; set; }
        public string Disponivel { get; set; }
        public string PedVenda { get; set; }
    }
}
