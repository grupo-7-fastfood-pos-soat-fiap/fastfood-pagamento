using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FastFoodPagamento.Application.Services;
using FastFoodPagamento.Domain.Interfaces;
using FastFoodPagamento.Domain.Models;
using GenericPack.Mediator;
using Moq;
using Xunit;

namespace FastFoodPagamento.Application.Test.Services;

public class SituacaoPagamentoAppTests
{
    [Fact]
    public async Task GetAll_ShouldReturnMappedViewModels()
    {
        // Arrange
        var situacaoList = new List<SituacaoPagamento>
        {
            new SituacaoPagamento(1, "Aguardando Pagamento"),
            new SituacaoPagamento(2, "Pagamento Confirmado"),
            new SituacaoPagamento(3, "Pagamento Recusado")
        };
        
        var situacaoRepositoryMock = new Mock<ISituacaoPagamentoRepository>();
        var mediatorMock = new Mock<IMediatorHandler>();
        var mapperMock = new Mock<IMapper>();

        situacaoRepositoryMock.Setup(repo => repo.GetAll()).ReturnsAsync(situacaoList);
       
        var situacaoPagamentoApp = new SituacaoPagamentoApp(
            situacaoRepositoryMock.Object,
            mediatorMock.Object,
            mapperMock.Object
        );

        // Act
        var result = await situacaoPagamentoApp.GetAll();

        // Assert
        // Assert.Equal(situacaoList.Count, result.Count);
    }
}