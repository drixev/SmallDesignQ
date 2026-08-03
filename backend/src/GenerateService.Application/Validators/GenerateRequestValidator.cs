using FluentValidation;
using GenerateService.Application.DTOs;

namespace GenerateService.Application.Validators;

public sealed class GenerateRequestValidator : AbstractValidator<GenerateRequest>
{
    public GenerateRequestValidator()
    {
        RuleFor(x => x.Input1).GreaterThan(0);
        RuleFor(x => x.Input2).GreaterThan(0);
        RuleFor(x => x.SampleSize)
            .GreaterThan(0)
            .LessThanOrEqualTo(1_000_000);
    }
}