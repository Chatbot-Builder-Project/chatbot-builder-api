using ChatbotBuilderApi.Application.Core.Shared.Responses;

namespace ChatbotBuilderApi.Presentation.Chatbots.ViewModels;

public sealed record ChatbotListViewModel(PageResponse<ChatbotListViewModelItem> Page);

public sealed record ChatbotListViewModelItem(
    Guid Id,
    Guid OwnerId,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    string Name,
    string Description,
    bool IsPublic);