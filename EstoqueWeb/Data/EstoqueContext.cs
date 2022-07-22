using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EstoqueWeb.Models;

namespace EstoqueWeb.Data
{
    public class EstoqueContext : DbContext
    {
        public DbSet<Saldo> Saldos { get; set; }
        public DbSet<PedidoDeCompra> PedidosDeCompra { get; set; }

        public DbSet<ItensDeEstoque> ItensDeEstoques { get; set; }

        public EstoqueContext (DbContextOptions<EstoqueContext> options)
            : base(options)
        {
        }
    }
}
