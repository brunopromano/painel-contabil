using Microsoft.EntityFrameworkCore;
using PainelContabil.Domain;

namespace PainelContabil.Repository
{
    public class PainelContabilContext : DbContext
    {
        public PainelContabilContext(DbContextOptions<PainelContabilContext> options) : base(options) {}

        public DbSet<LancamentoFinanceiro> LancamentosFinanceiros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<LancamentoFinanceiro>()
                .Property(p => p.Valor)
                .HasColumnType("decimal(18,4)");
        }
    }
}