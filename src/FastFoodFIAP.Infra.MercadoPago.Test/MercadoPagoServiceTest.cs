using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using FastFoodFIAP.Infra.MercadoPago.Models;
using Moq;
using Moq.Protected;
using Xunit;

namespace FastFoodFIAP.Infra.MercadoPago.Test;

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