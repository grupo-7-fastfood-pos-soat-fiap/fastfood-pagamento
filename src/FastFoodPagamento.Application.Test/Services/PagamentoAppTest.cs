using System;
using System.Threading.Tasks;
using AutoMapper;
using FastFoodPagamento.Application.InputModels;
using FastFoodPagamento.Application.Services;
using FastFoodPagamento.Domain.Commands.PagamentoCommands;
using FastFoodPagamento.Domain.Interfaces;
using GenericPack.Mediator;
using Moq;
using Xunit;

namespace FastFoodPagamento.Application.Test.Services;

public class PagamentoAppTests
{
    [Fact]
    public async Task Update_ValidModel_ShouldCallMediator()
    {
        // Arrange
        var id = Guid.NewGuid();
        var situacaoId = 2;
        var model = new WebhookPagamentoInputModel();
        var command = new PagamentoUpdateCommand(id, situacaoId); 
        
        var pagamentoRepositoryMock = new Mock<IPagamentoRepository>();
        var mediatorMock = new Mock<IMediatorHandler>();
        var mapperMock = new Mock<IMapper>();

        mapperMock.Setup(m => m.Map<PagamentoUpdateCommand>(model)).Returns(command);

        var pagamentoApp = new PagamentoApp(pagamentoRepositoryMock.Object, mediatorMock.Object, mapperMock.Object);

        // Act
        var result = await pagamentoApp.Update(model);

        // Assert
        mediatorMock.Verify(m => m.SendCommand(command), Times.Once);
    }

    [Fact]
    public async Task Create_ValidModel_ShouldCallMediator()
    {
        // Arrange
        var id = Guid.NewGuid();
        var valor = 2;
        var model = new NewPagamentoInputModel();
        var command = new PagamentoCreateCommand(id, valor); 
        
        var pagamentoRepositoryMock = new Mock<IPagamentoRepository>();
        var mediatorMock = new Mock<IMediatorHandler>();
        var mapperMock = new Mock<IMapper>();

        mapperMock.Setup(m => m.Map<PagamentoCreateCommand>(model)).Returns(command);

        var pagamentoApp = new PagamentoApp(pagamentoRepositoryMock.Object, mediatorMock.Object, mapperMock.Object);

        // Act
        var result = await pagamentoApp.Create(model);

        // Assert
        mediatorMock.Verify(m => m.SendCommand(command), Times.Once);
    }
}