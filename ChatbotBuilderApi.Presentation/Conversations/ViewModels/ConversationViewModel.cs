namespace ChatbotBuilderApi.Presentation.Conversations.ViewModels;

public sealed record ConversationViewModel(
    Guid Id,
    Guid ChatbotId,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    string Name);