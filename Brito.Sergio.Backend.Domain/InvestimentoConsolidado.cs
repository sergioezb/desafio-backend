using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brito.Sergio.Backend.Domain
{
    public class InvestimentoConsolidado
    {
        public decimal ValorTotal => Investimentos.Sum(s => s.ValorTotal);
        public ICollection<Investimento> Investimentos { get; private set; }


        public InvestimentoConsolidado()
        {
            Investimentos = new List<Investimento>();
        }

        public void AdicionarInvestimento(Investimento investimento)
        {
            Investimentos.Add(investimento);
        }

        public void CalcularValorResgate(Investimento investimento)
        {
            decimal descontoResgate = 30;

            var data03Meses = investimento.Vencimento.AddMonths(-3);
            var dataMetadeCustodia = investimento.InicioCustodia + 
                (investimento.Vencimento - investimento.InicioCustodia) / 2;

            if (DateTime.Today >= data03Meses)
                descontoResgate = 6;
            else if (DateTime.Today >= dataMetadeCustodia)
                descontoResgate = 15;

            investimento.ValorResgate = investimento.ValorTotal * (100 - descontoResgate) / 100;

        }
    }
}
