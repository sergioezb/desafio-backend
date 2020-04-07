using System;

namespace Brito.Sergio.Backend.Acl.Dtos
{
    public class TesouroDireto
    {
        public decimal ValorInvestido { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime Vencimento { get; set; }
        public DateTime DataDeCompra { get; set; }
        public decimal Iof { get; set; }
        public string Indice { get; set; }
        public string Tipo { get; set; }
        public string Nome { get; set; }

        public decimal Ir => (ValorTotal - ValorInvestido) * (decimal)0.10;
    }
}
