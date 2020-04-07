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

        private readonly string _endpoint;

        public FundoAcl(IConfiguration configuration)
        {
            _endpoint = configuration.GetSection("Endpoints:Fundo").Value;
        }

        public async Task<IEnumerable<Investimento>> ObterListaInvestimentos()
        {
            var retorno = await _endpoint
                                 .AllowAnyHttpStatus()
                                 .GetAsync()
                                 .ReceiveJson<ConsultaFundo>();

            return new List<Investimento>();
        }
    }
}
