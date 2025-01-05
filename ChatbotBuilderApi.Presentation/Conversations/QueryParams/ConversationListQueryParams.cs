using ChatbotBuilderApi.Application.Core.Shared;

namespace ChatbotBuilderApi.Presentation.Conversations.QueryParams;

/// <summary>
/// Query parameters for the list of conversations.
/// </summary>
/// <param name="PageParams">Page parameters for the list of conversations.</param>
/// <param name="Search">Only conversations with names that contain the search string will be returned.</param>
/// <param name="ChatbotId">Only conversations for the chatbot with the specified ID will be returned.</param>
public sealed record ConversationListQueryParams(
    PageParams PageParams,
    string? Search,
    Guid? ChatbotId);