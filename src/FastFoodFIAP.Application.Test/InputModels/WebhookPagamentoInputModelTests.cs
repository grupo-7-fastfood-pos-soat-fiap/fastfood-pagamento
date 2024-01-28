using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using FastFoodFIAP.Application.InputModels;
using Xunit;

namespace FastFoodFIAP.Application.Test.InputModels;

public class WebhookPagamentoInputModelTests
{
    [Fact]
    public void Id_RequiredAttribute_IsValid()
    {
        // Arrange
        var model = new WebhookPagamentoInputModel();

        // Act
        var validationResult = ValidateModel(model);

        // Assert
        Assert.Empty(validationResult);
    }

    [Fact]
    public void SituacaoId_RequiredAttribute_IsValid()
    {
        // Arrange
        var model = new WebhookPagamentoInputModel();

        // Act
        var validationResult = ValidateModel(model);

        // Assert
        Assert.Empty(validationResult);
        
    }

    [Fact]
    public void Model_With_Valid_Properties_Should_Pass_Validation()
    {
        // Arrange
        var model = new WebhookPagamentoInputModel
        {
            Id = Guid.NewGuid(),
            SituacaoId = 1
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