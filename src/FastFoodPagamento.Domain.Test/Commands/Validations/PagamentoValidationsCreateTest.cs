using FastFoodPagamento.Domain.Commands.PagamentoCommands;
using FluentAssertions;

namespace FastFoodFIAP.Domain.Test.Commands.Validations
{
    public class PagamentoValidationsCreateTests
    {
        
        [Fact]
        public void PagamentoValidations_Valido()
        {
            // Arrange
            Guid pedidoId = Guid.NewGuid();
            decimal valor = 100m;

            // Act
            var result = new PagamentoCreateCommand(pedidoId, valor);

            // Assert
            result.IsValid().Should().BeTrue();
        }
    }
}
