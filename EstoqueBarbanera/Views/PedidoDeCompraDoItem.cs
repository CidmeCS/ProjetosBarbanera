using Estoque.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estoque.Views
{
    public partial class PedidoDeCompraDoItem : Form
    {
        public PedidoDeCompraDoItem(DataGridViewRow row)
        {
            InitializeComponent();

            Crud crud = new Crud();
            var b = crud.ListPedidoDeCompra().Where(p => p.Produto == row.Cells[0].Value.ToString() & p.Saldo > 0).ToList();

            var lista = (

                from c in b
                orderby c.Entrega
                select (new Lista
                {
                    Produto = c.Produto,
                    Descricao = c.DescricaoAlternativa,
                    Pedido = c.Pedido,
                    DataPedio = c.Data,
                    DataEntrega = c.Entrega,
                    Fornecedor = c.Fornecedor,
                    Und = c.Unidade,
                    Quantidade = c.Quantidade,
                    QtdEntregue = c.QtdeEntregue,
                    QtdSaldo = c.Saldo,
                })).ToList();


            dataGridView1.DataSource = lista;
        }

        private class Lista
        {
            public string Produto { get; set; }
            public string Descricao { get; internal set; }
            public string Pedido { get; internal set; }
            public DateTime DataPedio { get; internal set; }
            public DateTime DataEntrega { get; internal set; }
            public string Fornecedor { get; internal set; }
            public string Und { get; internal set; }
            public double Quantidade { get; internal set; }
            public double QtdEntregue { get; internal set; }
            public double QtdSaldo { get; internal set; }
        }
    }
}
