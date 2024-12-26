using ChatbotBuilderApi.Application.Graphs;
using FluentValidation;

namespace ChatbotBuilderApi.Application.Workflows.UpdateWorkflow;

public sealed class UpdateWorkflowCommandValidator : AbstractValidator<UpdateWorkflowCommand>
{
    public UpdateWorkflowCommandValidator()
    {
        RuleFor(x => x.OwnerId)
            .NotEmpty();

        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Description)
            .NotEmpty()
            .MaximumLength(1000);

        RuleFor(x => x.Graph)
            .SetValidator(new GraphValidator());
    }
}