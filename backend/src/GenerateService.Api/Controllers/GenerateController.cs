using GenerateService.Application.DTOs;
using GenerateService.Application.Ports;
using Microsoft.AspNetCore.Mvc;

namespace GenerateService.Api.Controllers;

[ApiController]
[Route("api/generate")]
public class GenerateController : ControllerBase
{
    private readonly IGenerateSample _generateSample;
    public GenerateController(IGenerateSample generateSample)
    {
        _generateSample = generateSample;
    }

    [HttpPost]
    public async Task<IActionResult> Generate([FromBody] GenerateRequest request, int page, int pageSize)
    {
        var items = await _generateSample.GenerateSampleSize(request, page, pageSize);

        return Ok(items);
    }
}