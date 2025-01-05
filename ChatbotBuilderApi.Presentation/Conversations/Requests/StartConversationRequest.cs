namespace ChatbotBuilderApi.Presentation.Conversations.Requests;

/// <summary>
/// Request to start a conversation.
/// </summary>
/// <param name="ChatbotId">ID of the chatbot the conversation belongs to.</param>
/// <param name="Name">Name of the conversation.</param>
public sealed record StartConversationRequest(
    Guid ChatbotId,
    string Name);