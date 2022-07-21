using ConsultasERP.IWTpIntegradoras;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ConsultasERP.Controller
{
    public class IWTpIntegradoras
    {
        internal static void Get(string integradora)
        {
            string tokenId = LogInOut.DoLogInAlt()[0].ToString();
            Stopwatch s = new Stopwatch();
            Stopwatch sw = new Stopwatch();
            sw.Start();

            TWRemPageable page = new TWRemPageable()
            {
                Pagina = 0,
                RegistrosPorPagina = 10
            };

            int status = 0;
            string Extra = "";
            string xmlRet = string.Empty;
            string XmlDados = string.Empty;
            WTpIntegradorasClient wic = new WTpIntegradorasClient();

            s.Start();
            switch (integradora)
            {
                case "InsDadosInteg":
                    var idi = wic.InsDadosInteg(tokenId, XmlDados);
                    status = idi.Code;
                    Extra = idi.Extra;
                    break;
                case "GetStatusInteg":
                    var gsi = wic.GetStatusInteg(tokenId, XmlDados, ref xmlRet);
                    status = gsi.Code;
                    Extra = gsi.Extra;
                    break;
                case "GetDadosInteg":
                    var gdi = wic.GetDadosInteg(tokenId, XmlDados, ref xmlRet);
                    status = gdi.Code;
                    Extra = gdi.Extra;
                    break;
                case "GetExpPedidosVenda":
                    ConsultasERP.IWTpIntegrVendas.TWRemFiltroPedidoVenda filtro = new ConsultasERP.IWTpIntegrVendas.TWRemFiltroPedidoVenda();
                    TWRemFiltroPedidoVenda filtro2 = new TWRemFiltroPedidoVenda();
                    var gepv = wic.GetExpPedidosVenda(tokenId, filtro, filtro2, ref xmlRet);
                    status = gepv.Code;
                    Extra = gepv.Extra;
                    break;
                case "MarcaExpPedidoVendaProc":
                    var mepvp = wic.MarcaExpPedidoVendaProc(tokenId, 332, 99, 328338, 1);
                    status = mepvp.Code;
                    Extra = mepvp.Extra;
                    break;
                case "GetExpProdutosECommerce":
                    var gepec = wic.GetExpProdutosECommerce(tokenId, ref xmlRet, page);
                    status = gepec.Code;
                    Extra = gepec.Extra;
                    break;
                case "MarcaExpProdutosECommerceProc":
                    var mepep = wic.MarcaExpProdutosECommerceProc(tokenId, 332, 99, 1, 1, "B-198", 1);
                    status = mepep.Code;
                    Extra = mepep.Extra;
                    break;
                case "Select":
                    var S = wic.Select(tokenId, "", ref xmlRet, page);
                    status = S.Code;
                    Extra = S.Extra;
                    break;
                case "Select2":
                    var S2 = wic.Select2(tokenId, "THALES10", "", ref xmlRet);
                    status = S2.Code;
                    Extra = S2.Extra;
                    break;
            }
            Debug.WriteLine($@"{status} >> {Extra} >> {s.Elapsed}");
            sw.Stop();
            Debug.WriteLine($@"TempoTotal {sw.Elapsed}");
            LogInOut.DoLogOut();
        }
    }
}
