using System;
using PainelContabil.Domain;

namespace PainelContabil.Repository
{
    public interface IBalancoDiarioRepository
    {
        BalancoDia GetBalancoDiario(DateTime dia);
    }
}