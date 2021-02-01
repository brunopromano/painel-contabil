using System.Linq;
using System.Threading.Tasks;
using PainelContabil.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace PainelContabil.Repository
{
    public class PainelContabilRepository : IPainelContabilRepository
    {
        private readonly PainelContabilContext _context;

        public PainelContabilRepository(PainelContabilContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public async Task<LancamentoFinanceiro[]> GetAllLancamentoFinanceiro()
        {
            IQueryable<LancamentoFinanceiro> query = _context.LancamentosFinanceiros;

            query = query.OrderByDescending(d => d.DataLancamento);

            return await query.ToArrayAsync();
        }

        public async Task<LancamentoFinanceiro> GetLancamentoFinanceiroById(int lancamentoId)
        {
            IQueryable<LancamentoFinanceiro> query = _context.LancamentosFinanceiros;

            query = query.Where(i => i.Id == lancamentoId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }
    }
}