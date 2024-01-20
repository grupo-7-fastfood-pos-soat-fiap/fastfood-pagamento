using FastFoodFIAP.Domain.Interfaces;
using FastFoodFIAP.Domain.Interfaces.Services;
using FastFoodFIAP.Domain.Models;
using GenericPack.Messaging;
using MediatR;

namespace FastFoodFIAP.Domain.Commands.PagamentoCommands
{
    public class PagamentoCreateCommandHandler : CommandHandler, IRequestHandler<PagamentoCreateCommand, CommandResult>
    {
        private readonly IPagamentoRepository _repository;
        private readonly IGatewayPagamento _gateway;

        public PagamentoCreateCommandHandler(IMediator mediator, IPagamentoRepository repository, IGatewayPagamento gateway)
        {
            _repository = repository;
            _gateway = gateway;
        }

        public async Task<CommandResult> Handle(PagamentoCreateCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.CommandResult;

            var qrCode = await _gateway.SolicitarQrCodeAsync(request.PedidoId, request.Valor);

            var pagamento = new Pagamento(Guid.NewGuid(), qrCode, request.Valor, request.PedidoId, (int)Models.Enums.SituacaoPagamento.Pendente);

            _repository.Add(pagamento);

            return await Commit(_repository.UnitOfWork);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
