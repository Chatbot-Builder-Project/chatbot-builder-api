using ChatbotBuilderApi.Application.Graphs.Shared.Data;
using ChatbotBuilderApi.Application.Graphs.Shared.Metas;
using FluentValidation;

namespace ChatbotBuilderApi.Application.Graphs.Ports.InputPorts;

public sealed class InputPortValidator : AbstractValidator<InputPortDto>
{
    public InputPortValidator()
    {
        RuleFor(x => x.Info)
            .SetValidator(new InfoMetaValidator());

        RuleFor(x => x.Visual)
            .SetValidator(new VisualMetaValidator());

        RuleFor(x => x.DataType)
            .IsInEnum()
            .WithMessage("Data type must be a valid enum value.");
    }

    public InputPortValidator(DataType dataType) : this()
    {
        RuleFor(x => x.DataType)
            .Must(dt => dt == dataType)
            .WithMessage($"Input port data type must be {dataType}.");
    }
}