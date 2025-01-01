using FluentValidation;

namespace ChatbotBuilderApi.Application.Core.Shared.Validators;

public sealed class FileUploadValidator : AbstractValidator<FileUpload>
{
    public FileUploadValidator(IReadOnlySet<string>? allowedContentTypes = null)
    {
        RuleFor(x => x.FileName)
            .NotEmpty()
            .WithMessage("File name must not be empty.")
            .MaximumLength(255)
            .WithMessage("File name must not exceed 255 characters.");

        RuleFor(x => x.ContentType)
            .Must(ct => allowedContentTypes == null || allowedContentTypes.Contains(ct))
            .WithMessage("Content type is not allowed.");

        RuleFor(x => x.FileStream)
            .Must(f => f.Length > 0)
            .WithMessage("File must not be empty.")
            .Must(f => f.Length <= 5 * 1024 * 1024)
            .WithMessage("File must not exceed 5 MB.");
    }
}