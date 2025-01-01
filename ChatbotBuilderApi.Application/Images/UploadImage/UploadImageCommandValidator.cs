using ChatbotBuilderApi.Application.Core.Shared.Validators;
using FluentValidation;

namespace ChatbotBuilderApi.Application.Images.UploadImage;

public sealed class UploadImageCommandValidator : AbstractValidator<UploadImageCommand>
{
    public UploadImageCommandValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty();

        RuleFor(x => x.FileUpload)
            .SetValidator(new FileUploadValidator());
    }
}