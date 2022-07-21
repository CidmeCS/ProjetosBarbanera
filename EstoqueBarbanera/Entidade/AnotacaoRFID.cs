using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Entidade
{
    public class AnotacaoRFID
    {
        public int Id { get; internal set; }
        public string Produto { get; internal set; }
        public string Descricao { get; internal set; }
        public string SaldoAtual { get; internal set; }
        public string Prateleira { get; internal set; }
        public decimal Saida { get; internal set; }
        public decimal Entrada { get; internal set; }
        public decimal SaldoES { get; internal set; }
        public decimal ResultadoFinal { get; internal set; }
        public decimal Atualiza { get; internal set; }

    }
}
