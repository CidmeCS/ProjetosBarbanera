using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstoqueWeb.Data;
using EstoqueWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace EstoqueWeb.Controllers
{
    public class SaldoController : Controller
    {
        private readonly EstoqueContext contexto;

        public SaldoController(EstoqueContext context)
        {
            contexto = context;
        }

        public async Task<IActionResult> Index([FromForm] string selecao, string texto)
        {
            ViewResult produto = null;

            if (selecao == null)
            {
                return View();
            }
            else
            {
                produto = View("~/Views/Saldo/Index.cshtml", await Selectx(texto, selecao).ToListAsync()); 
                //switch (selecao)
                //{
                //    case "Id": produto = View("~/Views/Saldo/Index.cshtml", await contexto.Saldos.Where(p => p.Id.Equals(Convert.ToInt32(texto))).ToListAsync()); break;
                //    case "Produto": produto = View("~/Views/Saldo/Index.cshtml", await contexto.Saldos.Where(p => p.Produto.Contains(texto)).ToListAsync()); break;
                //    case "Descricao": produto = View("~/Views/Saldo/Index.cshtml", await Selectx(texto, selecao).ToListAsync()); break;
                //}
                return produto;
            }
        }

        private IQueryable<Saldo> Selectx(string texto, string selecao)
        {
            try
            {
                var ss = contexto.Saldos;
                var ii = contexto.ItensDeEstoques;
                var pp = ii.Where(p => p.Livre17.Equals("60")).ToList();

                var p = (from s in ss
                         join i in ii
                         on s.Produto equals i.Codigo
                         where 
                                
                             selecao == "Descricao" ? s.Descricao.Contains(texto) : 
                             selecao == "Produto" ? s.Produto.Contains(texto) :
                             selecao == "Prateleira" ? s.Prateleira.Contains(texto) : s.Grupo.Contains(texto) 

                         select new Saldo
                         {
                             Produto = s.Produto,
                             Descricao = s.Descricao,
                             Unid = s.Unid,
                             SaldoAtual = s.SaldoAtual,
                             PedCompras = s.PedCompras,
                             PrevFabric = s.PrevFabric,
                             EstqMinimo = s.EstqMinimo,
                             ConsuPrevOs = s.ConsuPrevOs,
                             EstqMaximo = s.EstqMaximo,
                             Prateleira = s.Prateleira,
                             PedVendas = s.PedVendas,
                             Grupo = s.Grupo,
                             DiassemMovimento = s.DiassemMovimento,

                             AguardandoCQ =
                             (s.Descricao.StartsWith("PERFIL CU ") ||
                             s.Descricao.StartsWith("TUBO ") ||
                             s.Descricao.StartsWith("BARRA ") ||
                             s.Descricao.StartsWith("BUCHA BRONZE ") || 
                             s.Produto == "B-1210") ?
                                 (i.Livre17.Length > 0 ? Math.Round(s.SaldoAtual / Convert.ToDouble(i.Livre17.Replace(",", ".")),3) : 0) :
                                 (i.Livre17.Length > 0 ? Math.Round(s.SaldoAtual * Convert.ToDouble(i.Livre17.Replace(",", ".")),3) : 0),

                             ForaEstoque = s.ForaEstoque,
                             DeTerceiros = s.DeTerceiros

                         });
                return p;
            }
            catch (Exception e)
            {
                Console.WriteLine("ERRO>>>>>>>>>>>>>>>>>>>>>>>>>> "+e.Message);
                return null;
            }
        }
        public IActionResult IExplorer()
        {
            ViewData["Message"] = "Your application description page.";

            return View();// ("It worked!", "You were able to view the about page, congrats!");

        }

    }

}