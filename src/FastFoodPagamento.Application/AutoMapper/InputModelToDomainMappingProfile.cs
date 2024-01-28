using AutoMapper;
using FastFoodPagamento.Application.InputModels;
using FastFoodPagamento.Domain.Commands.PagamentoCommands;

namespace FastFoodPagamento.Application.AutoMapper
{
    public class InputModelToDomainMappingProfile:Profile
    {
        public InputModelToDomainMappingProfile()
        {            
            AllowNullCollections = true;

            CreateMap<WebhookPagamentoInputModel, PagamentoUpdateCommand>();
            CreateMap<NewPagamentoInputModel, PagamentoCreateCommand>();
        }
    }
}
