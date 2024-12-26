using ChatbotBuilderApi.Application.Core.Abstract.Messaging;
using ChatbotBuilderApi.Application.Core.Shared;
using ChatbotBuilderApi.Domain.Chatbots.ValueObjects;
using ChatbotBuilderApi.Domain.Users;

namespace ChatbotBuilderApi.Application.Conversations.ListConversations;

public sealed class ListConversationsQuery : IQuery<ListConversationsResponse>
{
    public required PageParams PageParams { get; init; }
    public required UserId UserId { get; init; }
    public string? Search { get; init; }
    public ChatbotId? ChatbotId { get; init; }
}