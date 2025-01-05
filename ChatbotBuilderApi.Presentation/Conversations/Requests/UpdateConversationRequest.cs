namespace ChatbotBuilderApi.Presentation.Conversations.Requests;

/// <summary>
/// Request to update a conversation.
/// </summary>
/// <param name="Name">Name of the conversation.</param>
public sealed record UpdateConversationRequest(string Name);