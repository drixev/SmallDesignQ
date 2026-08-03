using FluentValidation;
using GenerateService.Application.DTOs;
using GenerateService.Application.Ports;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GenerateService.Api.Controllers;

[ApiController]
[Route("api/generate")]
[Authorize]
public class GenerateController : ControllerBase
{
    private readonly IGenerateSample _generateSample;
    private readonly IValidator<GenerateRequest> _validator;

    public GenerateController(IGenerateSample generateSample, IValidator<GenerateRequest> validator)
    {
        _generateSample = generateSample;
        _validator = validator;
    }

    [HttpPost]
    public async Task<IActionResult> Generate([FromBody] GenerateRequest request, int page, int pageSize)
    {
        if (page <= 0)
        {
            return BadRequest(new
            {
                error = $"Page must be greater than to 0: {nameof(page)}"
            });
        }
        if (pageSize <= 0)
        {
            return BadRequest(new
            {
                error = $"PageSize must be greater than to 0: {nameof(pageSize)}"
            });
        }

        var validationResult = await _validator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            return ValidationProblem(new ValidationProblemDetails(validationResult.ToDictionary()));
        }

        var items = await _generateSample.GenerateSampleSize(request, page, pageSize);

        return Ok(items);
    }
}