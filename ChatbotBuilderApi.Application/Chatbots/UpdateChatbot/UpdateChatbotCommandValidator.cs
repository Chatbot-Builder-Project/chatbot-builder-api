using ChatbotBuilderApi.Application.Core;
using ChatbotBuilderApi.Application.Graphs.Shared.Data;
using FluentValidation;

namespace ChatbotBuilderApi.Application.Chatbots.UpdateChatbot;

public sealed class UpdateChatbotCommandValidator : AbstractValidator<UpdateChatbotCommand>
{
    public UpdateChatbotCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required.")
            .MaximumLength(ApplicationRules.Strings.MaxSmallStringLength)
            .WithMessage($"Name must be less than {ApplicationRules.Strings.MaxSmallStringLength} characters.");

        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("Description is required.")
            .MaximumLength(ApplicationRules.Strings.MaxLargeStringLength)
            .WithMessage($"Description must be less than {ApplicationRules.Strings.MaxLargeStringLength} characters.");

        RuleFor(x => x.AvatarImageData)
            .SetValidator(new ImageDataValidator()!)
            .When(x => x.AvatarImageData is not null);
    }
}