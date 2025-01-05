using ChatbotBuilderApi.Application.Core;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Data;
using FluentValidation;

namespace ChatbotBuilderApi.Application.Graphs.Shared.Data;

public sealed class TextDataValidator : AbstractValidator<TextData>
{
    public TextDataValidator()
    {
        RuleFor(x => x.Text)
            .NotEmpty()
            .WithMessage("Text must not be empty.")
            .MaximumLength(ApplicationRules.Strings.MaxLargeStringLength)
            .WithMessage($"Text must be less than {ApplicationRules.Strings.MaxLargeStringLength} characters.");
    }
}