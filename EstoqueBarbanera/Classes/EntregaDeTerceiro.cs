using Estoque.DAO;
using Estoque.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estoque.Classes
{
    public class EntregaItemDeTerceiro
    {
        public  List<SaldoDeTerceiro> ListaDeTerceiro()
        {
            List<SaldoDeTerceiro> listaSDT;
            Crud c = new Crud();
            List<SaldoDeTerceiro> list = new List<SaldoDeTerceiro>();
            listaSDT = new List<SaldoDeTerceiro>();
            listaSDT.AddRange(c.ListaSaldoDeTerceiro());
            
            return listaSDT;
            
        }

        internal void Entregar(DataGridViewRow row, TextBox txtQuantidade, TextBox txtEntreguePara)
        {
            List<EntregaDeTerceiro> entrega = new List<EntregaDeTerceiro>();
            entrega.Add(new EntregaDeTerceiro
            {
                Produto = row.Cells["Produto"].Value.ToString(),
                Descricao = row.Cells["Descricao"].Value.ToString(),
                Quantidade = Convert.ToDouble(txtQuantidade.Text),
                Deposito = row.Cells["DEPOSITO"].Value.ToString(),
                EntreguePara = txtEntreguePara.Text,
                Data = DateTime.Today.ToString("dd/MM/yyyy") + " " + DateTime.Now.ToString("HH:mm")
            });

            Crud c = new Crud();
            c.AdicionarItemEntregaDeTerceiro(entrega);

        }
    }
}
