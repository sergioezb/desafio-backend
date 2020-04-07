using Brito.Sergio.Backend.Acl;
using Brito.Sergio.Backend.Domain;
using Brito.Sergio.Backend.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Brito.Sergio.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvestimentoController : ControllerBase
    {
        private readonly IInvestimentoService _investimentoService;
        public InvestimentoController(IInvestimentoService investimentoService)
        {
            _investimentoService = investimentoService;
        }

       [HttpGet]
       [Produces("application/json")]
        public  async Task<ActionResult<InvestimentoConsolidado>> ObterInvestimentos()
        {
            var investimentoConsolidado =   await _investimentoService.ObterInvestimentoConsolidado();
            return Ok(investimentoConsolidado);
        }


    }
}