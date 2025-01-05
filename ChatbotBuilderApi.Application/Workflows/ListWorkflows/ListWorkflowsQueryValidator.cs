using ChatbotBuilderApi.Application.Core;
using ChatbotBuilderApi.Application.Core.Validators;
using FluentValidation;

namespace ChatbotBuilderApi.Application.Workflows.ListWorkflows;

public sealed class ListWorkflowsQueryValidator : AbstractValidator<ListWorkflowsQuery>
{
    public ListWorkflowsQueryValidator()
    {
        RuleFor(x => x.OwnerId)
            .NotEmpty()
            .WithMessage("Owner Id must not be empty.");

        RuleFor(x => x.Search)
            .MaximumLength(ApplicationRules.Strings.MaxSmallStringLength)
            .WithMessage($"Search must not exceed {ApplicationRules.Strings.MaxSmallStringLength} characters.");

        RuleFor(x => x.PageParams)
            .SetValidator(new PageParamsValidator());
    }
}