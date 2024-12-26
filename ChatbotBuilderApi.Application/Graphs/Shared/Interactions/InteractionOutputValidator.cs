using ChatbotBuilderApi.Application.Graphs.Shared.Data;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Interactions;
using FluentValidation;

namespace ChatbotBuilderApi.Application.Graphs.Shared.Interactions;

public sealed class InteractionOutputValidator : AbstractValidator<InteractionOutput>
{
    public InteractionOutputValidator()
    {
        RuleFor(x => x.TextOutput)
            .SetValidator(new TextDataValidator()!)
            .When(x => x.TextOutput is not null);

        RuleFor(x => x.ExpectedOptionMetas)
            .ChildRules(oom =>
            {
                oom.RuleForEach(meta => meta!.Keys)
                    .SetValidator(new OptionDataValidator());

                oom.RuleForEach(meta => meta!.Values)
                    .SetValidator(new InteractionOptionMetaValidator());
            })
            .When(x => x.ExpectedOptionMetas is not null);
    }
}