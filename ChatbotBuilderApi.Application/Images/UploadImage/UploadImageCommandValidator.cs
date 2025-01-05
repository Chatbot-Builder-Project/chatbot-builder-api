using ChatbotBuilderApi.Application.Core.Validators;
using FluentValidation;

namespace ChatbotBuilderApi.Application.Images.UploadImage;

public sealed class UploadImageCommandValidator : AbstractValidator<UploadImageCommand>
{
    public UploadImageCommandValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("User ID must not be empty.");

        RuleFor(x => x.FileUpload)
            .SetValidator(new FileUploadValidator(ImageApplicationRules.MaxImageSizeInBytes));
    }
}