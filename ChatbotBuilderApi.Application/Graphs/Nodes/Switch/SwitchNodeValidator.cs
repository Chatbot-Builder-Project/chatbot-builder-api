using ChatbotBuilderApi.Application.Graphs.Ports.InputPorts;
using ChatbotBuilderApi.Application.Graphs.Shared.Data;
using FluentValidation;

namespace ChatbotBuilderApi.Application.Graphs.Nodes.Switch;

public sealed class SwitchNodeValidator : SwitchNodeValidatorBase<SwitchNodeDto>
{
    public SwitchNodeValidator()
    {
        RuleFor(x => x.Type)
            .Must(t => t == NodeType.Switch)
            .WithMessage("Node type must be Switch.");

        RuleFor(x => x.InputPort)
            .SetValidator(new InputPortValidator(DataType.Option));
    }
}