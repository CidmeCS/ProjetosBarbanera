using Estoque.DAO;
using System.Linq;
using System;
using Estoque.Entidade;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace Estoque.Classes
{
    public class InativarItensParados
    {
        static Crud c = new Crud();
        internal static DataTable Start()
        {
            return ListaDeSaldos();
        }

        private static DataTable ListaDeSaldos()
        {
            List<string> grupos = new List<string> { "10000000", "11000000", "12000000", "15000000", "16000000", "17000000", "20000000" };
            var nf = c.ListaNotasFiscaisDinamicaProduto();
            var nf2 = nf.Select(p=>p.Produto);

            var t = c.ListaDeTerceiro();
            var pc = c.ListPedidoDeCompra();
            var l1 = pc.Select(p => p.Produto).ToList();
            var t1 = t.Select(p => p.Produto).ToList();
            t1.AddRange(nf2);
            t1.AddRange(l1);
            var t2 = t1.Distinct().ToList();
            t2.Sort();
            var x = c.ListaSaldo().Where(p => grupos.Contains(p.Grupo)).ToList();
            List<Saldo> ls = new List<Saldo>();
            foreach (var item in x)
            {
                if (t2.Contains(item.Produto))
                {
                    continue;
                }
                ls.Add(item);
            }
            x.Clear();
            x.AddRange(ls);

            var u = c.ListaItensDeEstoque().Where(p => grupos.Contains(p.Grupo));
            var m = c.ListaMovimento().OrderBy(p=>p.Data);
            var y = (from z in x
                     join a in u on z.Produto equals a.Codigo
                     where (z.DiassemMovimento > 365) & (z.SaldoAtual == 0) & (z.Disponivel == 0) & (z.PedCompras == 0) &
                     (z.DeTerceiros == 0) & (z.EstqMinimo == 0) & (z.ForaEstoque == 0) & (a.ItemCadastradoEm < DateTime.Today.AddDays(-365))
                     select new NewSaldo
                     {
                         Produto = z.Produto,
                         Descricao = z.Descricao,
                         Unidade = z.Unid,
                         SaldoAtual = z.SaldoAtual,
                         DiassemMovimento = z.DiassemMovimento,
                         DataCadastro = a.ItemCadastradoEm,
                         Cadastro_Ha_Dias = DateTime.Today.Subtract(a.ItemCadastradoEm).TotalDays,
                         Movimentos = (from n in m where n.Codigo == z.Produto select n.Codigo).ToList().Count(),
                         ListaMovimentos = string.Join("\n", (from n in m where n.Codigo == z.Produto orderby n.DataInclusao select n.DataInclusao.ToString("dd/MM/yyyy")).ToList()),
                         Prateleira = z.Prateleira,
                         Grupo = z.Grupo, 
                         UltimoMovimento = (from n in m where n.Codigo == z.Produto select n.Data).LastOrDefault(),
                         DiasUltimoMovimento = DateTime.Today.Subtract((from n in m where n.Codigo == z.Produto select n.Data).LastOrDefault()).TotalDays
                         
                     }).OrderBy(p => p.Movimentos).ThenByDescending(p => p.DiasUltimoMovimento);

            DataTable dataTable = new DataTable();

            dataTable.Columns.Add(new DataColumn("Produto", typeof(String)));
            dataTable.Columns.Add(new DataColumn("Descricao", typeof(String)));
            dataTable.Columns.Add(new DataColumn("Unidade", typeof(String)));
            dataTable.Columns.Add(new DataColumn("SaldoAtual", typeof(Double)));
            dataTable.Columns.Add(new DataColumn("Prateleira", typeof(String)));
            dataTable.Columns.Add(new DataColumn("DiassemMovimento", typeof(int)));
            dataTable.Columns.Add(new DataColumn("DataCadastro", typeof(DateTime)));
            dataTable.Columns.Add(new DataColumn("Cadastro_Ha_Dias", typeof(int)));
            dataTable.Columns.Add(new DataColumn("Movimentos", typeof(int)));
            dataTable.Columns.Add(new DataColumn("ListaMovimentos", typeof(String)));
            dataTable.Columns.Add(new DataColumn("Grupo", typeof(String)));
            dataTable.Columns.Add(new DataColumn("UltimoMovimento", typeof(DateTime)));
            dataTable.Columns.Add(new DataColumn("DiasUltimoMovimento", typeof(double)));



            foreach (NewSaldo z in y)
            {
                dataTable.Rows.Add(z.Produto, z.Descricao, z.Unidade, z.SaldoAtual, z.Prateleira, z.DiassemMovimento, z.DataCadastro, z.Cadastro_Ha_Dias, z.Movimentos,
                    z.ListaMovimentos,
                    z.Grupo, z.UltimoMovimento, z.DiasUltimoMovimento);
            }
            return dataTable;
        }

        public class NewSaldo
        {
            public string Produto { get; set; }
            public string Descricao { get; set; }
            public string Unidade { get; internal set; }
            public double SaldoAtual { get; internal set; }
            public string Prateleira { get; set; }
            public double DiassemMovimento { get; set; }
            public DateTime DataCadastro { get; set; }
            public double Cadastro_Ha_Dias { get; set; }
            public int Movimentos { get; internal set; }
            public string ListaMovimentos { get; internal set; }
            public string Grupo { get; set; }
            public DateTime UltimoMovimento { get; set; }
            public double DiasUltimoMovimento { get; internal set; }
        }
    }
}