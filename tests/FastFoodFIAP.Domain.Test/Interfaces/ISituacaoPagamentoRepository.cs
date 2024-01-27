using FastFoodFIAP.Domain.Interfaces;
using FastFoodFIAP.Domain.Models;
using Moq;

namespace FastFoodFIAP.Domain.Test.Interfaces;

public class SituacaoPagamentoRepositoryTests
{
    [Fact]
    public async Task GetAll_ShouldReturnListOfSituacaoPagamentos()
    {
        // Arrange
        var pag = new List<SituacaoPagamento>
        {
            new SituacaoPagamento(1, "Aguardando Pagamento"),
            new SituacaoPagamento(2, "Pagamento Confirmado"),
            new SituacaoPagamento(3, "Pagamento Recusado")
        };

        var mockRepository = new Mock<ISituacaoPagamentoRepository>();
        mockRepository.Setup(repo => repo.GetAll())
            .ReturnsAsync(pag);

        var repository = mockRepository.Object;

        // Act
        var result = await repository.GetAll();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(pag.Count, result.Count());
    }
}