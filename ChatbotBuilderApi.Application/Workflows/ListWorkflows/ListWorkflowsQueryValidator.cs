using ChatbotBuilderApi.Application.Core.Validators;
using FluentValidation;

namespace ChatbotBuilderApi.Application.Workflows.ListWorkflows;

public sealed class ListWorkflowsQueryValidator : AbstractValidator<ListWorkflowsQuery>
{
    public ListWorkflowsQueryValidator()
    {
        RuleFor(x => x.OwnerId)
            .NotEmpty();

        RuleFor(x => x.Search)
            .MaximumLength(100);

        RuleFor(x => x.PageParams)
            .SetValidator(new PageParamsValidator());
    }
}