using FastFoodPagamento.Application.InputModels;
using GenericPack.Messaging;

namespace FastFoodPagamento.Application.Interfaces
{
    public interface IPagamentoApp: IDisposable
    {   

        Task<CommandResult> Create(NewPagamentoInputModel model);

        Task<CommandResult> Update(WebhookPagamentoInputModel model);
    }
}
