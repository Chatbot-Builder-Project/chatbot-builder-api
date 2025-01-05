using ChatbotBuilderApi.Application.Core;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Interactions;
using FluentValidation;

namespace ChatbotBuilderApi.Application.Graphs.Shared.Interactions;

public sealed class InteractionOptionMetaValidator : AbstractValidator<InteractionOptionMeta>
{
    public InteractionOptionMetaValidator()
    {
        RuleFor(x => x.Description)
            .MaximumLength(ApplicationRules.Strings.MaxLargeStringLength)
            .WithMessage("Option description must be less than " +
                         ApplicationRules.Strings.MaxLargeStringLength + " characters.");
    }
}