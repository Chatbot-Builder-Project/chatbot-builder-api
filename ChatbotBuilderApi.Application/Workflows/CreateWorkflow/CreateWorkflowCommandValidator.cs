using ChatbotBuilderApi.Application.Core;
using ChatbotBuilderApi.Application.Graphs;
using FluentValidation;

namespace ChatbotBuilderApi.Application.Workflows.CreateWorkflow;

public sealed class CreateWorkflowCommandValidator : AbstractValidator<CreateWorkflowCommand>
{
    public CreateWorkflowCommandValidator()
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
    }
}