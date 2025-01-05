using FluentValidation;

namespace ChatbotBuilderApi.Application.Chatbots.CreateChatbot;

public sealed class CreateChatbotCommandValidator : AbstractValidator<CreateChatbotCommand>
{
    public CreateChatbotCommandValidator()
    {
        RuleFor(x => x.WorkflowId)
            .NotEmpty()
            .WithMessage("WorkflowId is required.");
    }
}