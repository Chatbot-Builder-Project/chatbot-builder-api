using FluentValidation;

namespace ChatbotBuilderApi.Application.Images.UpdateImage;

public sealed class UpdateImageCommandValidator : AbstractValidator<UpdateImageCommand>
{
    public UpdateImageCommandValidator()
    {
        RuleFor(c => c.ImageId)
            .NotEmpty();

        RuleFor(c => c.OwnerId)
            .NotEmpty();
    }
}