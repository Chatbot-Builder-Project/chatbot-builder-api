using ChatbotBuilderApi.Application.Core.Shared.Responses;

namespace ChatbotBuilderApi.Presentation.Conversations.ViewModels;

public sealed record ConversationListViewModel(PageResponse<ConversationListViewModelItem> Page);

public sealed record ConversationListViewModelItem(
    Guid Id,
    Guid ChatbotId,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    string Name);