using ChatbotBuilderApi.Application.Core.Shared;
using FluentValidation;

namespace ChatbotBuilderApi.Application.Core.Validators;

public sealed class PageParamsValidator : AbstractValidator<PageParams>
{
    public PageParamsValidator(int maxPageSize = ApplicationRules.Pages.MaxPageSize)
    {
        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1)
            .WithMessage("Page number must be greater than or equal to 1.");

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1)
            .WithMessage("Page size must be greater than or equal to 1.")
            .LessThanOrEqualTo(maxPageSize)
            .WithMessage($"Page size must not exceed {maxPageSize}.");
    }
}