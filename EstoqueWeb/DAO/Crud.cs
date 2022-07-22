using EstoqueWeb.Data;
using EstoqueWeb.Models;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueWeb.DAO
{
    public class Crud
    {
        internal DataTable Select(string tabela, string coluna, string texto)
        {
            string file = File.ReadAllText("appsettings.json", Encoding.Default);
            var s = file.Remove(0, file.IndexOf("Server"));
            var stringCon = s.Substring(0, s.IndexOf("\""));


            DataSet ds = new DataSet();
            DataAdapter da;
            MySqlCommand cmd = new MySqlCommand();
            MySqlConnection Con = new MySqlConnection(stringCon);
            string commando = $"Select * from {tabela} where {coluna} like '%{texto}%' ";
            cmd = new MySqlCommand(commando, Con);
            Con.Open();
            cmd.ExecuteReader();
            Con.Close();
            da = new MySqlDataAdapter(commando, stringCon);
            ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }
    }
}
