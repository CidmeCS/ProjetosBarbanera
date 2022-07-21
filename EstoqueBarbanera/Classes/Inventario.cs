using Estoque.Classes;
using Estoque.DAO;
using Estoque.Entidade;
using Estoque.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Estoque.Classes
{
    internal class Inventario
    {
        static DataSet saldo, movmt, ForaEst, DeTerc, PedVenda, itens;
        static List<Saldo> s;
        static List<Movimento> m;
        static List<ForaDeEstoque> f;
        static List<DeTerceiro> d;
        static List<PedidoDeVenda> pv;
        static List<ClassParaExcell> cpe;
        static List<ItensDeEstoque> it;

        static List<string> c = new List<string>();

        static bool obterdados = true;

        internal static void Start(DateTime inicio, DateTime fim)
        {
            Inventariar(inicio, fim);
            Efetivar(inicio, fim);
        }

        private static void Efetivar(DateTime inicio, DateTime fim)
        {
            if (MessageBox.Show("ERRO?", "HOUVE ERROS", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                LancarObvios.Start();
                //AtualizaInventarioRotativo.Atualiza(inicio, fim, cpe);
                ListaItensParaIventariar.Start(cpe);
                LancarNoExcell.InventarioMovimentos(cpe, null);
                //LancarNoExcell.AcabadosParaExpedicao();
                //LancarNoExcell.SemiAcabadosParaFornecedores();
            }
        }

        public static List<ClassParaExcell> Inventariar(DateTime inicio, DateTime fim)
        {
            cpe = new List<ClassParaExcell>();
            var i = inicio.ToString("yyyy-MM-dd");
            var ff = fim.ToString("yyyy-MM-dd");
            saldo = new DataSet(); movmt = new DataSet(); ForaEst = new DataSet(); DeTerc = new DataSet(); PedVenda = new DataSet(); itens = new DataSet();
            if (obterdados)
            {
                Crud crud = new Crud();
                s = new List<Saldo>();
                s = crud.ListaSaldo();
                m = new List<Movimento>();
                m = crud.ListaMovimento().Where(p => p.DataInclusao >= Convert.ToDateTime(i) & p.DataInclusao <= Convert.ToDateTime(ff)).ToList();
                f = new List<ForaDeEstoque>();
                f = crud.ListaForaDeEstoque().Where(p => p.SaldoQtde > 0).ToList();
                d = new List<DeTerceiro>();
                d = crud.ListaDeTerceiro().Where(p => p.SaldoQtde > 0).ToList();
                pv = new List<PedidoDeVenda>();
                pv = crud.ListPedidoDeVenda().ToList();
            }
            c = new List<string>();

            c = ObterCodigos(m, f, d, s, inicio, fim);

            c.Sort();

            cpe = PopulandoClassParaExcell.Start(c, s, m, f, d);

            return cpe;
        }

        private static List<string> ObterCodigos(List<Movimento> m, List<ForaDeEstoque> f, List<DeTerceiro> d, List<Saldo> s, DateTime inicio, DateTime fim)
        {

            //esse codigo elmina os fora de estoque que são do mes corrente e e saldo igual 
            List<ForaDeEstoque> lm = new List<ForaDeEstoque>();
            foreach (var item in f)
            {
                var sd = s.Where(p => p.Produto == item.Produto).First();
                if (sd.SaldoAtual == item.QtdeNf & item.Data >= inicio)
                {
                    lm.Add(item);
                }
            }
            foreach (var item in lm)
            {
                f.Remove(item);
            }
            //fim

            c.AddRange(from i in m select i.Codigo);
            c.AddRange(from i in f select i.Produto);
            c.AddRange(from i in d select i.Produto);

            foreach (var item in lm)
            {
                c.Remove(item.Produto);
            }

            var g = c.Distinct().ToList();

            Crud cd = new Crud();
            string diasMov = inicio.ToString("dd/MM/yyyy") + " - " + fim.ToString("dd/MM/yyyy");
            foreach (var item in lm)
            {
                var dg = cd.ListaRegistroInventario().Where(p => p.Produto == item.Produto).OrderByDescending(p => p.Id).FirstOrDefault();
                var dgDiasMov = dg == null ? "" : dg.DiasMov;

                if (dgDiasMov != diasMov)
                {
                    RegistroInventario ri = new RegistroInventario();
                    ri.Produto = item.Produto;
                    ri.Descricao = item.Descricao;
                    ri.Unid = "";
                    ri.SaldoAtual = item.QtdeNf;
                    ri.Inventario = item.QtdeNf;
                    ri.DiaInventario = DateTime.Today;
                    ri.DiasMov = diasMov;
                    ri.Acerto = 0;
                    ri.Prateleira = s.Where(p => p.Produto == item.Produto).First().Prateleira;
                    ri.ValorConvertido = 0;
                    ri.Livre17 = 0;
                    ri._Indice = 0;
                    List<RegistroInventario> ril = new List<RegistroInventario>();
                    ril.Add(ri);
                    cd.AdicionaRegistroInventario(ril);
                }
            }

            

            return g;
        }

        internal static List<object> ListarAcabados()
        {
            DataSet ds = new DataSet();
            ds = Crud.Select("SELECT Produto, Descricao, Prateleira, Unid, SaldoAtual, '' as Inventario  FROM saldos where grupo = '10000000' and Prateleira <> '' order by Prateleira asc;");

            var x = "Linhas Carregadas: " + ds.Tables[0].Rows.Count;
            if (MessageBox.Show("Deseja Imprimir?", "Imprimir", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                List<ClassParaExcell> cpe = new List<ClassParaExcell>();
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    cpe.Add(new ClassParaExcell
                    {
                        Codigo = item.ItemArray[0].ToString(),
                        Descricao = item.ItemArray[1].ToString(),
                        Prateleira = item.ItemArray[2].ToString(),
                        Unid = item.ItemArray[3].ToString(),
                        SaldoKg = Convert.ToDouble(item.ItemArray[4].ToString()),
                        Inventario = item.ItemArray[5].ToString()
                    });

                }
                LancarNoExcell.InventarioMovimentos(cpe, null);
            }
            List<object> ob = new List<object>();
            ob.Add(ds);
            ob.Add(x);
            return ob;
        }

        internal static List<object> InventariarPorGrupo(string cb, string grupo)
        {
            int pp1 = 0, pp2 = 0, pp3 = 0, outro = 0, g10 = 0, g12 = 0, g15 = 0, g16 = 0, g17 = 0, g20 = 0;
            DataSet ds = new DataSet();
            ds = Crud.Select($"SELECT " +
                $"s.Produto, " +
                $"s.Descricao, " +
                $"CONCAT(s.Prateleira, ' C-', i.livre17) AS Prat_Conv, " +
                $"CONCAT(s.Unid, ': ', s.SaldoAtual) AS Und_Saldo, " +
                    $"if(s.Descricao like 'PERFIL CU %' OR s.Descricao like 'TUBO %' OR s.Descricao like 'BARRA %' OR " +
                    $"s.Descricao like 'BUCHA BRONZE %' or s.Produto = 'B-1210', " +
                        $"round(s.SaldoAtual / (Replace(i.Livre17, ',', '.') ), 3), " +
                        $"round(s.SaldoAtual * (Replace(i.Livre17, ',', '.') ), 3))  AS Convertido, '' " +
                $"AS Inventario, " +
                $"s.Grupo " +
                $"FROM saldos AS s " +
                $"INNER JOIN itensdeestoques AS i " +
                $"ON s.produto = i.codigo " +
                $"WHERE s.grupo LIKE '%{grupo}%' AND s.Prateleira <> '' AND s.produto LIKE '{cb}%' " +
                $"ORDER BY s.Prateleira ASC , s.Produto ASC");
            if (MessageBox.Show("Deseja Imprimir?", "Imprimir", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                List<ClassParaExcell> cpe = new List<ClassParaExcell>();
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    cpe.Add(new ClassParaExcell
                    {
                        Codigo = item.ItemArray[0].ToString(),
                        Descricao = item.ItemArray[1].ToString(),
                        Prateleira = item.ItemArray[2].ToString(),
                        Unid = item.ItemArray[3].ToString(),
                        SaldoM = item.ItemArray[4].ToString().Length == 0 ? 0 : Math.Round(Convert.ToDouble(item.ItemArray[4].ToString()), 3),
                        Grupo = item.ItemArray[6].ToString()
                    });
                }
                LancarNoExcell.InventariarPorGrupo(cpe);
            }
            List<object> ob = new List<object>();
            CultureInfo culture = CultureInfo.CreateSpecificCulture("pt-BR");
            StringBuilder sb = new StringBuilder();
            string formatString =
                "G10- {0,12:G}\n" +
                "G11-\n" +
                "   PP1- {1,12:G}\n" +
                "   PP2- {2,12:G}\n" +
                "   PP3- {3,12:G}\n" +
                "   Out- {4,12:G}\n" +
                "G12- {5,12:G}\n" +
                "G15- {6,12:G}\n" +
                "G16- {7,12:G}\n" +
                "G17- {8,12:G}\n" +
                "G20- {9,12:G}\n";

            foreach (DataRow item in ds.Tables[0].Rows)
            {
                if (item.ItemArray[6].ToString() == "11000000")
                {
                    var d = item.ItemArray[0].ToString().Substring(0, 4);
                    switch (d)
                    {
                        case "PP1-": pp1++; break;
                        case "PP2-": pp2++; break;
                        case "PP3-": pp3++; break;
                        default: outro++; break;
                    }
                }
                else
                {
                    switch (item.ItemArray[6].ToString())
                    {
                        case "10000000": g10++; break;
                        case "12000000": g12++; break;
                        case "15000000": g15++; break;
                        case "16000000": g16++; break;
                        case "17000000": g17++; break;
                        case "20000000": g20++; break;
                    }
                }
            }
            sb.AppendFormat(culture, formatString, g10, pp1, pp2, pp3, outro, g12, g15, g16, g17, g20);
            ob.Add(ds);
            ob.Add(sb);
            return ob;
        }

        internal static List<object> LimparPrateleiraComSaldoZeroMinimoZero()
        {
            DataSet ds = new DataSet();
            ds = Crud.Select("select Produto, e.Descricao, Unid, Grupo, e.SaldoAtual, Prateleira, EstqMinimo, DiasSemMovimento, count(m.Data) " +
                "from saldos AS e " +
                "Left join movimentos as m " +
                "on e.Produto = m.Codigo " +
                "where e.SaldoAtual <= '0' and Prateleira <> '' and EstqMinimo = '0'  and Produto <> 'B-2197' and (" +
                "Grupo = '10000000' or Grupo = '11000000' or Grupo = '12000000' or Grupo = '15000000' or Grupo = '17000000' or Grupo = '20000000' or Grupo = '16000000' ) group by Produto order by DiasSemMovimento desc, Prateleira");

            var x = "Linhas Carregadas: " + ds.Tables[0].Rows.Count;
            if (MessageBox.Show("Deseja Imprimir?", "Imprimir", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                List<ClassParaExcell> cpe = new List<ClassParaExcell>();
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    cpe.Add(new ClassParaExcell
                    {
                        Codigo = item.ItemArray[0].ToString(),
                        Descricao = item.ItemArray[1].ToString(),
                        Prateleira = item.ItemArray[5].ToString(),
                        Unid = item.ItemArray[2].ToString(),
                        SaldoKg = Convert.ToDouble(item.ItemArray[4].ToString()),
                        Inventario = ""
                    });

                }
                LancarNoExcell.LimparPrateleiraComSaldoZeroMinimoZero(cpe);// InventarioMovimentos(cpe, null);
            }
            List<object> ob = new List<object>();
            ob.Add(ds);
            ob.Add(x);
            return ob;
        }

        internal static List<ForaDeEstoque2> InventariarForaDeEstoqueComSaldo()
        {
            Crud c = new Crud();
            var dt = c.ListaForaDeEstoque().Where(p => p.ESTAB != "1").ToList();
            List<string> ls = new List<string> { "B-1837", "B-2601", "B-2602", "B-2603", "B-2604", "B-2868" };
            foreach (var x in ls)
            {
                dt.Add(new ForaDeEstoque { Produto = x });

            }

            var ie = c.ListaItensDeEstoque();
            var f = (from d in dt
                     join i in ie
                     on d.Produto equals i.Codigo into gj
                     from l in gj.DefaultIfEmpty()

                     select new ForaDeEstoque2
                     {
                         Produto = l.Codigo,
                         Descricao = l.Descricao,
                         Prateleira = l.Prateleira,
                         Unidade = l.Unidade,
                         SaldoFisico = l.SaldoFisico,
                         ForaDeEstoque = d.SaldoQtde,
                         NomeFantasia = d.NomeFantasia == null ? "" : d.NomeFantasia,
                         DocFiscal = d.DocFiscal == null ? "" : d.DocFiscal,
                         TM = d.TM == null ? "" : d.TM,
                         Data = d.Data == null ? DateTime.MaxValue : d.Data,
                     }).OrderByDescending(p => p.ForaDeEstoque).OrderBy(p => p.Produto).ToList();

            List<ForaDeEstoque2> lfe = new List<ForaDeEstoque2>();
            string produtoVelho = "";
            foreach (var item in f)
            {
                if (produtoVelho == item.Produto)
                {
                    if (item.DocFiscal.Length > 0)
                    {
                        lfe.Add(item);
                    }
                }
                else
                {
                    produtoVelho = item.Produto;
                    lfe.Add(item);
                }

            }

            return lfe;
        }

        internal static List<ForaDeEstoque2> InventariarDeTerceiroComSaldo()
        {
            Crud c = new Crud();
            var dt = c.ListaDeTerceiro().Where(p => p.SaldoQtde > 0).ToList();
            var ie = c.ListaItensDeEstoque();

            return (from d in dt
                    join i in ie
                    on d.Produto equals i.Codigo
                    where d.ESTAB == "1"
                    orderby d.Produto, d.Data
                    select new ForaDeEstoque2
                    {
                        Produto = d.Produto,
                        Descricao = d.Descricao,
                        Prateleira = i.Prateleira,
                        Unidade = i.Unidade,
                        SaldoFisico = i.SaldoFisico,
                        ForaDeEstoque = d.SaldoQtde,
                        NomeFantasia = d.NomeFantasia,
                        DocFiscal = d.DocFiscal,
                        TM = d.TM,
                        Data = d.Data,
                    }).ToList();
        }

        public static List<SaldoSucata> InventariarSucatas()
        {
            Crud c = new Crud();
            var sd = c.ListaSaldo().Where(p => p.Produto == "B-1837" | p.Produto == "B-2601" | p.Produto == "B-2602" | p.Produto == "B-2603" | p.Produto == "B-2604" | p.Produto == "B-2868");
            return (from s in sd
                    orderby s.Produto
                    select new SaldoSucata
                    {
                        Codigo = s.Produto,
                        Desccricao = s.Descricao,
                        Prateleira = s.Prateleira,
                        SaldoAtual = s.SaldoAtual,
                        Disponivel = s.Disponivel,
                        Inventario = 0.0,
                        ForaEstoque = s.ForaEstoque
                    }).ToList();
        }

        internal List<Saldo> BuscarPorPrateleira(string valor)
        {
            Crud c = new Crud();
            var sd = c.ListaSaldo().Where(p => p.Prateleira.StartsWith(valor)).OrderBy(p=>p.Prateleira).ToList();
            return sd;
        }
    }
}