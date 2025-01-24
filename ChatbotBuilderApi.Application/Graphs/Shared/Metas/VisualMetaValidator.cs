using ChatbotBuilderApi.Application.Core.Validators;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Meta;
using FluentValidation;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ChatbotBuilderApi.Application.Graphs.Shared.Metas;

public sealed class VisualMetaValidator : AbstractValidator<VisualMeta>
{
    public VisualMetaValidator()
    {
        RuleFor(v => v.Data)
            .SetValidator(new JObjectValidator());
    }
}