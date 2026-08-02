using GenerateService.Application.DTOs;

namespace GenerateService.Application.Ports;

public interface IGenerateService
{
    Task<IEnumerable<GenerateResponse>> GenerateSampleSize(GenerateRequest request);
}