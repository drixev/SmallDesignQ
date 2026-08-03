// Arrange / Act/ Assert

using Challenge.Application.DTOs;
using Challenge.Application.Services;

namespace Challenge.Tests.Services;


public class ChallengeServiceTests
{

    private readonly ChallengeService _service = new();
    [Fact]
    public async Task GenerateAsync_Should_ReturnExpectedResults()
    {
        // Arrange
        var request = new GenerateRequest(2, 3, 6);

        // Act
        var result = await _service.GenerateAsync(request, 1, 6);

        // Assert
        var expectedItems = new[]
        {
            new ChallegenResultDto(0, "I don't know"), // divisible by both
            new ChallegenResultDto(1, "N/A"),           // divisible by neither
            new ChallegenResultDto(2, "yes"),           // divisible by Input1 only
            new ChallegenResultDto(3, "no"),            // divisible by Input2 only
            new ChallegenResultDto(4, "yes"),
            new ChallegenResultDto(5, "N/A"),
        };
        Assert.Equal(expectedItems, result.Items);

        Assert.Equal(1, result.CurrentPage);
        Assert.Equal(6, result.PageSize);
        Assert.Equal(7, result.TotalItems); // SampleSize + 1, since range starts at 0
        Assert.Equal(2, result.TotalPages);
    }
}