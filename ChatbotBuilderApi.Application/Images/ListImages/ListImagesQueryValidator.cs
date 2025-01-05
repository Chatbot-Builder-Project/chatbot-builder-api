using ChatbotBuilderApi.Application.Core;
using ChatbotBuilderApi.Application.Core.Validators;
using FluentValidation;

namespace ChatbotBuilderApi.Application.Images.ListImages;

public sealed class ListImagesQueryValidator : AbstractValidator<ListImagesQuery>
{
    public ListImagesQueryValidator()
    {
        RuleFor(x => x.PageParams)
            .SetValidator(new PageParamsValidator());

        RuleFor(x => x.OwnerId)
            .NotEmpty()
            .WithMessage("Owner Id must not be empty.");

        RuleFor(x => x.Search)
            .MaximumLength(ApplicationRules.Strings.MaxSmallStringLength)
            .WithMessage($"Search must not exceed {ApplicationRules.Strings.MaxSmallStringLength} characters.");
    }
}