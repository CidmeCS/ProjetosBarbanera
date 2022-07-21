using Estoque.DAO;
using System;
using System.Text;
using System.Linq;

namespace Estoque.Classes
{
    internal class BuscaPedCompras
    {
        internal static StringBuilder Start(string produto)
        {
            StringBuilder sb = new StringBuilder();
            var x = Crud.Select($"SELECT date_format(Data, '%d-%m'), date_format(Entrega, '%d-%m') , Pedido, Quantidade FROM estoque.pedidodecompra where Produto = '{produto}' and Saldo > 0 ");
            for (int i = 0; i < x.Tables[0].Rows.Count; i++)
            {
                sb.Append("Data: " + x.Tables[0].Rows[i].ItemArray[0]);
                sb.Append("; Entrega: " + x.Tables[0].Rows[i].ItemArray[1]);
                sb.Append("; Pedido: " + x.Tables[0].Rows[i].ItemArray[2]);
                sb.AppendLine("; QTD: " + x.Tables[0].Rows[i].ItemArray[3]);
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