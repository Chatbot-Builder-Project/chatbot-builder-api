using ChatbotBuilderApi.Application.Core.Abstract.Messaging;
using ChatbotBuilderApi.Domain.Chatbots.ValueObjects;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Data;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Meta;
using ChatbotBuilderApi.Domain.Users;

namespace ChatbotBuilderApi.Application.Chatbots.UpdateChatbot;

public sealed class UpdateChatbotCommand : ICommand
{
    public required ChatbotId Id { get; init; }
    public required UserId OwnerId { get; init; }
    public required string Name { get; init; }
    public required string Description { get; init; }
    public required bool IsPublic { get; init; }
    public ImageData? AvatarImageData { get; init; }
    public required VisualMeta Visual { get; init; }
}