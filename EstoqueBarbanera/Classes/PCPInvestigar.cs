using Estoque.DAO;
using Estoque.Entidade;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estoque.Classes
{
    class PCPInvestigar
    {
        internal static DataSet Acabados()
        {
            //        DataSet ds = new DataSet();
            //        ds = Crud.Select("SELECT * FROM estoque.saldos where (grupo = '10000000' or Grupo = '11000000') and Prateleira = '' and SaldoAtual > 0 order by Produto asc;");

            //        if (MessageBox.Show("Deseja Imprimir?", "Imprimir", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //        {
            //            List<Saldo> sa = new List<Saldo>();
            //            foreach (DataRow item in ds.Tables[0].Rows)
            //            {
            //                sa.Add(new Saldo
            //                {
            //                    Produto = item["Produto"].ToString(),
            //                    Descricao = item["Descricao"].ToString(),
            //                    Unid = item["Unid"].ToString(),
            //                    Grupo = item["Grupo"].ToString(),
            //                    Disponivel = Convert.ToDouble(item["Disponivel"]),
            //                    SaldoAtual = Convert.ToDouble(item["SaldoAtual"]),
            //                    SaldoUltFech = Convert.ToDouble(item["SaldoUltFech"]),
            //                    Entradas = Convert.ToDouble(item["Entradas"]),
            //                    Saidas = Convert.ToDouble(item["Saidas"]),
            //                    PedCompras = Convert.ToDouble(item["PedCompras"]),
            //                    PedVendas = Convert.ToDouble(item["PedVendas"]),
            //                    ConsuPrevOs = Convert.ToDouble(item["ConsuPrevOs"]),
            //                    ForaEstoque = Convert.ToDouble(item["ForaEstoque"]),
            //                    DeTerceiros = Convert.ToDouble(item["DeTerceiros"]),
            //                    EstqMinimo = Convert.ToDouble(item["EstqMinimo"]),
            //                    EstqMaximo = Convert.ToDouble(item["EstqMaximo"]),
            //                    Prateleira = item["Prateleira"].ToString(),
            //                    PrevFabric = Convert.ToDouble(item["PrevFabric"]),
            //                    DiassemMovimento = Convert.ToDouble(item["DiasSemMovimento"])
            //                });

            //            }
            //            LancarNoExcell.PCPInvestigar(sa);
            //        }
            //        return ds;
            return null;
        }
    }
}
