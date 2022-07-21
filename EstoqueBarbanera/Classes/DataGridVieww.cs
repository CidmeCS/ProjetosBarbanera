using Estoque.DAO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Estoque
{
    internal class DataGridVieww
    {

        public static string Produto { get; private set; }
        public static string Descricao { get; private set; }
        public static string UND { get; private set; }

        public static string Kg_Metro { get; private set; }

        internal static List<string> Start(DataGridViewRow row)
        {
            List<string> lista = new List<string>();
            try
            {
                lista.Add(Produto = row.Cells[0].Value.ToString());
                lista.Add(Descricao = row.Cells[1].Value.ToString());
                lista.Add(UND = row.Cells[2].Value.ToString());
                lista.Add(Kg_Metro = Kg_metro(Produto));
            }
            catch (Exception)
            {
            }
            return lista;
        }
        private static string Kg_metro(string cod)
        {
            try
            {
                var x = Crud.Select("SELECT Livre17 FROM itensdeestoques where Codigo = '" + cod + "' ");
                return x.Tables[0].Rows[0].ItemArray[0].ToString();
            }
            catch (Exception e)
            {
                return null;

            }


        }
    }
}
