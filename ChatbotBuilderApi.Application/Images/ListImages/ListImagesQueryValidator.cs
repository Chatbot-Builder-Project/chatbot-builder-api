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
            .NotEmpty();

        RuleFor(x => x.Search)
            .MaximumLength(100)
            .WithMessage("Search must be less than 100 characters");
    }
}