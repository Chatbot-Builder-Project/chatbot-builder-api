using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Meta;
using FluentValidation;

namespace ChatbotBuilderApi.Application.Graphs.Shared.Metas;

public sealed class VisualMetaValidator : AbstractValidator<VisualMeta>
{
    public VisualMetaValidator()
    {
    }
}