using ChatbotBuilderApi.Application.Core.Abstract.Messaging;
using ChatbotBuilderApi.Domain.Conversations.ValueObjects;
using ChatbotBuilderApi.Domain.Graphs.ValueObjects.Meta;
using ChatbotBuilderApi.Domain.Users;

namespace ChatbotBuilderApi.Application.Conversations.UpdateConversation;

public sealed class UpdateConversationCommand : ICommand
{
    public required ConversationId Id { get; init; }
    public required UserId UserId { get; init; }
    public required string Name { get; init; }
    public required VisualMeta Visual { get; init; }
}