using System;

namespace PainelContabil.Domain
{
    public class LancamentoFinanceiro
    {
        public int Id { get; set; }
        public DateTime DataLancamento { get; set; }
        public Decimal Valor { get; set; }
        public string Tipo { get; set; }
        public string Status { get; set; }
    }
}