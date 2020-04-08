using Brito.Sergio.Backend.Domain;
using Brito.Sergio.Backend.Domain.Interfaces.Services;
using Brito.Sergio.Backend.Infra;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Threading.Tasks;

namespace Brito.Sergio.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvestimentoController : ControllerBase
    {
        private readonly IInvestimentoService _investimentoService;
        private readonly IRedisCache _redisCache;
        private readonly IDistributedCache _cache;
        public InvestimentoController(IInvestimentoService investimentoService, 
                                      IRedisCache redisCache, 
                                      IDistributedCache cache)
        {
            _investimentoService = investimentoService;
            _redisCache = redisCache;
            _cache = cache;
        }

       [HttpGet]
       [Produces("application/json")]
        public  async Task<ActionResult<InvestimentoConsolidado>> ObterInvestimentos()
        {
            try
            {
                InvestimentoConsolidado investimentoConsolidado;
                var existeCache = await _redisCache.ExistObjectAsync(_cache, "consolidado");
                if (existeCache)
                {
                    investimentoConsolidado =
                        await _redisCache.GetObjectAsync<InvestimentoConsolidado>(_cache, "consolidado");
                }
                else
                {
                    investimentoConsolidado = await _investimentoService.ObterInvestimentoConsolidado();
                    TimeSpan timeout = DateTime.Today.AddDays(1) - DateTime.Now;
                    await _redisCache.SetObjectAsync(_cache, "consolidado", investimentoConsolidado, timeout);
                }

                return Ok(investimentoConsolidado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}