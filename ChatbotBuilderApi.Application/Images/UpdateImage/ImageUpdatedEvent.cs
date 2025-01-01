using ChatbotBuilderApi.Application.Core.Abstract.Messaging;
using ChatbotBuilderApi.Domain.Images;
using ChatbotBuilderApi.Domain.Users;

namespace ChatbotBuilderApi.Application.Images.UpdateImage;

public sealed record ImageUpdatedEvent(
    ImageId ImageId,
    UserId OwnerId,
    ImageMeta ImageMeta
) : IEvent;