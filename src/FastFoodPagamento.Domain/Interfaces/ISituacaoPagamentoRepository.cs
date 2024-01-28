using FastFoodPagamento.Domain.Models;
using GenericPack.Data;

namespace FastFoodPagamento.Domain.Interfaces
{
    public interface ISituacaoPagamentoRepository : IRepository<SituacaoPagamento>
    {
        Task<IEnumerable<SituacaoPagamento>> GetAll();
    }
}
