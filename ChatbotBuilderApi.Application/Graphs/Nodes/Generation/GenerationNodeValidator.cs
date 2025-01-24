using ChatbotBuilderApi.Application.Core.Validators;
using ChatbotBuilderApi.Application.Graphs.Ports.InputPorts;
using ChatbotBuilderApi.Application.Graphs.Ports.OutputPorts;
using ChatbotBuilderApi.Application.Graphs.Shared.Data;
using FluentValidation;

namespace ChatbotBuilderApi.Application.Graphs.Nodes.Generation;

public sealed class GenerationNodeValidator : AbstractValidator<GenerationNodeDto>
{
    public GenerationNodeValidator()
    {
        RuleFor(x => x.Type)
            .Must(t => t == NodeType.Generation)
            .WithMessage("Node type must be Generation.");

        RuleFor(x => x.InputPort)
            .SetValidator(new InputPortValidator(DataType.Text));

        RuleFor(x => x.OutputPort)
            .SetValidator(new OutputPortValidator(DataType.Text));

        RuleFor(x => x.Options)
            .ChildRules(x => x
                .RuleFor(o => o.ResponseSchema)
                .SetValidator(new JObjectValidator()));
    }
}