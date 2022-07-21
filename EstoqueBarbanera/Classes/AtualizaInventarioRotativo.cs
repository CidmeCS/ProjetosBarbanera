using System;
using System.Collections.Generic;
using System.Data;
using Estoque.DAO;
using Estoque.Entidade;

namespace Estoque.Classes
{
    internal class AtualizaInventarioRotativo
    {
        internal static void Atualiza(DateTime inicio, DateTime fim, List<ClassParaExcell> cpe)
        {
            foreach (var item in cpe)
            {

                DataSet ds = new DataSet();
                ds = Crud.Select($"SELECT Produto FROM registrosinventario WHERE Produto = '{item.Codigo}' ");
                string disMov = inicio.ToShortDateString() + " - " + fim.ToShortDateString();
                DateTime hoje = DateTime.Today;
                string hj = hoje.ToString("yyyy-MM-dd");

                var x = new
                {
                    Produto = ds.Tables[0].Rows[0].ItemArray[0].ToString(),
                    Descricao = ds.Tables[0].Rows[0].ItemArray[1].ToString(),
                    Unid = ds.Tables[0].Rows[0].ItemArray[2].ToString(),
                    Saldo = ds.Tables[0].Rows[0].ItemArray[3]
                };

                Crud.InsertUpdateDelete($"INSERT INTO registrosinventario(Produto, Descricao, Unid, SaldoAtual, Inventario, DiaInventario, DiasMov, Acerto) " +
                    $"Values ('{x.Produto}', '{x.Descricao}', '{x.Unid}', '{x.Saldo}', '0', '{hoje.ToString("yyyy-MM-dd")}', 'Obvios', '0' )");
                
                
                //if (ds.Tables[0].Rows.Count == 0)//
                //{
                //    Crud.InsertUpdateDelete($"INSERT INTO registrosinventario (Codigo, Dia, DiasMov) VALUES ('{item.Codigo}', '{hj}', '" + disMov + "')");
                //}
                //else
                //{
                //    Crud.InsertUpdateDelete($"UPDATE registrosinventario SET Dia = '{hj}', DiasMov = '" + disMov + "' WHERE Codigo = '" + item.Codigo + "' ");
                //}

            }
        }

        internal static void Obvios(HashSet<string> hs, DateTime hoje, string v)
        {
            foreach (var item in hs)
            {

                DataSet ds = new DataSet();
                ds = Crud.Select($"SELECT Produto, Descricao, Unid, SaldoAtual FROM saldos WHERE Produto = '{item}' ");

                var x = new {
                    Produto = ds.Tables[0].Rows[0].ItemArray[0].ToString(),
                    Descricao = ds.Tables[0].Rows[0].ItemArray[1].ToString(),
                    Unid = ds.Tables[0].Rows[0].ItemArray[2].ToString(),
                    Saldo = ds.Tables[0].Rows[0].ItemArray[3]
                };

                Crud.InsertUpdateDelete($"INSERT INTO registrosinventario (Produto, Descricao, Unid, SaldoAtual, Inventario, DiaInventario, DiasMov, Acerto) " +
                    $"Values ('{x.Produto}', '{x.Descricao}', '{x.Unid}', '{x.Saldo}', '0', '{hoje.ToString("yyyy-MM-dd")}', 'Obvios', '0' )");

                //DataSet ds = new DataSet();
                //ds = Crud.Select($"SELECT Codigo FROM registrosinventario WHERE Codigo = '{item}' ");


                //if (ds.Tables[0].Rows.Count == 0)//
                //{
                //  Crud.InsertUpdateDelete($"INSERT INTO registrosinventario (Codigo, Dia, DiasMov) VALUES ( '{item}', '{hoje.ToString("yyyy-MM-dd")}', '" + v + "' ) ");
                //}
                //else
                //{
                //    Crud.InsertUpdateDelete($"UPDATE registrosinventario SET Dia = '{hoje.ToString("yyyy-MM-dd")}', DiasMov = '" + v + "' WHERE Codigo = '" + item + "' ");
                //}

            }
        }

        internal static void Rotativo(List<RegistroInventario> r, DateTime hoje, string v)
        {
            foreach (var item in r)
            {
                
                Crud.InsertUpdateDelete($"INSERT INTO registrosinventario (Produto, Descricao, Unid, SaldoAtual, Inventario, DiaInventario, DiasMov, Acerto) " +
                    $"Values ('{item.Produto}', '{item.Descricao}', '{item.Unid}', '{item.SaldoAtual}', '0', '{hoje.ToString("yyyy-MM-dd")}', '{v}', '0' )");


                //DataSet ds = new DataSet();
                //ds = Crud.Select($"SELECT Codigo FROM registrosinventario WHERE Codigo = '{item.Codigo}' ");


                //if (ds.Tables[0].Rows.Count == 0)//
                //{
                //    Crud.InsertUpdateDelete($"INSERT INTO registrosinventario (Codigo, Dia, DiasMov) VALUES ( '{item.Codigo}', '{hoje.ToString("yyyy-MM-dd")}', '" + v + "' ) ");
                //}
                //else
                //{
                //    Crud.InsertUpdateDelete($"UPDATE registrosinventario SET Dia = '{hoje.ToString("yyyy-MM-dd")}', DiasMov = '" + v + "' WHERE Codigo = '" + item.Codigo + "' ");
                //}

            }
        }
    }
}