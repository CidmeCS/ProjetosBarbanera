using Estoque.DAO;
using System;
using System.Collections.Generic;
using System.Data;

namespace Estoque.Classes
{
    public class MaterialParado
    {
        public static List<MaterialParado> mp;
       
        public string Produto { get; set; }
        public string Descricao { get; set; }
        public string Unid { get; set; }
        public double Disponivel { get; set; }
        public double SaldoAtual { get; set; }
        public string Prateleira { get; set; }
        public double PedVendas { get; set; }
        public double PrevFabric { get; set; }
        public string Pedido { get; set; }
        public DateTime DataPedido { get; set; }
        public DateTime DataEntrega { get; set; }
        public double Quantidade { get; set; }
        public string CodigoCliente { get; set; }

        internal static DataSet ProdutosAcabados()
        {
          
            var dados = Crud.Select("SELECT distinct(e.Produto), e.Descricao, e.Unid, e.SaldoAtual, e.Disponivel, e.Prateleira, e.PedVendas, e.PrevFabric, " +
                "p.Pedido, p.DataPedido, p.DataEntrega, p.Quantidade, p.CodigoCliente " +
                "FROM saldos as e " +
                "inner join pedidosdevenda as p " +
                "on e.Produto = p.Item " +
                "where  e.SaldoAtual > 0 and e.PedVendas <> e.SaldoAtual " +
                "order by p.DataPedido desc;");

            mp = new List<MaterialParado>();
            for (int i = 0; i < dados.Tables[0].Rows.Count; i++)
            {

                mp.Add(new MaterialParado {
                    Produto = dados.Tables[0].Rows[i].ItemArray[0].ToString(),
                    Descricao = dados.Tables[0].Rows[i].ItemArray[1].ToString(),
                    Unid = dados.Tables[0].Rows[i].ItemArray[2].ToString(),
                    SaldoAtual = (double)dados.Tables[0].Rows[i].ItemArray[4],
                    Disponivel = (double)dados.Tables[0].Rows[i].ItemArray[3],
                    Prateleira = dados.Tables[0].Rows[i].ItemArray[5].ToString(),
                    PedVendas = (double)dados.Tables[0].Rows[i].ItemArray[6],
                    PrevFabric = (double)dados.Tables[0].Rows[i].ItemArray[7],
                    Pedido = dados.Tables[0].Rows[i].ItemArray[8].ToString(),
                    DataPedido = (DateTime)dados.Tables[0].Rows[i].ItemArray[9],
                    DataEntrega = (DateTime)dados.Tables[0].Rows[i].ItemArray[10],
                    Quantidade = Convert.ToDouble(dados.Tables[0].Rows[i].ItemArray[11].ToString()),
                    CodigoCliente = dados.Tables[0].Rows[i].ItemArray[12].ToString()

                });
            }

            return dados;
        }

        internal static DataSet SemiAcabados()
        {
            return null; // Crud.Select("");
        }
    }
}