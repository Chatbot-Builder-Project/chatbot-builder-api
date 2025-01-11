using ChatbotBuilderApi.Application.Graphs.Ports.InputPorts;
using ChatbotBuilderApi.Application.Graphs.Shared.Data;
using FluentValidation;

namespace ChatbotBuilderApi.Application.Graphs.Nodes.Switch;

public abstract class SwitchNodeValidatorBase<TSwitch> : AbstractValidator<TSwitch>
    where TSwitch : SwitchNodeDtoBase
{
    public SwitchNodeValidatorBase()
    {
        RuleFor(x => x)
            .Must(x => x.InputPort.NodeIdentifier == x.Info.Identifier)
            .WithMessage("InputPort node identifier must match node identifier.");

        RuleFor(x => x.Bindings)
            .ChildRules(b => b
                .RuleForEach(meta => meta.Keys)
                .SetValidator(new OptionDataValidator()));
    }
}