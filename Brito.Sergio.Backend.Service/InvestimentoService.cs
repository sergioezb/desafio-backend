using AutoMapper;
using Brito.Sergio.Backend.Acl;
using Brito.Sergio.Backend.Domain;
using Brito.Sergio.Backend.Domain.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Brito.Sergio.Backend.Service
{
    public class InvestimentoService : IInvestimentoService
    {


        private readonly List<IInvestimentosAcl> _investimentosAcls;

        public InvestimentoService(IConfiguration configuration, IMapper mapper)
        {
            _investimentosAcls = new AclListBuilder(configuration, mapper).Build();
        }

        public async Task<InvestimentoConsolidado> ObterInvestimentoConsolidado()
        {
            var consolidado = new InvestimentoConsolidado();
            foreach (var acl in _investimentosAcls)
            {
                var investimentos = await acl.ObterListaInvestimentos();
                foreach (var investimento in investimentos)
                {
                    consolidado.AdicionarInvestimento(investimento);
                }
            }
            return consolidado;
        }
    }
}
