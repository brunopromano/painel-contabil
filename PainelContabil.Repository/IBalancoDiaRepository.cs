using System;
using PainelContabil.Domain;

namespace PainelContabil.Repository
{
    public interface IBalancoDiaRepository
    {
        BalancoDia[] GetRelatorioMensal(int mes, int ano);
    }
}