using System;

namespace PainelContabil.Domain
{
    public class BalancoDia
    {
        public DateTime DataBalanco { get; set; }
        public Decimal ValorTotalCredito { get; set; }
        public Decimal ValorTotalDebito { get; set; }
        public Decimal Saldo { get; set; }
    }
}