using FastFoodPagamento.Domain.Interfaces;
using FastFoodPagamento.Domain.Models;
using FastFoodPagamento.Infra.Data.Context;
using GenericPack.Data;
using Microsoft.EntityFrameworkCore;

namespace FastFoodPagamento.Infra.Data.Repository
{
    public class SituacaoPagamentoRepository: ISituacaoPagamentoRepository
    {
        protected readonly AppDbContext Db;
        protected readonly DbSet<SituacaoPagamento> DbSet;

        public SituacaoPagamentoRepository(AppDbContext context)
        {
            Db = context;
            DbSet = Db.Set<SituacaoPagamento>();
        }

        public IUnitOfWork UnitOfWork => Db;

        public async Task<IEnumerable<SituacaoPagamento>> GetAll()
        {
            return await DbSet.AsNoTracking().OrderBy(on => on.Id).ToListAsync();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
