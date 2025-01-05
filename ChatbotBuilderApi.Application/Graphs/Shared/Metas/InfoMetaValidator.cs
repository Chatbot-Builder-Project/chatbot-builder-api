using ChatbotBuilderApi.Application.Core;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Meta;
using FluentValidation;

namespace ChatbotBuilderApi.Application.Graphs.Shared.Metas;

public sealed class InfoMetaValidator : AbstractValidator<InfoMeta>
{
    public InfoMetaValidator()
    {
        RuleFor(x => x.Identifier)
            .GreaterThan(0)
            .WithMessage("Identifier must be a positive number.");

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name info must not be empty.")
            .MaximumLength(ApplicationRules.Strings.MaxMediumStringLength)
            .WithMessage($"Name info must not exceed {ApplicationRules.Strings.MaxMediumStringLength} characters.");
    }
}