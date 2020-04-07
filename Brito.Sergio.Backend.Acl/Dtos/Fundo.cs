using System;

namespace Brito.Sergio.Backend.Acl.Dtos
{
    public class Fundo
    {
        public int CapitalInvestido { get; set; }
        public int ValorAtual { get; set; }
        public DateTime DataResgate { get; set; }
        public DateTime DataCompra { get; set; }
        public int Iof { get; set; }
        public string Nome { get; set; }
        public decimal TotalTaxas { get; set; }
        public int Quantity { get; set; }

        public decimal Ir => (ValorAtual - CapitalInvestido) * (decimal)0.15;
    }

}
