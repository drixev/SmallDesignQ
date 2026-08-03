// Arrange / Act/ Assert

using Challenge.Application.DTOs;
using Challenge.Application.Validators;
using FluentValidation.TestHelper;

namespace Challenge.Tests.Validators;

public class GenerateRequestValidatorTests
{
    private readonly GenerateRequestValidator _validator = new();

    [Fact]
    public void Should_NotHaveErrors_When_RequestIsValid()
    {
        // Arrange
        var request = new GenerateRequest(2, 3, 6);

        // Act
        var result = _validator.TestValidate(request);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Should_HaveError_When_Input1IsNotGreaterThanZero(int input1)
    {
        // Arrange
        var request = new GenerateRequest(input1, 3, 6);

        // Act
        var result = _validator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Input1);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Should_HaveError_When_Input2IsNotGreaterThanZero(int input2)
    {
        // Arrange
        var request = new GenerateRequest(2, input2, 6);

        // Act
        var result = _validator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Input2);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Should_HaveError_When_SampleSizeIsNotGreaterThanZero(int sampleSize)
    {
        // Arrange
        var request = new GenerateRequest(2, 3, sampleSize);

        // Act
        var result = _validator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.SampleSize);
    }

    [Fact]
    public void Should_HaveError_When_SampleSizeExceedsMaximum()
    {
        // Arrange
        var request = new GenerateRequest(2, 3, 1_000_001);

        // Act
        var result = _validator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.SampleSize);
    }

    [Fact]
    public void Should_NotHaveError_When_SampleSizeIsAtMaximum()
    {
        // Arrange
        var request = new GenerateRequest(2, 3, 1_000_000);

        // Act
        var result = _validator.TestValidate(request);

        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.SampleSize);
    }
}
