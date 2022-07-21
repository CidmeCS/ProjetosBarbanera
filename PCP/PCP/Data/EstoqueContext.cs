
using PCP.DAO;
using PCP.Entidade;
using Microsoft.EntityFrameworkCore;

namespace PCP.Data
{

    public class EstoqueContext : DbContext
    {
       
        public DbSet<Saldo> Saldos { get; set; }
        public DbSet<Atualizacao> Atualizacoes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(StringConexao.sCon());
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Saldo>()
                               .Property(e => e.Id)
                               .ValueGeneratedOnAdd();
            modelBuilder.Entity<Atualizacao>()
                                .Property(e => e.Entidade)
                                .ValueGeneratedOnAdd();
        }
    }
}
