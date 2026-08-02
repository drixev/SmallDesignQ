using GenerateService.Application.DTOs;

namespace GenerateService.Application.Ports;

public interface IGenerateService
{
    Task<PagedResponse<GenerateResponse>> GenerateSampleSize(GenerateRequest request, int page, int pageSize);
}