﻿using AutoMapper;
using FastFoodPagamento.Application.InputModels;
using FastFoodPagamento.Application.Interfaces;
using FastFoodPagamento.Domain.Commands.PagamentoCommands;
using FastFoodPagamento.Domain.Interfaces;
using GenericPack.Mediator;
using GenericPack.Messaging;

namespace FastFoodPagamento.Application.Services
{
    public class PagamentoApp : IPagamentoApp
    {
        private readonly IPagamentoRepository _pagamentoRepository;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;

        public PagamentoApp(IPagamentoRepository pagamentoRepository, IMediatorHandler mediator, IMapper mapper)
        {
            _pagamentoRepository = pagamentoRepository;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<CommandResult> Update(WebhookPagamentoInputModel model)
        {
            var command = _mapper.Map<PagamentoUpdateCommand>(model);
            return await _mediator.SendCommand(command);
        }

        public async Task<CommandResult> Create(NewPagamentoInputModel model)
        {
            var command = _mapper.Map<PagamentoCreateCommand>(model);
            return await _mediator.SendCommand(command);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
