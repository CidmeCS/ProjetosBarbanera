using ImportExportERP.Entidade;
using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore;
using System;
using System.IO;
using System.Net;

namespace ImportExportERP.Data
{

    public class MySqlContext : DbContext
    {
        public static string maquina = string.Empty;
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
            var nome = Environment.MachineName;
            var nomeCompleto = Dns.GetHostEntry(nome).HostName;
            var nomes = $"Nome: {nome}, NomeCompleto: {nomeCompleto}\n";

            //File.AppendAllText(@"C:/Exports/Maquina.txt", nomes);

            if (nomeCompleto == "Estoque" | nomeCompleto == "ESTOQUE2")
            {
                //Barbanera
                maquina = "Estoque";
                optionsBuilder.UseMySQL("Server=192.168.0.60;Port=3306;Database=Estoque;Uid=root;Pwd=root;SSL Mode=0");
            }
            else
            {
                //Synology
                maquina = "Synology";
                optionsBuilder.UseMySQL("Server=cidme.synology.me;Port=3306;Database=estoque;Uid=root;Pwd=Th@les1010;SSL Mode=0");

            }

            //Casa
            //optionsBuilder.UseMySQL("Server=192.168.2.7;Port=3306;Database=EstoqueDB;Uid=root;Pwd=root");

            //Casa LocalHost
            //optionsBuilder.UseMySQL("Server=localhost;Port=3306;Database=Estoque;Uid=root;Pwd=root");
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
