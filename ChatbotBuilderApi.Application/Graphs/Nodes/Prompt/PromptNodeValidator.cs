using ChatbotBuilderApi.Application.Core;
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
            .Must(t => t == NodeType.Prompt)
            .WithMessage("Node type must be Prompt.");

        RuleFor(x => x.Template)
            .ChildRules(t => t
                .RuleFor(x => x.Text)
                .MaximumLength(ApplicationRules.Strings.MaxLargeStringLength)
                .WithMessage("Template text must be less than " +
                             ApplicationRules.Strings.MaxLargeStringLength + " characters."));

        RuleFor(x => x.OutputPort)
            .SetValidator(new OutputPortValidator(DataType.Text));

        RuleFor(x => x)
            .Must(x => x.OutputPort.NodeIdentifier == x.Info.Identifier)
            .WithMessage("OutputPort node identifier must match node identifier.");

        RuleFor(x => x.InputPorts)
            .MustBeUnique()
            .WithMessage("InputPorts must be unique.");

        RuleForEach(x => x.InputPorts)
            .SetValidator(new InputPortValidator(DataType.Text));

        RuleFor(x => x)
            .Must(x => x.InputPorts.All(ip => ip.NodeIdentifier == x.Info.Identifier))
            .WithMessage("All InputPorts node identifiers must match node identifier.");
    }
}