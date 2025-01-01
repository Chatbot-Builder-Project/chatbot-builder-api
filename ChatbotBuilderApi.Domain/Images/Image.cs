using ChatbotBuilderApi.Domain.Core.Primitives;
using ChatbotBuilderApi.Domain.Users;

namespace ChatbotBuilderApi.Domain.Images;

public sealed class Image : AggregateRoot<ImageId>
{
    public string Url { get; } = string.Empty;
    public string Name { get; } = string.Empty;
    public string ContentType { get; } = string.Empty;
    public Guid OwnerId { get; } // UserId is incompatible with IdentityUser<Guid>
    public ImageMeta Meta { get; private set; } = null!;

    private Image(
        ImageId id,
        string url,
        string name,
        string contentType,
        UserId ownerId,
        ImageMeta meta)
        : base(id)
    {
        Url = url;
        Name = name;
        ContentType = contentType;
        OwnerId = ownerId;
        Meta = meta;
    }

    /// <inheritdoc/>
    private Image()
    {
    }

    public static Image Create(
        ImageId id,
        string url,
        string name,
        string contentType,
        UserId ownerId,
        ImageMeta meta)
    {
        return new Image(id, url, name, contentType, ownerId, meta);
    }

    public void Update(ImageMeta meta)
    {
        Meta = meta;
    }
}