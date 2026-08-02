using GenerateService.Domain.Enums;

namespace GenerateService.Domain.Entities;

public sealed class GenerateResult
{
    public int Number { get; init; }
    public GenerateResultType TypeResult { get; init; }

    public GenerateResult(int number, GenerateResultType typeResult)
    {
        Number = number;
        TypeResult = typeResult;
    }
}