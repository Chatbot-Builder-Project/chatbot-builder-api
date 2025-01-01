using ChatbotBuilderApi.Application.Core.Abstract.Messaging;
using ChatbotBuilderApi.Domain.Images;
using ChatbotBuilderApi.Domain.Users;

namespace ChatbotBuilderApi.Application.Images.DeleteImage;

public sealed class DeleteImageCommand : ICommand
{
    public required ImageId ImageId { get; init; }
    public required UserId OwnerId { get; init; }
}