using AutoMapper;
using Brito.Sergio.Backend.Acl.Dtos;
using Brito.Sergio.Backend.Domain;
using Flurl.Http;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Brito.Sergio.Backend.Acl
{
    public class FundoAcl : IInvestimentosAcl
    {
        private readonly IMapper _mapper;
        private readonly string _endpoint;

        public FundoAcl(IConfiguration configuration, IMapper mapper)
        {
            _endpoint = configuration.GetSection("Endpoints:Fundo").Value;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Investimento>> ObterListaInvestimentos()
        {
            var retorno = await _endpoint
                                 .AllowAnyHttpStatus()
                                 .GetAsync()
                                 .ReceiveJson<ConsultaFundo>();

            var investimentos = _mapper.Map<IEnumerable<Investimento>>(retorno.Fundos);

            return investimentos;
        }
    }
}
