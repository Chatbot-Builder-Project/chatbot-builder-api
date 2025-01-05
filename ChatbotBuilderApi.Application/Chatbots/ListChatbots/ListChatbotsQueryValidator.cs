using ChatbotBuilderApi.Application.Core;
using ChatbotBuilderApi.Application.Core.Validators;
using FluentValidation;

namespace ChatbotBuilderApi.Application.Chatbots.ListChatbots;

public sealed class ListChatbotsQueryValidator : AbstractValidator<ListChatbotsQuery>
{
    public ListChatbotsQueryValidator()
    {
        RuleFor(x => x.PageParams)
            .SetValidator(new PageParamsValidator());

        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("User Id is required.");

        RuleFor(x => x.Search)
            .MaximumLength(ApplicationRules.Strings.MaxSmallStringLength)
            .WithMessage($"Search must be less than {ApplicationRules.Strings.MaxSmallStringLength} characters.");
    }
}