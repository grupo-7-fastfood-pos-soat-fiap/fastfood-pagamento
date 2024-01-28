using FastFoodPagamento.Domain.Interfaces.Services;
using Moq;

namespace FastFoodFIAP.Domain.Test.Interfaces;

public class GatewayPagamentoTests
{
    [Fact]
    public async Task SolicitarQrCodeAsync_ShouldReturnQrCode()
    {
        // Arrange
        var pedidoId = Guid.NewGuid();
        var valor = 100.00m;
        var qrCodeEsperado = "QrCode123";

        var mockGatewayPagamento = new Mock<IGatewayPagamento>();
        mockGatewayPagamento.Setup(gateway => gateway.SolicitarQrCodeAsync(pedidoId, valor))
            .ReturnsAsync(qrCodeEsperado);

        var gatewayPagamento = mockGatewayPagamento.Object;

        // Act
        var result = await gatewayPagamento.SolicitarQrCodeAsync(pedidoId, valor);

        // Assert
        Assert.Equal(qrCodeEsperado, result);
        mockGatewayPagamento.Verify(gateway => gateway.SolicitarQrCodeAsync(pedidoId, valor), Times.Once);
    }
}