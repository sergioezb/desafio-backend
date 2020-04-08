using System.Threading.Tasks;

namespace Brito.Sergio.Backend.Domain.Interfaces.Services
{
    public interface IInvestimentoService
    {
        public Task<InvestimentoConsolidado> ObterInvestimentoConsolidado();
    }
}
