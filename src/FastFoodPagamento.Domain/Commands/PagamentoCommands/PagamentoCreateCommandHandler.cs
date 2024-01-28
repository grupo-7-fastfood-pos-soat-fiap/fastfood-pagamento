using FastFoodPagamento.Domain.Interfaces;
using FastFoodPagamento.Domain.Interfaces.Services;
using FastFoodPagamento.Domain.Models;
using GenericPack.Messaging;
using MediatR;
using SituacaoPagamento = FastFoodPagamento.Domain.Models.Enums.SituacaoPagamento;

namespace FastFoodPagamento.Domain.Commands.PagamentoCommands
{
    public class PagamentoCreateCommandHandler : CommandHandler, IRequestHandler<PagamentoCreateCommand, CommandResult>, IDisposable
    {
        private readonly IPagamentoRepository _repository;
        private readonly IGatewayPagamento _gateway;

        public PagamentoCreateCommandHandler(IPagamentoRepository repository, IGatewayPagamento gateway)
        {
            _repository = repository;
            _gateway = gateway;
        }

        public async Task<CommandResult> Handle(PagamentoCreateCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.CommandResult;

            var qrCode = await _gateway.SolicitarQrCodeAsync(request.PedidoId, request.Valor);

            var pagamento = new Pagamento(Guid.NewGuid(), qrCode, request.Valor, request.PedidoId, (int)SituacaoPagamento.Pendente);

            _repository.Add(pagamento);

            return await Commit(_repository.UnitOfWork);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            _repository.Dispose();
        }
    }
}
