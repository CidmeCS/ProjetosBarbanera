using Estoque.DAO;
using Estoque.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estoque.Classes
{
    public class InventarioPersonalizado
    {
        List<RegistroInventario> ri = null;
        DataGridView dgv;
        public InventarioPersonalizado(DataGridView dgv)
        {
            this.dgv = dgv;
        }

        internal List<RegistroInventario> Start(List<string> lines)
        {
            var od = ObterDados(lines);
            return od;
        }

        private List<RegistroInventario> ObterDados(List<string> lines)
        {
            Crud c = new Crud();
            var consulta = c.ListaSaldo();
            ri = new List<RegistroInventario>();
            foreach (var line in lines)
            {
                var l = line.Replace("\n", "").Replace("\t", "");
                Saldo r = new Saldo();
                r = (from i in consulta where i.Produto == l select i).FirstOrDefault();
                ri.Add(new RegistroInventario
                {
                    Produto = r.Produto,
                    Descricao = r.Descricao,
                    Prateleira = r.Prateleira,
                    Unid = r.Unid,
                    SaldoAtual = r.SaldoAtual,
                    ValorConvertido = ((r.Descricao.StartsWith("CHAPA ") | r.Descricao.StartsWith("TUBO ") | r.Descricao.StartsWith("PERFIL CU ") | r.Descricao.StartsWith("BARRA ") | r.Descricao.StartsWith("BUCHA BRONZE ") & r.Grupo == "12000000") | (r.Descricao.StartsWith("REBITE ") & r.Grupo == "16000000")) ?
                                 r.Livre17 == 0 ? 0 : Math.Round(r.SaldoAtual / Convert.ToDouble(r.Livre17), 3) :
                                 r.Livre17 == 0 ? 0 : Math.Round(r.SaldoAtual * Convert.ToDouble(r.Livre17), 3),
                    Livre17 = r.Livre17 == 0 ? 0 : Convert.ToDouble(r.Livre17),

                });
            }
            return ri;
        }
    }
}
