using FastFoodPagamento.Domain.Commands.PagamentoCommands;
using FastFoodPagamento.Domain.Interfaces;
using FastFoodPagamento.Domain.Models;
using GenericPack.Data;
using Moq;

namespace FastFoodFIAP.Domain.Test.Commands.PagamentoCommand
{
    public class PagamentoUpdateCommandHandlerTest
    {
        [Fact]
        public async Task Handle_PagamentoExists_UpdatesAndCommits()
        {
            // Arrange
            var id = Guid.NewGuid();
            var situacaoId = 2;

            var repositoryMock = new Mock<IPagamentoRepository>();
            repositoryMock.Setup(r => r.GetById(id))
                          .ReturnsAsync(new Pagamento(id, "QRCode123", 50.0m, Guid.NewGuid(), 1));
            repositoryMock.Setup(m => m.UnitOfWork).Returns(new Mock<IUnitOfWork>().Object);
            
            var handler = new PagamentoUpdateCommandHandler(null, repositoryMock.Object);
            var command = new PagamentoUpdateCommand(id, situacaoId);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Verifique se o método Update foi chamado no repositório
            repositoryMock.Verify(r => r.Update(It.IsAny<Pagamento>()), Times.Once);

            // Verifique se o método Commit foi chamado na unidade de trabalho
            repositoryMock.Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }

        [Fact]
        public async Task Handle_PagamentoNotExists_ReturnsError()
        {
            // Arrange
            var id = Guid.NewGuid();
            var situacaoId = 2;

            var repositoryMock = new Mock<IPagamentoRepository>();
            repositoryMock.Setup(r => r.GetById(id))
                          .ReturnsAsync((Pagamento)null);

            var handler = new PagamentoUpdateCommandHandler(null, repositoryMock.Object);
            var command = new PagamentoUpdateCommand(id, situacaoId);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Certifique-se de que o método Update não foi chamado no repositório
            repositoryMock.Verify(r => r.Update(It.IsAny<Pagamento>()), Times.Never);

            // Certifique-se de que o método Commit não foi chamado na unidade de trabalho
            repositoryMock.Verify(r => r.UnitOfWork.Commit(), Times.Never);
        }
    }
}
