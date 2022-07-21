using Estoque.DAO;
using Estoque.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Estoque.Views
{
    internal class LancarObvios
    {
        static DateTime hoje;
        internal static void Start()
        {

            hoje = DateTime.Today;

            IgnorarObvios(hoje, "SELECT Produto, Descricao, Unid, SaldoAtual, EstqMinimo, EstqMaximo, Prateleira, PedCompras, Grupo, DiassemMovimento, ForaEstoque, DeTerceiros, Disponivel, PedVendas FROM saldos where SaldoAtual = 0 and Prateleira = '' and (grupo = '10000000' OR GRUPO = '11000000' OR GRUPO = '12000000' OR GRUPO = '150000000' OR GRUPO = '16000000' OR GRUPO = '17000000' OR GRUPO = '20000000')");
            IgnorarObvios(hoje, "SELECT Produto, Descricao, Unid, SaldoAtual, EstqMinimo, EstqMaximo, Prateleira, PedCompras, Grupo, DiassemMovimento, ForaEstoque, DeTerceiros, Disponivel, PedVendas FROM saldos where SaldoAtual > 0 and Prateleira = '' and SaldoAtual = PedVendas and grupo = '10000000' ");

        }

        public static void IgnorarObvios(DateTime hoje, string query)
        {
            // eliminando obvios
            DataSet obv = new DataSet();
            //consulta
            obv = Crud.Select(query);
            //eliminando do relatorio
            HashSet<string> h = new HashSet<string>();
            for (int i = 0; i < obv.Tables[0].Rows.Count; i++)
            {
                h.Add(obv.Tables[0].Rows[i].ItemArray[0].ToString());
            }
            string hojee = hoje.ToString("yyyy-MM-dd");

            DataSet est = new DataSet();
            est = Crud.Select("select Produto from registrosinventario ");
            HashSet<string> j = new HashSet<string>();
            for (int i = 0; i < est.Tables[0].Rows.Count; i++)
            {
                j.Add(est.Tables[0].Rows[i].ItemArray[0].ToString());
            }

            HashSet<string> hs = new HashSet<string>();
            var ts = h.Except(j);
            foreach (var item in ts)
            {
                hs.Add(item);
            }
            if (hs.Count > 0)
            {
                AtualizaInventarioRotativo.Obvios(hs, hoje, "Obvios");
            }

            //
        }
    }
}