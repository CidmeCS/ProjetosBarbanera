using Estoque.DAO;
using System;
using System.Data;

namespace Estoque.Views
{
    internal class CarregarTexBox
    {
        internal static string Start(string text)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = Crud.Select($"SELECT Descricao FROM saldos where Produto = '{text}' ");
                return ds.Tables[0].Rows[0].ItemArray[0].ToString();
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
}