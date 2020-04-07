using System;

namespace Brito.Sergio.Backend.Acl.Dtos
{
    public class Fundo
    {
        public decimal CapitalInvestido { get; set; }
        public decimal ValorAtual { get; set; }
        public DateTime DataResgate { get; set; }
        public DateTime DataCompra { get; set; }
        public decimal Iof { get; set; }
        public string Nome { get; set; }
        public decimal TotalTaxas { get; set; }
        public decimal Quantity { get; set; }

        public decimal Ir => (ValorAtual - CapitalInvestido) * (decimal)0.15;
    }

}
