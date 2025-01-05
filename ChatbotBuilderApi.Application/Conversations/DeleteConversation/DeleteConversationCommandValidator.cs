using FluentValidation;

namespace ChatbotBuilderApi.Application.Conversations.DeleteConversation;

public sealed class DeleteConversationCommandValidator : AbstractValidator<DeleteConversationCommand>
{
    public DeleteConversationCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Conversation Id is required.");

        RuleFor(x => x.OwnerId)
            .NotEmpty()
            .WithMessage("Owner Id is required.");
    }
}