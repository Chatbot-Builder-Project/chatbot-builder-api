using ChatbotBuilderApi.Application.Core.Extensions;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Meta;
using FluentValidation;

namespace ChatbotBuilderApi.Application.Graphs.Shared.Metas;

public sealed class InfoMetaValidator : AbstractValidator<InfoMeta>
{
    public InfoMetaValidator()
    {
        RuleFor(x => x.Identifier)
            .GreaterThan(0);

        RuleFor(x => x.Name)
            .IsNotEmpty()
            .MaximumLength(100);
    }
}