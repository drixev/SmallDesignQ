using GenerateService.Application.DTOs;
using GenerateService.Application.Extensions;
using GenerateService.Application.Ports;
using GenerateService.Domain.Enums;

namespace GenerateService.Application.Services;

public sealed class GenerateSample : IGenerateSample
{
    public Task<PagedResponse> GenerateSampleSize(GenerateRequest request, int page, int pageSize)
    {
        var sample = Enumerable.Range(0, request.SampleSize + 1)
            .Select(number =>
                new GenerateResponse(number, GetResult(number, request.Input1, request.Input2)))
            .ToList();

        return Task.FromResult(sample.ToPagedResponse(page, pageSize));
    }

    private static GenerateResultType GetResult(int number, int input1, int input2)
    {
        var dividedByInput1 = number % input1 == 0;
        var dividedByInput2 = number % input2 == 0;

        var result = (dividedByInput1, dividedByInput2) switch
        {
            (true, false) => GenerateResultType.Yes,
            (false, true) => GenerateResultType.No,
            (true, true) => GenerateResultType.IDontKnow,
            _ => GenerateResultType.Unknown
        };

        return result;
    }
}