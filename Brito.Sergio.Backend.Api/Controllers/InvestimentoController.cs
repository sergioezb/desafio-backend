using Brito.Sergio.Backend.Acl;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Brito.Sergio.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvestimentoController : ControllerBase
    {
        private readonly IInvestimentosAcl _tesouroDiretoAcl; //TROCAR POR SERVIÇO COM BUILDER
        public InvestimentoController(IInvestimentosAcl tesouroDiretoAcl)
        {
            _tesouroDiretoAcl = tesouroDiretoAcl;
        }

       [HttpGet]
       [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<Domain.Investimento>>> ObterInvestimentos()
        {

            var investimentos = await _tesouroDiretoAcl.ObterListaInvestimentos();
            return Ok(investimentos);
        }


    }
}