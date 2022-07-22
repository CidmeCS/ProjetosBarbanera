using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using EstoqueWeb.DAO;
using EstoqueWeb.Data;
using EstoqueWeb.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EstoqueWeb.Controllers
{
    public class PedidoDeCompraController : Controller
    {
        private readonly EstoqueContext contexto;

        public PedidoDeCompraController(EstoqueContext context)
        {
            contexto = context;
        }

        public async Task<IActionResult> Index([FromForm] string selecao, string texto, string tc, string tp)
        {
            ViewResult produto = null;

            if (selecao == null)
            {
                return View();
            }
            else
            {
                produto = View("~/Views/PedidoDeCompra/Index.cshtml", await Selectx(texto, selecao).ToListAsync());

                return produto;
            }
        }

        private IQueryable<PedidoDeCompra> Selectx(string texto, string selecao)
        {
            try
            {
                var ss = contexto.PedidosDeCompra;

                var p = (from s in ss
                         where

                             selecao == "Id" ? s.Id == Convert.ToInt32(texto) :
                             selecao == "Pedido" ? s.Pedido.Contains(texto) :
                             selecao == "Data" ? s.Data.ToString().Contains(texto) :
                             selecao == "Entrega" ? s.Entrega.ToString().Contains(texto) :
                             selecao == "Produto" ? s.Produto.Contains(texto) :
                             selecao == "DescricaoAlternativa" ? s.DescricaoAlternativa.Contains(texto)
                                                          : s.Fornecedor.Contains(texto)
                         select s);

                         //select new PedidoDeCompra
                         //{
                         //    Id = s.Id,
                         //    Pedido = s.Pedido,
                         //    Data = s.Data,
                         //    Entrega = s.Entrega,
                         //    Produto = s.Produto,
                         //    DescricaoAlternativa = s.DescricaoAlternativa,
                         //    Fornecedor = s.Fornecedor

                         //});
                return p;
            }
            catch (Exception e)
            {
                Console.WriteLine("ERRO>>>>>>>>>>>>>>>>>>>>>>>>>> " + e.Message);
                return null;
            }

        }
    }
}