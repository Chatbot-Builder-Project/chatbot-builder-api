using ChatbotBuilderApi.Application.Core.Extensions;
using ChatbotBuilderApi.Application.Graphs.Ports.InputPorts;
using ChatbotBuilderApi.Application.Graphs.Ports.OutputPorts;
using ChatbotBuilderApi.Application.Graphs.Shared.Data;
using FluentValidation;

namespace ChatbotBuilderApi.Application.Graphs.Nodes.Prompt;

public sealed class PromptNodeValidator : AbstractValidator<PromptNodeDto>
{
    public PromptNodeValidator()
    {
        RuleFor(x => x.Type)
            .Must(t => t == NodeType.Prompt);

        RuleFor(x => x.Template)
            .ChildRules(t => t
                .RuleFor(x => x.Text)
                .MaximumLength(1000));

        RuleFor(x => x.OutputPort)
            .SetValidator(new OutputPortValidator(DataType.Text));

        RuleFor(x => x)
            .Must(x => x.OutputPort.NodeIdentifier == x.Info.Identifier);

        RuleFor(x => x.InputPorts)
            .IsUnique();

        RuleForEach(x => x.InputPorts)
            .SetValidator(new InputPortValidator(DataType.Text));

        RuleFor(x => x)
            .Must(x => x.InputPorts.All(ip => ip.NodeIdentifier == x.Info.Identifier));
    }
}