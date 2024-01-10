using System.Data;
using AutoMapper;
using FastFoodFIAP.Application.InputModels;
using FastFoodFIAP.Application.ViewModels;
using FastFoodFIAP.Domain.Models;

namespace FastFoodFIAP.Application.AutoMapper
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
