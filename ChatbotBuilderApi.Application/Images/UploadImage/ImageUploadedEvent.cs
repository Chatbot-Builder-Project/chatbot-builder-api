using ChatbotBuilderApi.Application.Core.Abstract.Messaging;
using ChatbotBuilderApi.Domain.Images;
using ChatbotBuilderApi.Domain.Users;

namespace ChatbotBuilderApi.Application.Images.UploadImage;

public sealed record ImageUploadedEvent(
    ImageId ImageId,
    UserId OwnerId,
    ImageMeta ImageMeta
) : IEvent;