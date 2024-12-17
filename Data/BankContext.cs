using ContaFacil.Models;
using Microsoft.EntityFrameworkCore;

namespace ContaFacil.Data
{
    public class BankContext : DbContext
    {
        public BankContext(DbContextOptions<BankContext> options) : base(options) { }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Conta> Contas { get; set; }
        public DbSet<Operacao> Operacoes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
                .HasOne(c => c.Conta)
                .WithOne(co => co.Cliente)
                .HasForeignKey<Conta>(co => co.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Operacao>()
                .HasOne(o => o.ContaOrigem)
                .WithMany(co => co.HistoricoOperacao)
                .HasForeignKey(o => o.ContaOrigemId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Operacao>()
                .HasOne(o => o.ContaDestino)
                .WithMany() 
                .HasForeignKey(o => o.ContaDestinoId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
