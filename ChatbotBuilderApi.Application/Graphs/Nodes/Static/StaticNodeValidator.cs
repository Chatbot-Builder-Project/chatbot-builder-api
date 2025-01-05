using ChatbotBuilderApi.Application.Graphs.Ports.OutputPorts;
using ChatbotBuilderApi.Application.Graphs.Shared.Data.Extensions;
using FluentValidation;

namespace ChatbotBuilderApi.Application.Graphs.Nodes.Static;

public sealed class StaticNodeValidator : AbstractValidator<StaticNodeDto>
{
    public StaticNodeValidator()
    {
        RuleFor(x => x.Type)
            .Must(t => t == NodeType.Static)
            .WithMessage("Node type must be Static.");

        RuleFor(x => x)
            .Must(x => x.Data.ToDataType() == x.OutputPort.DataType)
            .WithMessage("OutputPort data type must match data type.");

        RuleFor(x => x.OutputPort)
            .SetValidator(new OutputPortValidator());

        RuleFor(x => x)
            .Must(x => x.OutputPort.NodeIdentifier == x.Info.Identifier)
            .WithMessage("OutputPort node identifier must match node identifier.");

        RuleFor(x => x.Data)
            .SetValidator(x => x.Data.GetValidator());
    }
}