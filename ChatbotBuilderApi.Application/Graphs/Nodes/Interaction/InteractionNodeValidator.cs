using ChatbotBuilderApi.Application.Graphs.Ports.InputPorts;
using ChatbotBuilderApi.Application.Graphs.Ports.OutputPorts;
using ChatbotBuilderApi.Application.Graphs.Shared.Data;
using ChatbotBuilderApi.Application.Graphs.Shared.Interactions;
using FluentValidation;

namespace ChatbotBuilderApi.Application.Graphs.Nodes.Interaction;

public sealed class InteractionNodeValidator : AbstractValidator<InteractionNodeDto>
{
    public InteractionNodeValidator()
    {
        RuleFor(x => x.Type)
            .Must(t => t == NodeType.Interaction);

        When(x => x.TextInputPort is not null, () =>
        {
            RuleFor(x => x.TextInputPort)
                .SetValidator(new InputPortValidator(DataType.Text)!);

            RuleFor(x => x)
                .Must(x => x.TextInputPort!.NodeIdentifier == x.Info.Identifier);
        });

        When(x => x.TextOutputPort is not null, () =>
        {
            RuleFor(x => x.TextOutputPort)
                .SetValidator(new OutputPortValidator(DataType.Text)!);

            RuleFor(x => x)
                .Must(x => x.TextOutputPort!.NodeIdentifier == x.Info.Identifier);
        });

        When(x => x.OptionOutputPort is not null, () =>
        {
            RuleFor(x => x.OptionOutputPort)
                .SetValidator(new OutputPortValidator(DataType.Option)!);

            RuleFor(x => x)
                .Must(x => x.OptionOutputPort!.NodeIdentifier == x.Info.Identifier);
        });

        RuleFor(x => x.OutputOptionMetas)
            .ChildRules(oom =>
            {
                oom.RuleForEach(meta => meta!.Keys)
                    .SetValidator(new OptionDataValidator());

                oom.RuleForEach(meta => meta!.Values)
                    .SetValidator(new InteractionOptionMetaValidator());
            })
            .When(x => x.OutputOptionMetas is not null);
    }
}