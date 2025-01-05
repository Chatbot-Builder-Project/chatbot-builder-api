using ChatbotBuilderApi.Application.Core.Shared;
using FluentValidation;

namespace ChatbotBuilderApi.Application.Core.Validators;

public sealed class FileUploadValidator : AbstractValidator<FileUpload>
{
    public FileUploadValidator(
        int maxFileSizeInBytes = ApplicationRules.Files.MaxFileSizeInBytes,
        IReadOnlySet<string>? allowedContentTypes = null)
    {
        RuleFor(x => x.FileName)
            .NotEmpty()
            .WithMessage("File name must not be empty.")
            .MaximumLength(ApplicationRules.Strings.MaxMediumStringLength)
            .WithMessage($"File name must not exceed {ApplicationRules.Strings.MaxMediumStringLength} characters.");

        RuleFor(x => x.ContentType)
            .Must(ct => allowedContentTypes == null || allowedContentTypes.Contains(ct))
            .WithMessage("Content type is not allowed.");

        RuleFor(x => x.FileStream)
            .Must(f => f.Length > 0)
            .WithMessage("File must not be empty.")
            .Must(f => f.Length <= maxFileSizeInBytes)
            .WithMessage($"File must not exceed {maxFileSizeInBytes} bytes.");
    }
}