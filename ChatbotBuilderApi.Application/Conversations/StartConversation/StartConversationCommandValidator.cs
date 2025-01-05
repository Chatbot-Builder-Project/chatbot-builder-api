using ChatbotBuilderApi.Application.Core;
using FluentValidation;

namespace ChatbotBuilderApi.Application.Conversations.StartConversation;

public sealed class StartConversationCommandValidator : AbstractValidator<StartConversationCommand>
{
    public StartConversationCommandValidator()
    {
        RuleFor(x => x.ChatbotId)
            .NotEmpty()
            .WithMessage("Chatbot Id is required.");

        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("User Id is required.");

        RuleFor(x => x.Name)
            .MaximumLength(ApplicationRules.Strings.MaxSmallStringLength)
            .WithMessage($"Name must be less than {ApplicationRules.Strings.MaxSmallStringLength} characters.");
    }
}