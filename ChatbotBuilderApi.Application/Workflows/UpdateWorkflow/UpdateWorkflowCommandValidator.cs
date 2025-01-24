using ChatbotBuilderApi.Application.Core;
using ChatbotBuilderApi.Application.Graphs;
using ChatbotBuilderApi.Application.Graphs.Shared.Metas;
using FluentValidation;

namespace ChatbotBuilderApi.Application.Workflows.UpdateWorkflow;

public sealed class UpdateWorkflowCommandValidator : AbstractValidator<UpdateWorkflowCommand>
{
    public UpdateWorkflowCommandValidator()
    {
        RuleFor(x => x.OwnerId)
            .NotEmpty()
            .WithMessage("Owner Id must not be empty.");

        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(ApplicationRules.Strings.MaxSmallStringLength)
            .WithMessage($"Name must not exceed {ApplicationRules.Strings.MaxSmallStringLength} characters.");

        RuleFor(x => x.Description)
            .NotEmpty()
            .MaximumLength(ApplicationRules.Strings.MaxLargeStringLength)
            .WithMessage($"Description must not exceed {ApplicationRules.Strings.MaxLargeStringLength} characters.");

        RuleFor(x => x.Graph)
            .SetValidator(new GraphValidator());

        RuleFor(x => x.Visual)
            .SetValidator(new VisualMetaValidator());
    }
}