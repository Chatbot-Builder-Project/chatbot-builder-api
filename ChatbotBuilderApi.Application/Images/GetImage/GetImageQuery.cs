using ChatbotBuilderApi.Application.Core.Abstract.Messaging;
using ChatbotBuilderApi.Domain.Images;
using ChatbotBuilderApi.Domain.Users;

namespace ChatbotBuilderApi.Application.Images.GetImage;

public sealed class GetImageQuery : IQuery<GetImageResponse>
{
    public required ImageId ImageId { get; init; }
    public required UserId OwnerId { get; init; }
}