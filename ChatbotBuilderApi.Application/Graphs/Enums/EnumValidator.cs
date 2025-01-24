using ChatbotBuilderApi.Application.Core.Extensions;
using ChatbotBuilderApi.Application.Graphs.Shared.Data;
using ChatbotBuilderApi.Application.Graphs.Shared.Metas;
using FluentValidation;

namespace ChatbotBuilderApi.Application.Graphs.Enums;

public sealed class EnumValidator : AbstractValidator<EnumDto>
{
    public EnumValidator()
    {
        RuleFor(x => x.Info)
            .SetValidator(new InfoMetaValidator());

        RuleFor(x => x.Visual)
            .SetValidator(new VisualMetaValidator());

        RuleFor(x => x.Options)
            .NotEmpty()
            .WithMessage("Options are required.")
            .MustBeUnique()
            .WithMessage("Options must be unique.");

        RuleForEach(x => x.Options)
            .SetValidator(new OptionDataValidator());
    }
}