using AutoMapper;
using Brito.Sergio.Backend.Acl.Dtos;
using Brito.Sergio.Backend.Domain;
using Flurl.Http;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Brito.Sergio.Backend.Acl
{
    public class RendaFixaAcl : IInvestimentosAcl
    {
        private readonly IMapper _mapper;
        private readonly string _endpoint;

        public RendaFixaAcl(IConfiguration configuration, IMapper mapper)
        {
            _mapper = mapper;
            _endpoint = configuration.GetSection("Endpoints:Renda.Fixa").Value;
        }

        public async Task<IEnumerable<Investimento>> ObterListaInvestimentos()
        {
            var retorno = await _endpoint
                                 .AllowAnyHttpStatus()
                                 .GetAsync()
                                 .ReceiveJson<ConsultaRendaFixa>();

            var investimentos = _mapper.Map<IEnumerable<Investimento>>(retorno.LCIS);

            return investimentos;
        }
    }
}
