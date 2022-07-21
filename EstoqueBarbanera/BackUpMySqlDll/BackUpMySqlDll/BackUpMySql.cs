using MySql.Data.MySqlClient;
using System;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using System.Data;
using System.Diagnostics;
using System.Threading;

namespace BackUpMysqlDll
{
    /// <summary>
    /// Realiza BackUps, Restaura o BackUp e Sincroniza na Inicialização...
    /// </summary>
    public class BackUPMySql
    {
        static string ConnStringLocalHost = "Server=192.168.0.60;Database=estoque;Uid=root;Pwd=root;charset=utf8;convertzerodatetime=true;";
        static string ConnStringServidor = "Server=192.168.0.100;Database=estoque;Uid=root;Pwd=root;charset=utf8;convertzerodatetime=true;";
        static string fileNew = "BackUpNew.sql";
        static string fileOld = "BackUpOld.sql";
        static string fileSync = "BackUpSync.sql";
        static string directoryC = @"C:\BackUPMysql\";
        static string directoryZ = @"Z:\Cid\BackUPMysql\";
        private static FileInfo size = null;
        private static bool sync = false;

        /// <summary>
        /// Realiza o BackUp do LocalHost
        /// </summary>
        public static void CriarFilesDeBackUP()
        {
            Directory.CreateDirectory(directoryC);
            Directory.CreateDirectory(directoryZ);

            using (MySqlConnection conn = new MySqlConnection(ConnStringLocalHost))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlBackup mb = new MySqlBackup(cmd))
                    {
                        cmd.Connection = conn;
                        conn.Open();
                        if (sync)
                        {
                            Debug.WriteLine($"Criando Files");
                            File.Delete(directoryC + fileSync);
                            mb.ExportToFile(directoryC + fileSync);
                            conn.Close();
                            File.Copy(directoryC + fileNew, directoryC + fileOld, true);
                            File.Copy(directoryC + fileNew, directoryZ + fileOld, true);
                            File.Copy(directoryC + fileSync, directoryC + fileNew, true);
                            File.Copy(directoryC + fileSync, directoryZ + fileNew, true);
                        }
                        Debug.WriteLine($"BackUp salvo em: \n{directoryC + fileNew} e \n{directoryZ + fileNew}");
                    }
                }
            }
        }

        /// <summary>
        /// Restaura o BackUP do LocalHost e Servidor
        /// </summary>

        private static void RestaurarBackUp(string connString, string onde)
        {
            Debug.WriteLine($"Iniciandoo o Restauro para o servidor");
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            cmd.Connection = conn;
                            conn.Open();
                            mb.ImportFromFile(directoryC + fileSync);
                            conn.Close();
                            Debug.WriteLine($"Sucesso >> BackUp restaurado OK", "Restauração de BackUp");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERRO  >>  No Restauro de BackUp >> {ex}");
            }
        }

        private static void max_allowed_packet_Set(string connString)
        {
            var valor = (UInt32)((size.Length * 1.5) / 1024 / 1024);
            string query = $"SET GLOBAL max_allowed_packet={valor}*1024*1024;";
            DataSet ds = new DataSet();
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Connection = conn;
                    conn.Open();
                    var x = cmd.ExecuteReader();
                    conn.Close();
                }
            }

        }

        private static bool max_allowed_packet_Consulta(string connString)
        {
            size = null;
            size = new FileInfo(@"C:\BackUPMysql\BackUpOld.sql");
            string query = "SHOW VARIABLES LIKE 'max_allowed_packet';";
            UInt32 maxpkglenth = 0;
            DataSet ds = new DataSet();
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Connection = conn;
                    conn.Open();
                    var x = cmd.ExecuteReader();
                    var tt = x.Read();
                    maxpkglenth = Convert.ToUInt32(x.GetValue(1).ToString());
                    conn.Close();
                }
            }

            if (maxpkglenth < size.Length)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        ///   Ao iniciar a aplicação atualizar os dados do LocalHost para o Servidor. LocalHost >> Servidor 
        /// </summary>
        public static void Sincronizar()
        {
            var b = max_allowed_packet_Consulta(ConnStringLocalHost);
            if (!b)
            {
                max_allowed_packet_Set(ConnStringLocalHost);
                max_allowed_packet_Set(ConnStringServidor);
                MessageBox.Show($"Reiniciando o APP... para aplicar Max Allowed packet");
                Application.Restart();
            }

            Debug.WriteLine("Sicronizando do LocalHost para Servidor...");
            sync = true;
            CriarFilesDeBackUP();
            RestaurarBackUp(ConnStringServidor, "ServidorDeArquivos");
            Debug.WriteLine("Sincronização feita!!");
            sync = false;
        }
    }
}
