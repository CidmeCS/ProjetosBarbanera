using ConsultasERP.IWTpBase;
using ConsultasERP.Properties;
using ConsultasERP.IWTpIntegradoras;
using ConsultasERP.IWTpIntegrVendas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel;
using System.Threading;
using System.Diagnostics;
using ConsultasERP.Controller;
using ConsultasERP.Model;

namespace ConsultasERP.Views
{
    public partial class ConsultaERP : Form
    {

        public string tokenId = string.Empty;
        private List<object> lo;

        public ConsultaERP()
        {
            InitializeComponent();
        }

        //IWTpBase

        public void btnLogInAlt_Click(object sender, EventArgs e)
        {
            lo = LogInOut.DoLogInAlt();
            tokenId = (string)lo[0];
        }

        public void btnLogOut_Click(object sender, EventArgs e)
        {
            LogInOut.DoLogOut();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            lo = LogInOut.DoLogin();
            tokenId = (string)lo[0];
        }

        private void btnCheckSession_Click(object sender, EventArgs e)
        {
            LogInOut.CheckSession();
        }

        private void btnGetServerHealth_Click(object sender, EventArgs e)
        {
            LogInOut.GetServerHealth();
        }

        //IWTpIntegrVendas

        private void btnConsultarPV_Click(object sender, EventArgs e)
        {
            var pdt = Controller.IWTpIntegrVendas.Get<PedidosVendas>("PedidosVendas");
            List<VEPM> f = new List<VEPM>();
            foreach (var item in pdt)
            {
                f.AddRange(item);
            }
            dgvMaster.DataSource = f;
            var pvs2 = f[1].VEPD;
            dgvDetalhes.DataSource = pvs2;
        }

        private void ConsultasERP_Load(object sender, EventArgs e)
        {
        }

        private void btnConsultaProdutos_Click(object sender, EventArgs e)
        {
            var pdt = Controller.IWTpIntegrVendas.Get<Produtos>("Produtos");
            List<ESTQ> f = new List<ESTQ>();
            foreach (var item in pdt)
            {
                f.AddRange(item);
            }
            dgvMaster.DataSource = f;
        }

        private void btnNFsVendas_Click(object sender, EventArgs e)
        {
            var pdt = Controller.IWTpIntegrVendas.Get<NotasVendas>("NotasVendas");
            List<NFME> f = new List<NFME>();
            foreach (var item in pdt)
            {
                f.AddRange(item);
            }
            dgvMaster.DataSource = f;
            var nfs2 = f[0].NFDE;
            dgvDetalhes.DataSource = nfs2;
        }

        private void btnCadClientes_Click(object sender, EventArgs e)
        {
            var ret = Controller.IWTpIntegrVendas.Get<Clientes>("Clientes");
            List<CRCL> f = new List<CRCL>();
            foreach (var item in ret)
            {
                f.AddRange(item);
            }
            dgvMaster.DataSource = f;
        }

        private void btnVendedores_Click(object sender, EventArgs e)
        {
            var ret = Controller.IWTpIntegrVendas.Get<Vendedores>("Vendedores");
            List<CRVN> f = new List<CRVN>();
            foreach (var item in ret)
            {
                f.AddRange(item);
            }
            dgvMaster.DataSource = f;
        }

        private void btnVinculoProduto_Click(object sender, EventArgs e)
        {
            var ret = Controller.IWTpIntegrVendas.Get<VinculoProduto>("VinculoProduto");
            List<VECP> f = new List<VECP>();
            foreach (var item in ret)
            {
                f.AddRange(item);
            }
            dgvMaster.DataSource = f;
        }

        private void btnGetSaldoProdutosECommerce_Click(object sender, EventArgs e)
        {
            var ret = Controller.IWTpIntegrVendas.Get<Produtos>("SaldoProdutosECommerce");
            List<ESTQ> f = new List<ESTQ>();
            foreach (var item in ret)
            {
                f.AddRange(item);
            }
            dgvMaster.DataSource = f;
        }

        //IWTpIntegradoras
        private void btnInsDadosInteg_Click(object sender, EventArgs e)
        {
            Controller.IWTpIntegradoras.Get("InsDadosInteg");
        }

        private void btnGetStatusInteg_Click(object sender, EventArgs e)
        {
            Controller.IWTpIntegradoras.Get("GetStatusInteg");
        }

        private void btnGetDadosInteg_Click(object sender, EventArgs e)
        {
            Controller.IWTpIntegradoras.Get("GetDadosInteg");
        }

        private void btnGetExpPedidosVenda_Click(object sender, EventArgs e)
        {
            Controller.IWTpIntegradoras.Get("GetExpPedidosVenda");
        }
        private void btnMarcaExpPedidoVendaProc_Click(object sender, EventArgs e)
        {
            Controller.IWTpIntegradoras.Get("MarcaExpPedidoVendaProc");
        }

        private void btnGetExpProdutosECommerce_Click(object sender, EventArgs e)
        {
            Controller.IWTpIntegradoras.Get("GetExpProdutosECommerce");
        }

        private void btnMarcaExpProdutosECommerceProc_Click(object sender, EventArgs e)
        {
            Controller.IWTpIntegradoras.Get("MarcaExpProdutosECommerceProc");
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            Controller.IWTpIntegradoras.Get("Select");
        }

        private void btnSelect2_Click(object sender, EventArgs e)
        {
            Controller.IWTpIntegradoras.Get("Select2");
        }
    }
}
