using ChatbotBuilderApi.Application.Core.Validators;
using FluentValidation;

namespace ChatbotBuilderApi.Application.Conversations.ListMessages;

public sealed class ListMessagesQueryValidator : AbstractValidator<ListMessagesQuery>
{
    public ListMessagesQueryValidator()
    {
        RuleFor(x => x.ConversationId)
            .NotEmpty()
            .WithMessage("Conversation Id is required.");

        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("User Id is required.");

        RuleFor(x => x.PageParams)
            .SetValidator(new PageParamsValidator());
    }
}