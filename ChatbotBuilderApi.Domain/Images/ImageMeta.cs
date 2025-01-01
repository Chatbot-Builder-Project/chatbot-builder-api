using ChatbotBuilderApi.Domain.Core.Primitives;

namespace ChatbotBuilderApi.Domain.Images;

public sealed class ImageMeta : ValueObject
{
    public bool IsProfilePicture { get; }

    private ImageMeta(bool isProfilePicture)
    {
        IsProfilePicture = isProfilePicture;
    }

    /// <inheritdoc/>
    private ImageMeta()
    {
    }

    public static ImageMeta Create(bool isProfilePicture) => new(isProfilePicture);

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return IsProfilePicture;
    }
}