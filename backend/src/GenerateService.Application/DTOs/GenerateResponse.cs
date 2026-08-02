using GenerateService.Domain.Enums;

namespace GenerateService.Application.DTOs;

public sealed record GenerateResponse(
    int Number,
    GenerateResultType Result
);