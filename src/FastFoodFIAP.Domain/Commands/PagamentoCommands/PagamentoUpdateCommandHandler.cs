﻿using FastFoodFIAP.Domain.Interfaces;
using FastFoodFIAP.Domain.Models;
using GenericPack.Messaging;
using MediatR;

namespace FastFoodFIAP.Domain.Commands.PagamentoCommands
{
    public class PagamentoCommandHandler : CommandHandler, IRequestHandler<PagamentoUpdateCommand, CommandResult>
    {
        private readonly IPagamentoRepository _repository;

        public PagamentoCommandHandler(IMediator mediator, IPagamentoRepository repository)
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

            return await Commit(_repository.UnitOfWork);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}