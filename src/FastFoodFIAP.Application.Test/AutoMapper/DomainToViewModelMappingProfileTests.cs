using AutoMapper;
using FastFoodFIAP.Application.AutoMapper;
using Xunit;

namespace FastFoodFIAP.Application.Test.AutoMapper;

public class DomainToViewModelMappingProfileTests
{
    [Fact]
    public void PagamentoMapping_IsValid()
    {
        // Arrange
        var profile = new DomainToViewModelMappingProfile();
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));

        // Act & Assert
        configuration.AssertConfigurationIsValid();
    }

    [Fact]
    public void SituacaoPagamentoMapping_IsValid()
    {
        // Arrange
        var profile = new DomainToViewModelMappingProfile();
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));

        // Act & Assert
        configuration.AssertConfigurationIsValid(); 
    }
}