using Estoque.Classes;
using Estoque.DAO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Estoque.Classes
{
    internal class Import
    {
        /*
        internal static string DepositoDeTerceiroImport()
        {
            PadronizarColunasDados.DepositoDeTerceiro();
            return "09 I.Deposito De Terceiro";
        }

        internal static string SaldoDeTerceiroImport()
        {
            PadronizarColunasDados.SaldoDeTerceiro();
            return "08 I.EstoqueDeTerceiro";
        }
        internal static string SaldoImport()
        {
            PadronizarColunasDados.CustomSaldo();
            ExportParaExcell.Start();

            var x = PadronizarColunasDados.Saldo();
            Crud.TruncateTable("saldos");
            var k = Crud.InsertUpdateDelete("INSERT INTO saldos VALUES " + x + "");
            PadronizarColunasDados.CustomSaldo();
            return k;
        }

        internal static string PedidoCompraImport()
        {
            var valores = PadronizarColunasDados.PedidoDeCompra();
            Crud.TruncateTable("pedidodecompra");
            var k = Crud.InsertUpdateDelete($"INSERT INTO pedidodecompra VALUES {valores}");
            return k;
        }

        internal static string PedidoVendaImport()
        {
            var valores = PadronizarColunasDados.PedidoDeVenda();
            Crud.TruncateTable("pedidosdevenda");
            var k = Crud.InsertUpdateDelete($"INSERT INTO pedidosdevenda VALUES {valores}");
            return k;
        }

        internal static string MovimentoImport()
        {
            var valores = PadronizarColunasDados.Movimentos();
            var data = MovimentosObterDataDoTXT();
            DateTime dt = Convert.ToDateTime(data);
            var f = dt.ToString("yyyy-MM-dd");
            Crud.InsertUpdateDelete($"DELETE FROM movimentos WHERE Data between '{f}' and curdate()");
            var k = Crud.InsertUpdateDelete($"INSERT INTO movimentos VALUES {valores}");
            return k;
        }

        
        private static string MovimentosObterDataDoTXT()
        {
            string linha;

            using (StreamReader sr = new StreamReader(File.OpenRead(@"C:\Exports\Movimentos.txt"), Encoding.Default))
            {
                sr.ReadLine();
                linha = sr.ReadLine().Substring(0, 10);
            }
            return linha;
        }

        internal static string ForaDeEstoqueImport()
        {
            var data = ForaDeEstoqueObterDataDoTXT().Remove(7, 3);
            Crud.InsertUpdateDelete($"DELETE FROM ForaDeEstoques WHERE Data between '{data + "-01"}' and curdate()");
            var valores = PadronizarColunasDados.ForaDeEstoque();
            var k = Crud.InsertUpdateDelete($"INSERT INTO ForaDeEstoque VALUES {valores}");

            //
            var x = PadronizarColunasDados.ForaDeEstoque2();
            Crud c = new Crud();
            c.TruncateForaDeEstoque();
            int d = x.Count;
            for (int i = 0; i <= x.Count; i += 1000)
            {
                if (d < 1000)
                {
                    c.AdicionaForaDeEstoque(x.GetRange(i, d));
                }
                else
                {
                    c.AdicionaForaDeEstoque(x.GetRange(i, 1000));
                }
                if (d >= 1000)
                {
                    d -= 1000;
                }
            }
            //


            return k;
        }

        private static string ForaDeEstoqueObterDataDoTXT()
        {
            string linha;
            var p = new HashSet<DateTime>();
            var t = new List<DateTime>();
            

            using (StreamReader sr = new StreamReader(File.OpenRead(@"C:\Exports\ForaDeEstoque.txt"), Encoding.Default))
            {
                linha = sr.ReadLine();
                while ((linha = sr.ReadLine()) != null)
                {
                    var x = linha.Replace("\"", "").Split('\t');
                     p.Add(Convert.ToDateTime(x[6]));
                }

                t = p.ToList();
                t.Sort();
            }
            return t.First().ToString("yyyy-MM-dd");
        }

        internal static string DeTerceiroImport()
        {
            var data = DeTerceiroObterDataDoTXT().Remove(7, 3);
            Crud.InsertUpdateDelete($"DELETE FROM deterceiros WHERE Data between '{data + "-01"}' and curdate()");
            var valores = PadronizarColunasDados.DeTerceiro();
            var k = Crud.InsertUpdateDelete($"INSERT INTO deterceiros VALUES {valores}");

            //
            var x = PadronizarColunasDados.DeTerceiros2();
            Crud c = new Crud();
            c.TruncateDeTerceiro();
            int d = x.Count;
            for (int i = 0; i <= x.Count; i += 1000)
            {
                if (d < 1000)
                {
                    c.AdicionaDeTerceiro(x.GetRange(i, d));
                }
                else
                {
                    c.AdicionaDeTerceiro(x.GetRange(i, 1000));
                }
                if (d >= 1000)
                {
                    d -= 1000;
                }
            }
            //

            return k;
        }

        private static string DeTerceiroObterDataDoTXT()
        {
            string linha;
            var p = new HashSet<DateTime>();
            var t = new List<DateTime>();


            using (StreamReader sr = new StreamReader(File.OpenRead(@"C:\Exports\DeTerceiro.txt"), Encoding.Default))
            {
                linha = sr.ReadLine();
                while ((linha = sr.ReadLine()) != null)
                {
                    var x = linha.Replace("\"", "").Split('\t');
                    p.Add(Convert.ToDateTime(x[6]));
                }

                t = p.ToList();
                t.Sort();
            }
            return t.First().ToString("yyyy-MM-dd");
        }

        internal static StringBuilder ItensDeEstoqueImport()
        {
            var valores = PadronizarColunasDados.ItensDeEstoque();
            Crud.TruncateTable("itensdeestoques");
            StringBuilder k = new StringBuilder();
            foreach (var item in valores)
            {
                k.AppendLine(Crud.InsertUpdateDelete($"INSERT INTO itensdeestoques VALUES {item}"));
            }

            //
            var x = PadronizarColunasDados.ItensDeEstoque2();
            Crud c = new Crud();
            c.TruncateItensDeEstoque();
            int d = x.Count;
            for (int i = 0; i <= x.Count; i += 1000)
            {
                if (d < 1000)
                {
                    c.AdicionaItensDeEstoque(x.GetRange(i, d));
                }
                else
                {
                    c.AdicionaItensDeEstoque(x.GetRange(i, 1000));
                }
                if (d >= 1000)
                {
                    d -= 1000;
                }
            }
            //

            return k;
        }
        */
    }
}