using ChatbotBuilderApi.Application.Core.Abstract.Messaging;
using ChatbotBuilderApi.Domain.Conversations.ValueObjects;
using ChatbotBuilderApi.Domain.Users;

namespace ChatbotBuilderApi.Application.Conversations.DeleteConversation;

public sealed record ConversationDeletedEvent(
    ConversationId ConversationId,
    UserId UserId
) : IEvent;