using FluentValidation;

namespace ChatbotBuilderApi.Application.Conversations.GetConversation;

public sealed class GetConversationQueryValidator : AbstractValidator<GetConversationQuery>
{
    public GetConversationQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Conversation Id is required.");

        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("User Id is required.");
    }
}