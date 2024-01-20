using FastFoodFIAP.Application.ViewModels;

namespace FastFoodFIAP.Application.Interfaces
{
    public interface ISituacaoPagamentoApp : IDisposable
    {
        Task<List<SituacaoPagamentoViewModel>> GetAll();
    }
}
