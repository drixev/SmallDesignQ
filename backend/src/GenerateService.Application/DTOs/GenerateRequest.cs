namespace GenerateService.Application.DTOs;

public sealed record GenerateRequest(
    int Input1,
    int Input2,
    int SampleSize
);