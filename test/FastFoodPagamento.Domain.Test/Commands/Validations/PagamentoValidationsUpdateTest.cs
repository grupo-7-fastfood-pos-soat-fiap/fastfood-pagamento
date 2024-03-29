using FastFoodPagamento.Domain.Commands.PagamentoCommands;
using FluentAssertions;

namespace FastFoodFIAP.Domain.Test.Commands.Validations
{
    public class PagamentoValidationsUpdateTests
    {
        
        [Fact]
        public void PagamentoValidations_Valido()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            int situacao = 1;

            // Act
            var result = new PagamentoUpdateCommand(id, situacao);

            // Assert
            result.IsValid().Should().BeTrue();
        }
    }
}
