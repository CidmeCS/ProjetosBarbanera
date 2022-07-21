using System;
using System.Collections.Generic;
using System.Text;
using Estoque.DAO;
using Estoque.Entidade;

namespace Estoque.Views
{
    internal class ListaItensParaIventariar
    {
        internal static void Start(List<ClassParaExcell> cpe)
        {
            Crud.TruncateTable("ItensParaInventariar");

            StringBuilder values = new StringBuilder();


            int line = 0;
           
            foreach (var row in cpe)
            {
                if (row.Codigo != null)
                {
                    var p = row.Codigo;
                    var d = row.Descricao;
                    var P = row.Prateleira;
                    var s = row.SaldoKg;
                    var S = row.SaldoM;
                    values.Append("('" + p + "', '" + d + "', '" + P + "', '" + s + "', '" + S + "'), ");
                    ++line;
                }
            }
            values.Remove(values.Length - 2, 2);


            Crud.InsertUpdateDelete("INSERT INTO ItensParaInventariar (codigo, item, endereco, saldoKg, saldoM) VALUES " + values + " ");
        }
    }
}