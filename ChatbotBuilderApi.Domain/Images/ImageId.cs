using ChatbotBuilderApi.Domain.Core.Primitives;

namespace ChatbotBuilderApi.Domain.Images;

public sealed class ImageId : EntityId<ImageId>
{
    public ImageId(Guid value) : base(value)
    {
    }
}