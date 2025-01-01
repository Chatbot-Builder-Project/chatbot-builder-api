using ChatbotBuilderApi.Application.Core.Abstract.Messaging;
using ChatbotBuilderApi.Application.Core.Shared;
using ChatbotBuilderApi.Application.Core.Shared.Responses;
using ChatbotBuilderApi.Domain.Images;
using ChatbotBuilderApi.Domain.Users;

namespace ChatbotBuilderApi.Application.Images.UploadImage;

public sealed class UploadImageCommand : ICommand<CreateResponse<ImageId>>
{
    public required UserId UserId { get; init; }
    public required FileUpload FileUpload { get; init; }
    public required ImageMeta ImageMeta { get; init; }
}