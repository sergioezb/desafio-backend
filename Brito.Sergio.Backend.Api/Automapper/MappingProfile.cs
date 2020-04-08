using AutoMapper;
using Brito.Sergio.Backend.Acl.Dtos;
using Brito.Sergio.Backend.Domain;

namespace Brito.Sergio.Backend.Api.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TesouroDireto, Investimento>()
            .ForMember(invest => invest.InicioCustodia, m => m.MapFrom(td => td.DataDeCompra))
            ;


            CreateMap<RendaFixa, Investimento>()
                    .ForMember(invest => invest.ValorInvestido, m => m.MapFrom(rf => rf.CapitalInvestido))
                    .ForMember(invest => invest.ValorTotal, m => m.MapFrom(rf => rf.CapitalAtual))
                    .ForMember(invest => invest.InicioCustodia, m => m.MapFrom(td => td.DataOperacao))
            ;

            CreateMap<Fundo, Investimento>()
                    .ForMember(invest => invest.ValorInvestido, m => m.MapFrom(fd => fd.CapitalInvestido))
                    .ForMember(invest => invest.ValorTotal, m => m.MapFrom(fd => fd.ValorAtual))
                    .ForMember(invest => invest.Vencimento, m => m.MapFrom(fd => fd.DataResgate))
                    .ForMember(invest => invest.InicioCustodia, m => m.MapFrom(fd => fd.DataCompra))
            ;
        }
    }
}
