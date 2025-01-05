using ChatbotBuilderApi.Application.Core.Shared.Responses;

namespace ChatbotBuilderApi.Presentation.Conversations.ViewModels;

/// <summary>
/// A list of conversations.
/// </summary>
/// <param name="Page">Page of conversations.</param>
public sealed record ConversationListViewModel(PageResponse<ConversationListViewModelItem> Page);

/// <summary>
/// Item in the list of conversations.
/// </summary>
/// <param name="Id">ID of the conversation.</param>
/// <param name="ChatbotId">ID of the chatbot the conversation belongs to.</param>
/// <param name="CreatedAt">Date and time the conversation was created.</param>
/// <param name="UpdatedAt">Date and time the conversation was last updated.</param>
/// <param name="Name">Name of the conversation.</param>
public sealed record ConversationListViewModelItem(
    Guid Id,
    Guid ChatbotId,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    string Name);