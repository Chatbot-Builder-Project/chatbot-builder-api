using ChatbotBuilderApi.Application.Core.Abstract.Messaging;
using ChatbotBuilderApi.Application.Core.Shared;
using ChatbotBuilderApi.Domain.Conversations.ValueObjects;
using ChatbotBuilderApi.Domain.Users;

namespace ChatbotBuilderApi.Application.Conversations.ListMessages;

public sealed class ListMessagesQuery : IQuery<ListMessagesResponse>
{
    public required ConversationId ConversationId { get; init; }
    public required UserId UserId { get; init; }
    public required PageParams PageParams { get; init; }
}