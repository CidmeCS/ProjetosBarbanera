using ImportExportERP.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;

namespace ImportExportERP.Classes
{
    internal class Atualizacao
    {
        internal static async Task<string> Get()
        {
            using (Stream stm = File.Open(@"C:\Exports\UltimaAtualizacao.txt", FileMode.Open))
            {
                StreamReader sr = new StreamReader(stm);
                var lsblultimaatualizacao = "Último Export: " + sr.ReadLine();
                sr.Close();
                stm.Close();
                return  lsblultimaatualizacao;
            }
        }

        internal static void Set()
        {
            using (Stream stm = File.Open(@"C:\Exports\UltimaAtualizacao.txt", FileMode.Create))
            {
                StreamWriter sw = new StreamWriter(stm);
                DateTime dt = DateTime.Now;
                string data = dt.ToString("dd/MM/yyyy HH:mm:ss");


                sw.Write(data);
                sw.Close();
                stm.Close();

                Get();
            }
        }

        internal async static Task<List<Entidade.Atualizacao>> Tudo()
        {
            CRUD c = new CRUD();
            var m = c.ListAtualizacaoMySql().ToList();
            //var s = c.ListAtualizacaoSqlServer().ToList();
            //m.AddRange(s);
            List<Entidade.Atualizacao> l = new List<Entidade.Atualizacao>();
            foreach (var item in m)
            {
                l.Add(new Entidade.Atualizacao { Entidade = item.Entidade, Data = item.Data });
            }
             return l.OrderByDescending(p => p.Data).ToList();
        }
    }
}