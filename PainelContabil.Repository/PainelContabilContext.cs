using Microsoft.EntityFrameworkCore;
using PainelContabil.Domain;

namespace PainelContabil.Repository
{
    public class PainelContabilContext : DbContext
    {
        public PainelContabilContext(DbContextOptions<PainelContabilContext> options) : base(options) {}

        public DbSet<LancamentoFinanceiro> LancamentosFinanceiros { get; set; }
        public DbSet<BalancoDia> BalancosDias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<LancamentoFinanceiro>()
                .Property(p => p.Valor)
                .HasColumnType("decimal(18,4)");

            modelBuilder.Entity<BalancoDia>()
                .HasNoKey();
            
            modelBuilder.Entity<BalancoDia>()
                .Property(p => p.ValorTotalCredito)
                .HasColumnType("decimal(18,4)");

            modelBuilder.Entity<BalancoDia>()
                .Property(p => p.ValorTotalDebito)
                .HasColumnType("decimal(18,4)");

            modelBuilder.Entity<BalancoDia>()
                .Property(p => p.Saldo)
                .HasColumnType("decimal(18,4)");
        }
    }
}