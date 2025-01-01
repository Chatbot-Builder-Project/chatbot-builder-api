using ChatbotBuilderApi.Application.Core.Shared.Responses;
using ChatbotBuilderApi.Domain.Images;

namespace ChatbotBuilderApi.Application.Images.ListImages;

public sealed record ListImagesResponse(PageResponse<ListImagesResponseItem> Page);

public sealed record ListImagesResponseItem(
    ImageId Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    string Url,
    string Name,
    string ContentType,
    ImageMeta ImageMeta);