using FastFoodFIAP.Domain.Models;

namespace FastFoodFIAP.Domain.Test.Models;

using Xunit;

public class SituacaoPagamentoTests
{
    [Fact]
    public void SituacaoPagamento_Constructor_ShouldSetProperties()
    {
        // Arrange
        int id = 1;
        string nome = "Aguardando Pagamento";

        // Act
        var situacaoPagamento = new SituacaoPagamento(id, nome);

        // Assert
        Assert.Equal(id, situacaoPagamento.Id);
        Assert.Equal(nome, situacaoPagamento.Nome);
    }
}
