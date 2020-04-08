using System;
using System.Text.Json.Serialization;

namespace Brito.Sergio.Backend.Domain
{
    public class Investimento
    {
        public string Nome { get; set; }
        public decimal ValorInvestido { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime Vencimento { get; set; }

        [JsonIgnore]
        public DateTime InicioCustodia { get; set; }
        public decimal Ir { get; set; }
        public decimal ValorResgate { get; set; }
    }




}
