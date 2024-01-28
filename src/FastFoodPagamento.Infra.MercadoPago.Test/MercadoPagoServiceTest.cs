using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace FastFoodPagamento.Infra.MercadoPago.Test;

public class MercadoPagoServiceTests
{
    [Fact]
    public async Task SolicitarQrCodeAsync_Success()
    {
        // Arrange
        var httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://api.mercadopago.com/v1/")
        };

        var mercadoPagoService = new MercadoPagoService(httpClient);

        var pedidoId = Guid.NewGuid();
        var valor = 10.0m;

        // Act
        var result = await mercadoPagoService.SolicitarQrCodeAsync(pedidoId, valor);

        // Assert
        Assert.NotNull(result);
    }
}