using FastFoodPagamento.Application.ViewModels;

namespace FastFoodPagamento.Application.Interfaces
{
    public interface ISituacaoPagamentoApp : IDisposable
    {
        Task<List<SituacaoPagamentoViewModel>> GetAll();
    }
}
