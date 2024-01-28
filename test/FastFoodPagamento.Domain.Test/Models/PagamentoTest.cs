using FastFoodPagamento.Domain.Models;

namespace FastFoodFIAP.Domain.Test.Models;

public class PagamentoTests
{
    [Fact]
    public void Pagamento_Constructor_ShouldSetProperties()
    {
        // Arrange
        Guid id = Guid.NewGuid();
        string qrCode = "QrCode123";
        decimal valor = 100.00m;
        Guid pedidoId = Guid.NewGuid();
        int situacaoId = 1;

        // Act
        var pagamento = new Pagamento(id, qrCode, valor, pedidoId, situacaoId);

        // Assert
        Assert.Equal(id, pagamento.Id);
        Assert.Equal(qrCode, pagamento.QrCode);
        Assert.Equal(valor, pagamento.Valor);
        Assert.Equal(pedidoId, pagamento.PedidoId);
        Assert.Equal(situacaoId, pagamento.SituacaoId);
    }
}
