using System;
using System.IO;

namespace Estoque.Classes
{
    internal class Atualizacao
    {
        internal static void Set()
        {
            Stream stm = File.Open(@"C:\Exports\UltimaAtualizacao.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(stm);
            DateTime dt = DateTime.Now;
            string data = dt.ToString("dd/MM/yyyy HH:mm:ss");


            sw.Write(data);
            sw.Close();
            stm.Close();

            Get();
        }

        internal static string Get()
        {
            Stream stm = File.Open(@"C:\Exports\UltimaAtualizacao.txt", FileMode.Open);
            StreamReader sr = new StreamReader(stm);
            var lsblultimaatualizacao = "Último Export: " + sr.ReadLine();
            sr.Close();
            stm.Close();
            return lsblultimaatualizacao;
        }
    }
}