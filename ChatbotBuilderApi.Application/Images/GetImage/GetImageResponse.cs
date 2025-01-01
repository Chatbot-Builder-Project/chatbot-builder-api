using ChatbotBuilderApi.Domain.Images;

namespace ChatbotBuilderApi.Application.Images.GetImage;

public record GetImageResponse(
    ImageId Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    string Url,
    string Name,
    string ContentType,
    ImageMeta ImageMeta);