using ChatbotBuilderApi.Presentation.Graphs.Metas;

namespace ChatbotBuilderApi.Presentation.Conversations.Requests;

/// <summary>
/// Request to update a conversation.
/// </summary>
/// <param name="Name">Name of the conversation.</param>
/// <param name="Visual">Generic visual metadata of the conversation.</param>
public sealed record UpdateConversationRequest(
    string Name,
    VisualMetaModel Visual);