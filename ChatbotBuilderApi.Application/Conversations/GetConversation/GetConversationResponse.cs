using ChatbotBuilderApi.Domain.Chatbots.ValueObjects;
using ChatbotBuilderApi.Domain.Conversations.ValueObjects;

namespace ChatbotBuilderApi.Application.Conversations.GetConversation;

public sealed record GetConversationResponse(
    ConversationId Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    string Name,
    ChatbotId ChatbotId);