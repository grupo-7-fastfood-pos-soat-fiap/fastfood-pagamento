using System;
using System.Threading.Tasks;
using FastFoodFIAP.Domain.Commands.PagamentoCommands;
using MediatR;
using Moq;
using Xunit;

namespace FastFoodFIAP.Infra.CrossCutting.Bus.Test;

public class InMemoryBusTest
{
    
    [Fact]
    public async Task SendCommand_ShouldCallMediatorSend()
    {
        // Arrange
        var mediatorMock = new Mock<IMediator>();
        Guid id = Guid.NewGuid();
        decimal valor = 100m;
        
        var inMemoryBus = new InMemoryBus(mediatorMock.Object);

        var sampleCommand = new PagamentoCreateCommand(id, valor); 

        // Act
        await inMemoryBus.SendCommand(sampleCommand);

        // Assert
        mediatorMock.Verify(m => m.Send(sampleCommand, default), Times.Once);
    }
}