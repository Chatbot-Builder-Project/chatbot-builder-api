using ChatbotBuilderApi.Application.Core.Abstract.Messaging;
using ChatbotBuilderApi.Application.Core.Shared;
using ChatbotBuilderApi.Domain.Users;

namespace ChatbotBuilderApi.Application.Images.ListImages;

public sealed class ListImagesQuery : IQuery<ListImagesResponse>
{
    public required PageParams PageParams { get; init; }
    public required UserId OwnerId { get; init; }
    public required bool IncludeOnlyProfilePictures { get; init; }
    public string? Search { get; init; }
}