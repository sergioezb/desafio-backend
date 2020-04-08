using AutoMapper;
using Brito.Sergio.Backend.Acl;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Brito.Sergio.Backend.Service
{
    public class AclListBuilder
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public AclListBuilder(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
        }

        public List<IInvestimentosAcl> Build()
        {
            return new List<IInvestimentosAcl>
            {
                new FundoAcl(_configuration, _mapper),
                new RendaFixaAcl(_configuration, _mapper),
                new TesouroDiretoAcl(_configuration, _mapper)
            };

        }
    }
}
