using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Data;
using FluentValidation;

namespace ChatbotBuilderApi.Application.Graphs.Shared.Data;

public sealed class TextDataValidator : AbstractValidator<TextData>
{
    public TextDataValidator()
    {
        RuleFor(x => x.Text)
            .MaximumLength(1000);
    }
}