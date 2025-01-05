using ChatbotBuilderApi.Application.Core;
using FluentValidation;

namespace ChatbotBuilderApi.Application.Conversations.SendMessage;

public sealed class SendMessageCommandValidator : AbstractValidator<SendMessageCommand>
{
    public SendMessageCommandValidator()
    {
        RuleFor(x => x.ConversationId)
            .NotEmpty()
            .WithMessage("Conversation Id is required.");

        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("User Id is required.");

        RuleFor(x => x.InputMessage.Input)
            .ChildRules(i => i
                .RuleFor(x => x.Text)
                .Must(t => t == null || t.Text.Length <= ApplicationRules.Strings.MaxLargeStringLength)
                .WithMessage("InputMessage Text must be less than " +
                             ApplicationRules.Strings.MaxSmallStringLength + " characters."));
    }
}