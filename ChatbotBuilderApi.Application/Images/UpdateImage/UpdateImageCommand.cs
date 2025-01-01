using ChatbotBuilderApi.Application.Core.Abstract.Messaging;
using ChatbotBuilderApi.Domain.Images;
using ChatbotBuilderApi.Domain.Users;

namespace ChatbotBuilderApi.Application.Images.UpdateImage;

public sealed class UpdateImageCommand : ICommand
{
    public required ImageId ImageId { get; init; }
    public required UserId OwnerId { get; init; }
    public required ImageMeta ImageMeta { get; init; }
}