using Brito.Sergio.Backend.Acl.Dtos;
using Brito.Sergio.Backend.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Brito.Sergio.Backend.Acl
{
    public interface IInvestimentosAcl
    {
        Task<IEnumerable<Investimento>> ObterListaInvestimentos();
    }
}