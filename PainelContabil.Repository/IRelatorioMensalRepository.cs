using System;
using PainelContabil.Domain;

namespace PainelContabil.Repository
{
    public interface IRelatorioMensalRepository
    {
        BalancoDia[] GetRelatorioMensal(int mes, int ano);
    }
}