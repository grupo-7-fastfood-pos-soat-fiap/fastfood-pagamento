using FastFoodFIAP.Domain.Interfaces;
using FastFoodFIAP.Domain.Models;
using Moq;

namespace FastFoodFIAP.Domain.Test.Interfaces;

public class PagamentoRepositoryTests
{
    [Fact]
    public async Task GetById_ShouldReturnPagamento_WhenIdExists()
    {
        // Arrange
        var pagamentoId = Guid.NewGuid();
        var pagamento = new Pagamento(pagamentoId, "QrCode123", 100.00m, Guid.NewGuid(), 1);

        var mockRepository = new Mock<IPagamentoRepository>();
        mockRepository.Setup(repo => repo.GetById(pagamentoId))
            .ReturnsAsync(pagamento);

        var repository = mockRepository.Object;

        // Act
        var result = await repository.GetById(pagamentoId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(pagamentoId, result.Id);
    }

    [Fact]
    public async Task GetById_ShouldReturnNull_WhenIdDoesNotExist()
    {
        // Arrange
        var nonExistingId = Guid.NewGuid();

        var mockRepository = new Mock<IPagamentoRepository>();
        mockRepository.Setup(repo => repo.GetById(nonExistingId))
            .ReturnsAsync((Pagamento)null!);

        var repository = mockRepository.Object;

        // Act
        var result = await repository.GetById(nonExistingId);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task GetAll_ShouldReturnListOfPagamentos()
    {
        // Arrange
        var pagamentos = new List<Pagamento>
        {
            new Pagamento(Guid.NewGuid(), "QrCode1", 50.00m, Guid.NewGuid(), 1),
            new Pagamento(Guid.NewGuid(), "QrCode2", 75.00m, Guid.NewGuid(), 2),
            new Pagamento(Guid.NewGuid(), "QrCode3", 100.00m, Guid.NewGuid(), 3)
        };

        var mockRepository = new Mock<IPagamentoRepository>();
        mockRepository.Setup(repo => repo.GetAll())
            .ReturnsAsync(pagamentos);

        var repository = mockRepository.Object;

        // Act
        var result = await repository.GetAll();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(pagamentos.Count, result.Count());
    }

    [Fact]
    public void Add_ShouldAddPagamentoToRepository()
    {
        // Arrange
        var pagamento = new Pagamento(Guid.NewGuid(), "QrCode123", 100.00m, Guid.NewGuid(), 1);

        var mockRepository = new Mock<IPagamentoRepository>();
        var repository = mockRepository.Object;

        // Act
        repository.Add(pagamento);

        // Assert
        mockRepository.Verify(repo => repo.Add(It.IsAny<Pagamento>()), Times.Once);
    }

    [Fact]
    public void Update_ShouldUpdatePagamentoInRepository()
    {
        // Arrange
        var pagamento = new Pagamento(Guid.NewGuid(), "QrCode123", 100.00m, Guid.NewGuid(), 1);

        var mockRepository = new Mock<IPagamentoRepository>();
        var repository = mockRepository.Object;

        // Act
        repository.Update(pagamento);

        // Assert
        mockRepository.Verify(repo => repo.Update(It.IsAny<Pagamento>()), Times.Once);
    }

    [Fact]
    public void Remove_ShouldRemovePagamentoFromRepository()
    {
        // Arrange
        var pagamento = new Pagamento(Guid.NewGuid(), "QrCode123", 100.00m, Guid.NewGuid(), 1);

        var mockRepository = new Mock<IPagamentoRepository>();
        var repository = mockRepository.Object;

        // Act
        repository.Remove(pagamento);

        // Assert
        mockRepository.Verify(repo => repo.Remove(It.IsAny<Pagamento>()), Times.Once);
    }
}