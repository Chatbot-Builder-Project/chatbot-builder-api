using ChatbotBuilderApi.Presentation.Graphs.Metas;

namespace ChatbotBuilderApi.Presentation.Conversations.ViewModels;

/// <summary>
/// View model for a conversation.
/// </summary>
/// <param name="Id">ID of the conversation.</param>
/// <param name="ChatbotId">ID of the chatbot the conversation belongs to.</param>
/// <param name="CreatedAt">Date and time the conversation was created.</param>
/// <param name="UpdatedAt">Date and time the conversation was last updated.</param>
/// <param name="Name">Name of the conversation.</param>
/// <param name="Visual">Generic visual metadata of the conversation.</param>
public sealed record ConversationViewModel(
    Guid Id,
    Guid ChatbotId,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    string Name,
    VisualMetaModel Visual);