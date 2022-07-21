using Estoque.Classes.ERP;
using MySql.Data.MySqlClient;
using System;
using System.IO;
using System.Text;

namespace Estoque.Classes
{
    internal class ConverterTXTParaMysql
    {
        internal static void Start()
        {

           
                string[] d;
                StringBuilder sb = new StringBuilder();
                Stream entrada = File.Open(@"C:\Users\Estoque\Documents\Exports\ExportCustom.txt", FileMode.Open);
                StreamReader leitor = new StreamReader(entrada, Encoding.UTF8);
                string linha = null;
                leitor.ReadLine();
                while ((linha = leitor.ReadLine()) != null)
                {
                    d = linha.Replace("\"", "").Replace("'", "").Split('\t');
                    sb.Append(
                        "('" + d[0] + "', '" +
                        d[1] + "', '" + d[2] + "', '" +
                        d[3].Replace(",", ".") + "', '" +
                        d[4].Replace(",", ".") + "', '" +
                        d[5].Replace(",", ".") + "', '" +
                        d[6] + "', '" +
                        d[7].Replace(",", ".") + "', '" +
                        d[8] + "', " +
                        d[9] + ", '" +
                        d[10].Replace(",", ".") + "', '" +
                        d[11].Replace(",", ".") + "', '" +
                        d[12].Replace(",", ".") + "', '" +
                        d[13].Replace(",", ".") + "'), ")
                        ;
                }
                leitor.Close();
                entrada.Close();
                sb.Remove(sb.Length - 2, 2);
                Stream stm = File.Create(@"C:\Users\Estoque\Documents\Exports\lista.txt");
                StreamWriter swr = new StreamWriter(stm, Encoding.Default);
                swr.Write(sb);
                swr.Close();
                stm.Close();

                //

                MySqlConnection connection2 = new MySqlConnection(StringConexao.sCon());
                try
                {
                    MySqlCommand command2 = new MySqlCommand("DELETE FROM tblestoque WHERE Produto <> '' ", connection2);
                    connection2.Open();
                    command2.ExecuteNonQuery();
                    connection2.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    connection2.Close();
                }


                MySqlConnection connection = new MySqlConnection(StringConexao.sCon());
                try
                {
                    MySqlCommand command2 = new MySqlCommand("INSERT INTO tblEstoque VALUES " + sb.ToString() + " ", connection);
                    connection.Open();
                    command2.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    connection.Close();
                }
                //





            

        }
    }
}