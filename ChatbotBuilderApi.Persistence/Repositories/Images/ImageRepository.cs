using ChatbotBuilderApi.Application.Images;
using ChatbotBuilderApi.Domain.Images;
using ChatbotBuilderApi.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace ChatbotBuilderApi.Persistence.Repositories.Images;

public sealed class ImageRepository : IImageRepository
{
    private readonly AppDbContext _context;

    public ImageRepository(AppDbContext context)
    {
        _context = context;
    }


    public async Task<Image?> GetByIdAndOwnerAsync(ImageId imageId, UserId ownerId, CancellationToken cancellationToken)
    {
        return await _context.Set<Image>()
            .Where(x =>
                x.Id == imageId &&
                x.OwnerId == ownerId)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public Task<int> GetCountByOwnerAsync(UserId ownerId, CancellationToken cancellationToken)
    {
        return _context.Set<Image>()
            .CountAsync(x => x.OwnerId == ownerId, cancellationToken);
    }
}