using ChatbotBuilderApi.Application.Graphs.Shared.Metas;
using FluentValidation;

namespace ChatbotBuilderApi.Application.Graphs.Links.FlowLinks;

public sealed class FlowLinkValidator : AbstractValidator<FlowLinkDto>
{
    public FlowLinkValidator()
    {
        RuleFor(x => x.Info)
            .SetValidator(new InfoMetaValidator());

        RuleFor(x => x.Visual)
            .SetValidator(new VisualMetaValidator());
    }
}