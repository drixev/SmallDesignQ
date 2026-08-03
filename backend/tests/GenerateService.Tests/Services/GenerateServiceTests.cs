// Arrange / Act/ Assert
using GenerateService.Application.DTOs;
using GenerateService.Application.Services;
using GenerateService.Domain.Enums;

namespace GenerateService.Tests.Services;


public class GenerateServiceTests
{

    private readonly GenerateSample _service = new();
    [Fact]
    public async Task GenerateAsync_Should_ReturnExpectedResults()
    {
        // Arrange
        var request = new GenerateRequest(2, 3, 6);

        // Act
        var result = await _service.GenerateSampleSize(request, 1, 6);

        // Assert
        var expectedItems = new[]
        {
            new GenerateResponse(0, GenerateResultType.Unknown), // divisible by both
            new GenerateResponse(1, GenerateResultType.IDontKnow),           // divisible by neither
            new GenerateResponse(2, GenerateResultType.Yes),           // divisible by Input1 only
            new GenerateResponse(3, GenerateResultType.No),            // divisible by Input2 only
            new GenerateResponse(4, GenerateResultType.Yes),
            new GenerateResponse(5, GenerateResultType.IDontKnow),
        };
        Assert.Equal(expectedItems, result.Items);

        Assert.Equal(1, result.Page);
        Assert.Equal(6, result.PageSize);
        Assert.Equal(7, result.TotalItems); // SampleSize + 1, since range starts at 0
        Assert.Equal(2, result.TotalPages);
    }
}