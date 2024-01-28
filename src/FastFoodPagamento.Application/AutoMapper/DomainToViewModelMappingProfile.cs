using AutoMapper;
using FastFoodPagamento.Application.ViewModels;
using FastFoodPagamento.Domain.Models;

namespace FastFoodPagamento.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile: Profile
    {
        public DomainToViewModelMappingProfile()
        {
            AllowNullCollections = true;            

            CreateMap<Pagamento, PagamentoViewModel>()
                .ForMember(c => c.Situacao,
                    map => map.MapFrom(m => m.SituacaoPagamentoNavegation));

            CreateMap<SituacaoPagamento, SituacaoPagamentoViewModel>();

        }
    }
}
