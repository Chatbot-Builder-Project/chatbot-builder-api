using ChatbotBuilderApi.Application.Core;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Data;
using FluentValidation;

namespace ChatbotBuilderApi.Application.Graphs.Shared.Data;

public sealed class OptionDataValidator : AbstractValidator<OptionData>
{
    public OptionDataValidator()
    {
        RuleFor(x => x.Value)
            .NotEmpty()
            .WithMessage("Option value must not be empty.")
            .MaximumLength(ApplicationRules.Strings.MaxMediumStringLength)
            .WithMessage($"Option value must not exceed {ApplicationRules.Strings.MaxMediumStringLength} characters.");
    }
}