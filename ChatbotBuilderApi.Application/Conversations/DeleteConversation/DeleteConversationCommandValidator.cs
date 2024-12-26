using FluentValidation;

namespace ChatbotBuilderApi.Application.Conversations.DeleteConversation;

public sealed class DeleteConversationCommandValidator : AbstractValidator<DeleteConversationCommand>
{
    public DeleteConversationCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();

        RuleFor(x => x.OwnerId)
            .NotEmpty();
    }
}