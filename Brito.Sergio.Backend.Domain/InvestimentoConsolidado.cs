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
    }
}
