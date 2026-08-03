using GenerateService.Application.DTOs;

namespace GenerateService.Application.Ports;

public interface IGenerateSample
{
    Task<PagedResponse> GenerateSampleSize(GenerateRequest request, int page, int pageSize);
}