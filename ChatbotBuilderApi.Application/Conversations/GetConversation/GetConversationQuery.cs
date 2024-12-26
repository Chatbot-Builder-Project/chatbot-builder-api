using ChatbotBuilderApi.Application.Core.Abstract.Messaging;
using ChatbotBuilderApi.Domain.Conversations.ValueObjects;
using ChatbotBuilderApi.Domain.Users;

namespace ChatbotBuilderApi.Application.Conversations.GetConversation;

public sealed class GetConversationQuery : IQuery<GetConversationResponse>
{
    public required ConversationId Id { get; init; }
    public required UserId UserId { get; init; }
}