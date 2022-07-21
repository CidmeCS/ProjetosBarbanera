
using Estoque.DAO;
using Estoque.Entidade;
using Microsoft.EntityFrameworkCore;

namespace Estoque.Data
{

    public class EstoqueContext : DbContext
    {
        public DbSet<RegistroInventario> RegistrosInventario { get; set; }
        public DbSet<SaldoDeTerceiro> SaldoDeTerceiros { get; set; }
        public DbSet<DepositoDeTerceiro> DepositoDeTerceiros { get; set; }
        public DbSet<ForaDeEstoque> ForaDeEstoques { get; set; }
        public DbSet<DeTerceiro> DeTerceiros { get; set; }
        public DbSet<ItensDeEstoque> ItensDeEstoques { get; set; }
        public DbSet<Saldo> Saldos { get; set; }
        public DbSet<RegistroInventarioSaldoDeTerceiro> RegistrosInventarioSaldoDeTerceiro { get; set; }
        public DbSet<Movimento> Movimentos { get; set; }
        public DbSet<EntregaDeTerceiro> EntregaDeTerceiros { get; set; }
        public DbSet<OrdensDeProducao> OrdensDeProducoes { get; set; }
        public DbSet<NotasFiscaisDinamicaProduto> NotasFiscaisDinamicaProdutos { get; set; }
        public DbSet<PedidoDeCompra> PedidosDeCompra { get; set; }
        public DbSet<PedidoDeVenda> PedidosDeVenda { get; set; }
        public DbSet<Atualizacao> Atualizacoes { get; set; }
        public DbSet<DataBackUP> DataBackUP { get; set; }
        public DbSet<AnotacaoRFID> AnotacaoRFIDs { get; set; }
        public DbSet<Etiqueta> Etiquetas { get; set; }
        public DbSet<EtiquetaMovimentos> EtiquetaMovimentos { get; set; }
        public DbSet<SaldoDivergente> SaldoDivergente { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(StringConexao.sCon());
            optionsBuilder.EnableSensitiveDataLogging(true);
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RegistroInventario>()
              .Property(e => e.Id)
              .ValueGeneratedOnAdd();
            modelBuilder.Entity<SaldoDeTerceiro>()
                 .Property(e => e.Id)
                 .ValueGeneratedOnAdd();
            modelBuilder.Entity<DepositoDeTerceiro>()
                     .Property(e => e.Id)
                     .ValueGeneratedOnAdd();
            modelBuilder.Entity<ForaDeEstoque>()
                         .Property(e => e.Id)
                         .ValueGeneratedOnAdd();
            modelBuilder.Entity<DeTerceiro>()
                         .Property(e => e.Id)
                         .ValueGeneratedOnAdd();
            modelBuilder.Entity<ItensDeEstoque>()
                            .Property(e => e.Id)
                            .ValueGeneratedOnAdd();
            modelBuilder.Entity<Saldo>()
                               .Property(e => e.Id)
                               .ValueGeneratedOnAdd();
            modelBuilder.Entity<RegistroInventarioSaldoDeTerceiro>()
                                   .Property(e => e.Id)
                                   .ValueGeneratedOnAdd();
            modelBuilder.Entity<Movimento>()
                                       .Property(e => e.Id)
                                       .ValueGeneratedOnAdd();
            modelBuilder.Entity<EntregaDeTerceiro>()
                                          .Property(e => e.Id)
                                          .ValueGeneratedOnAdd();
            modelBuilder.Entity<OrdensDeProducao>()
                    .Property(e => e.Id)
                    .ValueGeneratedOnAdd();
            modelBuilder.Entity<NotasFiscaisDinamicaProduto>()
                        .Property(e => e.Id)
                        .ValueGeneratedOnAdd();
            modelBuilder.Entity<PedidoDeCompra>()
                        .Property(e => e.Id)
                        .ValueGeneratedOnAdd();
            modelBuilder.Entity<PedidoDeVenda>()
                            .Property(e => e.Id)
                            .ValueGeneratedOnAdd();
            modelBuilder.Entity<Atualizacao>()
                                .Property(e => e.Entidade)
                                .ValueGeneratedOnAdd();
            modelBuilder.Entity<DataBackUP>()
                                    .Property(e => e.ID)
                                    .ValueGeneratedOnAdd();
            modelBuilder.Entity<AnotacaoRFID>()
                                        .Property(e => e.Id)
                                        .ValueGeneratedOnAdd();
            modelBuilder.Entity<Etiqueta>()
                                           .Property(e => e.Id)
                                           .ValueGeneratedOnAdd();
            modelBuilder.Entity<Etiqueta>()
                                              .HasIndex(e => e.Codigo)
                                              .IsUnique(true);
            modelBuilder.Entity<EtiquetaMovimentos>()
                                          .Property(e => e.Id)
                                          .ValueGeneratedOnAdd();
            modelBuilder.Entity<SaldoDivergente>()
                                              .Property(e => e.Id)
                                              .ValueGeneratedOnAdd();
        }
    }
}
