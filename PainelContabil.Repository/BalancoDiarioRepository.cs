using System;
using System.Linq;
using PainelContabil.Domain;
using PainelContabil.Repository;

namespace PainelContabil.Reposity
{
    public class BalancoDiarioRepository : IBalancoDiarioRepository
    {
        private readonly PainelContabilContext _context;

        public BalancoDiarioRepository(PainelContabilContext context)
        {
            _context = context;
        }
        public BalancoDia GetBalancoDiario(DateTime dia)
        {
            IQueryable<BalancoDia> query = _context.BalancosDias
                .Where(d => d.DataBalanco == dia);

            query = query.OrderByDescending(d => d.DataBalanco);

            return query.FirstOrDefault();
        }
    }
}