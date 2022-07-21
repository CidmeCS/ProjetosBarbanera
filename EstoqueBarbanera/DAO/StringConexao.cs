

using System;
using System.Net;

namespace Estoque.DAO

{
    internal class StringConexao
    {
        public static string excel = @"C:\Exports\Inventario.xlsx";
        public static string maquina = string.Empty;
        internal static string sCon()
        {

            var nome = Environment.MachineName;
            var nomeCompleto = Dns.GetHostEntry(nome).HostName;

            if (nomeCompleto == "Estoque" | nomeCompleto == "ESTOQUE2")
            {
                //Barbanera
                maquina = nomeCompleto;
                return "Server = 192.168.0.60;Database=estoque;Uid=root;Pwd=root;default command timeout=360";
            }
            else
            {
                //Synology
                maquina = "Synology";
                return "Server = cidme.synology.me;Database=estoque;Uid=root;Pwd=Th@les1010;default command timeout=360";

            }

            //string Barbanera = "Server = 192.168.0.100;Database=estoque;Uid=root;Pwd=root;default command timeout=360";
            //string Casa = "Server = localhost;Database=estoque;Uid=root;Pwd=root;";
            //string casa = "Server = 192.168.0.19;Database=estoque;Uid=root;Pwd=root;default command timeout=360";



        }
        internal static string SC_100()
        {

            string Barbanera = "Server = 192.168.0.100;Database=estoque;Uid=root;Pwd=root;default command timeout=360";
            string Local = "Server = localhost;Database=estoque;Uid=root;Pwd=root;default command timeout=360";
            string Estoque = "Server = 192.168.0.60;Database=estoque;Uid=root;Pwd=root;default command timeout=360";


            return Barbanera;

        }

        // FAZER UMA QUERY PARA LISTAR OS ITENS SEM SALDO E COM ENDEREÇOS PREENCHIDOS

    }
}