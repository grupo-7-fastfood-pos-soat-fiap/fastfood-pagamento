using FastFoodPagamento.Domain.Commands.PagamentoCommands;

namespace FastFoodFIAP.Domain.Test.Commands.PagamentoCommand;

public class PagamentoUpdateCommandTests
{
    [Fact]
    public void Constructor_Should_Set_Id_And_SituacaoId()
    {
        // Arrange
        var expectedId = Guid.NewGuid();
        var expectedSituacaoId = 1;

        // Act
        var command = new PagamentoUpdateCommand(expectedId, expectedSituacaoId);

        // Assert
        Assert.Equal(expectedId, command.Id);
        Assert.Equal(expectedSituacaoId, command.SituacaoId);
    }

    [Fact]
    public void Constructor_With_Empty_Guid_Should_Set_Id()
    {
        // Arrange
        var expectedId = Guid.Empty;
        var expectedSituacaoId = 1;

        // Act
        var command = new PagamentoUpdateCommand(expectedId, expectedSituacaoId);

        // Assert
        Assert.Equal(expectedId, command.Id);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(int.MaxValue)]
    public void Constructor_Should_Set_SituacaoId_With_Various_Integers(int SituacaoId)
    {
        // Arrange
        var expectedId = Guid.NewGuid();

        // Act
        var command = new PagamentoUpdateCommand(expectedId, SituacaoId);

        // Assert
        Assert.Equal(SituacaoId, command.SituacaoId);
    }

    [Fact]
    public void ProtectedConstructor_Should_Not_Be_Accessible()
    {
        // Act & Assert
        var type = typeof(PagamentoUpdateCommand);
        var constructors = type.GetConstructors(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        foreach (var constructor in constructors)
        {
            Assert.True(constructor.IsFamily);
        }
    }
}