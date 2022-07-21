using Estoque.Entidade;
using System;
using System.Collections.Generic;
using System.Data;


namespace Estoque.Classes
{
    internal class ConverterListClassParaExcellEmTablel
    {
        internal static DataTable Start(List<ClassParaExcell> cpe)
        {
            DataTable tabela = null;
           
            
            tabela = new DataTable("Rotativo", "Rotativo");
            tabela.Columns.Add("Codigo", typeof(string));
            tabela.Columns.Add("Descricao", typeof(string));
            tabela.Columns.Add("Prateleira", typeof(string));
            tabela.Columns.Add("SaldoKg", typeof(string));
            tabela.Columns.Add("ValorConvertido", typeof(string));
            tabela.Columns.Add("Inventario", typeof(string));
            tabela.Columns.Add("Origem", typeof(string));

            foreach (var i in cpe)
            {
                if (i.Codigo != null)
                {
                    tabela.Rows.Add(i.Codigo, i.Descricao, i.Prateleira, i.SaldoKg, i.SaldoM, i.Inventario, i.Origem);
                }
                
            }

            return tabela;
        }
    }
}