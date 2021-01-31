using Microsoft.EntityFrameworkCore;
using PainelContabil.Domain;

namespace PainelContabil.Repository
{
    public class PainelContabilContext : DbContext
    {
        public PainelContabilContext(DbContextOptions<PainelContabilContext> options) : base(options) {}

        public DbSet<LancamentoFinanceiro> LancamentosFinanceiros { get; set; }
    }
}