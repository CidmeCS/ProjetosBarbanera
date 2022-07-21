using ImportExportERP.Entidade;
using Microsoft.EntityFrameworkCore;

namespace ImportExportERP.Data
{

    public class SqlServerContext : DbContext
    {
        public DbSet<Saldo> Saldos { get; set; }
        public DbSet<PedidoDeCompra> PedidosDeCompra { get; set; }
        public DbSet<PedidoDeVenda> PedidosDeVenda { get; set; }
        public DbSet<Movimento> Movimentos { get; set; }
        public DbSet<ForaDeEstoque> ForaDeEstoques { get; set; }
        public DbSet<DeTerceiros> DeTerceiros { get; set; }
        public DbSet<ItensDeEstoque> ItensDeEstoques { get; set; }
        public DbSet<DepositoDeTerceiro> DepositoDeTerceiros { get; set; }
        public DbSet<SaldoDeTerceiro> SaldoDeTerceiros { get; set; }
        public DbSet<Atualizacao> Atualizacoes { get; set; }
        public DbSet<OrdensDeProducao> OrdensDeProducoes { get; set; }
        public DbSet<NotasFiscaisDinamicaProduto> NotasFiscaisDinamicaProdutos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Barbanera
            optionsBuilder.UseSqlServer("Server=192.168.0.113,1433;Database=EstoqueDB;User Id=sa;Password=sa;");

            //Casa
            //optionsBuilder.UseSqlServer("Server=192.168.2.7,1433;Database=EstoqueDB;User Id=sa;Password=sa;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Saldo>()
              .Property(e => e.Id)
              .ValueGeneratedOnAdd();

            modelBuilder.Entity<PedidoDeCompra>()
              .Property(e => e.Id)
              .ValueGeneratedOnAdd();

            modelBuilder.Entity<PedidoDeVenda>()
              .Property(e => e.Id)
              .ValueGeneratedOnAdd();

            modelBuilder.Entity<Movimento>()
              .Property(e => e.Id)
              .ValueGeneratedOnAdd();

            modelBuilder.Entity<ForaDeEstoque>()
              .Property(e => e.Id)
              .ValueGeneratedOnAdd();

            modelBuilder.Entity<DeTerceiros>()
              .Property(e => e.Id)
              .ValueGeneratedOnAdd();

            modelBuilder.Entity<ItensDeEstoque>()
              .Property(e => e.Id)
              .ValueGeneratedOnAdd();

            modelBuilder.Entity<DepositoDeTerceiro>()
              .Property(e => e.Id)
              .ValueGeneratedOnAdd();

            modelBuilder.Entity<SaldoDeTerceiro>()
              .Property(e => e.Id)
              .ValueGeneratedOnAdd();

            modelBuilder.Entity<Atualizacao>()
                 .Property(e => e.Entidade)
                 .ValueGeneratedOnAdd();

            modelBuilder.Entity<OrdensDeProducao>()
                     .Property(e => e.Id)
                     .ValueGeneratedOnAdd();

            modelBuilder.Entity<NotasFiscaisDinamicaProduto>()
                        .Property(e => e.Id)
                        .ValueGeneratedOnAdd();
        }
    }
}
