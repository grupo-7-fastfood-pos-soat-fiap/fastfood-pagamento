using AutoMapper;
using FastFoodFIAP.Application.InputModels;
using FastFoodFIAP.Domain.Commands.PagamentoCommands;
using FastFoodFIAP.Domain.Commands;
using FastFoodFIAP.Domain.Models;

namespace FastFoodFIAP.Application.AutoMapper
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
