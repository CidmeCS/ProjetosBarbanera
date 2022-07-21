using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Estoque
{
    internal class DataGridVieww
    {
       
        public static string Produto { get; private set; }
        public static string Kg_Metro { get; private set; }
        public static string Codigo { get; private set; }

        internal static List<string> Start(DataGridViewRow row)
        {
            List<string> lista = new List<string>();
            lista.Add(Kg_Metro = row.Cells[12].Value.ToString());
            lista.Add(Codigo = row.Cells[0].Value.ToString());
            lista.Add(Produto = row.Cells[1].Value.ToString());

            return lista;
        }
    }
}