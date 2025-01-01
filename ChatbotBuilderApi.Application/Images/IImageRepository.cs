using ChatbotBuilderApi.Application.Core.Shared.Responses;
using ChatbotBuilderApi.Application.Images.ListImages;
using ChatbotBuilderApi.Domain.Images;
using ChatbotBuilderApi.Domain.Users;

namespace ChatbotBuilderApi.Application.Images;

public interface IImageRepository
{
    Task<Image?> GetByIdAndOwnerAsync(
        ImageId imageId,
        UserId ownerId,
        CancellationToken cancellationToken);

    Task<int> GetCountByOwnerAsync(
        UserId ownerId,
        CancellationToken cancellationToken);

    Task<PageResponse<ListImagesResponseItem>> ListByQueryAsync(
        ListImagesQuery query,
        CancellationToken cancellationToken);
}