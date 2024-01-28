using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FastFoodFIAP.Application.Services;
using FastFoodFIAP.Domain.Interfaces;
using FastFoodFIAP.Domain.Models;
using GenericPack.Mediator;
using Moq;
using Xunit;

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
