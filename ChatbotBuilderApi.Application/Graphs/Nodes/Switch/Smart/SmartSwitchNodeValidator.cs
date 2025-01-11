using ChatbotBuilderApi.Application.Graphs.Ports.InputPorts;
using ChatbotBuilderApi.Application.Graphs.Shared.Data;
using FluentValidation;

namespace ChatbotBuilderApi.Application.Graphs.Nodes.Switch.Smart;

public sealed class SmartSwitchNodeValidator : SwitchNodeValidatorBase<SmartSwitchNodeDto>
{
    public SmartSwitchNodeValidator()
    {
        RuleFor(x => x.Type)
            .Must(t => t == NodeType.SmartSwitch)
            .WithMessage("Node type must be SmartSwitch.");

        RuleFor(x => x.InputPort)
            .SetValidator(new InputPortValidator(DataType.Text));
    }
}