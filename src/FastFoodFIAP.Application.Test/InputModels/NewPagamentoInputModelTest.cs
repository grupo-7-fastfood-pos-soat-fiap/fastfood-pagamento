using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FastFoodFIAP.Application.InputModels;
using Xunit;

namespace FastFoodFIAP.Application.Test.InputModels;

public class NewPagamentoInputModelTests
{
    [Fact]
    public void PedidoId_RequiredAttribute_IsValid()
    {
        // Arrange
        var model = new NewPagamentoInputModel();

        // Act
        var validationResult = ValidateModel(model);

        // Assert
        Assert.Empty(validationResult);
        
    }

    [Fact]
    public void Valor_RequiredAttribute_IsValid()
    {
        // Arrange
        var model = new NewPagamentoInputModel();

        // Act
        var validationResult = ValidateModel(model);

        // Assert
        Assert.Empty(validationResult);
        
    }

    [Fact]
    public void Model_With_Valid_Properties_Should_Pass_Validation()
    {
        // Arrange
        var model = new NewPagamentoInputModel
        {
            PedidoId = Guid.NewGuid(),
            Valor = 100.0m
        };

        // Act
        var validationResult = ValidateModel(model);

        // Assert
        Assert.Empty(validationResult);
    }

    private static List<ValidationResult> ValidateModel(object model)
    {
        var validationContext = new ValidationContext(model);
        var validationResult = new List<ValidationResult>();
        Validator.TryValidateObject(model, validationContext, validationResult, true);
        return validationResult;
    }
}