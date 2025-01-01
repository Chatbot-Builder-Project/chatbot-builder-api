using ChatbotBuilderApi.Application.Core.Shared.Responses;
using ChatbotBuilderApi.Application.Images;
using ChatbotBuilderApi.Application.Images.ListImages;
using ChatbotBuilderApi.Domain.Images;
using ChatbotBuilderApi.Domain.Users;
using ChatbotBuilderApi.Persistence.Repositories.Extensions;
using Microsoft.EntityFrameworkCore;

namespace ChatbotBuilderApi.Persistence.Repositories.Images;

public sealed class ImageRepository : IImageRepository
{
    private readonly AppDbContext _context;

    public ImageRepository(AppDbContext context)
    {
        _context = context;
    }


    public async Task<Image?> GetByIdAndOwnerAsync(
        ImageId imageId,
        UserId ownerId,
        CancellationToken cancellationToken)
    {
        return await _context.Set<Image>()
            .Where(x =>
                x.Id == imageId &&
                x.OwnerId == ownerId)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<int> GetCountByOwnerAsync(
        UserId ownerId,
        CancellationToken cancellationToken)
    {
        return await _context.Set<Image>()
            .CountAsync(x => x.OwnerId == ownerId, cancellationToken);
    }

    public async Task<PageResponse<ListImagesResponseItem>> ListByQueryAsync(
        ListImagesQuery query,
        CancellationToken cancellationToken)
    {
        return await _context.Set<Image>()
            .Where(i => i.OwnerId == query.OwnerId)
            .Where(i => !query.IncludeOnlyProfilePictures || i.Meta.IsProfilePicture)
            .Where(i => query.Search == null || i.Name.Contains(query.Search))
            .OrderByDescending(i => i.CreatedAt)
            .Select(i => new ListImagesResponseItem(
                i.Id,
                i.CreatedAt,
                i.UpdatedAt,
                i.Url,
                i.Name,
                i.ContentType,
                i.Meta))
            .PageResponseAsync(query.PageParams, cancellationToken);
    }
}