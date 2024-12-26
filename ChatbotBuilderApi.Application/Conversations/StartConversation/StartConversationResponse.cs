using ChatbotBuilderApi.Domain.Conversations.ValueObjects;

namespace ChatbotBuilderApi.Application.Conversations.StartConversation;

public sealed record StartConversationResponse(
    ConversationId ConversationId,
    OutputMessage InitialMessage);