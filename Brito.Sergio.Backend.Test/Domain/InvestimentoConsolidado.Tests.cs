using Brito.Sergio.Backend.Domain;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Brito.Sergio.Backend.Test.Domain
{
    public class InvestimentoConsolidadoTests
    {
        private readonly InvestimentoConsolidado _investimentoConsolidado;

        public InvestimentoConsolidadoTests()
        {
            _investimentoConsolidado = new InvestimentoConsolidado();
        }
        [Fact]
        public void DeveRetornarValorDescontandoSeisPorCento_QuandoFaltaAteTresMeses()
        {
            var investimento = new Investimento
            {
                ValorTotal = (decimal)100.00,
                Vencimento = DateTime.Today.AddMonths(2),
                InicioCustodia = DateTime.Today.AddMonths(12),
                ValorResgate  = decimal.Zero
            };

            _investimentoConsolidado.CalcularValorResgate(investimento);

            investimento.ValorResgate.Should().Be((decimal)94);

        }

        [Fact]
        public void DeveRetornarValorDescontandoQuinzePorCento_QuandoFaltaMenosDaMetadeDoTempo()
        {
            var investimento = new Investimento
            {
                ValorTotal = (decimal)100.00,
                Vencimento = DateTime.Today.AddMonths(20),
                InicioCustodia = DateTime.Today.AddMonths(-20).AddDays(-10),
                ValorResgate = decimal.Zero
            };

            _investimentoConsolidado.CalcularValorResgate(investimento);

            investimento.ValorResgate.Should().Be((decimal)85);

        }

        [Fact]
        public void DeveRetornarValorDescontandoTrintaPorCento_ParaDemaisCasos()
        {
            var investimento = new Investimento
            {
                ValorTotal = (decimal)100.00,
                Vencimento = DateTime.Today.AddMonths(20),
                InicioCustodia = DateTime.Today.AddMonths(-15),
                ValorResgate = decimal.Zero
            };

            _investimentoConsolidado.CalcularValorResgate(investimento);

            investimento.ValorResgate.Should().Be((decimal)70);

        }
    }
}
