using FastFoodFIAP.Domain.Commands.PagamentoCommands;

namespace FastFoodFIAP.Domain.Test.Commands.PagamentoCommand
{
    public class PagamentoCreateCommandTests
    {
        [Fact]
        public void Constructor_ValidParameters_ShouldCreateInstance()
        {
            // Arrange
            Guid expectedPedidoId = Guid.NewGuid();
            decimal expectedValor = 100m;

            // Act
            PagamentoCreateCommand command = new PagamentoCreateCommand(expectedPedidoId, expectedValor);

            // Assert
            Assert.NotNull(command);
            Assert.Equal(expectedPedidoId, command.PedidoId);
            Assert.Equal(expectedValor, command.Valor);
        }

        [Fact]
        public void Constructor_ZeroValor_ShouldCreateInstanceWithZero()
        {
            // Arrange
            Guid expectedPedidoId = Guid.NewGuid();
            decimal expectedValor = 0m;

            // Act
            PagamentoCreateCommand command = new PagamentoCreateCommand(expectedPedidoId, expectedValor);

            // Assert
            Assert.NotNull(command);
            Assert.Equal(expectedPedidoId, command.PedidoId);
            Assert.Equal(expectedValor, command.Valor);
        }

        [Fact]
        public void Constructor_NegativeValor_ShouldCreateInstanceWithNegativeValue()
        {
            // Arrange
            Guid expectedPedidoId = Guid.NewGuid();
            decimal expectedValor = -50m;

            // Act
            PagamentoCreateCommand command = new PagamentoCreateCommand(expectedPedidoId, expectedValor);

            // Assert
            Assert.NotNull(command);
            Assert.Equal(expectedPedidoId, command.PedidoId);
            Assert.Equal(expectedValor, command.Valor);
        }

        // [Fact]
        // public void Constructor_EmptyPedidoId_ShouldThrowArgumentException()
        // {
        //     // Arrange
        //     Guid expectedPedidoId = Guid.Empty;
        //     decimal expectedValor = 100m;
        //
        //     // Act & Assert
        //     var exception = Assert.Throws<ArgumentException>(() => new PagamentoCreateCommand(expectedPedidoId, expectedValor));
        //     Assert.Equal("pedidoId", exception.ParamName);
        // }

        [Theory]
        [InlineData(10.99)]
        [InlineData(0.01)]
        [InlineData(100000.00)]
        [InlineData(-0.01)]
        [InlineData(-99999.99)]
        public void Constructor_DecimalEdgeCaseValues_ShouldCreateInstanceWithGivenValue(decimal value)
        {
            // Arrange
            Guid expectedPedidoId = Guid.NewGuid();

            // Act
            PagamentoCreateCommand command = new PagamentoCreateCommand(expectedPedidoId, value);

            // Assert
            Assert.NotNull(command);
            Assert.Equal(expectedPedidoId, command.PedidoId);
            Assert.Equal(value, command.Valor);
        }
    }
}
