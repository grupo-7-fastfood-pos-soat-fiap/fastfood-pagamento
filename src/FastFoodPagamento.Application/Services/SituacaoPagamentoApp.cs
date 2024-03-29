using AutoMapper;
using FastFoodPagamento.Application.Interfaces;
using FastFoodPagamento.Application.ViewModels;
using FastFoodPagamento.Domain.Interfaces;
using GenericPack.Mediator;

namespace FastFoodPagamento.Application.Services
{
    public class SituacaoPagamentoApp : ISituacaoPagamentoApp
    {
        private readonly ISituacaoPagamentoRepository _situacaoRepository;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;

        public SituacaoPagamentoApp(ISituacaoPagamentoRepository situacaoRepository, IMediatorHandler mediator, IMapper mapper)
        {
            _situacaoRepository = situacaoRepository;
            _mediator = mediator;
            _mapper = mapper;
        }        

        public async Task<List<SituacaoPagamentoViewModel>> GetAll()
        {
            return _mapper.Map<List<SituacaoPagamentoViewModel>>(await _situacaoRepository.GetAll());
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
