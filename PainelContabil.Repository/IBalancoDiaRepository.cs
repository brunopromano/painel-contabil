using System;
using PainelContabil.Domain;

namespace PainelContabil.Repository
{
    public interface IBalancoDiaRepository
    {
        BalancoDia GetBalancoDia(DateTime dia);
    }
}