using Estoque.DAO;
using Estoque.Entidade;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using Estoque.Views;

namespace Estoque.Classes
{
    public class InventarioRotativo : Inventarios
    {
        public static List<Saldo> saldos { get; private set; }
        public static List<RegistroInventario> regInvt { get; private set; }

        internal static void Start(List<RegistroInventario> ir)
        {
            LancarNoExcell.Rotativo(ir);
        }

        internal static void Start(DataSet ds)
        {
            List<RegistroInventario> r = new List<RegistroInventario>();

            foreach (DataRow item in ds.Tables[0].Rows)
            {
                r.Add(new RegistroInventario
                {
                    Produto = item.ItemArray[0].ToString(),
                    Descricao = item.ItemArray[1].ToString(),
                    Prateleira = item.ItemArray[2].ToString(),
                    Unid = item.ItemArray[3].ToString(),
                    SaldoAtual = (double)item.ItemArray[4],
                    ValorConvertido = (double)item.ItemArray[5]
                });
            }

            LancarNoExcell.Rotativo(r);
        }

        public static List<RegistroInventario> ObterDados()
        {
                List<RegistroInventario> obj = new List<RegistroInventario>();
            try
            {

            Stopwatch sw = new Stopwatch();
                sw.Start();
                Crud c = new Crud();
                saldos = c.ListaSaldo();
                
                regInvt = c.ListaRegistroInventario().Where(p=>p.DiaInventario.Year == DateTime.Today.Year).ToList();
                sw.Stop();
                Console.WriteLine(sw.Elapsed);
                sw.Reset();
                sw.Restart();
                var itemm = (from s in saldos
                            

                             orderby s.Prateleira
                             where (s.Grupo == "10000000" | s.Grupo == "11000000" | s.Grupo == "12000000" | s.Grupo == "15000000" |
                             s.Grupo == "16000000" | s.Grupo == "17000000" | s.Grupo == "20000000")
                             select (new Entidade.RegistroInventario
                             {
                                 Produto = s.Produto,
                                 Descricao = s.Descricao,
                                 Prateleira = s.Prateleira,
                                 SaldoAtual = s.SaldoAtual,
                                 ValorConvertido = ((s.Descricao.StartsWith("CHAPA ") | s.Descricao.StartsWith("TUBO ") | s.Descricao.StartsWith("PERFIL CU ") | s.Descricao.StartsWith("BARRA ") | s.Descricao.StartsWith("BUCHA BRONZE ") & s.Grupo == "12000000") | (s.Descricao.StartsWith("REBITE ") & s.Grupo == "16000000")) ?
                                 Convert.ToDouble(s.Livre17 == 0 ? 0 : Convert.ToDecimal(Math.Round(s.SaldoAtual / Convert.ToDouble(s.Livre17), 3))) :
                                 Convert.ToDouble(s.Livre17 == 0 ? 0 : Convert.ToDecimal(Math.Round(s.SaldoAtual * Convert.ToDouble(s.Livre17), 3))),
                                 Unid = s.Unid,
                                 
                                 Livre17 = Math.Round((double)s.Livre17,5)
                             })).ToList();
                obj.AddRange(itemm);
                foreach (var i in itemm)
                {
                    var tira = (from t in regInvt where t.Produto == i.Produto select t.Produto).ToList().LastOrDefault();
                    if (!(tira is null))
                    {
                        obj.Remove(i);
                    }
                    
                }
               
                sw.Stop();
                Console.WriteLine(sw.Elapsed);
            
            }
            catch (System.FormatException d)
            {
                MessageBox.Show("ERRO 69B: "+ d.Message,"");
            }
            //return obj.OrderBy(p=>p.Prateleira).OrderBy(p=>p.SaldoAtual).ToList();
            return obj.OrderBy(p => p.SaldoAtual).OrderBy(p => p.Prateleira).ToList();

        }
        public List<RegistroInventario> ObterDadosZeradosSemPrateleira()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Crud c = new Crud();
            var saldos = c.ListaSaldo();
            var regInvt = c.ListaRegistroInventario().Where(p=> p.DiaInventario.Year == DateTime.Today.Year).ToList();
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
            sw.Reset();
            sw.Restart();
            var item = (from s in saldos
                        orderby s.Produto
                        where (s.Grupo == "10000000" | s.Grupo == "11000000" | s.Grupo == "12000000" | s.Grupo == "15000000" |
                        s.Grupo == "16000000" | s.Grupo == "17000000" | s.Grupo == "20000000") & (s.Prateleira == "" & s.SaldoAtual == 0)
                        select (new RegistroInventario
                        {
                            Produto = s.Produto,
                            Descricao = s.Descricao,
                            Prateleira = s.Prateleira,
                            Unid = s.Unid,
                            SaldoAtual = s.SaldoAtual,
                            ValorConvertido = 0,
                            Inventario = 0.0,
                            DiaInventario = DateTime.Today,
                            DiasMov = DateTime.Today.ToString("dd/MM/yyyy") + " - " + DateTime.Today.ToString("dd/MM/yyyy"),
                            Acerto = 0.0
                        })).ToList();
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
            sw.Reset();
            sw.Restart();
            List<RegistroInventario> obj = new List<RegistroInventario>();
            obj.AddRange(item);
            foreach (var i in item)
            {
                var tira = (from t in regInvt where t.Produto == i.Produto select t.Produto).ToList().FirstOrDefault();
                if (!(tira is null))
                {
                    obj.Remove(i);
                }
            }
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
            return obj;
        }
        internal static void AplicarZerados(DataSet ds)
        {
            List<RegistroInventario> r = new List<RegistroInventario>();
            DateTime hoje = DateTime.Today;



            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                r.Add(new RegistroInventario
                {
                    Produto = ds.Tables[0].Rows[i].ItemArray[0].ToString(),
                    Descricao = ds.Tables[0].Rows[i].ItemArray[1].ToString(),
                    Prateleira = ds.Tables[0].Rows[i].ItemArray[2].ToString(),
                    SaldoAtual = (double)ds.Tables[0].Rows[i].ItemArray[3],
                    Unid = ds.Tables[0].Rows[i].ItemArray[5].ToString(),
                    ValorConvertido = (double)ds.Tables[0].Rows[i].ItemArray[4]

                });
            }

            //LancarNoExcell.Rotativo(r);

            if (MessageBox.Show("Houve Erros: ", "ERROS", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                AtualizaInventarioRotativo.Rotativo(r, hoje, "AplicarZerados");
            }
        }
    }
}