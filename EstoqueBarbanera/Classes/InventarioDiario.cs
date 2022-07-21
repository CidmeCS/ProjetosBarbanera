using Estoque.DAO;
using Estoque.Entidade;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estoque.Classes
{
    public class InventarioDiario
    {

        public DateTime DataInicio { get; }
        public DateTime DataFim { get; }
        public ComboBox OperadorInclusao { get; }

        private Crud c;
        private List<RegistroInventario2> lista;

        public InventarioDiario(DateTimePicker dtpInicio, DateTimePicker dtpFim, ComboBox OperadorInclusao)
        {
            this.DataInicio = dtpInicio.Value;
            this.DataFim = dtpFim.Value;
            this.OperadorInclusao = OperadorInclusao;
        }


        internal List<RegistroInventario2> Start()
        {
            string Operador1 = String.Empty;
            string Operador2 = String.Empty;
            string Operador3 = String.Empty;
            string Operador4 = String.Empty;
            string Operador5 = String.Empty;

            switch (OperadorInclusao.Text)
            {
                case "ESTOQUE": Operador1 = "CID"; Operador2 = "FERNANDO"; break;
                case "TODOS":
                    Operador1 = "CID";
                    Operador2 = "FERNANDO";
                    Operador3 = "ALESSANDRA";
                    Operador4 = "RODRIGO";
                    Operador5 = "RODRIGO B";
                    break;
                default: Operador1 = OperadorInclusao.Text; break;
            }


            c = new Crud();
            lista = new List<RegistroInventario2>();
            lista = (from m in c.ListaMovimento()
                     join s in c.ListaItensDeEstoque() on m.Codigo equals s.Codigo
                     where m.DataInclusao.Date >= DataInicio.Date & m.DataInclusao.Date <= DataFim.Date
                     where 
                        m.OperadorInclusao == Operador1 |
                        m.OperadorInclusao == Operador2 | 
                        m.OperadorInclusao == Operador3 | 
                        m.OperadorInclusao == Operador4 | 
                        m.OperadorInclusao == Operador5
                     orderby s.Prateleira

                     select new RegistroInventario2
                     {
                         Produto = s.Codigo,
                         Descricao = s.Descricao,
                         Prateleira = s.Prateleira,
                         SaldoAtual = Math.Round(s.SaldoFisico, 3),
                         Livre17 = (s.Livre17.Length == 0 ? 0d : Convert.ToDouble(s.Livre17)),
                         ValorConvertido = ((s.Descricao.StartsWith("CHAPA ") | s.Descricao.StartsWith("TUBO ") | s.Descricao.StartsWith("PERFIL CU ") | s.Descricao.StartsWith("BARRA ") | s.Descricao.StartsWith("BUCHA BRONZE ") & s.Grupo == "12000000") | (s.Descricao.StartsWith("REBITE ") & s.Grupo == "16000000")) ?
                                 s.Livre17.Length == 0 ? 0 : Math.Round(s.SaldoFisico / Convert.ToDouble(s.Livre17.Replace('.', ',')), 3) :
                                 s.Livre17.Length == 0 ? 0 : Math.Round(s.SaldoFisico * Convert.ToDouble(s.Livre17.Replace('.', ',')), 3),
                         Unid = s.Unidade,
                         OperadorInclusao =
                            m.OperadorInclusao == "RODRIGO B" ? "FATURAMENTO" :
                            m.OperadorInclusao == "RODRIGO" ? "PCP" :
                            m.OperadorInclusao == "ALESSANDRA" ? "COMPRAS" : m.OperadorInclusao
                     }
            ).ToList();

            IEnumerable<RegistroInventario2> noduplicates = lista.Distinct();

            return noduplicates.ToList();
        }
    }
}
