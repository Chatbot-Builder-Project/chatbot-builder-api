using FluentValidation;

namespace ChatbotBuilderApi.Application.Images.UpdateImage;

public sealed class UpdateImageCommandValidator : AbstractValidator<UpdateImageCommand>
{
    public UpdateImageCommandValidator()
    {
        RuleFor(c => c.ImageId)
            .NotEmpty()
            .WithMessage("Image Id must not be empty.");

        RuleFor(c => c.OwnerId)
            .NotEmpty()
            .WithMessage("Owner Id must not be empty.");
    }
}