using ChatbotBuilderApi.Application.Core.Extensions;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Data;
using FluentValidation;

namespace ChatbotBuilderApi.Application.Graphs.Shared.Data;

public sealed class ImageDataValidator : AbstractValidator<ImageData>
{
    public ImageDataValidator()
    {
        RuleFor(x => x.Url)
            .MustBeUrl()
            .WithMessage("Image Url must be a valid url.");
    }
}