using ChatbotBuilderApi.Application.Core;
using FluentValidation;

namespace ChatbotBuilderApi.Application.Conversations.UpdateConversation;

public sealed class UpdateConversationCommandValidator : AbstractValidator<UpdateConversationCommand>
{
    public UpdateConversationCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Conversation Id is required.");

        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("User Id is required.");

        RuleFor(x => x.Name)
            .MaximumLength(ApplicationRules.Strings.MaxSmallStringLength)
            .WithMessage($"Name must be less than {ApplicationRules.Strings.MaxSmallStringLength} characters.");
    }
}