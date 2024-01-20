using FastFoodFIAP.Application.InputModels;
using FastFoodFIAP.Application.ViewModels;
using FluentValidation.Results;
using GenericPack.Messaging;

namespace FastFoodFIAP.Application.Interfaces
{
    public interface IPagamentoApp: IDisposable
    {   

        Task<CommandResult> Create(NewPagamentoInputModel model);

        Task<CommandResult> Update(WebhookPagamentoInputModel model);
    }
}
