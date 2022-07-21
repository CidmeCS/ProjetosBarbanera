
using Estoque.DAO;
using Estoque.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Estoque.Views
{
    internal class PopulandoClassParaExcell
    {

        private static StringBuilder sb;
        internal static List<ClassParaExcell> Start(List<string> c, List<Saldo> s,
            List<Movimento> m, List<ForaDeEstoque> f, List<DeTerceiro> d)
        {

            List<ClassParaExcell> cpe = new List<ClassParaExcell>();
            for (int i = 0; i < c.Count; i++)
            {

                if (sb != null)
                {
                    sb.Clear();
                }

                ObterOrigem(c, m, f, i, d);


                var xp =
                    from x in s
                    where x.Produto == c[i] & (x.Grupo == "10000000" | x.Grupo == "11000000" | x.Grupo == "12000000" | x.Grupo == "15000000" | x.Grupo == "16000000" | x.Grupo == "17000000" | x.Grupo == "20000000")

                    select new
                    {
                        x.Produto,
                        x.Descricao,
                        x.Prateleira,
                        x.SaldoAtual,
                        x.Unid,



                        SaldoKg = (x.Descricao.StartsWith("BARRA ") == true | x.Descricao.StartsWith("BUCHA BRONZE") == true | x.Descricao.StartsWith("PERFIL CU ") == true |
                                  x.Descricao.StartsWith("TUBO RED ") == true | x.Descricao.StartsWith("CHAPA ") == true & x.Grupo.Equals("12000000") == true & x.Produto.Equals("B-2146")) == true ?
                                  (x.SaldoAtual / Convert.ToDouble(x.Livre17)) :
                                  (x.SaldoAtual * Convert.ToDouble(x.Livre17)),
                        Origem = sb,
                        x.Livre17,
                        x.Grupo
                    };
                var a = new ClassParaExcell();
                foreach (var z in xp)
                {
                    a.Codigo = z.Produto;
                    a.Descricao = z.Descricao;

                    if (z.Prateleira.Length > 0 & z.Livre17 > 0)
                    {
                        a.Prateleira = z.Prateleira + " C-" + z.Livre17;
                    }
                    else
                    {
                        a.Prateleira = z.Prateleira;
                    }

                    a.SaldoKg = z.SaldoAtual;
                    a.Unid = z.Unid;
                    a.SaldoM = z.SaldoKg;
                    a.Origem = z.Origem.ToString().Remove(z.Origem.Length - 2);
                    a.Grupo = z.Grupo;

                };


                cpe.Add(new ClassParaExcell()
                {
                    Codigo = a.Codigo,
                    Descricao = a.Descricao,
                    Prateleira = a.Prateleira,
                    SaldoKg = a.SaldoKg,
                    Unid = a.Unid,
                    SaldoM = a.SaldoM,
                    Inventario = "",
                    Origem = a.Origem,
                    Grupo = a.Grupo

                });

            }

            var ll = OrdenandoPorPrateleira(cpe);
            return ll;
        }

        private static List<ClassParaExcell> OrdenandoPorPrateleira(List<ClassParaExcell> cpe)
        {
            Crud c = new Crud();
            var DiasMov = (Inventarios.inicio.ToString("dd/MM/yyyy") + " - " + Inventarios.fim.ToString("dd/MM/yyyy"));

            // se precisar incluir de inventarios anteriores - ...
            //var ri = c.ListaRegistroInventario().Where(p => p.DiasMov == DiasMov) | p.DiasMov == "24/05/2021 - 20/06/2021");

            //inventario com data normal
            var ri = c.ListaRegistroInventario().Where(p => p.DiasMov == DiasMov);

            var oi = new List<ClassParaExcell>();
            foreach (var r in ri)
            {
                var rr = cpe.Where(p => p.Codigo == r.Produto).ToList();
                if (rr.Count() > 0)
                {
                    oi.Add(rr.First());
                    cpe.Remove(rr.First());
                }
            }
            var xp = new List<ClassParaExcell>();

            xp.Add(new ClassParaExcell()
            {
                Codigo = "MOV",
                Descricao = ">>>>>",
                Prateleira = ">>>>>",
                SaldoKg = 0,
                Unid = ">>>>>",
                SaldoM = 0,
                Inventario = ">>>>>",
                Origem = ">>>>>",
                Grupo = ">>>>>",
            });

            var x = from p in cpe
                    where ((p.SaldoKg > 0) | (p.SaldoKg == 0 & p.Prateleira != "")) & p.Codigo != null
                    orderby p.Prateleira.Split(new string[] { " C-" }, StringSplitOptions.None).FirstOrDefault(), p.Codigo
                    select p;
            foreach (var a in x)
            {
                xp.Add(new ClassParaExcell()
                {
                    Codigo = a.Codigo,
                    Descricao = a.Descricao,
                    Prateleira = a.Prateleira,
                    SaldoKg = a.SaldoKg,
                    Unid = a.Unid,
                    SaldoM = a.SaldoM,
                    Inventario = "",
                    Origem = a.Origem,
                    Grupo = a.Grupo
                });
            }
            foreach (var i in xp)
            {
                Console.WriteLine(i.Codigo + " " + i.Descricao + " " + i.Prateleira + " " + i.SaldoKg + " " + i.SaldoM + " " + i.Inventario + "\n" + i.Origem);
            }

            var pv = c.ListPedidoDeVenda();

            List<ClassParaExcell> PV = new List<ClassParaExcell>();
            foreach (var p in pv)
            {
                var xf = xp.Where(pd => pd.Codigo == p.Item);
                if (xf.Count() == 0)
                {
                    continue;
                }
                var hk = xf.Take(1).First();
                PV.Add(hk);
                xp.Remove(hk);
            }


            var sdx = c.ListaRegistroInventario().Where(p => p.DiasMov == DiasMov).Select(p=>p.Produto).ToList();
            
            var fe = c.ListaForaDeEstoque().Where(p=>p.SaldoQtde > 0).ToList();
            List<ClassParaExcell> FE = new List<ClassParaExcell>();
            foreach (var p in fe)
            {

                if (sdx.Contains(p.Produto))
                {
                     continue;
                }

                var xf = xp.Where(pd => pd.Codigo == p.Produto);

                if (xf.Count() == 0)
                {
                    FE.Add(new ClassParaExcell
                    {
                        Codigo = p.Produto,
                        Descricao = p.Descricao,
                        SaldoKg = p.SaldoQtde,
                        SaldoM = 0.00,
                        Origem = $"{p.NomeFantasia} {p.Data.ToString("dd-MM-yyyy")} {p.DocFiscal}",
                        Grupo = "",
                        Unid = c.ListaSaldo().Where(pp=>pp.Produto == p.Produto).FirstOrDefault().Unid
                    });
                    continue;
                }
                var hk = xf.Take(1).First();
                FE.Add(hk);
                xp.Remove(hk);
            }

            

            var _PV = PV.OrderBy(s => s.Prateleira).ThenBy(s => s.Codigo);
            var _FE = FE.OrderBy(s => s.Prateleira).ThenBy(s => s.Codigo);

            ClassParaExcell clp = new ClassParaExcell();
            if (_PV.Count() > 0)
            {
                clp.Codigo = "_PV";
                clp.Descricao = ">>>>>";
                clp.Prateleira = ">>>>>";
                clp.SaldoKg = 0;
                clp.Unid = ">>>>>";
                clp.SaldoM = 0;
                clp.Inventario = ">>>>>";
                clp.Origem = ">>>>>";
                clp.Grupo = ">>>>>";

                xp.Insert(0, clp);
                xp.InsertRange(1, _PV);
            }

            clp = new ClassParaExcell();
            if (_FE.Count() > 0)
            {
                clp.Codigo = "_FE";
                clp.Descricao = ">>>>>";
                clp.Prateleira = ">>>>>";
                clp.SaldoKg = 0;
                clp.Unid = ">>>>>";
                clp.SaldoM = 0;
                clp.Inventario = ">>>>>";
                clp.Origem = ">>>>>";
                clp.Grupo = ">>>>>";

                xp.Insert(0, clp);
                xp.InsertRange(1, _FE);
            }
            return xp;

        }

        private static void ObterOrigem(List<string> c, List<Movimento> m, List<ForaDeEstoque> f, int i, List<DeTerceiro> d)
        {
            sb = new StringBuilder();
            //movimentos
            var mv = from x in m
                     where x.Codigo == c[i]
                     select new { x.Data, x.TM, x.Documento, x.Quantidade, x.OperadorInclusao, x.HoraInclusao };
            foreach (var u in mv)
            {
                sb.AppendLine(
                    u.Data.ToString("dd-MM") + " " +
                    u.TM + " " +
                    u.Documento + " " +
                    u.Quantidade + " " +
                    u.OperadorInclusao + " " +
                    u.HoraInclusao
                    );
            }
            //fora de estoque
            var mf = from x in f
                     where x.Produto == c[i]
                     select new
                     {
                         x.Data,
                         docs = "E" + x.DocEn + "-R" + x.DocFiscal,
                         QTD = "E" + x.QtdeNf + " R" + x.QT_DEVOLV,
                         SaldoQtde = "S" + x.SaldoQtde,
                         x.NomeFantasia
                     };
            foreach (var u in mf)
            {
                sb.AppendLine(
                    u.Data.ToString("dd-MM") + " " +
                    u.docs + " " +
                    u.QTD + " " +
                    u.SaldoQtde + " " +
                    u.NomeFantasia
                    );
            }
            //de terceiro
            var md = from x in d
                     where x.Produto == c[i]
                     select new
                     {
                         x.Data,
                         docs = "E" + x.DocEn + "-R" + x.DocFiscal,
                         QTD = "E" + x.QtdeNf + " R" + x.QT_DEVOLV,
                         SaldoQtde = "S" + x.SaldoQtde,
                         x.NomeFantasia
                     };
            foreach (var u in md)
            {
                sb.AppendLine(
                    u.Data.ToString("dd-MM") + " " +
                    u.docs + " " +
                    u.QTD + " " +
                    u.SaldoQtde + " " +
                    u.NomeFantasia
                    );
            }

        }
    }
}