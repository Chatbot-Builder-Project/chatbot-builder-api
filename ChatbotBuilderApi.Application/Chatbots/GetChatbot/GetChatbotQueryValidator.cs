using FluentValidation;

namespace ChatbotBuilderApi.Application.Chatbots.GetChatbot;

public sealed class GetChatbotQueryValidator : AbstractValidator<GetChatbotQuery>
{
    public GetChatbotQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Chatbot Id is required.");

        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("User Id is required.");
    }
}