using FastFoodPagamento.Domain.Interfaces;
using FastFoodPagamento.Domain.Models;
using FastFoodPagamento.Domain.PagamentoEvent;
using GenericPack.Messaging;
using MediatR;

namespace FastFoodPagamento.Domain.Commands.PagamentoCommands
{
    public class PagamentoUpdateCommandHandler : CommandHandler, IRequestHandler<PagamentoUpdateCommand, CommandResult>, IDisposable
    {
        private readonly IPagamentoRepository _repository;

        public PagamentoUpdateCommandHandler(IMediator mediator, IPagamentoRepository repository)
        {
            _repository = repository;
        }

        public async Task<CommandResult> Handle(PagamentoUpdateCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.CommandResult;

            var pagamentoExiste = await _repository.GetById(request.Id);
            if (pagamentoExiste is null)
            {
                AddError("O pagamento não existe.");
                return CommandResult;
            }

            var pagamento = new Pagamento(request.Id, pagamentoExiste.QrCode, pagamentoExiste.Valor, pagamentoExiste.PedidoId, request.SituacaoId);

            _repository.Update(pagamento);
            if (request.SituacaoId == 1) // pagamento aprovado 
            {
                pagamento.AddDomainEvent(new PagamentoCreateEvent(request.PedidoId));
            }

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