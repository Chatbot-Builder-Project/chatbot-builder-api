using ChatbotBuilderApi.Application.Core.Shared.Validators;
using FluentValidation;

namespace ChatbotBuilderApi.Application.Chatbots.ListChatbots;

public sealed class ListChatbotsQueryValidator : AbstractValidator<ListChatbotsQuery>
{
    public ListChatbotsQueryValidator()
    {
        RuleFor(x => x.PageParams)
            .SetValidator(new PageParamsValidator());

        RuleFor(x => x.UserId)
            .NotEmpty();

        RuleFor(x => x.Search)
            .MaximumLength(100);
    }
}