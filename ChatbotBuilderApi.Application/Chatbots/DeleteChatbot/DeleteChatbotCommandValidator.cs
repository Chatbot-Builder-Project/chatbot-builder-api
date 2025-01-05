using FluentValidation;

namespace ChatbotBuilderApi.Application.Chatbots.DeleteChatbot;

public sealed class DeleteChatbotCommandValidator : AbstractValidator<DeleteChatbotCommand>
{
    public DeleteChatbotCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Chatbot Id is required.");

        RuleFor(x => x.OwnerId)
            .NotEmpty()
            .WithMessage("Owner Id is required.");
    }
}