using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PainelContabil.Domain;

namespace PainelContabil.Repository
{
    public class BalancoDiaRepository : IBalancoDiaRepository
    {
        private readonly PainelContabilContext _context;

        public BalancoDiaRepository(PainelContabilContext context)
        {
            _context = context;
        }

        public BalancoDia GetBalancoDia(DateTime dia)
        {
            IQueryable<BalancoDia> query = _context.BalancosDias
                .Where(d => d.DataBalanco == dia);

            query = query.OrderByDescending(d => d.DataBalanco);
            
            return query.FirstOrDefault();
        }
    }
}