using Estoque.DAO;
using System;
using System.Text;

namespace Estoque.Classes3
{
    internal class BuscarRequisicaoCompra
    {
        internal static StringBuilder Start(string produto)
        {
            StringBuilder sb = new StringBuilder();
            var x = Crud.Select($"SELECT ID, QTD, DataHora FROM estoque.solicitacao WHERE Produto = '{produto}' and FimStatus = 'AGUARD' ORDER BY ID ASC");
            for (int i = 0; i < x.Tables[0].Rows.Count - 1 ; i++)
            {
                sb.Append("ID: E-" + x.Tables[0].Rows[i].ItemArray[0]);
                sb.Append("; QTD: " + x.Tables[0].Rows[i].ItemArray[1]);
                sb.Append("; DATA: " + Convert.ToDateTime(x.Tables[0].Rows[i].ItemArray[2]).ToString("dd-MM") + " \n");
                
            }
            try
            {
                return sb.Remove(sb.Length - 2, 2);
            }
            catch (ArgumentOutOfRangeException)
            {
                sb.Append("");
                return sb;
            }
        }
    }
}