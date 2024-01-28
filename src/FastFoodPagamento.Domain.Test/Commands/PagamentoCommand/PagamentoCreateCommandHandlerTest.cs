using FastFoodPagamento.Domain.Commands.PagamentoCommands;
using FastFoodPagamento.Domain.Interfaces;
using FastFoodPagamento.Domain.Interfaces.Services;
using FastFoodPagamento.Domain.Models;
using GenericPack.Data;
using Moq;

namespace FastFoodFIAP.Domain.Test.Commands.PagamentoCommand
{
    public class PagamentoCreateCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ValidCommand_ReturnsSuccessResult()
        {
            // Arrange
            var pedidoId = Guid.NewGuid();
            var valor = 50.0m;

            var gatewayMock = new Mock<IGatewayPagamento>();
            gatewayMock.Setup(g => g.SolicitarQrCodeAsync(It.IsAny<Guid>(), It.IsAny<decimal>()))
                .ReturnsAsync("QRCode123");

            var repositoryMock = new Mock<IPagamentoRepository>();
            repositoryMock.Setup(m => m.UnitOfWork).Returns(new Mock<IUnitOfWork>().Object);

            var handler = new PagamentoCreateCommandHandler(repositoryMock.Object, gatewayMock.Object);
            var command = new PagamentoCreateCommand(pedidoId, valor);
            
            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Verifique se o método de adição foi chamado no repositório
            repositoryMock.Verify(r => r.Add(It.IsAny<Pagamento>()), Times.Once);

            // Verifique se o método de solicitar QR Code foi chamado no gateway
            gatewayMock.Verify(g => g.SolicitarQrCodeAsync(It.IsAny<Guid>(), It.IsAny<decimal>()), Times.Once);
        }
    }
}