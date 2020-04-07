using AutoMapper;
using Brito.Sergio.Backend.Acl.Dtos;
using Brito.Sergio.Backend.Domain;
using Flurl.Http;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Brito.Sergio.Backend.Acl
{
    public class TesouroDiretoAcl : IInvestimentosAcl
    {
        private readonly IMapper _mapper;
        private readonly string _endpoint;

        public TesouroDiretoAcl(IConfiguration configuration, IMapper mapper)
        {
            _endpoint = configuration.GetSection("Endpoints:Tesouro.Direto").Value;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Investimento>> ObterListaInvestimentos()
        {
            var retorno = await _endpoint
                                 .AllowAnyHttpStatus()
                                 .GetAsync()
                                 .ReceiveJson<ConsultaTesouroDireto>();

            var investimentos = _mapper.Map<IEnumerable<Investimento>>(retorno.TDS);

            return investimentos;
        }
    }
}
