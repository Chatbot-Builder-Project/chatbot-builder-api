using ChatbotBuilderApi.Domain.Core.Primitives;

namespace ChatbotBuilderApi.Application.Conversations;

public static class ConversationApplicationErrors
{
    public static readonly Error ChatbotNotFound = Error.NotFound(
        "Conversations.ChatbotNotFound",
        "Chatbot not found.");

    public static readonly Error ConversationNotFound = Error.NotFound(
        "Conversations.ConversationNotFound",
        "Conversation not found.");
}