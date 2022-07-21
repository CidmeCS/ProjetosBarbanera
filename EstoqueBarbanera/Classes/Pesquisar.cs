using Estoque.DAO;
using Estoque.Entidade;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Estoque
{
    internal class Pesquisar
    {
        internal static DataSet Start(string cbPesquisar, string txtPesquisar)
        {
            string cbPesq = txtPesquisar;
            cbPesq = ("%" + cbPesq + "%");
            return Crud.Select("SELECT e.Produto, e.Descricao, e.Unid,  e.SaldoAtual, e.PedCompras, e.PrevFabric, e.EstqMinimo, e.ConsuPrevOs, e.EstqMaximo, e.Prateleira, " +
                 "e.PedVendas, e.Grupo, e.DiasSemMovimento, " +
                 "if(e.Descricao like 'PERFIL CU %' OR e.Descricao like 'TUBO %' OR e.Descricao like 'BARRA %' OR e.Descricao like 'BUCHA BRONZE %' or e.Produto = 'B-1210' or e.Produto = 'B-2146', " +
                 "round(e.SaldoAtual / (Replace(e.Livre17, ',', '.') ), 3), " +
                 "round(e.SaldoAtual * (Replace(e.Livre17, ',', '.') ), 3)) as UndConvtd, " +
                 "e.ForaEstoque, e.DeTerceiros, e.Livre17 " +
                 //", i.DiaInventario " +
                 "FROM Saldos as e " +
                 //"left join itensdeestoques as e on e.Produto = it.Codigo " +
                 //"left join registrosinventario as i on  e.produto = i.Produto " +
                 "where e." + cbPesquisar + " LIKE '" + cbPesq + "' ORDER BY e.Descricao ASC");
        }

        internal static DataSet Start2(string cbPesquisar, string txtPesquisar)
        {
            string cbPesq = txtPesquisar;
            cbPesq = ("%" + cbPesq + "%");
            return Crud.Select("SELECT e.Produto, e.Descricao, e.Unid,  e.SaldoAtual, e.PedCompras, e.PrevFabric, e.EstqMinimo, e.ConsuPrevOs, e.EstqMaximo, e.Prateleira, " +
                 "e.PedVendas, e.Grupo, e.DiasSemMovimento, " +
                 "if(e.Descricao like 'PERFIL CU %' OR e.Descricao like 'TUBO %' OR e.Descricao like 'BARRA %' OR e.Descricao like 'BUCHA BRONZE %' or e.Produto = 'B-1210' or e.Produto = 'B-2146', " +
                 "round(e.SaldoAtual / (Replace(e.Livre17, ',', '.') ), 2), " +
                 "round(e.SaldoAtual * (Replace(e.Livre17, ',', '.') ), 2)) as UndConvtd, " +
                 "e.ForaEstoque, e.DeTerceiros, e.Livre17 " +
                 //", i.DiaInventario " +
                 "FROM Saldos as e " +
                 //"left join itensdeestoques as e on e.Produto = it.Codigo " +
                 //"left join registrosinventario as i on  e.produto = i.Produto " +
                 "where e." + cbPesquisar + " LIKE '" + cbPesq + "' ORDER BY e.Descricao ASC");
        }

        public static List<Saldo3> SequenciaCodigo()
        {
            Crud c = new Crud();
            var lista = c.ListaSaldo().Where(p=>p.Produto.StartsWith("B-") & p.Produto.Length == 6).OrderByDescending(p=>p.Produto).Take(30).ToList();
            List<Saldo3> s3 = new List<Saldo3>();
            foreach (var item in lista)
            {
                s3.Add(new Saldo3 {
                    Produto = item.Produto,
                    Descricao = item.Descricao,
                });
            }
            return s3;
        }

        public class Saldo3
        {
            public string Produto { get; internal set; }
            public string Descricao { get; internal set; }
        }
    }
}