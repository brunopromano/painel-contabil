using System;
using System.Threading.Tasks;
using PainelContabil.Domain;

namespace PainelContabil.Repository
{
    public interface IPainelContabilRepository
    {
        void Add<T>(T entity) where T: class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        // Lançamento Financeiro
        Task<LancamentoFinanceiro[]> GetAllLancamentoFinanceiro();
        Task<LancamentoFinanceiro> GetLancamentoFinanceiroById(int lancamentoId);
    }
}
