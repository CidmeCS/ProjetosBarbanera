using ConsultasERP.IWTpIntegrVendas;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ConsultasERP.Controller
{
    class IWTpIntegrVendas
    {
        internal static List<T> Get<T>(string integradora)
        {
            string tokenId = LogInOut.DoLogInAlt()[0].ToString();
            List<T> lp = new List<T>();
            Stopwatch s = new Stopwatch();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            string xmlRet = string.Empty;

            TWRemPageable page = new TWRemPageable()
            {
                Pagina = 0,
                RegistrosPorPagina = 10
            };

            var extra = new WExtraInfo();
            var serializer = new JavaScriptSerializer();
            int status = 0;
            string Extra = "";

            do
            {
                s.Start();
                switch (integradora)
                {
                    case "Produtos":
                        TWRemFiltroProduto fp = new TWRemFiltroProduto();
                        WTpIntegrVendasClient Produto = new WTpIntegrVendasClient();
                        var sp = Produto.GetCadProdutos(tokenId, fp, ref xmlRet, page);
                        status = sp.Code;
                        Extra = sp.Extra;
                        break;
                    case "Clientes":
                        TWRemFiltroCliente fc = new TWRemFiltroCliente();
                        WTpIntegrVendasClient Clientes = new WTpIntegrVendasClient();
                        var sc = Clientes.GetCadClientes(tokenId, fc, ref xmlRet, page);
                        status = sc.Code;
                        Extra = sc.Extra;
                        break;
                    case "NotasVendas":
                        TWRemFiltroPedidoVenda fnv = new TWRemFiltroPedidoVenda();
                        WTpIntegrVendasClient NotasVendas = new WTpIntegrVendasClient();
                        var snv = NotasVendas.GetNotasVenda(tokenId, fnv, ref xmlRet, page);
                        status = snv.Code;
                        Extra = snv.Extra;
                        break;
                    case "PedidosVendas":
                        TWRemFiltroPedidoVenda fpv = new TWRemFiltroPedidoVenda();
                        WTpIntegrVendasClient PedidosVendas = new WTpIntegrVendasClient();
                        var spv = PedidosVendas.GetPedidosVenda(tokenId, fpv, ref xmlRet, page);
                        status = spv.Code;
                        Extra = spv.Extra;
                        break;
                    case "Vendedores":
                        TWRemFiltroBasico fv = new TWRemFiltroBasico();
                        WTpIntegrVendasClient Vendedores = new WTpIntegrVendasClient();
                        var sv = Vendedores.GetCadVendedores(tokenId, fv, ref xmlRet, page);
                        status = sv.Code;
                        Extra = sv.Extra;
                        break;
                    case "VinculoProduto":
                        TWRemFiltroVinculoProduto fvp = new TWRemFiltroVinculoProduto();
                        WTpIntegrVendasClient VinculoProduto = new WTpIntegrVendasClient();
                        var svp = VinculoProduto.GetVinculoProduto(tokenId, fvp, ref xmlRet, page);
                        status = svp.Code;
                        Extra = svp.Extra;
                        break;
                    case "SaldoProdutosECommerce":
                        TWRemFiltroProdutoECom Xfvp = new TWRemFiltroProdutoECom();
                        WTpIntegrVendasClient XVinculoProduto = new WTpIntegrVendasClient();
                        var Xsvp = XVinculoProduto.GetSaldoProdutosECommerce(tokenId, Xfvp, ref xmlRet, page);
                        status = Xsvp.Code;
                        Extra = Xsvp.Extra;
                        break;
                }

                // Verifica se retornou OK
                if (status == 0)
                {
                    // Processa o xml com os produtos retornado pela função
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                    byte[] byteArray = Encoding.ASCII.GetBytes(xmlRet);
                    MemoryStream ms = new MemoryStream(byteArray);
                    T x = (T)xmlSerializer.Deserialize(ms);

                    lp.Add(x);

                    if (lp.Count == 3)
                    {
                        return lp;
                        LogInOut.DoLogOut();
                    }

                    // Extrai as informações extras pra poder verificar se há mais registros:
                    extra = serializer.Deserialize<WExtraInfo>(Extra);

                    // Se tiver mais registros, configura para obter a página seguinte
                    s.Stop();
                    Debug.WriteLine($@"{page.Pagina} >> {lp.Count} >> {s.Elapsed}");
                    s.Reset();
                    if (extra.maisRegistros != 0)
                        page.Pagina++;
                }
                else
                    MessageBox.Show("Erro", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } while (status == 0 && extra.maisRegistros != 0);

            sw.Stop();
            Debug.WriteLine($@"TempoTotal {sw.Elapsed}");

            LogInOut.DoLogOut();

            return lp;
        }
    }
}
